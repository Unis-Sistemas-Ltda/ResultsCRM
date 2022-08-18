Public Partial Class WGNegociacaoMotivoFechamento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim objNegociacaoMotivo As New UCLNegociacaoMotivoFechamento(StrConexaoUsuario(Session("GlUsuario")))
        If e.CommandName = "EXCLUIR" Then
            objNegociacaoMotivo.Empresa = Session("GlEmpresa")
            objNegociacaoMotivo.Estabelecimento = Session("GlEstabelecimento")
            objNegociacaoMotivo.CodNegociacao = Session("SCodNegociacao")
            objNegociacaoMotivo.CodMotivo = e.CommandArgument
            objNegociacaoMotivo.Excluir()

            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        If Session("SCodNegociacao") <> -1 Then
            Session("SNegCodMotivo") = -1
            Session("SAcaoMotivo") = "INCLUIR"
            Response.Redirect("WFNegociacaoMotivoFechamento.aspx")
        Else
            LblErro.Text = "Não é permitido incluir um motivo de fechamento de salvar o cabeçalho da negociação."
        End If

    End Sub

End Class