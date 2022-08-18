Public Class UCLRoteiroAtendimento
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("roteiro_atendimento")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodRoteiro As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_roteiro", pCodRoteiro)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodRoteiro As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_roteiro", pCodRoteiro)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String, ByVal pEstabelecimento As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(cod_roteiro),0) + 1 seq from roteiro_atendimento where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento
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

    Public Function EnviaEmailRoteiro(ByVal StrConn As String, ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodRoteiro As String) As String
        Try
            Dim strSql As String = "select f_email_roteiro_atendimento( " + pEmpresa + ", " + pEstabelecimento + ", " + pCodRoteiro + " ) ret from dummy"
            Dim retorno As String = ObjAcessoDados.BuscarDadosComTransacao(strSql, StrConn)
            Return retorno
        Catch ex As Exception
            GravaLog("UCLRoteiroAtendimento: EnviaEmailRoteiro(...) " + vbCr + vbLf + ex.ToString)
            Throw ex
        End Try
    End Function
End Class
