Public Partial Class WFAtendimentoPedidoCabecalho
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAtendimentoPedidoCabecalho1.Empresa = Session("GlEmpresa")
        WUCAtendimentoPedidoCabecalho1.Estabelecimento = Session("GlEstabelecimento")
        WUCAtendimentoPedidoCabecalho1.CodAtendimento = Session("SCodAtendimento")
        WUCAtendimentoPedidoCabecalho1.Acao = Session("SAcaoAtPedidoCab")
        WUCAtendimentoPedidoCabecalho1.OrigemAberturaTela = WUCAtendimentoPedidoCabecalho.TipoAberturaTela.Atendimento
    End Sub

End Class