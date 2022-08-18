Partial Public Class WGVersaoSistema
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaBancoDados()
                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SVersao") = e.CommandArgument.ToString.Substring(0, e.CommandArgument.ToString.IndexOf(";"))
            Session("SBancoDados") = e.CommandArgument.ToString.Substring(e.CommandArgument.ToString.IndexOf(";") + 1)
            Response.Redirect("WFVersaoSistema.aspx")
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SVersao") = -1
        Session("SBancoDados") = 1
        Response.Redirect("WFVersaoSistema.aspx")
    End Sub

    Public Sub CarregaBancoDados()
        Try
            Dim ObjBancoDados As New UCLBancoDados
            ObjBancoDados.FillDropDown(DdlBancoDados, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlBancoDados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlBancoDados.SelectedIndexChanged
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub
End Class