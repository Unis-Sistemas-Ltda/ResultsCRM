Partial Public Class WUCNegociacaoItem_Farmacos2
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodNegociacao As String
    Private _SeqItem As String

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

    Public Property SeqItem() As String
        Get
            Return _SeqItem
        End Get
        Set(ByVal value As String)
            _SeqItem = value
        End Set
    End Property

    Private ReadOnly Property QuantidadeUD() As Double
        Get
            If String.IsNullOrEmpty(TxtQuantidadeUD.Text) Then
                Return 0.0
            Else
                If IsNumeric(TxtQuantidadeUD.Text) Then
                    Return CDbl(TxtQuantidadeUD.Text)
                Else
                    Return 0.0
                End If
            End If
        End Get
    End Property

    Private ReadOnly Property Quantidade() As Double
        Get
            If String.IsNullOrEmpty(TxtQuantidade.Text) Then
                Return 0.0
            Else
                If IsNumeric(TxtQuantidade.Text) Then
                    Return CDbl(TxtQuantidade.Text)
                Else
                    Return 0.0
                End If
            End If
        End Get
    End Property

    Private ReadOnly Property PercDesconto() As Double
        Get
            If String.IsNullOrEmpty(TxtPercDesconto.Text) Then
                Return 0.0
            Else
                If IsNumeric(TxtPercDesconto.Text) Then
                    Return CDbl(TxtPercDesconto.Text)
                Else
                    Return 0.0
                End If
            End If
        End Get
    End Property

    Private ReadOnly Property ValorDesconto() As Double
        Get
            If String.IsNullOrEmpty(TxtValorDesconto.Text) Then
                Return 0.0
            Else
                If IsNumeric(TxtValorDesconto.Text) Then
                    Return CDbl(TxtValorDesconto.Text)
                Else
                    Return 0.0
                End If
            End If
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objNatureza As New UCLNaturezaOperacao

            TxtQuantidade.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")
            TxtQuantidade.Attributes.Add("OnBlur", "submit();")
            TxtQuantidade.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtQuantidadeUD.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")
            TxtQuantidadeUD.Attributes.Add("OnBlur", "submit();")
            TxtQuantidadeUD.Attributes.Add("OnFocus", "selecionaCampo(this)")
            'TxtPrecoUnitarioTabela.Attributes.Add("OnKeyPress", "mascara( this, mvalor4dec );return true;")
            TxtPrecoUnitarioTabela.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtPrecoUnitarioTabela.Attributes.Add("OnBlur", "submit();")
            TxtValorDesconto.Attributes.Add("OnKeyPress", "mascara( this, mvalor );return true;")
            TxtValorDesconto.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtValorDesconto.Attributes.Add("OnBlur", "submit();")
            TxtDescCom1.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtDescCom2.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtDescCom3.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtDescCom4.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtDescCom5.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtPercDesconto.Attributes.Add("OnFocus", "selecionaCampo(this)")
            If Not IsPostBack Then
                objNatureza.FillDropDown(DdlNaturOper, True, "")
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                Else
                    Call NovoRegistro()
                End If
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

            Call CarregaDescricaoItem()
            Call CalculaValorUnitario()
            Call CalculaTotais()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub NovoRegistro()
        Try
            Call CarregaNovaPK()
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            Dim objCond As New UCLCondicaoPagamento
            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
            objNegociacao.CodNegociacao = CodNegociacao
            objNegociacao.Buscar()
            DdlNaturOper.SelectedValue = objNegociacao.CodNaturOper
            objCond.Codigo = objNegociacao.CodCondPagto
            objCond.Buscar()
            TxtPercDesconto.Text = objCond.PercDescontoPadrao

            If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
                LblRecurso.Visible = False
                LblLabelRSRecurso.Visible = False
                LblLabelRecurso.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CodItemMudou()
        Try
            Dim objItem As New UCLItem
            Dim CodTabelaPreco As Long
            Dim Desc1, Desc2, Desc3, Desc4, Desc5 As Double
            Dim CodUD As String
            Call CarregaDescricaoItem()

            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                TxtPrecoUnitarioTabela.Text = objItem.PrecoItemCliente(Session("GlEmpresa"), Session("SEstabelecimentoNegociacao"), LblCodEmitente.Text, LblCNPJ.Text, TxtCodItem.Text, "", "").ToString("F4")
                CodTabelaPreco = objItem.F_BuscaTabelaPrecoVenda(Session("GlEmpresa"), LblCodEmitente.Text, LblCNPJ.Text)

                Desc1 = 0
                Desc2 = 0
                Desc3 = 0
                Desc4 = 0
                Desc5 = 0

                Call objItem.BuscaDescontosComerciaisUnitarios(Session("GlEmpresa"), Session("SEstabelecimentoNegociacao"), CodTabelaPreco, TxtCodItem.Text, Desc1, Desc2, Desc3, Desc4, Desc5)

                TxtDescCom1.Text = Desc1.ToString("F2")
                TxtDescCom2.Text = Desc2.ToString("F2")
                TxtDescCom3.Text = Desc3.ToString("F2")
                TxtDescCom4.Text = Desc4.ToString("F2")
                TxtDescCom5.Text = Desc5.ToString("F2")

                TxtValorDesconto.Text = 0
                TxtNarrativa.Text = objItem.GetNarrativa(TxtCodItem.Text)

                Session("SCodItemPesquisado") = TxtCodItem.Text
                objItem.CodItem = TxtCodItem.Text
                objItem.Buscar()
                CodUD = objItem.CodUd
                LblDescricaoUD.Text = objItem.GetDescricaoUnidadeDespacho(CodUD)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtCodItem_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCodItem.TextChanged
        Try
            Call CodItemMudou()
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

    Private Function IsDigitacaoOK()
        If String.IsNullOrEmpty(TxtCodItem.Text) Then
            LblErro.Text += "Preencha o campo Item.<br/>"
        End If

        If Quantidade = 0 Then
            LblErro.Text += "Preencha corretamente o campo Quantidade.<br/>"
        End If

        If QuantidadeUD = 0 Then
            LblErro.Text += "Preencha corretamente o campo Quantidade UD.<br/>"
        End If

        If String.IsNullOrEmpty(LblPrecoUnitario.Text) Then
            LblPrecoUnitario.Text = "0,00"
        End If

        If LblValorTotal.Text <= 0 Then
            LblErro.Text += "O total do item deve ser maior que R$ 0,00.<br/>"
        End If

        If DdlNaturOper.SelectedValue = 0 Then
            LblErro.Text += "Informe a natureza de operação.<br/>"
        End If

        If IsNumeric(LblICMSST.Text) AndAlso LblICMSST.Text < 0 Then
            LblErro.Text += "O valor de ICMS ST não pode ser inferior a R$ 0,00.<br/>"
        End If

        Return LblErro.Text = ""
    End Function

    Private Function CarregaObjeto(ByRef objNegociacaoItem As UCLNegociacaoItem) As UCLNegociacaoItem

        objNegociacaoItem.CodItem = TxtCodItem.Text.GetValidInputContent
        objNegociacaoItem.Quantidade = Quantidade
        objNegociacaoItem.QuantidadeUD = QuantidadeUD
        objNegociacaoItem.PrecoUnitario = LblPrecoUnitario.Text
        objNegociacaoItem.PrecoUnitarioUD = LblValorUD.Text
        objNegociacaoItem.CodUnidade = LblUD.Text
        objNegociacaoItem.Narrativa = TxtNarrativa.Text.GetValidInputContent
        objNegociacaoItem.AliquotaIPI = LblAliquotaIPI.Text
        objNegociacaoItem.AliquotaICMS = LblAliquotaICMS.Text
        objNegociacaoItem.BaseICMSSubstituicao = LblBaseIcmsSubstituicao.Text
        objNegociacaoItem.ICMSST = LblICMSST.Text
        objNegociacaoItem.IPI = LblIPI.Text
        objNegociacaoItem.ValorTotal = LblValorTotal.Text
        objNegociacaoItem.CodNaturOper = DdlNaturOper.SelectedValue
        objNegociacaoItem.ICMS = LblICMS.Text
        objNegociacaoItem.ValorDesconto = TxtValorDesconto.Text
        objNegociacaoItem.ValorMercadoria = LblValorMercadoria.Text
        objNegociacaoItem.PercDescontoUnitario1 = TxtDescCom1.Text
        objNegociacaoItem.PercDescontoUnitario2 = TxtDescCom2.Text
        objNegociacaoItem.PercDescontoUnitario3 = TxtDescCom3.Text
        objNegociacaoItem.PercDescontoUnitario4 = TxtDescCom4.Text
        objNegociacaoItem.PercDescontoUnitario5 = TxtDescCom5.Text
        objNegociacaoItem.Recurso = LblRecurso.Text
        objNegociacaoItem.PrecoUnitarioTabela = TxtPrecoUnitarioTabela.Text
        objNegociacaoItem.FdAcaoDesejadaFuncao = TxtFdAcaoDesejadaProduto.Text
        If DdlFdColoracao.SelectedValue > 0 Then
            objNegociacaoItem.FdColoracao = DdlFdColoracao.SelectedValue
        End If
        If DdlFdOdor.SelectedValue > 0 Then
            objNegociacaoItem.FdOdor = DdlFdOdor.SelectedValue
        End If
        If DdlFdOdorDirecionamento.SelectedValue > 0 Then
            objNegociacaoItem.FdOdorDirecionamento = DdlFdOdorDirecionamento.SelectedValue
        End If
        objNegociacaoItem.FdCorReferencia = TxtFdCorReferencia.Text
        objNegociacaoItem.FdDescricaoProduto = TxtFdDescricaoProduto.Text
        objNegociacaoItem.FdNomeProduto = TxtFdNomeProduto.Text
        objNegociacaoItem.FdOdorReferencia = TxtFdOdorReferencia.Text
        Return objNegociacaoItem
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        Try
            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objNegociacaoItem.CodNegociacao = CodNegociacao
                    objNegociacaoItem.SeqItem = SeqItem
                    objNegociacaoItem.Empresa = Session("GlEmpresa")
                    objNegociacaoItem.Estabelecimento = Session("SEstabelecimentoNegociacao")
                    objNegociacaoItem.Buscar()
                    objNegociacaoItem = CarregaObjeto(objNegociacaoItem)
                    objNegociacaoItem.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objNegociacaoItem.CodNegociacao = CodNegociacao
                    objNegociacaoItem.SeqItem = LblSeqItem.Text
                    objNegociacaoItem.Empresa = Session("GlEmpresa")
                    objNegociacaoItem.Estabelecimento = Session("SEstabelecimentoNegociacao")
                    objNegociacaoItem.Buscar()
                    objNegociacaoItem = CarregaObjeto(objNegociacaoItem)
                    objNegociacaoItem.Incluir()
                End If

                Response.Redirect("WGNegociacaoItem.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub CalculaTotais()
        Dim objCalculoImposto As New UCLCalculoImposto
        Dim retorno As String

        If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
            objCalculoImposto.Empresa = Session("GlEmpresa")
            objCalculoImposto.Estabelecimento = Session("SEstabelecimentoNegociacao")
            objCalculoImposto.CodItem = TxtCodItem.Text
            objCalculoImposto.Quantidade = Quantidade
            objCalculoImposto.QuantidadeUD = QuantidadeUD
            objCalculoImposto.PrecoUnitario = CDbl(LblPrecoUnitario.Text)
            objCalculoImposto.PrecoUnitarioUD = CDbl(LblValorUD.Text)
            objCalculoImposto.PercentualDesconto = PercDesconto
            objCalculoImposto.ValorDesconto = ValorDesconto
            objCalculoImposto.CodEmitente = LblCodEmitente.Text
            objCalculoImposto.CNPJ = LblCNPJ.Text
            objCalculoImposto.CodNaturOper = DdlNaturOper.SelectedValue
            retorno = objCalculoImposto.CalculaTotais()
            LblErro.Text = retorno
            LblValorMercadoria.Text = objCalculoImposto.ValorMercadoria.ToString("F2")
            LblValorTotal.Text = objCalculoImposto.ValorTotalMercadoria.ToString("F2")
            If retorno = "" Then
                LblBaseIcmsSubstituicao.Text = objCalculoImposto.BaseIcmsSubstituicao.ToString("F4")
                LblICMSST.Text = objCalculoImposto.IcmsSubstituicao.ToString("F4")
                LblIPI.Text = objCalculoImposto.ValorIPI.ToString("F4")
                LblICMS.Text = objCalculoImposto.ValorICMS.ToString("F4")
                LblAliquotaICMS.Text = objCalculoImposto.AliquotaICMS.ToString
                LblAliquotaIPI.Text = objCalculoImposto.AliquotaIPI.ToString
                LblValorUD.Text = objCalculoImposto.PrecoUnitarioUD.ToString("F4")
                LblRecurso.Text = objCalculoImposto.Recurso.ToString("F4")
            Else
                LblErro.Text += " Por esse motivo, os valores abaixo podem não ser calculados corretamente."
            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("WGNegociacaoItem.aspx")
    End Sub

    Protected Sub CarregaFormulario()
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        Dim objItem As New UCLItem
        Dim CodUD As String
        objNegociacaoItem.Empresa = Session("GlEmpresa")
        objNegociacaoItem.Estabelecimento = Session("SEstabelecimentoNegociacao")
        objNegociacaoItem.CodNegociacao = CodNegociacao
        objNegociacaoItem.SeqItem = SeqItem
        objNegociacaoItem.Buscar()
        LblSeqItem.Text = objNegociacaoItem.SeqItem
        TxtCodItem.Text = objNegociacaoItem.CodItem
        LblUD.Text = objNegociacaoItem.CodUnidade
        LblPrecoUnitario.Text = objNegociacaoItem.PrecoUnitario
        LblValorUD.Text = objNegociacaoItem.PrecoUnitarioUD
        TxtQuantidade.Text = objNegociacaoItem.Quantidade
        TxtQuantidadeUD.Text = objNegociacaoItem.QuantidadeUD
        LblValorTotal.Text = objNegociacaoItem.ValorTotal
        LblICMSST.Text = objNegociacaoItem.ICMSST
        LblIPI.Text = objNegociacaoItem.IPI
        TxtNarrativa.Text = objNegociacaoItem.Narrativa
        TxtValorDesconto.Text = objNegociacaoItem.ValorDesconto
        LblICMS.Text = objNegociacaoItem.ICMS
        LblValorMercadoria.Text = objNegociacaoItem.ValorMercadoria
        DdlNaturOper.SelectedValue = objNegociacaoItem.CodNaturOper
        LblCNPJ.Text = objNegociacaoItem.CNPJCliente
        LblCodEmitente.Text = objNegociacaoItem.CodCliente
        TxtDescCom1.Text = objNegociacaoItem.PercDescontoUnitario1
        TxtDescCom2.Text = objNegociacaoItem.PercDescontoUnitario2
        TxtDescCom3.Text = objNegociacaoItem.PercDescontoUnitario3
        TxtDescCom4.Text = objNegociacaoItem.PercDescontoUnitario4
        TxtDescCom5.Text = objNegociacaoItem.PercDescontoUnitario5
        LblRecurso.Text = objNegociacaoItem.Recurso
        TxtPrecoUnitarioTabela.Text = objNegociacaoItem.PrecoUnitarioTabela
        objItem.CodItem = TxtCodItem.Text
        objItem.Buscar()
        CodUD = objItem.CodUd
        LblDescricaoUD.Text = objItem.GetDescricaoUnidadeDespacho(CodUD)
        DdlFdColoracao.SelectedValue = objNegociacaoItem.FdColoracao
        DdlFdOdor.SelectedValue = objNegociacaoItem.FdOdor
        DdlFdOdorDirecionamento.SelectedValue = objNegociacaoItem.FdOdorDirecionamento
        TxtFdAcaoDesejadaProduto.Text = objNegociacaoItem.FdAcaoDesejadaFuncao
        TxtFdCorReferencia.Text = objNegociacaoItem.FdCorReferencia
        TxtFdDescricaoProduto.Text = objNegociacaoItem.FdDescricaoProduto
        TxtFdNomeProduto.Text = objNegociacaoItem.FdNomeProduto
        TxtFdOdorReferencia.Text = objNegociacaoItem.FdOdorReferencia

        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
            LblRecurso.Visible = False
            LblLabelRSRecurso.Visible = False
            LblLabelRecurso.Visible = False
        End If
    End Sub

    Private Sub CarregaNovaPK()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        objNegociacaoItem.Empresa = Session("GlEmpresa")
        objNegociacaoItem.Estabelecimento = Session("SEstabelecimentoNegociacao")
        objNegociacaoItem.CodNegociacao = CodNegociacao
        LblSeqItem.Text = objNegociacaoItem.GetProximoCodigo

        objNegociacao.Empresa = Session("GlEmpresa")
        objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
        objNegociacao.CodNegociacao = CodNegociacao
        objNegociacao.Buscar()
        LblCodEmitente.Text = objNegociacao.CodCliente
        LblCNPJ.Text = objNegociacao.CNPJ
    End Sub

    Protected Sub TxtQuantidade_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtQuantidade.TextChanged
        TxtQuantidadeUD.Text = CalculaQuantidade_Unidade_UD(Quantidade, QuantidadeUD, TipoQuantidadeCalcular.QtdUD, TxtCodItem.Text, "").ToString("F4")
        TxtQuantidadeUD.DataBind()
        Call CalculaValorUnitario()
        Call CalculaTotais()
    End Sub

    Protected Sub TxtQuantidadeUD_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtQuantidadeUD.TextChanged
        TxtQuantidade.Text = CalculaQuantidade_Unidade_UD(Quantidade, QuantidadeUD, TipoQuantidadeCalcular.QtdPedida, TxtCodItem.Text, "").ToString("F4")
        TxtQuantidade.DataBind()
        Call CalculaValorUnitario()
        Call CalculaTotais()
    End Sub

    Public Sub CalculaValorUnitario()
        Try
            Dim percDesc As Decimal
            Dim precoUnitarioTabela As Decimal
            Dim precoUnitarioFinal As Decimal

            If Not IsNumeric(TxtPrecoUnitarioTabela.Text) Then
                Return
            End If

            precoUnitarioTabela = CDbl(TxtPrecoUnitarioTabela.Text)
            precoUnitarioFinal = precoUnitarioTabela

            For i As Integer = 1 To 5
                Select Case i
                    Case 1
                        If IsNumeric(TxtDescCom1.Text) Then
                            percDesc = CDbl(TxtDescCom1.Text)
                        Else
                            percDesc = 0
                        End If
                    Case 2
                        If IsNumeric(TxtDescCom2.Text) Then
                            percDesc = CDbl(TxtDescCom2.Text)
                        Else
                            percDesc = 0
                        End If
                    Case 3
                        If IsNumeric(TxtDescCom3.Text) Then
                            percDesc = CDbl(TxtDescCom3.Text)
                        Else
                            percDesc = 0
                        End If
                    Case 4
                        If IsNumeric(TxtDescCom4.Text) Then
                            percDesc = CDbl(TxtDescCom4.Text)
                        Else
                            percDesc = 0
                        End If
                    Case 5
                        If IsNumeric(TxtDescCom5.Text) Then
                            percDesc = CDbl(TxtDescCom5.Text)
                        Else
                            percDesc = 0
                        End If
                End Select

                precoUnitarioFinal = precoUnitarioFinal - (precoUnitarioFinal * percDesc / 100)
            Next

            LblPrecoUnitario.Text = precoUnitarioFinal.ToString("F4")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtDescCom1_TextChanged(sender As Object, e As EventArgs) Handles TxtDescCom1.TextChanged
        Call CalculaValorUnitario()
        Call CalculaTotais()
    End Sub

    Protected Sub TxtDescCom2_TextChanged(sender As Object, e As EventArgs) Handles TxtDescCom2.TextChanged
        Call CalculaValorUnitario()
        Call CalculaTotais()
    End Sub

    Protected Sub TxtDescCom3_TextChanged(sender As Object, e As EventArgs) Handles TxtDescCom3.TextChanged
        Call CalculaValorUnitario()
        Call CalculaTotais()
    End Sub

    Protected Sub TxtDescCom4_TextChanged(sender As Object, e As EventArgs) Handles TxtDescCom4.TextChanged
        Call CalculaValorUnitario()
        Call CalculaTotais()
    End Sub

    Protected Sub TxtDescCom5_TextChanged(sender As Object, e As EventArgs) Handles TxtDescCom5.TextChanged
        Call CalculaValorUnitario()
        Call CalculaTotais()
    End Sub

    Protected Sub TxtPrecoUnitarioTabela_TextChanged(sender As Object, e As EventArgs) Handles TxtPrecoUnitarioTabela.TextChanged
        Call CalculaValorUnitario()
        Call CalculaTotais()
    End Sub

    Protected Sub TxtValorDesconto_TextChanged(sender As Object, e As EventArgs) Handles TxtValorDesconto.TextChanged
        Call CalculaValorUnitario()
        Call CalculaTotais()
    End Sub
End Class