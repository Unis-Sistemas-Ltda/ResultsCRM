Public Class WGPosVendaContatos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SCamVoltar") = "WGPosVendaContatos.aspx"
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SCodContato") = e.CommandArgument
            Response.Redirect("WFContato.aspx?a=A&vcodc=SCodContato&vcode=SCodEmitente")
        End If
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Session("SCodContato") = -1
        Response.Redirect("WFContato.aspx?a=I&vcodc=SCodContato&vcode=SCodEmitente")
    End Sub
End Class