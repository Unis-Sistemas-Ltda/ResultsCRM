Partial Public Class WFTarefaPadrao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCTarefaPadrao1.Acao = Session("SAcao")
        WUCTarefaPadrao1.CodTarefa = Session("SCodTarefaPadrao")
    End Sub

End Class