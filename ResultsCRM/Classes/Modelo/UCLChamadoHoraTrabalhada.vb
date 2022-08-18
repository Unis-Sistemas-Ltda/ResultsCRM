Public Class UCLChamadoHoraTrabalhada
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("chamado_hora_trabalhada")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pSeqHora As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_chamado", pCodChamado)
            Me.SetConteudo("seq_hora", pSeqHora)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pSeqHora As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_chamado", pCodChamado)
            Me.SetConteudo("seq_hora", pSeqHora)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String, ByVal pCodChamado As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(seq_hora),0) + 1 seq from chamado_hora_trabalhada where empresa = " + pEmpresa + " and cod_chamado = " + pCodChamado
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
