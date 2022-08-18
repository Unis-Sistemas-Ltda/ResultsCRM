Public Class UCLRoteiroAtendimentoPedidoVenda
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("roteiro_atendimento_pedido_venda")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodRoteiro As String, ByVal pCodPedidoVenda As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_roteiro", pCodRoteiro)
            Me.SetConteudo("cod_pedido_venda", pCodPedidoVenda)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodRoteiro As String, ByVal pCodPedidoVenda As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_roteiro", pCodRoteiro)
            Me.SetConteudo("cod_pedido_venda", pCodPedidoVenda)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
