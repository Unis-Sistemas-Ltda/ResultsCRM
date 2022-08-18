Public Class WFEmail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCEmail1.Acao = Session("SAcaoEmail")
        WUCEmail1.SeqEmail = Request.QueryString.Item("e")
        WUCEmail1.Empresa = Session("GlEmpresa")
        WUCEmail1.AcaoAuxiliar = Session("SAcaoEmailAuxiliar")
        WUCEmail1.SeqEmailAuxiliar = Session("SSeqEmailAuxiliar")
    End Sub

End Class