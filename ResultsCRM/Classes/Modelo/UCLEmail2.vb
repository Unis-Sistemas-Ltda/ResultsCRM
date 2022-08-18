Public Class UCLEmail2
    Inherits UCLClasseGenerica

    Public Const TAM_CORPO_MENSAGEM_EMAIL As Integer = 1000

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("email", StrConexaoEmail)
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pSeqEmail As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("seq_email", pSeqEmail)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pSeqEmail As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("seq_email", pSeqEmail)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(seq_email),0) + 1 seq from email where empresa = " + pEmpresa
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

    Public Overrides Sub Alterar()
        Try
            Dim CorpoDaMensagem As String = Me.GetConteudo("corpo")
            Me.SetConteudo("corpo", CorpoDaMensagem)
            If CorpoDaMensagem.Length > TAM_CORPO_MENSAGEM_EMAIL Then
                Me.SetConteudo("corpo", CorpoDaMensagem.Substring(0, TAM_CORPO_MENSAGEM_EMAIL))
            Else
                Me.SetConteudo("corpo", CorpoDaMensagem)
            End If

            ObjTabelaGenerica.Alterar()

            While CorpoDaMensagem.Length > TAM_CORPO_MENSAGEM_EMAIL
                CorpoDaMensagem = CorpoDaMensagem.Substring(TAM_CORPO_MENSAGEM_EMAIL)
                Me.ConcatenarAoCorpoDaMensagem(Me.GetConteudo("empresa"), Me.GetConteudo("seq_email"), CorpoDaMensagem.Substring(0, Math.Min(TAM_CORPO_MENSAGEM_EMAIL, CorpoDaMensagem.Length)))
            End While

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overrides Sub Incluir()
        Try
            Dim CorpoDaMensagem As String = Me.GetConteudo("corpo")

            If CorpoDaMensagem.Length > TAM_CORPO_MENSAGEM_EMAIL Then
                Me.SetConteudo("corpo", CorpoDaMensagem.Substring(0, TAM_CORPO_MENSAGEM_EMAIL))
            Else
                Me.SetConteudo("corpo", CorpoDaMensagem)
            End If

            ObjTabelaGenerica.Incluir()

            While CorpoDaMensagem.Length > TAM_CORPO_MENSAGEM_EMAIL
                CorpoDaMensagem = CorpoDaMensagem.Substring(TAM_CORPO_MENSAGEM_EMAIL)
                Me.ConcatenarAoCorpoDaMensagem(Me.GetConteudo("empresa"), Me.GetConteudo("seq_email"), CorpoDaMensagem.Substring(0, Math.Min(TAM_CORPO_MENSAGEM_EMAIL, CorpoDaMensagem.Length)))
            End While
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConcatenarAoCorpoDaMensagem(ByVal pEmpresa As String, ByVal pSeqEmail As String, ByVal pTextoAConcatenar As String) As Boolean
        Try
            Dim strTextoAConcatenar As String = pTextoAConcatenar.Replace("'", "'||char(39)||'").Replace(Chr(34), "'||char(34)||'")
            Dim StrSql As String = " update email set corpo = corpo || '" + strTextoAConcatenar + "' where empresa = " + pEmpresa + " and seq_email = " + pSeqEmail
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAnexos(ByVal pEmpresa As String, ByVal pSeqEmail As String) As List(Of UCLEmailAnexo)
        Try
            Dim StrSql As String = " select seq_anexo, arquivo from email_anexo where empresa = " + pEmpresa + " and seq_email = " + pSeqEmail
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            Dim retorno As New List(Of UCLEmailAnexo)
            For Each row As DataRow In dt.Rows
                Dim objEmailAnexo As New UCLEmailAnexo
                objEmailAnexo.SetConteudo("empresa", pEmpresa)
                objEmailAnexo.SetConteudo("seq_email", pSeqEmail)
                objEmailAnexo.SetConteudo("seq_anexo", row.Item("seq_anexo"))
                objEmailAnexo.SetConteudo("arquivo", row.Item("arquivo"))
                retorno.Add(objEmailAnexo)
            Next
            Return retorno
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function SetSituacaoLeitura(ByVal pEmpresa As String, ByVal pSeqEmail As String, ByVal pSeqSituacaoLeitura As String)
        Try
            Dim StrSql As String = "update email set situacao_leitura = " + pSeqSituacaoLeitura + " where empresa = " + pEmpresa + " and seq_email = " + pSeqEmail
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetSituacaoLeitura(ByVal pEmpresa As String, ByVal pSeqEmail As String)
        Try
            Dim StrSql As String = "select situacao_leitura from email where empresa = " + pEmpresa + " and seq_email = " + pSeqEmail
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("situacao_leitura").ToString
            Else
                Return "0"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
