Public Partial Class WFAtendimentoPedidoItem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            WUCAtendimentoPedidoItem1.Empresa = Session("GlEmpresa")
            WUCAtendimentoPedidoItem1.Estabelecimento = Session("GlEstabelecimento")
            WUCAtendimentoPedidoItem1.CodPedidoVenda = Session("SAtCodPedido")
            WUCAtendimentoPedidoItem1.SeqItem = Session("SAtSeqItemPedido")
            WUCAtendimentoPedidoItem1.Acao = Session("SAcaoAtPedido")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class