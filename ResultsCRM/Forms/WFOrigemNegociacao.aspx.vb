Public Partial Class WFOrigemNegociacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCOrigemNegociacao1.Acao = Session("SAcao")
        WUCOrigemNegociacao1.Codigo = Session("SCodFonte")
    End Sub

End Class