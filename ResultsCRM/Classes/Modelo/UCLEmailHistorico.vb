Public Class UCLEmailHistorico
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("email_historico", StrConexaoEmail)
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pSeqEmail As String, ByVal pSeqHistorico As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("seq_email", pSeqEmail)
            Me.SetConteudo("seq_historico", pSeqHistorico)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pSeqEmail As String, ByVal pSeqHistorico As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("seq_email", pSeqEmail)
            Me.SetConteudo("seq_historico", pSeqHistorico)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String, ByVal pSeqEmail As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(seq_historico),0) + 1 seq from email_historico where empresa = " + pEmpresa + " and seq_email = " + pSeqEmail
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
