Partial Public Class WGMotivoFechamento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodMotivoFechamento") = e.CommandArgument
            Response.Redirect("WFMotivoFechamento.aspx")
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodMotivoFechamento") = -1
        Response.Redirect("WFMotivoFechamento.aspx")
    End Sub
End Class