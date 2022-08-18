Partial Public Class WFAtendimentoCabecalho_AssistenciaTecnica2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAtendimentoCabecalho_AssistenciaTecnica21.CodAtendimento = Session("SCodAtendimento")
        WUCAtendimentoCabecalho_AssistenciaTecnica21.Acao = Session("SAcao")
        WUCAtendimentoCabecalho_AssistenciaTecnica21.ModoAbertura = Session("SModoAbertura")
    End Sub

End Class