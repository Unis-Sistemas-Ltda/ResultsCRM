Public Partial Class WFFormasPagamento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCFormasPagamento1.Acao = Session("SAcao")
        WUCFormasPagamento1.Codigo = Session("SCodFormasPagamento")
    End Sub

End Class