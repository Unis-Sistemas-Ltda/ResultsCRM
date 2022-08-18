Partial Public Class WFRotina
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCRotina1.Acao = Session("SAcao")
        WUCRotina1.Codigo = Session("SCodRotina")
    End Sub

End Class