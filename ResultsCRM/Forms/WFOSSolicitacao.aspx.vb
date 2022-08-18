Partial Public Class WFOSSolicitacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

            WUCAtendimentoPedidoSolicitacao1.Empresa = Session("GlEmpresa")
            WUCAtendimentoPedidoSolicitacao1.Estabelecimento = Session("GlEstabelecimento")
            WUCAtendimentoPedidoSolicitacao1.CodPedidoVenda = Session("SAtCodPedido")
            WUCAtendimentoPedidoSolicitacao1.SeqSolicitacao = Session("SAtSeqItemPedido")
            WUCAtendimentoPedidoSolicitacao1.Acao = Session("SAcaoAtPedido")
            WUCAtendimentoPedidoSolicitacao1.CaminhoVoltar = "WGAtendimentoPedidoItem.aspx"
            WUCAtendimentoPedidoSolicitacao1.MostraBotaoVoltar = True

            objPedido.empresa = WUCAtendimentoPedidoSolicitacao1.Empresa
            objPedido.estabelecimento = WUCAtendimentoPedidoSolicitacao1.Estabelecimento
            objPedido.codPedidoVenda = WUCAtendimentoPedidoSolicitacao1.CodPedidoVenda
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