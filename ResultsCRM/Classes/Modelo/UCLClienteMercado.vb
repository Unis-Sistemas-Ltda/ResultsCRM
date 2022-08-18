Public Class UCLClienteMercado
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("cliente_mercado")
    End Sub

    Public Function Buscar(ByVal pCodEmitente As String, ByVal pCodMercado As String) As Boolean
        Try
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cod_mercado", pCodMercado)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodEmitente As String, ByVal pCodMercado As String)
        Try
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cod_mercado", pCodMercado)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function BuscarPreferencial(ByVal pCodEmitente As String) As String
        Try
            Dim StrSql As String = "select cod_mercado from cliente_mercado where cod_emitente = " + pCodEmitente + " and isnull(preferencial,'N') = 'S'"
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("cod_mercado")
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
