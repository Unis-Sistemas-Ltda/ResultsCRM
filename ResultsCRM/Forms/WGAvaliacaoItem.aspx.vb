Public Class WGAvaliacaoItem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "ALTERAR" Then
                Session("SAcaoItemAvaliado") = e.CommandName
                Session("SSeqItemAvaliado") = e.CommandArgument
                Response.Redirect("WFAvaliacaoItem.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class