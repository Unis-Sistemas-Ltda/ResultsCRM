Public Class WGGrupoResultado
    Inherits System.Web.UI.Page

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoGrupoResultado") = e.CommandName
            Session("SCodGrupoResultado") = e.CommandArgument
            Response.Redirect("WFGrupoResultadoDetalhes.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objGrupoResultado As New UCLGrupoResultadoItemAvaliado
            objGrupoResultado.Excluir(Session("GlEmpresa"), e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcaoGrupoResultado") = "INCLUIR"
        Session("SCodGrupoResultado") = -1
        Response.Redirect("WFGrupoResultadoDetalhes.aspx")
    End Sub

End Class