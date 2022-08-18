Partial Public Class WGManual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodManual") = e.CommandArgument
            Response.Redirect("WFManual.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim ObjManual As New UCLManual()
            ObjManual.Excluir(e.CommandArgument)
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodManual") = -1
        Response.Redirect("WFManual.aspx")
    End Sub
End Class