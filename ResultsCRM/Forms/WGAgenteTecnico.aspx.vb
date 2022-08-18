Partial Public Class WGAgenteTecnico
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodAgenteTecnico") = e.CommandArgument
            Response.Redirect("WFAgenteTecnico.aspx")
        End If
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodAgenteTecnico") = -1
        Response.Redirect("WFAgenteTecnico.aspx")
    End Sub
End Class