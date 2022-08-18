Public Class UCLClienteFinanceiro

    Private ObjAcessoDados As UCLAcessoDados
    Private _CodEmitente As String
    Private _Empresa As String
    Private _CodRepresentante As String
    Private _CodCondPagto As String
    Private _CodFormaPagto As String
    Private _CodNaturOper As String
    Private _TipoFrete As String
    Private _CodCanalVenda As String
    Private _CodGrupo As String
    Private _CodCarteira As String
    Private _CodPortador As String
    Private _CodBanco As String
    Private _CodDistribuidor As String

    Public Property CodTransportador As String
    Public Property CodEmitenteAtendimentoPadrao As String
    Public Property NumeroPontoAtendimentoPadrao As String
    Public Property CodCFPS As String

    Public Sub New()
        ObjAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Property CodParceiro As String
    Public Property ValorRepasseParceiro As String
    Public Property CodProvedorTef As String
    Public Property CodAdquirenteTef As String
    Public Property CodNaturOperServico As String
    Public Property ValorRepasseParceiroAdesao As String

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property CodRepresentante() As String
        Get
            Return _CodRepresentante
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodRepresentante = value
        End Set
    End Property

    Public Property CodCondPagto() As String
        Get
            Return _CodCondPagto
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodCondPagto = value
        End Set
    End Property

    Public Property CodFormaPagto() As String
        Get
            Return _CodFormaPagto
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodFormaPagto = value
        End Set
    End Property

    Public Property CodNaturOper() As String
        Get
            Return _CodNaturOper
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodNaturOper = value
        End Set
    End Property

    Public Property TipoFrete() As String
        Get
            Return _TipoFrete
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "1"
            End If
            _TipoFrete = value
        End Set
    End Property

    Public Property CodCanalVenda() As String
        Get
            Return _CodCanalVenda
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodCanalVenda = value
        End Set
    End Property

    Public Property CodGrupo() As String
        Get
            Return _CodGrupo
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodGrupo = value
        End Set
    End Property

    Public Property CodCarteira() As String
        Get
            Return _CodCarteira
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodCarteira = value
        End Set
    End Property

    Public Property CodPortador() As String
        Get
            Return _CodPortador
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodPortador = value
        End Set
    End Property

    Public Property CodBanco() As String
        Get
            Return _CodBanco
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                value = "0"
            End If
            _CodBanco = value
        End Set
    End Property

    Public Property CodDistribuidor() As String
        Get
            Return _CodDistribuidor
        End Get
        Set(ByVal value As String)
            _CodDistribuidor = value
        End Set
    End Property

    Public Sub Gravar()
        Try
            If Existe() Then
                Alterar()
            Else
                Incluir()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Incluir()
        Dim StrSql As String = ""

        Try
            StrSql += " insert into cliente_financeiro(cod_emitente, empresa, cod_distribuidor,cod_representante, cod_cond_pagto, cod_forma_pagamento, cod_natur_oper, cod_natur_oper_servico, tipo_frete, cod_canal_venda, cod_grupo, cod_carteira, cod_portador, cod_banco, perc_juro_mensal_atraso, perc_multa_atraso, valor_perc_desc_pag_dia, cod_parceiro, valor_repasse_parceiro, valor_repasse_parceiro_adesao, cod_provedor_tef, cod_adquirente_principal_tef, cod_emitente_atendimento_padrao, numero_ponto_atendimento_padrao ) "
            StrSql += "   values ( " + CodEmitente + ", " + Empresa + ", " + TestaNuloZero(CodDistribuidor, "null") + ", " + TestaNuloZero(CodRepresentante, "null") + ", " + TestaNuloZero(CodCondPagto, "null") + ", " + TestaNuloZero(CodFormaPagto, "null") + ", " + If(String.IsNullOrEmpty(CodNaturOper) OrElse Trim(CodNaturOper) = "0", "null", "'" + CodNaturOper + "'") + ", " + If(String.IsNullOrEmpty(CodNaturOperServico) OrElse Trim(CodNaturOperServico) = "0", "null", "'" + CodNaturOperServico + "'") + ", '" + TipoFrete + "', " + TestaNuloZero(CodCanalVenda, "null") + ", " + TestaNuloZero(CodGrupo, "null") + ", " + TestaNuloZero(CodCarteira, "null") + ", " + TestaNuloZero(CodPortador, "null") + ", " + TestaNuloZero(CodBanco, "null") + ",0 ,0, 0, " + TestaNuloZero(CodParceiro, "null") + ", " + TestaNuloZero(ValorRepasseParceiro.Replace(",", "."), "null") + ", " + TestaNuloZero(ValorRepasseParceiroAdesao.Replace(",", "."), "null") + ", " + TestaNuloZero(CodProvedorTef, "null") + ", " + TestaNuloZero(CodAdquirenteTef, "null") + "," + TestaNuloZero(CodEmitenteAtendimentoPadrao, "null") + ",'" + NumeroPontoAtendimentoPadrao + "')"
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function TestaNuloZero(ByVal Campo As String, ByVal ValorAssumir As String)
        If String.IsNullOrEmpty(Campo) OrElse Campo.Trim = "0" Then
            Return ValorAssumir
        Else
            Return Trim(Campo)
        End If
    End Function

    Public Sub Alterar()
        Dim StrSql As String = ""

        Try
            StrSql += " update cliente_financeiro set "
            StrSql += "        cod_representante             = " + TestaNuloZero(CodRepresentante, "null") + ", "
            StrSql += "        cod_cond_pagto                = " + TestaNuloZero(CodCondPagto, "null") + ", "
            StrSql += "        cod_forma_pagamento           = " + TestaNuloZero(CodFormaPagto, "null") + ", "
            StrSql += "        cod_natur_oper                = " + If(String.IsNullOrEmpty(CodNaturOper) OrElse Trim(CodNaturOper) = "0", "null", "'" + CodNaturOper + "'") + ", "
            StrSql += "        cod_natur_oper_servico        = " + If(String.IsNullOrEmpty(CodNaturOperServico) OrElse Trim(CodNaturOperServico) = "0", "null", "'" + CodNaturOperServico + "'") + ", "
            StrSql += "        tipo_frete                    = '" + TipoFrete + "', "
            StrSql += "        cod_canal_venda               = " + TestaNuloZero(CodCanalVenda, "null") + ", "
            StrSql += "        cod_grupo                     = " + TestaNuloZero(CodGrupo, "null") + ", "
            StrSql += "        cod_carteira                  = " + TestaNuloZero(CodCarteira, "null") + ", "
            StrSql += "        cod_portador                  = " + TestaNuloZero(CodPortador, "null") + ", "
            StrSql += "        cod_banco                     = " + TestaNuloZero(CodBanco, "null") + ", "
            StrSql += "        cod_parceiro                  = " + TestaNuloZero(CodParceiro, "null") + ", "
            StrSql += "        cod_distribuidor              = " + TestaNuloZero(CodDistribuidor, "null") + ", "
            StrSql += "        valor_repasse_parceiro        = " + TestaNuloZero(ValorRepasseParceiro.Replace(",", "."), "null") + ", "
            StrSql += "        valor_repasse_parceiro_adesao = " + TestaNuloZero(ValorRepasseParceiroAdesao.Replace(",", "."), "null") + ", "
            StrSql += "        cod_provedor_tef              = " + TestaNuloZero(CodProvedorTef, "null") + ", "
            StrSql += "        cod_adquirente_principal_tef  = " + TestaNuloZero(CodAdquirenteTef, "null") + ", "
            StrSql += "        cod_emitente_atendimento_padrao = " + TestaNuloZero(CodEmitenteAtendimentoPadrao, "null") + ", "
            StrSql += "        numero_ponto_atendimento_padrao = '" + NumeroPontoAtendimentoPadrao + "'"
            StrSql += "  where cod_emitente = " + CodEmitente
            StrSql += "    and empresa      = " + Empresa

            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Existe() As Boolean
        Dim strSql As String
        Dim dt As DataTable

        Try
            strSql = "select 1 from cliente_financeiro where cod_emitente = " + CodEmitente + " and empresa = " + Empresa
            dt = ObjAcessoDados.BuscarDados(strSql)
            Return dt.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Buscar() As Boolean
        Dim strSql As String
        Dim dt As DataTable

        Try
            strSql = " select cod_emitente, empresa, cod_representante, cod_distribuidor, cod_cfps, cod_cond_pagto, cod_forma_pagamento, cod_natur_oper, cod_natur_oper_servico, tipo_frete, cod_canal_venda, cod_grupo, cod_carteira, cod_portador, cod_banco, cod_parceiro, convert(numeric(14,2),valor_repasse_parceiro) valor_repasse_parceiro, convert(numeric(14,2),valor_repasse_parceiro_adesao) valor_repasse_parceiro_adesao, cod_provedor_tef, cod_adquirente_principal_tef, cod_emitente_atendimento_padrao, numero_ponto_atendimento_padrao, cod_transportador from cliente_financeiro where cod_emitente = " + CodEmitente + " and empresa = " + Empresa
            dt = ObjAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                CodCFPS = dt.Rows.Item(0).Item("cod_cfps").ToString
                CodRepresentante = dt.Rows.Item(0).Item("cod_representante").ToString
                CodCondPagto = dt.Rows.Item(0).Item("cod_cond_pagto").ToString
                CodFormaPagto = dt.Rows.Item(0).Item("cod_forma_pagamento").ToString
                CodNaturOper = dt.Rows.Item(0).Item("cod_natur_oper").ToString
                CodNaturOperServico = dt.Rows.Item(0).Item("cod_natur_oper_servico").ToString
                TipoFrete = dt.Rows.Item(0).Item("tipo_frete").ToString
                CodCanalVenda = dt.Rows.Item(0).Item("cod_canal_venda").ToString
                CodGrupo = dt.Rows.Item(0).Item("cod_grupo").ToString
                CodCarteira = dt.Rows.Item(0).Item("cod_carteira").ToString
                CodPortador = dt.Rows.Item(0).Item("cod_Portador").ToString
                CodBanco = dt.Rows.Item(0).Item("cod_banco").ToString
                CodProvedorTef = dt.Rows.Item(0).Item("cod_provedor_tef").ToString
                CodParceiro = dt.Rows.Item(0).Item("cod_parceiro").ToString
                CodDistribuidor = dt.Rows.Item(0).Item("cod_distribuidor").ToString
                ValorRepasseParceiro = dt.Rows.Item(0).Item("valor_repasse_parceiro").ToString
                ValorRepasseParceiroAdesao = dt.Rows.Item(0).Item("valor_repasse_parceiro_adesao").ToString
                CodAdquirenteTef = dt.Rows.Item(0).Item("cod_adquirente_principal_tef").ToString
                CodEmitenteAtendimentoPadrao = dt.Rows.Item(0).Item("cod_emitente_atendimento_padrao").ToString
                NumeroPontoAtendimentoPadrao = dt.Rows.Item(0).Item("numero_ponto_atendimento_padrao").ToString
                CodTransportador = dt.Rows.Item(0).Item("cod_transportador").ToString
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
