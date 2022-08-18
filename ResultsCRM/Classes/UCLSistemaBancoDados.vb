Public Class UCLSistemaBancoDados

    Private ObjAcessoDados As UCLAcessoDados
    Public Property CodSistema As String
    Public Property CodBancoDados As String

    Public Sub New()
        ObjAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub Incluir()
        Try
            Dim StrSql As String = " insert into sistema_banco_dados ( cod_sistema, cod_banco_dados ) values (" + CodSistema + ", " + CodBancoDados + ")"
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String = " delete from sistema_banco_dados where cod_sistema = " + CodSistema + " and cod_banco_dados = " + CodBancoDados
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Existe() As Boolean
        Try
            Dim StrSql As String = " select cod_sistema from sistema_banco_dados where cod_sistema = " + CodSistema + " and cod_banco_dados = " + CodBancoDados
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
