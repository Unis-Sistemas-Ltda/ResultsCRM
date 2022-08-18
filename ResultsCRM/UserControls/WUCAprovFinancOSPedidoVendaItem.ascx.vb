Public Partial Class WUCAprovFinancOSPedidoVendaItem
    Inherits System.Web.UI.UserControl

    Private _empresa As String
    Private _estabelecimento As String
    Private _codPedidoVenda As String
    Private _seqItem As String
    Private _acao As String
    Private _camVoltar As String

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
            Return _Acao
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
            Session("SModoCadEquipamento") = WUCEquipamento.ModoJanela.AberturaPorOutraTela

            If Not IsPostBack Then
                Call Carregar()
            End If

            If Not String.IsNullOrEmpty(Session("SCodItemPesquisado")) Then
                If Session("SAlterouCodItem") = "S" Then
                    If TxtCodItem.Text <> Session("SCodItemPesquisado") Then
                        TxtCodItem.Text = Session("SCodItemPesquisado")
                        CodItemMudou()
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

    Public Sub Carregar()
        Try
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
                Call CarregaTipoCobrancaOS()
            Else
                Call CarregaEquipamentoCliente("0")
                Call CarregaNovaPK()
                TxtQuantidade.Text = 0
                Call CarregaTipoCobrancaOS()
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

            LblSeqItem.Text = SeqItem
            TxtCodItem.Text = objPedidoItem.codItem
            TxtNarrativa.Text = objPedidoItem.narrativa
            TxtQuantidade.Text = CDbl(objPedidoItem.qtdPedida).ToString
            TxtPrecoUnitario.Text = CDbl(objPedidoItem.precoUnitario).ToString("F2")
            LblValorMercadoria.Text = CDbl(objPedidoItem.valorMercadoria).ToString("F2")
            LblValorICMS.Text = CDbl(objPedidoItem.valorIcms).ToString("F2")
            LblAliquotaICMS.Text = CDbl(objPedidoItem.aliquotaIcms).ToString("F1")
            LblValorIPI.Text = CDbl(objPedidoItem.valorIpi).ToString("F2")
            LblAliquotaIPI.Text = CDbl(objPedidoItem.aliquotaIpi).ToString("F1")
            LblValorST.Text = CDbl(objPedidoItem.icmsSubstituicao).ToString("F2")
            LblBaseICMSST.Text = CDbl(objPedidoItem.baseIcmsSubstituicao).ToString("F2")
            LblValorTotal.Text = CDbl(objPedidoItem.valorTotalMercadoria).ToString("F2")
            DdlTipoCobrancaOS.SelectedValue = objPedidoItem.codTipoCobrancaOS
            Call CarregaEquipamentoCliente(objPedidoItem.numeroSerie)
            If Not String.IsNullOrEmpty(objPedidoItem.numeroSerie) Then
                DdlEquipamento.SelectedValue = objPedidoItem.numeroSerie
                Call CarregaComponentes()
                If Not String.IsNullOrEmpty(objPedidoItem.seqComponente) Then
                    If DdlComponente.Items.FindByValue(objPedidoItem.seqComponente) IsNot Nothing Then
                        DdlComponente.SelectedValue = objPedidoItem.seqComponente
                    End If
                End If
            End If

            Call CarregaDescricaoItem()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CodItemMudou()
        Dim objItem As New UCLItem
        Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

        Try
            Call CarregaDescricaoItem()

            objPedidoVenda.empresa = Empresa
            objPedidoVenda.estabelecimento = Estabelecimento
            objPedidoVenda.codPedidoVenda = CodPedidoVenda
            objPedidoVenda.Buscar()

            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                TxtPrecoUnitario.Text = objItem.PrecoItemCliente(Empresa, Estabelecimento, objPedidoVenda.codEmitente, objPedidoVenda.cnpjFaturamento, TxtCodItem.Text, "", "").ToString("F2")
                TxtNarrativa.Text = objItem.GetNarrativa(TxtCodItem.Text)
                Session("SCodItemPesquisado") = TxtCodItem.Text
            End If
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
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedidoItemProgramacao As New UCLPedidoVendaItemProgramacao(StrConexaoUsuario(Session("GlUsuario")))
            Dim statusAnterior As String

            If IsDigitacaoOK() Then

                objPedido.empresa = Empresa
                objPedido.estabelecimento = Estabelecimento
                objPedido.codPedidoVenda = CodPedidoVenda
                objPedido.Buscar()

                statusAnterior = objPedido.statusDigitacao
                If statusAnterior = "2" Then
                    objPedido.statusDigitacao = "1"
                    objPedido.Alterar()
                End If

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
                    objPedidoItem.AlterarAprovFinancOS()
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

                If statusAnterior = "2" Then
                    objPedido.IgnoraValidacoes = True
                    objPedido.statusDigitacao = "2"
                    objPedido.Alterar()
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

    Private Sub CarregaObjeto(ByRef objPedidoVendaItem As UCLPedidoVendaItem, ByRef objPedidoVendaItemProgramacao As UCLPedidoVendaItemProgramacao)
        Try
            Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

            If String.IsNullOrEmpty(TxtQuantidade.Text) Then
                TxtQuantidade.Text = "0"
            End If
            If String.IsNullOrEmpty(TxtPrecoUnitario.Text) Then
                TxtPrecoUnitario.Text = "0,00"
            End If
            If String.IsNullOrEmpty(LblValorMercadoria.Text) Then
                LblValorMercadoria.Text = "0,00"
            End If
            If String.IsNullOrEmpty(LblValorTotal.Text) Then
                LblValorTotal.Text = "0,00"
            End If

            objPedidoVenda.empresa = objPedidoVendaItem.empresa
            objPedidoVenda.estabelecimento = objPedidoVendaItem.estabelecimento
            objPedidoVenda.codPedidoVenda = objPedidoVendaItem.codPedidoVenda
            objPedidoVenda.Buscar()

            objPedidoVendaItem.codItem = TxtCodItem.Text
            objPedidoVendaItem.codUsuario = Session("GlCodUsuario")
            objPedidoVendaItem.qtdUd = TxtQuantidade.Text
            objPedidoVendaItem.qtdPedida = TxtQuantidade.Text
            objPedidoVendaItem.precoUnitario = TxtPrecoUnitario.Text
            objPedidoVendaItem.precoUnitarioOriginal = TxtPrecoUnitario.Text
            objPedidoVendaItem.precoUnitarioUd = TxtPrecoUnitario.Text
            objPedidoVendaItem.precoUnitarioUdOriginal = TxtPrecoUnitario.Text
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
            objPedidoVendaItem.codNaturOper = objPedidoVenda.codNaturOper
            objPedidoVendaItem.narrativa = TxtNarrativa.Text.GetValidInputContent
            objPedidoVendaItem.icmsSubstituicao = LblValorST.Text
            objPedidoVendaItem.numeroSerie = DdlEquipamento.SelectedValue
            objPedidoVendaItem.seqComponente = DdlComponente.SelectedValue
            objPedidoVendaItem.codTipoCobrancaOS = DdlTipoCobrancaOS.SelectedValue

            objPedidoVendaItemProgramacao.qtdPedida = TxtQuantidade.Text
            objPedidoVendaItemProgramacao.dataEntrega = objPedidoVenda.dataEntrega
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
            If IsNumeric(TxtPrecoUnitario.Text) Then
                Return TxtPrecoUnitario.Text
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

            If String.IsNullOrEmpty(TxtQuantidade.Text) Then
                Return
            End If

            objPedidoVenda.empresa = Empresa
            objPedidoVenda.estabelecimento = Estabelecimento
            objPedidoVenda.codPedidoVenda = CodPedidoVenda
            objPedidoVenda.Buscar()

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
                objCalculoImposto.CodNaturOper = objPedidoVenda.codNaturOper
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
        If String.IsNullOrEmpty(TxtQuantidade.Text) OrElse (IsNumeric(TxtQuantidade.Text) AndAlso TxtQuantidade.Text <= 0) Then
            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                TxtQuantidade.Text = 1
            End If
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

    Protected Sub DdlTipoCobrancaOS_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlTipoCobrancaOS.SelectedIndexChanged
        Dim objTipoCobrancaOS As New UCLTipoCobrancaOS
        Dim faturado As String
        Dim CodTipoCobrancaOs As Integer

        CodTipoCobrancaOs = DdlTipoCobrancaOS.SelectedValue

        faturado = objTipoCobrancaOS.VerificaFaturamento(CodTipoCobrancaOs)

        If faturado = "N" Then
            TxtPrecoUnitario.Text = "0"
        End If

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

    Private Sub CarregaEquipamentoCliente(ByVal numeroSerieSelecionado As String)
        Try
            Dim objEquipamentoCliente As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))

            objPedidoVenda.empresa = Empresa
            objPedidoVenda.estabelecimento = Estabelecimento
            objPedidoVenda.codPedidoVenda = CodPedidoVenda
            objPedidoVenda.Buscar()
            If Not String.IsNullOrEmpty(objPedidoVenda.codChamado) Then
                objChamado.Empresa = objPedidoVenda.empresa
                objChamado.CodChamado = objPedidoVenda.codChamado
                objChamado.Buscar()
                If Not String.IsNullOrEmpty(objChamado.CodEmitenteAtendimento) And Not String.IsNullOrEmpty(objChamado.NumeroPontoAtendimento) Then
                    objEquipamentoCliente.CodCliente = objChamado.CodEmitenteAtendimento
                    objEquipamentoCliente.Empresa = objChamado.Empresa
                    objEquipamentoCliente.NumeroPontoAtendimento = objChamado.NumeroPontoAtendimento
                    objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.Observacao, numeroSerieSelecionado)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class