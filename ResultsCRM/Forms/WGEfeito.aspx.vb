Public Class WGEfeito
    Inherits System.Web.UI.Page

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodEfeito") = e.CommandArgument
            Response.Redirect("WFEfeito.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objEfeito As New UCLEfeito
            objEfeito.Excluir(Session("GlEmpresa"), e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodEfeito") = -1
        Response.Redirect("WFEfeito.aspx")
    End Sub

End Class