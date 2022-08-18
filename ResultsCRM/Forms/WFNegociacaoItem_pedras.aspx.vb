Public Class WFNegociacaoItem_pedras
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoItem1.CodNegociacao = Session("SCodNegociacao")
        WUCNegociacaoItem1.SeqItem = Session("SSeqItemNegociacao")
        WUCNegociacaoItem1.Acao = Session("SAcaoItem")
    End Sub

End Class