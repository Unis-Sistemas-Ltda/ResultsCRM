Public Class WFAtendimentoPedidoDespesa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCAtendimentoPedidoDespesa1.Acao = Session("SAcaoDespesa")
        WUCAtendimentoPedidoDespesa1.CodTipoDespAcess = Session("SAtCodTipoDespAcess")
        WUCAtendimentoPedidoDespesa1.CodPedidoVenda = Session("SAtCodPedido")
        WUCAtendimentoPedidoDespesa1.MostraBotaoVoltar = True
    End Sub

End Class