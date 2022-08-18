Public Class UCLPontoAtendimento

    Private _CodEmitente As String
    Private _Descricao As String
    Private _CNPJ As String
    Private _Ativo As String
    Private _Preferencial As String
    Private _Logradouro As String
    Private _Numero As String
    Private _CEP As String
    Private _Email As String
    Private _Fone1 As String
    Private _Fone2 As String
    Private _Fax As String
    Private _CodPais As String
    Private _CodEstado As String
    Private _CodCidade As String
    Private _Bairro As String
    Private _IE As String
    Private _IM As String
    Private _CodTipoPontoAtendimento As String
    Private _NumeroPontoAtendimento As String
    Private _NumeroUniorg As String
    Private _Observacao As String
    Private objAcessoDados As UCLAcessoDados

    Public Property HorarioFuncionamentoInicio As String
    Public Property HorarioFuncionamentoFim As String
    Public Property ExigeIntegracao As String

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return _Descricao
        End Get
        Set(ByVal value As String)
            _Descricao = value
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

    Public Property Ativo() As String
        Get
            If String.IsNullOrEmpty(_Ativo) Then
                _Ativo = "S"
            End If
            Return _Ativo
        End Get
        Set(ByVal value As String)
            _Ativo = value
        End Set
    End Property

    Public Property Preferencial() As String
        Get
            If String.IsNullOrEmpty(_Preferencial) Then
                _Preferencial = "N"
            End If
            Return _Preferencial
        End Get
        Set(ByVal value As String)
            _Preferencial = value
        End Set
    End Property

    Public Property Logradouro() As String
        Get
            Return _Logradouro
        End Get
        Set(ByVal value As String)
            _Logradouro = value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property

    Public Property CEP() As String
        Get
            Return _CEP
        End Get
        Set(ByVal value As String)
            _CEP = value
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

    Public Property Fone1() As String
        Get
            Return _Fone1
        End Get
        Set(ByVal value As String)
            _Fone1 = value
        End Set
    End Property

    Public Property Fone2() As String
        Get
            Return _Fone2
        End Get
        Set(ByVal value As String)
            _Fone2 = value
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal value As String)
            _Fax = value
        End Set
    End Property

    Public Property CodPais() As String
        Get
            Return _CodPais
        End Get
        Set(ByVal value As String)
            _CodPais = value
        End Set
    End Property

    Public Property CodEstado() As String
        Get
            Return _CodEstado
        End Get
        Set(ByVal value As String)
            _CodEstado = value
        End Set
    End Property

    Public Property CodCidade() As String
        Get
            Return _CodCidade
        End Get
        Set(ByVal value As String)
            _CodCidade = value
        End Set
    End Property

    Public Property Bairro() As String
        Get
            Return _Bairro
        End Get
        Set(ByVal value As String)
            _Bairro = value
        End Set
    End Property

    Public Property IE() As String
        Get
            Return _IE
        End Get
        Set(ByVal value As String)
            _IE = value
        End Set
    End Property

    Public Property IM() As String
        Get
            Return _IM
        End Get
        Set(ByVal value As String)
            _IM = value
        End Set
    End Property

    Public Property Observacao() As String
        Get
            Return _Observacao
        End Get
        Set(ByVal value As String)
            _Observacao = value
        End Set
    End Property

    Public Property CodTipoPontoAtendimento() As String
        Get
            Return _CodTipoPontoAtendimento
        End Get
        Set(ByVal value As String)
            _CodTipoPontoAtendimento = value
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

    Public Property NumeroUniorg() As String
        Get
            Return _NumeroUniorg
        End Get
        Set(ByVal value As String)
            _NumeroUniorg = value
        End Set
    End Property

    Public Sub New(ByVal StrConn As String)
        objAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""

        StrSql += " select isnull(descricao,'') descricao, isnull(ativo,'S') ativo, isnull(preferencial,'N') preferencial, isnull(endereco,'') endereco, isnull(observacao,'') observacao, isnull(cnpj,'') cnpj, "
        StrSql += "        isnull(numero,0) numero, isnull(cep,'') cep, isnull(telefone1,'') telefone1, isnull(telefone2,'') telefone2, isnull(fax,'') fax, cod_pais, cod_estado, cod_cidade, isnull(bairro,'') bairro, isnull(insc_estadual,'') insc_estadual, isnull(insc_municipal,'') insc_municipal, isnull(email,'') email, "
        StrSql += "        isnull(cod_tipo_ponto_atendimento,0) cod_tipo_ponto_atendimento, isnull(numero_ponto_atendimento,'') numero_ponto_atendimento, isnull(numero_uniorg,'') numero_uniorg, "
        StrSql += "        isnull(horario_funcionamento_inicio,'') horario_funcionamento_inicio, isnull(horario_funcionamento_fim,'') horario_funcionamento_fim, isnull(exige_integracao,'N') exige_integracao"
        StrSql += "   from ponto_atendimento "
        StrSql += "  where cod_emitente = " + CodEmitente
        StrSql += "    and numero_ponto_atendimento = '" + NumeroPontoAtendimento + "'"

        Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            HorarioFuncionamentoInicio = dt.Rows.Item(0).Item("horario_funcionamento_inicio").ToString
            HorarioFuncionamentoFim = dt.Rows.Item(0).Item("horario_funcionamento_fim").ToString
            ExigeIntegracao = dt.Rows.Item(0).Item("exige_integracao").ToString
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Ativo = dt.Rows.Item(0).Item("ativo").ToString
            Preferencial = dt.Rows.Item(0).Item("preferencial").ToString
            Logradouro = dt.Rows.Item(0).Item("endereco").ToString
            Numero = CDbl(dt.Rows.Item(0).Item("numero")).ToString("F0")
            CEP = dt.Rows.Item(0).Item("cep").ToString
            Fone1 = dt.Rows.Item(0).Item("telefone1").ToString
            Fone2 = dt.Rows.Item(0).Item("telefone2").ToString
            Fax = dt.Rows.Item(0).Item("fax").ToString
            CodPais = dt.Rows.Item(0).Item("cod_pais").ToString
            CodEstado = dt.Rows.Item(0).Item("cod_estado").ToString
            CodCidade = dt.Rows.Item(0).Item("cod_cidade").ToString
            Bairro = dt.Rows.Item(0).Item("bairro").ToString
            IE = dt.Rows.Item(0).Item("insc_estadual").ToString
            IM = dt.Rows.Item(0).Item("insc_municipal").ToString
            Email = dt.Rows.Item(0).Item("email").ToString
            CodTipoPontoAtendimento = dt.Rows.Item(0).Item("cod_tipo_ponto_atendimento").ToString
            NumeroPontoAtendimento = dt.Rows.Item(0).Item("numero_ponto_atendimento").ToString
            NumeroUniorg = dt.Rows.Item(0).Item("numero_uniorg").ToString
            Observacao = dt.Rows.Item(0).Item("observacao").ToString
            CNPJ = dt.Rows.Item(0).Item("cnpj").ToString
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into ponto_atendimento ("
            strSql += "    cod_emitente, numero_ponto_atendimento, cnpj, descricao, ativo,  "
            strSql += "    preferencial, endereco, numero, cep, telefone1, telefone2, fax, "
            strSql += "    cod_pais, cod_estado, cod_cidade, bairro, insc_estadual, insc_municipal, email, "
            strSql += "    cod_tipo_ponto_atendimento, numero_uniorg, observacao, horario_funcionamento_inicio, horario_funcionamento_fim, exige_integracao ) "
            strSql += " values(" + CodEmitente + ", '" + NumeroPontoAtendimento + "'," + IIf(String.IsNullOrEmpty(CNPJ), "null", "'" + CNPJ + "'") + ", '" + Descricao + "', '" + Ativo + "', "
            strSql += "    '" + Preferencial + "', '" + Logradouro + "', '" + Numero + "', '" + CEP + "', '" + Fone1 + "', '" + Fone2 + "', '" + Fax + "', "
            strSql += "    " + CodPais + ", " + CodEstado + ", " + CodCidade + ", '" + Bairro + "', '" + IE + "', '" + IM + "','" + Email + "', "
            strSql += "    " + IIf(String.IsNullOrEmpty(CodTipoPontoAtendimento), "null", CodTipoPontoAtendimento) + ", "
            strSql += "    " + IIf(String.IsNullOrEmpty(NumeroUniorg), "null", "'" + NumeroUniorg + "'") + ", '" + Observacao + "','" + HorarioFuncionamentoInicio + "','" + HorarioFuncionamentoFim + "','" + ExigeIntegracao + "'); "
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update ponto_atendimento "
            strSql += "    set descricao      = '" + Descricao + "', "
            strSql += "        ativo          = '" + Ativo + "', "
            strSql += "        preferencial   = '" + Preferencial + "', "
            strSql += "        endereco       = '" + Logradouro + "', "
            strSql += "        numero         = '" + Numero + "', "
            strSql += "        cep            = '" + CEP + "', "
            strSql += "        email          = '" + Email + "', "
            strSql += "        telefone1      = '" + Fone1 + "', "
            strSql += "        telefone2      = '" + Fone2 + "', "
            strSql += "        fax            = '" + Fax + "', "
            strSql += "        cod_pais       = " + CodPais + ", "
            strSql += "        cod_estado     = " + CodEstado + ", "
            strSql += "        cod_cidade     = " + CodCidade + ", "
            strSql += "        bairro         = '" + Bairro + "', "
            strSql += "        insc_estadual  = '" + IE + "', "
            strSql += "        insc_municipal = '" + IM + "', "
            strSql += "        cnpj           = " + IIf(String.IsNullOrEmpty(CNPJ), "null", "'" + CNPJ + "'") + ","
            strSql += "        observacao     = '" + Observacao + "',"
            strSql += "        horario_funcionamento_inicio = '" + HorarioFuncionamentoInicio + "', "
            strSql += "        horario_funcionamento_fim    = '" + HorarioFuncionamentoFim + "', "
            strSql += "        exige_integracao             = '" + ExigeIntegracao + "',"
            strSql += "        cod_tipo_ponto_atendimento = " + IIf(String.IsNullOrEmpty(CodTipoPontoAtendimento), "null", CodTipoPontoAtendimento) + ", "
            strSql += "        numero_uniorg              = " + IIf(String.IsNullOrEmpty(NumeroUniorg), "null", "'" + NumeroUniorg + "'")
            strSql += "  where cod_emitente   = " + CodEmitente
            strSql += "    and numero_ponto_atendimento   = '" + NumeroPontoAtendimento + "'"
            objAcessoDados.ExecutarSql(strSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub Excluir()
        Try
            Dim StrSql As String
            StrSql = " delete from ponto_atendimento "
            StrSql += "  where cod_emitente             = " + CodEmitente
            StrSql += "    and numero_ponto_atendimento = '" + NumeroPontoAtendimento + "'"
            objAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub AlterarNumeroPontoAtendimento(pCodEmitente As String, pNumeroPontoAtendimento As String, pNumeroPontoAtendimentoNovo As String, pNomeUsuario As String, pExiste As Boolean)
        Try
            Dim StrSql As String = ""

            If pExiste Then
                Throw New Exception("Ponto de Atendimento Nº " + pNumeroPontoAtendimentoNovo + " já existe. Operação não permitida.")
            End If

            StrSql += "  insert into ponto_atendimento_log(seq, cod_emitente, numero_ponto_atendimento, numero_ponto_atendimento_novo, cod_usuario, data_hora) "
            StrSql += "      values ( isnull((select max(seq) from ponto_atendimento_log),0)+1, " + pCodEmitente + ", '" + pNumeroPontoAtendimento + "', '" + pNumeroPontoAtendimentoNovo + "', f_busca_cod_usuario('" + pNomeUsuario + "'), now() ); "

            StrSql += "  update ponto_atendimento "
            StrSql += "     set numero_ponto_atendimento = '" + pNumeroPontoAtendimentoNovo + "'"
            StrSql += "   where cod_emitente             = " + pCodEmitente
            StrSql += "     and numero_ponto_atendimento = '" + pNumeroPontoAtendimento + "'"

            objAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
