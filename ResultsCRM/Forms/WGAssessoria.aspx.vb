Public Class WGAssessoria
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoAssessoria") = e.CommandName
            Session("SCodAssessoria") = e.CommandArgument
            Response.Redirect("WFAssessoriaDetalhes.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objAssessoria As New UCLAssessoria
            objAssessoria.Excluir(e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcaoAssessoria") = "INCLUIR"
        Session("SCodAssessoria") = -1
        Response.Redirect("WFAssessoriaDetalhes.aspx")
    End Sub
End Class