Public Class UCLAvaliacaoClienteItem
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("avaliacao_cliente_item")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodAvaliacao As String, ByVal pCodTipoAvaliacao As String, ByVal pSeqItemAvaliado As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_avaliacao", pCodAvaliacao)
            Me.SetConteudo("cod_tipo_avaliacao", pCodTipoAvaliacao)
            Me.SetConteudo("seq_item_avaliado", pSeqItemAvaliado)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodAvaliacao As String, ByVal pCodTipoAvaliacao As String, ByVal pSeqItemAvaliado As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_avaliacao", pCodAvaliacao)
            Me.SetConteudo("cod_tipo_avaliacao", pCodTipoAvaliacao)
            Me.SetConteudo("seq_item_avaliado", pSeqItemAvaliado)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
