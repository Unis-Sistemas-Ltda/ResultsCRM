Public Class WFNegociacaoItemFormula
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoItemFormulaInclusao1.CodNegociacao = Session("SCodNegociacao")
        WUCNegociacaoItemFormulaInclusao1.SeqItem = Session("SSeqItemNegociacao")
        WUCNegociacaoItemFormulaInclusao1.SeqFormula = Session("SSeqFormula")
        WUCNegociacaoItemFormulaInclusao1.Acao = Session("SAcaoItem")
    End Sub

End Class