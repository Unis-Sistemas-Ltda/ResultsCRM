Public Class WGTipoAvaliacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoTipoAvaliacao") = e.CommandName
            Session("SCodTipoAvaliacao") = e.CommandArgument
            Response.Redirect("WFTipoAvaliacaoDetalhes.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objTipoAvaliacao As New UCLTipoAvaliacao
            objTipoAvaliacao.Excluir(Session("GlEmpresa"), e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcaoTipoAvaliacao") = "INCLUIR"
        Session("SCodTipoAvaliacao") = -1
        Response.Redirect("WFTipoAvaliacaoDetalhes.aspx")
    End Sub
End Class