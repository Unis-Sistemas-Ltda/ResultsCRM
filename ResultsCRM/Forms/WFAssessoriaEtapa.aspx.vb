Public Class WFAssessoriaEtapa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAssessoriaEtapa1.Acao = Session("SAcaoAssessoriaEtapa")
        WUCAssessoriaEtapa1.CodAssessoriaEtapa = Session("SCodAssessoriaEtapa")
        WUCAssessoriaEtapa1.CodAssessoria = Session("SCodAssessoria")
    End Sub

End Class