Public Class WGItemAvaliado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim objItemAvaliado As New UCLItemAvaliado
                objItemAvaliado.Excluir(Session("GlEmpresa"), Session("SCodTipoAvaliacao"), e.CommandArgument)
                GridView1.DataBind()
            ElseIf e.CommandName = "ALTERAR" Then
                Session("SItemAvaliadoAcao") = e.CommandName
                Session("SSeqItemAvaliado") = e.CommandArgument
                Response.Redirect("WFItemAvaliado.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Session("SItemAvaliadoAcao") = "INCLUIR"
        Response.Redirect("WFItemAvaliado.aspx")
    End Sub

End Class