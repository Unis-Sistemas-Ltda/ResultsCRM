Public Class WGPosVendaPJVinculados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SCamVoltar") = "WGPosVendaPJVinculados.aspx"
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SCodContato") = e.CommandArgument
            Response.Redirect("WFContato.aspx?a=A&vcodc=SCodContato&vcode=SCodEmitente")
        End If
    End Sub


End Class