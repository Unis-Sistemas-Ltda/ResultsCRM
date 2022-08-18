Partial Public Class WFNegociacaoEmail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCNegociacaoEmail1.Empresa = Session("GlEmpresa")
        WUCNegociacaoEmail1.SeqEmail = Session("SSeqEmail")
        WUCNegociacaoEmail1.Acao = Session("SAcaoEmail")
    End Sub

End Class