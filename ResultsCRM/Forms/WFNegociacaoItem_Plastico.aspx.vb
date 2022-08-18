Partial Public Class WFNegociacaoItem_Plastico
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoItem_Plastico1.CodNegociacao = Session("SCodNegociacao")
        WUCNegociacaoItem_Plastico1.SeqItem = Session("SSeqItemNegociacao")
        WUCNegociacaoItem_Plastico1.Acao = Session("SAcaoItem")
    End Sub

End Class