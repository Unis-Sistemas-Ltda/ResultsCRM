Public Class UCLGestorContaRepresentante
    Private ObjAcessoDados As UCLAcessoDados

    Public Sub New()
        ObjAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Incluir(ByVal pCodGestor As String, ByVal pCodRepresentante As String) As Boolean
        Try
            Dim StrSql As String
            StrSql = " insert into gestor_conta_representante(cod_gestor, cod_representante) "
            StrSql += "  select " + pCodGestor + ", " + pCodRepresentante
            StrSql += "    from dummy "
            StrSql += "   where not exists(select 1 from gestor_conta_representante where cod_gestor = " + pCodGestor + " and cod_representante = " + pCodRepresentante + ")"
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Excluir(ByVal pCodGestor As String, ByVal pCodRepresentante As String) As Boolean
        Try
            Dim StrSql As String
            StrSql = " delete from gestor_conta_representante "
            StrSql += " where cod_gestor = " + pCodGestor + " and cod_representante = " + pCodRepresentante
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
