Public Class UCLPedidoVendaDespesas
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("pedido_venda_despesas")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodPedidoVenda As String, ByVal pCodTipoDespAcess As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_pedido_venda", pCodPedidoVenda)
            Me.SetConteudo("cod_tipo_desp_acess", pCodTipoDespAcess)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodPedidoVenda As String, ByVal pCodTipoDespAcess As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_pedido_venda", pCodPedidoVenda)
            Me.SetConteudo("cod_tipo_desp_acess", pCodTipoDespAcess)
            ObjTabelaGenerica.Excluir()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodPedidoVenda As String)
        Try
            Dim StrSql As String = " delete from pedido_venda_despesas where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento + " and cod_pedido_venda = " + pCodPedidoVenda
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
