Partial Public Class WFNegociacaoItem_Grade
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoItem_Grade1.CodNegociacao = Session("SCodNegociacao")
        WUCNegociacaoItem_Grade1.SeqItem = Session("SSeqItemNegociacao")
        WUCNegociacaoItem_Grade1.Acao = Session("SAcaoItem")
    End Sub
End Class