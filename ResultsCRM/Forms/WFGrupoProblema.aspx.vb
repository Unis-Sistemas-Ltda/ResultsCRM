Public Class WFGrupoProblema
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCGrupoProblema1.Acao = Session("SAcaoGrupoProblema")
        WUCGrupoProblema1.CodGrupo = Session("SCodGrupoProblema")
    End Sub

End Class