Public Class UCLVisitacao
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("visitacao")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pSeqVisita As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("seq_visita", pSeqVisita)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pSeqVisita As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("seq_visita", pSeqVisita)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String, ByVal pEstabelecimento As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(seq_visita),0) + 1 seq from visitacao where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento
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