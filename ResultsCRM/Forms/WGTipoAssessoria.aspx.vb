Public Class WGTipoAssessoria
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoTipoAssessoria") = e.CommandName
            Session("SCodTipoAssessoria") = e.CommandArgument
            Response.Redirect("WFTipoAssessoria.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objTipoAssessoria As New UCLTipoAssessoria
            objTipoAssessoria.Excluir(e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcaoTipoAssessoria") = "INCLUIR"
        Session("SCodTipoAssessoria") = -1
        Response.Redirect("WFTipoAssessoria.aspx")
    End Sub

End Class