Public Class UCLContato
    Private _Codigo As String
    Private _CNPJ As String
    Private _NumeroPontoAtendimento As String
    Private _Nome As String
    Private _CodEmitente As String
    Private _Email As String
    Private _Titulo As String
    Private _Preferencial As String
    Private _Ativo As String
    Private _CPF As String
    Private _RG As String
    Private _Telefone As String
    Private _Telefone2 As String
    Private _Celular As String
    Private _Celular2 As String
    Private _WhatsApp As String
    Private _Situacao As String
    Private _Tipo As String
    Private _RecebeEmailCobranca As String
    Private objAcessoDados As UCLAcessoDados

    Public Property Matricula As String

    Public Property Preferencial() As String
        Get
            Return _Preferencial
        End Get
        Set(ByVal value As String)
            _Preferencial = value
        End Set
    End Property

    Public Property Ativo() As String
        Get
            Return _Ativo
        End Get
        Set(ByVal value As String)
            _Ativo = value
        End Set
    End Property

    Public Property CPF() As String
        Get
            Return _CPF
        End Get
        Set(ByVal value As String)
            _CPF = value
        End Set
    End Property

    Public Property RG() As String
        Get
            Return _RG
        End Get
        Set(ByVal value As String)
            _RG = value
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

    Public Property Telefone2() As String
        Get
            Return _Telefone2
        End Get
        Set(ByVal value As String)
            _Telefone2 = value
        End Set
    End Property

    Public Property Celular() As String
        Get
            Return _Celular
        End Get
        Set(ByVal value As String)
            _Celular = value
        End Set
    End Property

    Public Property Celular2() As String
        Get
            Return _Celular2
        End Get
        Set(ByVal value As String)
            _Celular2 = value
        End Set
    End Property

    Public Property WhatsApp() As String
        Get
            Return _WhatsApp
        End Get
        Set(ByVal value As String)
            _WhatsApp = value
        End Set
    End Property

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
        End Set
    End Property

    Public Property CNPJ() As String
        Get
            Return _CNPJ
        End Get
        Set(ByVal value As String)
            _CNPJ = value
        End Set
    End Property

    Public Property NumeroPontoAtendimento() As String
        Get
            Return _NumeroPontoAtendimento
        End Get
        Set(ByVal value As String)
            _NumeroPontoAtendimento = value
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

    Public Property Titulo() As String
        Get
            Return _Titulo
        End Get
        Set(ByVal value As String)
            _Titulo = value
        End Set
    End Property

    Public Property Situacao() As String
        Get
            Return _Situacao
        End Get
        Set(ByVal value As String)
            _Situacao = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Public Property RecebeEmailCobranca() As String
        Get
            Return _RecebeEmailCobranca
        End Get
        Set(ByVal value As String)
            _RecebeEmailCobranca = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Sub Alterar()
        Dim StrSql As String = ""

        Try
            StrSql += " update contatos "
            StrSql += "    set nome         = '" + Nome + "', "
            StrSql += "        titulo       = '" + Titulo + "', "
            StrSql += "        preferencial = '" + Preferencial + "', "
            StrSql += "        ativo        = '" + Ativo + "', "
            StrSql += "        cpf          = '" + CPF + "', "
            StrSql += "        cnpj         = " + IIf(String.IsNullOrEmpty(CNPJ), "null", "'" + CNPJ + "'") + ", "
            StrSql += "        numero_ponto_atendimento = " + IIf(String.IsNullOrEmpty(NumeroPontoAtendimento), "null", "'" + NumeroPontoAtendimento + "'") + ", "
            StrSql += "        rg           = '" + RG + "', "
            StrSql += "        telefone     = '" + Telefone + "', "
            StrSql += "        telefone2    = '" + Telefone2 + "', "
            StrSql += "        celular      = '" + Celular + "', "
            StrSql += "        celular2     = '" + Celular2 + "', "
            StrSql += "        whattsapp    = '" + WhatsApp + "', "
            StrSql += "        email        = '" + Email + "', "
            StrSql += "        recebe_email_cobranca        = '" + RecebeEmailCobranca + "', "
            StrSql += "        matricula    = '" + Matricula + "', "
            StrSql += "        situacao     = " + IIf(String.IsNullOrEmpty(Situacao), "1", Situacao) + ", "
            StrSql += "        tipo         = " + IIf(String.IsNullOrEmpty(Tipo), "null", Tipo)
            StrSql += "  where cod_emitente = " + CodEmitente
            StrSql += "    and cod_contato  = " + Codigo
            objAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Incluir()
        Dim StrSql As String = ""

        Try
            StrSql += " insert into contatos "
            StrSql += "       (nome         ,"
            StrSql += "        titulo       ,"
            StrSql += "        preferencial ,"
            StrSql += "        ativo        ,"
            StrSql += "        cpf          ,"
            StrSql += "        cnpj         ,"
            StrSql += "        numero_ponto_atendimento, "
            StrSql += "        rg           ,"
            StrSql += "        telefone     ,"
            StrSql += "        telefone2    ,"
            StrSql += "        celular      ,"
            StrSql += "        celular2     ,"
            StrSql += "        whattsapp    ,"
            StrSql += "        email        ,"
            StrSql += "        cod_emitente ,"
            StrSql += "        matricula    ,"
            StrSql += "        situacao     ,"
            StrSql += "        tipo         ,"
            StrSql += "        recebe_email_cobranca, "
            StrSql += "        cod_contato  )"
            StrSql += " values('" + Nome + "', "
            StrSql += "        '" + Titulo + "', "
            StrSql += "        '" + Preferencial + "', "
            StrSql += "        '" + Ativo + "', "
            StrSql += "        '" + CPF + "', "
            StrSql += IIf(String.IsNullOrEmpty(CNPJ), "null", "'" + CNPJ + "'") + ", "
            StrSql += IIf(String.IsNullOrEmpty(NumeroPontoAtendimento), "null", "'" + NumeroPontoAtendimento + "'") + ", "
            StrSql += "        '" + RG + "', "
            StrSql += "        '" + Telefone + "', "
            StrSql += "        '" + Telefone2 + "', "
            StrSql += "        '" + Celular + "', "
            StrSql += "        '" + Celular2 + "', "
            StrSql += "        '" + WhatsApp + "', "
            StrSql += "        '" + Email + "',"
            StrSql += "        " + CodEmitente + ", "
            StrSql += "        '" + Matricula + "', "
            StrSql += IIf(String.IsNullOrEmpty(Situacao), "1", Situacao) + ", "
            StrSql += IIf(String.IsNullOrEmpty(Tipo), "null", Tipo) + ", "
            StrSql += IIf(String.IsNullOrEmpty(RecebeEmailCobranca), "'N'", "'" + RecebeEmailCobranca + "'") + ", "
            StrSql += "        " + Codigo + ") "
            objAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select isnull(nome,'') nome, isnull(titulo,'') titulo, isnull(preferencial,'N') preferencial, isnull(cnpj,'') cnpj, isnull(numero_ponto_atendimento,'') numero_ponto_atendimento, "
        StrSql += "        isnull(ativo,'S') ativo, isnull(cpf,'') cpf, isnull(rg,'') rg, isnull(telefone,'') telefone, isnull(matricula,'') matricula, situacao, tipo,"
        StrSql += "        isnull(telefone2,'') telefone2, isnull(celular,'') celular, isnull(celular2,'') celular2, isnull(whattsapp,'') whattsapp, isnull(email,'') email, isnull(recebe_email_cobranca,'N') recebe_email_cobranca"
        StrSql += "   from contatos"
        StrSql += "  where cod_emitente   = " + CodEmitente
        StrSql += "    and cod_contato    = " + Codigo
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Nome = dt.Rows.Item(0).Item("nome").ToString
            Titulo = dt.Rows.Item(0).Item("titulo").ToString
            Preferencial = dt.Rows.Item(0).Item("preferencial").ToString
            CNPJ = dt.Rows.Item(0).Item("cnpj").ToString
            NumeroPontoAtendimento = dt.Rows.Item(0).Item("numero_ponto_atendimento").ToString
            Ativo = dt.Rows.Item(0).Item("ativo").ToString
            CPF = dt.Rows.Item(0).Item("cpf").ToString
            RG = dt.Rows.Item(0).Item("rg").ToString
            Telefone = dt.Rows.Item(0).Item("telefone").ToString
            Telefone2 = dt.Rows.Item(0).Item("telefone2").ToString
            Celular = dt.Rows.Item(0).Item("celular").ToString
            Celular2 = dt.Rows.Item(0).Item("celular2").ToString
            WhatsApp = dt.Rows.Item(0).Item("whattsapp").ToString
            Email = dt.Rows.Item(0).Item("email").ToString
            Matricula = dt.Rows.Item(0).Item("matricula").ToString
            Situacao = dt.Rows.Item(0).Item("situacao").ToString
            Tipo = dt.Rows.Item(0).Item("tipo").ToString
            RecebeEmailCobranca = dt.Rows.Item(0).Item("recebe_email_cobranca").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_contato, nome"
        strSql += "   from contatos"
        strSql += "  where cod_emitente = " + IIf(String.IsNullOrEmpty(CodEmitente), "0", CodEmitente)
        If Not String.IsNullOrEmpty(NumeroPontoAtendimento) Then
            strSql += " and numero_ponto_atendimento  = '" + NumeroPontoAtendimento + "'"
        End If
        strSql += " order by nome "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_contato") = CodRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "cod_contato"
        DDL.DataBind()
    End Sub

    Public Sub FillDropDownTipo(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select tipo cod, descricao"
        strSql += "   from tipo_contato "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod"
        DDL.DataBind()
    End Sub

    Public Function GetCodEmitentePeloEmail(ByVal pEmail As String) As String
        Try
            Dim strSql As String = "select cod_emitente from contatos where email like '%" + pEmail + "%'"
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count = 0 Then
                Return -1
            Else
                Return dt.Rows.Item(0).Item("cod_emitente").ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCodContatoPreferencial() As Long
        Try
            CodEmitente = IIf(String.IsNullOrEmpty(CodEmitente), "0", CodEmitente)
            Dim strSql As String = "select cod_contato from contatos where cod_emitente = " + CodEmitente + " and preferencial = 'S'"
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count = 0 Then
                Return -1
            Else
                Return dt.Rows.Item(0).Item("cod_contato").ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_contato),0) + 1 max from contatos where cod_emitente = " + CodEmitente
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function
End Class
