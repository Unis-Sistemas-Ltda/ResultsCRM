Public Class WFRoteiroAtendimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCRoteiroAtendimento1.Acao = Session("SAcao")
        WUCRoteiroAtendimento1.CodRoteiro = Session("SCodRoteiroAtendimento")
    End Sub

End Class