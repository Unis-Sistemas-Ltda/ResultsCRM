Public Class UCLAvaliacaoCliente
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("avaliacao_cliente")
    End Sub

    Public Sub Incluir()
        ObjTabelaGenerica.Incluir()

        Dim StrSql As String = "insert into avaliacao_cliente_item(empresa, cod_avaliacao, cod_tipo_avaliacao, seq_item_avaliado) select empresa, " + Me.GetConteudo("cod_avaliacao") + ", cod_tipo_avaliacao, seq_item_avaliado from item_avaliado where empresa = " + Me.GetConteudo("empresa") + " and cod_tipo_avaliacao = " + Me.GetConteudo("cod_tipo_avaliacao")
        ObjAcessoDados.ExecutarSql(StrSql)
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodAvaliacao As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_avaliacao", pCodAvaliacao)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodAvaliacao As String)
        Try

            Dim strSql As String = "delete from avaliacao_cliente_item where empresa = " + pEmpresa + " and cod_avaliacao = " + pCodAvaliacao
            ObjAcessoDados.ExecutarSql(strSql)

            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_avaliacao", pCodAvaliacao)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(cod_avaliacao),0) + 1 seq from avaliacao_cliente where empresa = " + pEmpresa
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
