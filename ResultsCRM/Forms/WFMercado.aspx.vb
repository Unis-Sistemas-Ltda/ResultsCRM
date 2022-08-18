Public Class WFMercado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCMercado1.Acao = Session("SAcao")
        WUCMercado1.CodMercado = Session("SCodMercado")
    End Sub

End Class