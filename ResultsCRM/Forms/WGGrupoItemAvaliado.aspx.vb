Public Class WGGrupoItemAvaliado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoGrupoItem") = e.CommandName
            Session("SCodGrupoItem") = e.CommandArgument
            Response.Redirect("WFGrupoItemAvaliado.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objGrupo As New UCLGrupoItemAvaliado
            objGrupo.Excluir(Session("GlEmpresa"), e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcaoGrupoItem") = "INCLUIR"
        Session("SCodGrupoItem") = -1
        Response.Redirect("WFGrupoItemAvaliado.aspx")
    End Sub

End Class