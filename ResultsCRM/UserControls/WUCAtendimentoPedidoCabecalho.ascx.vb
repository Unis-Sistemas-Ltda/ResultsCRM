Partial Public Class WUCAtendimentoPedidoCabecalho
    Inherits System.Web.UI.UserControl

    Private _OrigemAberturaTela As TipoAberturaTela

    Public Enum TipoAberturaTela As Integer
        Atendimento = 1
        PainelDeOS = 2
    End Enum

    Public Property OrigemAberturaTela As TipoAberturaTela
        Get
            Return _OrigemAberturaTela
        End Get
        Set(value As TipoAberturaTela)
            If value = TipoAberturaTela.Atendimento Then
                LblLabelChamadoCliente.Visible = False
                TxtOSCliente.Visible = False
                Label7.Visible = False
                LblStatusChamado.Visible = False
                Label8.Visible = False
                TxtMotivoStatus.Visible = False
            Else
                LblLabelChamadoCliente.Visible = True
                TxtOSCliente.Visible = True
                Label7.Visible = True
                LblStatusChamado.Visible = True
                Label8.Visible = True
                TxtMotivoStatus.Visible = True
            End If
            _OrigemAberturaTela = value
        End Set
    End Property

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objParametrosManutencao As New UCLParametrosManutencao
            Dim AlterouCodTransportadora As String
            Dim CodTransportadoraPesquisado As String

            objParametrosManutencao.Buscar(Empresa, Estabelecimento)

            If Not String.IsNullOrEmpty(Session("SAlterouCodTransportadora")) Then
                AlterouCodTransportadora = Session("SAlterouCodTransportadora")
            Else
                AlterouCodTransportadora = 0
            End If

            CodTransportadoraPesquisado = Session("SCodTransportadoraPesquisado")

            If Not String.IsNullOrEmpty(CodTransportadoraPesquisado) Then
                If AlterouCodTransportadora > 0 Then
                    If TxtCodTransportadora.Text <> CodTransportadoraPesquisado Then
                        TxtCodTransportadora.Text = CodTransportadoraPesquisado
                        Call CodigoTransportadoraMudou()
                    End If
                    Session("SAlterouCodTransportadora") = AlterouCodTransportadora - 1
                End If
            End If

            If Not IsPostBack Then
                If String.IsNullOrEmpty(CodAtendimento) Then
                    BtnVoltar.Visible = False
                End If
                If objParametrosManutencao.GetConteudo("chamado_os_unica") = "S" Then
                    Dim objChamado As New UCLAtendimento(StrConexao)
                    Dim OSs As List(Of String) = objChamado.GetOSsChamado(Session("GlEmpresa"), Session("GlEstabelecimento"), Session("SCodAtendimento"))
                    If OSs.Count = 1 Then
                        BtnVoltar.Visible = False
                    End If
                End If
                Call CarregaFormulario()
            End If

            If Session("GlTipoFaturamento") = "G" Then
                LblAgendamentoChegada.Text = "Início:"
                LblTecnicoChegada.Text = "Início:"
                LblExecucaoChegada.Text = "Início:"
            End If

            If objParametrosManutencao.GetConteudo("mostrar_data_agendamento_os_crm") = "S" Then
                LblGrupoAgendamento.Visible = True
                LblAgendamentoChegada.Visible = True
                TxtDataChegadaPrevista.Visible = True
                TxtHoraChegadaPrevista.Visible = True
                LblAgendamentoEncerramento.Visible = True
                TxtDataEntrega.Visible = True
                TxtHoraEntrega.Visible = True
            Else
                LblGrupoAgendamento.Visible = False
                LblAgendamentoChegada.Visible = False
                TxtDataChegadaPrevista.Visible = False
                TxtHoraChegadaPrevista.Visible = False
                LblAgendamentoEncerramento.Visible = False
                TxtDataEntrega.Visible = False
                TxtHoraEntrega.Visible = False
            End If

            If objParametrosManutencao.GetConteudo("mostrar_data_tecnico_os_crm") = "S" Then
                LblGrupoTecnico.Visible = True
                LblTecnicoChegada.Visible = True
                TxtDataInicioExecucao.Visible = True
                TxtHoraInicioExecucao.Visible = True
                LblTecnicoEncerramento.Visible = True
                TxtDataTerminoExecucao.Visible = True
                TxtHoraTerminoExecucao.Visible = True
                BtnCopiarInfoTecnico.Visible = True
            Else
                LblGrupoTecnico.Visible = False
                LblTecnicoChegada.Visible = False
                TxtDataInicioExecucao.Visible = False
                TxtHoraInicioExecucao.Visible = False
                LblTecnicoEncerramento.Visible = False
                TxtDataTerminoExecucao.Visible = False
                TxtHoraTerminoExecucao.Visible = False
                BtnCopiarInfoTecnico.Visible = False
            End If

            If objParametrosManutencao.GetConteudo("mostrar_data_execucao_os_crm") = "S" Then
                LblGrupoExecucao.Visible = True
                LblExecucaoChegada.Visible = True
                TxtDataChegada.Visible = True
                TxtHoraChegada.Visible = True
                LblExecucaoEncerramento.Visible = True
                TxtDataEncerramento.Visible = True
                TxtHoraEncerramento.Visible = True
            Else
                LblGrupoExecucao.Visible = False
                LblExecucaoChegada.Visible = False
                TxtDataChegada.Visible = False
                TxtHoraChegada.Visible = False
                LblExecucaoEncerramento.Visible = False
                TxtDataEncerramento.Visible = False
                TxtHoraEncerramento.Visible = False
            End If

            If objParametrosManutencao.GetConteudo("motrar_obs_nao_fiscal_os_crm") = "S" Then
                LblObsNaoFiscais.Visible = True
                LblObsNaoFiscais.Text = "Observações Fiscais:"
                TxtObservacaoNaoFiscal.Visible = True
            Else
                LblObsNaoFiscais.Visible = False
                LblObsNaoFiscais.Text = "Observação:"
                TxtObservacaoNaoFiscal.Visible = False
            End If

            If objParametrosManutencao.GetConteudo("mostrar_cnpj_faturamento_os_crm") = "S" Then
                LblCNPJFaturamento.Visible = True
                'LblCNPJFaturamentoQuebra.Visible = True
                DdlCNPJFaturamento.Visible = True
            Else
                LblCNPJFaturamento.Visible = False
                'LblCNPJFaturamentoQuebra.Visible = False
                DdlCNPJFaturamento.Visible = False
            End If

            If objParametrosManutencao.GetConteudo("mostrar_cnpj_cobranca_os_crm") = "S" Then
                LblCNPJCobranca.Visible = True
                LblCNPJCobrancaQuebra.Visible = True
                DdlCNPJCobranca.Visible = True
            Else
                LblCNPJCobranca.Visible = False
                LblCNPJCobrancaQuebra.Visible = False
                DdlCNPJCobranca.Visible = False
            End If

            If objParametrosManutencao.GetConteudo("mostrar_cnpj_entrega_os_crm") = "S" Then
                LblCNPJEntrega.Visible = True
                LblCNPJEntregaQuebra.Visible = True
                DdlCNPJEntrega.Visible = True
            Else
                LblCNPJEntrega.Visible = False
                LblCNPJEntregaQuebra.Visible = False
                DdlCNPJEntrega.Visible = False
            End If

            If objParametrosManutencao.GetConteudo("mostrar_natureza_operacao_os_crm") = "S" Then
                LblNaturOper.Visible = True
                'LblNaturOperQuebra.Visible = True
                DdlNaturOper.Visible = True
            Else
                LblNaturOper.Visible = False
                'LblNaturOperQuebra.Visible = False
                DdlNaturOper.Visible = False
            End If

            If objParametrosManutencao.GetConteudo("mostrar_canal_venda_os_crm") = "S" Then
                LblCanalVenda.Visible = True
                LblCanalVendaQuebra.Visible = True
                DdlCanalVenda.Visible = True
            Else
                LblCanalVenda.Visible = False
                LblCanalVendaQuebra.Visible = False
                DdlCanalVenda.Visible = False
            End If

            If objParametrosManutencao.GetConteudo("mostrar_forma_pagamento_os_crm") = "S" Then
                LblFormaPagamento.Visible = True
                LblFormaPagamentoQuebra.Visible = True
                DdlFormaPagamento.Visible = True
            Else
                LblFormaPagamento.Visible = False
                LblFormaPagamentoQuebra.Visible = False
                DdlFormaPagamento.Visible = False
            End If

            If objParametrosManutencao.GetConteudo("mostrar_condicao_pagamento_os_crm") = "S" Then
                LblCondicaoPagamento.Visible = True
                LblCondicaoPagamentoQuebra.Visible = True
                DdlCondicaoPagamento.Visible = True
            Else
                LblCondicaoPagamento.Visible = False
                LblCondicaoPagamentoQuebra.Visible = False
                DdlCondicaoPagamento.Visible = False
            End If

            If objParametrosManutencao.GetConteudo("mostrar_transportador_os_crm") = "S" Then
                LblTransportadora.Visible = True
                'LblTransportadoraQuebra.Visible = True
                TxtCodTransportadora.Visible = True
                BtnFiltrarTransportadora.Visible = True
                LblNomeTransportadora.Visible = True
            Else
                LblTransportadora.Visible = False
                'LblTransportadoraQuebra.Visible = False
                TxtCodTransportadora.Visible = False
                BtnFiltrarTransportadora.Visible = False
                LblNomeTransportadora.Visible = False
            End If

            If objParametrosManutencao.GetConteudo("mostrar_tipo_frete_os_crm") = "S" Then
                LblTipoFreteLbl.Visible = True
                LblTipoFreteQuebra.Visible = True
                DdlTipoFrete.Visible = True
            Else
                LblTipoFreteLbl.Visible = False
                LblTipoFreteQuebra.Visible = False
                DdlTipoFrete.Visible = False
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub CarregaFormulario()
        Try
            Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEmitenteAtendimento As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objClienteFinanceiro As New UCLClienteFinanceiro
            Dim objCidade As New UCLCidade
            Dim objEstado As New UCLEstado
            Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim SAG As String
            Dim objParametrosManutencao As New UCLParametrosManutencao

            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))

            If objParametrosManutencao.GetConteudo("modelo_chamado_crm") <> 1 Then
                LblTomador.Text = "Cliente:"
                LblPontoAtendimento.Visible = False
                LblPtAtendimento.Visible = False
            End If

            LblMtvNvOS.Visible = False
            TxtAux1.Visible = False

            Call CarregaCanalVenda()
            Call CarregaNatureza()
            Call CarregaFormaPagto()
            Call CarregaCondPagto()

            If Acao = "INCLUIR" Then
                If String.IsNullOrEmpty(CodAtendimento) Then
                    LblCodEmitente.Text = "0"
                    objEmitente.CodEmitente = objAtendimento.CodEmitente
                    objEmitente.Buscar()
                    LblNomeEmitente.Text = objEmitente.Nome
                    SAG = ""
                Else
                    objAtendimento.Empresa = Empresa
                    objAtendimento.CodChamado = CodAtendimento
                    If objAtendimento.Buscar() Then
                        LblCodEmitente.Text = objAtendimento.CodEmitente
                        objEmitente.CodEmitente = objAtendimento.CodEmitente
                        objEmitente.Buscar()
                        LblNomeEmitente.Text = objEmitente.Nome
                        Call CarregaCNPJ()
                        If Not String.IsNullOrEmpty(objAtendimento.Cnpj) Then
                            DdlCNPJFaturamento.SelectedValue = objAtendimento.Cnpj
                            DdlCNPJCobranca.SelectedValue = objAtendimento.Cnpj
                            DdlCNPJEntrega.SelectedValue = objAtendimento.Cnpj
                        End If
                        If objAtendimento.Contrato <> "" AndAlso objAtendimento.Contrato <> "0" Then
                            CbxContrato.Checked = True
                        End If
                        SAG = objAtendimento.SAG

                        objEmitenteAtendimento.CodEmitente = objAtendimento.CodEmitenteAtendimento
                        If Not String.IsNullOrEmpty(objEmitenteAtendimento.CodEmitente) Then
                            objEmitenteAtendimento.Buscar()

                            objPontoAtendimento.CodEmitente = objEmitenteAtendimento.CodEmitente
                            objPontoAtendimento.NumeroPontoAtendimento = objAtendimento.NumeroPontoAtendimento
                            If Not String.IsNullOrEmpty(objPontoAtendimento.CodEmitente) And Not String.IsNullOrEmpty(objPontoAtendimento.NumeroPontoAtendimento) Then
                                objPontoAtendimento.Buscar()
                                LblPontoAtendimento.Text = objEmitenteAtendimento.NomeAbreviado + " - PA: " + objAtendimento.NumeroPontoAtendimento + " - " + objPontoAtendimento.Descricao
                                objCidade.CodPais = objPontoAtendimento.CodPais
                                objCidade.CodEstado = objPontoAtendimento.CodEstado
                                objCidade.CodCidade = objPontoAtendimento.CodCidade
                                objCidade.Buscar()
                                objEstado.CodPais = objPontoAtendimento.CodPais
                                objEstado.CodEstado = objPontoAtendimento.CodEstado
                                objEstado.Buscar()
                                LblPontoAtendimento.Text += " - " + objCidade.NomeCidade + " / " + objEstado.Sigla
                            End If
                        End If
                    Else
                        SAG = ""
                    End If
                End If

                objPedidoVenda.empresa = Empresa
                objPedidoVenda.estabelecimento = Estabelecimento
                'TxtCodPedidoVenda.Text = objPedidoVenda.GetProximoCodigo()
                TxtCodPedidoVenda.Text = "0"

                objClienteFinanceiro.Empresa = Empresa
                objClienteFinanceiro.CodEmitente = LblCodEmitente.Text
                objClienteFinanceiro.Buscar()

                Call VerificaNovoChamado()

                DdlCanalVenda.SelectedValue = objClienteFinanceiro.CodCanalVenda
                DdlNaturOper.SelectedValue = objClienteFinanceiro.CodNaturOper

                If objClienteFinanceiro.CodCondPagto > "0" Then
                    DdlCondicaoPagamento.SelectedValue = objClienteFinanceiro.CodCondPagto
                End If

                If objClienteFinanceiro.CodFormaPagto > "0" Then
                    DdlFormaPagamento.SelectedValue = objClienteFinanceiro.CodFormaPagto
                End If

                LblCodIndicador.Text = "1"
                DdlTipoFrete.Text = objClienteFinanceiro.TipoFrete
                TxtCodTransportadora.Text = objClienteFinanceiro.CodTransportador
                TxtNrChamado.Text = CodAtendimento

                TxtSag.Text = SAG

                If DdlCanalVenda.SelectedValue.Trim = "0" Then
                    DdlCanalVenda.SelectedValue = ""
                End If

                If DdlNaturOper.SelectedValue.Trim = "0" Then
                    DdlNaturOper.SelectedValue = ""
                End If

                BtnGravar.Text = "Incluir Ordem de Serviço"

                'DdlStatusRecebimento.Enabled = False

                Call CarregaDadosChamado()

            ElseIf Acao = "ALTERAR" Then
                TxtCodPedidoVenda.Enabled = False
                objPedidoVenda.empresa = Empresa
                objPedidoVenda.estabelecimento = Estabelecimento
                objPedidoVenda.codPedidoVenda = CodPedidoVenda
                objPedidoVenda.Buscar()
                objPedidoVenda.SetAlteradoTecnico("N")

                TxtCodPedidoVenda.Text = objPedidoVenda.codPedidoVenda
                CodAtendimento = objPedidoVenda.codChamado
                If objPedidoVenda.ImprimirMatricial = "S" Then
                    CbxImprimirMatricial.Checked = True
                Else
                    CbxImprimirMatricial.Checked = False
                End If

                If String.IsNullOrEmpty(CodAtendimento) Then
                    LblCodEmitente.Text = objPedidoVenda.codEmitente
                Else
                    objAtendimento.Empresa = Empresa
                    objAtendimento.CodChamado = CodAtendimento
                    If objAtendimento.Buscar() Then
                        'LblCodEmitente.Text = objAtendimento.CodEmitente
                    End If
                    LblCodEmitente.Text = objPedidoVenda.codEmitente
                    Call CarregaCNPJ()
                    DdlCNPJFaturamento.SelectedValue = objPedidoVenda.cnpjFaturamento
                    DdlCNPJCobranca.SelectedValue = objPedidoVenda.cnpjCobranca
                    DdlCNPJEntrega.SelectedValue = objPedidoVenda.cnpjEntrega
                    objEmitenteAtendimento.CodEmitente = objAtendimento.CodEmitenteAtendimento
                    If Not String.IsNullOrEmpty(objEmitenteAtendimento.CodEmitente) Then
                        objEmitenteAtendimento.Buscar()

                        objPontoAtendimento.CodEmitente = objEmitenteAtendimento.CodEmitente
                        objPontoAtendimento.NumeroPontoAtendimento = objAtendimento.NumeroPontoAtendimento
                        If Not String.IsNullOrEmpty(objPontoAtendimento.CodEmitente) And Not String.IsNullOrEmpty(objPontoAtendimento.NumeroPontoAtendimento) Then
                            objPontoAtendimento.Buscar()
                            LblPontoAtendimento.Text = objEmitenteAtendimento.NomeAbreviado + " - PA: " + objAtendimento.NumeroPontoAtendimento + " - " + objPontoAtendimento.Descricao
                            objCidade.CodPais = objPontoAtendimento.CodPais
                            objCidade.CodEstado = objPontoAtendimento.CodEstado
                            objCidade.CodCidade = objPontoAtendimento.CodCidade
                            objCidade.Buscar()
                            objEstado.CodPais = objPontoAtendimento.CodPais
                            objEstado.CodEstado = objPontoAtendimento.CodEstado
                            objEstado.Buscar()
                            LblPontoAtendimento.Text += " - " + objCidade.NomeCidade + " / " + objEstado.Sigla
                        End If
                    End If
                End If

                objEmitente.CodEmitente = LblCodEmitente.Text
                objEmitente.Buscar()

                objEnderecoEmitente.CodEmitente = LblCodEmitente.Text
                objEnderecoEmitente.CNPJ = objPedidoVenda.cnpjFaturamento
                objEnderecoEmitente.Buscar()

                LblNomeEmitente.Text = objEnderecoEmitente.NomeAbreviado
                BtnAlterarChamado.Visible = True

                DdlCanalVenda.SelectedValue = objPedidoVenda.codCanalVenda
                If objPedidoVenda.codCondPagto > "0" Then
                    DdlCondicaoPagamento.SelectedValue = objPedidoVenda.codCondPagto
                End If
                If objPedidoVenda.codFormaPagamento > "0" Then
                    DdlFormaPagamento.SelectedValue = objPedidoVenda.codFormaPagamento
                End If
                LblCodIndicador.Text = objPedidoVenda.codIndicador
                DdlNaturOper.SelectedValue = objPedidoVenda.codNaturOper
                DdlTipoFrete.Text = objPedidoVenda.tipoFrete
                TxtCodTransportadora.Text = objPedidoVenda.codTransportador
                Call MostraNomeTransportadora()
                TxtDataEntrega.Text = objPedidoVenda.dataEntrega
                TxtHoraEntrega.Text = objPedidoVenda.HoraEntrega
                TxtSag.Text = objPedidoVenda.SAG
                DdlStatusTecnico.SelectedValue = objPedidoVenda.StatusTecnico
                CbxContrato.Checked = (objPedidoVenda.idContrato = "S")
                If objPedidoVenda.dDataInicioExecucao <> Nothing Then
                    TxtDataInicioExecucao.Text = objPedidoVenda.dDataInicioExecucao.ToString("dd/MM/yyyy")
                Else
                    TxtDataInicioExecucao.Text = ""
                End If
                TxtHoraInicioExecucao.Text = objPedidoVenda.hHoraInicioExecucao

                If objPedidoVenda.dDataTerminoExecucao <> Nothing Then
                    TxtDataTerminoExecucao.Text = objPedidoVenda.dDataTerminoExecucao.ToString("dd/MM/yyyy")
                Else
                    TxtDataTerminoExecucao.Text = ""
                End If
                TxtHoraTerminoExecucao.Text = objPedidoVenda.hHoraTerminoExecucao

                If Not String.IsNullOrWhiteSpace(TxtDataTerminoExecucao.Text) Then
                    BtnCopiarInfoTecnico.Visible = True
                End If

                If objPedidoVenda.dDataEncerramento <> Nothing Then
                    TxtDataEncerramento.Text = objPedidoVenda.dDataEncerramento.ToString("dd/MM/yyyy")
                Else
                    TxtDataEncerramento.Text = ""
                End If
                TxtHoraEncerramento.Text = objPedidoVenda.hHoraEncerramento

                If objPedidoVenda.dDataChegada <> Nothing Then
                    TxtDataChegada.Text = objPedidoVenda.dDataChegada.ToString("dd/MM/yyyy")
                Else
                    TxtDataChegada.Text = ""
                End If
                TxtHoraChegada.Text = objPedidoVenda.hHoraChegada

                If objPedidoVenda.dDataChegadaPrevista <> Nothing Then
                    TxtDataChegadaPrevista.Text = objPedidoVenda.dDataChegadaPrevista.ToString("dd/MM/yyyy")
                Else
                    TxtDataChegadaPrevista.Text = ""
                End If
                TxtHoraChegadaPrevista.Text = objPedidoVenda.hHoraChegadaPrevista

                DdlStatus.SelectedValue = objPedidoVenda.statusDigitacao
                DdlStatusRecebimento.SelectedValue = objPedidoVenda.statusRecebimento
                TxtNrChamado.Text = objPedidoVenda.codChamado

                TxtDataInicioTrabalhoTecnico.Text = objPedidoVenda.dataInicioTrabalhoTecnico
                TxtHoraInicioTrabalhoTecnico.Text = objPedidoVenda.hHoraInicioTrabalhoTecnico

                If DdlCanalVenda.SelectedValue.Trim = "0" Then
                    DdlCanalVenda.SelectedValue = ""
                End If

                If DdlNaturOper.SelectedValue.Trim = "0" Then
                    DdlNaturOper.SelectedValue = ""
                End If

                TxtObservacao.Text = objPedidoVenda.observacao
                TxtObservacaoNaoFiscal.Text = objPedidoVenda.observacaoNaoFiscal
                TxtAux1.Text = objPedidoVenda.aux1
                TxtAux1.Enabled = False

                If Not String.IsNullOrEmpty(TxtAux1.Text) Then
                    TxtAux1.Visible = True
                    LblMtvNvOS.Visible = True
                End If

                BtnGravar.Text = "Salvar"
                BtnImprimirOS.Visible = True

                If DdlStatus.SelectedValue = "2" OrElse DdlStatus.SelectedValue = "3" Then
                    'DdlStatusRecebimento.Enabled = True
                    TxtDataEntrega.Enabled = False
                    TxtHoraEntrega.Enabled = False
                    TxtDataEncerramento.Enabled = False
                    TxtHoraEncerramento.Enabled = False
                    TxtDataChegada.Enabled = False
                    TxtHoraChegada.Enabled = False
                    TxtDataChegadaPrevista.Enabled = False
                    TxtHoraChegadaPrevista.Enabled = False
                    TxtObservacao.Enabled = False
                    TxtNrChamado.Enabled = False
                    BtnAlterarChamado.Visible = False
                    TxtMotivoStatus.Enabled = False
                    DdlCNPJFaturamento.Enabled = False
                    DdlCNPJEntrega.Enabled = False
                    DdlCNPJCobranca.Enabled = False
                    DdlTipoFrete.Enabled = False
                    TxtCodTransportadora.Enabled = False
                    BtnFiltrarTransportadora.Enabled = False
                    TxtObservacaoNaoFiscal.Enabled = False
                    DdlCanalVenda.Enabled = False
                    DdlCondicaoPagamento.Enabled = False
                    DdlFormaPagamento.Enabled = False
                    DdlNaturOper.Enabled = False
                Else
                    'DdlStatusRecebimento.Enabled = False
                    TxtDataEntrega.Enabled = True
                    TxtHoraEntrega.Enabled = True
                    TxtDataEncerramento.Enabled = True
                    TxtHoraEncerramento.Enabled = True
                    TxtDataChegada.Enabled = True
                    TxtHoraChegada.Enabled = True
                    TxtDataChegadaPrevista.Enabled = True
                    TxtHoraChegadaPrevista.Enabled = True
                    TxtObservacao.Enabled = True
                    TxtMotivoStatus.Enabled = True
                    DdlCNPJFaturamento.Enabled = True
                    DdlCNPJEntrega.Enabled = True
                    DdlCNPJCobranca.Enabled = True
                    DdlTipoFrete.Enabled = True
                    TxtCodTransportadora.Enabled = True
                    BtnFiltrarTransportadora.Enabled = True
                    TxtObservacaoNaoFiscal.Enabled = True
                    DdlCanalVenda.Enabled = True
                    DdlCondicaoPagamento.Enabled = True
                    DdlFormaPagamento.Enabled = True
                    DdlNaturOper.Enabled = True
                End If

                Call CarregaDadosChamado()

            End If

            If Session("GlTipoFaturamento") = "G" Then
                Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
                objChamado.Empresa = Session("GlEmpresa")
                objChamado.CodChamado = TxtNrChamado.Text
                If Not String.IsNullOrWhiteSpace(objChamado.CodChamado) Then
                    If objChamado.Buscar() Then
                        If TxtDataEntrega.Text.Trim.Length = 0 Then
                            TxtDataEntrega.Text = objChamado.DataEncerramentoPrevista
                        End If
                        If TxtHoraEntrega.Text.Trim.Length = 0 Then
                            TxtHoraEntrega.Text = objChamado.HoraEncerramentoPrevista
                        End If
                    End If
                End If
                If TxtDataChegadaPrevista.Text.Trim.Length = 0 Then
                    TxtDataChegadaPrevista.Text = F_DateAdd(Now.Date, "d", 1, "u").ToString("dd/MM/yyyy")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Enum En_EncerrarOS As Short
        ManterStatusInformadoEmTela = 0
        Encerrar = 1
        NaoEncerrar = 2
    End Enum

    Private Sub Gravar(ByVal encerrar As En_EncerrarOS)
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim statusAnterior As String
            Dim alterouCodPedidoVenda As Boolean = False
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim tmpAcao As String = Acao
            If IsDigitacaoOK() Then
                objPedido.empresa = Empresa
                objPedido.estabelecimento = Estabelecimento

                objChamado.Empresa = Empresa
                objChamado.CodChamado = TxtNrChamado.Text

                If Not String.IsNullOrWhiteSpace(objChamado.CodChamado) Then
                    If objChamado.Buscar() Then
                        objChamado.MotivoCancelamento = TxtMotivoStatus.Text
                        If Not String.IsNullOrWhiteSpace(TxtOSCliente.Text) Then
                            objChamado.OSCliente = TxtOSCliente.Text.Trim.GetValidInputContent
                        End If
                        objChamado.Alterar(Me.Empresa, Me.Estabelecimento, TxtNrChamado.Text)
                    End If
                End If

                If Acao = "INCLUIR" Then
                    objPedido.codPedidoVenda = TxtCodPedidoVenda.Text 'objPedido.GetProximoCodigo()
                    If objPedido.Buscar() Then
                        TxtCodPedidoVenda.Text = objPedido.GetProximoCodigo()
                        objPedido.codPedidoVenda = TxtCodPedidoVenda.Text
                        'alterouCodPedidoVenda = True
                    End If
                    objPedido = CarregaObjeto(objPedido, encerrar)
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
                    objPedido = CarregaObjeto(objPedido, encerrar)
                    objPedido.Alterar()
                End If

                If objPedido.statusDigitacao = "2" OrElse objPedido.statusDigitacao = "3" Then
                    'DdlStatusRecebimento.Enabled = True
                    TxtDataEntrega.Enabled = False
                    TxtObservacao.Enabled = False
                    TxtHoraEntrega.Enabled = False
                    TxtDataEncerramento.Enabled = False
                    TxtHoraEncerramento.Enabled = False
                    TxtDataChegada.Enabled = False
                    TxtHoraChegada.Enabled = False
                    TxtDataChegadaPrevista.Enabled = False
                    TxtHoraChegadaPrevista.Enabled = False
                    TxtNrChamado.Enabled = False
                    BtnAlterarChamado.Visible = False
                    TxtMotivoStatus.Enabled = True
                Else
                    'DdlStatusRecebimento.Enabled = False
                    TxtDataEntrega.Enabled = True
                    TxtObservacao.Enabled = True
                    TxtHoraEntrega.Enabled = True
                    TxtDataEncerramento.Enabled = True
                    TxtHoraEncerramento.Enabled = True
                    TxtDataChegada.Enabled = True
                    TxtHoraChegada.Enabled = True
                    TxtDataChegadaPrevista.Enabled = True
                    TxtHoraChegadaPrevista.Enabled = True
                    TxtMotivoStatus.Enabled = False
                    If Acao <> "INCLUIR" Then
                        BtnAlterarChamado.Visible = True
                    End If
                End If

                'If Not String.IsNullOrEmpty(CodAtendimento) Then
                '    Call objPedido.VerificaEEncerraChamado(IIf(String.IsNullOrEmpty(TxtNrChamado.Text), CodAtendimento, TxtNrChamado.Text), statusAnterior, objPedido.statusDigitacao)
                'End If

                LblErro.Text = "Dados salvos com sucesso."

                If alterouCodPedidoVenda Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('O número da OS foi alterado para " + TxtCodPedidoVenda.Text + ".');", True)
                End If

                If tmpAcao = "ALTERAR" Then
                    Call CarregaFormulario()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Enum TipoPergunta
        NumeroSerialNaoInformadoNoEquipamentoDaOS = 1
        DesejaEncerrarAOS = 2
        Confirmacao = 3
    End Enum

    Private Sub AjustarVisibilidadePergunta(ByVal tipo As TipoPergunta, ByVal mostrar As Boolean)
        Try
            If tipo = TipoPergunta.DesejaEncerrarAOS Then
                LblNumeroSerialEquipamentoNaoInformado.Visible = False
                LblDesejaEncerrarOS.Visible = mostrar
                LblConfirmacao.Visible = False
            ElseIf tipo = TipoPergunta.NumeroSerialNaoInformadoNoEquipamentoDaOS Then
                LblNumeroSerialEquipamentoNaoInformado.Visible = mostrar
                LblDesejaEncerrarOS.Visible = False
                LblConfirmacao.Visible = False
            ElseIf tipo = TipoPergunta.Confirmacao Then
                LblNumeroSerialEquipamentoNaoInformado.Visible = False
                LblDesejaEncerrarOS.Visible = False
                LblConfirmacao.Visible = mostrar
            End If

            If mostrar Then
                tdBarraFerramentas.BgColor = "#FFFFE6"
            Else
                tdBarraFerramentas.BgColor = ""
            End If

            BtnEncerraOS.Visible = mostrar
            BtnNaoEncerraOS.Visible = mostrar
            BtnGravar.Visible = Not mostrar
            BtnVoltar.Visible = Not mostrar
            BtnImprimirOS.Visible = Not mostrar

            If BtnVoltar.Visible Then
                Dim objParametrosManutencao As New UCLParametrosManutencao
                objParametrosManutencao.Buscar(Empresa, Estabelecimento)
                If objParametrosManutencao.GetConteudo("chamado_os_unica") = "S" Then
                    Dim objChamado As New UCLAtendimento(StrConexao)
                    Dim OSs As List(Of String) = objChamado.GetOSsChamado(Session("GlEmpresa"), Session("GlEstabelecimento"), Session("SCodAtendimento"))
                    If OSs.Count = 1 Then
                        BtnVoltar.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Function IsDigitacaoOK() As Boolean
        Try
            Dim objAgenteVendas As New UCLAgenteVendas
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

            LblErro.Text = ""

            objAgenteVendas.Codigo = Session("GlCodUsuario")
            If Not objAgenteVendas.Buscar() Then
                LblErro.Text += "- Usuário não é agente de vendas.<br/>"
            End If

            If TxtAux1.Visible AndAlso String.IsNullOrEmpty(TxtAux1.Text) Then
                LblErro.Text += "- Preencha o motivo da abertura de nova OS para o chamado.<br/>"
            End If

            If String.IsNullOrEmpty(DdlCanalVenda.SelectedValue) OrElse DdlCanalVenda.SelectedValue = "0" OrElse DdlCanalVenda.SelectedValue = "-1" Then
                LblErro.Text += "- Preencha o Campo Canal de Venda no cadastro do Cliente Financeiro e tente novamente incluir a OS.<br/>"
            End If

            If String.IsNullOrEmpty(DdlFormaPagamento.SelectedValue) Then
                LblErro.Text += "- Forma de Pagamento não foi informada.<br/>"
            End If

            If String.IsNullOrEmpty(DdlCondicaoPagamento.SelectedValue) Then
                LblErro.Text += "- Condição de Pagamento não foi informada.<br/>"
            End If

            If String.IsNullOrEmpty(DdlNaturOper.SelectedValue) OrElse DdlNaturOper.SelectedValue = "0" OrElse DdlNaturOper.SelectedValue = "-1" Then
                LblErro.Text += "- Verifique o cadastro do cliente financeiro. Campo Natureza de Operação não está preenchido.<br/>"
            End If

            If String.IsNullOrEmpty(DdlTipoFrete.Text) Then
                LblErro.Text += "- Tipo de Frete não foi informado.<br/>"
            End If

            'If DdlStatus.SelectedValue = "2" Then
            '    If String.IsNullOrEmpty(TxtDataEncerramento.Text) Then
            '        LblErro.Text += "- Para encerrar a OS é necessário informar a data do encerramento da mesma.<br/>"
            '    End If
            '    If String.IsNullOrEmpty(TxtHoraEncerramento.Text) Then
            '        LblErro.Text += "- Para encerrar a OS é necessário informar a hora do encerramento da mesma.<br/>"
            '    End If
            '    If String.IsNullOrEmpty(TxtDataChegada.Text) Then
            '        LblErro.Text += "- Para encerrar a OS é necessário informar a data de chegada.<br/>"
            '    End If
            '    If String.IsNullOrEmpty(TxtHoraChegada.Text) Then
            '        LblErro.Text += "- Para encerrar a OS é necessário informar a hora de chegada.<br/>"
            '    End If
            'End If

            If String.IsNullOrEmpty(CodAtendimento) Then
                CodAtendimento = TxtNrChamado.Text
            End If

            If Not objPedido.IgnoraValidacoes Then
                objChamado.Empresa = Empresa
                objChamado.CodChamado = CodAtendimento
                If objChamado.Buscar() Then

                    If Not String.IsNullOrEmpty(TxtDataEncerramento.Text) AndAlso isValidDate(TxtDataEncerramento.Text) Then
                        If objChamado.DDataChamado > CDate(TxtDataEncerramento.Text) Then
                            LblErro.Text += "- Data do encerramento da OS não pode ser inferior à da abertura do chamado.<br/>"
                        End If
                    End If
                    If Not String.IsNullOrEmpty(TxtDataEncerramento.Text) AndAlso isValidDate(TxtDataEncerramento.Text) AndAlso Not String.IsNullOrEmpty(TxtDataInicioExecucao.Text) AndAlso isValidDate(TxtDataInicioExecucao.Text) Then
                        If CDate(TxtDataInicioExecucao.Text) > CDate(TxtDataEncerramento.Text) Then
                            LblErro.Text += "- Data do encerramento da OS não pode ser inferior à do início do atendimento.<br/>"
                        End If
                    ElseIf Not String.IsNullOrEmpty(TxtDataEncerramento.Text) AndAlso isValidDate(TxtDataEncerramento.Text) Then
                        If objChamado.DDataInicioAtendimento <> Nothing AndAlso objChamado.DDataInicioAtendimento > CDate(TxtDataEncerramento.Text) Then
                            LblErro.Text += "- Data do encerramento da OS não pode ser inferior à do início do atendimento.<br/>"
                        End If
                    End If

                    If Not String.IsNullOrEmpty(TxtDataChegada.Text) AndAlso isValidDate(TxtDataChegada.Text) Then
                        If objChamado.DDataChamado > CDate(TxtDataChegada.Text) Then
                            LblErro.Text += "- Data da chegada não pode ser inferior à da abertura do chamado.<br/>"
                        End If
                    End If
                    If Not String.IsNullOrEmpty(TxtDataChegadaPrevista.Text) AndAlso isValidDate(TxtDataChegadaPrevista.Text) Then
                        If objChamado.DDataChamado > CDate(TxtDataChegadaPrevista.Text) Then
                            LblErro.Text += "- Data de previsão de chegada não pode ser inferior à da abertura do chamado.<br/>"
                        End If
                    End If
                    If Not String.IsNullOrEmpty(TxtDataEntrega.Text) AndAlso isValidDate(TxtDataEntrega.Text) Then
                        If objChamado.DDataChamado > CDate(TxtDataEntrega.Text) Then
                            LblErro.Text += "- Data de previsão de encerramento não pode ser inferior à da abertura do chamado.<br/>"
                        End If
                    End If
                End If
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

    Private Function CarregaObjeto(ByVal ObjPedido As UCLPedidoVenda, ByVal encerrar As En_EncerrarOS) As UCLPedidoVenda
        Try
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objClienteFinanceiro As New UCLClienteFinanceiro
            Dim cnpj As String

            objChamado.Empresa = Empresa
            objChamado.CodChamado = IIf(String.IsNullOrEmpty(TxtNrChamado.Text), CodAtendimento, TxtNrChamado.Text)
            objChamado.Buscar()

            cnpj = objChamado.Cnpj

            If Acao = "INCLUIR" Then
                objClienteFinanceiro.CodEmitente = LblCodEmitente.Text
                objClienteFinanceiro.Empresa = Empresa
                objClienteFinanceiro.Buscar()
                ObjPedido.codAgenteVenda = Session("GlCodUsuario")
                ObjPedido.codCanalVenda = DdlCanalVenda.SelectedValue
                ObjPedido.codNaturOper = DdlNaturOper.SelectedValue
                ObjPedido.codIndicador = LblCodIndicador.Text
                ObjPedido.codFormaPagamento = DdlFormaPagamento.SelectedValue
                ObjPedido.codCondPagto = DdlCondicaoPagamento.SelectedValue
                ObjPedido.dataEmissao = Now.Date.ToString("dd/MM/yyyy")
                ObjPedido.dataEntrega = TxtDataEntrega.Text
                ObjPedido.HoraEntrega = TxtHoraEntrega.Text
                ObjPedido.codEmitente = LblCodEmitente.Text
                ObjPedido.cnpjFaturamento = DdlCNPJFaturamento.SelectedValue 'IIf(String.IsNullOrEmpty(cnpj), GetCNPJ(TipoCNPJ.Preferencial), cnpj)
                ObjPedido.cnpjCobranca = DdlCNPJCobranca.SelectedValue 'GetCNPJ(TipoCNPJ.Cobranca)
                ObjPedido.cnpjEntrega = DdlCNPJEntrega.SelectedValue 'IIf(String.IsNullOrEmpty(cnpj), GetCNPJ(TipoCNPJ.Preferencial), cnpj)
                ObjPedido.tipoFrete = DdlTipoFrete.Text
                ObjPedido.codTransportador = TxtCodTransportadora.Text
                ObjPedido.dataCadastramento = Now.ToString("dd/MM/yyyyHH:mm")
                ObjPedido.codUsuarioCadastro = Session("GlCodUsuario")
                ObjPedido.statusRecebimento = DdlStatusRecebimento.SelectedValue
                ObjPedido.situacaoFaturamento = 1
                ObjPedido.IdOS = "S"
                ObjPedido.situacaoEntrega = 1
                ObjPedido.situacaoAprovacao1 = 1
                ObjPedido.situacaoAprovacao2 = 1
                ObjPedido.statusDigitacao = DdlStatus.SelectedValue
                ObjPedido.totalMercadoria = 0
                ObjPedido.SAG = TxtSag.Text
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
                ObjPedido.idContrato = IIf(CbxContrato.Checked, "S", "N")
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
                ObjPedido.observacaoNaoFiscal = TxtObservacaoNaoFiscal.Text.GetValidInputContent
                If ObjPedido.statusDigitacao = "2" Then
                    If String.IsNullOrWhiteSpace(TxtDataEncerramento.Text) Then
                        TxtDataEncerramento.Text = Now.ToString("dd/MM/yyyy")
                    End If
                    If String.IsNullOrWhiteSpace(TxtHoraEncerramento.Text) Then
                        TxtHoraEncerramento.Text = Now.ToString("HH:mm")
                    End If
                End If
                ObjPedido.dataEncerramento = TxtDataEncerramento.Text
                ObjPedido.hHoraEncerramento = TxtHoraEncerramento.Text
                ObjPedido.DataChegada = TxtDataChegada.Text
                ObjPedido.hHoraChegada = TxtHoraChegada.Text
                ObjPedido.DataChegadaPrevista = TxtDataChegadaPrevista.Text
                ObjPedido.hHoraChegadaPrevista = TxtHoraChegadaPrevista.Text
                ObjPedido.aux1 = TxtAux1.Text
                If CbxImprimirMatricial.Checked Then
                    ObjPedido.ImprimirMatricial = "S"
                Else
                    ObjPedido.ImprimirMatricial = "N"
                End If
                ObjPedido.codCfps = objClienteFinanceiro.CodCFPS
            Else
                ObjPedido.aux1 = TxtAux1.Text
                ObjPedido.IdOS = "S"
                ObjPedido.dataEntrega = TxtDataEntrega.Text
                ObjPedido.dataAlteracao = Now.ToString("dd/MM/yyyyHH:mm")
                ObjPedido.codUsuarioAlteracao = Session("GlCodUsuario")

                If encerrar = En_EncerrarOS.Encerrar Then
                    DdlStatus.SelectedValue = "2"
                ElseIf encerrar = En_EncerrarOS.NaoEncerrar Then
                    DdlStatus.SelectedValue = "1"
                End If

                ObjPedido.statusDigitacao = DdlStatus.SelectedValue
                ObjPedido.statusRecebimento = DdlStatusRecebimento.SelectedValue
                ObjPedido.codChamado = IIf(String.IsNullOrEmpty(TxtNrChamado.Text), CodAtendimento, TxtNrChamado.Text)
                ObjPedido.HoraEntrega = TxtHoraEntrega.Text
                ObjPedido.observacao = TxtObservacao.Text.GetValidInputContent
                ObjPedido.observacaoNaoFiscal = TxtObservacaoNaoFiscal.Text.GetValidInputContent
                If ObjPedido.statusDigitacao = "2" Then
                    If String.IsNullOrWhiteSpace(TxtDataEncerramento.Text) Then
                        TxtDataEncerramento.Text = Now.ToString("dd/MM/yyyy")
                    End If
                    If String.IsNullOrWhiteSpace(TxtHoraEncerramento.Text) Then
                        TxtHoraEncerramento.Text = Now.ToString("HH:mm")
                    End If
                End If

                ObjPedido.dataEncerramento = TxtDataEncerramento.Text
                ObjPedido.hHoraEncerramento = TxtHoraEncerramento.Text

                ObjPedido.dataInicioExecucao = TxtDataInicioExecucao.Text
                ObjPedido.hHoraInicioExecucao = TxtHoraInicioExecucao.Text
                ObjPedido.dataTerminoExecucao = TxtDataTerminoExecucao.Text
                ObjPedido.hHoraTerminoExecucao = TxtHoraTerminoExecucao.Text
                ObjPedido.codCanalVenda = DdlCanalVenda.SelectedValue
                ObjPedido.codNaturOper = DdlNaturOper.SelectedValue
                ObjPedido.DataChegada = TxtDataChegada.Text
                ObjPedido.hHoraChegada = TxtHoraChegada.Text
                ObjPedido.DataChegadaPrevista = TxtDataChegadaPrevista.Text
                ObjPedido.hHoraChegadaPrevista = TxtHoraChegadaPrevista.Text
                ObjPedido.SAG = TxtSag.Text
                If CbxImprimirMatricial.Checked Then
                    ObjPedido.ImprimirMatricial = "S"
                Else
                    ObjPedido.ImprimirMatricial = "N"
                End If
                ObjPedido.cnpjFaturamento = DdlCNPJFaturamento.SelectedValue
                ObjPedido.cnpjCobranca = DdlCNPJCobranca.SelectedValue
                ObjPedido.cnpjEntrega = DdlCNPJEntrega.SelectedValue
                ObjPedido.codFormaPagamento = DdlFormaPagamento.SelectedValue
                ObjPedido.codCondPagto = DdlCondicaoPagamento.SelectedValue
                ObjPedido.tipoFrete = DdlTipoFrete.SelectedValue
                ObjPedido.codTransportador = TxtCodTransportadora.Text
                ObjPedido.idContrato = IIf(CbxContrato.Checked, "S", "N")
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
            Call StatusDigitacaoMudou()
        End If
    End Sub

    Protected Sub VerificaNovoChamado()
        Try
            Dim objchamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim qtd As Long
            objchamado.Empresa = Empresa
            objchamado.CodChamado = CodAtendimento
            qtd = objchamado.QtdOSAlemDesta(TxtCodPedidoVenda.Text)
            If qtd > 0 Then
                LblMtvNvOS.Visible = True
                TxtAux1.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaDadosChamado()
        Try
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            objChamado.Empresa = Session("GlEmpresa")
            objChamado.CodChamado = TxtNrChamado.Text
            If Not String.IsNullOrWhiteSpace(objChamado.CodChamado) Then
                If objChamado.Buscar() Then
                    TxtOSCliente.Text = objChamado.OSCliente
                    TxtMotivoStatus.Text = objChamado.MotivoCancelamento
                    Dim objStatusChamado As New UCLStatusChamado
                    objStatusChamado.CodStatus = objChamado.CodStatus
                    If objStatusChamado.Buscar() Then
                        LblStatusChamado.Text = objStatusChamado.Descricao
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtNrChamado_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtNrChamado.TextChanged
        Call CarregaDadosChamado()
    End Sub

    Private Function ConfirmarEncerramentoOS() As Boolean
        Try
            Dim ObjEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            ObjEmitente.CodEmitente = LblCodEmitente.Text
            ObjEmitente.Buscar()

            If ObjEmitente.ConfirmacaoEncerramentoOS = "S" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function EstaEncerrandoEstaOS() As Boolean
        Try
            Dim ObjPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim StatusAtual As String
            Dim NovoStatus As String

            ObjPedidoVenda.empresa = Empresa
            ObjPedidoVenda.estabelecimento = Estabelecimento
            ObjPedidoVenda.codPedidoVenda = CodPedidoVenda
            ObjPedidoVenda.Buscar()

            StatusAtual = ObjPedidoVenda.statusDigitacao

            If StatusAtual Is Nothing OrElse StatusAtual.Trim = "" Then
                StatusAtual = "1"
            End If

            NovoStatus = DdlStatus.SelectedValue

            If NovoStatus = "2" And StatusAtual <> NovoStatus Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub StatusDigitacaoMudou()
        Try
            If EstaEncerrandoEstaOS() Then
                If ConfirmarEncerramentoOS() Then
                    BtnGravar.Attributes.Add("OnClick", "return confirm('Antes de encerrar a Ordem de Serviço, verifique se existe OS de retorno. Tem certeza de que deseja encerrar a O.S.?');")
                Else
                    BtnGravar.Attributes.Remove("OnClick")
                End If
            Else
                BtnGravar.Attributes.Remove("OnClick")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlStatus.SelectedIndexChanged
        Try
            Call StatusDigitacaoMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnCopiarInfoTecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCopiarInfoTecnico.Click
        TxtDataChegada.Text = TxtDataInicioExecucao.Text
        TxtHoraChegada.Text = TxtHoraInicioExecucao.Text
        TxtDataEncerramento.Text = TxtDataTerminoExecucao.Text
        TxtHoraEncerramento.Text = TxtHoraTerminoExecucao.Text
        If DdlStatus.SelectedValue = "1" AndAlso Not String.IsNullOrEmpty(TxtDataEncerramento.Text) Then
            DdlStatus.SelectedValue = "2"
            Call StatusDigitacaoMudou()
        End If
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objParametrosManutencao As New UCLParametrosManutencao

            Dim faixaDataI As Date = Now.AddMonths(-1)
            Dim faixaDataF As Date = Now.AddMonths(1)
            faixaDataI = New Date(faixaDataI.Year, faixaDataI.Month, 1)
            faixaDataF = New Date(faixaDataF.Year, faixaDataF.Month, Date.DaysInMonth(faixaDataF.Year, faixaDataF.Month))
            If DdlStatus.SelectedValue = "2" Then
                If Not String.IsNullOrEmpty(TxtDataEncerramento.Text) Then
                    If isValidDate(TxtDataEncerramento.Text) Then
                        If CDate(TxtDataEncerramento.Text) < faixaDataI OrElse CDate(TxtDataEncerramento.Text) > faixaDataF Then
                            LblConfirmacao.Text = "<b style=""color:Maroon"">ATENÇÃO:</b> Confirma encerramento da OS em " + TxtDataEncerramento.Text + "?"
                            AjustarVisibilidadePergunta(TipoPergunta.Confirmacao, True)
                            Return
                        End If
                    End If
                End If
            End If

            If Acao = "INCLUIR" OrElse DdlStatus.SelectedValue = "3" Then
                If GetSolicitarNumeroSerialEquipamentoOS() = "S" And DdlStatus.SelectedValue <> "3" Then
                    If GetNumeroSerialEquipamentosOSFoiInformado() Then
                        Call Gravar(En_EncerrarOS.ManterStatusInformadoEmTela)
                    Else
                        AjustarVisibilidadePergunta(TipoPergunta.NumeroSerialNaoInformadoNoEquipamentoDaOS, True)
                    End If
                Else
                    Call Gravar(En_EncerrarOS.ManterStatusInformadoEmTela)
                End If
            Else
                objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
                If objParametrosManutencao.GetConteudo("modelo_chamado_crm") <> 1 AndAlso DdlStatus.SelectedValue = 2 Then
                    If GetSolicitarNumeroSerialEquipamentoOS() = "S" Then
                        If GetNumeroSerialEquipamentosOSFoiInformado() Then
                            Call Gravar(En_EncerrarOS.ManterStatusInformadoEmTela)
                        Else
                            AjustarVisibilidadePergunta(TipoPergunta.NumeroSerialNaoInformadoNoEquipamentoDaOS, True)
                        End If
                    Else
                        Call Gravar(En_EncerrarOS.ManterStatusInformadoEmTela)
                    End If
                Else
                    If objParametrosManutencao.GetConteudo("pergunta_deseja_encerrar_os") = "S" Then
                        Call AjustarVisibilidadePergunta(TipoPergunta.DesejaEncerrarAOS, True)
                    Else
                        Call Gravar(En_EncerrarOS.ManterStatusInformadoEmTela)
                    End If
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnEncerraOS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEncerraOS.Click
        Try
            If LblConfirmacao.Visible Then
                Call AjustarVisibilidadePergunta(TipoPergunta.DesejaEncerrarAOS, False)
                Call AjustarVisibilidadePergunta(TipoPergunta.NumeroSerialNaoInformadoNoEquipamentoDaOS, False)
                Call AjustarVisibilidadePergunta(TipoPergunta.Confirmacao, False)
                Call Gravar(En_EncerrarOS.Encerrar)
            Else
                If LblNumeroSerialEquipamentoNaoInformado.Visible Then
                    Call AjustarVisibilidadePergunta(TipoPergunta.DesejaEncerrarAOS, False)
                    Call AjustarVisibilidadePergunta(TipoPergunta.NumeroSerialNaoInformadoNoEquipamentoDaOS, False)
                    Call AjustarVisibilidadePergunta(TipoPergunta.Confirmacao, False)
                    Call Gravar(En_EncerrarOS.Encerrar)
                Else
                    If GetSolicitarNumeroSerialEquipamentoOS() = "S" Then
                        If GetNumeroSerialEquipamentosOSFoiInformado() Then
                            Call AjustarVisibilidadePergunta(TipoPergunta.DesejaEncerrarAOS, False)
                            Call AjustarVisibilidadePergunta(TipoPergunta.NumeroSerialNaoInformadoNoEquipamentoDaOS, False)
                            Call AjustarVisibilidadePergunta(TipoPergunta.Confirmacao, False)
                            Call Gravar(En_EncerrarOS.Encerrar)
                        Else
                            Call AjustarVisibilidadePergunta(TipoPergunta.NumeroSerialNaoInformadoNoEquipamentoDaOS, True)
                        End If
                    Else
                        Call AjustarVisibilidadePergunta(TipoPergunta.DesejaEncerrarAOS, False)
                        Call AjustarVisibilidadePergunta(TipoPergunta.NumeroSerialNaoInformadoNoEquipamentoDaOS, False)
                        Call AjustarVisibilidadePergunta(TipoPergunta.Confirmacao, False)
                        Call Gravar(En_EncerrarOS.Encerrar)
                    End If
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnNaoEncerraOS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNaoEncerraOS.Click
        Try
            Call AjustarVisibilidadePergunta(TipoPergunta.Confirmacao, False)
            Call AjustarVisibilidadePergunta(TipoPergunta.DesejaEncerrarAOS, False)
            Call AjustarVisibilidadePergunta(TipoPergunta.NumeroSerialNaoInformadoNoEquipamentoDaOS, False)
            Call Gravar(En_EncerrarOS.NaoEncerrar)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Function GetSolicitarNumeroSerialEquipamentoOS() As String
        Try
            Dim objEmitente As New UCLEmitente(StrConexao)
            Return objEmitente.GetSolicitarNumeroSerialTerceiroOS(LblCodEmitente.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetNumeroSerialEquipamentosOSFoiInformado() As Boolean
        Try
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)
            Dim strSql As String
            Dim dt As DataTable
            Dim qtdSolicitacao As Integer
            Dim qtdInformado As Integer

            strSql = " select count(1) qtd "
            strSql += "  from pedido_venda_solicitacao ps"
            strSql += " where ps.empresa = " + Empresa + " and ps.estabelecimento = " + Estabelecimento + " and ps.cod_pedido_venda = " + CodPedidoVenda
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                qtdSolicitacao = dt.Rows.Item(0).Item("qtd")
            Else
                qtdSolicitacao = 0
            End If

            If qtdSolicitacao > 0 Then
                strSql = " select count(1) qtd "
                strSql += "  from pedido_venda_solicitacao ps inner join equipamento e on ps.empresa = e.empresa and ps.numero_serie = e.numero_serie "
                strSql += " where ps.empresa = " + Empresa + " and ps.estabelecimento = " + Estabelecimento + " and ps.cod_pedido_venda = " + CodPedidoVenda + " and isnull(e.numero_serie_terceiro,'') <> ''"
                dt = objAcessoDados.BuscarDados(strSql)
                If dt.Rows.Count > 0 Then
                    qtdInformado = dt.Rows.Item(0).Item("qtd")
                Else
                    qtdInformado = 0
                End If

                If qtdInformado < qtdSolicitacao Then
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CarregaCanalVenda()
        Dim objCanalVenda As New UCLCanalVenda
        objCanalVenda.Empresa = Session("GlEmpresa")
        objCanalVenda.FillControl(DdlCanalVenda, True, "")
    End Sub

    Private Sub CarregaNatureza()
        Dim objNatureza As New UCLNaturezaOperacao
        objNatureza.FillDropDown(DdlNaturOper, True, "")
    End Sub

    Private Sub CarregaCondPagto()
        Dim objCondPagto As New UCLCondicaoPagamento
        objCondPagto.FillDropDown(DdlCondicaoPagamento, True, "")
    End Sub

    Private Sub CarregaFormaPagto()
        Dim objFormaPagto As New UCLFormaPagto
        objFormaPagto.FillDropDown(DdlFormaPagamento, True, "")
    End Sub

    Private Sub CarregaCNPJ()
        Try
            Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
            If Not String.IsNullOrEmpty(LblCodEmitente.Text) Then
                objEnderecoEmitente.CodEmitente = LblCodEmitente.Text
                objEnderecoEmitente.FillDropDownCNPJ(DdlCNPJFaturamento, True)
                objEnderecoEmitente.FillDropDownCNPJ(DdlCNPJCobranca, True)
                objEnderecoEmitente.FillDropDownCNPJ(DdlCNPJEntrega, True)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CodigoTransportadoraMudou()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

        objEmitente.CodEmitente = IIf(String.IsNullOrEmpty(TxtCodTransportadora.Text), "0", TxtCodTransportadora.Text)
        objEmitente.Buscar()
        LblNomeTransportadora.Text = objEmitente.Nome

        Session("SCodTransportadoraNegociacao") = TxtCodTransportadora.Text
        Session("SCodTransportadoraPesquisado") = TxtCodTransportadora.Text
    End Sub

    Private Sub MostraNomeTransportadora()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            If Not String.IsNullOrEmpty(TxtCodTransportadora.Text) Then
                objEmitente.CodEmitente = TxtCodTransportadora.Text
                objEmitente.Buscar()
                LblNomeTransportadora.Text = objEmitente.Nome
            Else
                LblNomeTransportadora.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtCodTransportadora_TextChanged(sender As Object, e As EventArgs) Handles TxtCodTransportadora.TextChanged
        Try
            Call CodigoTransportadoraMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class