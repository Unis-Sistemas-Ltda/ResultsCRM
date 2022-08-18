Public Partial Class WFAtendimentoCabecalho
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAtendimentoCabecalho1.CodAtendimento = Session("SCodAtendimento")
        WUCAtendimentoCabecalho1.Acao = Session("SAcao")
        WUCAtendimentoCabecalho1.ModoAbertura = Session("SModoAbertura")
    End Sub

End Class