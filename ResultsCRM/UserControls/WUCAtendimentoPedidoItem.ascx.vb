Partial Public Class WUCAtendimentoPedidoItem
    Inherits System.Web.UI.UserControl

    Private _empresa As String
    Private _estabelecimento As String
    Private _codPedidoVenda As String
    Private _seqItem As String
    Private _acao As String
    Private _camVoltar As String

    Public Property MostraBotaoVoltar As Boolean = False

    Public Property CaminhoVoltar() As String
        Get
            Return _camVoltar
        End Get
        Set(ByVal value As String)
            _camVoltar = value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return _empresa
        End Get
        Set(ByVal value As String)
            _empresa = value
        End Set
    End Property

    Public Property Estabelecimento() As String
        Get
            Return _estabelecimento
        End Get
        Set(ByVal value As String)
            _estabelecimento = value
        End Set
    End Property

    Public Property CodPedidoVenda() As String
        Get
            Return _codPedidoVenda
        End Get
        Set(ByVal value As String)
            _codPedidoVenda = value
        End Set
    End Property

    Public Property SeqItem() As String
        Get
            Return _seqItem
        End Get
        Set(ByVal value As String)
            _seqItem = value
        End Set
    End Property

    Public Property Acao() As String
        Get
            Return _acao
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "INCLUIR"
                    LblAcao.Text = "INCLUSÃO"
                    BtnGravar.Text = "Incluir"
                Case "ALTERAR"
                    LblAcao.Text = "ALTERAÇÃO"
                    BtnGravar.Text = "Salvar alterações"
            End Select
            _acao = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            TxtInicial.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtFinal.Attributes.Add("OnFocus", "selecionaCampo(this)")
            'TxtPrecoUnitario0.Attributes.Add("OnKeyPress", "mascara( this, mvalor );")
            TxtPrecoUnitario0.Attributes.Add("OnFocus", "selecionaCampo(this)")

            Session("SModoCadEquipamento") = WUCEquipamento.ModoJanela.AberturaPorOutraTela

            If Not IsPostBack Then
                Dim objAgenteTecnico As New UCLAgenteTecnico
                objAgenteTecnico.FillDropDown(DdlAgenteTecnico, True, "(selecione)", "")
                SetAgenteTecnico()
                Call Carregar()
                If CaminhoVoltar.Contains("WGOSItem.aspx") Then
                    BtnGravar0.Visible = False
                End If
            End If

            If Not String.IsNullOrEmpty(Session("SCodItemPesquisado")) Then
                If Session("SAlterouCodItem") = "S" Then
                    If TxtCodItem.Text <> Session("SCodItemPesquisado") Then
                        TxtCodItem.Text = Session("SCodItemPesquisado")
                        CodItemMudou(True)
                        Dim objItemReferencia As New UCLItemReferencia(StrConexao)
                        objItemReferencia.CodItem = Session("SCodItemPesquisado")
                        objItemReferencia.Referencia = Session("SReferenciaPesquisada")
                        objItemReferencia.FillDropDown(DdlReferencia, True, "(selecione)")
                        DdlReferencia.SelectedValue = Session("SReferenciaPesquisada")
                    End If
                    Session("SAlterouCodItem") = "N"
                End If
            End If

            If IsPostBack Then
                Call ChecaAlteracaoNumeroSerie()
                Call CalculaTotal()
                Call CarregaDescricaoItem()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub ChecaAlteracaoNumeroSerie()
        Try
            Dim NumeroSerieRetornado As String
            Dim recarregaEquipamentos As Long

            If Not String.IsNullOrEmpty(Session("SAlterouNumeroSerieItemPedido")) Then
                recarregaEquipamentos = Session("SAlterouNumeroSerieItemPedido")
            Else
                recarregaEquipamentos = 0
            End If

            If recarregaEquipamentos > 0 Then
                NumeroSerieRetornado = Session("SNumeroSerieItemPedido")
                Call CarregaEquipamentoCliente(NumeroSerieRetornado)
                If Not String.IsNullOrEmpty(NumeroSerieRetornado) Then
                    DdlEquipamento.SelectedValue = NumeroSerieRetornado
                End If
                Session("SAlterouNumeroSerieItemPedido") = recarregaEquipamentos - 2
                Call CarregaComponentes()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetAgenteTecnico()
        Try
            Dim tipoItem As String
            Dim objItem As New UCLItem
            Dim codAgenteTecnico As String = "0"
            Dim objPedidoVendaAgenteTecnico As New UCLPedidoVendaAgenteTecnico(StrConexao)
            Dim agentes As List(Of UCLAgenteTecnico)
            Dim objAgenteTecnico As New UCLAgenteTecnico

            tipoItem = objItem.GetTipoItem(TxtCodItem.Text)

            objPedidoVendaAgenteTecnico.Empresa = Empresa
            objPedidoVendaAgenteTecnico.Estabelecimento = Estabelecimento
            objPedidoVendaAgenteTecnico.CodPedidoVenda = CodPedidoVenda

            agentes = objPedidoVendaAgenteTecnico.AgentesTecnicos()

            If agentes.Count > 0 Then
                DdlAgenteTecnico.SelectedValue = agentes.Item(0).CodAgenteTecnico
            Else
                codAgenteTecnico = objAgenteTecnico.GetCodAgenteTecnico(Session("GlCodUsuario"))
                If Not String.IsNullOrEmpty(codAgenteTecnico) AndAlso codAgenteTecnico <> "0" AndAlso codAgenteTecnico <> "-1" Then
                    DdlAgenteTecnico.SelectedValue = codAgenteTecnico
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNatureza()
        Dim objNatureza As New UCLNaturezaOperacao
        objNatureza.FillDropDown(DdlNaturOper, True, "")
    End Sub

    Public Sub Carregar()
        Try
            Dim objParametrosManutencao As New UCLParametrosManutencao
            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
            If Session("GlTipoFaturamento").ToString = "G" Then
                LblEquipamentoLabel.Text = "Produto:"
                BtnIncluirEquipamento.ToolTip = "Incluir Produto"
                BtnIncluirEquipamento.AlternateText = BtnIncluirEquipamento.ToolTip
                BtnAlterarEquipamento.ToolTip = "Alterar informações do Produto"
                BtnIncluirEquipamento.AlternateText = "Alterar Produto"
                BtnPesquisarEquipamento.ToolTip = "Pesquisar Produto"
                BtnPesquisarEquipamento.AlternateText = BtnPesquisarEquipamento.ToolTip
                LblTipoCobranca.Visible = True
                DdlTipoCobranca.Visible = True
                DdlComponente.Visible = False
                DdlSolicitacao.Visible = True
                LblComponenteLabel.Text = "Solicitação:"
                BtnIncluirEquipamento.OnClientClick = "ShowEditModal('../Forms/WFEquipamento2.aspx?aid=I','EditModalPopupClientes','IframeEdit');"
                BtnAlterarEquipamento.OnClientClick = "ShowEditModal('../Forms/WFEquipamento2.aspx?aid=A','EditModalPopupClientes','IframeEdit');"
                BtnPesquisarEquipamento.OnClientClick = "ShowEditModal('../Pesquisas/WFPEquipamento2.aspx','EditModalPopupClientes','IframeEdit');"
                Call CarregaServicoSolicitado()
            End If
            If objParametrosManutencao.GetConteudo("modelo_chamado_crm") <> 1 Then
                LblTipoCobranca.Visible = True
                DdlTipoCobranca.Visible = True
            End If
            Call CarregaNatureza()
            If objParametrosManutencao.GetConteudo("mostrar_natureza_operacao_os_crm") = "S" Then
                LblNaturOper.Visible = True
                LblNaturezaQuebra.Visible = True
                DdlNaturOper.Visible = True
            Else
                LblNaturOper.Visible = False
                LblNaturezaQuebra.Visible = False
                DdlNaturOper.Visible = False
            End If
            If objParametrosManutencao.GetConteudo("lote_os_crm") = "S" Then
                LblLote.Visible = True
                LblLoteQuebra.Visible = True
                TxtLote.Visible = True
            Else
                LblLote.Visible = False
                LblLoteQuebra.Visible = False
                TxtLote.Visible = False
            End If

            Call CarregaTipoCobrancaOS()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            Else
                Call CarregaNovaPK()
                Call CarregaDDlItemContrato("")
                Call SetEquipamentoSeUnico() 'carrega ddl de equipamento e seta o equipamento, se houver um equipamento só e um serviço solicitado só, para facilitar o preenchimento
                '
                TxtCodItem.Text = ""
                TxtNarrativa.Text = ""
                TxtQuantidade.Text = ""
                TxtPrecoUnitario0.Text = "0,00"
                LblValorMercadoria.Text = "0,00"
                LblValorICMS.Text = "0,00"
                LblAliquotaICMS.Text = "0,0"
                LblValorIPI.Text = "0,00"
                LblAliquotaIPI.Text = "0,0"
                LblValorST.Text = "0,00"
                LblBaseICMSST.Text = "0,00"
                LblValorTotal.Text = "0,00"
                '
                If DdlItemContrato.Items.Count > 0 Then
                    RblSelecionarItemContrato.SelectedValue = "S"
                    TxtCodItem.Text = DdlItemContrato.SelectedValue
                Else
                    RblSelecionarItemContrato.SelectedValue = "N"
                End If
                Call AlteraVisibilidadeItem(RblSelecionarItemContrato.SelectedValue)

                Call CodItemMudou(True)
                TxtQuantidade.Text = 0
            End If

            If MostraBotaoVoltar Then
                BtnVoltar.Visible = True
            Else
                BtnVoltar.Visible = False
            End If
            TxtInicial.AutoPostBack = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
            TxtFinal.AutoPostBack = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CarregaTipoCobrancaOS()
        Try
            Dim ObjTipoCobrancaOS As New UCLTipoCobrancaOS
            ObjTipoCobrancaOS.FillDropDown(DdlTipoCobranca, True, "(selecione)", "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CarregaServicoSolicitado()
        Try
            Dim ObjPedidoVendaSolicitacao As New UCLPedidoVendaSolicitacao(StrConexao)
            ObjPedidoVendaSolicitacao.Empresa = Empresa
            ObjPedidoVendaSolicitacao.Estabelecimento = Estabelecimento
            ObjPedidoVendaSolicitacao.CodPedidoVenda = CodPedidoVenda
            ObjPedidoVendaSolicitacao.FillDropDown(DdlSolicitacao, True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaEquipamentoCliente(ByVal numeroSerieSelecionado As String)
        Try
            Dim objEquipamentoCliente As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objParametrosManutencao As New UCLParametrosManutencao

            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))

            objPedidoVenda.empresa = Empresa
            objPedidoVenda.estabelecimento = Estabelecimento
            objPedidoVenda.codPedidoVenda = CodPedidoVenda
            objPedidoVenda.Buscar()
            If Not String.IsNullOrEmpty(objPedidoVenda.codChamado) Then
                objChamado.Empresa = objPedidoVenda.empresa
                objChamado.CodChamado = objPedidoVenda.codChamado
                objChamado.Buscar()

                objEquipamentoCliente.Empresa = objChamado.Empresa
                If Not String.IsNullOrEmpty(objChamado.CodEmitenteAtendimento) And Not String.IsNullOrEmpty(objChamado.NumeroPontoAtendimento) Then
                    objEquipamentoCliente.CodCliente = objChamado.CodEmitenteAtendimento
                    objEquipamentoCliente.NumeroPontoAtendimento = objChamado.NumeroPontoAtendimento
                    Session("SPAEquipamento") = objChamado.NumeroPontoAtendimento
                    Session("SCliEquipamento") = objChamado.CodEmitenteAtendimento
                Else
                    objEquipamentoCliente.CodCliente = objChamado.CodEmitente
                    objEquipamentoCliente.NumeroPontoAtendimento = ""
                    Session("SPAEquipamento") = ""
                    Session("SCliEquipamento") = objChamado.CodEmitente
                End If
                If Session("GlTipoFaturamento").ToString = "G" OrElse objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 4 Then
                    objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.DescricaoItem, numeroSerieSelecionado)
                Else
                    objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.Observacao, numeroSerieSelecionado)
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim objPedidoItem As New UCLPedidoVendaItem(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objItemReferencia As New UCLItemReferencia(StrConexao)
            Dim tipoItem As String
            Dim objItem As New UCLItem

            objPedidoItem.empresa = Empresa
            objPedidoItem.estabelecimento = Estabelecimento
            objPedidoItem.codPedidoVenda = CodPedidoVenda
            objPedidoItem.seqItem = SeqItem
            objPedidoItem.Buscar()

            objPedido.empresa = Empresa
            objPedido.estabelecimento = Estabelecimento
            objPedido.codPedidoVenda = CodPedidoVenda
            objPedido.Buscar()

            objChamado.Empresa = objPedidoItem.empresa
            objChamado.CodChamado = objPedido.codChamado
            If Not String.IsNullOrEmpty(objChamado.Empresa) And Not String.IsNullOrEmpty(objChamado.CodChamado) Then
                If objChamado.Buscar() Then
                    Session("SCodEmitenteAtNegociacao") = objChamado.CodEmitenteAtendimento
                    Session("SPontoAtendimento") = objChamado.NumeroPontoAtendimento
                End If
            End If

            Call CarregaDDlItemContrato("")
            If DdlItemContrato.Items.Count > 0 AndAlso DdlItemContrato.Items.FindByValue(objPedidoItem.codItem) IsNot Nothing Then
                RblSelecionarItemContrato.SelectedValue = "S"
            Else
                Call CarregaDDlItemContrato(objPedidoItem.codItem)
                RblSelecionarItemContrato.SelectedValue = "N"
            End If

            Call AlteraVisibilidadeItem(RblSelecionarItemContrato.SelectedValue)

            LblSeqItem.Text = SeqItem
            TxtCodItem.Text = objPedidoItem.codItem
            TxtLote.Text = objPedidoItem.lote
            DdlItemContrato.SelectedValue = TxtCodItem.Text
            DdlNaturOper.SelectedValue = objPedidoItem.codNaturOper
            TxtNarrativa.Text = objPedidoItem.narrativa
            TxtQuantidade.Text = CDbl(objPedidoItem.qtdPedida).ToString
            TxtPrecoUnitario0.Text = CDbl(objPedidoItem.precoUnitario).ToString("F2")
            LblValorMercadoria.Text = CDbl(objPedidoItem.valorMercadoria).ToString("F2")
            LblValorICMS.Text = CDbl(objPedidoItem.valorIcms).ToString("F2")
            LblAliquotaICMS.Text = CDbl(objPedidoItem.aliquotaIcms).ToString("F1")
            LblValorIPI.Text = CDbl(objPedidoItem.valorIpi).ToString("F2")
            LblAliquotaIPI.Text = CDbl(objPedidoItem.aliquotaIpi).ToString("F1")
            LblValorST.Text = CDbl(objPedidoItem.icmsSubstituicao).ToString("F2")
            LblBaseICMSST.Text = CDbl(objPedidoItem.baseIcmsSubstituicao).ToString("F2")
            LblValorTotal.Text = CDbl(objPedidoItem.valorTotalMercadoria).ToString("F2")
            TxtDataEntrega.Text = objPedidoItem.DataEntrega
            If Not String.IsNullOrWhiteSpace(objPedidoItem.codTipoCobrancaOS) Then
                DdlTipoCobranca.SelectedValue = objPedidoItem.codTipoCobrancaOS
            End If

            tipoItem = objItem.GetTipoItem(TxtCodItem.Text)

            If tipoItem = "1" Then
                TxtInicial.Text = objPedidoItem.HoraInicial
                TxtFinal.Text = objPedidoItem.HoraFinal
                DdlAgenteTecnico.Visible = True
                LblAgenteTecnico.Visible = True
                DdlAgenteTecnico.SelectedValue = objPedidoItem.CodAgenteTecnico
            ElseIf tipoItem = "2" Then
                TxtInicial.Text = objPedidoItem.KmInicial
                TxtFinal.Text = objPedidoItem.KmFinal
                TxtLocalOrigem.Text = objPedidoItem.LocalOrigem
                TxtLocalDestino.Text = objPedidoItem.LocalDestino
                DdlAgenteTecnico.Visible = True
                LblAgenteTecnico.Visible = True
                DdlAgenteTecnico.SelectedValue = objPedidoItem.CodAgenteTecnico
            Else
                DdlAgenteTecnico.Visible = False
                LblAgenteTecnico.Visible = False
            End If
            Call CarregaEquipamentoCliente(objPedidoItem.numeroSerie)
            If Not String.IsNullOrEmpty(objPedidoItem.numeroSerie) Then
                If DdlEquipamento.Items.FindByValue(objPedidoItem.numeroSerie) IsNot Nothing Then
                    DdlEquipamento.SelectedValue = objPedidoItem.numeroSerie
                    Call CarregaComponentes()
                    Session("SNumeroSerieItemPedido") = objPedidoItem.numeroSerie
                    If DdlComponente.Items.FindByValue(objPedidoItem.seqComponente) IsNot Nothing Then
                        DdlComponente.SelectedValue = objPedidoItem.seqComponente
                    End If
                Else
                    Session("SNumeroSerieItemPedido") = ""
                End If
            Else
                Session("SNumeroSerieItemPedido") = ""
            End If

            Call CarregaDescricaoItem()
            Call CodItemMudou(False)

            objItemReferencia.CodItem = objPedidoItem.codItem
            objItemReferencia.Referencia = objPedidoItem.referencia
            objItemReferencia.FillDropDown(DdlReferencia, True, "(selecione)")
            DdlReferencia.SelectedValue = objPedidoItem.referencia

            Call CalculaTotal()

            If Session("GlTipoFaturamento").ToString = "G" AndAlso Not String.IsNullOrWhiteSpace(objPedidoItem.seqSolicitacao) Then
                DdlSolicitacao.SelectedValue = objPedidoItem.seqSolicitacao
            End If

            TxtNarrativa.Text = objPedidoItem.narrativa
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CodItemMudou(ByVal alterarCodNaturOper As Boolean)
        Try
            Dim codNaturOper As String = ""
            Dim objItem As New UCLItem
            Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim tipoItem As String
            Dim codContrato As String = ""
            Dim objContrato As New UCLContratoManutencao
            Dim objContratoItem As New UCLContratoManutencaoItem
            Dim objChamado As New UCLAtendimento(StrConexao)
            Dim objParametrosManutencao As New UCLParametrosManutencao
            Dim dataIni As Date
            Dim dataFim As Date
            Dim qtdContratada As Double
            Dim qtdConsumida As Double
            Dim codEmitenteAtendimento As String = ""
            Dim numeroPontoAtendimento As String = ""
            Dim aplicacao As AplicacaoItem = AplicacaoItem.Produto
            Dim MesmoEstado As Boolean = False
            Dim objItemReferencia As New UCLItemReferencia(StrConexao)
            LblContrato.Text = ""

            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))

            Call CarregaDescricaoItem()

            If String.IsNullOrWhiteSpace(TxtDataEntrega.Text) Then
                TxtDataEntrega.Text = Now.ToString("dd/MM/yyyy")
            End If

            objPedidoVenda.empresa = Empresa
            objPedidoVenda.estabelecimento = Estabelecimento
            objPedidoVenda.codPedidoVenda = CodPedidoVenda
            objPedidoVenda.Buscar()

            If Not String.IsNullOrEmpty(objPedidoVenda.codChamado) Then
                objChamado.Empresa = objPedidoVenda.empresa
                objChamado.CodChamado = objPedidoVenda.codChamado
                objChamado.Buscar()
                codContrato = objChamado.Contrato
                codEmitenteAtendimento = objChamado.CodEmitenteAtendimento
                numeroPontoAtendimento = objChamado.NumeroPontoAtendimento
            End If

            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                tipoItem = objItem.GetTipoItem(TxtCodItem.Text)

                If tipoItem = "1" Then
                    Select Case objContratoItem.GetTipoHorasItemContrato(Session("GlEmpresa"), codContrato, TxtCodItem.Text)
                        Case "0", "2"
                            If TxtPrecoUnitario0.Text.ToString = "0,00" Then
                                TxtPrecoUnitario0.Text = objItem.PrecoItemCliente(Empresa, Estabelecimento, objPedidoVenda.codEmitente, objPedidoVenda.cnpjFaturamento, TxtCodItem.Text, codContrato, codEmitenteAtendimento, numeroPontoAtendimento).ToString("F2")
                            End If
                        Case Else
                            TxtPrecoUnitario0.Text = "0,00"
                    End Select
                Else
                    If TxtPrecoUnitario0.Text.ToString = "0,00" Then
                        TxtPrecoUnitario0.Text = objItem.PrecoItemCliente(Empresa, Estabelecimento, objPedidoVenda.codEmitente, objPedidoVenda.cnpjFaturamento, TxtCodItem.Text, codContrato, codEmitenteAtendimento, numeroPontoAtendimento).ToString("F2")
                    End If
                End If

                If DdlTipoCobranca.Items.Count > 0 Then
                    If Not IsExtraContrato(DdlTipoCobranca.SelectedValue) Then
                        TxtPrecoUnitario0.Text = "0,00"
                    End If
                End If

                TxtNarrativa.Text = objItem.GetNarrativa(TxtCodItem.Text)
                Session("SCodItemPesquisado") = TxtCodItem.Text

                If tipoItem = "1" Then
                    dataIni = CDate(TxtDataEntrega.Text)
                    dataIni = New Date(Year(dataIni), Month(dataIni), 1)
                    dataFim = dataIni.AddMonths(1).AddDays(-1)
                    qtdContratada = objContrato.GetQuantidadeContratada(Session("GlEmpresa"), codContrato, TxtCodItem.Text)
                    If qtdContratada <> 0 Then
                        qtdConsumida = objContrato.GetQuantidadeConsumidaNoPeriodo(Session("GlEmpresa"), Session("GlEstabelecimento"), codContrato, TxtCodItem.Text, dataIni, dataFim)
                        LblContrato.Text += "<br/><u>HORAS CONTRATADAS:</u><br/>"
                        LblContrato.Text += "Qtd. contratada: " + qtdContratada.ToString("F2") + " h<br/>"
                        LblContrato.Text += "Qtd. consumida no período: " + qtdConsumida.ToString("F2") + " h<br/>"
                        LblContrato.Text += "Qtd. restante: " + (qtdContratada - qtdConsumida).ToString("F2") + " h<br/>"
                    End If
                ElseIf tipoItem = "2" Then
                    If Not String.IsNullOrEmpty(codEmitenteAtendimento) AndAlso Not String.IsNullOrEmpty(numeroPontoAtendimento) Then
                        TxtQuantidade.Text = GetDistanciaPontoAtendimento(codEmitenteAtendimento, numeroPontoAtendimento)
                    End If
                    Call CalculaTotal()
                End If

                objItemReferencia.CodItem = TxtCodItem.Text
                objItemReferencia.Referencia = ""
                objItemReferencia.FillDropDown(DdlReferencia, True, "(selecione)")
            Else
                objItemReferencia.CodItem = ""
                objItemReferencia.Referencia = ""
                objItemReferencia.FillDropDown(DdlReferencia, True, "(selecione)")
                tipoItem = "3"
            End If

            If Not String.IsNullOrWhiteSpace(TxtCodItem.Text) Then
                objItem.CodItem = TxtCodItem.Text
                objItem.Buscar()
                aplicacao = objItem.Aplicacao
            End If

            Dim objParametrosFaturamento As New UCLParametrosFaturamento
            objParametrosFaturamento.Empresa = Empresa
            objParametrosFaturamento.Estabelecimento = Estabelecimento
            objParametrosFaturamento.Buscar()

            MesmoEstado = ClienteDoMesmoEstado(objPedidoVenda.empresa, objPedidoVenda.estabelecimento, objPedidoVenda.codEmitente, objPedidoVenda.cnpjFaturamento)

            If aplicacao = AplicacaoItem.Produto Then
                If MesmoEstado Then
                    codNaturOper = objParametrosFaturamento.CodNaturOperContratoProdutoDentroEstado
                Else
                    codNaturOper = objParametrosFaturamento.CodNaturOperContratoProdutoForaEstado
                End If
            ElseIf aplicacao = AplicacaoItem.Servico Then
                If MesmoEstado Then
                    codNaturOper = objParametrosFaturamento.CodNaturOperContratoServicoDentroEstado
                Else
                    codNaturOper = objParametrosFaturamento.CodNaturOperContratoServicoForaEstado
                End If
            End If

            If String.IsNullOrEmpty(codNaturOper) Then
                codNaturOper = objPedidoVenda.codNaturOper
            End If

            If alterarCodNaturOper Then
                codNaturOper = GetTabelaIcmsCfop(objPedidoVenda.empresa, objPedidoVenda.estabelecimento, TxtCodItem.Text, objPedidoVenda.cnpjFaturamento, codNaturOper)
            Else
                codNaturOper = DdlNaturOper.SelectedValue
            End If

            DdlNaturOper.SelectedValue = codNaturOper

            Select Case tipoItem
                Case "1"
                    LblQuantidade.Visible = False
                    TxtQuantidade.Visible = False
                    LblInicial.Visible = True
                    TxtInicial.Visible = True
                    LblFinal.Visible = True
                    TxtFinal.Visible = True
                    LblDataEntrega.Visible = True
                    TxtDataEntrega.Visible = True
                    LblLocalOrigem.Visible = False
                    TxtLocalOrigem.Visible = False
                    LblLocalDestino.Visible = False
                    TxtLocalDestino.Visible = False
                    LblDescricao.Visible = True
                    TxtNarrativa.Visible = True
                    'TxtNarrativa.TextMode = TextBoxMode.MultiLine
                    'TxtNarrativa.Height = New System.Web.UI.WebControls.Unit(60, UnitType.Pixel)
                    TxtInicial.Attributes.Add("OnKeyPress", "formatacampo(this,'##:##')")
                    TxtFinal.Attributes.Add("OnKeyPress", "formatacampo(this,'##:##')")
                    TxtQuantidade.Enabled = False
                    LblLabelRSUnitario.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    TxtPrecoUnitario0.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblLabelTotalMercadoria.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblValorMercadoria.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblLabelIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblMoedaIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblValorIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblParenteseEsquerdoIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblAliquotaIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblParenteseDireitoIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblLabelST.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblMoedaST.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblValorST.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblLabelTotalGeral.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblValorTotal.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    DdlAgenteTecnico.Visible = True
                    LblAgenteTecnico.Visible = True
                Case "2"
                    LblQuantidade.Visible = False
                    TxtQuantidade.Visible = False
                    LblInicial.Visible = True
                    TxtInicial.Visible = True
                    LblFinal.Visible = True
                    TxtFinal.Visible = True
                    LblDataEntrega.Visible = True
                    TxtDataEntrega.Visible = True
                    LblLocalOrigem.Visible = True
                    TxtLocalOrigem.Visible = True
                    LblLocalDestino.Visible = True
                    TxtLocalDestino.Visible = True
                    LblDescricao.Visible = False
                    TxtNarrativa.Visible = False
                    'TxtNarrativa.TextMode = TextBoxMode.SingleLine
                    'TxtNarrativa.Height = New System.Web.UI.WebControls.Unit(18, UnitType.Pixel)
                    TxtInicial.Attributes.Remove("OnKeyPress")
                    TxtFinal.Attributes.Remove("OnKeyPress")
                    TxtQuantidade.Enabled = True
                    LblLabelRSUnitario.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    TxtPrecoUnitario0.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblLabelTotalMercadoria.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblValorMercadoria.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblLabelIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblMoedaIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblValorIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblParenteseEsquerdoIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblAliquotaIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblParenteseDireitoIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblLabelST.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblMoedaST.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblValorST.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblLabelTotalGeral.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblValorTotal.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    DdlAgenteTecnico.Visible = True
                    LblAgenteTecnico.Visible = True
                Case Else
                    LblQuantidade.Visible = True
                    TxtQuantidade.Visible = True
                    LblInicial.Visible = False
                    TxtInicial.Visible = False
                    LblFinal.Visible = False
                    TxtFinal.Visible = False
                    If objParametrosManutencao.GetConteudo("modelo_chamado_crm") <> 1 Then
                        LblDataEntrega.Visible = True
                        TxtDataEntrega.Visible = True
                    Else
                        LblDataEntrega.Visible = False
                        TxtDataEntrega.Visible = False
                    End If
                    LblLocalOrigem.Visible = False
                    TxtLocalOrigem.Visible = False
                    LblLocalDestino.Visible = False
                    TxtLocalDestino.Visible = False
                    LblDescricao.Visible = True
                    TxtNarrativa.Visible = True
                    'TxtNarrativa.TextMode = TextBoxMode.SingleLine
                    'TxtNarrativa.Height = New System.Web.UI.WebControls.Unit(18, UnitType.Pixel)
                    TxtInicial.Attributes.Remove("OnKeyPress")
                    TxtFinal.Attributes.Remove("OnKeyPress")
                    TxtQuantidade.Enabled = True
                    LblLabelRSUnitario.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    TxtPrecoUnitario0.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblLabelTotalMercadoria.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblValorMercadoria.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblLabelIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblMoedaIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblValorIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblParenteseEsquerdoIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblAliquotaIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblParenteseDireitoIPI.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblLabelST.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblMoedaST.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblValorST.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblLabelTotalGeral.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    LblValorTotal.Visible = (objParametrosManutencao.GetConteudo("mostrar_valor_os_crm") = "S")
                    DdlAgenteTecnico.Visible = False
                    LblAgenteTecnico.Visible = False
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Enum TipoSalvamento As Integer
        SalvarFechar = 1
        SalvarIncluirNovo = 2
        SalvarApenas = 3
    End Enum

    Private Function Salvar() As Boolean
        Try
            Dim objPedidoItem As New UCLPedidoVendaItem(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedidoItemProgramacao As New UCLPedidoVendaItemProgramacao(StrConexaoUsuario(Session("GlUsuario")))

            Call CalculaQuantidade()

            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objPedidoItem.empresa = Empresa
                    objPedidoItem.estabelecimento = Estabelecimento
                    objPedidoItem.codPedidoVenda = CodPedidoVenda
                    objPedidoItem.seqItem = LblSeqItem.Text
                    objPedidoItem.Buscar()

                    objPedidoItemProgramacao.Empresa = objPedidoItem.empresa
                    objPedidoItemProgramacao.Estabelecimento = objPedidoItem.estabelecimento
                    objPedidoItemProgramacao.CodPedidoVenda = objPedidoItem.codPedidoVenda
                    objPedidoItemProgramacao.SeqItem = objPedidoItem.seqItem
                    objPedidoItemProgramacao.seqProgramacao = 1
                    objPedidoItem.Buscar()

                    Call CarregaObjeto(objPedidoItem, objPedidoItemProgramacao)
                    objPedidoItem.Alterar()
                    objPedidoItemProgramacao.Alterar()
                    Return True
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objPedidoItem.empresa = Empresa
                    objPedidoItem.estabelecimento = Estabelecimento
                    objPedidoItem.codPedidoVenda = CodPedidoVenda
                    objPedidoItem.seqItem = LblSeqItem.Text

                    objPedidoItemProgramacao.Empresa = objPedidoItem.empresa
                    objPedidoItemProgramacao.Estabelecimento = objPedidoItem.estabelecimento
                    objPedidoItemProgramacao.CodPedidoVenda = objPedidoItem.codPedidoVenda
                    objPedidoItemProgramacao.SeqItem = objPedidoItem.seqItem
                    objPedidoItemProgramacao.seqProgramacao = 1

                    Call CarregaObjeto(objPedidoItem, objPedidoItemProgramacao)
                    objPedidoItem.Incluir()
                    objPedidoItemProgramacao.Incluir()
                    Session("SAcaoAtPedido") = "ALTERAR"
                    LblSeqItem.Text = objPedidoItem.seqItem
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            If Salvar() Then
                Response.Redirect(CaminhoVoltar)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Function IsDigitacaoOK() As Boolean
        Try
            LblErro.Text = ""

            'testes aqui

            Return LblErro.Text = ""
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Enum AplicacaoItem As Int16
        Produto = 1
        Servico = 2
    End Enum

    Private Sub CarregaObjeto(ByRef objPedidoVendaItem As UCLPedidoVendaItem, ByRef objPedidoVendaItemProgramacao As UCLPedidoVendaItemProgramacao)
        Try
            Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim objParametrosFaturamento As New UCLParametrosFaturamento
            Dim tipoItem As String
            Dim ObjItem As New UCLItem
            Dim MesmoEstado As Boolean = False
            Dim aplicacao As AplicacaoItem = AplicacaoItem.Produto
            Dim codNaturOper As String = ""
            Dim objParametrosManutencao As New UCLParametrosManutencao
            Dim objClienteFinanceiro As New UCLClienteFinanceiro
            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))

            If String.IsNullOrEmpty(TxtQuantidade.Text) Then
                TxtQuantidade.Text = "0"
            End If
            If String.IsNullOrEmpty(TxtPrecoUnitario0.Text) Then
                TxtPrecoUnitario0.Text = "0,00"
            End If
            If String.IsNullOrEmpty(LblValorMercadoria.Text) Then
                LblValorMercadoria.Text = "0,00"
            End If
            If String.IsNullOrEmpty(LblValorTotal.Text) Then
                LblValorTotal.Text = "0,00"
            End If

            objParametrosFaturamento.Empresa = objPedidoVendaItem.empresa
            objParametrosFaturamento.Estabelecimento = objPedidoVendaItem.estabelecimento
            objParametrosFaturamento.Buscar()

            objPedidoVenda.empresa = objPedidoVendaItem.empresa
            objPedidoVenda.estabelecimento = objPedidoVendaItem.estabelecimento
            objPedidoVenda.codPedidoVenda = objPedidoVendaItem.codPedidoVenda
            objPedidoVenda.Buscar()

            objClienteFinanceiro.Empresa = Empresa
            objClienteFinanceiro.CodEmitente = objPedidoVenda.codEmitente
            objClienteFinanceiro.Buscar()

            MesmoEstado = ClienteDoMesmoEstado(objPedidoVendaItem.empresa, objPedidoVendaItem.estabelecimento, objPedidoVenda.codEmitente, objPedidoVenda.cnpjFaturamento)

            If Not String.IsNullOrWhiteSpace(TxtCodItem.Text) Then
                ObjItem.CodItem = TxtCodItem.Text
                ObjItem.Buscar()
                aplicacao = ObjItem.Aplicacao
            End If

            objPedidoVendaItem.codItem = TxtCodItem.Text
            objPedidoVendaItem.referencia = DdlReferencia.SelectedValue
            objPedidoVendaItem.lote = TxtLote.Text
            objPedidoVendaItem.codUsuario = Session("GlCodUsuario")
            objPedidoVendaItem.qtdUd = TxtQuantidade.Text
            objPedidoVendaItem.qtdPedida = TxtQuantidade.Text
            objPedidoVendaItem.precoUnitario = TxtPrecoUnitario0.Text
            objPedidoVendaItem.precoUnitarioOriginal = TxtPrecoUnitario0.Text
            objPedidoVendaItem.precoUnitarioUd = TxtPrecoUnitario0.Text
            objPedidoVendaItem.precoUnitarioUdOriginal = TxtPrecoUnitario0.Text
            objPedidoVendaItem.valorMercadoria = LblValorMercadoria.Text
            objPedidoVendaItem.aliquotaIcms = LblAliquotaICMS.Text
            objPedidoVendaItem.valorIcms = LblValorICMS.Text
            objPedidoVendaItem.aliquotaIpi = LblAliquotaIPI.Text
            objPedidoVendaItem.valorIpi = LblValorIPI.Text
            objPedidoVendaItem.percDesconto = 0
            objPedidoVendaItem.valorDesconto = 0
            objPedidoVendaItem.valorTotalMercadoria = LblValorTotal.Text
            objPedidoVendaItem.valorCusto = 0
            objPedidoVendaItem.impostosFederais = 0
            objPedidoVendaItem.percComissao = 0
            objPedidoVendaItem.valorComissao = 0
            objPedidoVendaItem.margemLiquida = (objPedidoVendaItem.valorTotalMercadoria - (objPedidoVendaItem.valorIcms))
            objPedidoVendaItem.situacaoFaturamento = 1
            objPedidoVendaItem.situacaoAprovacao = 1
            objPedidoVendaItem.situacaoEntrega = 1

            codNaturOper = DdlNaturOper.SelectedValue

            objPedidoVendaItem.codNaturOper = codNaturOper
            objPedidoVendaItem.narrativa = TxtNarrativa.Text.GetValidInputContent
            objPedidoVendaItem.icmsSubstituicao = LblValorST.Text
            objPedidoVendaItem.numeroSerie = DdlEquipamento.SelectedValue
            objPedidoVendaItem.seqComponente = DdlComponente.SelectedValue

            tipoItem = ObjItem.GetTipoItem(TxtCodItem.Text)

            If tipoItem = "1" Then
                objPedidoVendaItem.HoraInicial = TxtInicial.Text
                objPedidoVendaItem.HoraFinal = TxtFinal.Text
                objPedidoVendaItem.KmInicial = "0"
                objPedidoVendaItem.KmFinal = "0"
                objPedidoVendaItem.CodAgenteTecnico = DdlAgenteTecnico.SelectedValue
            ElseIf tipoItem = "2" Then
                objPedidoVendaItem.KmInicial = TxtInicial.Text.Replace(",", ".")
                objPedidoVendaItem.KmFinal = TxtFinal.Text.Replace(",", ".")
                objPedidoVendaItem.CodAgenteTecnico = DdlAgenteTecnico.SelectedValue
            End If

            objPedidoVendaItem.LocalOrigem = TxtLocalOrigem.Text.GetValidInputContent
            objPedidoVendaItem.LocalDestino = TxtLocalDestino.Text.GetValidInputContent

            objPedidoVendaItemProgramacao.qtdPedida = TxtQuantidade.Text
            objPedidoVendaItemProgramacao.qtdUD = TxtQuantidade.Text
            objPedidoVendaItemProgramacao.dataEntrega = objPedidoVenda.dataEntrega

            If DdlTipoCobranca.Items.Count > 0 Then
                If objParametrosManutencao.IsNull("modelo_chamado_crm") OrElse objParametrosManutencao.GetConteudo("modelo_chamado_crm") <> 1 Then
                    objPedidoVendaItem.codTipoCobrancaOS = DdlTipoCobranca.SelectedValue
                End If
            End If

            If Session("GlTipoFaturamento") = "G" Then
                objPedidoVendaItem.seqSolicitacao = DdlSolicitacao.SelectedValue
            End If

            If objPedidoVendaItem.seqSolicitacao = "0" Then
                objPedidoVendaItem.seqSolicitacao = ""
            End If

            If isValidDate(TxtDataEntrega.Text) Then
                objPedidoVendaItem.DataEntrega = TxtDataEntrega.Text
                objPedidoVendaItem.DDataEntrega = CDate(TxtDataEntrega.Text)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CarregaDescricaoItem()
        Try
            Dim objItem As New UCLItem
            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                objItem.CodItem = TxtCodItem.Text
                objItem.Buscar()
                LblDescricaoItem.Text = objItem.Descricao
            Else
                LblDescricaoItem.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private ReadOnly Property Quantidade() As String
        Get
            If IsNumeric(TxtQuantidade.Text) Then
                Return TxtQuantidade.Text
            Else
                Return 0
            End If
        End Get
    End Property

    Private ReadOnly Property PrecoUnitario() As String
        Get
            If IsNumeric(TxtPrecoUnitario0.Text) Then
                Return TxtPrecoUnitario0.Text
            Else
                Return 0
            End If
        End Get
    End Property

    Private Sub CalculaTotal()
        Try
            Dim objCalculoImposto As New UCLCalculoImposto
            Dim retorno As String
            Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim MesmoEstado As Boolean = False
            Dim aplicacao As AplicacaoItem = AplicacaoItem.Produto
            Dim codNaturOper As String = ""
            Dim objItem As New UCLItem
            Dim objParametrosFaturamento As New UCLParametrosFaturamento
            Dim objClienteFinanceiro As New UCLClienteFinanceiro

            If String.IsNullOrEmpty(TxtQuantidade.Text) Then
                Return
            End If

            If DdlTipoCobranca.Items.Count > 0 Then
                If Not IsExtraContrato(DdlTipoCobranca.SelectedValue) Then
                    TxtPrecoUnitario0.Text = "0,00"
                End If
            End If

            If TxtCodItem.Text = "" Then
                Return
            End If

            objPedidoVenda.empresa = Empresa
            objPedidoVenda.estabelecimento = Estabelecimento
            objPedidoVenda.codPedidoVenda = CodPedidoVenda
            objPedidoVenda.Buscar()

            objParametrosFaturamento.Empresa = objPedidoVenda.empresa
            objParametrosFaturamento.Estabelecimento = objPedidoVenda.estabelecimento
            objParametrosFaturamento.Buscar()

            objClienteFinanceiro.Empresa = Empresa
            objClienteFinanceiro.CodEmitente = objPedidoVenda.codEmitente
            objClienteFinanceiro.Buscar()

            MesmoEstado = ClienteDoMesmoEstado(objPedidoVenda.empresa, objPedidoVenda.estabelecimento, objPedidoVenda.codEmitente, objPedidoVenda.cnpjFaturamento)

            If Not String.IsNullOrWhiteSpace(TxtCodItem.Text) Then
                objItem.CodItem = TxtCodItem.Text
                objItem.Buscar()
                aplicacao = objItem.Aplicacao
            End If

            codNaturOper = DdlNaturOper.SelectedValue

            If CDbl(Quantidade) > 0 And CDbl(PrecoUnitario) > 0 Then
                LblValorMercadoria.Text = CDbl(Quantidade * PrecoUnitario).ToString("F2")
                LblValorTotal.Text = CDbl(Quantidade * PrecoUnitario).ToString("F2")
            End If

            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                objCalculoImposto.Empresa = Empresa
                objCalculoImposto.Estabelecimento = Estabelecimento
                objCalculoImposto.CodItem = TxtCodItem.Text
                objCalculoImposto.Quantidade = Quantidade
                objCalculoImposto.QuantidadeUD = Quantidade
                objCalculoImposto.PrecoUnitario = PrecoUnitario
                objCalculoImposto.PrecoUnitarioUD = PrecoUnitario
                objCalculoImposto.ValorDesconto = 0
                objCalculoImposto.CodEmitente = objPedidoVenda.codEmitente
                objCalculoImposto.CNPJ = objPedidoVenda.cnpjFaturamento
                objCalculoImposto.CodNaturOper = codNaturOper
                retorno = objCalculoImposto.CalculaTotais()
                LblErro.Text = retorno
                LblValorMercadoria.Text = objCalculoImposto.ValorMercadoria.ToString("F2")
                LblValorTotal.Text = objCalculoImposto.ValorTotalMercadoria.ToString("F2")
                If retorno = "" Then
                    LblBaseICMSST.Text = objCalculoImposto.BaseIcmsSubstituicao.ToString("F2")
                    LblValorST.Text = objCalculoImposto.IcmsSubstituicao.ToString("F2")
                    LblValorIPI.Text = objCalculoImposto.ValorIPI.ToString("F2")
                    LblValorICMS.Text = objCalculoImposto.ValorICMS.ToString("F2")
                    LblAliquotaICMS.Text = objCalculoImposto.AliquotaICMS.ToString("F1")
                    LblAliquotaIPI.Text = objCalculoImposto.AliquotaIPI.ToString("F1")
                Else
                    LblErro.Text += " Por esse motivo, os valores abaixo podem não ser calculados corretamente."
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Try
            Dim objPedidoItem As New UCLPedidoVendaItem(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))

            objPedido.empresa = Empresa
            objPedido.estabelecimento = Estabelecimento
            objPedido.codPedidoVenda = CodPedidoVenda
            objPedido.Buscar()

            objPedidoItem.empresa = Empresa
            objPedidoItem.estabelecimento = Estabelecimento
            objPedidoItem.codPedidoVenda = CodPedidoVenda
            LblSeqItem.Text = objPedidoItem.GetProximoCodigo()
            SeqItem = LblSeqItem.Text

            objChamado.Empresa = objPedidoItem.empresa
            objChamado.CodChamado = objPedido.codChamado
            If Not String.IsNullOrEmpty(objChamado.Empresa) And Not String.IsNullOrEmpty(objChamado.CodChamado) Then
                If objChamado.Buscar() Then
                    Session("SCodEmitenteAtNegociacao") = objChamado.CodEmitenteAtendimento
                    Session("SPontoAtendimento") = objChamado.NumeroPontoAtendimento
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtCodItem_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCodItem.TextChanged
        Try
            Call CodItemMudou(True)
            If String.IsNullOrEmpty(TxtQuantidade.Text) OrElse (IsNumeric(TxtQuantidade.Text) AndAlso TxtQuantidade.Text <= 0) Then
                If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                    TxtQuantidade.Text = 1
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub DdlEquipamento_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlEquipamento.SelectedIndexChanged
        Try
            Session("SNumeroSerieItemPedido") = DdlEquipamento.SelectedValue
            Call CarregaComponentes()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub CarregaComponentes()
        Try
            Dim objEquipamentoComponente As New UCLEquipamentoComponente(StrConexaoUsuario(Session("GlUsuario")))
            objEquipamentoComponente.Empresa = Empresa
            objEquipamentoComponente.NumeroSerie = DdlEquipamento.SelectedValue
            objEquipamentoComponente.FillDropDown(DdlComponente, False, "", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CalculaQuantidade()
        Try
            Dim tipoItem As String
            Dim objItem As New UCLItem
            Dim quantidade As Double = 0
            Dim ObjTipoChamado As New UCLTipoChamado
            Dim codTipoChamado As String
            Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim quantidadeMinimaOS As Double = 0
            Dim quantidadeMultiplaOS As Double = 0
            Dim qtdCalc As Double = 0
            Dim qtdAdd As Double = 0

            objPedidoVenda.empresa = Empresa
            objPedidoVenda.estabelecimento = Estabelecimento
            objPedidoVenda.codPedidoVenda = CodPedidoVenda
            objPedidoVenda.Buscar()
            If Not String.IsNullOrEmpty(objPedidoVenda.codChamado) Then
                objChamado.Empresa = objPedidoVenda.empresa
                objChamado.CodChamado = objPedidoVenda.codChamado
                objChamado.Buscar()
                codTipoChamado = objChamado.TipoChamado
                If String.IsNullOrWhiteSpace(codTipoChamado) Then
                    Throw New Exception("Campo Tipo de Chamado não foi informado para o chamado nº " + objPedidoVenda.codChamado + ". Informe o tipo de chamado antes de registrar as horas trabalhadas.")
                End If
                ObjTipoChamado.Buscar(Empresa, codTipoChamado)
                If Not ObjTipoChamado.IsNull("quantidade_minima_os") Then
                    quantidadeMinimaOS = ObjTipoChamado.GetConteudo("quantidade_minima_os")
                End If
                If Not ObjTipoChamado.IsNull("quantidade_multipla_os") Then
                    quantidadeMultiplaOS = ObjTipoChamado.GetConteudo("quantidade_multipla_os")
                End If
            End If

            If Not String.IsNullOrWhiteSpace(TxtCodItem.Text) Then
                tipoItem = objItem.GetTipoItem(TxtCodItem.Text)

                Select Case tipoItem
                    Case "1" 'Hora
                        TxtInicial.Text = TxtInicial.Text.Replace("::", ":")
                        TxtFinal.Text = TxtFinal.Text.Replace("::", ":")
                        If Not String.IsNullOrWhiteSpace(TxtFinal.Text) AndAlso TxtFinal.Text.Contains(":") AndAlso Not String.IsNullOrWhiteSpace(TxtInicial.Text) AndAlso TxtInicial.Text.Contains(":") Then
                            quantidade = Math.Abs(DateDiff(DateInterval.Second, CType(TxtFinal.Text, DateTime), CType(TxtInicial.Text, DateTime))) / 3600.0
                        End If
                    Case "2"  'KM
                        If Not String.IsNullOrWhiteSpace(TxtFinal.Text) AndAlso IsNumeric(TxtFinal.Text) AndAlso Not String.IsNullOrWhiteSpace(TxtInicial.Text) AndAlso IsNumeric(TxtInicial.Text) Then
                            quantidade = Math.Abs(CDbl(TxtFinal.Text) - CDbl(TxtInicial.Text))
                        End If
                End Select
            End If

            If quantidade <> Nothing AndAlso quantidade > 0 Then

                If quantidadeMinimaOS > 0 AndAlso quantidade < quantidadeMinimaOS Then
                    If Not String.IsNullOrWhiteSpace(TxtCodItem.Text) Then
                        tipoItem = objItem.GetTipoItem(TxtCodItem.Text)

                        Select Case tipoItem
                            Case "1" 'Hora
                                TxtInicial.Text = TxtInicial.Text.Replace("::", ":")
                                TxtFinal.Text = TxtFinal.Text.Replace("::", ":")
                                quantidade = quantidadeMinimaOS
                                TxtFinal.Text = CDate(TxtInicial.Text).AddSeconds(quantidadeMinimaOS * 3600).ToString("HH:mm")
                        End Select
                    End If
                End If

                If quantidadeMultiplaOS > 0 AndAlso (quantidade / quantidadeMultiplaOS) <> CLng(Math.Floor(quantidade / quantidadeMultiplaOS)) Then
                    If Not String.IsNullOrWhiteSpace(TxtCodItem.Text) Then
                        tipoItem = objItem.GetTipoItem(TxtCodItem.Text)

                        Select Case tipoItem
                            Case "1" 'Hora
                                qtdCalc = 0
                                While qtdCalc < quantidade
                                    qtdCalc += quantidadeMultiplaOS
                                End While
                                qtdAdd = qtdCalc - quantidade
                                quantidade = qtdCalc
                                TxtFinal.Text = CDate(TxtFinal.Text).AddSeconds(qtdAdd * 3600).ToString("HH:mm")
                        End Select
                    End If
                End If

                TxtQuantidade.Text = quantidade.ToString("F4")
            End If

            Call CalculaTotal()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtInicial_TextChanged(sender As Object, e As EventArgs) Handles TxtInicial.TextChanged
        Try
            Call CalculaQuantidade()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub TxtFinal_TextChanged(sender As Object, e As EventArgs) Handles TxtFinal.TextChanged
        Try
            Call CalculaQuantidade()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub DdlTipoCobranca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlTipoCobranca.SelectedIndexChanged
        Try
            Call CodItemMudou(False)
            Call CalculaTotal()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Function IsExtraContrato(codTipoCobranca As String) As Boolean
        Try
            Dim ObjTipoCobrancaOS As New UCLTipoCobrancaOS
            Dim faturado As Boolean = True
            If ObjTipoCobrancaOS.VerificaFaturamento(DdlTipoCobranca.SelectedValue) = "E" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function IsFaturado(codTipoCobranca As String) As Boolean
        Try
            Dim ObjTipoCobrancaOS As New UCLTipoCobrancaOS
            Dim faturado As Boolean = True
            If ObjTipoCobrancaOS.VerificaFaturamento(DdlTipoCobranca.SelectedValue) = "N" Then
                faturado = False
            End If

            Return faturado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect(CaminhoVoltar)
    End Sub

    Private Sub CarregaDDlItemContrato(ByVal CodItem As String)
        Try
            Dim objContratoManutencaoItem As New UCLContratoManutencaoItem
            Dim objPedidoVenda As New UCLPedidoVenda(StrConexao)
            Dim objChamado As New UCLAtendimento(StrConexao)
            Dim codContrato As String = ""
            objPedidoVenda.empresa = Empresa
            objPedidoVenda.estabelecimento = Estabelecimento
            objPedidoVenda.codPedidoVenda = CodPedidoVenda
            objPedidoVenda.Buscar()

            If Not String.IsNullOrEmpty(objPedidoVenda.codChamado) Then
                objChamado.Empresa = objPedidoVenda.empresa
                objChamado.CodChamado = objPedidoVenda.codChamado
                objChamado.Buscar()
                codContrato = objChamado.Contrato
            End If

            objContratoManutencaoItem.FillDropDown(DdlItemContrato, False, "", Session("GlEmpresa"), codContrato, CodItem)
            If CodItem <> "" Then
                DdlItemContrato.SelectedValue = CodItem
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlItemContrato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlItemContrato.SelectedIndexChanged
        Try
            TxtCodItem.Text = DdlItemContrato.SelectedValue
            Call CodItemMudou(True)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub RblSelecionarItemContrato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RblSelecionarItemContrato.SelectedIndexChanged
        Try
            If RblSelecionarItemContrato.SelectedValue = "N" Then
                TxtCodItem.Text = ""
                Call CodItemMudou(True)
            Else
                TxtCodItem.Text = DdlItemContrato.SelectedValue
                Call CodItemMudou(True)
            End If
            Call AlteraVisibilidadeItem(RblSelecionarItemContrato.SelectedValue)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub AlteraVisibilidadeItem(ByVal selecionarItemContrato As String)
        Try
            If selecionarItemContrato = "S" Then
                DdlItemContrato.Visible = True
                TxtCodItem.Visible = False
                LblDescricaoItem.Visible = False
                BtnFiltrarItem.Visible = False
            Else
                DdlItemContrato.Visible = False
                TxtCodItem.Visible = True
                LblDescricaoItem.Visible = True
                BtnFiltrarItem.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtPrecoUnitario0_TextChanged(sender As Object, e As EventArgs) Handles TxtPrecoUnitario0.TextChanged
        Call CalculaTotal()
    End Sub


    Protected Sub BtnGravar0_Click(sender As Object, e As EventArgs) Handles BtnGravar0.Click
        Try
            If Salvar() Then
                LblErro.Text = "<span style=""color:green"">Dados salvos com sucesso.</span>"
                Call IncluirNovo()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub IncluirNovo()
        Try
            Session("SAtSeqItemPedido") = -1
            Session("SAcaoAtPedido") = "INCLUIR"
            Me.Empresa = Session("GlEmpresa")
            Me.Estabelecimento = Session("GlEstabelecimento")
            Me.CodPedidoVenda = Session("SAtCodPedido")
            Me.SeqItem = Session("SAtSeqItemPedido")
            Me.Acao = Session("SAcaoAtPedido")
            Call Me.Carregar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetEquipamentoSeUnico()
        Dim numeroSerie As String = ""
        Try
            Dim strsql As String = "select numero_serie from pedido_venda_solicitacao where empresa = " + Empresa + " and estabelecimento = " + Estabelecimento + " and cod_pedido_venda = " + CodPedidoVenda + " and trim(isnull(numero_serie,'')) <> '' "
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)
            Dim dt As DataTable = objAcessoDados.BuscarDados(strsql)
            If dt.Rows.Count = 1 Then
                numeroSerie = dt.Rows.Item(0).Item("numero_serie").ToString
                CarregaEquipamentoCliente(dt.Rows.Item(0).Item("numero_serie").ToString)
                DdlEquipamento.SelectedValue = dt.Rows.Item(0).Item("numero_serie").ToString
                Session("SNumeroSerieItemPedido") = dt.Rows.Item(0).Item("numero_serie").ToString
                Call CarregaComponentes()
            Else
                CarregaEquipamentoCliente("0")
            End If
        Catch ex As Exception
            Throw New Exception("[" + numeroSerie + "] " + ex.ToString)
        End Try
    End Sub

End Class