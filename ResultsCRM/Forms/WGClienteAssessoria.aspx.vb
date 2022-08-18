Public Class WGClienteAssessoria
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Try
            Dim SCodEmitente As String = Session("SCodEmitente").ToString()
            If String.IsNullOrEmpty(SCodEmitente) OrElse SCodEmitente <= 0 Then
                LblErro.Text = "É necessário salvar o cadastro do cliente antes de inserir uma assessoria no cadastro."
                Return
            End If
            Session("SAcaoEmitenteAssessoria") = "INCLUIR"
            Session("SCodAssessoria") = ""
            Session("SCodFornecedorAssessoria") = ""
            Response.Redirect("WFEmitenteAssessoriaDetalhes.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim params As String() = {"", "", "", ""}
        If e.CommandName = "ALTERAR" OrElse e.CommandName = "EXCLUIR" Then
            params = e.CommandArgument.ToString().Split(";")
        End If
        If e.CommandName = "EXCLUIR" Then
            Dim objEmitenteAssessoria As New UCLEmitenteAssessoria
            objEmitenteAssessoria.Excluir(params(0), params(1), params(2), params(3))
            GridView1.DataBind()
        ElseIf e.CommandName = "ALTERAR" Then
            Session("SAcaoEmitenteAssessoria") = e.CommandName
            Session("SCodAssessoria") = params(2)
            Session("SCodFornecedorAssessoria") = params(3)
            Response.Redirect("WFEmitenteAssessoriaDetalhes.aspx")
        End If
    End Sub

End Class