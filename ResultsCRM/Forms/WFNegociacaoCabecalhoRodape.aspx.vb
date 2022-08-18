Public Partial Class WFNegociacaoCabecalhoRodape
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoCabecalhoRodape1.CodNegociacao = Session("SCodNegociacao")
    End Sub

End Class