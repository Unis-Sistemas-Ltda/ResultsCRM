Public Class UCLNegociacaoItemProgramacao
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("negociacao_cliente_item_programacao")
    End Sub

    Public Function BuscarPorReferencia(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacaoCliente As String, ByVal pSeqItem As String, ByVal pReferencia As String) As Boolean
        Try
            Dim StrSql As String = "select seq_programacao from negociacao_cliente_item_programacao where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento + " and cod_negociacao_cliente = " + pCodNegociacaoCliente + " and seq_item = " + pSeqItem + " and referencia = '" + pReferencia + "'"
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count = 0 Then
                Return False
            Else
                Me.SetConteudo("empresa", pEmpresa)
                Me.SetConteudo("estabelecimento", pEstabelecimento)
                Me.SetConteudo("cod_negociacao_cliente", pCodNegociacaoCliente)
                Me.SetConteudo("seq_item", pSeqItem)
                Me.SetConteudo("seq_programacao", dt.Rows.Item(0).Item("seq_programacao").ToString)
                Return ObjTabelaGenerica.Buscar()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Buscar(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacaoCliente As String, ByVal pSeqItem As String, ByVal pSeqProgramacao As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_negociacao_cliente", pCodNegociacaoCliente)
            Me.SetConteudo("seq_item", pSeqItem)
            Me.SetConteudo("seq_programacao", pSeqProgramacao)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetQuantidadeTotalItem(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacaoCliente As String, ByVal pSeqItem As String) As Double
        Try
            Dim StrSql As String = " select isnull(sum(qtd_pedida),0) qtd from negociacao_cliente_item_programacao where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento + " and cod_negociacao_cliente = " + pCodNegociacaoCliente + " and seq_item = " + pSeqItem
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count = 0 Then
                Return 0
            Else
                Return CDbl(dt.Rows.Item(0).Item("qtd"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacaoCliente As String, ByVal pSeqItem As String)
        Try
            Dim StrSql As String = " delete from negociacao_cliente_item_programacao where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento + " and cod_negociacao_cliente = " + pCodNegociacaoCliente + " and seq_item = " + pSeqItem
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacaoCliente As String, ByVal pSeqItem As String, ByVal pSeqProgramacao As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_negociacao_cliente", pCodNegociacaoCliente)
            Me.SetConteudo("seq_item", pSeqItem)
            Me.SetConteudo("seq_programacao", pSeqProgramacao)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacaoCliente As String, ByVal pSeqItem As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(seq_programacao),0) + 1 seq from negociacao_cliente_item_programacao where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento + " and cod_negociacao_cliente = " + pCodNegociacaoCliente + " and seq_item = " + pSeqItem
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("seq")
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
