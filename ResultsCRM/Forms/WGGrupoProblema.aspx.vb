Public Class WGGrupoProblema
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoGrupoProblema") = e.CommandName
            Session("SCodGrupoProblema") = e.CommandArgument
            Response.Redirect("WFGrupoProblema.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objGrupoProblema As New UCLGrupoProblema
            objGrupoProblema.Excluir(Session("GlEmpresa"), e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcaoGrupoProblema") = "INCLUIR"
        Session("SCodGrupoProblema") = -1
        Response.Redirect("WFGrupoProblema.aspx")
    End Sub

End Class