Public Class WGPosVendaChamados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodAtendimento") = e.CommandArgument
            Session("SModoAbertura") = 1
            Session("SCamVoltar") = "WGPosVendaChamados.aspx"
            Response.Redirect("WFPosVendaAtendimento.aspx")
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodAtendimento") = -1
        Session("SModoAbertura") = 1
        Session("SCamVoltar") = "WGPosVendaChamados.aspx"
        Response.Redirect("WFPosVendaAtendimento.aspx")
    End Sub
End Class