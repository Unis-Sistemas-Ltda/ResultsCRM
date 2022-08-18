Public Class WGAssessoriaEtapa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Try
            Dim codAssessoria As String = Session("SCodAssessoria").ToString()
            If String.IsNullOrEmpty(codAssessoria) OrElse codAssessoria <= 0 Then
                LblErro.Text = "É necessário salvar o cadastro da assessoria antes de inserir uma etapa."
                Return
            End If
            Session("SAcaoAssessoriaEtapa") = "INCLUIR"
            Session("SCodAssessoriaEtapa") = -1
            Response.Redirect("WFAssessoriaEtapa.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim objAssessoriaEtapa As New UCLAssessoriaEtapa
            objAssessoriaEtapa.Excluir(Session("SCodAssessoria"), e.CommandArgument)
            GridView1.DataBind()
        ElseIf e.CommandName = "ALTERAR" Then
            Session("SAcaoAssessoriaEtapa") = e.CommandName
            Session("SCodAssessoriaEtapa") = e.CommandArgument
            Response.Redirect("WFAssessoriaEtapa.aspx")
        End If
    End Sub

End Class