Public Class WFTipoAvaliacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCTipoAvaliacao1.Acao = Session("SAcaoTipoAvaliacao")
        WUCTipoAvaliacao1.CodTipoAvaliacao = Session("SCodTipoAvaliacao")
    End Sub

End Class