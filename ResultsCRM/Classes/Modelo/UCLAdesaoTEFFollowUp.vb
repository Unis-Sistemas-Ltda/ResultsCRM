Public Class UCLAdesaoTEFFollowUp

    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("adesao_tef_follow_up")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pCNPJ As String, ByVal pSeqFollowUP As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cnpj", pCNPJ)
            Me.SetConteudo("seq_follow_up", pSeqFollowUP)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Buscar(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pSeqFollowUP As String)
        Try
            Dim StrSql As String = " select cnpj from adesao_tef_follow_up where empresa = " + pEmpresa + " and cod_emitente = " + pCodEmitente + " and seq_follow_up = " + pSeqFollowUP
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Me.Buscar(pEmpresa, pCodEmitente, dt.Rows.Item(0).Item("cnpj").ToString, pSeqFollowUP)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pSeqFollowUP As String)
        Try
            Dim StrSql As String = " delete from adesao_tef_follow_up where empresa = " + pEmpresa + " and cod_emitente = " + pCodEmitente + " and seq_follow_up = " + pSeqFollowUP
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pCNPJ As String, ByVal pSeqFollowUP As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cnpj", pCNPJ)
            Me.SetConteudo("seq_follow_up", pSeqFollowUP)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String, ByVal pCodEmitente As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(seq_follow_up),0) + 1 seq from adesao_tef_follow_up where empresa = " + pEmpresa + " and cod_emitente = " + pCodEmitente
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