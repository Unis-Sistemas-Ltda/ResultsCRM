Partial Public Class WFEtapaTarefas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCEtapaTarefas1.Acao = Session("SAcao")
        WUCEtapaTarefas1.CodEtapa = Session("SCodEtapa")
    End Sub
End Class