Public Partial Class _Default1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SUsuarioConexao") = "dehonet"
        Session("SSenhaConexao") = "1234"
        Response.Redirect("~/Forms/WFFaleConosco.aspx")
    End Sub

End Class