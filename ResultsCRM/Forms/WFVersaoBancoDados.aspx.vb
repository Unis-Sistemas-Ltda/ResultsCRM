Partial Public Class WFVersaoBancoDados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCVersaoBancoDados1.Acao = Session("SAcao")
        WUCVersaoBancoDados1.Versao = Session("SVersao")
        WUCVersaoBancoDados1.CodBancoDados = Session("SBancoDados")
    End Sub

End Class