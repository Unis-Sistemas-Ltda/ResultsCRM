Public Class WFTEFFollowUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAdesaoTEFFollowUp1.Empresa = Session("GlEmpresa")
        WUCAdesaoTEFFollowUp1.CodEmitente = Session("SCodLoja")
        WUCAdesaoTEFFollowUp1.SeqFollowUp = Session("SSeqFolowUp")
        WUCAdesaoTEFFollowUp1.Acao = Session("SAcaoFollowUp")
    End Sub

End Class