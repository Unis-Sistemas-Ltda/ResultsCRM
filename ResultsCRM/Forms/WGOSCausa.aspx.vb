Partial Public Class WGOSCausa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("GlTipoFaturamento").ToString = "G" Then
            GridView1.Columns.Item(1).HeaderText = "Produto / Solicitação"
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAtSeqItemPedidoCausa") = e.CommandArgument
            Session("SAcaoAtPedidoCausa") = "ALTERAR"
            Response.Redirect("WFOSCausa.aspx")
        End If
    End Sub

    

End Class