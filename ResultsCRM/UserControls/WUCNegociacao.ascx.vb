﻿Imports iTextSharp.text.pdf

Partial Public Class WUCNegociacao
    Inherits System.Web.UI.UserControl

    Private _CodNegociacao As String
    Private _Acao As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodNegociacao() As String
        Get
            Return _CodNegociacao
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property

    Private _EstabelecimentoNegociacao As Integer
    Public Property EstabelecimentoNegociacao() As Integer
        Get
            Return _EstabelecimentoNegociacao
        End Get
        Set(ByVal value As Integer)
            _EstabelecimentoNegociacao = value
        End Set
    End Property



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim CodClientePesquisado As String
            Dim CNPJClientePesquisado As String
            Dim CodContatoRetornado As String
            Dim recarregaContatos As Long
            Dim alterouCodCliente As Long
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            Dim objParametrosFaturamento As New UCLParametrosFaturamento
            Dim segmento As String

            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")

            If objNegociacao.Estabelecimento Is Nothing Then
                objNegociacao.Estabelecimento = Session("GlEstabelecimento")
            End If

            objParametrosFaturamento.Empresa = Session("GlEmpresa")
            objParametrosFaturamento.Estabelecimento = Session("SEstabelecimentoNegociacao")
            If objParametrosFaturamento.Estabelecimento Is Nothing Then
                objParametrosFaturamento.Estabelecimento = Session("GlEstabelecimento")
            End If
            objParametrosFaturamento.Buscar()
            segmento = objParametrosFaturamento.Segmento
            LblTipoCobranca.Visible = True
            DdlTipoCobranca.Visible = True
            If segmento = "O" Then
                ChkGerarPedido.Text = "Aprovar"
                LabelObra01.Visible = False
                LabelObra02.Visible = False
                LabelObra03.Visible = False
                LabelObra04.Visible = False
                LabelObra05.Visible = False
                DdlTipoObra.Visible = False
                DdlModalidadeObra.Visible = False
                DdlEstagioObra.Visible = False
                TxtTamanhoObra.Visible = False
            ElseIf segmento = "T" Then
                LabelObra01.Visible = True
                LabelObra02.Visible = True
                LabelObra03.Visible = True
                LabelObra04.Visible = True
                LabelObra05.Visible = True
                DdlTipoObra.Visible = True
                DdlModalidadeObra.Visible = True
                DdlEstagioObra.Visible = True
                TxtTamanhoObra.Visible = True
            Else
                LabelObra01.Visible = False
                LabelObra02.Visible = False
                LabelObra03.Visible = False
                LabelObra04.Visible = False
                LabelObra05.Visible = False
                DdlTipoObra.Visible = False
                DdlModalidadeObra.Visible = False
                DdlEstagioObra.Visible = False
                TxtTamanhoObra.Visible = False
            End If

            If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
                ChkGerarPedido.Enabled = False
            End If

            If Not String.IsNullOrEmpty(Session("SRecarregaDdlContatos")) Then
                recarregaContatos = Session("SRecarregaDdlContatos")
            Else
                recarregaContatos = 0
            End If

            If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
                alterouCodCliente = Session("SAlterouCodCliente")
            Else
                alterouCodCliente = 0
            End If

            CodClientePesquisado = Session("SCodClientePesquisado")


            If Not String.IsNullOrEmpty(CodClientePesquisado) Then
                If alterouCodCliente > 0 Then
                    If TxtCliente.Text <> CodClientePesquisado Then
                        TxtCliente.Text = CodClientePesquisado
                        Call CodigoClienteMudou()
                    End If
                    Session("SAlterouCodCliente") = alterouCodCliente - 1
                End If
            End If

            CNPJClientePesquisado = Session("SCNPJClientePesquisado")

            If Not String.IsNullOrEmpty(CNPJClientePesquisado) Then
                If alterouCodCliente > 0 Then
                    If DdlCNPJ.Text <> CNPJClientePesquisado Then
                        DdlCNPJ.Text = CNPJClientePesquisado
                    End If

                End If
            End If

            If Not IsPostBack Then
                If Acao = "ALTERAR" Then
                    BtnAlterarCliente.Enabled = True
                    Call CarregaFormulario()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaEquipamentoCliente("0")
                    LblCodChamado.Text = ""
                    Session("SCodEmitenteNegociacao") = -1
                    Session("SCodEmitenteNegociacaoAnterior") = -1
                    BtnAlterarCliente.Enabled = False
                    Call CarregaNovaPK()
                    Call CarregaDropDowns("0", "0")
                    Call CarregaVendedores(0, False)
                    Call CarregaAgentesVenda(Session("GlCodUsuario"))
                    LblDataCadastramento.Text = Now().ToString("dd/MM/yyyy")
                    DdlMoeda.SelectedValue = 1
                    DdlFrete.SelectedValue = 2
                    If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
                        DdlRepresentante.Enabled = False
                        DdlRepresentante.SelectedValue = Session("GlCodEmitenteExterno")
                    End If

                    If Session("SCodAtendimento") IsNot Nothing AndAlso Session("SCodAtendimento").ToString() <> "" Then
                        Dim objChamado As New UCLAtendimento(StrConexao)
                        objChamado.Empresa = Session("GlEmpresa")
                        objChamado.CodChamado = Session("SCodAtendimento")
                        If objChamado.Buscar() Then
                            TxtCliente.Text = objChamado.CodEmitente
                            Call CodigoClienteMudou()
                            DdlCNPJ.SelectedValue = objChamado.Cnpj
                            DdlContato.SelectedValue = objChamado.CodContato
                            LblCodChamado.Text = objChamado.CodChamado
                        End If
                    End If
                End If
            Else
                If recarregaContatos > 0 Then
                    CodContatoRetornado = Session("SCodContatoNegociacao")
                    Call CarregaContatos()
                    If Not String.IsNullOrEmpty(CodContatoRetornado) Then
                        DdlContato.SelectedValue = CodContatoRetornado
                        Call ContatoSelecionadoMudou()
                    End If
                    Session("SRecarregaDdlContatos") = recarregaContatos - 1
                End If
                Call ChecaPesquisaClienteAtendimento()
                Call ChecaPesquisaPontoAtendimento()
                Call ChecaEdicaoContatoAtendimento()

            End If

            Call MostraNomeCliente()
            Call MostraNomeClienteAtendimento()
            Call MostraNrPedido(False)
            Call CarregaInfoContato()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaEquipamentoCliente(ByVal numeroSerieSelecionado As String)
        Try
            Dim objEquipamentoCliente As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))

            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
            objNegociacao.CodNegociacao = CodNegociacao
            objNegociacao.Buscar()

            If Not String.IsNullOrEmpty(objNegociacao.CodChamado) Then
                objChamado.Empresa = objNegociacao.Empresa
                objChamado.CodChamado = objNegociacao.CodChamado
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

                If Session("GlTipoFaturamento").ToString = "G" Then
                    objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.DescricaoItem, numeroSerieSelecionado)
                Else
                    objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.Observacao, numeroSerieSelecionado)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub MostraNrPedido(ByVal pSetaEtapa As Boolean)
        Try
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
            objNegociacao.CodNegociacao = LblNrNegociacao.Text
            objNegociacao.Buscar()
            LblNrPedido.Text = objNegociacao.GetNrPedido()
            LblNrPedido.DataBind()
            If LblNrPedido.Text <> "" Then
                LblNrPedidoLbl.Visible = True
                LblNrPedidoLbl.DataBind()
                If pSetaEtapa Then
                    DdlEtapa.SelectedValue = objNegociacao.CodEtapaNegociacao
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objNegociacao.Empresa = Session("GlEmpresa")
                    objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
                    objNegociacao.CodNegociacao = LblNrNegociacao.Text
                    objNegociacao.Buscar()
                    objNegociacao = CarregaObjeto(objNegociacao)
                    objNegociacao.Alterar()
                    LblErro.Text = "<span style=""color:DarkGreen"">Os dados foram salvos com sucesso.</span>"
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objNegociacao.Empresa = Session("GlEmpresa")
                    'objNegociacao.Estabelecimento = Session("GlEstabelecimento")
                    objNegociacao.CodNegociacao = LblNrNegociacao.Text
                    objNegociacao.Buscar()
                    objNegociacao = CarregaObjeto(objNegociacao)
                    objNegociacao.Incluir()
                    LblErro.Text = "<span style=""color:DarkGreen"">Negociação incluída com sucesso.</span>"
                    Session("SAcaoNegociacao") = "ALTERAR"
                    Session("SCodNegociacao") = LblNrNegociacao.Text
                    Session("SEstabelecimentoNegociacao") = DdlEstabelecimento.SelectedValue

                Else
                    LblErro.Text = "Ação não definida."
                End If
                Call MostraNrPedido(True)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub CarregaDropDowns(ByVal pCodFunil As String, ByVal pCodEtapa As String)
        Try
            Call CarregaFunil()
            Call CarregaCNPJ()
            Call CarregaContatos()
            Call CarregaCarteiras()
            Call CarregaGestores()
            Call CarregaEtapa(pCodFunil, pCodEtapa)
            Call CarregaFormaPagto()
            Call CarregaCondPagto()
            Call CarregaFonte()
            Call CarregaStatus()
            Call CarregaCanalVenda()
            Call CarregaNatureza()
            Call CarregaMoeda()
            Call CarregaModelos()
            Call CarregaTipoCobrancaOS()
            Call CarregaMotivoFechamentoNegociacao()
            Call CarregaEstabelecimento()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaContatos()
        Try
            Dim objContato As New UCLContato
            Dim CodCliente As String = TxtCliente.Text
            Dim CNPJ = DdlCNPJ.SelectedValue
            If CodCliente IsNot Nothing AndAlso Not String.IsNullOrEmpty(CodCliente) AndAlso CNPJ IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(CNPJ) Then
                objContato.CodEmitente = CodCliente
                objContato.CNPJ = CNPJ
                objContato.FillDropDown(DdlContato, True, "", 0)
                DdlContato.DataBind()
            Else
                DdlContato.Items.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaMoeda()
        Try
            Dim objMoeda As New UCLMoeda
            objMoeda.FillDropDown(DdlMoeda, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaCanalVenda()
        Try
            Dim objCanalVenda As New UCLCanalVenda
            objCanalVenda.Empresa = Session("GlEmpresa")
            objCanalVenda.FillControl(DdlCanalVenda, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNatureza()
        Try
            Dim objNatureza As New UCLNaturezaOperacao
            objNatureza.FillDropDown(DdlNatureza, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaCarteiras()
        Try
            Dim objCarteira As New UCLCarteiraCRM
            objCarteira.FillControl(DdlCarteira, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaModelos()
        Try
            Dim objModelo As New UCLModeloNegociacao
            objModelo.Empresa = Session("GlEmpresa")
            objModelo.FillDropDown(DdlModelo, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaGestores()
        Try
            Dim objGestor As New UCLGestorConta
            objGestor.FillDropDown(DdlGestor, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaVendedores(ByVal codRepresentante As String, ByVal MostraInativos As Boolean)
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            objEmitente.CodEmitente = TxtCliente.Text
            objEmitente.FillDropDown(DdlRepresentante, True, "", UCLEmitente.TipoEmitenteDDL.Representante, codRepresentante, MostraInativos, UCLEmitente.TipoExibicaoDDL.Nome, Session("GlCodGestor"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaAgentesVenda(ByVal codAgenteVenda As String)
        Try
            Dim objAgente As New UCLAgenteVendas
            Dim objFunil As New UCLFunilVenda
            If Session("GlAgenteVendaMaster") = "S" OrElse Session("GlRestricaoAcessoAgenteVenda") = 0 Then
                objAgente.FillDropDown(DdlAgente, True, "(Todos)", 0, UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
            Else
                objAgente.FillDropDown(DdlAgente, True, "(Todos)", Session("GlCodUsuario"), UCLAgenteVendas.TipoRestricaoAcesso.SomenteOProprioAgenteDeVendasNoCRMeNoResults)
            End If
            'If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Vendas Or Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Total Then
            DdlAgente.SelectedValue = Session("GlCodUsuario")
            objAgente.Codigo = Session("GlCodUsuario")
            objAgente.Buscar()

            If Acao = "INCLUIR" Then
                DdlFunil.SelectedValue = objAgente.CodFunil
                objFunil.Empresa = Session("GlEmpresa")
                objFunil.Codigo = objAgente.CodFunil
                DdlEtapa.SelectedValue = objFunil.BuscaEtapaInicial()
            End If

            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaStatus()
        Try
            Dim objStatus As New UCLStatusNegociacao
            objStatus.FillDropDown(DdlStatus, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaEtapa(ByVal pCodFunil As String, ByVal pCodEtapa As String)
        Try
            Dim objEtapaNegociacao As New UCLEtapaNegociacao
            objEtapaNegociacao.Empresa = Session("GlEmpresa")
            objEtapaNegociacao.FillDropDown(DdlEtapa, True, "", pCodFunil, pCodEtapa)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFunil()
        Try
            Dim objFunil As New UCLFunilVenda
            objFunil.FillDropDown(DdlFunil, True, "", Session("GlEmpresa"), Session("GlCodUsuario"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaEstabelecimento()
        Try
            Dim objEstabelecimento As New UCLEstabelecimento()
            objEstabelecimento.CodEmpresa = Session("GlEmpresa")
            objEstabelecimento.FillDropDown(DdlEstabelecimento, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaCondPagto()
        Try
            Dim objCondPagto As New UCLCondicaoPagamento
            objCondPagto.FillDropDown(DdlCondicaoPagto, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormaPagto()
        Try
            Dim objFormaPagto As New UCLFormaPagto
            objFormaPagto.FillDropDown(DdlFormaPagto, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFonte()
        Try
            Dim objFonte As New UCLFonteOrigem
            objFonte.FillDropDown(DdlFonteOrigem, True, "")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CarregaCNPJ()
        Try
            Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
            If Not String.IsNullOrEmpty(TxtCliente.Text) Then
                objEnderecoEmitente.CodEmitente = TxtCliente.Text
                objEnderecoEmitente.FillDropDownCNPJ(DdlCNPJ)
            Else
                DdlCNPJ.Items.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaInfoContato()
        Try
            Dim objContato As New UCLContato
            Dim CodCliente As String = TxtCliente.Text
            Dim CodContato As String = DdlContato.SelectedValue
            If CodCliente IsNot Nothing AndAlso CodContato IsNot Nothing AndAlso Not String.IsNullOrEmpty(CodCliente) AndAlso Not String.IsNullOrWhiteSpace(CodContato) Then
                objContato.CodEmitente = CodCliente
                objContato.Codigo = CodContato
                If objContato.Buscar() Then
                    If Not String.IsNullOrWhiteSpace(objContato.Telefone) Then
                        LblTelefone.Text = objContato.Telefone
                    Else
                        LblTelefone.Text = ""
                    End If
                    If Not String.IsNullOrWhiteSpace(objContato.Celular) Then
                        LblCelular.Text = objContato.Celular
                    Else
                        LblCelular.Text = ""
                    End If
                    LblEmail.Text = objContato.Email
                Else
                    LblTelefone.Text = ""
                    LblEmail.Text = ""
                End If
            Else
                LblTelefone.Text = ""
                LblEmail.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub ContatoSelecionadoMudou()
        Session("SCodContatoNegociacao") = DdlContato.SelectedValue
        Call CarregaInfoContato()
    End Sub

    Protected Sub DdlContato_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlContato.SelectedIndexChanged
        Try
            Call ContatoSelecionadoMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub ContatoAtendimentoSelecionadoMudou()
        Session("SCodContatoAtendimentoNegociacao") = DdlContatoAtendimento.SelectedValue
        Call CarregaInfoContatoAtendimento()
    End Sub

    Protected Sub DdlContatoAtendimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlContatoAtendimento.SelectedIndexChanged
        Try
            Call ContatoAtendimentoSelecionadoMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub CodigoClienteMudou()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

            Call CarregaCNPJ()
            Call CarregaContatos()

            If Not String.IsNullOrWhiteSpace(TxtCliente.Text) Then
                objEmitente.CodEmitente = TxtCliente.Text
                objEmitente.Buscar()
                LblNomeCliente.Text = objEmitente.Nome
            Else
                LblNomeCliente.Text = ""
            End If

            If DdlContato.Items.Count > 0 Then
                DdlContato.SelectedValue = 0
                Call ContatoSelecionadoMudou()
                LblEmail.Text = ""
                LblTelefone.Text = ""
            End If

            Session("SCodEmitenteNegociacao") = TxtCliente.Text
            Session("SCodClientePesquisado") = TxtCliente.Text

            Call CarregaDadosClienteFinanceiro(TxtCliente.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaDadosClienteFinanceiro(ByVal pCodEmitente As String)
        Try
            Dim objClienteFinanceiro As New UCLClienteFinanceiro

            If String.IsNullOrWhiteSpace(pCodEmitente) Then
                Return
            End If

            If Not IsNumeric(pCodEmitente) Then
                Return
            End If

            objClienteFinanceiro.CodEmitente = pCodEmitente
            objClienteFinanceiro.Empresa = Session("GlEmpresa")

            If Not objClienteFinanceiro.Buscar() Then
                Return
            End If

            If DdlRepresentante.Items.FindByValue(objClienteFinanceiro.CodRepresentante) IsNot Nothing Then
                DdlRepresentante.SelectedValue = objClienteFinanceiro.CodRepresentante
            End If

            If DdlCondicaoPagto.Items.FindByValue(objClienteFinanceiro.CodCondPagto) IsNot Nothing Then
                DdlCondicaoPagto.SelectedValue = objClienteFinanceiro.CodCondPagto
            End If

            If DdlFormaPagto.Items.FindByValue(objClienteFinanceiro.CodFormaPagto) IsNot Nothing Then
                DdlFormaPagto.SelectedValue = objClienteFinanceiro.CodFormaPagto
            End If

            If DdlNatureza.Items.FindByValue(objClienteFinanceiro.CodNaturOper) IsNot Nothing Then
                DdlNatureza.SelectedValue = objClienteFinanceiro.CodNaturOper
            End If

            If DdlCanalVenda.Items.FindByValue(objClienteFinanceiro.CodCanalVenda) IsNot Nothing Then
                DdlCanalVenda.SelectedValue = objClienteFinanceiro.CodCanalVenda
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtCliente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCliente.TextChanged
        Try
            Call CodigoClienteMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        Try
            Dim permiteDataPrevisaoEmBranco = False
            Dim exigeDataRecontato = False
            Dim objEtapa As New UCLEtapaNegociacao
            Dim objParametros As New UCLParametrosVenda
            Dim objNegociacao As New UCLNegociacao(StrConexao)

            Dim exigeMotivoFechamentoNegociacao As Boolean = False


            If objParametros.Buscar(Session("GlEmpresa")) Then
                If objParametros.GetConteudo("exigir_motivo_fechamento_negociacao") = "S" Then
                    exigeMotivoFechamentoNegociacao = True
                End If
            End If

            LblErro.Text = ""

            If String.IsNullOrWhiteSpace(DdlEstabelecimento.SelectedValue) Or DdlEstabelecimento.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Estabelecimento<br/>"
            End If

            If String.IsNullOrEmpty(DdlContato.SelectedValue) Or DdlContato.SelectedValue = "0" Then
                LblErro.Text += "Preencha o campo Contato<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlRepresentante.SelectedValue) Or DdlRepresentante.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Vendedor/Representante.<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlAgente.SelectedValue) Or DdlAgente.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Agente de vendas.<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlCanalVenda.SelectedValue) Or DdlCanalVenda.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Canal de Venda.<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlCarteira.SelectedValue) Or DdlCarteira.SelectedValue = 0 And Session("GlClienteUnis") = 1 Then
                LblErro.Text += "Preencha o campo Carteira.<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlMoeda.SelectedValue) Or DdlMoeda.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Moeda.<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlFormaPagto.SelectedValue) Or DdlFormaPagto.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Forma de Pagamento.<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlCondicaoPagto.SelectedValue) Or DdlCondicaoPagto.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Condição de Pagamento.<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlNatureza.SelectedValue) Or DdlNatureza.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Natureza da Operação.<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlFrete.SelectedValue) Or DdlFrete.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Tipo de Frete.<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlFunil.SelectedValue) Or DdlFunil.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Funil de Vendas<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlEtapa.SelectedValue) Or DdlEtapa.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Etapa da Venda.<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlStatus.SelectedValue) Or DdlStatus.SelectedValue = 0 And Session("GlClienteUnis") = 1 Then
                LblErro.Text += "Preencha o campo Status da Venda.<br/>"
            End If

            If String.IsNullOrWhiteSpace(DdlFonteOrigem.SelectedValue) Or DdlFonteOrigem.SelectedValue = 0 And Session("GlClienteUnis") = 1 Then
                LblErro.Text += "Preencha o campo Origem do Lead.<br/>"
            End If


            If String.IsNullOrEmpty(TxtCliente.Text) Then
                LblErro.Text += "Preencha o campo Cliente.<br/>"
            End If





            objEtapa.Empresa = Session("GlEmpresa")
            objEtapa.Codigo = DdlEtapa.SelectedValue
            objEtapa.Buscar()

            If Acao = "INCLUIR" Then
                permiteDataPrevisaoEmBranco = True
            Else
                objNegociacao.Empresa = Session("GlEmpresa")
                objNegociacao.Estabelecimento = Session("GlEstabelecimento")
                objNegociacao.CodNegociacao = LblNrNegociacao.Text
                If Not objNegociacao.TemItens() Then
                    permiteDataPrevisaoEmBranco = True
                Else
                    If objEtapa.NaoExigirDataPrevisao = "S" Then
                        permiteDataPrevisaoEmBranco = True
                    End If
                End If
            End If

            If objEtapa.ExigirDataRecontato = "S" Then
                exigeDataRecontato = True
            End If

            If Not permiteDataPrevisaoEmBranco Then
                If TxtPrevisaoFechamento.Text = "" Then
                    LblErro.Text += "Preencha o campo Previsão de Fechamento.<br/>"
                ElseIf Not isValidDate(TxtPrevisaoFechamento.Text) Then
                    LblErro.Text += "Preencha corretamente o campo Previsão de Fechamento.<br/>"
                End If
            End If

            If exigeDataRecontato Then
                If TxtDataRecontato.Text = "" Then
                    LblErro.Text += "Preencha o campo Data Recontato.<br/>"
                ElseIf Not isValidDate(TxtDataRecontato.Text) Then
                    LblErro.Text += "Preencha corretamente o campo Data Recontato.<br/>"
                Else
                    'If Acao = "INCLUIR" Then
                    If CDate(TxtDataRecontato.Text) < Now.Date() Then
                        LblErro.Text += "Data do recontato não pode ser retroativa.<br/>"
                    End If
                    'End If
                End If
            End If

            If objEtapa.Status = "3" AndAlso exigeMotivoFechamentoNegociacao AndAlso DdlMotivoFechamento.SelectedValue.ToString = "0" Then
                If Not objNegociacao.TemMotivoDeFechamentoOuPerda(Session("GlEmpresa"), Session("GlEstabelecimento"), LblNrNegociacao.Text) And IsNull(objNegociacao.CodMotivo, -2) = -2 Then
                    LblErro.Text += "Antes de encerrar a negociação é necessário informar o(s) motivo(s) de fechamento ou perda.<br/>"
                End If
            End If

            Return LblErro.Text.Trim = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Function CarregaObjeto(ByRef objNegociacao As UCLNegociacao) As UCLNegociacao
        Try
            Dim dataHoraRecontato As String = ""

            objNegociacao.CodCliente = TxtCliente.Text
            objNegociacao.CNPJ = DdlCNPJ.SelectedValue

            If DdlEquipamento.SelectedValue = "-1" OrElse DdlEquipamento.SelectedValue = "0" Then
                objNegociacao.NumeroSerie = ""
            Else
                objNegociacao.NumeroSerie = DdlEquipamento.SelectedValue
            End If


            If String.IsNullOrWhiteSpace(DdlContato.SelectedValue) OrElse DdlContato.SelectedValue = 0 Then
                objNegociacao.CodContato = "null"
            Else
                objNegociacao.CodContato = DdlContato.SelectedValue
            End If

            If (String.IsNullOrWhiteSpace(DdlCarteira.SelectedValue) OrElse DdlCarteira.SelectedValue = 0) Then
                objNegociacao.CodCarteira = "null"
            Else
                objNegociacao.CodCarteira = DdlCarteira.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlGestor.SelectedValue) OrElse DdlGestor.SelectedValue = 0 Then
                objNegociacao.CodGestorConta = "null"
            Else
                objNegociacao.CodGestorConta = DdlGestor.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlTipoCobranca.SelectedValue) OrElse DdlTipoCobranca.SelectedValue = 0 Then
                objNegociacao.CodTipoCobrancaOs = "null"
            Else
                objNegociacao.CodTipoCobrancaOs = DdlTipoCobranca.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlTipoCobranca.SelectedValue) OrElse DdlTipoCobranca.SelectedValue = 0 Then
                objNegociacao.CodTipoCobrancaOs = "null"
            Else
                objNegociacao.CodTipoCobrancaOs = DdlTipoCobranca.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlMotivoFechamento.SelectedValue) OrElse DdlMotivoFechamento.SelectedValue = 0 Then
                objNegociacao.CodMotivo = "null"
            Else
                objNegociacao.CodMotivo = DdlMotivoFechamento.SelectedValue
            End If

            If Acao = "INCLUIR" Then
                If Session("SCodAtendimento") IsNot Nothing AndAlso Session("SCodAtendimento").ToString() <> "" Then
                    objNegociacao.CodChamado = Session("SCodAtendimento")
                End If
                If DdlEstabelecimento.SelectedValue = "-1" OrElse DdlEstabelecimento.SelectedValue = "0" Then
                    Throw New Exception("O campo estabelecimentno é um campo obrigatório. Por favor selecione o estabelecimento!")
                    'objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
                Else
                    'objNegociacao.Estabelecimento = Session("GlEstabelecimento")
                    objNegociacao.Estabelecimento = DdlEstabelecimento.SelectedValue
                End If
            End If

            If String.IsNullOrWhiteSpace(DdlAgente.SelectedValue) OrElse DdlAgente.SelectedValue = 0 Then
                Throw New Exception("O Agente de vendas é um campo obrigatório. Por favor preencher o campo agente de vendas!")
                'objNegociacao.CodAgenteVenda = "null"
            Else
                objNegociacao.CodAgenteVenda = DdlAgente.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlCanalVenda.SelectedValue) OrElse DdlCanalVenda.SelectedValue = "0" Then
                Throw New Exception("O canal de venda é um campo obrigatório. Por favor preencher o campo canal de venda!")
                'objNegociacao.CodCanalVendas = "null"
            Else
                objNegociacao.CodCanalVendas = DdlCanalVenda.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlNatureza.SelectedValue) OrElse DdlNatureza.SelectedValue = "0" Then
                Throw New Exception("O natureza de operação é um campo obrigatório. Por favor preencher o campo natureza de operação!")
                'objNegociacao.CodNaturOper = "null"
            Else
                objNegociacao.CodNaturOper = DdlNatureza.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlModelo.SelectedValue) OrElse DdlModelo.SelectedValue = "0" Then
                objNegociacao.CodModelo = "null"
            Else
                objNegociacao.CodModelo = DdlModelo.SelectedValue
            End If

            objNegociacao.GerarPedido = ChkGerarPedido.Checked.ToString.Replace("False", "N").Replace("True", "S")

            objNegociacao.ManterInformado = TxtManterInformado.Text.GetValidInputContent

            If String.IsNullOrWhiteSpace(DdlEtapa.SelectedValue) OrElse DdlEtapa.SelectedValue = "0" Then
                Throw New Exception("O campo etapa da negociação é um campo obrigatório. Por favor preencher o campo etapa da negociação!")
                'objNegociacao.CodNaturOper = "null"
            Else
                objNegociacao.CodEtapaNegociacao = DdlEtapa.SelectedValue
            End If


            If isValidDate(TxtDataRecontato.Text) Then
                dataHoraRecontato = TxtDataRecontato.Text
                If Not String.IsNullOrEmpty(TxtHoraRecontato.Text.Trim) Then
                    dataHoraRecontato += " " + TxtHoraRecontato.Text
                End If
            Else
                dataHoraRecontato = ""
            End If

            If Acao = "ALTERAR" Then
                If Not String.IsNullOrEmpty(dataHoraRecontato) Then
                    If String.IsNullOrEmpty(objNegociacao.DataRecontato) Then
                        If CDate(TxtDataRecontato.Text) < Now.Date() Then
                            Throw New Exception("Data do recontato não pode ser retroativa.")
                        End If
                    Else
                        If Convert.ToDateTime(dataHoraRecontato) <> Convert.ToDateTime(objNegociacao.DataRecontato) Then
                            If CDate(TxtDataRecontato.Text) < Now.Date() Then
                                Throw New Exception("Data do recontato não pode ser retroativa.")
                            End If
                        End If
                    End If
                End If
            End If
            objNegociacao.DataRecontato = dataHoraRecontato

            If isValidDate(TxtDataValidadeProposta.Text) Then
                objNegociacao.DataValidade = TxtDataValidadeProposta.Text
            Else
                objNegociacao.DataValidade = ""
            End If

            If isValidDate(TxtPrevisaoFechamento.Text) Then
                objNegociacao.DataPrevisaoFechamento = TxtPrevisaoFechamento.Text
            Else
                objNegociacao.DataPrevisaoFechamento = ""
            End If

            If String.IsNullOrEmpty(TxtProbabilidadeSucesso.Text) Then
                objNegociacao.ProbabilidadeSucesso = "null"
            Else
                objNegociacao.ProbabilidadeSucesso = TxtProbabilidadeSucesso.Text
            End If

            objNegociacao.Prioridade = ddlPrioridade.SelectedValue
            objNegociacao.Receptividade = ddlReceptividade.SelectedValue

            If String.IsNullOrWhiteSpace(DdlFormaPagto.SelectedValue) OrElse DdlFormaPagto.SelectedValue = 0 Then
                Throw New Exception("A forma de pagamento é um campo obrigatório. Por favor preencher o campo forma de pagamento!")
                objNegociacao.CodFormaPagto = "null"
            Else
                objNegociacao.CodFormaPagto = DdlFormaPagto.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlCondicaoPagto.SelectedValue) OrElse DdlCondicaoPagto.SelectedValue = 0 Then
                Throw New Exception("A condição de pagamento é um campo obrigatório. Por favor preencher o campo condição de pagamento!")
                'objNegociacao.CodCondPagto = "null"
            Else
                objNegociacao.CodCondPagto = DdlCondicaoPagto.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlFonteOrigem.SelectedValue) OrElse DdlFonteOrigem.SelectedValue = 0 Then
                objNegociacao.CodFonteOrigemNegociacao = "null"
            Else
                objNegociacao.CodFonteOrigemNegociacao = DdlFonteOrigem.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlStatus.SelectedValue) OrElse DdlStatus.SelectedValue = 0 Then
                objNegociacao.CodStatus = "null"
            Else
                objNegociacao.CodStatus = DdlStatus.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlMoeda.SelectedValue) OrElse DdlMoeda.SelectedValue = 0 Then
                Throw New Exception("A moeda é um campo obrigatório. Por favor preencher o campo moeda!")
                'objNegociacao.CodFonteOrigemNegociacao = "null"
            Else
                objNegociacao.Moeda = DdlMoeda.SelectedValue
            End If


            'If String.IsNullOrEmpty(DdlRepresentante.SelectedValue) Then

            If String.IsNullOrWhiteSpace(DdlRepresentante.SelectedValue) OrElse DdlRepresentante.SelectedValue = 0 Then
                Throw New Exception("O Vendedor/Representante é um campo obrigatório. Por favor preencher o campo Vendedor/Representante!")
                'objNegociacao.CodRepresentante = "null"
            Else
                objNegociacao.CodRepresentante = DdlRepresentante.SelectedValue
            End If


            objNegociacao.CodTipoObra = DdlTipoObra.SelectedValue
            objNegociacao.CodEstagioObra = DdlEstagioObra.SelectedValue
            objNegociacao.CodModalidadeObra = DdlModalidadeObra.SelectedValue
            objNegociacao.TamanhoObra = TxtTamanhoObra.Text

            If String.IsNullOrWhiteSpace(DdlFrete.SelectedValue) OrElse DdlFrete.SelectedValue = 0 Then
                Throw New Exception("O tipo de frete é um campo obrigatório. Por favor preencher o campo tipo de frete!")
                'objNegociacao.tipo_frete = "2"
            Else
                objNegociacao.tipo_frete = DdlFrete.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlFunil.SelectedValue) OrElse DdlFunil.SelectedValue = 0 Then
                Throw New Exception("O funil de vendas é um campo obrigatório. Por favor preencher o campo funil de vendas!")
                'objNegociacao.tipo_frete = "2"
            Else
                objNegociacao.CodFunil = DdlFunil.SelectedValue
            End If

            objNegociacao.CodEmitenteAtendimento = TxtClienteAtendimento.Text
            objNegociacao.NumeroPontoAtendimento = TxtNrPontoAtendimento.Text
            objNegociacao.CodContatoAtendimento = DdlContatoAtendimento.SelectedValue
            objNegociacao.GerarChamado = ChkGerarChamado.Checked.ToString.Replace("False", "N").Replace("True", "S")

            Return objNegociacao
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub MostraNomeCliente()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim qtdTitulosEmAberto As Long
            Dim diasInadimplente As Long

            Dim ObjEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
            If Not String.IsNullOrEmpty(TxtCliente.Text) Then
                objEmitente.CodEmitente = TxtCliente.Text
                Session("SCodEmitente") = objEmitente.CodEmitente
                objEmitente.Buscar()

                LblNomeCliente.Text = objEmitente.Nome
                ObjEnderecoEmitente.CodEmitente = TxtCliente.Text
                ObjEnderecoEmitente.CNPJ = DdlCNPJ.SelectedValue

                qtdTitulosEmAberto = objEmitente.TitulosEmAbertoVencidos(Session("GlEmpresa"))
                diasInadimplente = objEmitente.DiasInadimplente(Session("GlEmpresa"))

                If qtdTitulosEmAberto > 0 AndAlso diasInadimplente > 0 Then
                    LblInadimplente.Text = "Cliente possui " + qtdTitulosEmAberto.ToString + " título(s) em aberto e está inadimplente há " + diasInadimplente.ToString + " dias"
                Else
                    LblInadimplente.Text = ""
                End If


                If ObjEnderecoEmitente.Buscar() Then
                    LblTelefone.Text = ObjEnderecoEmitente.Fone1
                    If Not String.IsNullOrWhiteSpace(ObjEnderecoEmitente.Fone2) Then
                        LblTelefone.Text += " / " + ObjEnderecoEmitente.Fone2
                    End If

                    LblInscEstadual.Text = ObjEnderecoEmitente.IE

                    If LblInscEstadual.Text = "ISENTO" Or LblInscEstadual.Text = "isento" Then
                        LblInscEstadual.ForeColor = Drawing.Color.Red
                    Else
                        LblInscEstadual.ForeColor = Drawing.Color.Empty
                    End If

                    LblEndereco.Text = ObjEnderecoEmitente.Logradouro
                    If Not String.IsNullOrEmpty(ObjEnderecoEmitente.Numero) AndAlso ObjEnderecoEmitente.Numero <> "0" Then
                        LblEndereco.Text += ", Nº " + ObjEnderecoEmitente.Numero
                    End If
                    If Not String.IsNullOrEmpty(ObjEnderecoEmitente.Referencia) Then
                        LblEndereco.Text += " " + ObjEnderecoEmitente.Referencia
                    End If
                    If Not String.IsNullOrEmpty(ObjEnderecoEmitente.Bairro) Then
                        LblEndereco.Text += " - Bairro " + ObjEnderecoEmitente.Bairro
                    End If

                    Dim objPais As New UCLPais
                    Dim objEstado As New UCLEstado
                    Dim objCidade As New UCLCidade

                    objPais.CodPais = ObjEnderecoEmitente.CodPais
                    objPais.Buscar()

                    objEstado.CodPais = ObjEnderecoEmitente.CodPais
                    objEstado.CodEstado = ObjEnderecoEmitente.CodEstado
                    objEstado.Buscar()

                    objCidade.CodPais = ObjEnderecoEmitente.CodPais
                    objCidade.CodEstado = ObjEnderecoEmitente.CodEstado
                    objCidade.CodCidade = ObjEnderecoEmitente.CodCidade
                    objCidade.Buscar()

                    LblEndereco.Text += "<br>" + objCidade.NomeCidade + " / " + IIf(Not String.IsNullOrEmpty(objEstado.Sigla), objEstado.Sigla, objEstado.NomeEstado) + " - " + objPais.Nome
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim dataHoraRecontato As String
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            LblNrNegociacao.Text = CodNegociacao

            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
            objNegociacao.CodNegociacao = CodNegociacao
            objNegociacao.Buscar()

            TxtCliente.Text = objNegociacao.CodCliente
            Session("SCodEmitenteNegociacao") = TxtCliente.Text
            Session("SCodEmitenteNegociacaoAnterior") = TxtCliente.Text
            DdlCNPJ.SelectedValue = objNegociacao.CNPJ
            Call CarregaEquipamentoCliente(objNegociacao.NumeroSerie)
            DdlEquipamento.SelectedValue = objNegociacao.NumeroSerie
            'Necessário para que a alteração de emitente funcione via tela da negociação, não retirar
            '----------------------------------------------
            Session("SCNPJEmitente") = objNegociacao.CNPJ
            '----------------------------------------------

            ChkGerarPedido.Checked = objNegociacao.GerarPedido.ToString.Replace("S", "True").Replace("N", "False")
            ChkGerarChamado.Checked = objNegociacao.GerarChamado.ToString.Replace("S", "True").Replace("N", "False")

            Call CarregaDropDowns(objNegociacao.CodFunil, objNegociacao.CodEtapaNegociacao)

            DdlMoeda.SelectedValue = objNegociacao.Moeda
            DdlNatureza.SelectedValue = objNegociacao.CodNaturOper
            DdlModelo.SelectedValue = objNegociacao.CodModelo
            DdlCanalVenda.SelectedValue = objNegociacao.CodCanalVendas
            DdlEstabelecimento.SelectedValue = objNegociacao.Estabelecimento
            DdlContato.SelectedValue = objNegociacao.CodContato
            Call ContatoSelecionadoMudou()

            Call CarregaAgentesVenda(objNegociacao.CodAgenteVenda)
            DdlAgente.SelectedValue = objNegociacao.CodAgenteVenda

            Call CarregaVendedores(objNegociacao.CodRepresentante, False)
            DdlRepresentante.SelectedValue = objNegociacao.CodRepresentante

            DdlGestor.SelectedValue = objNegociacao.CodGestorConta
            DdlFunil.SelectedValue = objNegociacao.CodFunil
            FunilMudou(objNegociacao.CodFunil, objNegociacao.CodEtapaNegociacao)
            DdlEtapa.SelectedValue = objNegociacao.CodEtapaNegociacao
            DdlFormaPagto.SelectedValue = objNegociacao.CodFormaPagto
            DdlCondicaoPagto.SelectedValue = objNegociacao.CodCondPagto
            DdlStatus.SelectedValue = objNegociacao.CodStatus
            DdlNatureza.SelectedValue = objNegociacao.CodNaturOper

            If objNegociacao.CodFonteOrigemNegociacao IsNot Nothing Then
                DdlFonteOrigem.SelectedValue = objNegociacao.CodFonteOrigemNegociacao
            End If

            dataHoraRecontato = objNegociacao.DataRecontato
            TxtDataRecontato.Text = Left(dataHoraRecontato, 10)
            TxtHoraRecontato.Text = Right(dataHoraRecontato, 5)
            If TxtHoraRecontato.Text = "00:00" Then
                TxtHoraRecontato.Text = ""
            End If

            TxtDataValidadeProposta.Text = objNegociacao.DataValidade
            TxtPrevisaoFechamento.Text = objNegociacao.DataPrevisaoFechamento

            TxtManterInformado.Text = objNegociacao.ManterInformado
            TxtProbabilidadeSucesso.Text = objNegociacao.ProbabilidadeSucesso
            ddlPrioridade.SelectedValue = objNegociacao.Prioridade
            ddlReceptividade.SelectedValue = objNegociacao.Receptividade
            DdlCarteira.SelectedValue = objNegociacao.CodCarteira

            If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
                DdlRepresentante.Enabled = False
            End If

            DdlTipoObra.SelectedValue = objNegociacao.CodTipoObra
            DdlEstagioObra.SelectedValue = objNegociacao.CodEstagioObra
            DdlModalidadeObra.SelectedValue = objNegociacao.CodModalidadeObra
            TxtTamanhoObra.Text = objNegociacao.TamanhoObra

            LblDataCadastramento.Text = objNegociacao.DataCadastramento

            DdlFrete.SelectedValue = objNegociacao.tipo_frete
            LblCodChamado.Text = objNegociacao.CodChamado
            DdlTipoCobranca.SelectedValue = objNegociacao.CodTipoCobrancaOs
            DdlMotivoFechamento.SelectedValue = objNegociacao.CodMotivo

            TxtClienteAtendimento.Text = objNegociacao.CodEmitenteAtendimento
            Call CodigoClienteAtendimentoMudou()

            TxtNrPontoAtendimento.Text = objNegociacao.NumeroPontoAtendimento
            Call NrPontoAtendimentoMudou()

            'Necessário para que a alteração de emitente funcione via tela do chamado, não retirar
            '----------------------------------------------
            Session("SPontoAtendimento") = TxtNrPontoAtendimento.Text
            '----------------------------------------------

            Call CarregaContatoAtendimento()
            If Not String.IsNullOrEmpty(objNegociacao.CodContatoAtendimento) Then
                DdlContatoAtendimento.SelectedValue = objNegociacao.CodContatoAtendimento
                Call ContatoSelecionadoAtendimentoMudou()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Try
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            LblNrNegociacao.Text = objNegociacao.GetProximoCodigo
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CNPJMudou()
        Try
            'Necessário para que a alteração de emitente funcione via tela da negociação, não retirar
            Session("SCNPJEmitente") = DdlCNPJ.SelectedValue

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlCNPJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlCNPJ.SelectedIndexChanged
        Try
            Call CNPJMudou()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FunilMudou(ByVal pCodFunil As String, ByVal pCodEtapa As String)
        Dim objFunil As New UCLFunilVenda
        pCodFunil = IIf(String.IsNullOrEmpty(pCodFunil), "0", pCodFunil)
        pCodEtapa = IIf(String.IsNullOrEmpty(pCodEtapa), "0", pCodEtapa)
        objFunil.Empresa = Session("GlEmpresa")
        objFunil.Codigo = pCodFunil
        If objFunil.Buscar() Then
            If objFunil.OcultarEquipamento = "S" Then
                LblEquipamento.Visible = False
                DdlEquipamento.Visible = False
            Else
                LblEquipamento.Visible = True
                DdlEquipamento.Visible = True
            End If
        End If
        Call CarregaEtapa(pCodFunil, pCodEtapa)
    End Sub

    Protected Sub DdlFunil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlFunil.SelectedIndexChanged
        Try
            Call FunilMudou(DdlFunil.SelectedValue, "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlEtapa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlEtapa.SelectedIndexChanged
        Try
            Call EtapaMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub EtapaMudou()
        Try
            Dim objEtapa As New UCLEtapaNegociacao
            If DdlEtapa.SelectedValue <> "" Then
                objEtapa.Empresa = Session("GlEmpresa")
                objEtapa.Codigo = DdlEtapa.SelectedValue
                objEtapa.Buscar()
                If Not String.IsNullOrEmpty(objEtapa.PercentualFechamento) Then
                    TxtProbabilidadeSucesso.Text = CDbl(objEtapa.PercentualFechamento).ToString("F2")
                End If
            End If
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

    Public Sub CarregaMotivoFechamentoNegociacao()
        Try
            Dim objMotivo As New UCLMotivoFechamento
            objMotivo.FillDropDown(DdlMotivoFechamento, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChecaPesquisaClienteAtendimento()
        Try
            Dim CodClientePesquisado As String
            Dim cnpjPesquisado As String
            Dim alterouCliente As Long

            If Not String.IsNullOrEmpty(Session("SAlterouCodClienteAt")) Then
                alterouCliente = Session("SAlterouCodClienteAt")
            Else
                alterouCliente = 0
            End If

            CodClientePesquisado = Session("SCodClienteAtPesquisado")
            cnpjPesquisado = Session("SCNPJAtPesquisado")

            If Not String.IsNullOrEmpty(CodClientePesquisado) Then
                If alterouCliente > 0 Then
                    If TxtClienteAtendimento.Text <> CodClientePesquisado Then
                        TxtClienteAtendimento.Text = CodClientePesquisado
                        Call CodigoClienteAtendimentoMudou()
                    End If
                    'If DdlCNPJAtendimento.SelectedValue <> cnpjPesquisado Then
                    '    DdlCNPJAtendimento.SelectedValue = cnpjPesquisado
                    '    Call CNPJAtendimentoMudou()
                    'End If
                    Session("SAlterouCodClienteAt") = alterouCliente - 2
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChecaEdicaoContatoAtendimento()
        Try
            Dim CodContatoRetornado As String
            Dim recarregaContatos As Long

            If Not String.IsNullOrEmpty(Session("SRecarregaDdlContatosAt")) Then
                recarregaContatos = Session("SRecarregaDdlContatosAt")
            Else
                recarregaContatos = 0
            End If

            If recarregaContatos > 0 Then
                CodContatoRetornado = Session("SCodContatoNegociacaoAt")
                Call CarregaContatoAtendimento()
                If Not String.IsNullOrEmpty(CodContatoRetornado) Then
                    DdlContatoAtendimento.SelectedValue = CodContatoRetornado
                    Call ContatoSelecionadoAtendimentoMudou()
                End If
                Session("SRecarregaDdlContatosAt") = recarregaContatos - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaContatoAtendimento()
        Try
            Dim objContato As New UCLContato
            If Not String.IsNullOrEmpty(TxtClienteAtendimento.Text) Then
                objContato.CodEmitente = TxtClienteAtendimento.Text
                objContato.NumeroPontoAtendimento = TxtNrPontoAtendimento.Text
                objContato.FillDropDown(DdlContatoAtendimento, True, "", "-1")
                DdlContatoAtendimento.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CodigoClienteAtendimentoMudou()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Session("SCodEmitenteAtNegociacao") = TxtClienteAtendimento.Text
            Session("SCodClienteAtPesquisado") = TxtClienteAtendimento.Text
            Call NrPontoAtendimentoMudou()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NrPontoAtendimentoMudou()
        Try
            'Dim objEndereco As New UCLEnderecoEmitente
            Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEstado As New UCLEstado
            Dim objCidade As New UCLCidade

            'Necessário para que a alteração de emitente funcione via tela da negociação, não retirar
            Session("SPontoAtendimento") = TxtNrPontoAtendimento.Text
            Session("SPontoPesquisado") = TxtNrPontoAtendimento.Text

            If Not String.IsNullOrEmpty(TxtClienteAtendimento.Text) AndAlso Not String.IsNullOrEmpty(TxtNrPontoAtendimento.Text) Then
                objPontoAtendimento.CodEmitente = TxtClienteAtendimento.Text
                objPontoAtendimento.NumeroPontoAtendimento = TxtNrPontoAtendimento.Text
                objPontoAtendimento.Buscar()
                If Not String.IsNullOrEmpty(objPontoAtendimento.CodEstado) AndAlso Not String.IsNullOrEmpty(objPontoAtendimento.CodCidade) Then
                    objEstado.CodPais = objPontoAtendimento.CodPais
                    objEstado.CodEstado = objPontoAtendimento.CodEstado
                    objEstado.Buscar()

                    objCidade.CodPais = objPontoAtendimento.CodPais
                    objCidade.CodEstado = objPontoAtendimento.CodEstado
                    objCidade.CodCidade = objPontoAtendimento.CodCidade
                    objCidade.Buscar()

                    LblEnderecoAtendimento.Text = objPontoAtendimento.Logradouro
                    If Not String.IsNullOrEmpty(objPontoAtendimento.Numero) AndAlso objPontoAtendimento.Numero <> 0 Then
                        LblEnderecoAtendimento.Text += ", " + objPontoAtendimento.Numero
                    End If
                    LblEnderecoAtendimento.Text += " - " + objCidade.NomeCidade
                    LblEnderecoAtendimento.Text += "/" + objEstado.Sigla
                Else
                    LblEnderecoAtendimento.Text = "(não informado)"
                End If

                LblTelefoneAtendimento.Text = objPontoAtendimento.Fone1
                If Not String.IsNullOrEmpty(objPontoAtendimento.Fone2) Then
                    LblTelefoneAtendimento.Text += " / " + objPontoAtendimento.Fone2
                End If

                Call MostraNomeClienteAtendimento()

                Call CarregaContatoAtendimento()

                DdlContatoAtendimento.SelectedValue = -1
                Call ContatoSelecionadoAtendimentoMudou()

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub ContatoSelecionadoAtendimentoMudou()
        Try
            Session("SCodContatoNegociacaoAt") = DdlContatoAtendimento.SelectedValue
            Call CarregaInfoContatoAtendimento()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaInfoContatoAtendimento()
        Try
            Dim objContato As New UCLContato
            If Not String.IsNullOrEmpty(TxtClienteAtendimento.Text) And Not String.IsNullOrEmpty(DdlContatoAtendimento.SelectedValue) Then
                objContato.CodEmitente = TxtClienteAtendimento.Text
                objContato.Codigo = DdlContatoAtendimento.SelectedValue
                objContato.Buscar()
                LblEmailAtendimento.Text = objContato.Email
            Else
                LblEmailAtendimento.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MostraNomeClienteAtendimento()
        Try
            Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objTipoPontoAtendimento As New UCLTipoPontoAtendimento
            If Not String.IsNullOrEmpty(TxtClienteAtendimento.Text) Then
                objPontoAtendimento.CodEmitente = TxtClienteAtendimento.Text
                objPontoAtendimento.NumeroPontoAtendimento = TxtNrPontoAtendimento.Text

                If Not String.IsNullOrEmpty(objPontoAtendimento.CodEmitente) Then
                    objEmitente.CodEmitente = objPontoAtendimento.CodEmitente
                    objEmitente.Buscar()
                    LblRazaoSocialPontoAtendimento.Text = objEmitente.Nome
                End If

                If Not String.IsNullOrEmpty(objPontoAtendimento.CodEmitente) AndAlso Not String.IsNullOrEmpty(objPontoAtendimento.NumeroPontoAtendimento) Then
                    objPontoAtendimento.Buscar()

                    objTipoPontoAtendimento.CodTipoPontoAtendimento = objPontoAtendimento.CodTipoPontoAtendimento
                    If Not String.IsNullOrEmpty(objTipoPontoAtendimento.CodTipoPontoAtendimento) Then
                        objTipoPontoAtendimento.Buscar()
                    End If

                    LblNomePontoAtendimento.Text = objTipoPontoAtendimento.Descricao + "  " + objPontoAtendimento.NumeroPontoAtendimento + " ─ " + objPontoAtendimento.Descricao
                    LblObsPontoAtendimento.Text = objPontoAtendimento.Observacao
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChecaPesquisaPontoAtendimento()
        Try
            Dim PontoPesquisado As String
            Dim alterouPontoAtendimento As Long

            If Not String.IsNullOrEmpty(Session("SAlterouNumeroPontoAtendimento")) Then
                alterouPontoAtendimento = Session("SAlterouNumeroPontoAtendimento")
            Else
                alterouPontoAtendimento = 0
            End If

            PontoPesquisado = Session("SPontoPesquisado")

            If Not String.IsNullOrEmpty(PontoPesquisado) Then
                If alterouPontoAtendimento > 0 Then
                    If TxtNrPontoAtendimento.Text <> PontoPesquisado Then
                        TxtNrPontoAtendimento.Text = PontoPesquisado
                        Call NrPontoAtendimentoMudou()
                    End If
                    Session("SAlterouNumeroPontoAtendimento") = alterouPontoAtendimento - 2
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
