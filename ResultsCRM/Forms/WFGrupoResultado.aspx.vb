Public Class WFGrupoResultado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCGrupoResultado1.Acao = Session("SAcaoGrupoResultado")
        WUCGrupoResultado1.CodGrupoResultado = Session("SCodGrupoResultado")
    End Sub

End Class