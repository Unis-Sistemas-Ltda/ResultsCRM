Partial Public Class WFOSItem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

            WUCAtendimentoPedidoItem1.Empresa = Session("GlEmpresa")
            WUCAtendimentoPedidoItem1.Estabelecimento = Session("GlEstabelecimento")
            WUCAtendimentoPedidoItem1.CodPedidoVenda = Session("SAtCodPedido")
            WUCAtendimentoPedidoItem1.SeqItem = Session("SAtSeqItemPedido")
            WUCAtendimentoPedidoItem1.Acao = Session("SAcaoAtPedido")
            WUCAtendimentoPedidoItem1.CaminhoVoltar = "WGAtendimentoPedidoItem.aspx"
            WUCAtendimentoPedidoItem1.MostraBotaoVoltar = True

            objPedido.empresa = WUCAtendimentoPedidoItem1.Empresa
            objPedido.estabelecimento = WUCAtendimentoPedidoItem1.Estabelecimento
            objPedido.codPedidoVenda = WUCAtendimentoPedidoItem1.CodPedidoVenda
            If Not String.IsNullOrEmpty(objPedido.empresa) AndAlso Not String.IsNullOrEmpty(objPedido.estabelecimento) AndAlso Not String.IsNullOrEmpty(objPedido.codPedidoVenda) Then
                If objPedido.Buscar() Then
                    Session("SCodAtendimento") = objPedido.codChamado

                    Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
                    objChamado.Empresa = objPedido.empresa
                    objChamado.CodChamado = objPedido.codChamado

                    If Not String.IsNullOrEmpty(objChamado.Empresa) AndAlso Not String.IsNullOrEmpty(objChamado.CodChamado) Then
                        If objChamado.Buscar() Then
                            Session("SCodEmitenteAtNegociacao") = objChamado.CodEmitenteAtendimento
                            Session("SCNPJEmitenteAtendimento") = objChamado.CnpjAtendimento
                        End If
                    End If

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class