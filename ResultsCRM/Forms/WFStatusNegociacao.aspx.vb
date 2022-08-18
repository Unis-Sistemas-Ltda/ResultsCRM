Public Partial Class WFStatusNegociacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCStatusNegociacao1.Acao = Session("SAcao")
        WUCStatusNegociacao1.CodStatus = Session("SCodStatusNegociacao")
    End Sub

End Class