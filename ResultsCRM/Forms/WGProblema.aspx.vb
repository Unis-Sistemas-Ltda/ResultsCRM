Public Class WGProblema
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodProblema") = e.CommandArgument
            Response.Redirect("WFProblemaDetalhes.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objProblema As New UCLProblemaPadrao
            objProblema.Excluir(Session("GlEmpresa"), e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodProblema") = -1
        Response.Redirect("WFProblemaDetalhes.aspx")
    End Sub

End Class