Partial Public Class WGCausa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodCausa") = e.CommandArgument
            Response.Redirect("WFCausaDetalhes.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objCausa As New UCLCausa
            objCausa.Empresa = Session("GlEmpresa")
            objCausa.Codigo = e.CommandArgument
            objCausa.Excluir()
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodCausa") = -1
        Response.Redirect("WFCausaDetalhes.aspx")
    End Sub
End Class