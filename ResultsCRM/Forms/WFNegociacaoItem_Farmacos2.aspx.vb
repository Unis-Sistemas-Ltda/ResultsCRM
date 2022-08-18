Partial Public Class WFNegociacaoItem_Farmacos2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoItem_Farmacos21.CodNegociacao = Session("SCodNegociacao")
        WUCNegociacaoItem_Farmacos21.SeqItem = Session("SSeqItemNegociacao")
        WUCNegociacaoItem_Farmacos21.Acao = Session("SAcaoItem")
    End Sub

End Class