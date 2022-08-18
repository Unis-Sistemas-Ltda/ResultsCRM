Public Class UCLItemAvaliado
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("item_avaliado")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodTipoAvaliacao As String, ByVal pSeqItemAvaliado As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_tipo_avaliacao", pCodTipoAvaliacao)
            Me.SetConteudo("seq_item_avaliado", pSeqItemAvaliado)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodTipoAvaliacao As String, ByVal pSeqItemAvaliado As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_tipo_avaliacao", pCodTipoAvaliacao)
            Me.SetConteudo("seq_item_avaliado", pSeqItemAvaliado)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String, ByVal pCodTipoAvaliacao As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(seq_item_avaliado),0) + 1 seq from item_avaliado where empresa = " + pEmpresa + " and cod_tipo_avaliacao = " + pCodTipoAvaliacao
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
