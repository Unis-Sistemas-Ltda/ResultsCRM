Public Partial Class WFNegociacaoMotivoFechamento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoMotivoFechamento1.Acao = Session("SAcaoMotivo")
        WUCNegociacaoMotivoFechamento1.CodMotivo = Session("SNegCodMotivo")
        WUCNegociacaoMotivoFechamento1.CodNegociacao = Session("SCodNegociacao")
    End Sub

End Class