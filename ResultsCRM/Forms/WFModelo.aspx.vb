Public Partial Class WFModelo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCModelo1.Empresa = Session("GlEmpresa")
        WUCModelo1.CodModelo = Session("SCodModelo")
        WUCModelo1.Acao = Session("SAcao")
    End Sub

End Class