Public Class UCLSistemaRelease

    Private objAcessoDados As UCLAcessoDados
    Public Property CodSistema As String
    Public Property Release As String

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Existe() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select cod_sistema "
        StrSql += "   from sistema_release "
        StrSql += "  where cod_sistema  = " + CodSistema
        StrSql += "    and " + Chr(34) + "release" + Chr(34) + " = " + Release
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select " + Chr(34) + "release" + Chr(34)
        strSql += "   from sistema_release "
        strSql += "  where cod_sistema = " + CodSistema
        strSql += "  order by " + Chr(34) + "release" + Chr(34) + " desc "
        dt = objAcessoDados.BuscarDados(strSql)

        DDL.DataSource = dt
        DDL.DataTextField = "release"
        DDL.DataValueField = "release"
        DDL.DataBind()
    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into sistema_release ( cod_sistema, " + Chr(34) + "release" + Chr(34) + " ) "
            strSql += " values ( " + CodSistema + ", " + Release + " ) "
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub Excluir()
        Dim strSql As String = ""
        Try
            strSql += " delete from sistema_release "
            strSql += "  where cod_sistema  = " + CodSistema
            strSql += "    and " + Chr(34) + "release" + Chr(34) + " = " + Release
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
