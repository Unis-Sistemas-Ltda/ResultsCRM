Public Class UCLVersaoSistema


    Public Property CodSistema As String
    Public Property CodSistemaVersao As String
    Public Property Release As String
    Public Property CodBancoDados As String
    Public Property Versao As String
    Private objAcessoDados As UCLAcessoDados


    Public Sub Incluir()
        Dim strSql As String = ""
        Try
            strSql += " insert into sistema_versao (cod_sistema, cod_sistema_versao, " + Chr(34) + "release" + Chr(34) + ", cod_banco_dados, versao, data_liberacao) "
            strSql += " values (" + CodSistema + ", " + CodSistemaVersao + ", " + Release + ", " + CodBancoDados + ", " + Versao + ", getdate() ) "
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try
            strSql += " update sistema_versao"
            strSql += "    set " + Chr(34) + "release" + Chr(34) + " = " + Release + ", "
            strSql += "        cod_banco_dados = " + CodBancoDados + ", "
            strSql += "        versao = " + Versao
            strSql += "  where cod_sistema = " + CodSistema
            strSql += "    and cod_sistema_versao = " + CodSistemaVersao
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Dim strSql As String = ""
        Try
            strSql += " delete from sistema_versao "
            strSql += "  where cod_sistema = " + CodSistema
            strSql += "    and cod_sistema_versao = " + CodSistemaVersao
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select " + Chr(34) + "release" + Chr(34) + ", cod_banco_dados, versao "
        StrSql += "   from sistema_versao "
        StrSql += "  where cod_sistema = " + CodSistema
        StrSql += "    and cod_sistema_versao = " + CodSistemaVersao
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Release = dt.Rows.Item(0).Item("release").ToString
            CodBancoDados = dt.Rows.Item(0).Item("cod_banco_dados").ToString
            Versao = dt.Rows.Item(0).Item("versao").ToString
            Return True
        Else
            Return False
        End If

    End Function

End Class
