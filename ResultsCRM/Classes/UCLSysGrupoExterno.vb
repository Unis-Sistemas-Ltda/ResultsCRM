Public Class UCLSysGrupoExterno
    Private ObjAcessoDados As UCLAcessoDados
    Private _CodGrupoExterno, _NomeGrupoExterno, _CampoIdentificador As String

    Public Sub New()
        Try
            ObjAcessoDados = New UCLAcessoDados(StrConexao)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Property CodGrupoExterno As String
        Get
            Return _CodGrupoExterno
        End Get
        Set(ByVal value As String)
            _CodGrupoExterno = value
        End Set
    End Property

    Public Property NomeGrupoExterno As String
        Get
            Return _NomeGrupoExterno
        End Get
        Set(ByVal value As String)
            _NomeGrupoExterno = value
        End Set
    End Property

    Public Property CampoIdentificador As String
        Get
            Return _CampoIdentificador
        End Get
        Set(ByVal value As String)
            _CampoIdentificador = value
        End Set
    End Property

    Public Function Buscar(ByVal pCodGrupoExterno) As Boolean
        Try
            CodGrupoExterno = pCodGrupoExterno
            Return Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function Buscar() As Boolean
        Try
            Dim StrSql As String = "select nome_grupo_externo, campo_identificador from sysgrupo_externo where cod_grupo_externo = " + CodGrupoExterno
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                NomeGrupoExterno = dt.Rows.Item(0).Item("nome_grupo_externo").ToString
                CampoIdentificador = dt.Rows.Item(0).Item("campo_identificador").ToString
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub FillDropDown(ByRef ddl As DropDownList)
        Try
            Dim StrSql As String = " select cod_grupo_externo, nome_grupo_externo from sysgrupo_externo "
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)

            ddl.DataSource = dt
            ddl.DataTextField = "nome_grupo_externo"
            ddl.DataValueField = "cod_grupo_externo"
            ddl.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Permissoes(ByVal pEmpresa As String, ByVal pCodGrupoExterno As String) As List(Of UCLSysGrupoExternoPermissao)
        Try
            Dim prms As New List(Of UCLSysGrupoExternoPermissao)
            Dim prm As UCLSysGrupoExternoPermissao
            Dim StrSql As String = "select cod_modulo_externo, nome_menu_item from sysgrupo_externo_permissao where empresa = " + pEmpresa + " and cod_grupo_externo = " + pCodGrupoExterno
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)

            For Each row As DataRow In dt.Rows
                prm = New UCLSysGrupoExternoPermissao
                prm.Empresa = pEmpresa
                prm.CodGrupoExterno = pCodGrupoExterno
                prm.CodModuloExterno = row.Item("cod_modulo_externo")
                prm.NomeMenuItem = row.Item("nome_menu_item")
                prms.Add(prm)
            Next

            Return prms
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
