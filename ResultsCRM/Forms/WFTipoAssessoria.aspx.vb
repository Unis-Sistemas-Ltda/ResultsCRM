Public Class WFTipoAssessoria
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCTipoAssessoria1.Acao = Session("SAcaoTipoAssessoria")
        WUCTipoAssessoria1.CodTipoAssessoria = Session("SCodTipoAssessoria")
    End Sub

End Class