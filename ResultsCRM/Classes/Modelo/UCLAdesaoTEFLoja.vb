Public Class UCLAdesaoTEFLoja
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("adesao_tef_loja")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pCNPJ As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cnpj", pCNPJ)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pCNPJ As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cnpj", pCNPJ)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetCodPedidoVenda(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pCNPJ As String) As String
        Try
            If Me.Buscar(pEmpresa, pCodEmitente, pCNPJ) AndAlso Not Me.IsNull("cod_negociacao_cliente") Then
                Dim StrSql As String = "select cod_pedido_venda from pedido_venda where empresa = " + pEmpresa + " and cod_negociacao_cliente = " + Me.GetConteudo("cod_negociacao_cliente")
                Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
                If dt.Rows.Count > 0 Then
                    Return dt.Rows.Item(0).Item("cod_pedido_venda").ToString()
                Else
                    Return ""
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class