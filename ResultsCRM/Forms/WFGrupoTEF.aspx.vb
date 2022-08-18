Public Class WFGrupoTEF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCGrupoTEF1.Acao = Session("SAcao")
        WUCGrupoTEF1.Codigo = Session("SCodAdesao")
    End Sub

End Class