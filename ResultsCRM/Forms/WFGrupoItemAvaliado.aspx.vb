Public Class WFGrupoItemAvaliado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCGrupoItemAvaliado1.Acao = Session("SAcaoGrupoItem")
        WUCGrupoItemAvaliado1.CodGrupoItem = Session("SCodGrupoItem")
    End Sub

End Class