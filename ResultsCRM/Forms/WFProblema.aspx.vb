Public Class WFProblema
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCProblema1.Acao = Session("SAcao")
        WUCProblema1.CodProblema = Session("SCodProblema")
    End Sub

End Class