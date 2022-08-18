Partial Public Class WFPFollowUp
    Inherits System.Web.UI.Page
    Dim Controle As String
    Dim Comando As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "SELECIONAR" Then
            Session("SDescricaoFollowUpSelecionado") = e.CommandArgument
            ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
        End If
    End Sub

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFiltrar.Click
        Call CarregaGrid()
    End Sub

    Protected Sub btnOkay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOkay.Click
        Try
            ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onError();", True)
        End Try
    End Sub

    Private Sub CarregaGrid()
        Try
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class