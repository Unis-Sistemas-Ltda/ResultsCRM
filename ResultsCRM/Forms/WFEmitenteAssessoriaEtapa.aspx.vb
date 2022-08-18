Public Class WFEmitenteAssessoriaEtapa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCEmitenteAssessoriaEtapa1.Acao = Session("SAcaoEmitenteAssessoriaEtapa")
        WUCEmitenteAssessoriaEtapa1.CodEmitente = Session("SCodEmitente")
        WUCEmitenteAssessoriaEtapa1.CodAssessoria = Session("SCodAssessoria")
        WUCEmitenteAssessoriaEtapa1.CodFornecedor = Session("SCodFornecedorAssessoria")
        WUCEmitenteAssessoriaEtapa1.SeqEtapa = Session("SCodEtapaAssessoria")
    End Sub

End Class