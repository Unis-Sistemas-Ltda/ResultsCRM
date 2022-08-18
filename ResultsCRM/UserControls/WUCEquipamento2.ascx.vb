Partial Public Class WUCEquipamento2
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
                LblCodEquipamentoLbl.Text = "Produto"
            End If

            MultiView1.ActiveViewIndex = 0

            LblCodCliente.Text = CodCliente
            LblCNPJ.Text = CNPJ.MascaraCNPJ

            Call MostraNomeCliente()
            Call CarregaEstabelecimentos()

            If Acao = "ALTERAR" Then
                TxtNumeroSerie.Text = NumeroSerie
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Dim objEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))

                objEquipamento.Empresa = Session("GlEmpresa")
                objEquipamento.NumeroSerie = TxtNumeroSerie.Text
                If objEquipamento.Buscar() Then
                    TxtNumeroSerie.Text = NumeroSerie
                    Call CarregaFormulario()
                Else
                    CBxAtivo.Checked = True
                    CBxAtivo.Enabled = False
                    If objEquipamento.GerarNumeroSerieAutomatico(Session("GlEmpresa")) Then
                        CarregaNovaPK()
                        TxtNumeroSerie.Enabled = False
                    Else
                        TxtNumeroSerie.Enabled = True
                    End If
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

    Private Sub CarregaReferencias()
        Try
            Dim ObjItemReferencia As New UCLItemReferencia(StrConexao)
            ObjItemReferencia.CodItem = TxtCodItem.Text
            ObjItemReferencia.FillDropDown(DdlReferencia, False, "")

            If DdlReferencia.Items.Count = 0 Then
                ObjItemReferencia.FillDropDown(DdlReferencia, True, "")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim ObjEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            ObjEquipamento.Empresa = Session("GlEmpresa")
            ObjEquipamento.NumeroSerie = NumeroSerie
            ObjEquipamento.Buscar()

            TxtNumeroSerie.Enabled = False
            CBxAtivo.Checked = ObjEquipamento.Ativo.Replace("S", "True").Replace("N", "False")
            DdlEstabelecimentoNFS.SelectedValue = ObjEquipamento.EstabelecimentoNFS
            TxtObservacao.Text = ObjEquipamento.Observacao
            TxtCodItem.Text = ObjEquipamento.CodItem
            TxtSerie.Text = ObjEquipamento.Serie
            TxtNF.Text = ObjEquipamento.CodNFS
            TxtOP.Text = ObjEquipamento.CodOP
            Call MostraDescricaoItem()
            Call CarregaReferencias()
            If DdlReferencia.Items.FindByValue(ObjEquipamento.Referencia) IsNot Nothing Then
                DdlReferencia.SelectedValue = ObjEquipamento.Referencia
            Else
                DdlReferencia.SelectedValue = " "
            End If
            TxtLote.Text = ObjEquipamento.Lote
            TxtReferenciaGarantia.Text = ObjEquipamento.DataReferenciaGarantia
            TxtValidadeGarantia.Text = ObjEquipamento.DataValidadeGarantia
            TxtUltimaPreventiva.Text = ObjEquipamento.DataUltimaPreventiva
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MostraNomeCliente()
        Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
        If Not String.IsNullOrEmpty(CodCliente) AndAlso Not String.IsNullOrWhiteSpace(NumeroPontoAtendimento) Then
            objPontoAtendimento.CodEmitente = CodCliente
            objPontoAtendimento.NumeroPontoAtendimento = NumeroPontoAtendimento
            objPontoAtendimento.Buscar()

            LblDescricaoPontoAtendimento.Text = objPontoAtendimento.NumeroPontoAtendimento + " ─ " + objPontoAtendimento.Descricao
        End If
    End Sub

    Public Function Gravar() As Boolean
        Try
            Dim objEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))

            If IsDigitacaoOK() Then
                If Acao = "INCLUIR" Then
                    objEquipamento.Empresa = Session("GlEmpresa")
                    objEquipamento.NumeroSerie = TxtNumeroSerie.Text
                    If objEquipamento.Buscar() Then
                        objEquipamento.Empresa = Session("GlEmpresa")
                        objEquipamento.NumeroSerie = NumeroSerie
                        objEquipamento.Buscar()
                        objEquipamento = CarregaObjeto(objEquipamento)
                        objEquipamento.Alterar()
                        Return True
                    Else
                        If objEquipamento.GerarNumeroSerieAutomatico(Session("GlEmpresa")) Then
                            CarregaNovaPK()
                            TxtNumeroSerie.Enabled = False
                        End If
                        objEquipamento.Empresa = Session("GlEmpresa")
                        objEquipamento.NumeroSerie = TxtNumeroSerie.Text
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
        objEquipamento.NumeroRegistroPatrimonio = ""
        objEquipamento.CodCliente = CodCliente
        objEquipamento.CNPJ = CNPJ
        objEquipamento.NumeroPontoAtendimento = NumeroPontoAtendimento
        objEquipamento.EstabelecimentoNFS = DdlEstabelecimentoNFS.SelectedValue
        objEquipamento.CodItem = TxtCodItem.Text.GetValidInputContent
        objEquipamento.Referencia = DdlReferencia.SelectedValue
        objEquipamento.Lote = TxtLote.Text.GetValidInputContent
        objEquipamento.Observacao = TxtObservacao.Text.GetValidInputContent
        objEquipamento.CodNFS = TxtNF.Text.GetValidInputContent
        objEquipamento.Serie = TxtSerie.Text.GetValidInputContent
        objEquipamento.CodOP = TxtOP.Text.GetValidInputContent
        objEquipamento.DataReferenciaGarantia = TxtReferenciaGarantia.Text
        objEquipamento.DataValidadeGarantia = TxtValidadeGarantia.Text
        objEquipamento.DataUltimaPreventiva = TxtUltimaPreventiva.Text

        If String.IsNullOrEmpty(objEquipamento.DataReferenciaGarantia) Then
            objEquipamento.DataReferenciaGarantia = Today().ToString("dd/MM/yyyy")
        End If

        If String.IsNullOrEmpty(objEquipamento.DataValidadeGarantia) Then
            objEquipamento.DataValidadeGarantia = "31/12/2999"
        End If

        Return objEquipamento
    End Function

    Private Function IsDigitacaoOK() As Boolean
        LblErro.Text = ""

        If Not String.IsNullOrEmpty(TxtReferenciaGarantia.Text) AndAlso Not isValidDate(TxtReferenciaGarantia.Text) Then
            LblErro.Text += "Informe corretamente a data de referência da garantia ou deixe o campo em branco.<br>"
        End If

        If Not String.IsNullOrEmpty(TxtValidadeGarantia.Text) AndAlso Not isValidDate(TxtValidadeGarantia.Text) Then
            LblErro.Text += "Informe corretamente a data de validade da garantia ou deixe o campo em branco.<br>"
        End If

        If Not String.IsNullOrEmpty(TxtUltimaPreventiva.Text) AndAlso Not isValidDate(TxtUltimaPreventiva.Text) Then
            LblErro.Text += "Informe corretamente a data da última preventiva ou deixe o campo em branco.<br>"
        End If

        Return LblErro.Text = ""
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            If Gravar() Then
                Session("SAlterouNumeroSerieItemPedido") = 1
                Session("SNumeroSerieItemPedido") = TxtNumeroSerie.Text

                If GetModoAberturaJanela() = ModoJanela.AberturaPorOutraTela Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
                Else
                    Response.Redirect("WGClienteEquipamento.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Try
            Dim objEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            TxtNumeroSerie.Text = objEquipamento.GetProximoCodigo()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '---------------

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "SELECIONAR" Then
            If Session("SViewOrigem") = 0 Then
                TxtCodItem.Text = e.CommandArgument
                TxtCodItem.DataBind()
                Call MostraDescricaoItem()
                Call CarregaReferencias()
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

    Protected Sub BtnFiltrarItem0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnFiltrarItem0.Click
        MultiView1.ActiveViewIndex = 1
        Session("SViewOrigem") = 0
    End Sub

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

    Protected Sub TxtCodItemComponente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCodItem.TextChanged
        Call MostraDescricaoItem()
        Call CarregaReferencias()
    End Sub

    Protected Sub BtnVoltarGeral_Click(sender As Object, e As EventArgs) Handles BtnVoltarGeral.Click
        Response.Redirect("WGClienteEquipamento.aspx")
    End Sub

    Protected Sub AjustaVisibilidadeBotoes(modo As ModoJanela)
        If modo = ModoJanela.AberturaPeloCadastroDelaMesma Then
            btnCancel.Visible = False
            BtnVoltarGeral.Visible = True
            GridView1.Width = New System.Web.UI.WebControls.Unit(100, UnitType.Percentage)
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

End Class