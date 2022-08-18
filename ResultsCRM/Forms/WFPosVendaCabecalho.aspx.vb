Partial Public Class WFPosVendaCabecalho
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCPosVendaCabecalho1.CodEmitente = Session("SCodEmitente")
        WUCPosVendaCabecalho1.CNPJEmitente = Session("SCNPJEmitente")
        WUCPosVendaCabecalho1.Acao = Session("SAcaoPosVenda")
    End Sub

End Class