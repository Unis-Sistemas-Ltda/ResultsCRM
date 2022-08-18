Partial Public Class WGPosVendaFollowUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SSeqFolowUp") = e.CommandArgument
            Session("SAcaoFollowUp") = "ALTERAR"
            Response.Redirect("WFPosVendaFollowUp.aspx")
        End If
    End Sub

    Protected Sub LblIncluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LblIncluir.Click
        Session("SSeqFollowUp") = -1
        Session("SAcaoFollowUp") = "INCLUIR"
        Response.Redirect("WFPosVendaFollowUp.aspx")
    End Sub
End Class