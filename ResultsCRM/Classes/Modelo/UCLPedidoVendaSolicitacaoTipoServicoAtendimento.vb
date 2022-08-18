Public Class UCLPedidoVendaSolicitacaoTipoServicoAtendimento
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("pedido_venda_solicitacao_tipo_servico_atendimento")
    End Sub

    Public Function Existe(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodPedidoVenda As String, ByVal pSeqSolicitacao As String, ByVal pCodTipoServico As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_pedido_venda", pCodPedidoVenda)
            Me.SetConteudo("seq_solicitacao", pSeqSolicitacao)
            Me.SetConteudo("cod_tipo_servico", pCodTipoServico)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodPedidoVenda As String, ByVal pSeqSolicitacao As String, ByVal pCodTipoServico As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_pedido_venda", pCodPedidoVenda)
            Me.SetConteudo("seq_solicitacao", pSeqSolicitacao)
            Me.SetConteudo("cod_tipo_servico", pCodTipoServico)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodPedidoVenda As String, ByVal pSeqSolicitacao As String)
        Try
            Dim StrSql As String = " delete from pedido_venda_solicitacao_tipo_servico_atendimento where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento + " and cod_pedido_venda = " + pCodPedidoVenda + " and seq_solicitacao = " + pSeqSolicitacao
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class

