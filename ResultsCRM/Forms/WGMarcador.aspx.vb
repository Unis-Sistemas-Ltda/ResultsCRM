Public Class WGMarcador
    Inherits System.Web.UI.Page

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodMarcador") = e.CommandArgument
            Response.Redirect("WFMarcador.aspx?embeeded=False")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objMarcador As New UCLMarcador
            objMarcador.Excluir(Session("GlEmpresa"), e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodMarcador") = -1
        Response.Redirect("WFMarcador.aspx?embeeded=False")
    End Sub

End Class