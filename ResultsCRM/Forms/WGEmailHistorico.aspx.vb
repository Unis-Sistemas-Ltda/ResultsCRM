Public Class WGEmailHistorico
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub SqlDataSource1_Init(sender As Object, e As System.EventArgs) Handles SqlDataSource1.Init
        SqlDataSource1.ConnectionString = StrConexaoEmail
    End Sub

End Class