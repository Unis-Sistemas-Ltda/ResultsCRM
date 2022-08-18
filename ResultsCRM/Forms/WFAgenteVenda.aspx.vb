Public Partial Class WFAgenteVenda
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAgenteVenda1.Acao = Session("SAcao")
        WUCAgenteVenda1.CodAgente = Session("SCodAgenteVenda")
    End Sub

End Class