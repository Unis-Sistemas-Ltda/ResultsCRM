Public Class UCLUsuario

    Private _CodUsuario As String
    Private _Usuario As String
    Private _Senha As String
    Private _NomeUsuario As String
    Private _EmpresaPadrao As String
    Private _EstabelecimentoPadrao As String
    Private _Situacao As String
    Private _CodGrupoExterno As String
    Private _CodEmitenteExterno As String
    Private objAcessoDados As UCLAcessoDados

    Public Enum SituacaoUsuario As Integer
        Administrador = 1
        Liberado = 2
        Restrito = 3
        Bloqueado = 4
        Cancelado = 5
    End Enum

    Public Property Situacao() As String
        Get
            Return _Situacao
        End Get
        Set(ByVal value As String)
            _Situacao = value
        End Set
    End Property

    Public Property CodEmitenteExterno As String
        Get
            Return _CodEmitenteExterno
        End Get
        Set(value As String)
            _CodEmitenteExterno = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Public Property CodUsuario() As String
        Get
            Return _CodUsuario
        End Get
        Set(ByVal value As String)
            _CodUsuario = value
        End Set
    End Property

    Public Property Senha() As String
        Get
            Return _Senha
        End Get
        Set(ByVal value As String)
            _Senha = value
        End Set
    End Property

    Public Property CodGrupoExterno() As String
        Get
            Return _CodGrupoExterno
        End Get
        Set(ByVal value As String)
            _CodGrupoExterno = value
        End Set
    End Property

    Public Property NomeUsuario() As String
        Get
            Return _NomeUsuario
        End Get
        Set(ByVal value As String)
            _NomeUsuario = value
        End Set
    End Property

    Public Property EmpresaPadrao() As String
        Get
            Return _EmpresaPadrao
        End Get
        Set(ByVal value As String)
            _EmpresaPadrao = value
        End Set
    End Property

    Public Property EstabelecimentoPadrao()
        Get
            Return _EstabelecimentoPadrao
        End Get
        Set(ByVal value)
            _EstabelecimentoPadrao = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Function AutorizarUsuariosAcessarBD()
        Try
            Dim StrSql As String = "select distinct nome_identificacao from sysusuario u where not exists(select 1 from sysuserlist l where l.name = u.nome_identificacao)"
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            For Each row As DataRow In dt.Rows
                StrSql = "call sp_sysusuario(1, '" + row.Item("nome_identificacao") + "')"
                objAcessoDados.ExecutarSql(StrSql)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Buscar() As Boolean
        Dim StrSql As String = "select cod_usuario, ds_senha senha, cod_grupo_externo, id_situacao, nome_usuario, cod_emitente_externo, cod_empresa_padrao empresa, cod_estabelecimento_padrao estabelecimento from sysusuario where nome_identificacao = '" + Usuario + "'"
        Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Senha = dt.Rows.Item(0).Item("senha").ToString
            EmpresaPadrao = dt.Rows.Item(0).Item("empresa").ToString
            EstabelecimentoPadrao = dt.Rows.Item(0).Item("estabelecimento").ToString
            NomeUsuario = dt.Rows.Item(0).Item("nome_usuario").ToString
            CodUsuario = dt.Rows.Item(0).Item("cod_usuario").ToString
            Situacao = dt.Rows.Item(0).Item("id_situacao").ToString
            CodGrupoExterno = dt.Rows.Item(0).Item("cod_grupo_externo").ToString
            CodEmitenteExterno = dt.Rows.Item(0).Item("cod_emitente_externo").ToString
            Return True
        Else
            Return False
        End If
    End Function

    Public Function BuscarPorCodigo() As Boolean
        Dim StrSql As String = "select nome_identificacao, id_situacao, cod_grupo_externo, ds_senha senha, nome_usuario, cod_emitente_externo, cod_empresa_padrao empresa, cod_estabelecimento_padrao estabelecimento from sysusuario where cod_usuario = " + CodUsuario
        Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Usuario = dt.Rows.Item(0).Item("nome_identificacao")
            Senha = dt.Rows.Item(0).Item("senha").ToString
            EmpresaPadrao = dt.Rows.Item(0).Item("empresa").ToString
            EstabelecimentoPadrao = dt.Rows.Item(0).Item("estabelecimento").ToString
            NomeUsuario = dt.Rows.Item(0).Item("nome_usuario").ToString
            Situacao = dt.Rows.Item(0).Item("id_situacao").ToString
            CodGrupoExterno = dt.Rows.Item(0).Item("cod_grupo_externo").ToString
            CodEmitenteExterno = dt.Rows.Item(0).Item("cod_emitente_externo").ToString
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub FillControl(ByRef DDL As Object, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select a.cod_usuario, a.nome_usuario "
        strSql += "   from sysusuario a "
        strSql += "  where id_situacao in (1,2,3)"
        strSql += "  order by nome_usuario "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_usuario") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome_usuario") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        If TypeOf DDL Is DropDownList Then
            CType(DDL, DropDownList).DataSource = dt
            CType(DDL, DropDownList).DataTextField = "nome_usuario"
            CType(DDL, DropDownList).DataValueField = "cod_usuario"
            CType(DDL, DropDownList).DataBind()
        ElseIf TypeOf DDL Is ListBox Then
            CType(DDL, ListBox).DataSource = dt
            CType(DDL, ListBox).DataTextField = "nome_usuario"
            CType(DDL, ListBox).DataValueField = "cod_usuario"
            CType(DDL, ListBox).DataBind()
        End If
        
    End Sub

    Public Function GetTipoAcesso(ByVal CodUsuario As String) As TipoAcesso
        Dim strSql As String
        Dim CodTpAgenteVendas As String = ""
        Dim dt As DataTable
        Dim retorno As TipoAcesso

        strSql = ""
        strSql += " select cod_tp_agente_venda "
        strSql += "   from agente_venda a "
        strSql += "  where cod_agente_venda = " + CodUsuario
        dt = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows.Item(0).Item("cod_tp_agente_venda")) Then
                retorno = TipoAcesso.SemAcesso
            Else
                CodTpAgenteVendas = dt.Rows.Item(0).Item("cod_tp_agente_venda").ToString
            End If
        Else
            retorno = TipoAcesso.SemAcesso
        End If

        If retorno <> TipoAcesso.SemAcesso Then
            If Not String.IsNullOrEmpty(CodTpAgenteVendas) Then
                strSql = ""
                strSql += " select isnull(acesso,1) acesso "
                strSql += "   from tipo_agente_venda a "
                strSql += "  where cod_tp_agente_vendas = " + CodTpAgenteVendas
                dt = objAcessoDados.BuscarDados(strSql)

                If dt.Rows.Count > 0 Then
                    retorno = dt.Rows.Item(0).Item("acesso").ToString
                Else
                    retorno = TipoAcesso.SemAcesso
                End If
            Else
                retorno = TipoAcesso.SemAcesso
            End If
        End If

        If retorno = TipoAcesso.SemAcesso Then
            strSql = ""
            strSql += " select 1 acesso "
            strSql += "   from analista a "
            strSql += "  where cod_analista = " + CodUsuario
            strSql += "    and isnull(inativo,'N') = 'N'"
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                retorno = TipoAcesso.PosVendas
            Else
                retorno = TipoAcesso.SemAcesso
            End If
        End If

        Return retorno

    End Function

    Public Sub Alterar()
        Try
            Dim StrSql As String = ""
            StrSql += " update sysusuario "
            StrSql += "    set ds_senha = '" + Senha + "', "
            StrSql += "        nome_usuario = '" + NomeUsuario + "' "
            StrSql += "  where cod_usuario = " + CodUsuario
            objAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Enum TipoAcesso As Integer
        SemAcesso = -1
        Vendas = 1
        PosVendas = 2
        Representante = 3
        Regional = 4
        Total = 0
    End Enum

    Public Sub FillDropDownDepartamentos(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_departamento, descricao "
        strSql += "   from departamento "
        strSql += "  order by descricao "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_departamento") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_departamento"
        DDL.DataBind()
    End Sub


End Class