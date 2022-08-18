Partial Public Class WFPosVendaFollowUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCPosVendaFollowUp1.CodEmitente = Session("SCodEmitente")
        WUCPosVendaFollowUp1.SeqFollowUp = Session("SSeqFolowUp")
        WUCPosVendaFollowUp1.Acao = Session("SAcaoFollowUp")
    End Sub

End Class