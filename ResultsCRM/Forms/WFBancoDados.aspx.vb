Partial Public Class WFBancoDados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCBancoDados1.Acao = Session("SAcao")
        WUCBancoDados1.Codigo = Session("SCodBancoDados")
    End Sub

End Class