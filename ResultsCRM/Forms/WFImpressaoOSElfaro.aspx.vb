Partial Public Class WFImpressaoOSElfaro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objEmpresa As New UCLEmpresa
            Dim objEstabelecimento As New UCLEstabelecimento
            Dim objCidade As New UCLCidade
            Dim objEstado As New UCLEstado
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEmitenteAtendimento As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedidoVendaItem As New UCLPedidoVendaItem(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))

            objEmpresa.CodEmpresa = Empresa
            objEmpresa.Buscar()
            LblRazaoSocialEmpresa.Text = objEmpresa.RazaoSocial

            objEstabelecimento.CodEmpresa = Empresa
            objEstabelecimento.Estabelecimento = Estabelecimento
            objEstabelecimento.Buscar()
            LblEnderecoEmpresa.Text = objEstabelecimento.Rua + ", " + objEstabelecimento.Numero
            LblBairroEmpresa.Text = objEstabelecimento.Bairro

            objCidade.CodPais = objEstabelecimento.CodPais
            objCidade.CodEstado = objEstabelecimento.CodEstado
            objCidade.CodCidade = objEstabelecimento.CodCidade
            objCidade.Buscar()
            LblMunicipioEmpresa.Text = objCidade.NomeCidade

            objEstado.CodPais = objEstabelecimento.CodPais
            objEstado.CodEstado = objEstabelecimento.CodEstado
            objEstado.Buscar()
            LblUFEmpresa.Text = objEstado.Sigla

            LblTelefoneEmpresa1.Text = objEstabelecimento.Telefones
            LblTelefoneEmpresa2.Text = objEstabelecimento.Fax
            LblCNPJEmpresa.Text = objEstabelecimento.CNPJ.MascaraCNPJ
            LblInscEstEmpresa.Text = objEstabelecimento.InscEst

            LblCodOS.Text = CodPedidoVenda

            objPedido.empresa = Empresa
            objPedido.estabelecimento = Estabelecimento
            objPedido.codPedidoVenda = CodPedidoVenda
            objPedido.Buscar()

            LblCodChamado.Text = objPedido.codChamado

            objChamado.Empresa = Empresa
            objChamado.CodChamado = objPedido.codChamado
            objChamado.Buscar()

            LblDataAbertura.Text = objChamado.DataChamado
            If Not String.IsNullOrEmpty(objChamado.HoraChamado) Then
                LblDataAbertura.Text += " " + objChamado.HoraChamado
            End If
            LblPrevisaoEncerramento.Text = objPedido.dataEntrega
            If objPedido.HoraEntrega.Trim.Length = 0 Then
                LblPrevisaoEncerramento.Text += " " + objPedido.HoraEntrega
            End If
            LblCodOSCliente.Text = objChamado.OSCliente + " "

            objEmitente.CodEmitente = objPedido.codEmitente
            objEmitente.Buscar()

            objEnderecoEmitente.CodEmitente = objPedido.codEmitente
            objEnderecoEmitente.CNPJ = objPedido.cnpjFaturamento
            objEnderecoEmitente.Buscar()

            LblNomeTomador.Text = objEmitente.Nome
            If objPedido.cnpjFaturamento.Length = 11 Then
                LblCNPJTomador.Text = objPedido.cnpjFaturamento.MascaraCPF
            Else
                LblCNPJTomador.Text = objPedido.cnpjFaturamento.MascaraCNPJ
            End If

            LblEnderecoTomador.Text = objEnderecoEmitente.Logradouro + " " + objEnderecoEmitente.Numero.Trim
            LblBairroTomador.Text = objEnderecoEmitente.Bairro

            objCidade.CodPais = objEnderecoEmitente.CodPais
            objCidade.CodEstado = objEnderecoEmitente.CodEstado
            objCidade.CodCidade = objEnderecoEmitente.CodCidade
            If Not String.IsNullOrEmpty(objCidade.CodPais) And Not String.IsNullOrEmpty(objCidade.CodEstado) And Not String.IsNullOrEmpty(objCidade.CodCidade) Then
                objCidade.Buscar()
            End If
            LblMunicipioTomador.Text = objCidade.NomeCidade

            objEstado.CodPais = objEnderecoEmitente.CodPais
            objEstado.CodEstado = objEnderecoEmitente.CodEstado
            If Not String.IsNullOrEmpty(objEstado.CodPais) And Not String.IsNullOrEmpty(objEstado.CodEstado) Then
                objEstado.Buscar()
            End If
            LblMunicipioTomador.Text += " / " + objEstado.Sigla
            LblCEPTomador.Text = objEnderecoEmitente.CEP.MascaraCEP

            objEmitenteAtendimento.CodEmitente = objChamado.CodEmitenteAtendimento
            If Not String.IsNullOrEmpty(objEmitenteAtendimento.CodEmitente) Then
                objEmitenteAtendimento.Buscar()
            End If
            LblNomeClienteAtendimento.Text = objEmitenteAtendimento.Nome

            objPontoAtendimento.CodEmitente = objChamado.CodEmitenteAtendimento
            objPontoAtendimento.NumeroPontoAtendimento = objChamado.NumeroPontoAtendimento
            If Not String.IsNullOrEmpty(objPontoAtendimento.CodEmitente) And Not String.IsNullOrEmpty(objPontoAtendimento.NumeroPontoAtendimento) Then
                objPontoAtendimento.Buscar()
            End If

            LblEnderecoAtendimento.Text = objPontoAtendimento.Logradouro + ", " + objPontoAtendimento.Numero

            objCidade.CodPais = objPontoAtendimento.CodPais
            objCidade.CodEstado = objPontoAtendimento.CodEstado
            objCidade.CodCidade = objPontoAtendimento.CodCidade
            If Not String.IsNullOrEmpty(objCidade.CodPais) And Not String.IsNullOrEmpty(objCidade.CodEstado) And Not String.IsNullOrEmpty(objCidade.CodCidade) Then
                objCidade.Buscar()
            End If
            LblMunicipioAtendimento.Text = objCidade.NomeCidade

            objEstado.CodPais = objPontoAtendimento.CodPais
            objEstado.CodEstado = objPontoAtendimento.CodEstado
            If Not String.IsNullOrEmpty(objEstado.CodPais) And Not String.IsNullOrEmpty(objEstado.CodEstado) Then
                objEstado.Buscar()
            End If

            LblMunicipioAtendimento.Text += " / " + objEstado.Sigla

            LblBairroAtendimento.Text = objPontoAtendimento.Bairro
            LblCEPAtendimento.Text = objPontoAtendimento.CEP.MascaraCEP

            'Grid dos problemas e serviços solicitados
            GridView2.DataSourceID = ""
            GridView2.DataSource = DtGridProblemasServicosSolicitados()
            GridView2.DataBind()

            'Grid das causas
            GridView3.DataSourceID = ""
            GridView3.DataSource = DtGridCausas()
            GridView3.DataBind()

            'Grid dos problemas e serviços solicitados
            GridView4.DataSourceID = ""
            GridView4.DataSource = DtGridServicosRealizados()
            GridView4.DataBind()

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Function DtGridProblemasServicosSolicitados() As DataTable
        Try
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim StrSql As String = ""
            Dim dt As DataTable
            Dim NrLinhas As Long = 6

            StrSql += " select convert(varchar(4),p.seq_solicitacao) seq_solicitacao, replace(replace(p.servico_solicitado,char(13),''), char(10),'') servico_solicitado "
            StrSql += "  from pedido_venda_solicitacao p "
            StrSql += " where p.empresa          = " + Empresa
            StrSql += "   and p.estabelecimento  = " + Estabelecimento
            StrSql += "   and p.cod_pedido_venda = " + CodPedidoVenda
            StrSql += " order by p.seq_solicitacao "

            dt = ObjAcessoDados.BuscarDados(StrSql)

            For i As Long = dt.Rows.Count + 1 To nrLinhas
                dt.Rows.Add(dt.NewRow)
            Next

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function DtGridCausas() As DataTable
        Try
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim StrSql As String = ""
            Dim dt As DataTable
            Dim NrLinhas As Long = 6

            StrSql += " select p.seq_solicitacao, c.cod_causa, c.descricao"
            StrSql += "   from pedido_venda_solicitacao_causa p inner join causa c on p.cod_causa = c.cod_causa"
            StrSql += "  where p.empresa          = " + Empresa
            StrSql += "    and p.estabelecimento  = " + Estabelecimento
            StrSql += "    and p.cod_pedido_venda = " + CodPedidoVenda
            StrSql += "  order by p.seq_solicitacao, c.descricao "

            dt = ObjAcessoDados.BuscarDados(StrSql)

            For i As Long = dt.Rows.Count + 1 To NrLinhas
                dt.Rows.Add(dt.NewRow)
            Next

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function DtGridServicosRealizados() As DataTable
        Try
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim StrSql As String = ""
            Dim dt As DataTable
            Dim NrLinhas As Long = 6

            StrSql += " select convert(varchar(4),p.seq_solicitacao) seq_item, replace(replace(i.descricao,char(13),''), char(10),'') servico_realizado, replace(replace(p.narrativa,char(13),''), char(10),'') complemento_servico "
            StrSql += "   from pedido_venda_item p inner join item i on p.cod_item = i.cod_item "
            StrSql += " where p.empresa          = " + Empresa
            StrSql += "   and p.estabelecimento  = " + Estabelecimento
            StrSql += "   and p.cod_pedido_venda = " + CodPedidoVenda
            StrSql += " order by p.seq_solicitacao, p.seq_item "

            dt = ObjAcessoDados.BuscarDados(StrSql)

            For i As Long = dt.Rows.Count + 1 To NrLinhas
                dt.Rows.Add(dt.NewRow)
            Next

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private ReadOnly Property Empresa() As String
        Get
            Return Request.QueryString.Item("eid")
        End Get
    End Property

    Private ReadOnly Property Estabelecimento() As String
        Get
            Return Request.QueryString.Item("sid")
        End Get
    End Property

    Private ReadOnly Property CodPedidoVenda() As String
        Get
            Return Request.QueryString.Item("pid")
        End Get
    End Property

End Class