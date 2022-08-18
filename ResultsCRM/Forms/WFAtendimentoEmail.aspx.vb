Partial Public Class WFAtendimentoEmail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAtendimentoEmail1.Empresa = Session("GlEmpresa")
        WUCAtendimentoEmail1.SeqEmail = Session("SSeqEmail")
        WUCAtendimentoEmail1.Acao = Session("SAcaoEmail")
    End Sub

End Class