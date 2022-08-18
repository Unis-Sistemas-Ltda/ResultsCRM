Public Partial Class WFCarteira
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCCarteira1.Acao = Session("SAcao")
        WUCCarteira1.CodCarteira = Session("SCodCarteira")
    End Sub

End Class