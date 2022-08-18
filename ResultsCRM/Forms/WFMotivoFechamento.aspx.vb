Public Partial Class WFMotivoFechamento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCMotivoFechamento1.Acao = Session("SAcao")
        WUCMotivoFechamento1.CodMotivo = Session("SCodMotivoFechamento")
    End Sub

End Class