Public Partial Class WFNegociacaoFollowUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoFollowUp1.Empresa = Session("GlEmpresa")
        WUCNegociacaoFollowUp1.Estabelecimento = Session("SEstabelecimentoNegociacao")
        WUCNegociacaoFollowUp1.CodNegociacao = Session("SCodNegociacao")
        WUCNegociacaoFollowUp1.SeqFollowUp = Session("SSeqFolowUp")
        WUCNegociacaoFollowUp1.Acao = Session("SAcaoFollowUp")
    End Sub

End Class