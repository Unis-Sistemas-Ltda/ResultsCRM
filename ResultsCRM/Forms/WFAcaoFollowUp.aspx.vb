Public Partial Class WFAcaoFollowUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAcaoFollowUp1.Acao = Session("SAcao")
        WUCAcaoFollowUp1.CodAcao = Session("SCodAcao")
    End Sub

End Class