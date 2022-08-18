Public Partial Class WFEtapaNegociacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCEtapaNegociacao1.Acao = Session("SAcao")
        WUCEtapaNegociacao1.CodEtapa = Session("SCodEtapa")
    End Sub
End Class