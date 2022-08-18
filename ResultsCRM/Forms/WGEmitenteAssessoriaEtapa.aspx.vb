Public Class WGEmitenteAssessoriaEtapa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Try
            Session("SAcaoEmitenteAssessoriaEtapa") = "INCLUIR"
            Session("SCodEtapaAssessoria") = "-1"
            Response.Redirect("WFEmitenteAssessoriaEtapa.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoEmitenteAssessoriaEtapa") = e.CommandName
            Session("SCodEtapaAssessoria") = e.CommandArgument
            Response.Redirect("WFEmitenteAssessoriaEtapa.aspx")
        End If
    End Sub

End Class