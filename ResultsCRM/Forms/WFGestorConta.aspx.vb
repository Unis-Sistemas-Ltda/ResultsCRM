Public Partial Class WFGestorConta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCGestorConta1.CodGestor = Session("SCodGestorConta")
        WUCGestorConta1.Acao = Session("SAcao")
    End Sub

End Class