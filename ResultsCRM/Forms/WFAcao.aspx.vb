Public Class WFAcao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAcao1.Acao = Session("SAcao")
        WUCAcao1.CodAcao = Session("SCodAcao")
    End Sub

End Class