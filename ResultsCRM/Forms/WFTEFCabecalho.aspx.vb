Public Class WFTEFCabecalho
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCTEF1.Acao = Session("SAcao")
        WUCTEF1.CodLoja = Session("SCodLoja")
        WUCTEF1.CNPJLoja = Session("SCNPJLoja")
    End Sub

End Class