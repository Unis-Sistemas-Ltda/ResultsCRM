Public Class WFAvaliacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAvaliacao1.Acao = Session("SAcaoAvaliacao")
        WUCAvaliacao1.CodAvaliacao = Session("SCodAvaliacao")
    End Sub

End Class