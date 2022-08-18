Public Class UCLPedidoVenda
    Inherits System.Web.UI.Page

    Private ObjAcessoDados As UCLAcessoDados

    Private _empresa As String
    Private _estabelecimento As String
    Private _codPedidoVenda As String
    Private _codPedidoCliente As String
    Private _codPedidoRepresentante As String
    Private _codEmitente As String
    Private _cnpjFaturamento As String
    Private _cnpjCobranca As String
    Private _cnpjEntrega As String
    Private _codNaturOper As String
    Private _codTransportador As String
    Private _codRepresentante As String
    Private _percComissao As String
    Private _codAgenteVenda As String
    Private _codIndicador As String
    Private _codCondPagto As String
    Private _codNegociacaoCliente As String
    Private _codFormaPagamento As String
    Private _codObsPadrao As String
    Private _codCanalVenda As String
    Private _codCfps As String
    Private _dataEmissao As String
    Private _dDataEmissao As Date
    Private _dataCadastramento As String
    Private _dDataCadastramento As Date
    Private _hHoraCadastramento As String
    Private _dataEncerramento As String
    Private _dDataEncerramento As Date
    Private _hHoraEncerramento As String
    Private _situacaoFaturamento As String
    Private _situacaoEntrega As String
    Private _situacaoAprovacao1 As String
    Private _situacaoAprovacao2 As String
    Private _statusDigitacao As String
    Private _totalMercadoria As String
    Private _totalMercadoriaOrig As String
    Private _totalIcms As String
    Private _totalIpi As String
    Private _totalDesconto As String
    Private _totalPedido As String
    Private _totalDespesas As String
    Private _tipoFrete As String
    Private _baseIcms As String
    Private _baseIcmsSubstituicao As String
    Private _icmsTributado As String
    Private _icmsIsento As String
    Private _icmsOutras As String
    Private _icmsSubstituicao As String
    Private _baseIpi As String
    Private _ipiTributado As String
    Private _ipiIsento As String
    Private _ipiOutras As String
    Private _baseCofins As String
    Private _cofins As String
    Private _basePis As String
    Private _pis As String
    Private _baseCsll As String
    Private _csll As String
    Private _baseIrrf As String
    Private _irrf As String
    Private _baseIssqn As String
    Private _issqn As String
    Private _baseInss As String
    Private _inss As String
    Private _observacao As String
    Private _percDesconto As String
    Private _dataEntrega As String
    Private _dDataEntrega As Date
    Private _horaEntrega As String
    Private _periodo As String
    Private _codUsuarioCadastro As String
    Private _codUsuarioAlteracao As String
    Private _codUsuarioAprovacao1 As String
    Private _codUsuarioAprovacao2 As String
    Private _dataAlteracao As String
    Private _dDataAlteracao As Date
    Private _hHoraAlteracao As String
    Private _codLicenciador As String
    Private _codRomaneio As String
    Private _codChamado As String
    Private _idContrato As String
    Private _impressoOp As String
    Private _observacaoNaoFiscal As String
    Private _observacaoProducao As String
    Private _pedidoProducao As String
    Private _codObra As String
    Private _aprovadoResultado As String
    Private _codSituacaoProducao As String
    Private _codPedidoForcaVendas As String
    Private _pedidoForcaVendas As String
    Private _aux1 As String
    Private _faturamentoAssociado As String
    Private _codTpAssociado As String
    Private _codUsuarioAprovacaoResultado As String
    Private _dataAprovacaoResultado As String
    Private _dDataAprovacaoResultado As Date
    Private _hHoraAprovacaoResultado As String
    Private _dataChegada As String
    Private _dDataChegada As Date
    Private _hHoraChegada As String
    Private _dataChegadaPrevista As String
    Private _dDataChegadaPrevista As Date
    Private _hHoraChegadaPrevista As String
    Private _totalRecurso As String
    Private _totalFrete As String
    Private _totalSeguro As String
    Private _totalDespesaAcessoria As String
    Private _impressoFechamentoCarga As String
    Private _ufEmbarque As String
    Private _localEmbarque As String
    Private _obsFiscalNota As String
    Private _obsNaoFiscalNota As String
    Private _embarqueConferido As String
    Private _auxiliar1 As String
    Private _auxiliar2 As String
    Private _statusRecebimento As String
    Private _exportadoIntegracaoProducao As String
    Private _osLiberadoFinanceiro As String
    Private _codTipoCobrancaOS As String
    Private _PontoAtendimento As String
    Private _IgnoraValidacoes As Boolean
    Private _SeqAlteracaoEntrega As String
    Private _Sag As String
    Private _IdOS As String
    Private _ImprimirMatricial As String
    Private _StatusTecnico As String
    Private _dataInicioExecucao As String
    Private _dDataInicioExecucao As Date
    Private _hHoraInicioExecucao As String

    Private _dataTerminoExecucao As String
    Private _dDataTerminoExecucao As Date
    Private _hHoraTerminoExecucao As String

    Private _dataInicioTrabalhoTecnico As String
    Private _dDataInicioTrabalhoTecnico As Date
    Private _hHoraInicioTrabalhoTecnico As String

    Public Sub New(ByVal StrConn As String)
        ObjAcessoDados = New UCLAcessoDados(StrConn)
        Dim objParametrosManutencao As New UCLParametrosManutencao
        If objParametrosManutencao.Buscar(1, 1) Then
            If objParametrosManutencao.IsNull("aplicar_validacoes_encerrar_os") Then
                IgnoraValidacoes = True
            Else
                If objParametrosManutencao.GetConteudo("aplicar_validacoes_encerrar_os") = "S" Then
                    IgnoraValidacoes = False
                Else
                    IgnoraValidacoes = True
                End If
            End If
        Else
            IgnoraValidacoes = True
        End If
    End Sub

    Public Property StatusTecnico As String
        Get
            Return _StatusTecnico
        End Get
        Set(value As String)
            _StatusTecnico = value
        End Set
    End Property

    Public Property ImprimirMatricial As String
        Get
            Return _ImprimirMatricial
        End Get
        Set(value As String)
            _ImprimirMatricial = value
        End Set
    End Property

    Public Property IdOS
        Get
            Return _IdOS
        End Get
        Set(value)
            _IdOS = value
        End Set
    End Property

    Public Property SAG
        Get
            Return _Sag
        End Get
        Set(value)
            _Sag = value
        End Set
    End Property

    Public Property SeqAlteracaoEntrega As String
        Get
            Return _SeqAlteracaoEntrega
        End Get
        Set(ByVal value As String)
            _SeqAlteracaoEntrega = value
        End Set
    End Property

    Public Property IgnoraValidacoes() As Boolean
        Get
            Return _IgnoraValidacoes
        End Get
        Set(ByVal value As Boolean)
            _IgnoraValidacoes = value
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
    Public Property codPedidoCliente() As String
        Get
            Return _codPedidoCliente
        End Get
        Set(ByVal value As String)
            _codPedidoCliente = value
        End Set
    End Property
    Public Property codPedidoRepresentante() As String
        Get
            Return _codPedidoRepresentante
        End Get
        Set(ByVal value As String)
            _codPedidoRepresentante = value
        End Set
    End Property
    Public Property codEmitente() As String
        Get
            Return _codEmitente
        End Get
        Set(ByVal value As String)
            _codEmitente = value
        End Set
    End Property
    Public Property cnpjFaturamento() As String
        Get
            Return _cnpjFaturamento
        End Get
        Set(ByVal value As String)
            _cnpjFaturamento = value
        End Set
    End Property
    Public Property cnpjCobranca() As String
        Get
            Return _cnpjCobranca
        End Get
        Set(ByVal value As String)
            _cnpjCobranca = value
        End Set
    End Property
    Public Property cnpjEntrega() As String
        Get
            Return _cnpjEntrega
        End Get
        Set(ByVal value As String)
            _cnpjEntrega = value
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
    Public Property statusRecebimento() As String
        Get
            Return _statusRecebimento
        End Get
        Set(ByVal value As String)
            _statusRecebimento = value
        End Set
    End Property
    Public Property codTransportador() As String
        Get
            Return _codTransportador
        End Get
        Set(ByVal value As String)
            _codTransportador = value
        End Set
    End Property
    Public Property codRepresentante() As String
        Get
            Return _codRepresentante
        End Get
        Set(ByVal value As String)
            _codRepresentante = value
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
    Public Property codAgenteVenda() As String
        Get
            Return _codAgenteVenda
        End Get
        Set(ByVal value As String)
            _codAgenteVenda = value
        End Set
    End Property
    Public Property codIndicador() As String
        Get
            Return _codIndicador
        End Get
        Set(ByVal value As String)
            _codIndicador = value
        End Set
    End Property
    Public Property codCondPagto() As String
        Get
            Return _codCondPagto
        End Get
        Set(ByVal value As String)
            _codCondPagto = value
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
    Public Property codFormaPagamento() As String
        Get
            Return _codFormaPagamento
        End Get
        Set(ByVal value As String)
            _codFormaPagamento = value
        End Set
    End Property
    Public Property codObsPadrao() As String
        Get
            Return _codObsPadrao
        End Get
        Set(ByVal value As String)
            _codObsPadrao = value
        End Set
    End Property
    Public Property codCanalVenda() As String
        Get
            Return _codCanalVenda
        End Get
        Set(ByVal value As String)
            _codCanalVenda = value
        End Set
    End Property
    Public Property codCfps() As String
        Get
            Return _codCfps
        End Get
        Set(ByVal value As String)
            _codCfps = value
        End Set
    End Property
    Public Property dataEmissao() As String
        Get
            Return _dataEmissao
        End Get
        Set(ByVal value As String)
            If value.isValidDate Then
                dDataEmissao = CDate(value)
            End If
            _dataEmissao = value
        End Set
    End Property
    Public Property dDataEmissao() As Date
        Get
            Return _dDataEmissao
        End Get
        Set(ByVal value As Date)
            _dDataEmissao = value
        End Set
    End Property
    Public Property dataInicioExecucao As String
        Get
            Return _dataInicioExecucao
        End Get
        Set(value As String)
            Dim strData As String = ""
            Dim strHora As String
            If Not String.IsNullOrEmpty(value) Then
                strData = Left(value, 10)
                strHora = value.Substring(10)
                strHora = Left(strHora, 5)
                If strData.isValidDate Then
                    dDataInicioExecucao = CDate(strData)
                Else
                    dDataInicioExecucao = Nothing
                End If
                hHoraInicioExecucao = strHora
            Else
                dDataInicioExecucao = Nothing
            End If
            _dataInicioExecucao = strData
        End Set
    End Property
    Public Property dDataInicioExecucao() As Date
        Get
            Return _dDataInicioExecucao
        End Get
        Set(ByVal value As Date)
            _dDataInicioExecucao = value
        End Set
    End Property
    Public Property hHoraInicioExecucao() As String
        Get
            Return _hHoraInicioExecucao
        End Get
        Set(ByVal value As String)
            _hHoraInicioExecucao = value
        End Set
    End Property
    Public Property dataInicioTrabalhoTecnico As String
        Get
            Return _dataInicioTrabalhoTecnico
        End Get
        Set(value As String)
            Dim strData As String = ""
            Dim strHora As String = ""
            If Not String.IsNullOrEmpty(value) Then
                strData = Left(value, 10)
                strHora = value.Substring(10)
                strHora = Left(strHora, 5)
                If strData.isValidDate Then
                    dDataInicioTrabalhoTecnico = CDate(strData)
                Else
                    dDataInicioTrabalhoTecnico = Nothing
                End If
                hHoraInicioTrabalhoTecnico = strHora
            Else
                dDataInicioTrabalhoTecnico = Nothing
            End If
            _dataInicioTrabalhoTecnico = strData
        End Set
    End Property
    Public Property dataTerminoExecucao As String
        Get
            Return _dataTerminoExecucao
        End Get
        Set(value As String)
            Dim strData As String = ""
            Dim strHora As String = ""
            If Not String.IsNullOrEmpty(value) Then
                strData = Left(value, 10)
                strHora = value.Substring(10)
                strHora = Left(strHora, 5)
                If strData.isValidDate Then
                    dDataTerminoExecucao = CDate(strData)
                Else
                    dDataTerminoExecucao = Nothing
                End If
                hHoraTerminoExecucao = strHora
            Else
                dDataTerminoExecucao = Nothing
            End If
            _dataTerminoExecucao = strData
        End Set
    End Property
    Public Property dDataTerminoExecucao() As Date
        Get
            Return _dDataTerminoExecucao
        End Get
        Set(ByVal value As Date)
            _dDataTerminoExecucao = value
        End Set
    End Property
    Public Property hHoraTerminoExecucao() As String
        Get
            Return _hHoraTerminoExecucao
        End Get
        Set(ByVal value As String)
            _hHoraTerminoExecucao = value
        End Set
    End Property
    Public Property dDataInicioTrabalhoTecnico() As Date
        Get
            Return _dDataInicioTrabalhoTecnico
        End Get
        Set(ByVal value As Date)
            _dDataInicioTrabalhoTecnico = value
        End Set
    End Property
    Public Property hHoraInicioTrabalhoTecnico() As String
        Get
            Return _hHoraInicioTrabalhoTecnico
        End Get
        Set(ByVal value As String)
            _hHoraInicioTrabalhoTecnico = value
        End Set
    End Property
    Public Property dataCadastramento() As String
        Get
            Return _dataCadastramento
        End Get
        Set(ByVal value As String)
            Dim strData As String
            Dim strHora As String
            If Not String.IsNullOrEmpty(value) Then
                strData = Left(value, 10)
                strHora = value.Substring(10)
                strHora = Left(strHora, 5)
                If strData.isValidDate Then
                    dDataCadastramento = CDate(strData)
                End If
                hHoraCadastramento = strHora
            End If
            _dataCadastramento = value
        End Set
    End Property
    Public Property dDataCadastramento() As Date
        Get
            Return _dDataCadastramento
        End Get
        Set(ByVal value As Date)
            _dDataCadastramento = value
        End Set
    End Property
    Public Property hHoraCadastramento() As String
        Get
            Return _hHoraCadastramento
        End Get
        Set(ByVal value As String)
            _hHoraCadastramento = value
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
    Public Property situacaoEntrega() As String
        Get
            Return _situacaoEntrega
        End Get
        Set(ByVal value As String)
            _situacaoEntrega = value
        End Set
    End Property
    Public Property situacaoAprovacao1() As String
        Get
            Return _situacaoAprovacao1
        End Get
        Set(ByVal value As String)
            _situacaoAprovacao1 = value
        End Set
    End Property
    Public Property situacaoAprovacao2() As String
        Get
            Return _situacaoAprovacao2
        End Get
        Set(ByVal value As String)
            _situacaoAprovacao2 = value
        End Set
    End Property
    Public Property statusDigitacao() As String
        Get
            If String.IsNullOrEmpty(_statusDigitacao) Then
                _statusDigitacao = "1"
            End If
            Return _statusDigitacao
        End Get
        Set(ByVal value As String)
            _statusDigitacao = value
        End Set
    End Property
    Public Property totalMercadoria() As String
        Get
            Return _totalMercadoria
        End Get
        Set(ByVal value As String)
            _totalMercadoria = value
        End Set
    End Property
    Public Property totalMercadoriaOrig() As String
        Get
            Return _totalMercadoriaOrig
        End Get
        Set(ByVal value As String)
            _totalMercadoriaOrig = value
        End Set
    End Property
    Public Property totalIcms() As String
        Get
            Return _totalIcms
        End Get
        Set(ByVal value As String)
            _totalIcms = value
        End Set
    End Property
    Public Property totalIpi() As String
        Get
            Return _totalIpi
        End Get
        Set(ByVal value As String)
            _totalIpi = value
        End Set
    End Property
    Public Property totalDesconto() As String
        Get
            Return _totalDesconto
        End Get
        Set(ByVal value As String)
            _totalDesconto = value
        End Set
    End Property
    Public Property totalPedido() As String
        Get
            Return _totalPedido
        End Get
        Set(ByVal value As String)
            _totalPedido = value
        End Set
    End Property
    Public Property totalDespesas() As String
        Get
            Return _totalDespesas
        End Get
        Set(ByVal value As String)
            _totalDespesas = value
        End Set
    End Property
    Public Property tipoFrete() As String
        Get
            Return _tipoFrete
        End Get
        Set(ByVal value As String)
            _tipoFrete = value
        End Set
    End Property
    Public Property baseIcms() As String
        Get
            Return _baseIcms
        End Get
        Set(ByVal value As String)
            _baseIcms = value
        End Set
    End Property
    Public Property baseIcmsSubstituicao() As String
        Get
            Return _baseIcmsSubstituicao
        End Get
        Set(ByVal value As String)
            _baseIcmsSubstituicao = value
        End Set
    End Property
    Public Property icmsTributado() As String
        Get
            Return _icmsTributado
        End Get
        Set(ByVal value As String)
            _icmsTributado = value
        End Set
    End Property
    Public Property icmsIsento() As String
        Get
            Return _icmsIsento
        End Get
        Set(ByVal value As String)
            _icmsIsento = value
        End Set
    End Property
    Public Property icmsOutras() As String
        Get
            Return _icmsOutras
        End Get
        Set(ByVal value As String)
            _icmsOutras = value
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
    Public Property baseIpi() As String
        Get
            Return _baseIpi
        End Get
        Set(ByVal value As String)
            _baseIpi = value
        End Set
    End Property
    Public Property ipiTributado() As String
        Get
            Return _ipiTributado
        End Get
        Set(ByVal value As String)
            _ipiTributado = value
        End Set
    End Property
    Public Property ipiIsento() As String
        Get
            Return _ipiIsento
        End Get
        Set(ByVal value As String)
            _ipiIsento = value
        End Set
    End Property
    Public Property ipiOutras() As String
        Get
            Return _ipiOutras
        End Get
        Set(ByVal value As String)
            _ipiOutras = value
        End Set
    End Property
    Public Property baseCofins() As String
        Get
            Return _baseCofins
        End Get
        Set(ByVal value As String)
            _baseCofins = value
        End Set
    End Property
    Public Property cofins() As String
        Get
            Return _cofins
        End Get
        Set(ByVal value As String)
            _cofins = value
        End Set
    End Property
    Public Property basePis() As String
        Get
            Return _basePis
        End Get
        Set(ByVal value As String)
            _basePis = value
        End Set
    End Property
    Public Property pis() As String
        Get
            Return _pis
        End Get
        Set(ByVal value As String)
            _pis = value
        End Set
    End Property
    Public Property baseCsll() As String
        Get
            Return _baseCsll
        End Get
        Set(ByVal value As String)
            _baseCsll = value
        End Set
    End Property
    Public Property csll() As String
        Get
            Return _csll
        End Get
        Set(ByVal value As String)
            _csll = value
        End Set
    End Property
    Public Property baseIrrf() As String
        Get
            Return _baseIrrf
        End Get
        Set(ByVal value As String)
            _baseIrrf = value
        End Set
    End Property
    Public Property irrf() As String
        Get
            Return _irrf
        End Get
        Set(ByVal value As String)
            _irrf = value
        End Set
    End Property
    Public Property baseIssqn() As String
        Get
            Return _baseIssqn
        End Get
        Set(ByVal value As String)
            _baseIssqn = value
        End Set
    End Property
    Public Property issqn() As String
        Get
            Return _issqn
        End Get
        Set(ByVal value As String)
            _issqn = value
        End Set
    End Property
    Public Property baseInss() As String
        Get
            Return _baseInss
        End Get
        Set(ByVal value As String)
            _baseInss = value
        End Set
    End Property
    Public Property inss() As String
        Get
            Return _inss
        End Get
        Set(ByVal value As String)
            _inss = value
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
    Public Property percDesconto() As String
        Get
            Return _percDesconto
        End Get
        Set(ByVal value As String)
            _percDesconto = value
        End Set
    End Property
    Public Property dataEntrega() As String
        Get
            Return _dataEntrega
        End Get
        Set(ByVal value As String)
            If value.isValidDate Then
                dDataEntrega = CDate(value)
            End If
            _dataEntrega = value
        End Set
    End Property
    Public Property dDataEntrega() As Date
        Get
            Return _dDataEntrega
        End Get
        Set(ByVal value As Date)
            _dDataEntrega = value
        End Set
    End Property
    Public Property HoraEntrega() As String
        Get
            Return _horaEntrega
        End Get
        Set(ByVal value As String)
            _horaEntrega = value
        End Set
    End Property
    Public Property periodo() As String
        Get
            Return _periodo
        End Get
        Set(ByVal value As String)
            _periodo = value
        End Set
    End Property
    Public Property codUsuarioCadastro() As String
        Get
            Return _codUsuarioCadastro
        End Get
        Set(ByVal value As String)
            _codUsuarioCadastro = value
        End Set
    End Property
    Public Property codUsuarioAlteracao() As String
        Get
            Return _codUsuarioAlteracao
        End Get
        Set(ByVal value As String)
            _codUsuarioAlteracao = value
        End Set
    End Property
    Public Property codUsuarioAprovacao1() As String
        Get
            Return _codUsuarioAprovacao1
        End Get
        Set(ByVal value As String)
            _codUsuarioAprovacao1 = value
        End Set
    End Property
    Public Property codUsuarioAprovacao2() As String
        Get
            Return _codUsuarioAprovacao2
        End Get
        Set(ByVal value As String)
            _codUsuarioAprovacao2 = value
        End Set
    End Property
    Public Property dataAlteracao() As String
        Get
            Return _dataAlteracao
        End Get
        Set(ByVal value As String)
            Dim strData As String
            Dim strHora As String
            If Not String.IsNullOrEmpty(value) Then
                strData = Left(value, 10)
                strHora = value.Substring(10)
                strHora = Left(strHora, 5)
                If strData.isValidDate Then
                    dDataAlteracao = CDate(strData)
                End If
                hHoraAlteracao = strHora
            End If
            _dataAlteracao = value
        End Set
    End Property
    Public Property dataEncerramento() As String
        Get
            Return _dataEncerramento
        End Get
        Set(ByVal value As String)
            Dim strData As String
            Dim strHora As String
            If Not String.IsNullOrEmpty(value) Then
                strData = Left(value, 10)
                strHora = value.Substring(10)
                strHora = Left(strHora, 5)
                If strData.isValidDate Then
                    dDataEncerramento = CDate(strData)
                End If
                hHoraEncerramento = strHora
            Else
                dDataEncerramento = Nothing
                hHoraEncerramento = ""
            End If
            _dataEncerramento = value
        End Set
    End Property
    Public Property dDataAlteracao() As Date
        Get
            Return _dDataAlteracao
        End Get
        Set(ByVal value As Date)
            _dDataAlteracao = value
        End Set
    End Property
    Public Property hHoraAlteracao() As String
        Get
            Return _hHoraAlteracao
        End Get
        Set(ByVal value As String)
            _hHoraAlteracao = value
        End Set
    End Property
    Public Property dDataEncerramento() As Date
        Get
            Return _dDataEncerramento
        End Get
        Set(ByVal value As Date)
            _dDataEncerramento = value
        End Set
    End Property
    Public Property hHoraEncerramento() As String
        Get
            Return _hHoraEncerramento
        End Get
        Set(ByVal value As String)
            _hHoraEncerramento = value
        End Set
    End Property
    Public Property DataChegada As String
        Get
            Return _dataChegada
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                _dDataChegada = value
            End If
            _dataChegada = value
        End Set
    End Property
    Public Property dDataChegada() As Date
        Get
            Return _dDataChegada
        End Get
        Set(ByVal value As Date)
            _dDataChegada = value
        End Set
    End Property
    Public Property hHoraChegada() As String
        Get
            Return _hHoraChegada
        End Get
        Set(ByVal value As String)
            _hHoraChegada = value
        End Set
    End Property
    Public Property DataChegadaPrevista As String
        Get
            Return _dataChegadaPrevista
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                _dDataChegadaPrevista = value
            End If
            _dataChegadaPrevista = value
        End Set
    End Property
    Public Property dDataChegadaPrevista() As Date
        Get
            Return _dDataChegadaPrevista
        End Get
        Set(ByVal value As Date)
            _dDataChegadaPrevista = value
        End Set
    End Property
    Public Property hHoraChegadaPrevista() As String
        Get
            Return _hHoraChegadaPrevista
        End Get
        Set(ByVal value As String)
            _hHoraChegadaPrevista = value
        End Set
    End Property
    Public Property codLicenciador() As String
        Get
            Return _codLicenciador
        End Get
        Set(ByVal value As String)
            _codLicenciador = value
        End Set
    End Property
    Public Property codRomaneio() As String
        Get
            Return _codRomaneio
        End Get
        Set(ByVal value As String)
            _codRomaneio = value
        End Set
    End Property
    Public Property codChamado() As String
        Get
            Return _codChamado
        End Get
        Set(ByVal value As String)
            _codChamado = value
        End Set
    End Property
    Public Property idContrato() As String
        Get
            Return _idContrato
        End Get
        Set(ByVal value As String)
            _idContrato = value
        End Set
    End Property
    Public Property impressoOp() As String
        Get
            Return _impressoOp
        End Get
        Set(ByVal value As String)
            _impressoOp = value
        End Set
    End Property
    Public Property observacaoNaoFiscal() As String
        Get
            Return _observacaoNaoFiscal
        End Get
        Set(ByVal value As String)
            _observacaoNaoFiscal = value
        End Set
    End Property
    Public Property observacaoProducao() As String
        Get
            Return _observacaoProducao
        End Get
        Set(ByVal value As String)
            _observacaoProducao = value
        End Set
    End Property
    Public Property pedidoProducao() As String
        Get
            Return _pedidoProducao
        End Get
        Set(ByVal value As String)
            _pedidoProducao = value
        End Set
    End Property
    Public Property codObra() As String
        Get
            Return _codObra
        End Get
        Set(ByVal value As String)
            _codObra = value
        End Set
    End Property
    Public Property aprovadoResultado() As String
        Get
            Return _aprovadoResultado
        End Get
        Set(ByVal value As String)
            _aprovadoResultado = value
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
    Public Property codPedidoForcaVendas() As String
        Get
            Return _codPedidoForcaVendas
        End Get
        Set(ByVal value As String)
            _codPedidoForcaVendas = value
        End Set
    End Property
    Public Property pedidoForcaVendas() As String
        Get
            Return _pedidoForcaVendas
        End Get
        Set(ByVal value As String)
            _pedidoForcaVendas = value
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
    Public Property faturamentoAssociado() As String
        Get
            Return _faturamentoAssociado
        End Get
        Set(ByVal value As String)
            _faturamentoAssociado = value
        End Set
    End Property
    Public Property codTpAssociado() As String
        Get
            Return _codTpAssociado
        End Get
        Set(ByVal value As String)
            _codTpAssociado = value
        End Set
    End Property
    Public Property codUsuarioAprovacaoResultado() As String
        Get
            Return _codUsuarioAprovacaoResultado
        End Get
        Set(ByVal value As String)
            _codUsuarioAprovacaoResultado = value
        End Set
    End Property
    Public Property dataAprovacaoResultado() As String
        Get
            Return _dataAprovacaoResultado
        End Get
        Set(ByVal value As String)
            Dim strData As String
            Dim strHora As String
            If Not String.IsNullOrEmpty(value) Then
                strData = Left(value, 10)
                strHora = value.Substring(10)
                strHora = Left(strHora, 5)
                If strData.isValidDate Then
                    dDataAprovacaoResultado = CDate(strData)
                End If
                hHoraAprovacaoResultado = strHora
            End If
            _dataAprovacaoResultado = value
        End Set
    End Property
    Public Property dDataAprovacaoResultado() As Date
        Get
            Return _dDataAprovacaoResultado
        End Get
        Set(ByVal value As Date)
            _dDataAprovacaoResultado = value
        End Set
    End Property
    Public Property hHoraAprovacaoResultado() As String
        Get
            Return _hHoraAprovacaoResultado
        End Get
        Set(ByVal value As String)
            _hHoraAprovacaoResultado = value
        End Set
    End Property
    Public Property totalRecurso() As String
        Get
            Return _totalRecurso
        End Get
        Set(ByVal value As String)
            _totalRecurso = value
        End Set
    End Property
    Public Property totalFrete() As String
        Get
            Return _totalFrete
        End Get
        Set(ByVal value As String)
            _totalFrete = value
        End Set
    End Property
    Public Property totalSeguro() As String
        Get
            Return _totalSeguro
        End Get
        Set(ByVal value As String)
            _totalSeguro = value
        End Set
    End Property
    Public Property totalDespesaAcessoria() As String
        Get
            Return _totalDespesaAcessoria
        End Get
        Set(ByVal value As String)
            _totalDespesaAcessoria = value
        End Set
    End Property
    Public Property impressoFechamentoCarga() As String
        Get
            Return _impressoFechamentoCarga
        End Get
        Set(ByVal value As String)
            _impressoFechamentoCarga = value
        End Set
    End Property
    Public Property ufEmbarque() As String
        Get
            Return _ufEmbarque
        End Get
        Set(ByVal value As String)
            _ufEmbarque = value
        End Set
    End Property
    Public Property localEmbarque() As String
        Get
            Return _localEmbarque
        End Get
        Set(ByVal value As String)
            _localEmbarque = value
        End Set
    End Property
    Public Property obsFiscalNota() As String
        Get
            Return _obsFiscalNota
        End Get
        Set(ByVal value As String)
            _obsFiscalNota = value
        End Set
    End Property
    Public Property obsNaoFiscalNota() As String
        Get
            Return _obsNaoFiscalNota
        End Get
        Set(ByVal value As String)
            _obsNaoFiscalNota = value
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
    Public Property auxiliar1() As String
        Get
            Return _auxiliar1
        End Get
        Set(ByVal value As String)
            _auxiliar1 = value
        End Set
    End Property
    Public Property auxiliar2() As String
        Get
            Return _auxiliar2
        End Get
        Set(ByVal value As String)
            _auxiliar2 = value
        End Set
    End Property
    Public Property exportadoIntegracaoProducao() As String
        Get
            Return _exportadoIntegracaoProducao
        End Get
        Set(ByVal value As String)
            _exportadoIntegracaoProducao = value
        End Set
    End Property

    Public Property osLiberadoFinanceiro() As String
        Get
            Return _osLiberadoFinanceiro
        End Get
        Set(ByVal value As String)
            _osLiberadoFinanceiro = value
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

    Public Property PontoAtendimento() As String
        Get
            Return _PontoAtendimento
        End Get
        Set(ByVal value As String)
            _PontoAtendimento = value
        End Set
    End Property


    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable

            StrSql += "SELECT c.*,"
            StrSql += "       ea.nome_abreviado||' PA - '||isnull( (select isnull(ppa.numero_ponto_atendimento,'') || ' - ' || isnull(ppa.descricao,'') || ' - ' || ci.nome_cidade || '/' || puf.sigla"
            StrSql += "                                               from ponto_atendimento ppa left outer join cidade ci on ppa.cod_cidade = ci.cod_cidade and ppa.cod_estado = ci.cod_estado and ppa.cod_pais = ci.cod_pais"
            StrSql += "                                                                          left outer join estado puf on puf.cod_pais = ppa.cod_pais and puf.cod_estado = ppa.cod_estado"
            StrSql += "                                              where(ppa.cod_emitente = ch.cod_emitente_atendimento)"
            StrSql += "                                                and ppa.numero_ponto_atendimento = ch.numero_ponto_atendimento),'') ponto_atendimento"
            StrSql += "  FROM pedido_venda c left outer join chamado ch on ch.empresa     = c.empresa"
            StrSql += "                                                and ch.cod_chamado = c.cod_chamado"
            StrSql += "                      left outer join endereco_emitente e on c.cod_emitente   = e.cod_emitente"
            StrSql += "                                                         and c.cnpj_faturamento = e.cnpj                        "
            StrSql += "                      left outer join emitente ea on ch.cod_emitente_atendimento = ea.cod_emitente"
            StrSql += "  where c.empresa          = " + empresa
            StrSql += "    and c.estabelecimento  = " + estabelecimento
            StrSql += "    and c.cod_pedido_venda = " + codPedidoVenda

            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                codPedidoCliente = dt.Rows.Item(0).Item("cod_Pedido_Cliente").ToString
                codPedidoRepresentante = dt.Rows.Item(0).Item("cod_Pedido_Representante").ToString
                codEmitente = dt.Rows.Item(0).Item("cod_Emitente").ToString
                cnpjFaturamento = dt.Rows.Item(0).Item("cnpj_Faturamento").ToString
                cnpjCobranca = dt.Rows.Item(0).Item("cnpj_Cobranca").ToString
                cnpjEntrega = dt.Rows.Item(0).Item("cnpj_Entrega").ToString
                codNaturOper = dt.Rows.Item(0).Item("cod_Natur_Oper").ToString
                codTransportador = dt.Rows.Item(0).Item("cod_Transportador").ToString
                codRepresentante = dt.Rows.Item(0).Item("cod_Representante").ToString
                percComissao = dt.Rows.Item(0).Item("perc_Comissao").ToString
                codAgenteVenda = dt.Rows.Item(0).Item("cod_Agente_Venda").ToString
                codIndicador = dt.Rows.Item(0).Item("cod_Indicador").ToString
                codCondPagto = dt.Rows.Item(0).Item("cod_Cond_Pagto").ToString
                codNegociacaoCliente = dt.Rows.Item(0).Item("cod_Negociacao_Cliente").ToString
                codFormaPagamento = dt.Rows.Item(0).Item("cod_Forma_Pagamento").ToString
                codObsPadrao = dt.Rows.Item(0).Item("cod_Obs_Padrao").ToString
                codCanalVenda = dt.Rows.Item(0).Item("cod_Canal_Venda").ToString
                codCfps = dt.Rows.Item(0).Item("cod_cfps").ToString
                IdOS = dt.Rows.Item(0).Item("id_os").ToString
                ImprimirMatricial = dt.Rows.Item(0).Item("imprimir_matricial").ToString
                SAG = dt.Rows.Item(0).Item("sag").ToString
                SeqAlteracaoEntrega = dt.Rows.Item(0).Item("seq_alteracao_entrega").ToString
                StatusTecnico = dt.Rows.Item(0).Item("os_status_tecnico").ToString
                If String.IsNullOrWhiteSpace(StatusTecnico) Then
                    StatusTecnico = "1"
                End If

                If String.IsNullOrEmpty(SeqAlteracaoEntrega) Then
                    SeqAlteracaoEntrega = 0
                End If

                If String.IsNullOrEmpty(ImprimirMatricial) Then
                    ImprimirMatricial = "N"
                End If

                If IsDBNull(dt.Rows.Item(0).Item("data_Emissao")) Then
                    dataEmissao = ""
                Else
                    dataEmissao = CDate(dt.Rows.Item(0).Item("data_Emissao")).ToString("dd/MM/yyyy")
                End If
                If IsDBNull(dt.Rows.Item(0).Item("data_Cadastramento")) Then
                    dataCadastramento = ""
                Else
                    dataCadastramento = CType(dt.Rows.Item(0).Item("data_Cadastramento"), DateTime).ToString("dd/MM/yyyyHH:mm:ss")
                End If

                If IsDBNull(dt.Rows.Item(0).Item("data_inicio_execucao")) Then
                    dataInicioExecucao = ""
                Else
                    dataInicioExecucao = CType(dt.Rows.Item(0).Item("data_inicio_execucao"), DateTime).ToString("dd/MM/yyyyHH:mm:ss")
                End If

                If IsDBNull(dt.Rows.Item(0).Item("data_termino_execucao")) Then
                    dataTerminoExecucao = ""
                Else
                    dataTerminoExecucao = CType(dt.Rows.Item(0).Item("data_termino_execucao"), DateTime).ToString("dd/MM/yyyyHH:mm:ss")
                End If

                If IsDBNull(dt.Rows.Item(0).Item("data_inicio_trabalho_tecnico")) Then
                    dataInicioTrabalhoTecnico = ""
                Else
                    dataInicioTrabalhoTecnico = CType(dt.Rows.Item(0).Item("data_inicio_trabalho_tecnico"), DateTime).ToString("dd/MM/yyyyHH:mm:ss")
                End If

                If IsDBNull(dt.Rows.Item(0).Item("data_encerramento")) Then
                    dataEncerramento = ""
                Else
                    dataEncerramento = CType(dt.Rows.Item(0).Item("data_encerramento"), DateTime).ToString("dd/MM/yyyyHH:mm:ss")
                End If

                situacaoFaturamento = dt.Rows.Item(0).Item("situacao_Faturamento").ToString
                situacaoEntrega = dt.Rows.Item(0).Item("situacao_Entrega").ToString
                situacaoAprovacao1 = dt.Rows.Item(0).Item("situacao_Aprovacao1").ToString
                situacaoAprovacao2 = dt.Rows.Item(0).Item("situacao_Aprovacao2").ToString
                statusDigitacao = dt.Rows.Item(0).Item("status_Digitacao").ToString
                statusRecebimento = dt.Rows.Item(0).Item("status_recebimento").ToString
                totalMercadoria = dt.Rows.Item(0).Item("total_Mercadoria").ToString
                totalMercadoriaOrig = dt.Rows.Item(0).Item("total_Mercadoria_Orig").ToString
                totalIcms = dt.Rows.Item(0).Item("total_Icms").ToString
                totalIpi = dt.Rows.Item(0).Item("total_Ipi").ToString
                totalDesconto = dt.Rows.Item(0).Item("total_Desconto").ToString
                totalPedido = dt.Rows.Item(0).Item("total_Pedido").ToString
                totalDespesas = dt.Rows.Item(0).Item("total_Despesas").ToString
                tipoFrete = dt.Rows.Item(0).Item("tipo_Frete").ToString
                baseIcms = dt.Rows.Item(0).Item("base_Icms").ToString
                statusRecebimento = dt.Rows.Item(0).Item("status_recebimento").ToString
                baseIcmsSubstituicao = dt.Rows.Item(0).Item("base_Icms_Substituicao").ToString
                icmsTributado = dt.Rows.Item(0).Item("icms_Tributado").ToString
                icmsIsento = dt.Rows.Item(0).Item("icms_Isento").ToString
                icmsOutras = dt.Rows.Item(0).Item("icms_Outras").ToString
                icmsSubstituicao = dt.Rows.Item(0).Item("icms_Substituicao").ToString
                baseIpi = dt.Rows.Item(0).Item("base_Ipi").ToString
                ipiTributado = dt.Rows.Item(0).Item("ipi_Tributado").ToString
                ipiIsento = dt.Rows.Item(0).Item("ipi_Isento").ToString
                ipiOutras = dt.Rows.Item(0).Item("ipi_Outras").ToString
                baseCofins = dt.Rows.Item(0).Item("base_Cofins").ToString
                cofins = dt.Rows.Item(0).Item("cofins").ToString
                basePis = dt.Rows.Item(0).Item("base_Pis").ToString
                pis = dt.Rows.Item(0).Item("pis").ToString
                baseCsll = dt.Rows.Item(0).Item("base_Csll").ToString
                csll = dt.Rows.Item(0).Item("csll").ToString
                baseIrrf = dt.Rows.Item(0).Item("base_Irrf").ToString
                irrf = dt.Rows.Item(0).Item("irrf").ToString
                baseIssqn = dt.Rows.Item(0).Item("base_Issqn").ToString
                issqn = dt.Rows.Item(0).Item("issqn").ToString
                baseInss = dt.Rows.Item(0).Item("base_Inss").ToString
                inss = dt.Rows.Item(0).Item("inss").ToString
                observacao = dt.Rows.Item(0).Item("observacao").ToString
                percDesconto = dt.Rows.Item(0).Item("perc_Desconto").ToString

                If IsDBNull(dt.Rows.Item(0).Item("data_Entrega")) Then
                    dataEntrega = ""
                Else
                    dataEntrega = CDate(dt.Rows.Item(0).Item("data_Entrega")).ToString("dd/MM/yyyy")
                End If

                HoraEntrega = dt.Rows.Item(0).Item("hora_entrega").ToString
                periodo = dt.Rows.Item(0).Item("periodo").ToString
                codUsuarioCadastro = dt.Rows.Item(0).Item("cod_Usuario_Cadastro").ToString
                codUsuarioAlteracao = dt.Rows.Item(0).Item("cod_Usuario_Alteracao").ToString
                codUsuarioAprovacao1 = dt.Rows.Item(0).Item("cod_Usuario_Aprovacao1").ToString
                codUsuarioAprovacao2 = dt.Rows.Item(0).Item("cod_Usuario_Aprovacao2").ToString

                If IsDBNull(dt.Rows.Item(0).Item("data_Alteracao")) Then
                    dataAlteracao = ""
                Else
                    dataAlteracao = CType(dt.Rows.Item(0).Item("data_Alteracao"), DateTime).ToString("dd/MM/yyyyHH:mm:ss")
                End If

                codLicenciador = dt.Rows.Item(0).Item("cod_Licenciador").ToString
                codRomaneio = dt.Rows.Item(0).Item("cod_Romaneio").ToString
                codChamado = dt.Rows.Item(0).Item("cod_Chamado").ToString
                idContrato = dt.Rows.Item(0).Item("id_Contrato").ToString
                impressoOp = dt.Rows.Item(0).Item("impresso_Op").ToString
                observacaoNaoFiscal = dt.Rows.Item(0).Item("observacao_Nao_Fiscal").ToString
                observacaoProducao = dt.Rows.Item(0).Item("observacao_Producao").ToString
                pedidoProducao = dt.Rows.Item(0).Item("pedido_Producao").ToString
                codObra = dt.Rows.Item(0).Item("cod_Obra").ToString
                aprovadoResultado = dt.Rows.Item(0).Item("aprovado_Resultado").ToString
                codSituacaoProducao = dt.Rows.Item(0).Item("cod_Situacao_Producao").ToString
                codPedidoForcaVendas = dt.Rows.Item(0).Item("cod_Pedido_Forca_Vendas").ToString
                pedidoForcaVendas = dt.Rows.Item(0).Item("pedido_Forca_Vendas").ToString
                aux1 = dt.Rows.Item(0).Item("aux_1").ToString
                faturamentoAssociado = dt.Rows.Item(0).Item("faturamento_Associado").ToString
                codTpAssociado = dt.Rows.Item(0).Item("cod_Tp_Associado").ToString
                codUsuarioAprovacaoResultado = dt.Rows.Item(0).Item("cod_Usuario_Aprovacao_Resultado").ToString

                If IsDBNull(dt.Rows.Item(0).Item("data_Aprovacao_Resultado")) Then
                    dataAprovacaoResultado = ""
                Else
                    dataAprovacaoResultado = CType(dt.Rows.Item(0).Item("data_Aprovacao_Resultado"), DateTime).ToString("dd/MM/yyyyHH:mm:ss")
                End If
                If IsDBNull(dt.Rows.Item(0).Item("data_chegada")) Then
                    DataChegada = ""
                    hHoraChegada = ""
                Else
                    DataChegada = CDate(dt.Rows.Item(0).Item("data_chegada")).ToString("dd/MM/yyyy")
                    hHoraChegada = CDate(dt.Rows.Item(0).Item("data_chegada")).ToString("HH:mm")
                End If
                If IsDBNull(dt.Rows.Item(0).Item("data_chegada_prevista")) Then
                    DataChegadaPrevista = ""
                    hHoraChegadaPrevista = ""
                Else
                    DataChegadaPrevista = CDate(dt.Rows.Item(0).Item("data_chegada_prevista")).ToString("dd/MM/yyyy")
                    hHoraChegadaPrevista = CDate(dt.Rows.Item(0).Item("data_chegada_prevista")).ToString("HH:mm")
                End If

                totalRecurso = dt.Rows.Item(0).Item("total_Recurso").ToString
                totalFrete = dt.Rows.Item(0).Item("total_Frete").ToString
                totalSeguro = dt.Rows.Item(0).Item("total_Seguro").ToString
                totalDespesaAcessoria = dt.Rows.Item(0).Item("total_Despesa_Acessoria").ToString
                impressoFechamentoCarga = dt.Rows.Item(0).Item("impresso_Fechamento_Carga").ToString
                ufEmbarque = dt.Rows.Item(0).Item("uf_Embarque").ToString
                localEmbarque = dt.Rows.Item(0).Item("local_Embarque").ToString
                obsFiscalNota = dt.Rows.Item(0).Item("obs_Fiscal_Nota").ToString
                obsNaoFiscalNota = dt.Rows.Item(0).Item("obs_Nao_Fiscal_Nota").ToString
                embarqueConferido = dt.Rows.Item(0).Item("embarque_Conferido").ToString
                auxiliar1 = dt.Rows.Item(0).Item("auxiliar_1").ToString
                auxiliar2 = dt.Rows.Item(0).Item("auxiliar_2").ToString
                exportadoIntegracaoProducao = dt.Rows.Item(0).Item("exportado_Integracao_Producao").ToString
                osLiberadoFinanceiro = dt.Rows.Item(0).Item("os_liberado_financeiro").ToString
                codTipoCobrancaOS = dt.Rows.Item(0).Item("cod_tipo_cobranca_os").ToString
                PontoAtendimento = dt.Rows.Item(0).Item("ponto_atendimento").ToString
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
            Dim strSql As String = ""
            Dim strData As String = ""
            Dim stant As String
            Dim msgErro As String = ""

            codNaturOper = IIf(codNaturOper = "" OrElse codNaturOper = "0" OrElse codNaturOper = "-1", "null", "'" + codNaturOper + "'")
            codPedidoRepresentante = IIf(String.IsNullOrEmpty(codPedidoRepresentante), "null", codPedidoRepresentante)
            codEmitente = IIf(String.IsNullOrEmpty(codEmitente), "null", codEmitente)
            codTransportador = IIf(String.IsNullOrEmpty(codTransportador), "null", codTransportador)
            codRepresentante = IIf(String.IsNullOrEmpty(codRepresentante), "null", codRepresentante)
            percComissao = IIf(String.IsNullOrEmpty(percComissao), "null", percComissao)
            codAgenteVenda = IIf(String.IsNullOrEmpty(codAgenteVenda), "null", codAgenteVenda)
            codCondPagto = IIf(String.IsNullOrEmpty(codCondPagto), "null", codCondPagto)
            codNegociacaoCliente = IIf(String.IsNullOrEmpty(codNegociacaoCliente), "null", codNegociacaoCliente)
            codFormaPagamento = IIf(String.IsNullOrEmpty(codFormaPagamento), "null", codFormaPagamento)
            codObsPadrao = IIf(String.IsNullOrEmpty(codObsPadrao), "null", codObsPadrao)
            codCanalVenda = IIf(String.IsNullOrEmpty(codCanalVenda), "null", codCanalVenda)
            situacaoFaturamento = IIf(String.IsNullOrEmpty(situacaoFaturamento), "null", situacaoFaturamento)
            situacaoEntrega = IIf(String.IsNullOrEmpty(situacaoEntrega), "null", situacaoEntrega)
            situacaoAprovacao1 = IIf(String.IsNullOrEmpty(situacaoAprovacao1), "null", situacaoAprovacao1)
            situacaoAprovacao2 = IIf(String.IsNullOrEmpty(situacaoAprovacao2), "null", situacaoAprovacao2)
            statusDigitacao = IIf(String.IsNullOrEmpty(statusDigitacao), "null", statusDigitacao)
            totalMercadoria = IIf(String.IsNullOrEmpty(totalMercadoria), "null", totalMercadoria)
            totalMercadoriaOrig = IIf(String.IsNullOrEmpty(totalMercadoriaOrig), "null", totalMercadoriaOrig)
            totalIcms = IIf(String.IsNullOrEmpty(totalIcms), "null", totalIcms)
            totalIpi = IIf(String.IsNullOrEmpty(totalIpi), "null", totalIpi)
            totalDesconto = IIf(String.IsNullOrEmpty(totalDesconto), "null", totalDesconto)
            totalPedido = IIf(String.IsNullOrEmpty(totalPedido), "null", totalPedido)
            totalDespesas = IIf(String.IsNullOrEmpty(totalDespesas), "null", totalDespesas)
            tipoFrete = IIf(String.IsNullOrEmpty(tipoFrete), "null", tipoFrete)
            baseIcms = IIf(String.IsNullOrEmpty(baseIcms), "null", baseIcms)
            baseIcmsSubstituicao = IIf(String.IsNullOrEmpty(baseIcmsSubstituicao), "null", baseIcmsSubstituicao)
            icmsTributado = IIf(String.IsNullOrEmpty(icmsTributado), "null", icmsTributado)
            icmsIsento = IIf(String.IsNullOrEmpty(icmsIsento), "null", icmsIsento)
            icmsOutras = IIf(String.IsNullOrEmpty(icmsOutras), "null", icmsOutras)
            icmsSubstituicao = IIf(String.IsNullOrEmpty(icmsSubstituicao), "null", icmsSubstituicao)
            baseIpi = IIf(String.IsNullOrEmpty(baseIpi), "null", baseIpi)
            ipiTributado = IIf(String.IsNullOrEmpty(ipiTributado), "null", ipiTributado)
            ipiIsento = IIf(String.IsNullOrEmpty(ipiIsento), "null", ipiIsento)
            ipiOutras = IIf(String.IsNullOrEmpty(ipiOutras), "null", ipiOutras)
            baseCofins = IIf(String.IsNullOrEmpty(baseCofins), "null", baseCofins)
            cofins = IIf(String.IsNullOrEmpty(cofins), "null", cofins)
            basePis = IIf(String.IsNullOrEmpty(basePis), "null", basePis)
            pis = IIf(String.IsNullOrEmpty(pis), "null", pis)
            baseCsll = IIf(String.IsNullOrEmpty(baseCsll), "null", baseCsll)
            csll = IIf(String.IsNullOrEmpty(csll), "null", csll)
            baseIrrf = IIf(String.IsNullOrEmpty(baseIrrf), "null", baseIrrf)
            irrf = IIf(String.IsNullOrEmpty(irrf), "null", irrf)
            baseIssqn = IIf(String.IsNullOrEmpty(baseIssqn), "null", baseIssqn)
            issqn = IIf(String.IsNullOrEmpty(issqn), "null", issqn)
            baseInss = IIf(String.IsNullOrEmpty(baseInss), "null", baseInss)
            inss = IIf(String.IsNullOrEmpty(inss), "null", inss)
            percDesconto = IIf(String.IsNullOrEmpty(percDesconto), "null", percDesconto)
            periodo = IIf(String.IsNullOrEmpty(periodo), "null", periodo)
            codUsuarioCadastro = IIf(String.IsNullOrEmpty(codUsuarioCadastro), "null", codUsuarioCadastro)
            codUsuarioAlteracao = IIf(String.IsNullOrEmpty(codUsuarioAlteracao), "null", codUsuarioAlteracao)
            codUsuarioAprovacao1 = IIf(String.IsNullOrEmpty(codUsuarioAprovacao1), "null", codUsuarioAprovacao1)
            codUsuarioAprovacao2 = IIf(String.IsNullOrEmpty(codUsuarioAprovacao2), "null", codUsuarioAprovacao2)
            codLicenciador = IIf(String.IsNullOrEmpty(codLicenciador), "null", codLicenciador)
            codRomaneio = IIf(String.IsNullOrEmpty(codRomaneio), "null", codRomaneio)
            codChamado = IIf(String.IsNullOrEmpty(codChamado), "null", codChamado)
            codObra = IIf(String.IsNullOrEmpty(codObra), "null", codObra)
            codSituacaoProducao = IIf(String.IsNullOrEmpty(codSituacaoProducao), "null", codSituacaoProducao)
            codPedidoForcaVendas = IIf(String.IsNullOrEmpty(codPedidoForcaVendas), "null", codPedidoForcaVendas)
            codTpAssociado = IIf(String.IsNullOrEmpty(codTpAssociado), "null", codTpAssociado)
            codUsuarioAprovacaoResultado = IIf(String.IsNullOrEmpty(codUsuarioAprovacaoResultado), "null", codUsuarioAprovacaoResultado)
            totalRecurso = IIf(String.IsNullOrEmpty(totalRecurso), "null", totalRecurso)
            totalFrete = IIf(String.IsNullOrEmpty(totalFrete), "null", totalFrete)
            totalSeguro = IIf(String.IsNullOrEmpty(totalSeguro), "null", totalSeguro)
            totalDespesaAcessoria = IIf(String.IsNullOrEmpty(totalDespesaAcessoria), "null", totalDespesaAcessoria)
            statusRecebimento = IIf(String.IsNullOrEmpty(statusRecebimento), "1", statusRecebimento)
            osLiberadoFinanceiro = IIf(String.IsNullOrEmpty(osLiberadoFinanceiro), "N", osLiberadoFinanceiro)
            SeqAlteracaoEntrega = IIf(String.IsNullOrEmpty(SeqAlteracaoEntrega), 0, SeqAlteracaoEntrega)
            ImprimirMatricial = IIf(String.IsNullOrEmpty(ImprimirMatricial), "N", ImprimirMatricial)
            IdOS = IIf(String.IsNullOrEmpty(IdOS), "N", IdOS)

            If Not IgnoraValidacoes Then
                If statusDigitacao <> GetStatusAtual() Then
                    If statusDigitacao = "2" Then
                        If Not TemItens() Then
                            msgErro += "Antes de encerrar a OS é necessário informar o(s) serviço(s) realizado(s).</br>"
                        End If
                        If Not TodosOsItensTemCodItemPreenchido() Then
                            msgErro += "Para encerrar a OS, é necessário que todos os serviços realizados estejam com o campo item preenchido.</br>"
                        End If
                        If dDataEncerramento = Nothing Then
                            msgErro += "Não é possível encerrar a OS sem o preenchimento do campo Data Encerramento.<br/>"
                        End If
                        If String.IsNullOrEmpty(hHoraEncerramento) Then
                            msgErro += "Não é possível encerrar a OS sem o preenchimento do campo Hora Encerramento.<br/>"
                        End If
                        If dDataChegada = Nothing Then
                            msgErro += "Não é possível encerrar a OS sem o preenchimento do campo Data Chegada.<br/>"
                        End If
                        If String.IsNullOrEmpty(hHoraChegada) Then
                            msgErro += "Não é possível encerrar a OS sem o preenchimento do campo Hora Chegada.<br/>"
                        End If
                        If Not isAgenteTecnicoInformado() Then
                            msgErro += "Não é possível encerrar a OS sem preencher o Agente Técnico responsável pelo atendimento.<br/>"
                        End If
                        If Not String.IsNullOrEmpty(msgErro) Then
                            Throw New Exception(msgErro)
                        End If
                    End If
                End If
            End If

            strSql += "call sp_sysvar(); "
            strSql += "insert into pedido_venda ("
            strSql += " empresa, "
            strSql += " estabelecimento, "
            strSql += " cod_pedido_venda, "
            strSql += " cod_pedido_cliente, "
            strSql += " cod_pedido_representante, "
            strSql += " cod_emitente, "
            strSql += " cnpj_faturamento, "
            strSql += " cnpj_cobranca, "
            strSql += " cnpj_entrega, "
            strSql += " cod_natur_oper, "
            strSql += " cod_transportador, "
            strSql += " cod_representante, "
            strSql += " perc_comissao, "
            strSql += " cod_agente_venda, "
            strSql += " cod_indicador, "
            strSql += " cod_cond_pagto, "
            strSql += " cod_negociacao_cliente, "
            strSql += " cod_forma_pagamento, "
            strSql += " cod_obs_padrao, "
            strSql += " cod_canal_venda, "
            strSql += " cod_cfps, "
            strSql += " data_emissao, "
            strSql += " data_cadastramento, "
            strSql += " data_inicio_execucao, "
            strSql += " data_termino_execucao, "
            strSql += " situacao_faturamento, "
            strSql += " situacao_entrega, "
            strSql += " situacao_aprovacao1, "
            strSql += " situacao_aprovacao2, "
            strSql += " status_digitacao, "
            strSql += " total_mercadoria, "
            strSql += " total_mercadoria_orig, "
            strSql += " total_icms, "
            strSql += " total_ipi, "
            strSql += " total_desconto, "
            strSql += " total_pedido, "
            strSql += " total_despesas, "
            strSql += " tipo_frete, "
            strSql += " base_icms, "
            strSql += " base_icms_substituicao, "
            strSql += " icms_tributado, "
            strSql += " icms_isento, "
            strSql += " icms_outras, "
            strSql += " icms_substituicao, "
            strSql += " base_ipi, "
            strSql += " ipi_tributado, "
            strSql += " ipi_isento, "
            strSql += " ipi_outras, "
            strSql += " base_cofins, "
            strSql += " cofins, "
            strSql += " base_pis, "
            strSql += " pis, "
            strSql += " base_csll, "
            strSql += " csll, "
            strSql += " base_irrf, "
            strSql += " irrf, "
            strSql += " base_issqn, "
            strSql += " issqn, "
            strSql += " base_inss, "
            strSql += " inss, "
            strSql += " observacao, "
            strSql += " perc_desconto, "
            strSql += " data_entrega, "
            strSql += " hora_entrega, "
            strSql += " periodo, "
            strSql += " cod_usuario_cadastro, "
            strSql += " cod_usuario_alteracao, "
            strSql += " cod_usuario_aprovacao1, "
            strSql += " cod_usuario_aprovacao2, "
            strSql += " data_alteracao, "
            strSql += " cod_licenciador, "
            strSql += " cod_romaneio, "
            strSql += " cod_chamado, "
            strSql += " id_contrato, "
            strSql += " impresso_op, "
            strSql += " observacao_nao_fiscal, "
            strSql += " observacao_producao, "
            strSql += " pedido_producao, "
            strSql += " cod_obra, "
            strSql += " aprovado_resultado, "
            strSql += " cod_situacao_producao, "
            strSql += " cod_pedido_forca_vendas, "
            strSql += " pedido_forca_vendas, "
            strSql += " aux_1, "
            strSql += " faturamento_associado, "
            strSql += " cod_tp_associado, "
            strSql += " cod_usuario_aprovacao_resultado, "
            strSql += " data_aprovacao_resultado, "
            strSql += " total_recurso, "
            strSql += " total_frete, "
            strSql += " total_seguro, "
            strSql += " total_despesa_acessoria, "
            strSql += " impresso_fechamento_carga, "
            strSql += " uf_embarque, "
            strSql += " local_embarque, "
            strSql += " obs_fiscal_nota, "
            strSql += " obs_nao_fiscal_nota, "
            strSql += " embarque_conferido, "
            strSql += " auxiliar_1, "
            strSql += " auxiliar_2, "
            strSql += " status_recebimento, "
            strSql += " data_encerramento, "
            strSql += " exportado_integracao_producao, "
            strSql += " os_Liberado_Financeiro, "
            strSql += " seq_alteracao_entrega, "
            strSql += " data_chegada, "
            strSql += " data_chegada_prevista, "
            strSql += " sag, "
            strSql += " id_os, "
            strSql += " imprimir_matricial, "
            strSql += " cod_tipo_cobranca_os) "
            strSql += "values ("
            strSql += empresa + ", "
            strSql += estabelecimento + ", "
            strSql += codPedidoVenda + ", "
            strSql += "'" + codPedidoCliente + "', "
            strSql += codPedidoRepresentante + ", "
            strSql += codEmitente + ", "
            strSql += "'" + cnpjFaturamento + "', "
            strSql += "'" + cnpjCobranca + "', "
            strSql += "'" + cnpjEntrega + "', "
            strSql += codNaturOper + ", "
            strSql += codTransportador + ", "
            strSql += codRepresentante + ", "
            strSql += percComissao.Replace(",", ".") + ", "
            strSql += codAgenteVenda + ", "
            strSql += "'" + codIndicador + "', "
            strSql += codCondPagto + ", "
            strSql += codNegociacaoCliente + ", "
            strSql += codFormaPagamento + ", "
            strSql += codObsPadrao + ", "
            strSql += codCanalVenda + ", "

            If String.IsNullOrEmpty(codCfps) Then
                strSql += "null, "
            Else
                strSql += "'" + codCfps + "', "
            End If

            If dDataEmissao = Nothing Then
                strSql += "null, "
            Else
                strSql += "'" + dDataEmissao.ToString("yyyy-MM-dd") + "', "
            End If

            If dDataCadastramento = Nothing Then
                strSql += "null, "
            Else
                strData = dDataCadastramento.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(hHoraCadastramento) Then
                    strData += Space(1) + Left(hHoraCadastramento, 5) + ":00"
                End If
                strSql += "'" + strData + "', "
            End If

            If dDataInicioExecucao = Nothing Then
                strSql += "null, "
            Else
                strData = dDataInicioExecucao.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(hHoraInicioExecucao) Then
                    strData += Space(1) + Left(hHoraInicioExecucao, 5) + ":00"
                End If
                strSql += "'" + strData + "', "
            End If

            If dDataTerminoExecucao = Nothing Then
                strSql += "null, "
            Else
                strData = dDataTerminoExecucao.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(hHoraTerminoExecucao) Then
                    strData += Space(1) + Left(hHoraTerminoExecucao, 5) + ":00"
                End If
                strSql += "'" + strData + "', "
            End If

            strSql += situacaoFaturamento + ", "
            strSql += situacaoEntrega + ", "
            strSql += situacaoAprovacao1 + ", "
            strSql += situacaoAprovacao2 + ", "
            strSql += statusDigitacao + ", "
            strSql += totalMercadoria.Replace(",", ".") + ", "
            strSql += totalMercadoriaOrig.Replace(",", ".") + ", "
            strSql += totalIcms.Replace(",", ".") + ", "
            strSql += totalIpi.Replace(",", ".") + ", "
            strSql += totalDesconto.Replace(",", ".") + ", "
            strSql += totalPedido.Replace(",", ".") + ", "
            strSql += totalDespesas.Replace(",", ".") + ", "
            strSql += tipoFrete.Replace(",", ".") + ", "
            strSql += baseIcms.Replace(",", ".") + ", "
            strSql += baseIcmsSubstituicao.Replace(",", ".") + ", "
            strSql += icmsTributado.Replace(",", ".") + ", "
            strSql += icmsIsento.Replace(",", ".") + ", "
            strSql += icmsOutras.Replace(",", ".") + ", "
            strSql += icmsSubstituicao.Replace(",", ".") + ", "
            strSql += baseIpi.Replace(",", ".") + ", "
            strSql += ipiTributado.Replace(",", ".") + ", "
            strSql += ipiIsento.Replace(",", ".") + ", "
            strSql += ipiOutras.Replace(",", ".") + ", "
            strSql += baseCofins.Replace(",", ".") + ", "
            strSql += cofins.Replace(",", ".") + ", "
            strSql += basePis.Replace(",", ".") + ", "
            strSql += pis.Replace(",", ".") + ", "
            strSql += baseCsll.Replace(",", ".") + ", "
            strSql += csll.Replace(",", ".") + ", "
            strSql += baseIrrf.Replace(",", ".") + ", "
            strSql += irrf.Replace(",", ".") + ", "
            strSql += baseIssqn.Replace(",", ".") + ", "
            strSql += issqn.Replace(",", ".") + ", "
            strSql += baseInss.Replace(",", ".") + ", "
            strSql += inss.Replace(",", ".") + ", "
            strSql += "'" + observacao + "', "
            strSql += percDesconto.Replace(",", ".") + ", "

            If dDataEntrega = Nothing Then
                strSql += "null, "
            Else
                strSql += "'" + dDataEntrega.ToString("yyyy-MM-dd") + "', "
            End If

            strSql += "'" + HoraEntrega + "', "
            strSql += periodo + ", "
            strSql += codUsuarioCadastro + ", "
            strSql += codUsuarioAlteracao + ", "
            strSql += codUsuarioAprovacao1 + ", "
            strSql += codUsuarioAprovacao2 + ", "

            If dDataAlteracao = Nothing Then
                strSql += "null, "
            Else
                strData = dDataAlteracao.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(hHoraAlteracao) Then
                    strData += Space(1) + Left(hHoraAlteracao, 5) + ":00"
                End If
                strSql += "'" + strData + "', "
            End If

            strSql += codLicenciador + ", "
            strSql += codRomaneio + ", "
            strSql += codChamado + ", "
            strSql += "'" + idContrato + "', "
            strSql += "'" + impressoOp + "', "
            strSql += "'" + observacaoNaoFiscal + "', "
            strSql += "'" + observacaoProducao + "', "
            strSql += "'" + pedidoProducao + "', "
            strSql += codObra + ", "
            strSql += "'" + aprovadoResultado + "', "
            strSql += codSituacaoProducao + ", "
            strSql += codPedidoForcaVendas + ", "
            strSql += "'" + pedidoForcaVendas + "', "
            strSql += "'" + aux1 + "', "
            strSql += "'" + faturamentoAssociado + "', "
            strSql += codTpAssociado + ", "
            strSql += codUsuarioAprovacaoResultado + ", "

            If dDataAprovacaoResultado = Nothing Then
                strSql += "null, "
            Else
                strData = dDataAprovacaoResultado.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(hHoraAprovacaoResultado) Then
                    strData += Space(1) + Left(hHoraAprovacaoResultado, 5) + ":00"
                End If
                strSql += "'" + strData + "', "
            End If

            strSql += totalRecurso.Replace(",", ".") + ", "
            strSql += totalFrete.Replace(",", ".") + ", "
            strSql += totalSeguro.Replace(",", ".") + ", "
            strSql += totalDespesaAcessoria.Replace(",", ".") + ", "
            strSql += "'" + impressoFechamentoCarga + "', "
            strSql += "'" + ufEmbarque + "', "
            strSql += "'" + localEmbarque + "', "
            strSql += "'" + obsFiscalNota + "', "
            strSql += "'" + obsNaoFiscalNota + "', "
            strSql += "'" + embarqueConferido + "', "
            strSql += "'" + auxiliar1 + "', "
            strSql += "'" + auxiliar2 + "', "
            strSql += "'" + statusRecebimento + "', "

            If dDataEncerramento = Nothing Then
                strSql += "null, "
            Else
                strData = dDataEncerramento.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(hHoraEncerramento) Then
                    strData += Space(1) + Left(hHoraEncerramento, 5) + ":00"
                End If
                strSql += "'" + strData + "', "
            End If

            strSql += "'" + exportadoIntegracaoProducao + "', "
            strSql += "'" + osLiberadoFinanceiro + "', "
            strSql += SeqAlteracaoEntrega + ", "

            If dDataChegada = Nothing Then
                strSql += "null, "
            Else
                strData = dDataChegada.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(hHoraChegada) Then
                    strData += Space(1) + Left(hHoraChegada, 5) + ":00"
                End If
                strSql += "'" + strData + "', "
            End If

            If dDataChegadaPrevista = Nothing Then
                strSql += "null, "
            Else
                strData = dDataChegadaPrevista.ToString("yyyy-MM-dd")
                If Not String.IsNullOrEmpty(hHoraChegadaPrevista) Then
                    strData += Space(1) + Left(hHoraChegadaPrevista, 5) + ":00"
                End If
                strSql += "'" + strData + "', "
            End If

            strSql += "'" + SAG + "', "
            strSql += "'" + IdOS + "', "
            strSql += "'" + ImprimirMatricial + "', "
            strSql += IIf(codTipoCobrancaOS = Nothing, "null", codTipoCobrancaOS) + " ) "

            stant = GetStatusAtual()

            ObjAcessoDados.ExecutarSql(strSql)

            Call VerificaEAlteraDataChegadaPrevistaChamado()
            Call VerificaEAlteraDataChegadaChamado()
            Call VerificaEAlteraDataEncerramentoPrevistoChamado()
            Call VerificaEAlteraDataEncerramentoChamado()
            Call VerificaEEncerraChamado(Me.codChamado, stant, statusDigitacao)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub VerificaEAlteraDataEncerramentoPrevistoChamado()
        Try
            Dim strSql As String = " select data_entrega, max(hora_entrega) hora_entrega from pedido_venda where (status_digitacao = 1 or abs(datediff(minute, data_alteracao, getdate())) <= 1 ) and cod_chamado = " + Me.codChamado + " group by data_entrega having data_entrega = max(data_entrega)"
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
            Dim dCheg As Date = Nothing
            Dim hCheg As String = ""
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("data_entrega")) Then
                    Return
                End If
                dCheg = CDate(dt.Rows.Item(0).Item("data_entrega")).ToString("dd/MM/yyyy")
                If Not IsDBNull(dt.Rows.Item(0).Item("hora_entrega")) AndAlso Not String.IsNullOrEmpty(dt.Rows.Item(0).Item("hora_entrega").ToString) Then
                    hCheg = Left(dt.Rows.Item(0).Item("hora_entrega").ToString.PadRight(5), 5)
                Else
                    hCheg = ""
                End If

            End If

            If dCheg <> Nothing Then
                Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
                objChamado.Empresa = Me.empresa
                objChamado.CodChamado = Me.codChamado
                If objChamado.Buscar() Then
                    objChamado.DataEncerramentoPrevista = dCheg.ToString("dd/MM/yyyy")
                    objChamado.HoraEncerramentoPrevista = hCheg
                    objChamado.Alterar(Me.empresa, Me.estabelecimento, Me.codChamado)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub VerificaEAlteraDataEncerramentoChamado()
        Try
            Dim strSql As String = " select data_encerramento from pedido_venda where (status_digitacao = 1 or abs(datediff(minute, data_alteracao, getdate())) <= 1 ) and cod_chamado = " + Me.codChamado
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
            Dim dCheg As Date = Nothing
            Dim hCheg As String = ""
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("data_encerramento")) Then
                    Return
                End If
                dCheg = CDate(dt.Rows.Item(0).Item("data_encerramento")).ToString("dd/MM/yyyy")
                hCheg = CDate(dt.Rows.Item(0).Item("data_encerramento")).ToString("HH:mm")
            End If

            If dCheg <> Nothing Then
                Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
                objChamado.Empresa = Me.empresa
                objChamado.CodChamado = Me.codChamado
                If objChamado.Buscar() Then
                    objChamado.DataEncerramento = dCheg.ToString("dd/MM/yyyy")
                    objChamado.HoraEncerramento = hCheg
                    objChamado.Alterar(Me.empresa, Me.estabelecimento, Me.codChamado)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub VerificaEEncerraChamado(ByVal lcodChamado As String, ByVal statusAnterior As String, ByVal statusAtual As String)
        Try
            Dim objTipoChamado As New UCLTipoChamado
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objParametrosManutencao As New UCLParametrosManutencao
            Dim horasConsumidas As Double = 0
            Dim horasContratadas As Double = 0
            Dim encerrar As Boolean = True

            objChamado.Empresa = empresa
            objChamado.CodChamado = lcodChamado

            If statusAnterior <> statusAtual AndAlso statusAtual = "2" Then
                If Not objChamado.ExistemOSsAbertas() Then
                    If objChamado.Buscar() Then

                        objParametrosManutencao.Buscar(objChamado.Empresa, objChamado.Estabelecimento)
                        If Not String.IsNullOrEmpty(objChamado.TipoChamado) Then
                            If objTipoChamado.Buscar(objChamado.Empresa, objChamado.TipoChamado) Then
                                If Not objTipoChamado.IsNull("encerrar_chamado_automaticamente") Then
                                    If objTipoChamado.GetConteudo("encerrar_chamado_automaticamente") <> "S" Then
                                        encerrar = False
                                    End If
                                End If
                            End If
                        End If

                        If encerrar AndAlso Not String.IsNullOrEmpty(objParametrosManutencao.GetConteudo("cod_status_final")) Then
                            If objChamado.CodStatus <> objParametrosManutencao.GetConteudo("cod_status_final") Then
                                objChamado.CodStatus = objParametrosManutencao.GetConteudo("cod_status_final")
                                objChamado.Alterar(empresa, estabelecimento, lcodChamado)
                                objChamado.EnviaEmailStatus(StrConexaoUsuario(Session("GlUsuario")), Session("GlEmpresa"), lcodChamado)
                            End If
                        End If

                        Dim codContrato As String = objChamado.Contrato
                        Dim dataIni As Date
                        Dim dataFim As Date
                        Dim objContrato As New UCLContratoManutencao
                        dataIni = CDate(objChamado.DataChamado)
                        dataIni = New Date(Year(dataIni), Month(dataIni), 1)
                        dataFim = dataIni.AddMonths(1).AddDays(-1)

                        horasContratadas = objContrato.GetQuantidadeHorasContratada(objChamado.Empresa, codContrato)
                        horasConsumidas = objContrato.GetQuantidadeHorasConsumidaNoPeriodo(objChamado.Empresa, objChamado.Estabelecimento, codContrato, dataIni, dataFim)

                        If horasContratadas > 0 AndAlso horasConsumidas > 0 Then
                            If ((horasConsumidas / horasContratadas) * 100) >= 80.0 AndAlso ((horasConsumidas / horasContratadas) * 100) < 100.0 Then
                                objChamado.EnviaEmailConsumoHoras(StrConexaoUsuario(Session("GlUsuario")), objChamado.Empresa, objChamado.CodChamado)
                            End If
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function isAgenteTecnicoInformado() As Boolean
        Try
            Dim objPedidoVendaAgenteTecnico As New UCLPedidoVendaAgenteTecnico(StrConexaoUsuario(Session("GlUsuario")))
            Dim agentes As List(Of UCLAgenteTecnico)
            objPedidoVendaAgenteTecnico.Empresa = Me.empresa
            objPedidoVendaAgenteTecnico.Estabelecimento = Me.estabelecimento
            objPedidoVendaAgenteTecnico.CodPedidoVenda = Me.codPedidoVenda
            agentes = objPedidoVendaAgenteTecnico.AgentesTecnicos()
            If agentes.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Alterar()
        Try
            Dim strSql As String = ""
            Dim stant As String
            Dim msgErro As String = ""

            codNaturOper = IIf(codNaturOper = "" OrElse codNaturOper = "0" OrElse codNaturOper = "-1", "null", "'" + codNaturOper + "'")
            codPedidoRepresentante = IIf(String.IsNullOrEmpty(codPedidoRepresentante), "null", codPedidoRepresentante)
            codEmitente = IIf(String.IsNullOrEmpty(codEmitente), "null", codEmitente)
            codTransportador = IIf(String.IsNullOrEmpty(codTransportador), "null", codTransportador)
            codRepresentante = IIf(String.IsNullOrEmpty(codRepresentante), "null", codRepresentante)
            percComissao = IIf(String.IsNullOrEmpty(percComissao), "null", percComissao)
            codAgenteVenda = IIf(String.IsNullOrEmpty(codAgenteVenda), "null", codAgenteVenda)
            codCondPagto = IIf(String.IsNullOrEmpty(codCondPagto), "null", codCondPagto)
            codNegociacaoCliente = IIf(String.IsNullOrEmpty(codNegociacaoCliente), "null", codNegociacaoCliente)
            codFormaPagamento = IIf(String.IsNullOrEmpty(codFormaPagamento), "null", codFormaPagamento)
            codObsPadrao = IIf(String.IsNullOrEmpty(codObsPadrao), "null", codObsPadrao)
            codCanalVenda = IIf(String.IsNullOrEmpty(codCanalVenda), "null", codCanalVenda)
            situacaoFaturamento = IIf(String.IsNullOrEmpty(situacaoFaturamento), "null", situacaoFaturamento)
            situacaoEntrega = IIf(String.IsNullOrEmpty(situacaoEntrega), "null", situacaoEntrega)
            situacaoAprovacao1 = IIf(String.IsNullOrEmpty(situacaoAprovacao1), "null", situacaoAprovacao1)
            situacaoAprovacao2 = IIf(String.IsNullOrEmpty(situacaoAprovacao2), "null", situacaoAprovacao2)
            statusDigitacao = IIf(String.IsNullOrEmpty(statusDigitacao), "null", statusDigitacao)
            totalMercadoria = IIf(String.IsNullOrEmpty(totalMercadoria), "null", totalMercadoria)
            totalMercadoriaOrig = IIf(String.IsNullOrEmpty(totalMercadoriaOrig), "null", totalMercadoriaOrig)
            totalIcms = IIf(String.IsNullOrEmpty(totalIcms), "null", totalIcms)
            totalIpi = IIf(String.IsNullOrEmpty(totalIpi), "null", totalIpi)
            totalDesconto = IIf(String.IsNullOrEmpty(totalDesconto), "null", totalDesconto)
            totalPedido = IIf(String.IsNullOrEmpty(totalPedido), "null", totalPedido)
            totalDespesas = IIf(String.IsNullOrEmpty(totalDespesas), "null", totalDespesas)
            tipoFrete = IIf(String.IsNullOrEmpty(tipoFrete), "null", tipoFrete)
            baseIcms = IIf(String.IsNullOrEmpty(baseIcms), "null", baseIcms)
            baseIcmsSubstituicao = IIf(String.IsNullOrEmpty(baseIcmsSubstituicao), "null", baseIcmsSubstituicao)
            icmsTributado = IIf(String.IsNullOrEmpty(icmsTributado), "null", icmsTributado)
            icmsIsento = IIf(String.IsNullOrEmpty(icmsIsento), "null", icmsIsento)
            icmsOutras = IIf(String.IsNullOrEmpty(icmsOutras), "null", icmsOutras)
            icmsSubstituicao = IIf(String.IsNullOrEmpty(icmsSubstituicao), "null", icmsSubstituicao)
            baseIpi = IIf(String.IsNullOrEmpty(baseIpi), "null", baseIpi)
            ipiTributado = IIf(String.IsNullOrEmpty(ipiTributado), "null", ipiTributado)
            ipiIsento = IIf(String.IsNullOrEmpty(ipiIsento), "null", ipiIsento)
            ipiOutras = IIf(String.IsNullOrEmpty(ipiOutras), "null", ipiOutras)
            baseCofins = IIf(String.IsNullOrEmpty(baseCofins), "null", baseCofins)
            cofins = IIf(String.IsNullOrEmpty(cofins), "null", cofins)
            basePis = IIf(String.IsNullOrEmpty(basePis), "null", basePis)
            pis = IIf(String.IsNullOrEmpty(pis), "null", pis)
            baseCsll = IIf(String.IsNullOrEmpty(baseCsll), "null", baseCsll)
            csll = IIf(String.IsNullOrEmpty(csll), "null", csll)
            baseIrrf = IIf(String.IsNullOrEmpty(baseIrrf), "null", baseIrrf)
            irrf = IIf(String.IsNullOrEmpty(irrf), "null", irrf)
            baseIssqn = IIf(String.IsNullOrEmpty(baseIssqn), "null", baseIssqn)
            issqn = IIf(String.IsNullOrEmpty(issqn), "null", issqn)
            baseInss = IIf(String.IsNullOrEmpty(baseInss), "null", baseInss)
            inss = IIf(String.IsNullOrEmpty(inss), "null", inss)
            percDesconto = IIf(String.IsNullOrEmpty(percDesconto), "null", percDesconto)
            periodo = IIf(String.IsNullOrEmpty(periodo), "null", periodo)
            codUsuarioCadastro = IIf(String.IsNullOrEmpty(codUsuarioCadastro), "null", codUsuarioCadastro)
            codUsuarioAlteracao = IIf(String.IsNullOrEmpty(codUsuarioAlteracao), "null", codUsuarioAlteracao)
            codUsuarioAprovacao1 = IIf(String.IsNullOrEmpty(codUsuarioAprovacao1), "null", codUsuarioAprovacao1)
            codUsuarioAprovacao2 = IIf(String.IsNullOrEmpty(codUsuarioAprovacao2), "null", codUsuarioAprovacao2)
            codLicenciador = IIf(String.IsNullOrEmpty(codLicenciador), "null", codLicenciador)
            codRomaneio = IIf(String.IsNullOrEmpty(codRomaneio), "null", codRomaneio)
            codChamado = IIf(String.IsNullOrEmpty(codChamado), "null", codChamado)
            codObra = IIf(String.IsNullOrEmpty(codObra), "null", codObra)
            codSituacaoProducao = IIf(String.IsNullOrEmpty(codSituacaoProducao), "null", codSituacaoProducao)
            aprovadoResultado = IIf(String.IsNullOrEmpty(aprovadoResultado), "null", "'" + aprovadoResultado + "'")
            impressoFechamentoCarga = IIf(String.IsNullOrEmpty(impressoFechamentoCarga), "null", "'" + impressoFechamentoCarga + "'")
            faturamentoAssociado = IIf(String.IsNullOrEmpty(faturamentoAssociado), "null", "'" + faturamentoAssociado + "'")
            obsFiscalNota = IIf(String.IsNullOrEmpty(obsFiscalNota), "null", "'" + obsFiscalNota + "'")
            obsNaoFiscalNota = IIf(String.IsNullOrEmpty(obsNaoFiscalNota), "null", "'" + obsNaoFiscalNota + "'")
            codPedidoForcaVendas = IIf(String.IsNullOrEmpty(codPedidoForcaVendas), "null", codPedidoForcaVendas)
            codTpAssociado = IIf(String.IsNullOrEmpty(codTpAssociado), "null", codTpAssociado)
            codUsuarioAprovacaoResultado = IIf(String.IsNullOrEmpty(codUsuarioAprovacaoResultado), "null", codUsuarioAprovacaoResultado)
            totalRecurso = IIf(String.IsNullOrEmpty(totalRecurso), "null", totalRecurso)
            totalFrete = IIf(String.IsNullOrEmpty(totalFrete), "null", totalFrete)
            totalSeguro = IIf(String.IsNullOrEmpty(totalSeguro), "null", totalSeguro)
            totalDespesaAcessoria = IIf(String.IsNullOrEmpty(totalDespesaAcessoria), "null", totalDespesaAcessoria)
            statusRecebimento = IIf(String.IsNullOrEmpty(statusRecebimento), "null", statusRecebimento)
            osLiberadoFinanceiro = IIf(String.IsNullOrEmpty(osLiberadoFinanceiro), "N", osLiberadoFinanceiro)
            IdOS = IIf(String.IsNullOrEmpty(IdOS), "N", IdOS)
            ImprimirMatricial = IIf(String.IsNullOrEmpty(ImprimirMatricial), "N", ImprimirMatricial)
            If String.IsNullOrEmpty(SeqAlteracaoEntrega) Then SeqAlteracaoEntrega = 0

            If Not IgnoraValidacoes Then
                If statusDigitacao <> GetStatusAtual() Then
                    If statusDigitacao = "2" Then
                        If Not TemItens() Then
                            msgErro += "Antes de encerrar a OS é necessário informar o(s) serviço(s) realizado(s).</br>"
                        End If
                        If Not TodosOsItensTemCodItemPreenchido() Then
                            msgErro += "Não é possível encerrar a OS sem que todos os serviços realizados estejam com o campo item preenchido.</br>"
                        End If
                        If dDataEncerramento = Nothing Then
                            msgErro += "Não é possível encerrar a OS sem o preenchimento do campo Data Encerramento.<br/>"
                        End If
                        If String.IsNullOrEmpty(hHoraEncerramento) Then
                            msgErro += "Não é possível encerrar a OS sem o preenchimento do campo Hora Encerramento.<br/>"
                        End If
                        If dDataChegada = Nothing Then
                            msgErro += "Não é possível encerrar a OS sem o preenchimento do campo Data Chegada.<br/>"
                        End If
                        If String.IsNullOrEmpty(hHoraChegada) Then
                            msgErro += "Não é possível encerrar a OS sem o preenchimento do campo Hora Chegada.<br/>"
                        End If
                        If Not isAgenteTecnicoInformado() Then
                            msgErro += "Não é possível encerrar a OS sem preencher o Agente Técnico responsável pelo atendimento.<br/>"
                        End If
                        If Not String.IsNullOrEmpty(msgErro) Then
                            Throw New Exception(msgErro)
                        End If
                    End If
                End If
            End If

            'strSql = "call sp_sysvar(); "
            'strSql += "update pedido_venda_item "
            'strSql += "   set cod_natur_oper    = '" + codNaturOper + "'"
            'strSql += " where empresa           = " + empresa
            'strSql += "   and estabelecimento   = " + estabelecimento
            'strSql += "   and cod_pedido_venda  = " + codPedidoVenda
            'ObjAcessoDados.ExecutarSql(strSql)

            strSql = "call sp_sysvar(); "
            strSql += "update pedido_venda "
            strSql += "   set cod_pedido_cliente               = '" + codPedidoCliente + "', "
            strSql += "       cod_pedido_representante         = " + codPedidoRepresentante + ", "
            strSql += "       cod_emitente                     = " + codEmitente + ", "
            strSql += "       cnpj_faturamento                 = '" + cnpjFaturamento + "', "
            strSql += "       cnpj_cobranca                    = '" + cnpjCobranca + "', "
            strSql += "       cnpj_entrega                     = '" + cnpjEntrega + "', "
            strSql += "       cod_natur_oper                   = " + codNaturOper + ", "
            strSql += "       cod_transportador                = " + codTransportador + ", "
            strSql += "       cod_representante                = " + codRepresentante + ", "
            strSql += "       perc_comissao                    = " + percComissao.Replace(",", ".") + ", "
            strSql += "       cod_agente_venda                 = " + codAgenteVenda + ", "
            strSql += "       cod_indicador                    = '" + codIndicador + "', "
            strSql += "       cod_cond_pagto                   = " + codCondPagto + ", "
            strSql += "       cod_negociacao_cliente           = " + codNegociacaoCliente + ", "
            strSql += "       cod_forma_pagamento              = " + codFormaPagamento + ", "
            strSql += "       cod_obs_padrao                   = " + codObsPadrao + ", "
            strSql += "       cod_canal_venda                  = " + codCanalVenda + ", "
            strSql += "       seq_alteracao_entrega            = " + SeqAlteracaoEntrega + ", "
            strSql += "       cod_cfps                         = " + IIf(String.IsNullOrEmpty(codCfps), "null", "'" + codCfps + "'") + ", "
            strSql += "       data_emissao                     = " + IIf(dDataEmissao = Nothing, "null", "'" + dDataEmissao.ToString("yyyy-MM-dd") + "'") + ", "
            strSql += "       situacao_faturamento             = " + situacaoFaturamento + ", "
            strSql += "       situacao_entrega                 = " + situacaoEntrega + ", "
            strSql += "       situacao_aprovacao1              = " + situacaoAprovacao1 + ", "
            strSql += "       situacao_aprovacao2              = " + situacaoAprovacao2 + ", "
            strSql += "       status_digitacao                 = " + statusDigitacao + ", "
            strSql += "       id_os                            = '" + IdOS + "', "
            strSql += "       imprimir_matricial               = '" + ImprimirMatricial + "', "
            strSql += "       sag                              = '" + SAG + "', "
            strSql += "       data_inicio_execucao             = " + IIf(dDataInicioExecucao = Nothing, "null", "'" + dDataInicioExecucao.ToString("yyyy-MM-dd") + IIf(Not String.IsNullOrEmpty(hHoraInicioExecucao), Space(1) + Left(hHoraInicioExecucao, 5) + ":00", "") + "'") + ", "
            strSql += "       data_termino_execucao            = " + IIf(dDataTerminoExecucao = Nothing, "null", "'" + dDataTerminoExecucao.ToString("yyyy-MM-dd") + IIf(Not String.IsNullOrEmpty(hHoraTerminoExecucao), Space(1) + Left(hHoraTerminoExecucao, 5) + ":00", "") + "'") + ", "
            'strSql += "       total_mercadoria                 = " + totalMercadoria.Replace(",", ".") + ", "
            'strSql += "       total_mercadoria_orig            = " + totalMercadoriaOrig.Replace(",", ".") + ", "
            'strSql += "       total_icms                       = " + totalIcms.Replace(",", ".") + ", "
            'strSql += "       total_ipi                        = " + totalIpi.Replace(",", ".") + ", "
            'strSql += "       total_desconto                   = " + totalDesconto.Replace(",", ".") + ", "
            'strSql += "       total_pedido                     = " + totalPedido.Replace(",", ".") + ", "
            'strSql += "       total_despesas                   = " + totalDespesas.Replace(",", ".") + ", "
            strSql += "       tipo_frete                       = " + tipoFrete.Replace(",", ".") + ", "
            'strSql += "       base_icms                        = " + baseIcms.Replace(",", ".") + ", "
            'strSql += "       base_icms_substituicao           = " + baseIcmsSubstituicao.Replace(",", ".") + ", "
            'strSql += "       icms_tributado                   = " + icmsTributado.Replace(",", ".") + ", "
            'strSql += "       icms_isento                      = " + icmsIsento.Replace(",", ".") + ", "
            'strSql += "       icms_outras                      = " + icmsOutras.Replace(",", ".") + ", "
            'strSql += "       icms_substituicao                = " + icmsSubstituicao.Replace(",", ".") + ", "
            'strSql += "       base_ipi                         = " + baseIpi.Replace(",", ".") + ", "
            'strSql += "       ipi_tributado                    = " + ipiTributado.Replace(",", ".") + ", "
            'strSql += "       ipi_isento                       = " + ipiIsento.Replace(",", ".") + ", "
            'strSql += "       ipi_outras                       = " + ipiOutras.Replace(",", ".") + ", "
            'strSql += "       base_cofins                      = " + baseCofins.Replace(",", ".") + ", "
            'strSql += "       cofins                           = " + cofins.Replace(",", ".") + ", "
            'strSql += "       base_pis                         = " + basePis.Replace(",", ".") + ", "
            'strSql += "       pis                              = " + pis.Replace(",", ".") + ", "
            'strSql += "       base_csll                        = " + baseCsll.Replace(",", ".") + ", "
            'strSql += "       csll                             = " + csll.Replace(",", ".") + ", "
            'strSql += "       base_irrf                        = " + baseIrrf.Replace(",", ".") + ", "
            'strSql += "       irrf                             = " + irrf.Replace(",", ".") + ", "
            'strSql += "       base_issqn                       = " + baseIssqn.Replace(",", ".") + ", "
            'strSql += "       issqn                            = " + issqn.Replace(",", ".") + ", "
            'strSql += "       base_inss                        = " + baseInss.Replace(",", ".") + ", "
            'strSql += "       inss                             = " + inss.Replace(",", ".") + ", "
            strSql += "       observacao                       = '" + observacao + "', "
            strSql += "       perc_desconto                    = " + percDesconto.Replace(",", ".") + ", "
            strSql += "       data_entrega                     = " + IIf(dDataEntrega = Nothing, "null", "'" + dDataEntrega.ToString("yyyy-MM-dd") + "'") + ", "
            strSql += "       hora_entrega                     ='" + HoraEntrega + "', "
            strSql += "       periodo                          = " + periodo + ", "
            'strSql += "       cod_usuario_cadastro             = " + codUsuarioCadastro + ", "
            strSql += "       cod_usuario_alteracao            = " + codUsuarioAlteracao + ", "
            strSql += "       cod_usuario_aprovacao1           = " + codUsuarioAprovacao1 + ", "
            strSql += "       cod_usuario_aprovacao2           = " + codUsuarioAprovacao2 + ", "
            strSql += "       data_alteracao                   = " + IIf(dDataAlteracao = Nothing, "null", "'" + dDataAlteracao.ToString("yyyy-MM-dd") + IIf(Not String.IsNullOrEmpty(hHoraAlteracao), Space(1) + Left(hHoraAlteracao, 5) + ":00", "") + "'") + ", "
            strSql += "       cod_licenciador                  = " + codLicenciador + ", "
            'strSql += "       cod_romaneio                     = " + codRomaneio + ", "
            strSql += "       cod_chamado                      = " + codChamado + ", "
            strSql += "       id_contrato                      = '" + idContrato + "', "
            strSql += "       impresso_op                      = '" + impressoOp + "', "
            strSql += "       observacao_nao_fiscal            = '" + observacaoNaoFiscal + "', "
            strSql += "       observacao_producao              = '" + observacaoProducao + "', "
            strSql += "       pedido_producao                  = '" + pedidoProducao + "', "
            strSql += "       cod_obra                         = " + codObra + ", "
            strSql += "       status_recebimento               = " + statusRecebimento + ", "
            strSql += "       aprovado_resultado               = " + aprovadoResultado + ", "
            strSql += "       cod_situacao_producao            = " + codSituacaoProducao + ", "
            'strSql += "       cod_pedido_forca_vendas          = " + codPedidoForcaVendas + ", "
            'strSql += "       pedido_forca_vendas              = '" + pedidoForcaVendas + "', "
            strSql += "       aux_1                            = '" + aux1 + "', "
            strSql += "       faturamento_associado            = " + faturamentoAssociado + ", "
            strSql += "       cod_tp_associado                 = " + codTpAssociado + ", "
            strSql += "       cod_usuario_aprovacao_resultado  = " + codUsuarioAprovacaoResultado + ", "
            strSql += "       data_aprovacao_resultado         = " + IIf(dDataAprovacaoResultado = Nothing, "null", "'" + dDataAprovacaoResultado.ToString("yyyy-MM-dd") + IIf(Not String.IsNullOrEmpty(hHoraAprovacaoResultado), Space(1) + Left(hHoraAprovacaoResultado, 5) + ":00", "") + "'") + ", "
            'strSql += "       total_recurso                    = " + totalRecurso.Replace(",", ".") + ", "
            'strSql += "       total_frete                      = " + totalFrete.Replace(",", ".") + ", "
            'strSql += "       total_seguro                     = " + totalSeguro.Replace(",", ".") + ", "
            'strSql += "       total_despesa_acessoria          = " + totalDespesaAcessoria.Replace(",", ".") + ", "
            strSql += "       impresso_fechamento_carga        = " + impressoFechamentoCarga + ", "
            strSql += "       uf_embarque                      = '" + ufEmbarque + "', "
            strSql += "       local_embarque                   = '" + localEmbarque + "', "
            strSql += "       obs_fiscal_nota                  = " + obsFiscalNota + ", "
            strSql += "       obs_nao_fiscal_nota              = " + obsNaoFiscalNota + ","
            strSql += "       embarque_conferido               = " + IIf(String.IsNullOrEmpty(embarqueConferido), "null", "'" + embarqueConferido + "'") + ", "
            strSql += "       auxiliar_1                       = '" + auxiliar1 + "', "
            strSql += "       auxiliar_2                       = '" + auxiliar2 + "', "
            strSql += "       data_encerramento                = " + IIf(dDataEncerramento = Nothing, "null", "'" + dDataEncerramento.ToString("yyyy-MM-dd") + IIf(Not String.IsNullOrEmpty(hHoraEncerramento), Space(1) + Left(hHoraEncerramento, 5) + ":00", "") + "'") + ", "
            'strSql += "       exportado_integracao_producao    = '" + exportadoIntegracaoProducao + "', "
            'strSql += "       os_liberado_financeiro    = '" + osLiberadoFinanceiro + "', "
            strSql += "       data_chegada            = " + IIf(dDataChegada = Nothing, "null", "'" + dDataChegada.ToString("yyyy-MM-dd") + IIf(Not String.IsNullOrEmpty(hHoraChegada), Space(1) + Left(hHoraChegada, 5) + ":00", "") + "'") + ", "
            strSql += "       data_chegada_prevista   = " + IIf(dDataChegadaPrevista = Nothing, "null", "'" + dDataChegadaPrevista.ToString("yyyy-MM-dd") + IIf(Not String.IsNullOrEmpty(hHoraChegadaPrevista), Space(1) + Left(hHoraChegadaPrevista, 5) + ":00", "") + "'") + ", "
            strSql += "       cod_tipo_cobranca_os    = " + IIf(codTipoCobrancaOS = Nothing, "null", codTipoCobrancaOS)
            strSql += " where empresa           = " + empresa
            strSql += "   and estabelecimento   = " + estabelecimento
            strSql += "   and cod_pedido_venda  = " + codPedidoVenda

            stant = GetStatusAtual()

            ObjAcessoDados.ExecutarSql(strSql)

            Call VerificaEAlteraDataChegadaPrevistaChamado()
            Call VerificaEAlteraDataChegadaChamado()
            Call VerificaEAlteraDataEncerramentoPrevistoChamado()
            Call VerificaEAlteraDataEncerramentoChamado()
            Call VerificaEEncerraChamado(Me.codChamado, stant, statusDigitacao)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub VerificaEAlteraDataChegadaChamado()
        Try
            Dim strSql As String = " select max(data_chegada) data_chegada from pedido_venda where (status_digitacao = 1 or abs(datediff(minute, data_alteracao, getdate())) <= 1 ) and cod_chamado = " + Me.codChamado
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
            Dim dCheg As Date = Nothing
            Dim hCheg As String = ""
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("data_chegada")) Then
                    Return
                End If
                dCheg = CDate(dt.Rows.Item(0).Item("data_chegada")).ToString("dd/MM/yyyy")
                hCheg = CDate(dt.Rows.Item(0).Item("data_chegada")).ToString("HH:mm")
            End If

            If dCheg <> Nothing Then
                Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
                objChamado.Empresa = Me.empresa
                objChamado.CodChamado = Me.codChamado
                If objChamado.Buscar() Then
                    objChamado.DataChegada = dCheg.ToString("dd/MM/yyyy")
                    objChamado.HoraChegada = hCheg
                    objChamado.Alterar(Me.empresa, Me.estabelecimento, Me.codChamado)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub VerificaEAlteraDataChegadaPrevistaChamado()
        Try
            Dim strSql As String = " select max(data_chegada_prevista) data_chegada_prevista from pedido_venda where (status_digitacao = 1 or abs(datediff(minute, data_alteracao, getdate())) <= 1 ) and cod_chamado = " + Me.codChamado
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
            Dim dChegPrev As Date = Nothing
            Dim hChegPrev As String = ""
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("data_chegada_prevista")) Then
                    Return
                End If
                dChegPrev = CDate(dt.Rows.Item(0).Item("data_chegada_prevista")).ToString("dd/MM/yyyy")
                hChegPrev = CDate(dt.Rows.Item(0).Item("data_chegada_prevista")).ToString("HH:mm")
            End If

            If dChegPrev <> Nothing Then
                Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
                objChamado.Empresa = Me.empresa
                objChamado.CodChamado = Me.codChamado
                If objChamado.Buscar() Then
                    objChamado.DataChegadaPrevista = dChegPrev.ToString("dd/MM/yyyy")
                    objChamado.HoraChegadaPrevista = hChegPrev
                    objChamado.Alterar(Me.empresa, Me.estabelecimento, Me.codChamado)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_pedido_venda),0) + 1 max from pedido_venda where empresa = " + empresa + " and estabelecimento = " + estabelecimento
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Private Function BuscarPorCodChamado() As Boolean
        Try
            Dim strSql As String
            Dim dt As DataTable

            strSql = "  select cod_pedido_venda "
            strSql += "   from pedido_venda "
            strSql += "  where empresa         = " + empresa
            strSql += "    and estabelecimento = " + estabelecimento
            strSql += "    and cod_chamado     = " + codChamado
            dt = ObjAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count = 0 Then
                Return False
            Else
                codPedidoVenda = dt.Rows.Item(0).Item("cod_pedido_venda").ToString
                Return Buscar()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TemItens() As Boolean
        Try
            Dim ret As Boolean
            Dim strSql As String
            Dim dt As DataTable

            strSql = " select 1 a"
            strSql += "  from pedido_venda_item "
            strSql += " where empresa          = " + empresa
            strSql += "   and estabelecimento  = " + estabelecimento
            strSql += "   and cod_pedido_venda = " + codPedidoVenda
            dt = ObjAcessoDados.BuscarDados(strSql)

            ret = dt.Rows.Count > 0

            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TodosOsItensTemCodItemPreenchido() As Boolean
        Try
            Dim StrSql As String
            Dim dt As DataTable
            Dim qtd As Long

            StrSql = " select count(1) qtd "
            StrSql += "  from pedido_venda_item "
            StrSql += " where empresa          = " + empresa
            StrSql += "   and estabelecimento  = " + estabelecimento
            StrSql += "   and cod_pedido_venda = " + codPedidoVenda
            StrSql += "   and cod_item is null "

            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                qtd = dt.Rows.Item(0).Item("qtd").ToString
                If qtd = 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir()
        Try
            Dim StrSql As String = ""

            StrSql = " delete from pedido_venda where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_pedido_venda = " + codPedidoVenda
            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetStatusAtual() As String
        Try
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = " select status_digitacao "
            StrSql += "  from pedido_venda "
            StrSql += " where empresa          = " + empresa
            StrSql += "   and estabelecimento  = " + estabelecimento
            StrSql += "   and cod_pedido_venda = " + codPedidoVenda

            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("status_digitacao").ToString
            Else
                Return ""
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SetAlteradoTecnico(ByVal pAlteradoTecnico As String)
        Try
            Dim StrSql As String = ""

            StrSql += " update pedido_venda set alterado_tecnico = '" + pAlteradoTecnico + "'"
            StrSql += " where empresa          = " + empresa
            StrSql += "   and estabelecimento  = " + estabelecimento
            StrSql += "   and cod_pedido_venda = " + codPedidoVenda
            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetFollowUps(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodPedidoVenda As String) As List(Of UCLFollowUpEmitente)
        Try
            Dim f As New List(Of UCLFollowUpEmitente)
            Dim strSql As String = "select empresa, cod_emitente, seq_follow_up from follow_up_emitente where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento + " and cod_pedido_venda = " + codPedidoVenda + " order by seq_follow_up"
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
            For Each row As DataRow In dt.Rows
                Dim objFollowUpEmitente As New UCLFollowUpEmitente(StrConexao)
                objFollowUpEmitente.Empresa = row.Item("empresa")
                objFollowUpEmitente.CodEmitente = row.Item("cod_emitente")
                objFollowUpEmitente.SeqFollowUP = row.Item("seq_follow_up")
                objFollowUpEmitente.Buscar()
                f.Add(objFollowUpEmitente)
            Next
            Return f
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetNF(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodPedidoVenda As String) As String
        Try
            Dim strSql As String = "select first isnull(nff.serie || '/' || nff.cod_nfs,'') nf from nfs_faturamento nff inner join nfs on nff.empresa = nfs.empresa and nff.estabelecimento = nfs.estabelecimento and nff.serie = nfs.serie and nff.cod_nfs = nfs.cod_nfs where nff.empresa = " + pEmpresa + " and nff.estabelecimento = " + pEstabelecimento + " and nff.cod_pedido_venda = " + pCodPedidoVenda + " and nfs.situacao = 1"
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("nf").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class