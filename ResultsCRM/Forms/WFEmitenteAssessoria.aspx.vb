Public Class WFEmitenteAssessoria
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCEmitenteAssessoria1.Acao = Session("SAcaoEmitenteAssessoria")
        WUCEmitenteAssessoria1.CodEmitente = Session("SCodEmitente")
        WUCEmitenteAssessoria1.CodAssessoria = Session("SCodAssessoria")
        WUCEmitenteAssessoria1.CodFornecedor = Session("SCodFornecedorAssessoria")
    End Sub

End Class