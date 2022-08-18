Partial Public Class WGBancoDados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodBancoDados") = e.CommandArgument
            Response.Redirect("WFBancoDados.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim ObjBanco As New UCLBancoDados
            ObjBanco.CodBancoDados = e.CommandArgument
            ObjBanco.Excluir()
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodBancoDados") = -1
        Response.Redirect("WFBancoDados.aspx")
    End Sub
End Class