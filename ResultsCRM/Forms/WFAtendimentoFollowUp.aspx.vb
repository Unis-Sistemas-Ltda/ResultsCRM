Partial Public Class WFAtendimentoFollowUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAtendimentoFollowUp1.Empresa = Session("GlEmpresa")
        WUCAtendimentoFollowUp1.CodAtendimento = Session("SCodAtendimento")
        WUCAtendimentoFollowUp1.SeqFollowUp = Session("SSeqFolowUp")
        WUCAtendimentoFollowUp1.Acao = Session("SAcaoFollowUp")
    End Sub

End Class