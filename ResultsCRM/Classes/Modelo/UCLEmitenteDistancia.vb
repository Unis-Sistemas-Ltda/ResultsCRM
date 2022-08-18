Public Class UCLEmitenteDistancia
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("emitente_distancia")
    End Sub

    Public Function Buscar(ByVal pCodEmitente As String, ByVal pSeqDistancia As String) As Boolean
        Try
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("seq_distancia", pSeqDistancia)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodEmitente As String, ByVal pSeqDistancia As String)
        Try
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("seq_distancia", pSeqDistancia)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pCodEmitente As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(seq_distancia),0) + 1 seq from emitente_distancia where cod_emitente = " + pCodEmitente
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
