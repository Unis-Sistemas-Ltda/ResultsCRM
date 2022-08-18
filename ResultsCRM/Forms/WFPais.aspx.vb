Public Partial Class WFPais
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCPais1.Acao = Session("SAcao")
        WUCPais1.CodPais = Session("SCodPais")
    End Sub
End Class