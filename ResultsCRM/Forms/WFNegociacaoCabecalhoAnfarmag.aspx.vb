Partial Public Class WFNegociacaoCabecalhoAnfarmag
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoAnfarmag1.CodNegociacao = Session("SCodNegociacao")
        WUCNegociacaoAnfarmag1.Acao = Session("SAcaoNegociacao")
    End Sub

End Class