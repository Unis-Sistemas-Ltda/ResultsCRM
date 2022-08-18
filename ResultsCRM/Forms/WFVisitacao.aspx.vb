Partial Public Class WFVisitacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCVisitacao1.Acao = Session("SAcaoVisitacao")
        WUCVisitacao1.Codigo = Session("SSeqVisita")
    End Sub

End Class