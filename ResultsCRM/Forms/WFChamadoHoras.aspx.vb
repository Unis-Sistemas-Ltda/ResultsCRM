Public Class WFChamadoHoras
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCChamadoHoras1.CodChamado = Session("SCodAtendimento")
        WUCChamadoHoras1.SeqHora = Session("SAtHora")
        WUCChamadoHoras1.Acao = Session("SAcaoHoraChamado")
    End Sub

End Class