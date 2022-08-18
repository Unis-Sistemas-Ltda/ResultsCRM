Public Class WFAssessoria
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAssessoria1.Acao = Session("SAcaoAssessoria")
        WUCAssessoria1.CodAssessoria = Session("SCodAssessoria")
    End Sub

End Class