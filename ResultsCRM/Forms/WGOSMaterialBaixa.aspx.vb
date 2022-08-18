Partial Public Class WGOSMaterialBaixa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call SetaParaInclusao()
            Call CarregaCabecalho()
        Else
            Call MantemCabecalhoCarregado()
        End If
    End Sub

    Private Sub Mensagem(ByVal texto As String)
        LblErro.Text = ""
        If Not String.IsNullOrEmpty(texto) Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('" + texto + "');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "", True)
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAtSolicitacao") = e.CommandArgument
            Session("SAcaoAtPedido") = "ALTERAR"
            Call CarregaCabecalho()
        ElseIf e.CommandName = "EXCLUIR" Then
            Try
                Dim objTransfTecnicoBaixa As New UCLTransferenciaTecnicoBaixa(StrConexaoUsuario(Session("GlUsuario")))
                Dim objTransfTecnicoInstalacaoRetorno As New UCLTransferenciaTecnicoInstalacaoRetorno(StrConexaoUsuario(Session("GlUsuario")))
                Dim objTransTecnicoPendencia As New UCLTransferenciaTecnicoPendenciaSolicitacao(StrConexaoUsuario(Session("GlUsuario")))
                Dim codTransferencia, seqTransferencia, seqBaixa As String

                codTransferencia = ""
                seqTransferencia = ""
                seqBaixa = ""
                ParametrosChave(e.CommandArgument, codTransferencia, seqTransferencia, seqBaixa)

                objTransTecnicoPendencia.empresa = Session("GlEmpresa")
                objTransTecnicoPendencia.estabelecimento = Session("GlEstabelecimento")
                objTransTecnicoPendencia.cod_transferencia = codTransferencia
                objTransTecnicoPendencia.seq_transferencia = seqTransferencia
                objTransTecnicoPendencia.seq_baixa = seqBaixa
                objTransTecnicoPendencia.ExcluirPorBaixaOriginal()

                objTransfTecnicoInstalacaoRetorno.empresa = Session("GlEmpresa")
                objTransfTecnicoInstalacaoRetorno.estabelecimento = Session("GlEstabelecimento")
                objTransfTecnicoInstalacaoRetorno.cod_transferencia = codTransferencia
                objTransfTecnicoInstalacaoRetorno.seq_transferencia = seqTransferencia
                objTransfTecnicoInstalacaoRetorno.seq_baixa_origem = seqBaixa
                objTransfTecnicoInstalacaoRetorno.ExcluirPorBaixaOriginal()

                objTransfTecnicoBaixa.empresa = Session("GlEmpresa")
                objTransfTecnicoBaixa.estabelecimento = Session("GlEstabelecimento")
                objTransfTecnicoBaixa.cod_transferencia = codTransferencia
                objTransfTecnicoBaixa.seq_transferencia = seqTransferencia
                objTransfTecnicoBaixa.seq_baixa = seqBaixa
                objTransfTecnicoBaixa.Excluir()

                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()

                Call SetaParaInclusao()
                Call CarregaCabecalho()

                Mensagem("Baixa de Material foi estornada com sucesso!")
            Catch ex As Exception
                LblErro.Text = ex.Message.ToString
            End Try
        End If
    End Sub

    Protected Sub SetaParaInclusao()
        If Session("SAtCodPedido") <> -1 Then
            Session("SAtSolicitacao") = -1
            Session("SAcaoAtPedido") = "INCLUIR"
        Else
            Mensagem("Antes de adicionar um item, você deve salvar o cabeçalho da OS.")
            WUCBaixaMaterial1.Visible = False
        End If
    End Sub

    Protected Sub MantemCabecalhoCarregado()
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            WUCBaixaMaterial1.Empresa = Session("GlEmpresa")
            WUCBaixaMaterial1.Estabelecimento = Session("GlEstabelecimento")
            WUCBaixaMaterial1.CodPedidoVenda = Session("SAtCodPedido")
            WUCBaixaMaterial1.CodSolicitacao = Session("SAtSolicitacao")
            WUCBaixaMaterial1.CaminhoVoltar = "WGOSMaterialBaixa.aspx"
            objPedido.empresa = WUCBaixaMaterial1.Empresa
            objPedido.estabelecimento = WUCBaixaMaterial1.Estabelecimento
            objPedido.codPedidoVenda = WUCBaixaMaterial1.CodPedidoVenda
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CarregaCabecalho()
        Try
            Call MantemCabecalhoCarregado()
            Call WUCBaixaMaterial1.Carregar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub ParametrosChave(ByVal chave As String, ByRef codTransferencia As String, ByRef seqTransferencia As String, ByRef seqBaixa As String)
        Try
            If chave.Contains(";") Then
                codTransferencia = chave.Substring(0, chave.IndexOf(";"))
                chave = chave.Substring(chave.IndexOf(";") + 1)
                seqTransferencia = chave.Substring(0, chave.IndexOf(";"))
                chave = chave.Substring(chave.IndexOf(";") + 1)
                seqBaixa = chave
            Else
                codTransferencia = 0
                seqTransferencia = 0
                seqBaixa = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class