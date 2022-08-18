Public Class UCLAnalista

    Private _Codigo As String
    Private _Nome As String
    Private _Master As String
    Private _PrazoResolucao As String
    Private _Email As String
    Private _Telefone As String
    Private _Ramal As String
    Private _SMTP As String
    Private _Remetente As String
    Private _UsuarioEmail As String
    Private _SenhaEmail As String
    Private _Inativo As String
    Private _PermiteAlterarDataAberturaChamado As String
    Private objAcessoDados As UCLAcessoDados

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Public Property PermiteAlterarDataAberturaChamado() As String
        Get
            Return _PermiteAlterarDataAberturaChamado
        End Get
        Set(ByVal value As String)
            _PermiteAlterarDataAberturaChamado = value
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

    Public Property Master() As String
        Get
            Return _Master
        End Get
        Set(ByVal value As String)
            _Master = value
        End Set
    End Property

    Public Property PrazoResolucao() As String
        Get
            Return _PrazoResolucao
        End Get
        Set(ByVal value As String)
            _PrazoResolucao = value
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

    Public Property Telefone() As String
        Get
            Return _Telefone
        End Get
        Set(ByVal value As String)
            _Telefone = value
        End Set
    End Property

    Public Property Ramal() As String
        Get
            Return _Ramal
        End Get
        Set(ByVal value As String)
            _Ramal = value
        End Set
    End Property

    Public Property SMTP() As String
        Get
            Return _SMTP
        End Get
        Set(ByVal value As String)
            _SMTP = value
        End Set
    End Property

    Public Property Remetente() As String
        Get
            Return _Remetente
        End Get
        Set(ByVal value As String)
            _Remetente = value
        End Set
    End Property

    Public Property UsuarioEmail() As String
        Get
            Return _UsuarioEmail
        End Get
        Set(ByVal value As String)
            _UsuarioEmail = value
        End Set
    End Property

    Public Property SenhaEmail() As String
        Get
            Return _SenhaEmail
        End Get
        Set(ByVal value As String)
            _SenhaEmail = value
        End Set
    End Property

    Public Property Inativo() As String
        Get
            Return _Inativo
        End Get
        Set(ByVal value As String)
            _Inativo = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select a.cod_analista, isnull(a.permite_alterar_data_abertura_chamado,'N') permite_alterar_data_abertura_chamado, u.nome_usuario nome,  isnull(a.master,'N') master, isnull(a.prazo_resolucao,0) prazo_resolucao,  a.email, a.telefone, a.ramal, a.smtp, isnull(a.remetente, u.nome_usuario) remetente, a.usuario, a.senha, isnull(a.inativo,'N') inativo "
        StrSql += "   from analista a inner join sysusuario u on a.cod_analista = u.cod_usuario "
        StrSql += "  where cod_analista = " + Codigo
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Nome = dt.Rows.Item(0).Item("nome").ToString
            Master = dt.Rows.Item(0).Item("master").ToString
            PrazoResolucao = dt.Rows.Item(0).Item("prazo_resolucao").ToString
            Email = dt.Rows.Item(0).Item("email").ToString
            Telefone = dt.Rows.Item(0).Item("telefone").ToString
            Ramal = dt.Rows.Item(0).Item("smtp").ToString
            Remetente = dt.Rows.Item(0).Item("remetente").ToString
            UsuarioEmail = dt.Rows.Item(0).Item("usuario").ToString
            SenhaEmail = dt.Rows.Item(0).Item("senha").ToString
            Inativo = dt.Rows.Item(0).Item("inativo").ToString
            PermiteAlterarDataAberturaChamado = dt.Rows.Item(0).Item("permite_alterar_data_abertura_chamado").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String, ByVal SomenteAtivos As Boolean, ByVal IncluirPendentes As Boolean, ByVal CodAnalista As String, ByVal CodAnalistaMaster As String)
        Dim strSql As String = ""
        Dim dt, dt2 As DataTable

        strSql += " select convert(text,a.cod_analista) cod_analista, u.nome_usuario nome"
        strSql += "   from analista a inner join sysusuario u on a.cod_analista = u.cod_usuario"
        strSql += "  where 1 = 1"
        If SomenteAtivos Then
            strSql += "  and ( isnull(a.inativo,'N') = 'N' or cod_analista = " + IIf(String.IsNullOrWhiteSpace(CodAnalista), "0", CodAnalista) + ")"
        End If
        If Not String.IsNullOrEmpty(CodAnalistaMaster) Then
            strSql += "  and ( exists( select 1 from analista where master = 'S' and cod_analista = " + CodAnalistaMaster + " ) or a.cod_analista = " + CodAnalistaMaster + ")"
        End If
        strSql += "  order by nome "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            If Not String.IsNullOrEmpty(CodAnalistaMaster) Then
                dt2 = objAcessoDados.BuscarDados("select if exists( select 1 from analista where master = 'S' and cod_analista = " + CodAnalistaMaster + " ) then  1 else 0 endif valor from dummy")
                If dt2.Rows.Count > 0 Then
                    If dt2.Rows.Item(0).Item("valor") = 1 Then
                        Dim NovaLinha As DataRow = dt.NewRow
                        NovaLinha("cod_analista") = CodRegistroEmBranco
                        If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                            DescricaoRegistroEmBranco = " "
                        End If
                        NovaLinha("nome") = DescricaoRegistroEmBranco
                        dt.Rows.InsertAt(NovaLinha, 0)
                    End If
                End If
            Else
                Dim NovaLinha As DataRow = dt.NewRow
                NovaLinha("cod_analista") = CodRegistroEmBranco
                If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                    DescricaoRegistroEmBranco = " "
                End If
                NovaLinha("nome") = DescricaoRegistroEmBranco
                dt.Rows.InsertAt(NovaLinha, 0)
            End If
        End If

        If IncluirPendentes Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_analista") = "-9"
            NovaLinha("nome") = "(Pendentes)"
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "cod_analista"
        DDL.DataBind()
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_analista),0) + 1 max from analista "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into ( cod_analista, master, permite_alterar_data_abertura_chamado, prazo_resolucao, email, telefone, ramal, smtp, id_email, remetente, usuario, senha, tipo_valor, fato_gerador, inativo, valor_custo_hora, cod_veiculo )"
            strSql += " values (" + Codigo + ", '" + Master + "', '" + PermiteAlterarDataAberturaChamado + "', '" + Email + "', '" + Telefone + "', '" + Ramal + "', '" + SMTP + "', null, '" + Remetente + "', '" + UsuarioEmail + "', '" + SenhaEmail + "', null, null, '" + Inativo + "', null, null)"
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update analista "
            strSql += "    set master = '" + Master + "', "
            strSql += "        prazo_resolucao = " + IIf(String.IsNullOrEmpty(PrazoResolucao), "null", PrazoResolucao) + ", "
            strSql += "        email = '" + Email + "', "
            strSql += "        telefone = '" + Telefone + "', "
            strSql += "        ramal = '" + Ramal + "', "
            strSql += "        smtp = '" + SMTP + "', "
            strSql += "        remetente = '" + Remetente + "', "
            strSql += "        usuario = '" + UsuarioEmail + "', "
            strSql += "        senha = '" + SenhaEmail + "', "
            strSql += "        permite_alterar_data_abertura_chamado = '" + PermiteAlterarDataAberturaChamado + "', "
            strSql += "        inativo = '" + Inativo + "'"
            strSql += "  where cod_analista = " + Codigo
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class