Public Class WGRoteiroVisitaChamados
    Inherits System.Web.UI.Page

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodAtendimento") = e.CommandArgument
            Session("SModoAbertura") = 1
            Session("SCamVoltar") = "WGRoteiroVisitaChamados.aspx"
            Response.Redirect("WFPosVendaAtendimento.aspx")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodAtendimento") = -1
        Session("SModoAbertura") = 1
        Session("SCamVoltar") = "WGRoteiroVisitaChamados.aspx"
        Response.Redirect("WFPosVendaAtendimento.aspx")
    End Sub
End Class