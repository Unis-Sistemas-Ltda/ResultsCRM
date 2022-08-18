Public Class WFNegociacaoItem_Dist
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoItem_Dist1.CodNegociacao = Session("SCodNegociacao")
        WUCNegociacaoItem_Dist1.SeqItem = Session("SSeqItemNegociacao")
        WUCNegociacaoItem_Dist1.Acao = Session("SAcaoItem")
    End Sub

End Class