Public Class UCLGestorConta

    Private _Codigo As String
    Private _Nome As String
    Private _CodUsuario As String
    Private _Email As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodUsuario() As String
        Get
            Return _CodUsuario
        End Get
        Set(ByVal value As String)
            _CodUsuario = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return _Nome
        End Get
        Set(ByVal value As String)
            _Nome = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into gestor_conta (cod_gestor, cod_usuario, email)"
            strSql += " values ( " + Codigo + ", " + CodUsuario + ", '" + Email + "')"
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update gestor_conta set cod_usuario = " + CodUsuario + ","
            strSql += "                         email = '" + Email + "'"
            strSql += "  where cod_gestor = " + Codigo
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select g.cod_gestor, g.cod_usuario, g.email, u.nome_usuario nome"
        StrSql += "   from gestor_conta g inner join sysusuario u on g.cod_usuario = u.cod_usuario"
        StrSql += "  where cod_gestor = " + Codigo
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Nome = dt.Rows.Item(0).Item("nome").ToString
            CodUsuario = dt.Rows.Item(0).Item("cod_usuario").ToString
            Email = dt.Rows.Item(0).Item("email").ToString
            Return True
        Else
            Return False
        End If
    End Function

    Public Function BuscarPorCodUsuario() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select g.cod_gestor, g.cod_usuario, g.email, u.nome_usuario nome"
        StrSql += "   from gestor_conta g inner join sysusuario u on g.cod_usuario = u.cod_usuario"
        StrSql += "  where g.cod_usuario = " + CodUsuario
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Nome = dt.Rows.Item(0).Item("nome").ToString
            Codigo = dt.Rows.Item(0).Item("cod_gestor").ToString
            Email = dt.Rows.Item(0).Item("email").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select g.cod_gestor, u.nome_usuario nome"
        strSql += "   from gestor_conta g inner join sysusuario u on g.cod_usuario = u.cod_usuario"
        strSql += "  order by nome "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_gestor") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "cod_gestor"
        DDL.DataBind()
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_gestor),0) + 1 max from gestor_conta "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
