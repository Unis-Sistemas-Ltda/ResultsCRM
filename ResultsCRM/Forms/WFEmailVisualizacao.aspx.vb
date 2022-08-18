Public Class WFEmailVisualizacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCEmailVisualizacao1.Acao = "ALTERAR"
        WUCEmailVisualizacao1.SeqEmail = Request.QueryString.Item("e")
        WUCEmailVisualizacao1.Empresa = Session("GlEmpresa")
    End Sub

End Class