Public Class WFAdesaoTEF
    Inherits System.Web.UI.Page

    Private ReadOnly Property Prop_CodEmitente As String
        Get
            Return Request.QueryString.Item("e")
        End Get
    End Property

    Private ReadOnly Property Prop_CNPJ As String
        Get
            Return Request.QueryString.Item("c")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaFormulario()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    
    Private Sub CarregaFormulario()
        Try
            Dim objAdesaoTEFEmitente As New UCLAdesaoTEFEmitente
            Dim objAdesaoTEFLoja As New UCLAdesaoTEFLoja
            Dim objEmitente As New UCLEmitente(StrConexao)
            Dim objPedido As New UCLPedidoVenda(StrConexao)
            Dim objChamado As New UCLAtendimento(StrConexao)
            Dim objStatusChamado As New UCLStatusChamado

            objAdesaoTEFLoja.Buscar(Session("GlEmpresa"), Prop_CodEmitente, Prop_CNPJ)
            objAdesaoTEFEmitente.Buscar(Session("GlEmpresa"), Prop_CodEmitente)

            LblCodEmitente.Text = Prop_CodEmitente
            LblCNPJ.Text = Prop_CNPJ.MascaraCNPJ
            LblNomeEmitente.Text = objEmitente.GetRazaoSocial(LblCodEmitente.Text)

            TxtCodNegociacaoCliente.Text = objAdesaoTEFLoja.GetConteudo("cod_negociacao_cliente")
            LblCodPedidoVenda.Text = objAdesaoTEFLoja.GetCodPedidoVenda(Session("GlEmpresa"), Prop_CodEmitente, Prop_CNPJ)

            objPedido.empresa = Session("GlEmpresa")
            objPedido.estabelecimento = Session("GlEstabelecimento")
            objPedido.codPedidoVenda = LblCodPedidoVenda.Text
            If Not String.IsNullOrEmpty(objPedido.empresa) AndAlso Not String.IsNullOrEmpty(objPedido.estabelecimento) AndAlso Not String.IsNullOrEmpty(objPedido.codPedidoVenda) Then
                If objPedido.Buscar() Then
                    LblDataEmissaoPedido.Text = objPedido.dDataEmissao.ToString("dd/MM/yyyy")
                    LblNF.Text = objPedido.GetNF(objPedido.empresa, objPedido.estabelecimento, objPedido.codPedidoVenda)
                End If
            End If

            TxtCodChamadoInstalacao.Text = objAdesaoTEFLoja.GetConteudo("cod_chamado_instalacao")
            objChamado.Empresa = Session("GlEmpresa")
            objChamado.CodChamado = TxtCodChamadoInstalacao.Text
            If Not String.IsNullOrEmpty(objChamado.Empresa) AndAlso Not String.IsNullOrEmpty(objChamado.CodChamado) AndAlso objChamado.Buscar() Then
                objStatusChamado.CodStatus = objChamado.CodStatus
                If Not String.IsNullOrEmpty(objStatusChamado.CodStatus) AndAlso objStatusChamado.Buscar() Then
                    LblStatusChamadoInstalacao.Text = objStatusChamado.Descricao
                End If
            End If

            If Not String.IsNullOrEmpty(objChamado.CodChamado) Then
                BtnGerarChamado.Visible = False
            End If

            CbxAdquirente.Checked = (objAdesaoTEFLoja.GetConteudo("cadastro_adquirente") = "S")
            CbxParceiro.Checked = (objAdesaoTEFLoja.GetConteudo("cadastro_parceiro") = "S")
            CbxEquipamentoEnviado.Checked = (objAdesaoTEFLoja.GetConteudo("equipamento_enviado") = "S")
            LblEtapa1.Text = objAdesaoTEFEmitente.GetConteudo("confirmou_contato").ToString.Replace("S", "Sim").Replace("N", "Não")
            LblEtapa2.Text = objAdesaoTEFEmitente.GetConteudo("confirmou_lojas").ToString.Replace("S", "Sim").Replace("N", "Não")
            If objAdesaoTEFEmitente.IsNull("data_aceite") Then
                LblDataAceite.Text = "Não aceito."
            Else
                LblDataAceite.Text = objAdesaoTEFEmitente.GetConteudoData("data_aceite").ToString("dd/MM/yyyy HH:mm:ss")
            End If
            If objAdesaoTEFEmitente.IsNull("data_validacao") Then
                LblDataValidacao.Text = "Não validado."
            Else
                LblDataValidacao.Text = objAdesaoTEFEmitente.GetConteudoData("data_validacao").ToString("dd/MM/yyyy HH:mm:ss")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles BtnVoltar.Click
        If Request.QueryString.Item("ori") = "P" Then
            Response.Redirect("WGAdesaoTEF.aspx?t=" + Now.ToString("ddMMyyyyHHmmss"))
        ElseIf Request.QueryString.Item("ori") = "N" Then
            Response.Redirect("WGNegociacaoAdesaoTEF.aspx?t=" + Now.ToString("ddMMyyyyHHmmss"))
        End If
    End Sub

    Protected Function Salvar() As Boolean
        Try
            Dim objAdesaoTEFLoja As New UCLAdesaoTEFLoja
            If objAdesaoTEFLoja.Buscar(Session("GlEmpresa"), Prop_CodEmitente, Prop_CNPJ) Then
                objAdesaoTEFLoja.SetConteudo("cod_negociacao_cliente", TxtCodNegociacaoCliente.Text)
                objAdesaoTEFLoja.SetConteudo("cod_chamado_instalacao", TxtCodChamadoInstalacao.Text)
                objAdesaoTEFLoja.SetConteudo("cadastro_adquirente", IIf(CbxAdquirente.Checked, "S", "N"))
                objAdesaoTEFLoja.SetConteudo("cadastro_parceiro", IIf(CbxParceiro.Checked, "S", "N"))
                objAdesaoTEFLoja.SetConteudo("equipamento_enviado", IIf(CbxEquipamentoEnviado.Checked, "S", "N"))
                objAdesaoTEFLoja.Alterar()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles BtnGravar.Click
        Try
            If IsDigitacaoOK() Then
                If Salvar() Then
                    If Request.QueryString.Item("ori") = "P" Then
                        Response.Redirect("WGAdesaoTEF.aspx?t=" + Now.ToString("ddMMyyyyHHmmss"))
                    ElseIf Request.QueryString.Item("ori") = "N" Then
                        Response.Redirect("WGNegociacaoAdesaoTEF.aspx?t=" + Now.ToString("ddMMyyyyHHmmss"))
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function IsDigitacaoOK() As Boolean
        Try
            LblErro.Text = ""

            If Not String.IsNullOrEmpty(TxtCodNegociacaoCliente.Text) AndAlso Not IsNumeric(TxtCodNegociacaoCliente.Text) Then
                LblErro.Text = "Informe corretamente o número da negociação.<br>"
            End If

            If Not String.IsNullOrEmpty(TxtCodChamadoInstalacao.Text) AndAlso Not IsNumeric(TxtCodChamadoInstalacao.Text) Then
                LblErro.Text = "Informe corretamente o número do chamado de instalação.<br>"
            End If

            Return (LblErro.Text = "")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub TxtCodNegociacaoCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCodNegociacaoCliente.TextChanged
        Try
            Dim objAdesaoTEFLoja As New UCLAdesaoTEFLoja
            Dim objPedido As New UCLPedidoVenda(StrConexao)

            LblCodPedidoVenda.Text = objAdesaoTEFLoja.GetCodPedidoVenda(Session("GlEmpresa"), Prop_CodEmitente, Prop_CNPJ)

            objPedido.empresa = Session("GlEmpresa")
            objPedido.estabelecimento = Session("GlEstabelecimento")
            objPedido.codPedidoVenda = LblCodPedidoVenda.Text
            If Not String.IsNullOrEmpty(objPedido.empresa) AndAlso Not String.IsNullOrEmpty(objPedido.estabelecimento) AndAlso Not String.IsNullOrEmpty(objPedido.codPedidoVenda) Then
                If objPedido.Buscar() Then
                    LblDataEmissaoPedido.Text = objPedido.dDataEmissao.ToString("dd/MM/yyyy")
                    LblNF.Text = objPedido.GetNF(objPedido.empresa, objPedido.estabelecimento, objPedido.codPedidoVenda)
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub TxtCodChamadoInstalacao_TextChanged(sender As Object, e As EventArgs) Handles TxtCodChamadoInstalacao.TextChanged
        Try
            Call CarregaDadosChamadoInstalacao()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CarregaDadosChamadoInstalacao()
        Try
            Dim objChamado As New UCLAtendimento(StrConexao)
            Dim objStatusChamado As New UCLStatusChamado

            objChamado.Empresa = Session("GlEmpresa")
            objChamado.CodChamado = TxtCodChamadoInstalacao.Text
            If Not String.IsNullOrEmpty(objChamado.Empresa) AndAlso Not String.IsNullOrEmpty(objChamado.CodChamado) AndAlso objChamado.Buscar() Then
                objStatusChamado.CodStatus = objChamado.CodStatus
                If Not String.IsNullOrEmpty(objStatusChamado.CodStatus) AndAlso objStatusChamado.Buscar() Then
                    LblStatusChamadoInstalacao.Text = objStatusChamado.Descricao
                End If
            End If

            If Not String.IsNullOrEmpty(objChamado.CodChamado) Then
                BtnGerarChamado.Visible = False
            Else
                BtnGerarChamado.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGerarChamado_Click(sender As Object, e As EventArgs) Handles BtnGerarChamado.Click
        Try
            Dim objAtendimento As New UCLAtendimento(StrConexao)
            Dim objContato As New UCLContato
            Dim codChamado As String
            objAtendimento.CodEmitente = LblCodEmitente.Text

            objContato.CodEmitente = LblCodEmitente.Text
            objAtendimento.CodContato = objContato.GetCodContatoPreferencial()
            objAtendimento.CodAnalista = Session("GlCodUsuario")
            objAtendimento.TipoChamado = "11"
            objAtendimento.CodUsuario = Session("GlCodUsuario")
            objAtendimento.CodStatus = 22 'Aguardando equipamento
            objAtendimento.CodSistema = 11
            objAtendimento.DataChamado = Now.ToString("dd/MM/yyyy")
            objAtendimento.HoraChamado = Now.ToString("HH:mm")
            objAtendimento.Assunto = "INSTALAÇÃO TEF"
            objAtendimento.Observacao = ""
            objAtendimento.Cnpj = Prop_CNPJ
            objAtendimento.CodVeiculo = ""
            objAtendimento.Contrato = ""
            objAtendimento.OSCliente = ""
            codChamado = objAtendimento.GetProximoCodigo()

            objAtendimento.Incluir(Session("GlEmpresa"), Session("GlEstabelecimento"), codChamado)

            TxtCodChamadoInstalacao.Text = codChamado

            If IsDigitacaoOK() AndAlso Salvar() Then
                Call CarregaDadosChamadoInstalacao()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class