Partial Public Class WGFunilVenda
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodFunil") = e.CommandArgument
            Response.Redirect("WFFunilVenda.aspx")
        ElseIf e.CommandName = "ETAPAS" Then
            Session("SAcao") = e.CommandName
            Session("SCodFunil") = e.CommandArgument
            Response.Redirect("WFFunilVendaEtapas.aspx")
        End If
    End Sub

    Protected Sub BtnIncluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluir.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodFunil") = -1
        Response.Redirect("WFFunilVenda.aspx")
    End Sub

End Class