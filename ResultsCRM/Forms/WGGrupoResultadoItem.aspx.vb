Public Class WGGrupoResultadoItem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim objResultadoItemAvaliado As New UCLResultadoItemAvaliado
                objResultadoItemAvaliado.Excluir(Session("GlEmpresa"), Session("SCodGrupoResultado"), e.CommandArgument)
                GridView1.DataBind()
            ElseIf e.CommandName = "ALTERAR" Then
                Session("SResultadoAcao") = e.CommandName
                Session("SSeqResultado") = e.CommandArgument
                Response.Redirect("WFGrupoResultadoItem.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Session("SResultadoAcao") = "INCLUIR"
        Response.Redirect("WFGrupoResultadoItem.aspx")
    End Sub

End Class