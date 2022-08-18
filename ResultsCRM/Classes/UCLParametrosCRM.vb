Public Class UCLParametrosCRM
    Private _Empresa As String
    Private _UsuarioPadrao As String
    Private _CodCanalVendasPadrao As String
    Private _CodEtapaPadrao As String
    Private _CodFontePadrao As String
    Private _CodAcaoPadrao As String
    Private _CodFunil As String
    Private _CodEtapa As String
    Private _TipoPainelCliente As String
    Private _ItensNegociacaoFormatoPlanilha As String
    Private _NrEtapasPipeline As String
    Private _BloquearCadastroEmitenteRepresentante As String
    Private objAcessoDados As UCLAcessoDados
    Public Property BloquearCadastroEmitenteRepresentante As String
        Get
            Return _BloquearCadastroEmitenteRepresentante
        End Get
        Set(value As String)
            _BloquearCadastroEmitenteRepresentante = value
        End Set
    End Property

    Public Property NrEtapasPipeline As String
        Get
            Return _NrEtapasPipeline
        End Get
        Set(value As String)
            _NrEtapasPipeline = value
        End Set
    End Property

    Public Property ItensNegociacaoFormatoPlanilha
        Get
            Return _ItensNegociacaoFormatoPlanilha
        End Get
        Set(value)
            _ItensNegociacaoFormatoPlanilha = value
        End Set
    End Property

    Public Property TipoPainelCliente As String
        Get
            Return _TipoPainelCliente
        End Get
        Set(value As String)
            _TipoPainelCliente = value
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

    Public Property UsuarioPadrao() As String
        Get
            Return _UsuarioPadrao
        End Get
        Set(ByVal value As String)
            _UsuarioPadrao = value
        End Set
    End Property

    Public Property CodCanalVendasPadrao() As String
        Get
            Return _CodCanalVendasPadrao
        End Get
        Set(ByVal value As String)
            _CodCanalVendasPadrao = value
        End Set
    End Property

    Public Property CodEtapaPadrao() As String
        Get
            Return _CodEtapaPadrao
        End Get
        Set(ByVal value As String)
            _CodEtapaPadrao = value
        End Set
    End Property

    Public Property CodFontePadrao() As String
        Get
            Return _CodFontePadrao
        End Get
        Set(ByVal value As String)
            _CodFontePadrao = value
        End Set
    End Property

    Public Property CodAcaoPadrao() As String
        Get
            Return _CodAcaoPadrao
        End Get
        Set(ByVal value As String)
            _CodAcaoPadrao = value
        End Set
    End Property

    Public Property CodFunil() As String
        Get
            Return _CodFunil
        End Get
        Set(ByVal value As String)
            _CodFunil = value
        End Set
    End Property

    Public Property CodEtapa() As String
        Get
            Return _CodEtapa
        End Get
        Set(ByVal value As String)
            _CodEtapa = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select usuario_padrao, cod_canal_venda_padrao, cod_etapa_padrao, cod_fonte_padrao, cod_acao_padrao, tipo_painel_cliente, itens_negociacao_formato_planilha, isnull(nr_etapas_pipeline,7) nr_etapas_pipeline, isnull(bloquear_cadastro_emitente_representante,'N') bloquear_cadastro_emitente_representante, cod_funil, cod_etapa "
        StrSql += "   from parametros_crm "
        StrSql += "  where empresa = " + Empresa
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            UsuarioPadrao = dt.Rows.Item(0).Item("usuario_padrao").ToString
            CodCanalVendasPadrao = dt.Rows.Item(0).Item("cod_canal_venda_padrao").ToString
            CodEtapaPadrao = dt.Rows.Item(0).Item("cod_etapa_padrao").ToString
            CodFontePadrao = dt.Rows.Item(0).Item("cod_fonte_padrao").ToString
            CodAcaoPadrao = dt.Rows.Item(0).Item("cod_acao_padrao").ToString
            CodFunil = dt.Rows.Item(0).Item("cod_funil").ToString
            CodEtapa = dt.Rows.Item(0).Item("cod_etapa").ToString
            TipoPainelCliente = dt.Rows.Item(0).Item("tipo_painel_cliente").ToString
            ItensNegociacaoFormatoPlanilha = dt.Rows.Item(0).Item("itens_negociacao_formato_planilha").ToString
            NrEtapasPipeline = dt.Rows.Item(0).Item("nr_etapas_pipeline").ToString
            BloquearCadastroEmitenteRepresentante = dt.Rows.Item(0).Item("bloquear_cadastro_emitente_representante").ToString
            Return True
        Else
            Return False
        End If

    End Function

End Class
