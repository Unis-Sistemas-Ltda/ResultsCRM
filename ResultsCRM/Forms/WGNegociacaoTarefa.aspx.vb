Public Partial Class WGNegociacaoTarefa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SSeqTarefaNegociacao") = e.CommandArgument
            Session("SAcaoItem") = "ALTERAR"
            Response.Redirect("WFNegociacaoTarefa.aspx")
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        If Session("SCodNegociacao") <> -1 Then
            Session("SSeqTarefaNegociacao") = -1
            Session("SAcaoItem") = "INCLUIR"
            Response.Redirect("WFNegociacaoTarefa.aspx")
        Else
            LblErro.Text = "Não é permitido incluir um registro de item antes de salvar o cabeçalho da negociação."
        End If

    End Sub

    Protected Sub DdlSituacao_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlSituacao.SelectedIndexChanged
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub
End Class