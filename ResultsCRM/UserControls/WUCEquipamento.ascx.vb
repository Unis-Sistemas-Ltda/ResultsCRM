Public Partial Class WUCEquipamento
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _NumeroSerie As String
    Private _CodCliente As String
    Private _CNPJ As String
    Private _NumeroPontoAtendimento As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property NumeroSerie() As String
        Get
            Return _NumeroSerie
        End Get
        Set(ByVal value As String)
            _NumeroSerie = value
        End Set
    End Property
    Public Property CodCliente() As String
        Get
            Return _CodCliente
        End Get
        Set(ByVal value As String)
            _CodCliente = value
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
    Public Property NumeroPontoAtendimento() As String
        Get
            Return _NumeroPontoAtendimento
        End Get
        Set(ByVal value As String)
            _NumeroPontoAtendimento = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call AjustaVisibilidadeBotoes(GetModoAberturaJanela())

            If Session("GlTipoFaturamento").ToString = "G" Then
                LblTitulo.Text = "Detalhe do Cadastro de Produto"
                LblNumeroControle.Text = "Nº Controle"
                LblTituloPasso2.Text = "Produto"
                LblCodEquipamentoLbl0.Text = "Produto"
                GridView2.EmptyDataText = "Nenhum componente foi inserido neste produto até o momento. Informe um item acima e clique no botão Incluir para adicionar um."
            End If

            MultiView1.ActiveViewIndex = 0

            LblCodCliente.Text = CodCliente
            LblCodClienteComponente.Text = CodCliente
            LblCNPJ.Text = CNPJ.MascaraCNPJ
            LblCNPJComponente.Text = LblCNPJ.Text

            Call MostraNomeCliente()
            Call CarregaEstabelecimentos()

            If Acao = "ALTERAR" Then
                LblNrSerie.Text = NumeroSerie
                LblNrSerieComponente.Text = NumeroSerie
                Call CarregaFormulario()

            ElseIf Acao = "INCLUIR" Then
                Dim objEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))

                objEquipamento.Empresa = Session("GlEmpresa")
                objEquipamento.NumeroSerie = LblNrSerie.Text
                If objEquipamento.Buscar() Then
                    LblNrSerie.Text = NumeroSerie
                    LblNrSerieComponente.Text = NumeroSerie
                    Call CarregaFormulario()
                Else
                    CBxAtivo.Checked = True
                    CBxAtivo.Enabled = False
                    CarregaNovaPK()
                    CarregaNSU()
                End If
            End If
        End If
    End Sub

    Private Sub CarregaEstabelecimentos()
        Try
            Dim objEstabelecimento As New UCLEstabelecimento
            objEstabelecimento.CodEmpresa = Session("GlEmpresa")
            objEstabelecimento.FillDropDown(DdlEstabelecimentoNFS, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
        ObjEquipamento.Empresa = Session("GlEmpresa")
        ObjEquipamento.NumeroSerie = NumeroSerie
        ObjEquipamento.Buscar()

        CBxAtivo.Checked = ObjEquipamento.Ativo.Replace("S", "True").Replace("N", "False")
        TxtRegPatrimonial.Text = ObjEquipamento.NumeroRegistroPatrimonio
        DdlEstabelecimentoNFS.SelectedValue = ObjEquipamento.EstabelecimentoNFS
        TxtObservacao.Text = ObjEquipamento.Observacao
        TxtNumeroSerieTerceiro.Text = ObjEquipamento.NumeroSerieTerceiro
        TxtCodItem.Text = ObjEquipamento.CodItem
        TxtPlaca.Text = ObjEquipamento.Placa
        TxtQuantidade.Text = ObjEquipamento.Quantidade
        Call MostraDescricaoItem()
    End Sub

    Private Sub MostraNomeCliente()
        Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
        If Not String.IsNullOrEmpty(CodCliente) And Not String.IsNullOrWhiteSpace(NumeroPontoAtendimento) Then
            objPontoAtendimento.CodEmitente = CodCliente
            objPontoAtendimento.NumeroPontoAtendimento = NumeroPontoAtendimento
            objPontoAtendimento.Buscar()

            LblDescricaoPontoAtendimento.Text = objPontoAtendimento.NumeroPontoAtendimento + " ─ " + objPontoAtendimento.Descricao
            LblDescricaoPontoAtendimentoComponente.Text = LblDescricaoPontoAtendimento.Text
        End If
    End Sub

    Public Function Gravar() As Boolean
        Try
            Dim objEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))

            If IsDigitacaoOK() Then
                If Acao = "INCLUIR" Then
                    objEquipamento.Empresa = Session("GlEmpresa")
                    objEquipamento.NumeroSerie = LblNrSerie.Text
                    If objEquipamento.Buscar() Then
                        objEquipamento.Empresa = Session("GlEmpresa")
                        objEquipamento.NumeroSerie = NumeroSerie
                        objEquipamento.Buscar()
                        objEquipamento = CarregaObjeto(objEquipamento)
                        objEquipamento.Alterar()
                        Return True
                    Else
                        CarregaNovaPK()
                        objEquipamento.Empresa = Session("GlEmpresa")
                        objEquipamento.NumeroSerie = LblNrSerie.Text
                        objEquipamento = CarregaObjeto(objEquipamento)
                        objEquipamento.Incluir()
                        Return True
                    End If
                Else
                    objEquipamento.Empresa = Session("GlEmpresa")
                    objEquipamento.NumeroSerie = NumeroSerie
                    objEquipamento.Buscar()
                    objEquipamento = CarregaObjeto(objEquipamento)
                    objEquipamento.Alterar()
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function CarregaObjeto(ByVal objEquipamento As UCLEquipamentoCliente) As UCLEquipamentoCliente

        objEquipamento.Ativo = CBxAtivo.Checked.ToString.Replace("True", "S").Replace("False", "N")
        objEquipamento.NumeroRegistroPatrimonio = TxtRegPatrimonial.Text
        objEquipamento.CodCliente = CodCliente
        objEquipamento.CNPJ = CNPJ
        objEquipamento.NumeroSerieTerceiro = TxtNumeroSerieTerceiro.Text
        objEquipamento.NumeroPontoAtendimento = NumeroPontoAtendimento
        objEquipamento.EstabelecimentoNFS = DdlEstabelecimentoNFS.SelectedValue
        objEquipamento.Observacao = TxtObservacao.Text
        objEquipamento.Placa = TxtPlaca.Text
        objEquipamento.Quantidade = TxtQuantidade.Text
        If objEquipamento.DDataReferenciaGarantia = Nothing Then
            objEquipamento.DataReferenciaGarantia = "01/01/1991"
        End If
        If objEquipamento.DDataValidadeGarantia = Nothing Then
            objEquipamento.DataValidadeGarantia = "31/12/2099"
        End If
        objEquipamento.CodItem = TxtCodItem.Text
        Return objEquipamento
    End Function

    Private Function IsDigitacaoOK() As Boolean
        LblErro.Text = ""

        Return LblErro.Text = ""
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            If Gravar() Then
                Session("SAlterouNumeroSerieItemPedido") = 1
                Session("SNumeroSerieItemPedido") = LblNrSerie.Text
                MultiView1.ActiveViewIndex = 2
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Try
            Dim objEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            LblNrSerie.Text = objEquipamento.GetProximoCodigo()
            LblNrSerieComponente.Text = LblNrSerie.Text
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNSU()
        Try
            Dim objEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objTipoPontoAtendimento As New UCLTipoPontoAtendimento
            Dim nsu As String
            Dim codEmitente As String

            If Session("SCodEmitenteAtNegociacao") Is Nothing Then
                codEmitente = ""
            Else
                codEmitente = Session("SCodEmitenteAtNegociacao")
            End If
            If Session("SCodEmitenteNegociacao") Is Nothing Then
                codEmitente = ""
            Else
                codEmitente = Session("SCodEmitenteNegociacao")
            End If
            objPontoAtendimento.CodEmitente = codEmitente
            If Session("SPontoAtendimento") Is Nothing Then
                objPontoAtendimento.NumeroPontoAtendimento = ""
            Else
                objPontoAtendimento.NumeroPontoAtendimento = Session("SPontoAtendimento")
            End If
            If Not String.IsNullOrWhiteSpace(objPontoAtendimento.CodEmitente) And Not String.IsNullOrWhiteSpace(objPontoAtendimento.NumeroPontoAtendimento) Then
                objPontoAtendimento.Buscar()

                If Not String.IsNullOrWhiteSpace(objPontoAtendimento.CodTipoPontoAtendimento) Then
                    objTipoPontoAtendimento.CodTipoPontoAtendimento = objPontoAtendimento.CodTipoPontoAtendimento
                    objTipoPontoAtendimento.Buscar()

                    If objTipoPontoAtendimento.SequencialAutomatico = "S" Then
                        nsu = objEquipamento.GetNSU(Session("GlEmpresa"), True, 1)
                        TxtRegPatrimonial.Text = nsu
                    End If
                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '---------------

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "SELECIONAR" Then
            If Session("SViewOrigem") = 2 Then
                TxtCodItemComponente.Text = e.CommandArgument
                TxtCodItemComponente.DataBind()
                Call MostraDescricaoItemComponente()
            ElseIf Session("SViewOrigem") = 0 Then
                TxtCodItem.Text = e.CommandArgument
                TxtCodItem.DataBind()
                Call MostraDescricaoItem()
            End If
            MultiView1.ActiveViewIndex = Session("SViewOrigem")
        End If
    End Sub

    Protected Sub TxtFornecedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNome.TextChanged
        TxtNome.Text = TxtNome.Text
    End Sub

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFiltrar.Click
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub

    Protected Sub BtnVoltarParaEquipamento_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltarParaEquipamento.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    '-----------------

    Protected Sub BtnConcluir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnConcluir.Click
        Try
            If GetModoAberturaJanela() = ModoJanela.AberturaPorOutraTela Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
            Else
                Response.Redirect("WGClienteEquipamento.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub BtnIncluirComponente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnIncluirComponente.Click
        Try
            Dim objEquipamentoComponente As New UCLEquipamentoComponente(StrConexaoUsuario(Session("GlUsuario")))
            LblErro.Text = ""

            If String.IsNullOrEmpty(TxtCodItemComponente.Text) Then
                LblErro.Text += "Preencha o campo item.<br/>"
            End If

            objEquipamentoComponente.Empresa = Session("GlEmpresa")
            objEquipamentoComponente.NumeroSerie = LblNrSerie.Text
            objEquipamentoComponente.SeqComponente = objEquipamentoComponente.GetProximoCodigo()
            objEquipamentoComponente.CodItem = TxtCodItemComponente.Text
            objEquipamentoComponente.Observacao = TxtObservacaoComponente.Text.GetValidInputContent
            objEquipamentoComponente.Quantidade = TxtQuantidadeComponente.Text
            objEquipamentoComponente.Incluir()

            SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            SqlDataSource2.DataBind()
            GridView2.DataBind()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim objEquipamentoComponente As New UCLEquipamentoComponente(StrConexaoUsuario(Session("GlUsuario")))

            objEquipamentoComponente.Empresa = Session("GlEmpresa")
            objEquipamentoComponente.NumeroSerie = LblNrSerie.Text
            objEquipamentoComponente.SeqComponente = e.CommandArgument
            objEquipamentoComponente.Excluir()

            SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            SqlDataSource2.DataBind()
            GridView2.DataBind()
        End If
    End Sub

    Protected Sub BtnFiltrarItem0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnFiltrarItem0.Click
        MultiView1.ActiveViewIndex = 1
        Session("SViewOrigem") = 2
    End Sub

    Private Sub MostraDescricaoItemComponente()
        Try
            Dim objItem As New UCLItem
            If Not String.IsNullOrEmpty(TxtCodItemComponente.Text) Then
                objItem.CodItem = TxtCodItemComponente.Text
                objItem.Buscar()
                LblDescricaoItemComponente.Text = objItem.Descricao
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtCodItemComponente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCodItemComponente.TextChanged
        Call MostraDescricaoItemComponente()
    End Sub

    Protected Sub BtnVoltarGeral_Click(sender As Object, e As EventArgs) Handles BtnVoltarGeral.Click
        Response.Redirect("WGClienteEquipamento.aspx")
    End Sub

    Protected Sub AjustaVisibilidadeBotoes(modo As ModoJanela)
        If modo = ModoJanela.AberturaPeloCadastroDelaMesma Then
            btnCancel.Visible = False
            BtnVoltarGeral.Visible = True
            GridView1.Width = New System.Web.UI.WebControls.Unit(100, UnitType.Percentage)
            GridView2.Width = New System.Web.UI.WebControls.Unit(100, UnitType.Percentage)
        Else
            btnCancel.Visible = True
            BtnVoltarGeral.Visible = False
        End If
    End Sub

    Public Enum ModoJanela As Integer
        AberturaPeloCadastroDelaMesma = 1
        AberturaPorOutraTela = 2
    End Enum

    Private Function GetModoAberturaJanela() As ModoJanela
        If Session("SModoCadEquipamento") Is Nothing Then
            Return ModoJanela.AberturaPorOutraTela
        End If
        If String.IsNullOrEmpty(Session("SModoCadEquipamento")) Then
            Return ModoJanela.AberturaPorOutraTela
        End If
        If Not IsNumeric(Session("SModoCadEquipamento")) Then
            Return ModoJanela.AberturaPorOutraTela
        End If
        Select Case Session("SModoCadEquipamento")
            Case ModoJanela.AberturaPorOutraTela, ModoJanela.AberturaPeloCadastroDelaMesma
                Return Session("SModoCadEquipamento")
            Case Else
                Return ModoJanela.AberturaPorOutraTela
        End Select
    End Function

    Private Sub MostraDescricaoItem()
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

    Protected Sub TxtCodItem_TextChanged(sender As Object, e As EventArgs) Handles TxtCodItem.TextChanged
        Call MostraDescricaoItem()
    End Sub

    Protected Sub BtnFiltrarItem1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnFiltrarItem1.Click
        MultiView1.ActiveViewIndex = 1
        Session("SViewOrigem") = 0
    End Sub
End Class