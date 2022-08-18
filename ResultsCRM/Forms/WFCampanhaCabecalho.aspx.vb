Public Class WFCampanhaCabecalho
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCTEFGrupo1.CodGrupo = Session("SCodGrupoTEF")
        WUCTEFGrupo1.Acao = Session("SAcaoGrupoTEF")
    End Sub

End Class