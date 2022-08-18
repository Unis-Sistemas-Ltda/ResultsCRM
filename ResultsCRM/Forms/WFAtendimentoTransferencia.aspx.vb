Partial Public Class WFAtendimentoTransferencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAtendimentoTransferencia1.CodAtendimento = Session("SCodAtendimento")
        WUCAtendimentoTransferencia1.Acao = Session("SAcao")
    End Sub

End Class