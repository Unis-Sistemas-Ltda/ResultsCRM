Partial Public Class WGGestorConta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodGestorConta") = e.CommandArgument
            Response.Redirect("WFGestorConta.aspx")
        ElseIf e.CommandName = "REPRESENTANTE" Then
            Session("SCodGestorConta") = e.CommandArgument
            Response.Redirect("WFGestorContaRepresentante.aspx")
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodGestorConta") = -1
        Response.Redirect("WFGestorConta.aspx")
    End Sub
End Class