Partial Public Class WFManual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCManual1.Acao = Session("SAcao")
        WUCManual1.Codigo = Session("SCodManual")
    End Sub

End Class