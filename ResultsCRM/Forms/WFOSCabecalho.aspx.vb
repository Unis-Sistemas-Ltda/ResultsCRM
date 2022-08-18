Partial Public Class WFOSCabecalho
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Remove("SCodAtendimento")
        WUCAtendimentoPedidoCabecalho1.Empresa = Session("GlEmpresa")
        WUCAtendimentoPedidoCabecalho1.Estabelecimento = Session("GlEstabelecimento")
        WUCAtendimentoPedidoCabecalho1.CodAtendimento = Session("SCodAtendimento")
        WUCAtendimentoPedidoCabecalho1.CodPedidoVenda = Session("SAtCodPedido")
        WUCAtendimentoPedidoCabecalho1.Acao = Session("SAcaoAtPedidoCab")
        WUCAtendimentoPedidoCabecalho1.OrigemAberturaTela = WUCAtendimentoPedidoCabecalho.TipoAberturaTela.PainelDeOS
    End Sub

End Class