Public Class UCLEmailAnexo
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("email_anexo", StrConexaoEmail)
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pSeqEmail As String, ByVal pSeqAnexo As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("seq_email", pSeqEmail)
            Me.SetConteudo("seq_anexo", pSeqAnexo)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pSeqEmail As String)
        Try
            Dim StrSql As String = " select seq_anexo from email_anexo where empresa = " + pEmpresa + " and seq_email = " + pSeqEmail
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            For Each row As DataRow In dt.Rows
                Me.Excluir(pEmpresa, pSeqEmail, row.Item("seq_anexo"))
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pSeqEmail As String, ByVal pSeqAnexo As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("seq_email", pSeqEmail)
            Me.SetConteudo("seq_anexo", pSeqAnexo)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String, ByVal pSeqEmail As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(seq_anexo),0) + 1 seq from email_anexo where empresa = " + pEmpresa + " and seq_email = " + pSeqEmail
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
