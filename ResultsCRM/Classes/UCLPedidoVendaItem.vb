Public Class UCLPedidoVendaItem
    Inherits System.Web.UI.Page

    Private ObjAcessoDados As UCLAcessoDados

    Private _empresa As String
    Private _estabelecimento As String
    Private _codPedidoVenda As String
    Private _seqItem As String
    Private _codItem As String
    Private _referencia As String
    Private _lote As String
    Private _codUsuario As String
    Private _qtdUd As String
    Private _qtdPedida As String
    Private _qtdAlocada As String
    Private _qtdEntregue As String
    Private _precoUnitarioOriginal As String
    Private _precoUnitario As String
    Private _precoUnitarioTabela As String
    Private _precoUnitarioUdOriginal As String
    Private _precoUnitarioUd As String
    Private _precoUnitarioProdutor As String
    Private _precoUnitarioProdutorDesconto As String
    Private _precoUnitarioProdutorFaturar As String
    Private _valorMercadoria As String
    Private _valorMercadoriaProdutor As String
    Private _aliquotaIcms As String
    Private _valorIcms As String
    Private _aliquotaIpi As String
    Private _valorIpi As String
    Private _percDescontoUnitario As String
    Private _percDescontoUnitario2 As String
    Private _percDescontoUnitario3 As String
    Private _percDescontoUnitario4 As String
    Private _percDescontoUnitario5 As String
    Private _percDesconto As String
    Private _valorDesconto As String
    Private _valorTotalMercadoria As String
    Private _valorTotalMercadoriaProdutor As String
    Private _valorCusto As String
    Private _impostosFederais As String
    Private _percComissao As String
    Private _valorComissao As String
    Private _margemLiquida As String
    Private _situacaoFaturamento As String
    Private _situacaoAprovacao As String
    Private _situacaoEntrega As String
    Private _servicoSolicitado As String
    Private _dataAprovaFinanc As String
    Private _dDataAprovaFinanc As Date
    Private _codNaturOper As String
    Private _codSituacaoProducao As String
    Private _narrativa As String
    Private _codNegociacaoCliente As String
    Private _largura As String
    Private _altura As String
    Private _espessura As String
    Private _dataInicioProducao As String
    Private _dDataInicioProducao As Date
    Private _aux1 As String
    Private _aux2 As String
    Private _aux3 As String
    Private _aux4 As String
    Private _aux5 As String
    Private _aux6 As String
    Private _aux7 As String
    Private _aux8 As String
    Private _aux9 As String
    Private _aux10 As String
    Private _aux11 As String
    Private _aux12 As String
    Private _auxCheck1 As String
    Private _auxCheck2 As String
    Private _auxCheck3 As String
    Private _auxCheck4 As String
    Private _auxCheck5 As String
    Private _auxCheck6 As String
    Private _auxCheck7 As String
    Private _auxCheck8 As String
    Private _codUnidade As String
    Private _codPlanoUN As String
    Private _codUN As String
    Private _codModalidade As String
    Private _recurso As String
    Private _baseIcmsSubstituicao As String
    Private _icmsSubstituicao As String
    Private _valorFrete As String
    Private _valorSeguro As String
    Private _valorDespesaAcessoria As String
    Private _observacao As String
    Private _custoFreteProdutor As String
    Private _custoRoyaltiesProdutor As String
    Private _codTabelaPrecoVenda As String
    Private _embarqueConferido As String
    Private _numeroSerie As String
    Private _seqSolicitacao As String
    Private _codTipoCobrancaOS As String
    Private _seqComponente As String

    Public Property CodAgenteTecnico As String
    Public Property HoraInicial As String
    Public Property HoraFinal As String
    Public Property KmInicial As String
    Public Property KmFinal As String
    Public Property LocalOrigem As String
    Public Property LocalDestino As String
    Public Property DataEntrega As String
    Public Property DDataEntrega As Date

    Public Sub New(ByVal StrConn As String)
        ObjAcessoDados = New UCLAcessoDados(StrConn)
        KmInicial = ""
        KmFinal = ""
        HoraInicial = ""
        HoraFinal = ""
    End Sub

    Public Property numeroSerie() As String
        Get
            Return _numeroSerie
        End Get
        Set(ByVal value As String)
            _numeroSerie = value
        End Set
    End Property

    Public Property seqComponente As String
        Get
            Return _seqComponente
        End Get
        Set(value As String)
            _seqComponente = value
        End Set
    End Property

    Public Property empresa() As String
        Get
            Return _empresa
        End Get
        Set(ByVal value As String)
            _empresa = value
        End Set
    End Property
    Public Property estabelecimento() As String
        Get
            Return _estabelecimento
        End Get
        Set(ByVal value As String)
            _estabelecimento = value
        End Set
    End Property
    Public Property codPedidoVenda() As String
        Get
            Return _codPedidoVenda
        End Get
        Set(ByVal value As String)
            _codPedidoVenda = value
        End Set
    End Property
    Public Property seqItem() As String
        Get
            Return _seqItem
        End Get
        Set(ByVal value As String)
            _seqItem = value
        End Set
    End Property
    Public Property codItem() As String
        Get
            Return _codItem
        End Get
        Set(ByVal value As String)
            _codItem = value
        End Set
    End Property
    Public Property ServicoSolicitado() As String
        Get
            Return _servicoSolicitado
        End Get
        Set(ByVal value As String)
            _servicoSolicitado = value
        End Set
    End Property
    Public Property referencia() As String
        Get
            Return _referencia
        End Get
        Set(ByVal value As String)
            _referencia = value
        End Set
    End Property
    Public Property lote() As String
        Get
            Return _lote
        End Get
        Set(ByVal value As String)
            _lote = value
        End Set
    End Property
    Public Property codUsuario() As String
        Get
            Return _codUsuario
        End Get
        Set(ByVal value As String)
            _codUsuario = value
        End Set
    End Property
    Public Property qtdUd() As String
        Get
            Return _qtdUd
        End Get
        Set(ByVal value As String)
            _qtdUd = value
        End Set
    End Property
    Public Property qtdPedida() As String
        Get
            Return _qtdPedida
        End Get
        Set(ByVal value As String)
            _qtdPedida = value
        End Set
    End Property
    Public Property qtdAlocada() As String
        Get
            Return _qtdAlocada
        End Get
        Set(ByVal value As String)
            _qtdAlocada = value
        End Set
    End Property
    Public Property qtdEntregue() As String
        Get
            Return _qtdEntregue
        End Get
        Set(ByVal value As String)
            _qtdEntregue = value
        End Set
    End Property
    Public Property precoUnitarioOriginal() As String
        Get
            Return _precoUnitarioOriginal
        End Get
        Set(ByVal value As String)
            _precoUnitarioOriginal = value
        End Set
    End Property
    Public Property precoUnitario() As String
        Get
            Return _precoUnitario
        End Get
        Set(ByVal value As String)
            _precoUnitario = value
        End Set
    End Property
    Public Property precoUnitarioTabela() As String
        Get
            Return _precoUnitarioTabela
        End Get
        Set(ByVal value As String)
            _precoUnitarioTabela = value
        End Set
    End Property
    Public Property precoUnitarioUdOriginal() As String
        Get
            Return _precoUnitarioUdOriginal
        End Get
        Set(ByVal value As String)
            _precoUnitarioUdOriginal = value
        End Set
    End Property
    Public Property precoUnitarioUd() As String
        Get
            Return _precoUnitarioUd
        End Get
        Set(ByVal value As String)
            _precoUnitarioUd = value
        End Set
    End Property
    Public Property precoUnitarioProdutor() As String
        Get
            Return _precoUnitarioProdutor
        End Get
        Set(ByVal value As String)
            _precoUnitarioProdutor = value
        End Set
    End Property
    Public Property precoUnitarioProdutorDesconto() As String
        Get
            Return _precoUnitarioProdutorDesconto
        End Get
        Set(ByVal value As String)
            _precoUnitarioProdutorDesconto = value
        End Set
    End Property
    Public Property precoUnitarioProdutorFaturar() As String
        Get
            Return _precoUnitarioProdutorFaturar
        End Get
        Set(ByVal value As String)
            _precoUnitarioProdutorFaturar = value
        End Set
    End Property
    Public Property valorMercadoria() As String
        Get
            Return _valorMercadoria
        End Get
        Set(ByVal value As String)
            _valorMercadoria = value
        End Set
    End Property
    Public Property valorMercadoriaProdutor() As String
        Get
            Return _valorMercadoriaProdutor
        End Get
        Set(ByVal value As String)
            _valorMercadoriaProdutor = value
        End Set
    End Property
    Public Property aliquotaIcms() As String
        Get
            Return _aliquotaIcms
        End Get
        Set(ByVal value As String)
            _aliquotaIcms = value
        End Set
    End Property
    Public Property valorIcms() As String
        Get
            Return _valorIcms
        End Get
        Set(ByVal value As String)
            _valorIcms = value
        End Set
    End Property
    Public Property aliquotaIpi() As String
        Get
            Return _aliquotaIpi
        End Get
        Set(ByVal value As String)
            _aliquotaIpi = value
        End Set
    End Property
    Public Property valorIpi() As String
        Get
            Return _valorIpi
        End Get
        Set(ByVal value As String)
            _valorIpi = value
        End Set
    End Property
    Public Property percDescontoUnitario() As String
        Get
            Return _percDescontoUnitario
        End Get
        Set(ByVal value As String)
            _percDescontoUnitario = value
        End Set
    End Property
    Public Property percDescontoUnitario2() As String
        Get
            Return _percDescontoUnitario2
        End Get
        Set(ByVal value As String)
            _percDescontoUnitario2 = value
        End Set
    End Property
    Public Property percDescontoUnitario3() As String
        Get
            Return _percDescontoUnitario3
        End Get
        Set(ByVal value As String)
            _percDescontoUnitario3 = value
        End Set
    End Property
    Public Property percDescontoUnitario4() As String
        Get
            Return _percDescontoUnitario4
        End Get
        Set(ByVal value As String)
            _percDescontoUnitario4 = value
        End Set
    End Property
    Public Property percDescontoUnitario5() As String
        Get
            Return _percDescontoUnitario5
        End Get
        Set(ByVal value As String)
            _percDescontoUnitario5 = value
        End Set
    End Property
    Public Property percDesconto() As String
        Get
            Return _percDesconto
        End Get
        Set(ByVal value As String)
            _percDesconto = value
        End Set
    End Property
    Public Property valorDesconto() As String
        Get
            Return _valorDesconto
        End Get
        Set(ByVal value As String)
            _valorDesconto = value
        End Set
    End Property
    Public Property valorTotalMercadoria() As String
        Get
            Return _valorTotalMercadoria
        End Get
        Set(ByVal value As String)
            _valorTotalMercadoria = value
        End Set
    End Property
    Public Property valorTotalMercadoriaProdutor() As String
        Get
            Return _valorTotalMercadoriaProdutor
        End Get
        Set(ByVal value As String)
            _valorTotalMercadoriaProdutor = value
        End Set
    End Property
    Public Property valorCusto() As String
        Get
            Return _valorCusto
        End Get
        Set(ByVal value As String)
            _valorCusto = value
        End Set
    End Property
    Public Property impostosFederais() As String
        Get
            Return _impostosFederais
        End Get
        Set(ByVal value As String)
            _impostosFederais = value
        End Set
    End Property
    Public Property percComissao() As String
        Get
            Return _percComissao
        End Get
        Set(ByVal value As String)
            _percComissao = value
        End Set
    End Property
    Public Property valorComissao() As String
        Get
            Return _valorComissao
        End Get
        Set(ByVal value As String)
            _valorComissao = value
        End Set
    End Property
    Public Property margemLiquida() As String
        Get
            Return _margemLiquida
        End Get
        Set(ByVal value As String)
            _margemLiquida = value
        End Set
    End Property
    Public Property situacaoFaturamento() As String
        Get
            Return _situacaoFaturamento
        End Get
        Set(ByVal value As String)
            _situacaoFaturamento = value
        End Set
    End Property
    Public Property situacaoAprovacao() As String
        Get
            Return _situacaoAprovacao
        End Get
        Set(ByVal value As String)
            _situacaoAprovacao = value
        End Set
    End Property
    Public Property situacaoEntrega() As String
        Get
            Return _situacaoEntrega
        End Get
        Set(ByVal value As String)
            _situacaoEntrega = value
        End Set
    End Property
    Public Property dataAprovaFinanc() As String
        Get
            Return _dataAprovaFinanc
        End Get
        Set(ByVal value As String)
            If value.isValidDate Then
                dDataAprovaFinanc = CDate(value)
            End If
            _dataAprovaFinanc = value
        End Set
    End Property
    Public Property dDataAprovaFinanc() As Date
        Get
            Return _dDataAprovaFinanc
        End Get
        Set(ByVal value As Date)
            _dDataAprovaFinanc = value
        End Set
    End Property
    Public Property codNaturOper() As String
        Get
            Return _codNaturOper
        End Get
        Set(ByVal value As String)
            _codNaturOper = value
        End Set
    End Property
    Public Property codSituacaoProducao() As String
        Get
            Return _codSituacaoProducao
        End Get
        Set(ByVal value As String)
            _codSituacaoProducao = value
        End Set
    End Property
    Public Property narrativa() As String
        Get
            Return _narrativa
        End Get
        Set(ByVal value As String)
            _narrativa = value
        End Set
    End Property
    Public Property codNegociacaoCliente() As String
        Get
            Return _codNegociacaoCliente
        End Get
        Set(ByVal value As String)
            _codNegociacaoCliente = value
        End Set
    End Property
    Public Property largura() As String
        Get
            Return _largura
        End Get
        Set(ByVal value As String)
            _largura = value
        End Set
    End Property
    Public Property altura() As String
        Get
            Return _altura
        End Get
        Set(ByVal value As String)
            _altura = value
        End Set
    End Property
    Public Property espessura() As String
        Get
            Return _espessura
        End Get
        Set(ByVal value As String)
            _espessura = value
        End Set
    End Property
    Public Property dataInicioProducao() As String
        Get
            Return _dataInicioProducao
        End Get
        Set(ByVal value As String)
            If value.isValidDate Then
                dDataInicioProducao = CDate(value)
            End If
            _dataInicioProducao = value
        End Set
    End Property
    Public Property dDataInicioProducao() As Date
        Get
            Return _dDataInicioProducao
        End Get
        Set(ByVal value As Date)
            _dDataInicioProducao = value
        End Set
    End Property
    Public Property aux1() As String
        Get
            Return _aux1
        End Get
        Set(ByVal value As String)
            _aux1 = value
        End Set
    End Property
    Public Property aux2() As String
        Get
            Return _aux2
        End Get
        Set(ByVal value As String)
            _aux2 = value
        End Set
    End Property
    Public Property aux3() As String
        Get
            Return _aux3
        End Get
        Set(ByVal value As String)
            _aux3 = value
        End Set
    End Property
    Public Property aux4() As String
        Get
            Return _aux4
        End Get
        Set(ByVal value As String)
            _aux4 = value
        End Set
    End Property
    Public Property aux5() As String
        Get
            Return _aux5
        End Get
        Set(ByVal value As String)
            _aux5 = value
        End Set
    End Property
    Public Property aux6() As String
        Get
            Return _aux6
        End Get
        Set(ByVal value As String)
            _aux6 = value
        End Set
    End Property
    Public Property aux7() As String
        Get
            Return _aux7
        End Get
        Set(ByVal value As String)
            _aux7 = value
        End Set
    End Property
    Public Property aux8() As String
        Get
            Return _aux8
        End Get
        Set(ByVal value As String)
            _aux8 = value
        End Set
    End Property
    Public Property aux9() As String
        Get
            Return _aux9
        End Get
        Set(ByVal value As String)
            _aux9 = value
        End Set
    End Property
    Public Property aux10() As String
        Get
            Return _aux10
        End Get
        Set(ByVal value As String)
            _aux10 = value
        End Set
    End Property
    Public Property aux11() As String
        Get
            Return _aux11
        End Get
        Set(ByVal value As String)
            _aux11 = value
        End Set
    End Property
    Public Property aux12() As String
        Get
            Return _aux12
        End Get
        Set(ByVal value As String)
            _aux12 = value
        End Set
    End Property
    Public Property auxCheck1() As String
        Get
            Return _auxCheck1
        End Get
        Set(ByVal value As String)
            _auxCheck1 = value
        End Set
    End Property
    Public Property auxCheck2() As String
        Get
            Return _auxCheck2
        End Get
        Set(ByVal value As String)
            _auxCheck2 = value
        End Set
    End Property
    Public Property auxCheck3() As String
        Get
            Return _auxCheck3
        End Get
        Set(ByVal value As String)
            _auxCheck3 = value
        End Set
    End Property
    Public Property auxCheck4() As String
        Get
            Return _auxCheck4
        End Get
        Set(ByVal value As String)
            _auxCheck4 = value
        End Set
    End Property
    Public Property auxCheck5() As String
        Get
            Return _auxCheck5
        End Get
        Set(ByVal value As String)
            _auxCheck5 = value
        End Set
    End Property
    Public Property auxCheck6() As String
        Get
            Return _auxCheck6
        End Get
        Set(ByVal value As String)
            _auxCheck6 = value
        End Set
    End Property
    Public Property auxCheck7() As String
        Get
            Return _auxCheck7
        End Get
        Set(ByVal value As String)
            _auxCheck7 = value
        End Set
    End Property
    Public Property auxCheck8() As String
        Get
            Return _auxCheck8
        End Get
        Set(ByVal value As String)
            _auxCheck8 = value
        End Set
    End Property
    Public Property codUnidade() As String
        Get
            Return _codUnidade
        End Get
        Set(ByVal value As String)
            _codUnidade = value
        End Set
    End Property
    Public Property codPlanoUN() As String
        Get
            Return _codPlanoUN
        End Get
        Set(ByVal value As String)
            _codPlanoUN = value
        End Set
    End Property
    Public Property codUN() As String
        Get
            Return _codUN
        End Get
        Set(ByVal value As String)
            _codUN = value
        End Set
    End Property
    Public Property codModalidade() As String
        Get
            Return _codModalidade
        End Get
        Set(ByVal value As String)
            _codModalidade = value
        End Set
    End Property
    Public Property recurso() As String
        Get
            Return _recurso
        End Get
        Set(ByVal value As String)
            _recurso = value
        End Set
    End Property
    Public Property baseIcmsSubstituicao() As String
        Get
            If String.IsNullOrEmpty(_baseIcmsSubstituicao) Then
                _baseIcmsSubstituicao = 0
            End If
            Return _baseIcmsSubstituicao
        End Get
        Set(ByVal value As String)
            _baseIcmsSubstituicao = value
        End Set
    End Property
    Public Property icmsSubstituicao() As String
        Get
            Return _icmsSubstituicao
        End Get
        Set(ByVal value As String)
            _icmsSubstituicao = value
        End Set
    End Property
    Public Property valorFrete() As String
        Get
            Return _valorFrete
        End Get
        Set(ByVal value As String)
            _valorFrete = value
        End Set
    End Property
    Public Property valorSeguro() As String
        Get
            Return _valorSeguro
        End Get
        Set(ByVal value As String)
            _valorSeguro = value
        End Set
    End Property
    Public Property valorDespesaAcessoria() As String
        Get
            Return _valorDespesaAcessoria
        End Get
        Set(ByVal value As String)
            _valorDespesaAcessoria = value
        End Set
    End Property
    Public Property observacao() As String
        Get
            Return _observacao
        End Get
        Set(ByVal value As String)
            _observacao = value
        End Set
    End Property
    Public Property custoFreteProdutor() As String
        Get
            Return _custoFreteProdutor
        End Get
        Set(ByVal value As String)
            _custoFreteProdutor = value
        End Set
    End Property
    Public Property custoRoyaltiesProdutor() As String
        Get
            Return _custoRoyaltiesProdutor
        End Get
        Set(ByVal value As String)
            _custoRoyaltiesProdutor = value
        End Set
    End Property
    Public Property codTabelaPrecoVenda() As String
        Get
            Return _codTabelaPrecoVenda
        End Get
        Set(ByVal value As String)
            _codTabelaPrecoVenda = value
        End Set
    End Property
    Public Property embarqueConferido() As String
        Get
            Return _embarqueConferido
        End Get
        Set(ByVal value As String)
            _embarqueConferido = value
        End Set
    End Property
    Public Property seqSolicitacao() As String
        Get
            Return _seqSolicitacao
        End Get
        Set(ByVal value As String)
            _seqSolicitacao = value
        End Set
    End Property

    Public Property codTipoCobrancaOS() As String
        Get
            Return _codTipoCobrancaOS
        End Get
        Set(ByVal value As String)
            _codTipoCobrancaOS = value
        End Set
    End Property

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable

            StrSql += " select * "
            StrSql += "   from pedido_venda_item "
            StrSql += "  where empresa          = " + empresa
            StrSql += "    and estabelecimento  = " + estabelecimento
            StrSql += "    and cod_pedido_venda = " + codPedidoVenda
            StrSql += "    and seq_item         = " + seqItem

            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                codItem = dt.Rows.Item(0).Item("cod_item").ToString
                referencia = dt.Rows.Item(0).Item("referencia").ToString
                lote = dt.Rows.Item(0).Item("lote").ToString
                codUsuario = dt.Rows.Item(0).Item("cod_usuario").ToString
                qtdUd = dt.Rows.Item(0).Item("qtd_ud").ToString
                qtdPedida = dt.Rows.Item(0).Item("qtd_pedida").ToString
                qtdAlocada = dt.Rows.Item(0).Item("qtd_alocada").ToString
                qtdEntregue = dt.Rows.Item(0).Item("qtd_entregue").ToString
                precoUnitarioOriginal = dt.Rows.Item(0).Item("preco_unitario_original").ToString
                precoUnitario = dt.Rows.Item(0).Item("preco_unitario").ToString
                precoUnitarioTabela = dt.Rows.Item(0).Item("preco_unitario_tabela").ToString
                precoUnitarioUdOriginal = dt.Rows.Item(0).Item("preco_unitario_ud_original").ToString
                precoUnitarioUd = dt.Rows.Item(0).Item("preco_unitario_ud").ToString
                precoUnitarioProdutor = dt.Rows.Item(0).Item("preco_unitario_produtor").ToString
                precoUnitarioProdutorDesconto = dt.Rows.Item(0).Item("preco_unitario_produtor_desconto").ToString
                precoUnitarioProdutorFaturar = dt.Rows.Item(0).Item("preco_unitario_produtor_faturar").ToString
                valorMercadoria = dt.Rows.Item(0).Item("valor_mercadoria").ToString
                valorMercadoriaProdutor = dt.Rows.Item(0).Item("valor_mercadoria_produtor").ToString
                aliquotaIcms = dt.Rows.Item(0).Item("aliquota_icms").ToString
                valorIcms = dt.Rows.Item(0).Item("valor_icms").ToString
                aliquotaIpi = dt.Rows.Item(0).Item("aliquota_ipi").ToString
                valorIpi = dt.Rows.Item(0).Item("valor_ipi").ToString
                percDescontoUnitario = dt.Rows.Item(0).Item("perc_desconto_unitario").ToString
                percDescontoUnitario2 = dt.Rows.Item(0).Item("perc_desconto_unitario2").ToString
                percDescontoUnitario3 = dt.Rows.Item(0).Item("perc_desconto_unitario3").ToString
                percDescontoUnitario4 = dt.Rows.Item(0).Item("perc_desconto_unitario4").ToString
                percDescontoUnitario5 = dt.Rows.Item(0).Item("perc_desconto_unitario5").ToString
                percDesconto = dt.Rows.Item(0).Item("perc_desconto").ToString
                valorDesconto = dt.Rows.Item(0).Item("valor_desconto").ToString
                valorTotalMercadoria = dt.Rows.Item(0).Item("valor_total_mercadoria").ToString
                valorTotalMercadoriaProdutor = dt.Rows.Item(0).Item("valor_total_mercadoria_produtor").ToString
                valorCusto = dt.Rows.Item(0).Item("valor_custo").ToString
                impostosFederais = dt.Rows.Item(0).Item("impostos_federais").ToString
                percComissao = dt.Rows.Item(0).Item("perc_comissao").ToString
                valorComissao = dt.Rows.Item(0).Item("valor_comissao").ToString
                margemLiquida = dt.Rows.Item(0).Item("margem_liquida").ToString
                CodAgenteTecnico = dt.Rows.Item(0).Item("cod_agente_tecnico").ToString
                situacaoFaturamento = dt.Rows.Item(0).Item("situacao_faturamento").ToString
                situacaoAprovacao = dt.Rows.Item(0).Item("situacao_aprovacao").ToString
                situacaoEntrega = dt.Rows.Item(0).Item("situacao_entrega").ToString
                ServicoSolicitado = dt.Rows.Item(0).Item("servico_solicitado").ToString
                seqSolicitacao = dt.Rows.Item(0).Item("seq_solicitacao").ToString
                HoraInicial = dt.Rows.Item(0).Item("hora_inicial").ToString
                HoraFinal = dt.Rows.Item(0).Item("hora_final").ToString
                KmInicial = dt.Rows.Item(0).Item("km_inicial").ToString
                KmFinal = dt.Rows.Item(0).Item("km_final").ToString
                LocalOrigem = dt.Rows.Item(0).Item("local_origem").ToString
                LocalDestino = dt.Rows.Item(0).Item("local_destino").ToString

                If Not IsDBNull(dt.Rows.Item(0).Item("data_entrega")) Then
                    DataEntrega = CDate(dt.Rows.Item(0).Item("data_entrega")).ToString("dd/MM/yyyy")
                    DDataEntrega = CDate(dt.Rows.Item(0).Item("data_entrega")).ToString("dd/MM/yyyy")
                Else
                    DataEntrega = ""
                    DDataEntrega = New Date(1900, 1, 1)
                End If

                If IsDBNull(dt.Rows.Item(0).Item("data_aprova_financ")) Then
                    dataAprovaFinanc = ""
                Else
                    dataAprovaFinanc = CDate(dt.Rows.Item(0).Item("data_aprova_financ")).ToString("dd/MM/yyyy")
                End If

                codNaturOper = dt.Rows.Item(0).Item("cod_natur_oper").ToString
                codSituacaoProducao = dt.Rows.Item(0).Item("cod_situacao_producao").ToString
                narrativa = dt.Rows.Item(0).Item("narrativa").ToString
                codNegociacaoCliente = dt.Rows.Item(0).Item("cod_negociacao_cliente").ToString
                largura = dt.Rows.Item(0).Item("largura").ToString
                altura = dt.Rows.Item(0).Item("altura").ToString
                espessura = dt.Rows.Item(0).Item("espessura").ToString

                If IsDBNull(dt.Rows.Item(0).Item("data_inicio_producao")) Then
                    dataInicioProducao = ""
                Else
                    dataInicioProducao = CDate(dt.Rows.Item(0).Item("data_inicio_producao")).ToString("dd/MM/yyyy")
                End If

                aux1 = dt.Rows.Item(0).Item("aux1").ToString
                aux2 = dt.Rows.Item(0).Item("aux2").ToString
                aux3 = dt.Rows.Item(0).Item("aux3").ToString
                aux4 = dt.Rows.Item(0).Item("aux4").ToString
                aux5 = dt.Rows.Item(0).Item("aux5").ToString
                aux6 = dt.Rows.Item(0).Item("aux6").ToString
                aux7 = dt.Rows.Item(0).Item("aux7").ToString
                aux8 = dt.Rows.Item(0).Item("aux8").ToString
                aux9 = dt.Rows.Item(0).Item("aux9").ToString
                aux10 = dt.Rows.Item(0).Item("aux10").ToString
                aux11 = dt.Rows.Item(0).Item("aux11").ToString
                aux12 = dt.Rows.Item(0).Item("aux12").ToString
                auxCheck1 = dt.Rows.Item(0).Item("aux_check1").ToString
                auxCheck2 = dt.Rows.Item(0).Item("aux_check2").ToString
                auxCheck3 = dt.Rows.Item(0).Item("aux_check3").ToString
                auxCheck4 = dt.Rows.Item(0).Item("aux_check4").ToString
                auxCheck5 = dt.Rows.Item(0).Item("aux_check5").ToString
                auxCheck6 = dt.Rows.Item(0).Item("aux_check6").ToString
                auxCheck7 = dt.Rows.Item(0).Item("aux_check7").ToString
                auxCheck8 = dt.Rows.Item(0).Item("aux_check8").ToString
                codUnidade = dt.Rows.Item(0).Item("cod_unidade").ToString
                codPlanoUN = dt.Rows.Item(0).Item("cod_plano_un").ToString
                codUN = dt.Rows.Item(0).Item("cod_un").ToString
                codModalidade = dt.Rows.Item(0).Item("cod_modalidade").ToString
                recurso = dt.Rows.Item(0).Item("recurso").ToString
                baseIcmsSubstituicao = dt.Rows.Item(0).Item("base_icms_substituicao").ToString
                icmsSubstituicao = dt.Rows.Item(0).Item("icms_substituicao").ToString
                valorFrete = dt.Rows.Item(0).Item("valor_frete").ToString
                valorSeguro = dt.Rows.Item(0).Item("valor_seguro").ToString
                valorDespesaAcessoria = dt.Rows.Item(0).Item("valor_despesa_acessoria").ToString
                observacao = dt.Rows.Item(0).Item("observacao").ToString
                custoFreteProdutor = dt.Rows.Item(0).Item("custo_frete_produtor").ToString
                custoRoyaltiesProdutor = dt.Rows.Item(0).Item("custo_royalties_produtor").ToString
                codTabelaPrecoVenda = dt.Rows.Item(0).Item("cod_tabela_preco_venda").ToString
                embarqueConferido = dt.Rows.Item(0).Item("embarque_conferido").ToString
                numeroSerie = dt.Rows.Item(0).Item("numero_serie").ToString
                seqComponente = dt.Rows.Item(0).Item("seq_componente").ToString
                codTipoCobrancaOS = dt.Rows.Item(0).Item("cod_tipo_cobranca_os").ToString
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Incluir()
        Try
            Dim StrSql As String = ""

            qtdUd = IIf(String.IsNullOrEmpty(qtdUd), "null", qtdUd)
            qtdPedida = IIf(String.IsNullOrEmpty(qtdPedida), "null", qtdPedida)
            qtdAlocada = IIf(String.IsNullOrEmpty(qtdAlocada), "null", qtdAlocada)
            qtdEntregue = IIf(String.IsNullOrEmpty(qtdEntregue), "null", qtdEntregue)
            precoUnitarioOriginal = IIf(String.IsNullOrEmpty(precoUnitarioOriginal), "null", precoUnitarioOriginal)
            precoUnitario = IIf(String.IsNullOrEmpty(precoUnitario), "null", precoUnitario)
            precoUnitarioTabela = IIf(String.IsNullOrEmpty(precoUnitarioTabela), "null", precoUnitarioTabela)
            precoUnitarioUdOriginal = IIf(String.IsNullOrEmpty(precoUnitarioUdOriginal), "null", precoUnitarioUdOriginal)
            precoUnitarioUd = IIf(String.IsNullOrEmpty(precoUnitarioUd), "null", precoUnitarioUd)
            precoUnitarioProdutor = IIf(String.IsNullOrEmpty(precoUnitarioProdutor), "null", precoUnitarioProdutor)
            precoUnitarioProdutorDesconto = IIf(String.IsNullOrEmpty(precoUnitarioProdutorDesconto), "null", precoUnitarioProdutorDesconto)
            precoUnitarioProdutorFaturar = IIf(String.IsNullOrEmpty(precoUnitarioProdutorFaturar), "null", precoUnitarioProdutorFaturar)
            valorMercadoria = IIf(String.IsNullOrEmpty(valorMercadoria), "null", valorMercadoria)
            valorMercadoriaProdutor = IIf(String.IsNullOrEmpty(valorMercadoriaProdutor), "null", valorMercadoriaProdutor)
            aliquotaIcms = IIf(String.IsNullOrEmpty(aliquotaIcms), "null", aliquotaIcms)
            valorIcms = IIf(String.IsNullOrEmpty(valorIcms), "null", valorIcms)
            aliquotaIpi = IIf(String.IsNullOrEmpty(aliquotaIpi), "null", aliquotaIpi)
            valorIpi = IIf(String.IsNullOrEmpty(valorIpi), "null", valorIpi)
            percDescontoUnitario = IIf(String.IsNullOrEmpty(percDescontoUnitario), "null", percDescontoUnitario)
            percDescontoUnitario2 = IIf(String.IsNullOrEmpty(percDescontoUnitario2), "null", percDescontoUnitario2)
            percDescontoUnitario3 = IIf(String.IsNullOrEmpty(percDescontoUnitario3), "null", percDescontoUnitario3)
            percDescontoUnitario4 = IIf(String.IsNullOrEmpty(percDescontoUnitario4), "null", percDescontoUnitario4)
            percDescontoUnitario5 = IIf(String.IsNullOrEmpty(percDescontoUnitario5), "null", percDescontoUnitario5)
            percDesconto = IIf(String.IsNullOrEmpty(percDesconto), "null", percDesconto)
            valorDesconto = IIf(String.IsNullOrEmpty(valorDesconto), "null", valorDesconto)
            valorTotalMercadoria = IIf(String.IsNullOrEmpty(valorTotalMercadoria), "null", valorTotalMercadoria)
            valorTotalMercadoriaProdutor = IIf(String.IsNullOrEmpty(valorTotalMercadoriaProdutor), "null", valorTotalMercadoriaProdutor)
            valorCusto = IIf(String.IsNullOrEmpty(valorCusto), "null", valorCusto)
            impostosFederais = IIf(String.IsNullOrEmpty(impostosFederais), "null", impostosFederais)
            percComissao = IIf(String.IsNullOrEmpty(percComissao), "null", percComissao)
            valorComissao = IIf(String.IsNullOrEmpty(valorComissao), "null", valorComissao)
            margemLiquida = IIf(String.IsNullOrEmpty(margemLiquida), "null", margemLiquida)
            largura = IIf(String.IsNullOrEmpty(largura), "null", largura)
            altura = IIf(String.IsNullOrEmpty(altura), "null", altura)
            espessura = IIf(String.IsNullOrEmpty(espessura), "null", espessura)
            codModalidade = IIf(String.IsNullOrEmpty(codModalidade), "null", codModalidade)
            recurso = IIf(String.IsNullOrEmpty(recurso), "null", recurso)
            baseIcmsSubstituicao = IIf(String.IsNullOrEmpty(baseIcmsSubstituicao), "null", baseIcmsSubstituicao)
            icmsSubstituicao = IIf(String.IsNullOrEmpty(icmsSubstituicao), "null", icmsSubstituicao)
            valorFrete = IIf(String.IsNullOrEmpty(valorFrete), "null", valorFrete)
            valorSeguro = IIf(String.IsNullOrEmpty(valorSeguro), "null", valorSeguro)
            valorDespesaAcessoria = IIf(String.IsNullOrEmpty(valorDespesaAcessoria), "null", valorDespesaAcessoria)
            custoFreteProdutor = IIf(String.IsNullOrEmpty(custoFreteProdutor), "null", custoFreteProdutor)
            custoRoyaltiesProdutor = IIf(String.IsNullOrEmpty(custoRoyaltiesProdutor), "null", custoRoyaltiesProdutor)
            codTabelaPrecoVenda = IIf(String.IsNullOrEmpty(codTabelaPrecoVenda), "null", codTabelaPrecoVenda)
            codSituacaoProducao = IIf(String.IsNullOrEmpty(codSituacaoProducao), "null", codSituacaoProducao)
            codNegociacaoCliente = IIf(String.IsNullOrEmpty(codNegociacaoCliente), "null", codNegociacaoCliente)
            codPlanoUN = IIf(String.IsNullOrEmpty(codPlanoUN), "null", codPlanoUN)
            seqSolicitacao = IIf(String.IsNullOrEmpty(seqSolicitacao), "null", seqSolicitacao)
            seqComponente = IIf(String.IsNullOrEmpty(seqComponente), "null", seqComponente)
            CodAgenteTecnico = IIf(String.IsNullOrEmpty(CodAgenteTecnico) OrElse CodAgenteTecnico = "0", "null", CodAgenteTecnico)

            qtdAlocada = 0
            qtdEntregue = 0
            embarqueConferido = "N"

            If PedidoEncerrado() Then
                Throw New Exception("Não é permitido incluir item na OS após o encerramento da mesma.")
            End If

            StrSql += " call sp_sysvar(); "
            StrSql += " insert into pedido_venda_item ( "
            StrSql += "    empresa, "
            StrSql += "    estabelecimento, "
            StrSql += "    cod_pedido_venda, "
            StrSql += "    seq_item, "
            StrSql += "    cod_item, "
            StrSql += "    referencia, "
            StrSql += "    lote, "
            StrSql += "    cod_usuario, "
            StrSql += "    qtd_ud, "
            StrSql += "    qtd_pedida, "
            StrSql += "    qtd_alocada, "
            StrSql += "    qtd_entregue, "
            StrSql += "    preco_unitario_original, "
            StrSql += "    preco_unitario, "
            'StrSql += "    preco_unitario_tabela, "
            StrSql += "    preco_unitario_ud_original, "
            StrSql += "    preco_unitario_ud, "
            'StrSql += "    preco_unitario_produtor, "
            'StrSql += "    preco_unitario_produtor_desconto, "
            'StrSql += "    preco_unitario_produtor_faturar, "
            StrSql += "    valor_mercadoria, "
            'StrSql += "    valor_mercadoria_produtor, "
            StrSql += "    aliquota_icms, "
            StrSql += "    valor_icms, "
            StrSql += "    aliquota_ipi, "
            StrSql += "    valor_ipi, "
            StrSql += "    perc_desconto_unitario, "
            StrSql += "    perc_desconto_unitario2, "
            StrSql += "    perc_desconto_unitario3, "
            StrSql += "    perc_desconto_unitario4, "
            StrSql += "    perc_desconto_unitario5, "
            StrSql += "    perc_desconto, "
            StrSql += "    valor_desconto, "
            StrSql += "    valor_total_mercadoria, "
            StrSql += "    valor_total_mercadoria_produtor, "
            StrSql += "    valor_custo, "
            StrSql += "    impostos_federais, "
            StrSql += "    perc_comissao, "
            StrSql += "    valor_comissao, "
            StrSql += "    margem_liquida, "
            StrSql += "    situacao_faturamento, "
            StrSql += "    situacao_aprovacao, "
            StrSql += "    situacao_entrega, "
            StrSql += "    data_aprova_financ, "
            StrSql += "    cod_natur_oper, "
            StrSql += "    cod_situacao_producao, "
            StrSql += "    narrativa, "
            StrSql += "    cod_negociacao_cliente, "
            StrSql += "    largura, "
            StrSql += "    altura, "
            StrSql += "    espessura, "
            StrSql += "    data_inicio_producao, "
            StrSql += "    aux1, "
            StrSql += "    aux2, "
            StrSql += "    aux3, "
            StrSql += "    aux4, "
            StrSql += "    aux5, "
            StrSql += "    aux6, "
            StrSql += "    aux7, "
            StrSql += "    aux8, "
            StrSql += "    aux9, "
            StrSql += "    aux10, "
            StrSql += "    aux11, "
            StrSql += "    aux12, "
            StrSql += "    aux_check1, "
            StrSql += "    aux_check2, "
            StrSql += "    aux_check3, "
            StrSql += "    aux_check4, "
            StrSql += "    aux_check5, "
            StrSql += "    aux_check6, "
            StrSql += "    aux_check7, "
            StrSql += "    aux_check8, "
            StrSql += "    cod_unidade, "
            StrSql += "    cod_plano_un, "
            StrSql += "    cod_un, "
            StrSql += "    cod_modalidade, "
            StrSql += "    recurso, "
            StrSql += "    base_icms_substituicao, "
            StrSql += "    icms_substituicao, "
            StrSql += "    valor_frete, "
            StrSql += "    valor_seguro, "
            StrSql += "    valor_despesa_acessoria, "
            StrSql += "    observacao, "
            'StrSql += "    custo_frete_produtor, "
            'StrSql += "    custo_royalties_produtor, "
            StrSql += "    cod_tabela_preco_venda, "
            StrSql += "    numero_serie, "
            StrSql += "    seq_componente, "
            StrSql += "    seq_solicitacao, "
            StrSql += "    servico_solicitado, "
            StrSql += "    data_entrega, "
            StrSql += "    embarque_conferido, hora_inicial, hora_final, km_inicial, km_final, local_origem, local_destino, cod_agente_tecnico, "
            StrSql += "    cod_tipo_cobranca_os) "
            StrSql += " values ( "
            StrSql += empresa + ", "
            StrSql += estabelecimento + ", "
            StrSql += codPedidoVenda + ", "
            StrSql += seqItem + ", "
            StrSql += IIf(String.IsNullOrEmpty(codItem), "null", "'" + codItem + "'") + ", "
            StrSql += "'" + referencia + "', "
            StrSql += "'" + lote + "', "
            StrSql += codUsuario + ", "
            StrSql += qtdUd.Replace(",", ".") + ", "
            StrSql += qtdPedida.Replace(",", ".") + ", "
            StrSql += qtdAlocada.Replace(",", ".") + ", "
            StrSql += qtdEntregue.Replace(",", ".") + ", "
            StrSql += precoUnitarioOriginal.Replace(",", ".") + ", "
            StrSql += precoUnitario.Replace(",", ".") + ", "
            'StrSql += precoUnitarioTabela.Replace(",", ".") + ", "
            StrSql += precoUnitarioUdOriginal.Replace(",", ".") + ", "
            StrSql += precoUnitarioUd.Replace(",", ".") + ", "
            'StrSql += precoUnitarioProdutor.Replace(",", ".") + ", "
            'StrSql += precoUnitarioProdutorDesconto.Replace(",", ".") + ", "
            'StrSql += precoUnitarioProdutorFaturar.Replace(",", ".") + ", "
            StrSql += valorMercadoria.Replace(",", ".") + ", "
            'StrSql += valorMercadoriaProdutor.Replace(",", ".") + ", "
            StrSql += aliquotaIcms.Replace(",", ".") + ", "
            StrSql += valorIcms.Replace(",", ".") + ", "
            StrSql += aliquotaIpi.Replace(",", ".") + ", "
            StrSql += valorIpi.Replace(",", ".") + ", "
            StrSql += percDescontoUnitario.Replace(",", ".") + ", "
            StrSql += percDescontoUnitario2.Replace(",", ".") + ", "
            StrSql += percDescontoUnitario3.Replace(",", ".") + ", "
            StrSql += percDescontoUnitario4.Replace(",", ".") + ", "
            StrSql += percDescontoUnitario5.Replace(",", ".") + ", "
            StrSql += percDesconto.Replace(",", ".") + ", "
            StrSql += valorDesconto.Replace(",", ".") + ", "
            StrSql += valorTotalMercadoria.Replace(",", ".") + ", "
            StrSql += valorTotalMercadoriaProdutor.Replace(",", ".") + ", "
            StrSql += valorCusto.Replace(",", ".") + ", "
            StrSql += impostosFederais.Replace(",", ".") + ", "
            StrSql += percComissao.Replace(",", ".") + ", "
            StrSql += valorComissao.Replace(",", ".") + ", "
            StrSql += margemLiquida.Replace(",", ".") + ", "
            StrSql += situacaoFaturamento + ", "
            StrSql += situacaoAprovacao + ", "
            StrSql += situacaoEntrega + ", "

            If dDataAprovaFinanc = Nothing Then
                StrSql += "null, "
            Else
                StrSql += "'" + dDataAprovaFinanc.ToString("yyyy-MM-dd") + "', "
            End If

            StrSql += "'" + codNaturOper + "', "
            StrSql += codSituacaoProducao + ", "
            StrSql += "'" + narrativa + "', "
            StrSql += codNegociacaoCliente + ", "
            StrSql += largura.Replace(",", ".") + ", "
            StrSql += altura.Replace(",", ".") + ", "
            StrSql += espessura.Replace(",", ".") + ", "

            If dDataInicioProducao = Nothing Then
                StrSql += "null, "
            Else
                StrSql += "'" + dDataInicioProducao.ToString("yyyy-MM-dd") + "', "
            End If

            StrSql += "'" + aux1 + "', "
            StrSql += "'" + aux2 + "', "
            StrSql += "'" + aux3 + "', "
            StrSql += "'" + aux4 + "', "
            StrSql += "'" + aux5 + "', "
            StrSql += "'" + aux6 + "', "
            StrSql += "'" + aux7 + "', "
            StrSql += "'" + aux8 + "', "
            StrSql += "'" + aux9 + "', "
            StrSql += "'" + aux10 + "', "
            StrSql += "'" + aux11 + "', "
            StrSql += "'" + aux12 + "', "
            StrSql += "'" + auxCheck1 + "', "
            StrSql += "'" + auxCheck2 + "', "
            StrSql += "'" + auxCheck3 + "', "
            StrSql += "'" + auxCheck4 + "', "
            StrSql += "'" + auxCheck5 + "', "
            StrSql += "'" + auxCheck6 + "', "
            StrSql += "'" + auxCheck7 + "', "
            StrSql += "'" + auxCheck8 + "', "

            If String.IsNullOrEmpty(codUnidade) Then
                StrSql += "null, "
            Else
                StrSql += "'" + codUnidade + "', "
            End If

            StrSql += codPlanoUN + ", "

            If String.IsNullOrEmpty(codUN) Then
                StrSql += "null, "
            Else
                StrSql += "'" + codUN + "', "
            End If

            StrSql += codModalidade + ", "
            StrSql += recurso.Replace(",", ".") + ", "
            StrSql += baseIcmsSubstituicao.Replace(",", ".") + ", "
            StrSql += icmsSubstituicao.Replace(",", ".") + ", "
            StrSql += valorFrete.Replace(",", ".") + ", "
            StrSql += valorSeguro.Replace(",", ".") + ", "
            StrSql += valorDespesaAcessoria.Replace(",", ".") + ", "
            StrSql += "'" + observacao + "', "
            'StrSql += custoFreteProdutor.Replace(",", ".") + ", "
            'StrSql += custoRoyaltiesProdutor.Replace(",", ".") + ", "
            StrSql += codTabelaPrecoVenda + ", "

            If Not String.IsNullOrEmpty(numeroSerie) AndAlso numeroSerie <> "0" AndAlso numeroSerie <> "-1" Then
                StrSql += "'" + numeroSerie + "',"
            Else
                StrSql += "null, "
            End If

            StrSql += seqComponente + ", "
            StrSql += seqSolicitacao + ", "
            StrSql += "'" + ServicoSolicitado + "', "

            If DDataEntrega = New Date(1900, 1, 1) Then
                StrSql += "null, "
            Else
                StrSql += "'" + DDataEntrega.ToString("yyyy-MM-dd") + "',"
            End If

            StrSql += "'" + embarqueConferido + "', '" + HoraInicial.ToString + "', '" + HoraFinal.ToString + "', '" + KmInicial.ToString.Replace(",", ".") + "', '" + KmFinal.ToString.Replace(",", ".") + "', '" + LocalOrigem + "', '" + LocalDestino + "', " + CodAgenteTecnico + ", "
            StrSql += IIf(codTipoCobrancaOS Is Nothing OrElse codTipoCobrancaOS = "0" OrElse codTipoCobrancaOS = "", "null", codTipoCobrancaOS) + " ) "

            ObjAcessoDados.ExecutarSql(StrSql)

            Call VincularEquipamentoAoContratoDoChamado()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim StrSql As String = ""

            qtdUd = IIf(String.IsNullOrEmpty(qtdUd), "null", qtdUd)
            qtdPedida = IIf(String.IsNullOrEmpty(qtdPedida), "null", qtdPedida)
            qtdAlocada = IIf(String.IsNullOrEmpty(qtdAlocada), "null", qtdAlocada)
            qtdEntregue = IIf(String.IsNullOrEmpty(qtdEntregue), "null", qtdEntregue)
            precoUnitarioOriginal = IIf(String.IsNullOrEmpty(precoUnitarioOriginal), "null", precoUnitarioOriginal)
            precoUnitario = IIf(String.IsNullOrEmpty(precoUnitario), "null", precoUnitario)
            precoUnitarioTabela = IIf(String.IsNullOrEmpty(precoUnitarioTabela), "null", precoUnitarioTabela)
            precoUnitarioUdOriginal = IIf(String.IsNullOrEmpty(precoUnitarioUdOriginal), "null", precoUnitarioUdOriginal)
            precoUnitarioUd = IIf(String.IsNullOrEmpty(precoUnitarioUd), "null", precoUnitarioUd)
            precoUnitarioProdutor = IIf(String.IsNullOrEmpty(precoUnitarioProdutor), "null", precoUnitarioProdutor)
            precoUnitarioProdutorDesconto = IIf(String.IsNullOrEmpty(precoUnitarioProdutorDesconto), "null", precoUnitarioProdutorDesconto)
            precoUnitarioProdutorFaturar = IIf(String.IsNullOrEmpty(precoUnitarioProdutorFaturar), "null", precoUnitarioProdutorFaturar)
            valorMercadoria = IIf(String.IsNullOrEmpty(valorMercadoria), "null", valorMercadoria)
            valorMercadoriaProdutor = IIf(String.IsNullOrEmpty(valorMercadoriaProdutor), "null", valorMercadoriaProdutor)
            aliquotaIcms = IIf(String.IsNullOrEmpty(aliquotaIcms), "null", aliquotaIcms)
            valorIcms = IIf(String.IsNullOrEmpty(valorIcms), "null", valorIcms)
            aliquotaIpi = IIf(String.IsNullOrEmpty(aliquotaIpi), "null", aliquotaIpi)
            valorIpi = IIf(String.IsNullOrEmpty(valorIpi), "null", valorIpi)
            percDescontoUnitario = IIf(String.IsNullOrEmpty(percDescontoUnitario), "null", percDescontoUnitario)
            percDescontoUnitario2 = IIf(String.IsNullOrEmpty(percDescontoUnitario2), "null", percDescontoUnitario2)
            percDescontoUnitario3 = IIf(String.IsNullOrEmpty(percDescontoUnitario3), "null", percDescontoUnitario3)
            percDescontoUnitario4 = IIf(String.IsNullOrEmpty(percDescontoUnitario4), "null", percDescontoUnitario4)
            percDescontoUnitario5 = IIf(String.IsNullOrEmpty(percDescontoUnitario5), "null", percDescontoUnitario5)
            percDesconto = IIf(String.IsNullOrEmpty(percDesconto), "null", percDesconto)
            valorDesconto = IIf(String.IsNullOrEmpty(valorDesconto), "null", valorDesconto)
            valorTotalMercadoria = IIf(String.IsNullOrEmpty(valorTotalMercadoria), "null", valorTotalMercadoria)
            valorTotalMercadoriaProdutor = IIf(String.IsNullOrEmpty(valorTotalMercadoriaProdutor), "null", valorTotalMercadoriaProdutor)
            valorCusto = IIf(String.IsNullOrEmpty(valorCusto), "null", valorCusto)
            impostosFederais = IIf(String.IsNullOrEmpty(impostosFederais), "null", impostosFederais)
            percComissao = IIf(String.IsNullOrEmpty(percComissao), "null", percComissao)
            valorComissao = IIf(String.IsNullOrEmpty(valorComissao), "null", valorComissao)
            margemLiquida = IIf(String.IsNullOrEmpty(margemLiquida), "null", margemLiquida)
            largura = IIf(String.IsNullOrEmpty(largura), "null", largura)
            altura = IIf(String.IsNullOrEmpty(altura), "null", altura)
            espessura = IIf(String.IsNullOrEmpty(espessura), "null", espessura)
            codModalidade = IIf(String.IsNullOrEmpty(codModalidade), "null", codModalidade)
            recurso = IIf(String.IsNullOrEmpty(recurso), "null", recurso)
            baseIcmsSubstituicao = IIf(String.IsNullOrEmpty(baseIcmsSubstituicao), "null", baseIcmsSubstituicao)
            icmsSubstituicao = IIf(String.IsNullOrEmpty(icmsSubstituicao), "null", icmsSubstituicao)
            valorFrete = IIf(String.IsNullOrEmpty(valorFrete), "null", valorFrete)
            valorSeguro = IIf(String.IsNullOrEmpty(valorSeguro), "null", valorSeguro)
            valorDespesaAcessoria = IIf(String.IsNullOrEmpty(valorDespesaAcessoria), "null", valorDespesaAcessoria)
            custoFreteProdutor = IIf(String.IsNullOrEmpty(custoFreteProdutor), "null", custoFreteProdutor)
            custoRoyaltiesProdutor = IIf(String.IsNullOrEmpty(custoRoyaltiesProdutor), "null", custoRoyaltiesProdutor)
            codTabelaPrecoVenda = IIf(String.IsNullOrEmpty(codTabelaPrecoVenda), "null", codTabelaPrecoVenda)
            codSituacaoProducao = IIf(String.IsNullOrEmpty(codSituacaoProducao), "null", codSituacaoProducao)
            codNegociacaoCliente = IIf(String.IsNullOrEmpty(codNegociacaoCliente), "null", codNegociacaoCliente)
            codPlanoUN = IIf(String.IsNullOrEmpty(codPlanoUN), "null", codPlanoUN)
            embarqueConferido = IIf(String.IsNullOrEmpty(embarqueConferido), "N", embarqueConferido)
            seqSolicitacao = IIf(String.IsNullOrEmpty(seqSolicitacao), "null", seqSolicitacao)
            seqComponente = IIf(String.IsNullOrEmpty(seqComponente), "null", seqComponente)
            CodAgenteTecnico = IIf(String.IsNullOrEmpty(CodAgenteTecnico) OrElse CodAgenteTecnico = "0", "null", CodAgenteTecnico)

            If PedidoEncerrado() Then
                Throw New Exception("Não é permitido alterar informações no item da OS após o encerramento da mesma.")
            End If

            StrSql += " call sp_sysvar(); "
            StrSql += " update pedido_venda_item "
            StrSql += "	   set cod_item	                        = " + IIf(String.IsNullOrEmpty(codItem), "null", "'" + codItem + "'") + ", "
            StrSql += "	       referencia	                    = '" + referencia + "', "
            StrSql += "	       lote                             = '" + lote + "', "
            StrSql += "	       cod_usuario                      = " + codUsuario + ", "
            StrSql += "	       qtd_ud                           = " + qtdUd.Replace(",", ".") + ", "
            StrSql += "	       qtd_pedida                       = " + qtdPedida.Replace(",", ".") + ", "
            'StrSql += "	       qtd_alocada                      = " + qtdAlocada.Replace(",", ".") + ", "
            'StrSql += "	       qtd_entregue                     = " + qtdEntregue.Replace(",", ".") + ", "
            StrSql += "	       preco_unitario_original          = " + precoUnitarioOriginal.Replace(",", ".") + ", "
            StrSql += "	       preco_unitario                   = " + precoUnitario.Replace(",", ".") + ", "
            'StrSql += "	       preco_unitario_tabela            = " + precoUnitarioTabela.Replace(",", ".") + ", "
            StrSql += "	       preco_unitario_ud_original       = " + precoUnitarioUdOriginal.Replace(",", ".") + ", "
            StrSql += "	       preco_unitario_ud                = " + precoUnitarioUd.Replace(",", ".") + ", "
            'StrSql += "	       preco_unitario_produtor          = " + precoUnitarioProdutor.Replace(",", ".") + ", "
            'StrSql += "	       preco_unitario_produtor_desconto = " + precoUnitarioProdutorDesconto.Replace(",", ".") + ", "
            'StrSql += "	       preco_unitario_produtor_faturar  = " + precoUnitarioProdutorFaturar.Replace(",", ".") + ", "
            StrSql += "	       valor_mercadoria                 = " + valorMercadoria.Replace(",", ".") + ", "
            'StrSql += "	       valor_mercadoria_produtor        = " + valorMercadoriaProdutor.Replace(",", ".") + ", "
            StrSql += "	       aliquota_icms                    = " + aliquotaIcms.Replace(",", ".") + ", "
            StrSql += "	       valor_icms                       = " + valorIcms.Replace(",", ".") + ", "
            StrSql += "	       aliquota_ipi                     = " + aliquotaIpi.Replace(",", ".") + ", "
            StrSql += "	       valor_ipi                        = " + valorIpi.Replace(",", ".") + ", "
            StrSql += "	       perc_desconto_unitario           = " + percDescontoUnitario.Replace(",", ".") + ", "
            StrSql += "	       perc_desconto_unitario2          = " + percDescontoUnitario2.Replace(",", ".") + ", "
            StrSql += "        perc_desconto_unitario3          = " + percDescontoUnitario3.Replace(",", ".") + ", "
            StrSql += "	       perc_desconto_unitario4          = " + percDescontoUnitario4.Replace(",", ".") + ", "
            StrSql += "        perc_desconto_unitario5          = " + percDescontoUnitario5.Replace(",", ".") + ", "
            StrSql += "	       perc_desconto                    = " + percDesconto.Replace(",", ".") + ", "
            StrSql += "	       valor_desconto                   = " + valorDesconto.Replace(",", ".") + ", "
            StrSql += "	       valor_total_mercadoria           = " + valorTotalMercadoria.Replace(",", ".") + ", "
            StrSql += "	       valor_total_mercadoria_produtor  = " + valorTotalMercadoriaProdutor.Replace(",", ".") + ", "
            StrSql += "	       valor_custo                      = " + valorCusto.Replace(",", ".") + ", "
            StrSql += "	       impostos_federais                = " + impostosFederais.Replace(",", ".") + ", "
            StrSql += "	       perc_comissao                    = " + percComissao.Replace(",", ".") + ", "
            StrSql += "	       valor_comissao                   = " + valorComissao.Replace(",", ".") + ", "
            StrSql += "	       margem_liquida                   = " + margemLiquida.Replace(",", ".") + ", "
            'StrSql += "	       situacao_faturamento             = " + situacaoFaturamento + ", "
            StrSql += "	       situacao_aprovacao               = " + situacaoAprovacao + ", "
            StrSql += "	       situacao_entrega                 = " + situacaoEntrega + ", "
            StrSql += "	       data_aprova_financ               = " + IIf(dDataAprovaFinanc = Nothing, "null", "'" + dDataAprovaFinanc.ToString("yyyy-MM-dd") + "'") + ", "
            StrSql += "	       cod_natur_oper                   = '" + codNaturOper + "', "
            StrSql += "	       cod_situacao_producao            = " + codSituacaoProducao + ", "
            StrSql += "	       narrativa                        = '" + narrativa + "', "
            StrSql += "	       cod_negociacao_cliente           = " + codNegociacaoCliente + ", "
            StrSql += "	       largura                          = " + largura.Replace(",", ".") + ", "
            StrSql += "	       altura                           = " + altura.Replace(",", ".") + ", "
            StrSql += "	       espessura                        = " + espessura.Replace(",", ".") + ", "
            StrSql += "	       data_inicio_producao             = " + IIf(dDataInicioProducao = Nothing, "null", "'" + dDataInicioProducao.ToString("yyyy-MM-dd") + "'") + ", "
            StrSql += "	       aux1	                            = '" + aux1 + "', "
            StrSql += "	       aux2                             = '" + aux2 + "', "
            StrSql += "	       aux3                             = '" + aux3 + "', "
            StrSql += "	       aux4                             = '" + aux4 + "', "
            StrSql += "	       aux5                             = '" + aux5 + "', "
            StrSql += "	       aux6                             = '" + aux6 + "', "
            StrSql += "	       aux7                             = '" + aux7 + "', "
            StrSql += "	       aux8                             = '" + aux8 + "', "
            StrSql += "        aux9                             = '" + aux9 + "', "
            StrSql += "	       aux10                            = '" + aux10 + "', "
            StrSql += "	       aux11                            = '" + aux11 + "', "
            StrSql += "	       aux12                            = '" + aux12 + "', "
            StrSql += "	       aux_check1                       = '" + auxCheck1 + "', "
            StrSql += "	       aux_check2                       = '" + auxCheck2 + "', "
            StrSql += "	       aux_check3                       = '" + auxCheck3 + "', "
            StrSql += "	       aux_check4                       = '" + auxCheck4 + "', "
            StrSql += "	       aux_check5                       = '" + auxCheck5 + "', "
            StrSql += "	       aux_check6                       = '" + auxCheck6 + "', "
            StrSql += "	       aux_check7                       = '" + auxCheck7 + "', "
            StrSql += "	       aux_check8                       = '" + auxCheck8 + "', "
            StrSql += "	       cod_unidade                      = " + IIf(String.IsNullOrEmpty(codUnidade), "null", "'" + codUnidade + "'") + ", "
            StrSql += "	       cod_plano_un                     = " + codPlanoUN + ", "
            StrSql += "	       cod_un                           = " + IIf(String.IsNullOrEmpty(codUN), "null", "'" + codUN + "'") + ", "
            StrSql += "	       cod_modalidade                   = " + codModalidade + ", "
            StrSql += "	       recurso                          = " + recurso.Replace(",", ".") + ", "
            StrSql += "	       base_icms_substituicao           = " + baseIcmsSubstituicao.Replace(",", ".") + ", "
            StrSql += "	       icms_substituicao                = " + icmsSubstituicao.Replace(",", ".") + ", "
            StrSql += "	       valor_frete                      = " + valorFrete.Replace(",", ".") + ", "
            StrSql += "        valor_seguro                     = " + valorSeguro.Replace(",", ".") + ", "
            StrSql += "	       valor_despesa_acessoria          = " + valorDespesaAcessoria.Replace(",", ".") + ", "
            StrSql += "	       observacao                       = '" + observacao + "', "
            'StrSql += "	       custo_frete_produtor             = " + custoFreteProdutor.Replace(",", ".") + ", "
            'StrSql += "	       custo_royalties_produtor         = " + custoRoyaltiesProdutor.Replace(",", ".") + ", "
            StrSql += "        numero_serie                     = " + IIf(String.IsNullOrEmpty(numeroSerie) OrElse numeroSerie = "0" OrElse numeroSerie = "-1", "null", "'" + numeroSerie + "'") + ", "
            StrSql += "        seq_componente                   = " + seqComponente + ", "
            StrSql += "        servico_solicitado               = '" + ServicoSolicitado + "', "
            StrSql += "	       cod_tabela_preco_venda           = " + codTabelaPrecoVenda + ", "
            StrSql += "        seq_solicitacao                  = " + seqSolicitacao + ", "
            StrSql += "	       embarque_conferido               = '" + embarqueConferido + "', "
            StrSql += "        hora_inicial                     = '" + HoraInicial + "', "
            StrSql += "        hora_final                       = '" + HoraFinal + "', "
            StrSql += "        km_inicial                       = '" + KmInicial.Replace(",", ".") + "', "
            StrSql += "        km_final                         = '" + KmFinal.Replace(",", ".") + "', "
            StrSql += "        local_origem                     = '" + LocalOrigem + "',"
            StrSql += "        local_destino                    = '" + LocalDestino + "',"
            StrSql += "        cod_agente_tecnico               = " + CodAgenteTecnico + ","
            StrSql += "        data_entrega                     = " + IIf(DDataEntrega = New Date(1900, 1, 1), "null, ", "'" + DDataEntrega.ToString("yyyy-MM-dd") + "', ")
            StrSql += "        cod_tipo_cobranca_os    = " + IIf(codTipoCobrancaOS Is Nothing OrElse codTipoCobrancaOS = "" OrElse codTipoCobrancaOS = "0", "null", codTipoCobrancaOS)
            StrSql += "  where empresa          = " + empresa
            StrSql += "    and estabelecimento  = " + estabelecimento
            StrSql += "    and cod_pedido_venda = " + codPedidoVenda
            StrSql += "    and seq_item         = " + seqItem

            ObjAcessoDados.ExecutarSql(StrSql)

            VincularEquipamentoAoContratoDoChamado()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub AlterarAprovFinancOS()
        Try
            Dim StrSql As String = ""

            qtdUd = IIf(String.IsNullOrEmpty(qtdUd), "null", qtdUd)
            qtdPedida = IIf(String.IsNullOrEmpty(qtdPedida), "null", qtdPedida)
            qtdAlocada = IIf(String.IsNullOrEmpty(qtdAlocada), "null", qtdAlocada)
            qtdEntregue = IIf(String.IsNullOrEmpty(qtdEntregue), "null", qtdEntregue)
            precoUnitarioOriginal = IIf(String.IsNullOrEmpty(precoUnitarioOriginal), "null", precoUnitarioOriginal)
            precoUnitario = IIf(String.IsNullOrEmpty(precoUnitario), "null", precoUnitario)
            precoUnitarioTabela = IIf(String.IsNullOrEmpty(precoUnitarioTabela), "null", precoUnitarioTabela)
            precoUnitarioUdOriginal = IIf(String.IsNullOrEmpty(precoUnitarioUdOriginal), "null", precoUnitarioUdOriginal)
            precoUnitarioUd = IIf(String.IsNullOrEmpty(precoUnitarioUd), "null", precoUnitarioUd)
            precoUnitarioProdutor = IIf(String.IsNullOrEmpty(precoUnitarioProdutor), "null", precoUnitarioProdutor)
            precoUnitarioProdutorDesconto = IIf(String.IsNullOrEmpty(precoUnitarioProdutorDesconto), "null", precoUnitarioProdutorDesconto)
            precoUnitarioProdutorFaturar = IIf(String.IsNullOrEmpty(precoUnitarioProdutorFaturar), "null", precoUnitarioProdutorFaturar)
            valorMercadoria = IIf(String.IsNullOrEmpty(valorMercadoria), "null", valorMercadoria)
            valorMercadoriaProdutor = IIf(String.IsNullOrEmpty(valorMercadoriaProdutor), "null", valorMercadoriaProdutor)
            aliquotaIcms = IIf(String.IsNullOrEmpty(aliquotaIcms), "null", aliquotaIcms)
            valorIcms = IIf(String.IsNullOrEmpty(valorIcms), "null", valorIcms)
            aliquotaIpi = IIf(String.IsNullOrEmpty(aliquotaIpi), "null", aliquotaIpi)
            valorIpi = IIf(String.IsNullOrEmpty(valorIpi), "null", valorIpi)
            percDescontoUnitario = IIf(String.IsNullOrEmpty(percDescontoUnitario), "null", percDescontoUnitario)
            percDescontoUnitario2 = IIf(String.IsNullOrEmpty(percDescontoUnitario2), "null", percDescontoUnitario2)
            percDescontoUnitario3 = IIf(String.IsNullOrEmpty(percDescontoUnitario3), "null", percDescontoUnitario3)
            percDescontoUnitario4 = IIf(String.IsNullOrEmpty(percDescontoUnitario4), "null", percDescontoUnitario4)
            percDescontoUnitario5 = IIf(String.IsNullOrEmpty(percDescontoUnitario5), "null", percDescontoUnitario5)
            percDesconto = IIf(String.IsNullOrEmpty(percDesconto), "null", percDesconto)
            valorDesconto = IIf(String.IsNullOrEmpty(valorDesconto), "null", valorDesconto)
            valorTotalMercadoria = IIf(String.IsNullOrEmpty(valorTotalMercadoria), "null", valorTotalMercadoria)
            valorTotalMercadoriaProdutor = IIf(String.IsNullOrEmpty(valorTotalMercadoriaProdutor), "null", valorTotalMercadoriaProdutor)
            valorCusto = IIf(String.IsNullOrEmpty(valorCusto), "null", valorCusto)
            impostosFederais = IIf(String.IsNullOrEmpty(impostosFederais), "null", impostosFederais)
            percComissao = IIf(String.IsNullOrEmpty(percComissao), "null", percComissao)
            valorComissao = IIf(String.IsNullOrEmpty(valorComissao), "null", valorComissao)
            margemLiquida = IIf(String.IsNullOrEmpty(margemLiquida), "null", margemLiquida)
            largura = IIf(String.IsNullOrEmpty(largura), "null", largura)
            altura = IIf(String.IsNullOrEmpty(altura), "null", altura)
            espessura = IIf(String.IsNullOrEmpty(espessura), "null", espessura)
            codModalidade = IIf(String.IsNullOrEmpty(codModalidade), "null", codModalidade)
            recurso = IIf(String.IsNullOrEmpty(recurso), "null", recurso)
            baseIcmsSubstituicao = IIf(String.IsNullOrEmpty(baseIcmsSubstituicao), "null", baseIcmsSubstituicao)
            icmsSubstituicao = IIf(String.IsNullOrEmpty(icmsSubstituicao), "null", icmsSubstituicao)
            valorFrete = IIf(String.IsNullOrEmpty(valorFrete), "null", valorFrete)
            valorSeguro = IIf(String.IsNullOrEmpty(valorSeguro), "null", valorSeguro)
            valorDespesaAcessoria = IIf(String.IsNullOrEmpty(valorDespesaAcessoria), "null", valorDespesaAcessoria)
            custoFreteProdutor = IIf(String.IsNullOrEmpty(custoFreteProdutor), "null", custoFreteProdutor)
            custoRoyaltiesProdutor = IIf(String.IsNullOrEmpty(custoRoyaltiesProdutor), "null", custoRoyaltiesProdutor)
            codTabelaPrecoVenda = IIf(String.IsNullOrEmpty(codTabelaPrecoVenda), "null", codTabelaPrecoVenda)
            codSituacaoProducao = IIf(String.IsNullOrEmpty(codSituacaoProducao), "null", codSituacaoProducao)
            codNegociacaoCliente = IIf(String.IsNullOrEmpty(codNegociacaoCliente), "null", codNegociacaoCliente)
            codPlanoUN = IIf(String.IsNullOrEmpty(codPlanoUN), "null", codPlanoUN)
            embarqueConferido = IIf(String.IsNullOrEmpty(embarqueConferido), "N", embarqueConferido)
            seqSolicitacao = IIf(String.IsNullOrEmpty(seqSolicitacao), "null", seqSolicitacao)


            StrSql += " call sp_sysvar(); "
            StrSql += " update pedido_venda_item "
            StrSql += "	   set cod_item	                        = " + IIf(String.IsNullOrEmpty(codItem), "null", "'" + codItem + "'") + ", "
            StrSql += "	       referencia	                    = '" + referencia + "', "
            StrSql += "	       lote                             = '" + lote + "', "
            StrSql += "	       cod_usuario                      = " + codUsuario + ", "
            StrSql += "	       qtd_ud                           = " + qtdUd.Replace(",", ".") + ", "
            StrSql += "	       qtd_pedida                       = " + qtdPedida.Replace(",", ".") + ", "
            'StrSql += "	       qtd_alocada                      = " + qtdAlocada.Replace(",", ".") + ", "
            'StrSql += "	       qtd_entregue                     = " + qtdEntregue.Replace(",", ".") + ", "
            StrSql += "	       preco_unitario_original          = " + precoUnitarioOriginal.Replace(",", ".") + ", "
            StrSql += "	       preco_unitario                   = " + precoUnitario.Replace(",", ".") + ", "
            'StrSql += "	       preco_unitario_tabela            = " + precoUnitarioTabela.Replace(",", ".") + ", "
            StrSql += "	       preco_unitario_ud_original       = " + precoUnitarioUdOriginal.Replace(",", ".") + ", "
            StrSql += "	       preco_unitario_ud                = " + precoUnitarioUd.Replace(",", ".") + ", "
            'StrSql += "	       preco_unitario_produtor          = " + precoUnitarioProdutor.Replace(",", ".") + ", "
            'StrSql += "	       preco_unitario_produtor_desconto = " + precoUnitarioProdutorDesconto.Replace(",", ".") + ", "
            'StrSql += "	       preco_unitario_produtor_faturar  = " + precoUnitarioProdutorFaturar.Replace(",", ".") + ", "
            StrSql += "	       valor_mercadoria                 = " + valorMercadoria.Replace(",", ".") + ", "
            'StrSql += "	       valor_mercadoria_produtor        = " + valorMercadoriaProdutor.Replace(",", ".") + ", "
            StrSql += "	       aliquota_icms                    = " + aliquotaIcms.Replace(",", ".") + ", "
            StrSql += "	       valor_icms                       = " + valorIcms.Replace(",", ".") + ", "
            StrSql += "	       aliquota_ipi                     = " + aliquotaIpi.Replace(",", ".") + ", "
            StrSql += "	       valor_ipi                        = " + valorIpi.Replace(",", ".") + ", "
            StrSql += "	       perc_desconto_unitario           = " + percDescontoUnitario.Replace(",", ".") + ", "
            StrSql += "	       perc_desconto_unitario2          = " + percDescontoUnitario2.Replace(",", ".") + ", "
            StrSql += "        perc_desconto_unitario3          = " + percDescontoUnitario3.Replace(",", ".") + ", "
            StrSql += "	       perc_desconto_unitario4          = " + percDescontoUnitario4.Replace(",", ".") + ", "
            StrSql += "        perc_desconto_unitario5          = " + percDescontoUnitario5.Replace(",", ".") + ", "
            StrSql += "	       perc_desconto                    = " + percDesconto.Replace(",", ".") + ", "
            StrSql += "	       valor_desconto                   = " + valorDesconto.Replace(",", ".") + ", "
            StrSql += "	       valor_total_mercadoria           = " + valorTotalMercadoria.Replace(",", ".") + ", "
            StrSql += "	       valor_total_mercadoria_produtor  = " + valorTotalMercadoriaProdutor.Replace(",", ".") + ", "
            StrSql += "	       valor_custo                      = " + valorCusto.Replace(",", ".") + ", "
            StrSql += "	       impostos_federais                = " + impostosFederais.Replace(",", ".") + ", "
            StrSql += "	       perc_comissao                    = " + percComissao.Replace(",", ".") + ", "
            StrSql += "	       valor_comissao                   = " + valorComissao.Replace(",", ".") + ", "
            StrSql += "	       margem_liquida                   = " + margemLiquida.Replace(",", ".") + ", "
            StrSql += "	       situacao_faturamento             = " + situacaoFaturamento + ", "
            StrSql += "	       situacao_aprovacao               = " + situacaoAprovacao + ", "
            StrSql += "	       situacao_entrega                 = " + situacaoEntrega + ", "
            StrSql += "	       data_aprova_financ               = " + IIf(dDataAprovaFinanc = Nothing, "null", "'" + dDataAprovaFinanc.ToString("yyyy-MM-dd") + "'") + ", "
            StrSql += "	       cod_natur_oper                   = '" + codNaturOper + "', "
            StrSql += "	       cod_situacao_producao            = " + codSituacaoProducao + ", "
            StrSql += "	       narrativa                        = '" + narrativa + "', "
            StrSql += "	       cod_negociacao_cliente           = " + codNegociacaoCliente + ", "
            StrSql += "	       largura                          = " + largura + ", "
            StrSql += "	       altura                           = " + altura + ", "
            StrSql += "	       espessura                        = " + espessura + ", "
            StrSql += "	       data_inicio_producao             = " + IIf(dDataInicioProducao = Nothing, "null", "'" + dDataInicioProducao.ToString("yyyy-MM-dd") + "'") + ", "
            StrSql += "	       aux1	                            = '" + aux1 + "', "
            StrSql += "	       aux2                             = '" + aux2 + "', "
            StrSql += "	       aux3                             = '" + aux3 + "', "
            StrSql += "	       aux4                             = '" + aux4 + "', "
            StrSql += "	       aux5                             = '" + aux5 + "', "
            StrSql += "	       aux6                             = '" + aux6 + "', "
            StrSql += "	       aux7                             = '" + aux7 + "', "
            StrSql += "	       aux8                             = '" + aux8 + "', "
            StrSql += "        aux9                             = '" + aux9 + "', "
            StrSql += "	       aux10                            = '" + aux10 + "', "
            StrSql += "	       aux11                            = '" + aux11 + "', "
            StrSql += "	       aux12                            = '" + aux12 + "', "
            StrSql += "	       aux_check1                       = '" + auxCheck1 + "', "
            StrSql += "	       aux_check2                       = '" + auxCheck2 + "', "
            StrSql += "	       aux_check3                       = '" + auxCheck3 + "', "
            StrSql += "	       aux_check4                       = '" + auxCheck4 + "', "
            StrSql += "	       aux_check5                       = '" + auxCheck5 + "', "
            StrSql += "	       aux_check6                       = '" + auxCheck6 + "', "
            StrSql += "	       aux_check7                       = '" + auxCheck7 + "', "
            StrSql += "	       aux_check8                       = '" + auxCheck8 + "', "
            StrSql += "	       cod_unidade                      = " + IIf(String.IsNullOrEmpty(codUnidade), "null", "'" + codUnidade + "'") + ", "
            StrSql += "	       cod_plano_un                     = " + codPlanoUN + ", "
            StrSql += "	       cod_un                           = " + IIf(String.IsNullOrEmpty(codUN), "null", "'" + codUN + "'") + ", "
            StrSql += "	       cod_modalidade                   = " + codModalidade + ", "
            StrSql += "	       recurso                          = " + recurso + ", "
            StrSql += "	       base_icms_substituicao           = " + baseIcmsSubstituicao.Replace(",", ".") + ", "
            StrSql += "	       icms_substituicao                = " + icmsSubstituicao.Replace(",", ".") + ", "
            StrSql += "	       valor_frete                      = " + valorFrete.Replace(",", ".") + ", "
            StrSql += "        valor_seguro                     = " + valorSeguro.Replace(",", ".") + ", "
            StrSql += "	       valor_despesa_acessoria          = " + valorDespesaAcessoria.Replace(",", ".") + ", "
            StrSql += "	       observacao                       = '" + observacao + "', "
            'StrSql += "	       custo_frete_produtor             = " + custoFreteProdutor.Replace(",", ".") + ", "
            'StrSql += "	       custo_royalties_produtor         = " + custoRoyaltiesProdutor.Replace(",", ".") + ", "
            StrSql += "        numero_serie                     = " + IIf(String.IsNullOrEmpty(numeroSerie) OrElse numeroSerie = "0" OrElse numeroSerie = "-1", "null", "'" + numeroSerie + "'") + ", "
            StrSql += "        servico_solicitado               = '" + ServicoSolicitado + "', "
            StrSql += "	       cod_tabela_preco_venda           = " + codTabelaPrecoVenda + ", "
            StrSql += "        seq_solicitacao                  = " + seqSolicitacao + ", "
            StrSql += "	       embarque_conferido               = '" + embarqueConferido + "', "
            StrSql += "       cod_tipo_cobranca_os    = " + IIf(codTipoCobrancaOS = Nothing, "null", codTipoCobrancaOS)
            StrSql += "  where empresa          = " + empresa
            StrSql += "    and estabelecimento  = " + estabelecimento
            StrSql += "    and cod_pedido_venda = " + codPedidoVenda
            StrSql += "    and seq_item         = " + seqItem

            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(seq_item),0) + 1 max from pedido_venda_item where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_pedido_venda = " + codPedidoVenda
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub Excluir()
        Try
            Dim StrSql As String

            StrSql = "  delete from pedido_venda_agente_tecnico_pagamento "
            StrSql += "   where empresa          = " + empresa
            StrSql += "     and estabelecimento  = " + estabelecimento
            StrSql += "     and cod_pedido_venda = " + codPedidoVenda
            If Not String.IsNullOrEmpty(seqItem) Then
                StrSql += " and seq_item         = " + seqItem
            End If

            StrSql += "; "

            StrSql += "  delete from pedido_venda_item "
            StrSql += "   where empresa          = " + empresa
            StrSql += "     and estabelecimento  = " + estabelecimento
            StrSql += "     and cod_pedido_venda = " + codPedidoVenda
            If Not String.IsNullOrEmpty(seqItem) Then
                StrSql += " and seq_item         = " + seqItem
            End If
            ObjAcessoDados.ExecutarSql("call sp_sysvar();" + StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function dtGridItens(ByVal empresa As String, ByVal estabelecimento As String, ByVal codPedidoVenda As String, ByVal nrLinhas As Long) As DataTable
        Try
            Dim strSql As String = ""
            Dim dt As DataTable

            strSql += " select pi.seq_item, pi.seq_solicitacao, pi.cod_item, i.descricao item_descricao, isnull(pi.narrativa,'') narrativa, pi.qtd_pedida, pi.preco_unitario, pi.valor_mercadoria"
            strSql += "   from pedido_venda_item pi inner join item i on pi.cod_item = i.cod_item"
            strSql += "  where pi.empresa          = " + empresa
            strSql += "    and pi.estabelecimento  = " + estabelecimento
            strSql += "    and pi.cod_pedido_venda = " + codPedidoVenda
            strSql += "  order by pi.seq_solicitacao, pi.seq_item "
            dt = ObjAcessoDados.BuscarDados(strSql)

            For i As Long = dt.Rows.Count + 1 To nrLinhas
                dt.Rows.Add(dt.NewRow)
            Next

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function dtGridItensAtiva(ByVal empresa As String, ByVal estabelecimento As String, ByVal codPedidoVenda As String, ByVal nrLinhas As Long) As DataTable
        Try
            Dim strSql As String = ""
            Dim dt As DataTable
            'Não vai trazer registros apenas para instanciar o dt
            strSql += " select pi.seq_item, pi.seq_solicitacao, pi.cod_item, i.descricao item_descricao, isnull(pi.narrativa,'') narrativa, pi.qtd_pedida, pi.preco_unitario, pi.valor_mercadoria"
            strSql += "   from pedido_venda_item pi inner join item i on pi.cod_item = i.cod_item"
            strSql += "  where pi.empresa          = 999" + empresa
            strSql += "    and pi.estabelecimento  = " + estabelecimento
            strSql += "    and pi.cod_pedido_venda = " + codPedidoVenda
            strSql += "  order by pi.seq_solicitacao, pi.seq_item "
            dt = ObjAcessoDados.BuscarDados(strSql)

            For i As Long = dt.Rows.Count + 1 To nrLinhas
                dt.Rows.Add(dt.NewRow)
            Next

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function PedidoEncerrado() As Boolean
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            objPedido.empresa = Me.empresa
            objPedido.estabelecimento = Me.estabelecimento
            objPedido.codPedidoVenda = Me.codPedidoVenda
            objPedido.Buscar()

            If objPedido.statusDigitacao = "2" Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub VincularEquipamentoAoContratoDoChamado()
        Try
            Dim StrSql As String = ""

            StrSql += " insert into contrato_manutencao_equipamento( empresa, contrato, numero_serie, dia_manutencao, tipo_frequencia_manutencao )"
            StrSql += "  select c.empresa, c.contrato, pvs.numero_serie, cm.dia_manutencao, cm.tipo_frequencia_manutencao "
            StrSql += "    from chamado c inner join pedido_venda pv on c.empresa = pv.empresa and c.cod_chamado = pv.cod_chamado "
            StrSql += "                   inner join pedido_venda_item pvs on pvs.empresa = pv.empresa and pvs.estabelecimento = pv.estabelecimento and pvs.cod_pedido_venda = pv.cod_pedido_venda "
            StrSql += "                   inner join contrato_manutencao cm on cm.empresa = c.empresa and cm.contrato = c.contrato "
            StrSql += "   where pvs.empresa          = " + Empresa
            StrSql += "     and pvs.estabelecimento  = " + Estabelecimento
            StrSql += "     and pvs.cod_pedido_venda = " + CodPedidoVenda
            StrSql += "     and pvs.seq_item         = " + seqItem
            StrSql += "     and cm.contrato is not null "
            StrSql += "     and pvs.numero_serie is not null "
            StrSql += "     and not exists(select 1 from contrato_manutencao_equipamento where empresa = c.empresa and contrato = c.contrato and numero_serie = pvs.numero_serie) "

            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
