Public Partial Class WFAprovFinancOSCabecalho
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Remove("SCodAtendimento")
        WUAprovFinancOSCabecalho1.Empresa = Session("GlEmpresa")
        WUAprovFinancOSCabecalho1.Estabelecimento = Session("GlEstabelecimento")
        WUAprovFinancOSCabecalho1.CodAtendimento = Session("SCodAtendimento")
        WUAprovFinancOSCabecalho1.CodPedidoVenda = Session("SAtCodPedido")
        WUAprovFinancOSCabecalho1.Acao = Session("SAcaoAtPedidoCab")

    End Sub

End Class