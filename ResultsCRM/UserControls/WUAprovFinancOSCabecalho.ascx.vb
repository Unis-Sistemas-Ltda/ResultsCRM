Public Partial Class WUAprovFinancOSCabecalho
    Inherits System.Web.UI.UserControl

    Public Property Empresa() As String
        Get
            Return LblEmpresa.Text
        End Get
        Set(ByVal value As String)
            LblEmpresa.Text = value
        End Set
    End Property

    Public Property Estabelecimento() As String
        Get
            Return LblEstabelecimento.Text
        End Get
        Set(ByVal value As String)
            LblEstabelecimento.Text = value
        End Set
    End Property

    Public Property CodAtendimento() As String
        Get
            Return LblCodAtendimento.Text
        End Get
        Set(ByVal value As String)
            LblCodAtendimento.Text = value
        End Set
    End Property

    Public Property CodPedidoVenda() As String
        Get
            Return TxtCodPedidoVenda.Text
        End Get
        Set(ByVal value As String)
            TxtCodPedidoVenda.Text = value
        End Set
    End Property

    Public Property Acao() As String
        Get
            Return LblAcao.Text
        End Get
        Set(ByVal value As String)
            LblAcao.Text = value
        End Set
    End Property


    Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario").tostring))
    Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario").tostring))
    Dim objClienteFinanceiro As New UCLClienteFinanceiro
    Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario").tostring))
    Dim objEndereco As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario").tostring))


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TxtDataEntrega.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtHoraEncerramento.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            If Not IsPostBack Then
                If String.IsNullOrEmpty(CodAtendimento) Then
                    BtnVoltar.Visible = False
                End If
                Call CarregaFormulario()
            Else
                Call ChecaPesquisaCliente()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub


    Protected Sub CarregaFormulario()
        Try
            Call CarregaTipoCobrancaOS()

            If Acao = "INCLUIR" Then
                
            ElseIf Acao = "ALTERAR" Then
                TxtCodPedidoVenda.Enabled = False
                DdlStatusRecebimento.Enabled = False
                DdlStatus.Enabled = False
                TxtDataEncerramento.Enabled = False
                TxtDataEntrega.Enabled = False
                TxtHoraEncerramento.Enabled = False
                TxtHoraEntrega.Enabled = False
                BtnAlterarChamado.Visible = False
                TxtDataChegada.Enabled = False
                TxtHoraChegada.Enabled = False
                TxtDataChegadaPrevista.Enabled = False
                TxtHoraChegadaPrevista.Enabled = False

                objPedidoVenda.empresa = Empresa
                objPedidoVenda.estabelecimento = Estabelecimento
                objPedidoVenda.codPedidoVenda = CodPedidoVenda
                objPedidoVenda.Buscar()

                TxtCodPedidoVenda.Text = objPedidoVenda.codPedidoVenda
                TxtCliente.Text = objPedidoVenda.codEmitente
                CarregaCliente()
                CodAtendimento = objPedidoVenda.codChamado

                TxtSag.Text = objPedidoVenda.SAG
                LblCodCanalVenda.Text = objPedidoVenda.codCanalVenda
                LblCodCondPagto.Text = objPedidoVenda.codCondPagto
                LblCodFormaPagamento.Text = objPedidoVenda.codFormaPagamento
                LblCodIndicador.Text = objPedidoVenda.codIndicador
                LblCodNaturOper.Text = objPedidoVenda.codNaturOper
                LblTipoFrete.Text = objPedidoVenda.tipoFrete
                TxtDataEntrega.Text = objPedidoVenda.dataEntrega
                TxtHoraEntrega.Text = objPedidoVenda.HoraEntrega
                TxtDataChegada.Text = objPedidoVenda.DataChegada
                TxtHoraChegada.Text = objPedidoVenda.hHoraChegada
                TxtDataChegadaPrevista.Text = objPedidoVenda.DataChegadaPrevista
                TxtHoraChegadaPrevista.Text = objPedidoVenda.hHoraChegadaPrevista
                If objPedidoVenda.ImprimirMatricial = "S" Then
                    CbxImprimirMatricial.Checked = True
                Else
                    CbxImprimirMatricial.Checked = False
                End If

                If objPedidoVenda.dDataEncerramento <> Nothing Then
                    TxtDataEncerramento.Text = objPedidoVenda.dDataEncerramento.ToString("dd/MM/yyyy")
                Else
                    TxtDataEncerramento.Text = ""
                End If
                TxtHoraEncerramento.Text = objPedidoVenda.hHoraEncerramento
                DdlStatus.SelectedValue = objPedidoVenda.statusDigitacao
                DdlStatusRecebimento.SelectedValue = objPedidoVenda.statusRecebimento
                TxtNrChamado.Text = objPedidoVenda.codChamado
                DdlStatusAprovFinancOS.SelectedValue = objPedidoVenda.osLiberadoFinanceiro
                DdlTipoCobrancaOS.SelectedValue = objPedidoVenda.codTipoCobrancaOS


                If LblCodCanalVenda.Text.Trim = "0" Then
                    LblCodCanalVenda.Text = ""
                End If

                If LblCodCondPagto.Text.Trim = "0" Then
                    LblCodCondPagto.Text = ""
                End If

                If LblCodFormaPagamento.Text.Trim = "0" Then
                    LblCodFormaPagamento.Text = ""
                End If

                If LblCodNaturOper.Text.Trim = "0" Then
                    LblCodNaturOper.Text = ""
                End If

                TxtObservacao.Text = objPedidoVenda.observacao

                BtnGravar.Text = "Salvar"
                BtnImprimirOS.Visible = True

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaCNPJ()
        Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
        If Not String.IsNullOrEmpty(TxtCliente.Text) Then
            objEnderecoEmitente.CodEmitente = TxtCliente.Text
            objEnderecoEmitente.FillDropDownCNPJ(DdlCNPJ, True)
        End If
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim statusAnterior As String
            Dim statusAtual As String
            Dim alterouCodPedidoVenda As Boolean = False
            If IsDigitacaoOK() Then
                objPedido.empresa = Empresa
                objPedido.estabelecimento = Estabelecimento
                If Acao = "INCLUIR" Then
                    objPedido.codPedidoVenda = TxtCodPedidoVenda.Text 'objPedido.GetProximoCodigo()
                    If objPedido.Buscar() Then
                        TxtCodPedidoVenda.Text = objPedido.GetProximoCodigo()
                        objPedido.codPedidoVenda = TxtCodPedidoVenda.Text
                        alterouCodPedidoVenda = True
                    End If
                    objPedido = CarregaObjeto(objPedido)
                    statusAnterior = ""
                    objPedido.Incluir()
                    TxtCodPedidoVenda.Text = objPedido.codPedidoVenda
                    Session("SAtCodPedido") = objPedido.codPedidoVenda
                    BtnGravar.Text = "Salvar"
                    BtnImprimirOS.Visible = True
                    TxtCodPedidoVenda.Enabled = False
                Else
                    objPedido.codPedidoVenda = CodPedidoVenda
                    objPedido.Buscar()
                    objPedido.codChamado = IIf(String.IsNullOrEmpty(TxtNrChamado.Text), objPedido.codChamado, TxtNrChamado.Text)
                    statusAnterior = objPedido.statusDigitacao
                    statusAtual = DdlStatus.SelectedValue

                    objPedido = CarregaObjeto(objPedido)
                    If statusAnterior = "2" And statusAtual = "2" Then
                        objPedido.statusDigitacao = "1"
                        objPedido.Alterar()
                    End If

                    objPedido.Alterar()

                    If statusAnterior = "2" And statusAtual = "2" Then
                        objPedido.IgnoraValidacoes = True
                        objPedido.statusDigitacao = "2"
                        objPedido.Alterar()
                    End If

                End If

                If Not String.IsNullOrEmpty(CodAtendimento) Then
                    Call objPedido.VerificaEEncerraChamado(IIf(String.IsNullOrEmpty(TxtNrChamado.Text), CodAtendimento, TxtNrChamado.Text), statusAnterior, objPedido.statusDigitacao)
                End If

                LblErro.Text = "Dados salvos com sucesso."

                If alterouCodPedidoVenda Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('O número da OS foi alterado para " + TxtCodPedidoVenda.Text + ".');", True)
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Function IsDigitacaoOK() As Boolean
        Try
            Dim objAgenteVendas As New UCLAgenteVendas

            LblErro.Text = ""

            objAgenteVendas.Codigo = Session("GlCodUsuario")
            If Not objAgenteVendas.Buscar() Then
                LblErro.Text += "- Usuário não é agente de vendas.<br/>"
            End If

            If String.IsNullOrEmpty(LblCodCanalVenda.Text) Then
                LblErro.Text += "- Verifique o cadastro do cliente financeiro. Campo Canal de Venda não está preenchido.<br/>"
            End If

            If String.IsNullOrEmpty(LblCodFormaPagamento.Text) Then
                LblErro.Text += "- Verifique o cadastro do cliente financeiro. Campo Forma de Pagamento não está preenchido.<br/>"
            End If

            If String.IsNullOrEmpty(LblCodCondPagto.Text) Then
                LblErro.Text += "- Verifique o cadastro do cliente financeiro. Campo Condição de Pagamento não está preenchido.<br/>"
            End If

            If String.IsNullOrEmpty(LblCodNaturOper.Text) Then
                LblErro.Text += "- Verifique o cadastro do cliente financeiro. Campo Natureza de Operação não está preenchido.<br/>"
            End If

            If String.IsNullOrEmpty(LblTipoFrete.Text) Then
                LblErro.Text += "- Verifique o cadastro do cliente financeiro. Campo Tipo Frete não está preenchido.<br/>"
            End If

            If LblErro.Text = "" Then
                Return True
            Else
                LblErro.Text = "Prezado usuário, não foi possível salvar:<br/>" + LblErro.Text
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Function CarregaObjeto(ByVal ObjPedido As UCLPedidoVenda) As UCLPedidoVenda
        Try
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim cnpj As String

            objChamado.Empresa = Empresa
            objChamado.CodChamado = IIf(String.IsNullOrEmpty(TxtNrChamado.Text), CodAtendimento, TxtNrChamado.Text)
            objChamado.Buscar()

            cnpj = objChamado.Cnpj

            If Acao = "INCLUIR" Then
                ObjPedido.codAgenteVenda = Session("GlCodUsuario")
                ObjPedido.codCanalVenda = LblCodCanalVenda.Text
                ObjPedido.codIndicador = LblCodIndicador.Text
                ObjPedido.codFormaPagamento = LblCodFormaPagamento.Text
                ObjPedido.codCondPagto = LblCodCondPagto.Text
                ObjPedido.dataEmissao = Now.Date.ToString("dd/MM/yyyy")
                ObjPedido.dataEntrega = TxtDataEntrega.Text
                ObjPedido.HoraEntrega = TxtHoraEntrega.Text
                ObjPedido.codEmitente = LblCodEmitente.Text
                ObjPedido.cnpjFaturamento = IIf(String.IsNullOrEmpty(cnpj), GetCNPJ(TipoCNPJ.Preferencial), cnpj)
                ObjPedido.cnpjCobranca = GetCNPJ(TipoCNPJ.Cobranca)
                ObjPedido.cnpjEntrega = IIf(String.IsNullOrEmpty(cnpj), GetCNPJ(TipoCNPJ.Preferencial), cnpj)
                ObjPedido.codNaturOper = LblCodNaturOper.Text
                ObjPedido.tipoFrete = LblTipoFrete.Text
                ObjPedido.codTransportador = LblCodTransportador.Text
                ObjPedido.dataCadastramento = Now.ToString("dd/MM/yyyyHH:mm")
                ObjPedido.codUsuarioCadastro = Session("GlCodUsuario")
                ObjPedido.statusRecebimento = DdlStatusRecebimento.SelectedValue
                ObjPedido.DataChegada = TxtDataChegada.Text
                ObjPedido.hHoraChegada = TxtHoraChegada.Text
                ObjPedido.DataChegadaPrevista = TxtDataChegadaPrevista.Text
                ObjPedido.hHoraChegadaPrevista = TxtHoraChegadaPrevista.Text
                ObjPedido.situacaoFaturamento = 1
                ObjPedido.situacaoEntrega = 1
                ObjPedido.situacaoAprovacao1 = 1
                ObjPedido.situacaoAprovacao2 = 1
                ObjPedido.statusDigitacao = DdlStatus.SelectedValue
                ObjPedido.totalMercadoria = 0
                ObjPedido.totalMercadoriaOrig = 0
                ObjPedido.totalIcms = 0
                ObjPedido.totalIpi = 0
                ObjPedido.totalDesconto = 0
                ObjPedido.totalPedido = 0
                ObjPedido.baseIcms = 0
                ObjPedido.baseIcmsSubstituicao = 0
                ObjPedido.icmsTributado = 0
                ObjPedido.icmsIsento = 0
                ObjPedido.icmsOutras = 0
                ObjPedido.icmsSubstituicao = 0
                ObjPedido.baseIpi = 0
                ObjPedido.ipiTributado = 0
                ObjPedido.ipiIsento = 0
                ObjPedido.ipiOutras = 0
                ObjPedido.baseCofins = 0
                ObjPedido.cofins = 0
                ObjPedido.basePis = 0
                ObjPedido.pis = 0
                ObjPedido.baseCsll = 0
                ObjPedido.csll = 0
                ObjPedido.baseIrrf = 0
                ObjPedido.irrf = 0
                ObjPedido.baseIssqn = 0
                ObjPedido.issqn = 0
                ObjPedido.baseInss = 0
                ObjPedido.inss = 0
                ObjPedido.idContrato = "N"
                ObjPedido.faturamentoAssociado = "N"
                ObjPedido.codChamado = IIf(String.IsNullOrEmpty(TxtNrChamado.Text), CodAtendimento, TxtNrChamado.Text)
                ObjPedido.pedidoProducao = "N"
                ObjPedido.aprovadoResultado = "N"
                ObjPedido.pedidoForcaVendas = "N"
                ObjPedido.impressoFechamentoCarga = "N"
                ObjPedido.obsFiscalNota = "N"
                ObjPedido.obsNaoFiscalNota = "N"
                ObjPedido.embarqueConferido = "N"
                ObjPedido.exportadoIntegracaoProducao = "N"
                ObjPedido.observacao = TxtObservacao.Text.GetValidInputContent
                ObjPedido.dataEncerramento = TxtDataEncerramento.Text
                ObjPedido.hHoraEncerramento = TxtHoraEncerramento.Text
                ObjPedido.osLiberadoFinanceiro = DdlStatusAprovFinancOS.SelectedValue
                DdlTipoCobrancaOS.SelectedValue = ObjPedido.codTipoCobrancaOS
                ObjPedido.SAG = TxtSag.Text
                ObjPedido.ImprimirMatricial = CbxImprimirMatricial.Checked
            Else
                ObjPedido.codEmitente = TxtCliente.Text
                ObjPedido.cnpjFaturamento = DdlCNPJ.SelectedValue
                ObjPedido.cnpjCobranca = DdlCNPJ.SelectedValue
                ObjPedido.cnpjEntrega = DdlCNPJ.SelectedValue
                ObjPedido.dataEntrega = TxtDataEntrega.Text
                ObjPedido.dataAlteracao = Now.ToString("dd/MM/yyyyHH:mm")
                ObjPedido.codUsuarioAlteracao = Session("GlCodUsuario")
                ObjPedido.statusDigitacao = DdlStatus.SelectedValue
                ObjPedido.statusRecebimento = DdlStatusRecebimento.SelectedValue
                ObjPedido.codChamado = IIf(String.IsNullOrEmpty(TxtNrChamado.Text), CodAtendimento, TxtNrChamado.Text)
                ObjPedido.HoraEntrega = TxtHoraEntrega.Text
                ObjPedido.DataChegada = TxtDataChegada.Text
                ObjPedido.hHoraChegada = TxtHoraChegada.Text
                ObjPedido.DataChegadaPrevista = TxtDataChegadaPrevista.Text
                ObjPedido.hHoraChegadaPrevista = TxtHoraChegadaPrevista.Text
                ObjPedido.observacao = TxtObservacao.Text.GetValidInputContent
                ObjPedido.osLiberadoFinanceiro = DdlStatusAprovFinancOS.SelectedValue
                ObjPedido.codTipoCobrancaOS = DdlTipoCobrancaOS.SelectedValue
                ObjPedido.SAG = TxtSag.Text
                ObjPedido.ImprimirMatricial = CbxImprimirMatricial.Checked
                If Not String.IsNullOrEmpty(TxtDataEncerramento.Text) Then
                    If Not String.IsNullOrEmpty(TxtHoraEncerramento.Text) Then
                        ObjPedido.dataEncerramento = TxtDataEncerramento.Text + TxtHoraEncerramento.Text
                    Else
                        ObjPedido.dataEncerramento = TxtDataEncerramento.Text
                    End If
                Else
                    ObjPedido.dataEncerramento = ""
                End If
            End If

            Return ObjPedido

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Enum TipoCNPJ
        Preferencial = 1
        Cobranca = 2
    End Enum

    Private Function GetCNPJ(ByVal tipo As TipoCNPJ) As String
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            objEmitente.CodEmitente = LblCodEmitente.Text
            objEmitente.Buscar()

            If tipo = TipoCNPJ.Cobranca Then
                Return objEmitente.CNPJCobranca
            ElseIf tipo = TipoCNPJ.Preferencial Then
                Return objEmitente.CNPJPreferencial
            Else
                Return ""
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGAtendimentoPedido.aspx")
    End Sub

    Private ReadOnly Property CaminhoRedirect() As String
        Get
            Return Request.QueryString.Item("rd")
        End Get
    End Property

    Protected Sub BtnImprimirOS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImprimirOS.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "window.open('WFImpressaoOS.aspx?eid=" + Empresa + "&sid=" + Estabelecimento + "&pid=" + CodPedidoVenda + "');", True)
    End Sub

    Protected Sub BtnAlterarChamado_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAlterarChamado.Click
        TxtNrChamado.Enabled = True
        BtnAlterarChamado.Visible = False
    End Sub

    Protected Sub TxtDataEncerramento_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDataEncerramento.TextChanged
        If DdlStatus.SelectedValue = "1" AndAlso Not String.IsNullOrEmpty(TxtDataEncerramento.Text) Then
            DdlStatus.SelectedValue = "2"
        End If
    End Sub

    Private Sub CarregaTipoCobrancaOS()
        Try
            Dim objTipoCobrancaOS As New UCLTipoCobrancaOS
            objTipoCobrancaOS.FillDropDown(DdlTipoCobrancaOS, True, "(selecione)", "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CarregaCliente()

        CarregaCNPJ()
        DdlCNPJ.SelectedValue = objPedidoVenda.cnpjFaturamento

        objEmitente.CodEmitente = TxtCliente.Text
        objEmitente.Buscar()


        objEndereco.CodEmitente = TxtCliente.Text
        objEndereco.CNPJ = DdlCNPJ.SelectedValue
        objEndereco.Buscar()
        LblNomeCliente.Text = objEndereco.NomeAbreviado
        LblTelefone.Text = objEndereco.Fone1
        LblPontoAtendimento.Text = objPedidoVenda.PontoAtendimento
    End Sub

    Private Sub ChecaPesquisaCliente()
        Try
            Dim CodClientePesquisado As String
            Dim CnpjClientePesquisado As String
            Dim alterouCodCliente As Long

            If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
                alterouCodCliente = Session("SAlterouCodCliente")
            Else
                alterouCodCliente = 0
            End If

            CodClientePesquisado = Session("SCodClientePesquisado")
            CnpjClientePesquisado = Session("SCNPJClientePesquisado")

            If Not String.IsNullOrEmpty(CodClientePesquisado) Then
                If alterouCodCliente > 0 Then
                    If TxtCliente.Text <> CodClientePesquisado Then
                        TxtCliente.Text = CodClientePesquisado
                        Call CodigoClienteMudou(True)
                    End If
                    If DdlCNPJ.SelectedValue <> CnpjClientePesquisado Then
                        DdlCNPJ.SelectedValue = CnpjClientePesquisado
                        Call CNPJMudou()
                    End If
                    Session("SAlterouCodCliente") = alterouCodCliente - 2
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CodigoClienteMudou(ByVal procCompleto As Boolean)
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        
        If procCompleto Then
            Call CarregaCNPJ()
        End If

        objEmitente.CodEmitente = TxtCliente.Text
        objEmitente.Buscar()
        LblNomeCliente.Text = objEmitente.Nome


        Session("SCodEmitenteNegociacao") = TxtCliente.Text
        Session("SCodClientePesquisado") = TxtCliente.Text


        If procCompleto Then
            Call CNPJMudou()
        End If

    End Sub

    Private Sub CNPJMudou()
        Try
            Dim objEndereco As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))

            'Necessário para que a alteração de emitente funcione via tela da negociação, não retirar
            Session("SCNPJEmitente") = DdlCNPJ.SelectedValue

            objEndereco.CodEmitente = TxtCliente.Text
            objEndereco.CNPJ = DdlCNPJ.SelectedValue
            objEndereco.Buscar()
            LblNomeCliente.Text = objEndereco.NomeAbreviado
            LblTelefone.Text = objEndereco.Fone1
            If Not String.IsNullOrEmpty(objEndereco.Fone2) Then
                LblTelefone.Text += " / " + objEndereco.Fone2
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub TxtCliente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCliente.TextChanged
        Call CarregaCliente()
        Call CodigoClienteMudou(True)
    End Sub

    Protected Sub DdlCNPJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlCNPJ.SelectedIndexChanged
        Call CNPJMudou()
    End Sub
End Class