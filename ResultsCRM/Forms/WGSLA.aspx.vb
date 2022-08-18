Partial Public Class WGSLA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnIncluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluir.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodSLA") = -1
        Response.Redirect("WFSLA.aspx")
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodSLA") = e.CommandArgument
            Response.Redirect("WFSLA.aspx")
        End If
    End Sub
End Class