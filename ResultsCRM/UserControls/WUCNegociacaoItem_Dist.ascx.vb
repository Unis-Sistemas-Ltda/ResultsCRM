Partial Public Class WUCNegociacaoItem_Dist
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

    Private ReadOnly Property ConteudoQuantidadeUD() As Double
        Get
            If String.IsNullOrEmpty(LblQtdUD.Text) Then
                Return 0.0
            Else
                If IsNumeric(LblQtdUD.Text) Then
                    Return CDbl(LblQtdUD.Text)
                Else
                    Return 0.0
                End If
            End If
        End Get
    End Property

    Private ReadOnly Property ConteudoQuantidade() As Double
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

    Private ReadOnly Property ConteudoValorDesconto() As Double
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

    Private ReadOnly Property ConteudoPercDescontoUnitario() As Double
        Get
            If String.IsNullOrEmpty(TxtPercDescontoUnitario.Text) Then
                Return 0.0
            Else
                If IsNumeric(TxtPercDescontoUnitario.Text) Then
                    Return CDbl(TxtPercDescontoUnitario.Text)
                Else
                    Return 0.0
                End If
            End If
        End Get
    End Property

    Private ReadOnly Property ConteudoPercAcrescimoUnitario() As Double
        Get
            If String.IsNullOrEmpty(TxtPercAcrescimoUnitario.Text) Then
                Return 0.0
            Else
                If IsNumeric(TxtPercAcrescimoUnitario.Text) Then
                    Return CDbl(TxtPercAcrescimoUnitario.Text)
                Else
                    Return 0.0
                End If
            End If
        End Get
    End Property

    Private ReadOnly Property ConteudoPrecoUnitario() As Double
        Get
            If String.IsNullOrEmpty(TxtPrecoUnitario.Text) Then
                Return 0.0
            Else
                If IsNumeric(TxtPrecoUnitario.Text) Then
                    Return CDbl(TxtPrecoUnitario.Text)
                Else
                    Return 0.0
                End If
            End If
        End Get
    End Property

    Private ReadOnly Property ConteudoPrecoUnitarioTabela() As Double
        Get
            If String.IsNullOrEmpty(LblPrecoUnitarioTabela.Text) Then
                Return 0.0
            Else
                If IsNumeric(LblPrecoUnitarioTabela.Text) Then
                    Return CDbl(LblPrecoUnitarioTabela.Text)
                Else
                    Return 0.0
                End If
            End If
        End Get
    End Property

    Private ReadOnly Property ConteudoPercDesconto() As Double
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objNatureza As New UCLNaturezaOperacao

        TxtQuantidade.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")
        TxtQuantidade.Attributes.Add("OnBlur", "submit();")

        TxtPercDescontoUnitario.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")
        TxtPercAcrescimoUnitario.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")
        TxtPrecoUnitario.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")

        TxtPercDesconto.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")
        TxtValorDesconto.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")

        Try
            If Not IsPostBack Then
                objNatureza.FillDropDown(DdlNaturOper, True, "")
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                    BtnIncluirOpcional.Enabled = True
                Else
                    Call CarregaNovaPK()
                End If
                Call CarregaLabelsAuxiliares()
            End If

            If Not String.IsNullOrEmpty(Session("SCodItemPesquisado")) Then
                If Session("SNAlterouCodItem") Is Nothing Then
                    Session("SNAlterouCodItem") = 0
                End If
                If Not IsNumeric(Session("SNAlterouCodItem")) Then
                    Session("SNAlterouCodItem") = 0
                End If
                If Session("SAlterouCodItem") = "S" Then
                    If TxtCodItem.Text <> Session("SCodItemPesquisado") Then
                        TxtCodItem.Text = Session("SCodItemPesquisado")
                        Call CodItemMudou()
                    End If
                    If DdlReferencia.SelectedValue <> Session("SReferenciaPesquisada") Then
                        Dim objItemReferencia As New UCLItemReferencia(StrConexao)
                        objItemReferencia.CodItem = Session("SCodItemPesquisado")
                        objItemReferencia.Referencia = Session("SReferenciaPesquisada")
                        objItemReferencia.FillDropDown(DdlReferencia, True, "(selecione)")
                        DdlReferencia.SelectedValue = Session("SReferenciaPesquisada")
                    End If

                    Session("SNAlterouCodItem") = Session("SNAlterouCodItem") + 1

                    If Session("SNAlterouCodItem") > 1 Then
                        Session("SAlterouCodItem") = "N"
                        Session("SNAlterouCodItem") = 0
                    End If
                End If
            End If
            LblPrecoOpcionais.Text = GetTotalOpcionais().ToString("F4")
            Call CarregaDescricaoItem()
            Call CalculaTotais()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub CarregaUnidades()
        Dim objItem As New UCLItem
        objItem.FillDropDownUnidade(DdlUD, True, "", TxtCodItem.Text)
    End Sub

    Private Sub CodItemMudou()
        Dim objItem As New UCLItem
        Dim ObjNegociacao As New UCLNegociacao(StrConexao)

        Try
            Call CarregaDescricaoItem()

            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                LblPrecoUnitarioSemComponentes.Text = objItem.PrecoItemCliente(Session("GlEmpresa"), Session("GlEstabelecimento"), LblCodEmitente.Text, LblCNPJ.Text, TxtCodItem.Text, "", "").ToString("F4")
                LblPrecoUnitarioTabela.Text = objItem.PrecoItemCliente(Session("GlEmpresa"), Session("GlEstabelecimento"), LblCodEmitente.Text, LblCNPJ.Text, TxtCodItem.Text, "", "").ToString("F4")
                TxtPercDescontoUnitario.Text = "0,00"
                TxtPercAcrescimoUnitario.Text = "0,00"
                TxtPrecoUnitario.Text = objItem.PrecoItemCliente(Session("GlEmpresa"), Session("GlEstabelecimento"), LblCodEmitente.Text, LblCNPJ.Text, TxtCodItem.Text, "", "").ToString("F4")
                TxtValorDesconto.Text = 0
                TxtNarrativa.Text = objItem.GetNarrativa(TxtCodItem.Text)
                Call CarregaUnidades()
                Session("SCodItemPesquisado") = TxtCodItem.Text
                ObjNegociacao.Empresa = Session("GlEmpresa")
                ObjNegociacao.Estabelecimento = Session("GlEstabelecimento")
                ObjNegociacao.CodNegociacao = CodNegociacao
                ObjNegociacao.Buscar()
                If ObjNegociacao.CodNaturOper IsNot Nothing AndAlso DdlNaturOper.Items.FindByValue(ObjNegociacao.CodNaturOper) IsNot Nothing Then
                    DdlNaturOper.SelectedValue = ObjNegociacao.CodNaturOper
                End If

                Dim objItemReferencia As New UCLItemReferencia(StrConexao)
                objItemReferencia.CodItem = TxtCodItem.Text
                objItemReferencia.Referencia = ""
                objItemReferencia.FillDropDown(DdlReferencia, True, "(selecione)")
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

        If ConteudoQuantidade = 0 Then
            LblErro.Text += "Preencha corretamente o campo Quantidade.<br/>"
        End If

        If ConteudoQuantidadeUD = 0 Then
            LblErro.Text += "Preencha corretamente o campo Quantidade UD.<br/>"
        End If

        If String.IsNullOrEmpty(TxtPrecoUnitario.Text) Then
            LblErro.Text += "Preencha o campo Preço Unitário.<br/>"
        End If

        If Not IsNumeric(TxtPrecoUnitario.Text) Then
            LblErro.Text += "Preencha corretamente campo Preço Unitário.<br/>"
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
        objNegociacaoItem.Referencia = DdlReferencia.SelectedValue
        objNegociacaoItem.Quantidade = ConteudoQuantidade
        objNegociacaoItem.QuantidadeUD = ConteudoQuantidadeUD
        objNegociacaoItem.PrecoUnitarioTabela = ConteudoPrecoUnitarioTabela
        objNegociacaoItem.PercDescontoUnitario1 = ConteudoPercDescontoUnitario
        objNegociacaoItem.PercAcrescimoUnitario = ConteudoPercAcrescimoUnitario
        objNegociacaoItem.PrecoUnitario = ConteudoPrecoUnitario
        objNegociacaoItem.PrecoUnitarioUD = LblValorUD.Text
        objNegociacaoItem.CodUnidade = DdlUD.SelectedValue
        objNegociacaoItem.Narrativa = TxtNarrativa.Text.GetValidInputContent
        objNegociacaoItem.AliquotaIPI = LblAliquotaIPI.Text
        objNegociacaoItem.AliquotaICMS = LblAliquotaICMS.Text
        objNegociacaoItem.BaseICMSSubstituicao = LblBaseIcmsSubstituicao.Text
        objNegociacaoItem.ICMSST = LblICMSST.Text
        objNegociacaoItem.IPI = LblIPI.Text
        objNegociacaoItem.ValorTotal = LblValorTotal.Text
        objNegociacaoItem.CodNaturOper = DdlNaturOper.SelectedValue
        objNegociacaoItem.ICMS = LblICMS.Text
        objNegociacaoItem.PercentualDesconto = TxtPercDesconto.Text
        objNegociacaoItem.ValorDesconto = TxtValorDesconto.Text
        objNegociacaoItem.ValorMercadoria = LblValorMercadoria.Text
        objNegociacaoItem.PrecoUnitarioSemComponente = LblPrecoUnitarioSemComponentes.Text
        objNegociacaoItem.PrazoEntrega = TxtPrazoEntrega.Text
        objNegociacaoItem.TpPrazoEntrega = DdlTpPrazoEntrega.SelectedValue
        objNegociacaoItem.Aux1 = TxtAux1.Text.GetValidInputContent
        objNegociacaoItem.Aux2 = TxtAux2.Text.GetValidInputContent
        objNegociacaoItem.Aux3 = TxtAux3.Text.GetValidInputContent
        objNegociacaoItem.Aux4 = TxtAux4.Text.GetValidInputContent
        Return objNegociacaoItem
    End Function

    Private Function Gravar() As Boolean
        Try
            Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objNegociacaoItem.CodNegociacao = CodNegociacao
                    objNegociacaoItem.SeqItem = SeqItem
                    objNegociacaoItem.Empresa = Session("GlEmpresa")
                    objNegociacaoItem.Estabelecimento = Session("GlEstabelecimento")
                    objNegociacaoItem.Buscar()
                    objNegociacaoItem = CarregaObjeto(objNegociacaoItem)
                    objNegociacaoItem.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objNegociacaoItem.CodNegociacao = CodNegociacao
                    objNegociacaoItem.SeqItem = LblSeqItem.Text
                    objNegociacaoItem.Empresa = Session("GlEmpresa")
                    objNegociacaoItem.Estabelecimento = Session("GlEstabelecimento")
                    objNegociacaoItem.Buscar()
                    objNegociacaoItem = CarregaObjeto(objNegociacaoItem)
                    objNegociacaoItem.Incluir()
                    Session("SAcaoItem") = "ALTERAR"
                    Session("SSeqItemNegociacao") = LblSeqItem.Text
                    Response.Redirect("WFNegociacaoItem_Dist.aspx?t=" + Now.ToString("yyyyMMddHHmmssfff"))
                End If
                Return True
            End If
            Return False
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Call Gravar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Function GetTotalOpcionais() As Double
        Try
            Dim StrSql As String = "select isnull(sum(n.preco_total),0) tot_opc" + _
                                    " from negociacao_cliente_item_estrutura n" + _
                                   " where n.empresa                = " + Session("GlEmpresa") + _
                                     " and n.estabelecimento        = " + Session("GlEstabelecimento") + _
                                     " and n.cod_negociacao_cliente = " + CodNegociacao + _
                                     " and n.seq_item               = " + LblSeqItem.Text
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("tot_opc")) Then
                    Return 0
                Else
                    Return CDbl(dt.Rows.Item(0).Item("tot_opc"))
                End If
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub CalculaTotais()
        Dim objCalculoImposto As New UCLCalculoImposto
        Dim retorno As String

        If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
            objCalculoImposto.Empresa = Session("GlEmpresa")
            objCalculoImposto.Estabelecimento = Session("GlEstabelecimento")
            objCalculoImposto.CodItem = TxtCodItem.Text
            objCalculoImposto.Quantidade = ConteudoQuantidade
            objCalculoImposto.QuantidadeUD = ConteudoQuantidadeUD
            objCalculoImposto.PrecoUnitario = ConteudoPrecoUnitario
            objCalculoImposto.PrecoUnitarioUD = CDbl(LblValorUD.Text)
            objCalculoImposto.PercentualDesconto = ConteudoPercDesconto
            objCalculoImposto.ValorDesconto = ConteudoValorDesconto
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
            Else
                LblErro.Text += " Por esse motivo, os valores abaixo podem não ser calculados corretamente."
            End If
        End If
    End Sub

    Private Sub CalcularPrecoUnitario(ByVal CampoAlterado As String, ByVal NovoValor As String)
        Try
            Dim precoOriginal As Double = 0
            Dim percentualDescontoUnitario As Double = 0
            Dim percentualAcrescimoUnitario As Double = 0
            Dim precoUnitarioFinal As Double = 0

            If IsNumeric(LblPrecoUnitarioTabela.Text) Then
                precoOriginal = CDbl(LblPrecoUnitarioTabela.Text)
            End If

            If IsNumeric(TxtPercDescontoUnitario.Text) Then
                percentualDescontoUnitario = CDbl(TxtPercDescontoUnitario.Text)
            End If

            If IsNumeric(TxtPercAcrescimoUnitario.Text) Then
                percentualAcrescimoUnitario = CDbl(TxtPercAcrescimoUnitario.Text)
            End If

            If IsNumeric(TxtPrecoUnitario.Text) Then
                precoUnitarioFinal = CDbl(TxtPrecoUnitario.Text)
            End If

            Select Case CampoAlterado
                Case "TxtPercDescontoUnitario"
                    If IsNumeric(NovoValor) Then
                        percentualDescontoUnitario = CDbl(NovoValor)
                    End If
                Case "TxtPercAcrescimoUnitario"
                    If IsNumeric(NovoValor) Then
                        percentualAcrescimoUnitario = CDbl(NovoValor)
                    End If
                Case "TxtPrecoUnitario"
                    If IsNumeric(NovoValor) Then
                        precoUnitarioFinal = CDbl(NovoValor)
                    End If
                    If precoUnitarioFinal > precoOriginal AndAlso precoOriginal > 0 AndAlso precoUnitarioFinal > 0 Then
                        percentualAcrescimoUnitario = (precoUnitarioFinal / precoOriginal * 100) - 100
                        percentualDescontoUnitario = 0
                    ElseIf precoUnitarioFinal < precoOriginal AndAlso precoOriginal > 0 AndAlso precoUnitarioFinal > 0 Then
                        percentualAcrescimoUnitario = 0
                        percentualDescontoUnitario = Math.Abs((precoUnitarioFinal / precoOriginal * 100) - 100)
                    End If
            End Select

            If CampoAlterado <> "TxtPrecoUnitario" Then
                precoUnitarioFinal = precoOriginal * (1 + (percentualAcrescimoUnitario / 100)) * (1 - (percentualDescontoUnitario / 100))
            End If

            TxtPercDescontoUnitario.Text = percentualDescontoUnitario.ToString("F2")
            TxtPercAcrescimoUnitario.Text = percentualAcrescimoUnitario.ToString("F2")
            TxtPrecoUnitario.Text = precoUnitarioFinal.ToString("F4")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("WGNegociacaoItem.aspx")
    End Sub

    Protected Sub CarregaFormulario()
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        objNegociacaoItem.Empresa = Session("GlEmpresa")
        objNegociacaoItem.Estabelecimento = Session("GlEstabelecimento")
        objNegociacaoItem.CodNegociacao = CodNegociacao
        objNegociacaoItem.SeqItem = SeqItem
        objNegociacaoItem.Buscar()
        LblSeqItem.Text = objNegociacaoItem.SeqItem
        TxtCodItem.Text = objNegociacaoItem.CodItem

        Dim objItemReferencia As New UCLItemReferencia(StrConexao)
        objItemReferencia.CodItem = TxtCodItem.Text
        objItemReferencia.Referencia = objNegociacaoItem.Referencia
        objItemReferencia.FillDropDown(DdlReferencia, True, "(selecione)")

        DdlReferencia.SelectedValue = objNegociacaoItem.Referencia
        Session("SCodItemPesquisado") = TxtCodItem.Text
        Session("SReferenciaPesquisada") = DdlReferencia.SelectedValue
        Call CarregaUnidades()
        DdlUD.SelectedValue = objNegociacaoItem.CodUnidade
        LblPrecoUnitarioTabela.Text = objNegociacaoItem.PrecoUnitarioTabela
        LblPrecoUnitarioSemComponentes.Text = objNegociacaoItem.PrecoUnitarioSemComponente
        TxtPercDescontoUnitario.Text = objNegociacaoItem.PercDescontoUnitario1
        TxtPercAcrescimoUnitario.Text = objNegociacaoItem.PercAcrescimoUnitario
        TxtPrecoUnitario.Text = objNegociacaoItem.PrecoUnitario
        LblValorUD.Text = objNegociacaoItem.PrecoUnitarioUD
        TxtQuantidade.Text = objNegociacaoItem.Quantidade
        LblQtdUD.Text = objNegociacaoItem.QuantidadeUD
        LblValorTotal.Text = objNegociacaoItem.ValorTotal
        LblICMSST.Text = objNegociacaoItem.ICMSST
        LblIPI.Text = objNegociacaoItem.IPI
        TxtNarrativa.Text = objNegociacaoItem.Narrativa
        TxtPercDesconto.Text = objNegociacaoItem.PercentualDesconto
        TxtValorDesconto.Text = objNegociacaoItem.ValorDesconto
        LblICMS.Text = objNegociacaoItem.ICMS
        LblValorMercadoria.Text = objNegociacaoItem.ValorMercadoria
        DdlNaturOper.SelectedValue = objNegociacaoItem.CodNaturOper
        LblCNPJ.Text = objNegociacaoItem.CNPJCliente
        LblCodEmitente.Text = objNegociacaoItem.CodCliente
        TxtPrazoEntrega.Text = objNegociacaoItem.PrazoEntrega
        If Not String.IsNullOrWhiteSpace(objNegociacaoItem.TpPrazoEntrega) Then
            DdlTpPrazoEntrega.SelectedValue = objNegociacaoItem.TpPrazoEntrega
        End If
        TxtAux1.Text = objNegociacaoItem.Aux1
        TxtAux2.Text = objNegociacaoItem.Aux2
        TxtAux3.Text = objNegociacaoItem.Aux3
        TxtAux4.Text = objNegociacaoItem.Aux4
    End Sub

    Private Sub CarregaNovaPK()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        objNegociacaoItem.Empresa = Session("GlEmpresa")
        objNegociacaoItem.Estabelecimento = Session("GlEstabelecimento")
        objNegociacaoItem.CodNegociacao = CodNegociacao
        LblSeqItem.Text = objNegociacaoItem.GetProximoCodigo

        objNegociacao.Empresa = Session("GlEmpresa")
        objNegociacao.Estabelecimento = Session("GlEstabelecimento")
        objNegociacao.CodNegociacao = CodNegociacao
        objNegociacao.Buscar()
        LblCodEmitente.Text = objNegociacao.CodCliente
        LblCNPJ.Text = objNegociacao.CNPJ
    End Sub

    Protected Sub TxtQuantidade_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtQuantidade.TextChanged
        LblQtdUD.Text = CalculaQuantidade_Unidade_UD(ConteudoQuantidade, ConteudoQuantidadeUD, TipoQuantidadeCalcular.QtdUD, TxtCodItem.Text, "").ToString("F4")
        LblQtdUD.DataBind()
    End Sub

    Protected Sub DdlUD_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlUD.SelectedIndexChanged
        LblQtdUD.Text = CalculaQuantidade_Unidade_UD(ConteudoQuantidade, ConteudoQuantidadeUD, TipoQuantidadeCalcular.QtdUD, TxtCodItem.Text, "").ToString("F4")
        LblQtdUD.DataBind()
    End Sub

    Protected Sub BtnIncluirOpcional_Click(sender As Object, e As EventArgs) Handles BtnIncluirOpcional.Click

    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            Dim ObjNegociacaoClienteItemEstrutura As New UCLNegociacaoItemEstrutura(StrConexaoUsuario(Session("GlUsuario")))
            If e.CommandName = "EXCLUIR" Then
                ObjNegociacaoClienteItemEstrutura.Empresa = Session("GlEmpresa")
                ObjNegociacaoClienteItemEstrutura.Estabelecimento = Session("GlEstabelecimento")
                ObjNegociacaoClienteItemEstrutura.CodNegociacaoCliente = Session("SCodNegociacao")
                ObjNegociacaoClienteItemEstrutura.SeqItem = Session("SSeqItemNegociacao")
                ObjNegociacaoClienteItemEstrutura.SeqItemEstrutura = e.CommandArgument
                ObjNegociacaoClienteItemEstrutura.Excluir()

                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()
                Dim valorComponentes As Double = GetTotalOpcionais()
                If valorComponentes > 0 Then
                    LblPrecoUnitarioTabela.Text = (CDbl(LblPrecoUnitarioSemComponentes.Text) + valorComponentes).ToString("F4")
                    Call CalcularPrecoUnitario("", "")
                    Call CalculaTotais()
                    Call Gravar()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnAtualizarGrid_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnAtualizarGrid.Click
        Try
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
            Dim valorComponentes As Double = GetTotalOpcionais()
            If valorComponentes > 0 Then
                LblPrecoUnitarioTabela.Text = (CDbl(LblPrecoUnitarioSemComponentes.Text) + valorComponentes).ToString("F4")
                Call CalcularPrecoUnitario("", "")
                Call CalculaTotais()
                Call Gravar()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub TxtPercAcrescimoUnitario_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtPercAcrescimoUnitario.TextChanged
        Call CalcularPrecoUnitario("TxtPercAcrescimoUnitario", CType(sender, TextBox).Text)
        Call CalculaTotais()
    End Sub

    Protected Sub TxtPrecoUnitario_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtPrecoUnitario.TextChanged
        Call CalcularPrecoUnitario("TxtPrecoUnitario", CType(sender, TextBox).Text)
        Call CalculaTotais()
    End Sub

    Protected Sub TxtPercDescontoUnitario_TextChanged(sender As Object, e As EventArgs) Handles TxtPercDescontoUnitario.TextChanged
        Call CalcularPrecoUnitario("TxtPercDescontoUnitario", CType(sender, TextBox).Text)
        Call CalculaTotais()
    End Sub

    Protected Sub TxtPercDesconto_TextChanged(sender As Object, e As EventArgs) Handles TxtPercDesconto.TextChanged
        Call CalculaTotais()
    End Sub

    Protected Sub TxtValorDesconto_TextChanged(sender As Object, e As EventArgs) Handles TxtValorDesconto.TextChanged
        Call CalculaTotais()
    End Sub

    Protected Sub CarregaLabelsAuxiliares()
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        objNegociacaoItem.Empresa = Session("GlEmpresa")
        objNegociacaoItem.Estabelecimento = Session("GlEstabelecimento")
        objNegociacaoItem.CodNegociacao = CodNegociacao
        objNegociacaoItem.SeqItem = SeqItem
        objNegociacaoItem.Buscar()
        LblAux1.Text = objNegociacaoItem.Aux1Label.Trim
        LblAux2.Text = objNegociacaoItem.Aux2Label.Trim
        LblAux3.Text = objNegociacaoItem.Aux3Label.Trim
        LblAux4.Text = objNegociacaoItem.Aux4Label.Trim

        If LblAux1.Text = "" Then
            LblAux1.Text = "Aux. 1"
        End If
        If LblAux2.Text = "" Then
            LblAux2.Text = "Aux. 2"
        End If
        If LblAux3.Text = "" Then
            LblAux3.Text = "Aux. 3"
        End If
        If LblAux4.Text = "" Then
            LblAux4.Text = "Aux. 4"
        End If
        If Not LblAux1.Text.EndsWith(":") Then
            LblAux1.Text += ":"
        End If
        If Not LblAux2.Text.EndsWith(":") Then
            LblAux2.Text += ":"
        End If
        If Not LblAux3.Text.EndsWith(":") Then
            LblAux3.Text += ":"
        End If
        If Not LblAux4.Text.EndsWith(":") Then
            LblAux4.Text += ":"
        End If
    End Sub

End Class