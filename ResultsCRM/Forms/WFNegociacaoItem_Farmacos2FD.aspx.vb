Partial Public Class WFNegociacaoItem_Farmacos2FD
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoItem_Farmacos2FD1.CodNegociacao = Session("SCodNegociacao")
        WUCNegociacaoItem_Farmacos2FD1.SeqItem = Session("SSeqItemNegociacao")
        WUCNegociacaoItem_Farmacos2FD1.Acao = Session("SAcaoItem")

    End Sub

End Class