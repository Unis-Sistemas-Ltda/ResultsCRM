Public Class UCLSysGrupoExternoPermissao
    Private ObjAcessoDados As UCLAcessoDados
    Private _Empresa, _CodGrupoExterno, _CodModuloExterno, _NomeMenuItem As String

    Public Sub New()
        Try
            ObjAcessoDados = New UCLAcessoDados(StrConexao)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Property Empresa As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property CodGrupoExterno As String
        Get
            Return _CodGrupoExterno
        End Get
        Set(ByVal value As String)
            _CodGrupoExterno = value
        End Set
    End Property

    Public Property CodModuloExterno As String
        Get
            Return _CodModuloExterno
        End Get
        Set(ByVal value As String)
            _CodModuloExterno = value
        End Set
    End Property

    Public Property NomeMenuItem As String
        Get
            Return _NomeMenuItem
        End Get
        Set(ByVal value As String)
            _NomeMenuItem = value
        End Set
    End Property

    Public Function Existe() As Boolean
        Try
            Dim StrSql As String = "select 1 from sysgrupo_externo_permissao where empresa = " + Empresa + " and cod_grupo_externo = " + CodGrupoExterno + " and cod_modulo_externo = " + CodModuloExterno + " and nome_menu_item = " + NomeMenuItem
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            Return dt.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Incluir()
        Try
            Dim StrSql As String = "insert into sysgrupo_externo_permissao (empresa, cod_grupo_externo, cod_modulo_externo, nome_menu_item) values (" + Empresa + ", " + CodGrupoExterno + ", " + CodModuloExterno + ", '" + NomeMenuItem + "')"
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Excluir() As Boolean
        Try
            Dim StrSql As String = "delete from sysgrupo_externo_permissao where empresa = " + Empresa + " and cod_grupo_externo = " + CodGrupoExterno + " and cod_modulo_externo = " + CodModuloExterno + " and nome_menu_item = " + NomeMenuItem
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            Return dt.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
