Partial Public Class WFSistema
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCSistema1.Acao = Session("SAcao")
        WUCSistema1.Codigo = Session("SCodSistema")
    End Sub

End Class