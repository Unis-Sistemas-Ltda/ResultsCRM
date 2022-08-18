Partial Public Class WFTipoPontoAtendimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCTipoPontoAtendimento1.Acao = Session("SAcao")
        WUCTipoPontoAtendimento1.CodTipoPontoAtendimento = Session("SCodTipoPontoAtendimento")
    End Sub

End Class