Public Class UCLSysModuloExterno
    Private ObjAcessoDados As UCLAcessoDados
    Private _CodModuloExterno, _NomeModulo, _DSModulo, _NomeMenu As String

    Public Sub New()
        Try
            ObjAcessoDados = New UCLAcessoDados(StrConexao)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Property CodModuloExterno As String
        Get
            Return _CodModuloExterno
        End Get
        Set(ByVal value As String)
            _CodModuloExterno = value
        End Set
    End Property

    Public Property NomeModulo As String
        Get
            Return _NomeModulo
        End Get
        Set(ByVal value As String)
            _NomeModulo = value
        End Set
    End Property

    Public Property DSModulo As String
        Get
            Return _DSModulo
        End Get
        Set(ByVal value As String)
            _DSModulo = value
        End Set
    End Property

    Public Property NomeMenu As String
        Get
            Return _NomeMenu
        End Get
        Set(ByVal value As String)
            _NomeMenu = value
        End Set
    End Property

    Public Function Buscar(ByVal pCodModuloExterno) As Boolean
        Try
            CodModuloExterno = pCodModuloExterno
            Return Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function Buscar() As Boolean
        Try
            Dim StrSql As String = "select nome_modulo, ds_modulo, nome_menu from sysmodulo_externo where cod_modulo_externo = " + CodModuloExterno
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                DSModulo = dt.Rows.Item(0).Item("ds_modulo").ToString
                NomeModulo = dt.Rows.Item(0).Item("nome_modulo").ToString
                NomeMenu = dt.Rows.Item(0).Item("nome_menu").ToString
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
