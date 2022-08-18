Public Class WFFalta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCFalta1.Acao = Session("SAcaoFalta")
        WUCFalta1.CodFalta = Session("SCodFalta")
    End Sub

End Class