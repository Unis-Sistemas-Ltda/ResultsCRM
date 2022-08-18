Public Class WFImpressaoProposta407
    Inherits System.Web.UI.Page

    Private ReadOnly Property Empresa()
        Get
            Return Request.QueryString.Item("eid")
        End Get
    End Property

    Private ReadOnly Property Estabelecimento()
        Get
            Return Request.QueryString.Item("sid")
        End Get
    End Property

    Private ReadOnly Property CodNegociacao()
        Get
            Return Request.QueryString.Item("nid")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        SqlDataSource2.DataBind()
        GridView1.DataBind()
        Call CarregaFormulario()
    End Sub

    Private Sub CarregaFormulario()
        Dim objNegociacao As New UCLNegociacao(StrConexao)
        Dim dt As DataTable
        Dim valor As Double
        Dim codItem As String
        Dim ValorTotal As Double = 0
        Dim objStatus As New UCLStatusNegociacao
        Dim objChamado As New UCLAtendimento(StrConexao, Empresa(), Estabelecimento())
        Dim objEmitente As New UCLEmitente(StrConexao)
        Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexao)
        Dim objEstado As New UCLEstado
        Dim objCidade As New UCLCidade
        Dim objContato As New UCLContato
        Dim objChamadoProblema As New UCLChamadoProblema
        Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa
        Dim problemas As List(Of String)
        Dim gruposProblema As List(Of String)
        Dim objEquipamento As New UCLEquipamentoCliente(StrConexao)

        objNegociacao.Empresa = Empresa
        objNegociacao.Estabelecimento = Estabelecimento
        objNegociacao.CodNegociacao = CodNegociacao
        dt = objNegociacao.DadosNegociacao()

        If dt.Rows.Count > 0 Then
            objNegociacao.Buscar()

            ImgLogo.ImageUrl = "http://187.49.238.34/webdeskunis/imagens/logo_ativa.jpg"

            LblCodNegociacaoCliente.Text = CodNegociacao.ToString
            LblDataNegociacao.Text = objNegociacao.DataCadastramento

            objStatus.Codigo = objNegociacao.CodStatus
            If Not String.IsNullOrEmpty(objStatus.Codigo) Then
                If objStatus.Buscar() Then
                    LblStatusNegociacao.Text = objStatus.Descricao
                End If
            End If

            objChamado.Empresa = Empresa()
            objChamado.CodChamado = objNegociacao.CodChamado
            If Not String.IsNullOrEmpty(objNegociacao.CodChamado) Then
                If objChamado.Buscar() Then
                    LblOSCliente.Text = objChamado.OSCliente
                    LblCodChamado.Text = objChamado.CodChamado
                    Dim OSs As List(Of String) = objChamado.GetOSsChamado(Empresa(), Estabelecimento(), objChamado.CodChamado)
                    For Each os As String In OSs
                        LblCodOS.Text += os + ", "
                    Next
                    If LblCodOS.Text.Length > 2 Then
                        LblCodOS.Text = LblCodOS.Text.Substring(0, LblCodOS.Text.Length - 2)
                    End If
                    If Not String.IsNullOrEmpty(objChamado.CodEmitenteAtendimento) Then
                        objEmitente.CodEmitente = objChamado.CodEmitenteAtendimento
                        objEmitente.Buscar()
                        LblRazaoSocialClienteAtendimento.Text = objEmitente.Nome
                        LblNumeroPontoAtendimento.Text = objChamado.NumeroPontoAtendimento
                        If Not String.IsNullOrEmpty(objChamado.NumeroPontoAtendimento) Then
                            objPontoAtendimento.CodEmitente = objChamado.CodEmitenteAtendimento
                            objPontoAtendimento.NumeroPontoAtendimento = objChamado.NumeroPontoAtendimento
                            If objPontoAtendimento.Buscar() Then
                                LblNomePontoAtendimento.Text = objPontoAtendimento.Descricao
                                LblEnderecoPontoAtendimento.Text = objPontoAtendimento.Logradouro
                                If objPontoAtendimento.Numero <> "" Then
                                    LblEnderecoPontoAtendimento.Text += ", " + objPontoAtendimento.Numero
                                End If
                                LblEnderecoPontoAtendimento.Text += " " + objPontoAtendimento.Bairro


                                objCidade.CodPais = objPontoAtendimento.CodPais
                                objCidade.CodEstado = objPontoAtendimento.CodEstado
                                objCidade.CodCidade = objPontoAtendimento.CodCidade
                                If Not String.IsNullOrEmpty(objCidade.CodPais) AndAlso Not String.IsNullOrEmpty(objCidade.CodCidade) AndAlso Not String.IsNullOrEmpty(objCidade.CodEstado) Then
                                    objCidade.Buscar()
                                    LblCidadePontoAtendimento.Text = objCidade.NomeCidade

                                    objEstado.CodPais = objPontoAtendimento.CodPais
                                    objEstado.CodEstado = objPontoAtendimento.CodEstado
                                    objEstado.Buscar()
                                    LblCidadePontoAtendimento.Text += " / " + objEstado.Sigla
                                End If
                                LblUniorg.Text = objPontoAtendimento.NumeroUniorg
                            End If
                        End If
                        objContato.CodEmitente = objChamado.CodEmitenteAtendimento
                        objContato.Codigo = objChamado.CodContatoAtendimento
                        If Not String.IsNullOrEmpty(objContato.CodEmitente) AndAlso Not String.IsNullOrEmpty(objContato.Codigo) Then
                            If objContato.Buscar() Then
                                LblContatoPontoAtendimento.Text = objContato.Nome
                                LblMatriculaContatoPontoAtendimento.Text = objContato.Matricula
                            End If
                        End If
                        problemas = objChamadoProblema.GetProblemas(Empresa, objChamado.CodChamado)
                        gruposProblema = objChamadoProblema.GetGrupoProblemas(Empresa, objChamado.CodChamado)
                        For Each problema As String In problemas
                            LblProblemas.Text += problema + ", "
                        Next
                        If LblProblemas.Text.Length > 2 Then
                            LblProblemas.Text = LblProblemas.Text.Substring(0, LblProblemas.Text.Length - 2)
                        End If
                        For Each grupoProblema As String In gruposProblema
                            LblGrupoProblema.Text += grupoProblema + ", "
                        Next
                        If LblGrupoProblema.Text.Length > 2 Then
                            LblGrupoProblema.Text = LblGrupoProblema.Text.Substring(0, LblGrupoProblema.Text.Length - 2)
                        End If
                        If String.IsNullOrEmpty(objChamado.IntervencaoConjunta) Then
                            LblNecessariaIntervencaoConjunta.Text = "Não"
                        Else
                            LblNecessariaIntervencaoConjunta.Text = objChamado.IntervencaoConjunta.Replace("S", "Sim").Replace("N", "Não")
                        End If
                        LblNecessariaIntervencaoConjuntaEmpresa.Text = objChamado.IntervencaoConjuntaNarrativa
                    End If
                End If
            End If

            LblCabecalho.Text = ImprimeTexto(dt.Rows.Item(0).Item("cabecalho_proposta").ToString)
            LblRodape.Text = ImprimeTexto(dt.Rows.Item(0).Item("rodape_proposta").ToString)

            LblRazaoSocialEmpresa.Text = dt.Rows.Item(0).Item("nome_empresa").ToString
            LblEnderecoEmpresa.Text = dt.Rows.Item(0).Item("endereco_empresa").ToString + " CEP: " + dt.Rows.Item(0).Item("cep_empresa").ToString
            LblCidadeEmpresa.Text = dt.Rows.Item(0).Item("bairro_empresa").ToString + " - " + dt.Rows.Item(0).Item("cidade_empresa").ToString + "/" + dt.Rows.Item(0).Item("uf_empresa").ToString
            LblTelefoneEmpresa.Text = dt.Rows.Item(0).Item("fones_empresa").ToString
            LblEmailEmpresa.Text = dt.Rows.Item(0).Item("email_empresa").ToString
            LblCNPJEmpresa.Text = dt.Rows.Item(0).Item("cnpj_empresa").ToString.MascaraCNPJ

            LblRazaoSocialTomador.Text = dt.Rows.Item(0).Item("nome_cliente").ToString
            LblEnderecoTomador.Text = dt.Rows.Item(0).Item("endereco_cliente").ToString
            LblCidadeTomador.Text = dt.Rows.Item(0).Item("cidade_cliente").ToString + "/" + dt.Rows.Item(0).Item("uf_cliente").ToString
            LblTelefoneTomador.Text = dt.Rows.Item(0).Item("telefone_cliente").ToString
            LblCNPJTomador.Text = dt.Rows.Item(0).Item("cnpj_cliente").ToString.MascaraCNPJ
            LblInscricaoEstadualTomador.Text = dt.Rows.Item(0).Item("ie_cliente").ToString
            LblContatoTomador.Text = dt.Rows.Item(0).Item("contato_cliente").ToString
            LblContatoTomadorEmail.Text = dt.Rows.Item(0).Item("email_cliente").ToString

            LblObservacao.Text = "<br/>" + ImprimeTexto(dt.Rows.Item(0).Item("observacao").ToString)
            LblNomeAgenteVendas.Text = dt.Rows.Item(0).Item("nome_agente_vendas").ToString
        End If

        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                codItem = CType(row.FindControl("LblCodItem"), Label).Text
                valor = CDbl(CType(row.FindControl("LblValorMercadoria"), Label).Text)
                ValorTotal += valor
            End If
        Next

        If ValorTotal > 0 Then
            LblTotal.Text = ValorTotal.ToString("N2")
        End If

    End Sub

End Class