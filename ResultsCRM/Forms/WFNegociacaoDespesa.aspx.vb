Public Class WFNegociacaoDespesa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoDespesa1.Acao = Session("SAcaoDespesa")
        WUCNegociacaoDespesa1.CodTipoDespAcess = Session("SNegCodTipoDespAcess")
        WUCNegociacaoDespesa1.CodNegociacao = Session("SCodNegociacao")
    End Sub

End Class