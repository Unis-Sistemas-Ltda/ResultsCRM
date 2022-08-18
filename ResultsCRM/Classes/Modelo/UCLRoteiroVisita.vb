Public Class UCLRoteiroVisita
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("roteiro_visita")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodVisita As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_roteiro_visita", pCodVisita)
            Dim achou As Boolean = ObjTabelaGenerica.Buscar()
            If Me.IsNull("situacao") Then
                Me.SetConteudo("situacao", 1)
            End If
            Return achou
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodVisita As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_roteiro_visita", pCodVisita)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String, ByVal pEstabelecimento As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(cod_roteiro_visita),0) + 1 seq from roteiro_visita where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento
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
