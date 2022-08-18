Partial Public Class WGOSMaterial
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
                Dim objSolicitacao As New UCLSolicitacaoTecnico(StrConexaoUsuario(Session("GlUsuario")))
                objSolicitacao.empresa = Session("GlEmpresa")
                objSolicitacao.estabelecimento = Session("GlEstabelecimento")
                objSolicitacao.cod_solicitacao = e.CommandArgument
                objSolicitacao.Excluir(objSolicitacao.empresa, objSolicitacao.estabelecimento, objSolicitacao.cod_solicitacao)
                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()
                Mensagem("Solicitação excluída com sucesso!")
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
            WUCSolicitacaoMaterial1.Visible = False
        End If
    End Sub

    Protected Sub MantemCabecalhoCarregado()
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            WUCSolicitacaoMaterial1.Empresa = Session("GlEmpresa")
            WUCSolicitacaoMaterial1.Estabelecimento = Session("GlEstabelecimento")
            WUCSolicitacaoMaterial1.CodPedidoVenda = Session("SAtCodPedido")
            WUCSolicitacaoMaterial1.CodSolicitacao = Session("SAtSolicitacao")
            WUCSolicitacaoMaterial1.Acao = Session("SAcaoAtPedido")
            WUCSolicitacaoMaterial1.CaminhoVoltar = "WGOSMaterial.aspx"
            objPedido.empresa = WUCSolicitacaoMaterial1.Empresa
            objPedido.estabelecimento = WUCSolicitacaoMaterial1.Estabelecimento
            objPedido.codPedidoVenda = WUCSolicitacaoMaterial1.CodPedidoVenda
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CarregaCabecalho()
        Try
            Call MantemCabecalhoCarregado()
            Call WUCSolicitacaoMaterial1.Carregar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

End Class