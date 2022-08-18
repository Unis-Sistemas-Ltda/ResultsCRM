Public Partial Class WFNegociacaoCabecalho
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacao1.CodNegociacao = Session("SCodNegociacao")
        WUCNegociacao1.Acao = Session("SAcaoNegociacao")
    End Sub

End Class