Partial Public Class WFAgenteTecnico
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAgenteTecnico1.Acao = Session("SAcao")
        WUCAgenteTecnico1.CodAgente = Session("SCodAgenteTecnico")
    End Sub

End Class