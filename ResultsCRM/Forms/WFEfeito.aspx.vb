Public Class WFEfeito
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCEfeito1.Acao = Session("SAcao")
        WUCEfeito1.CodEfeito = Session("SCodEfeito")
    End Sub

End Class