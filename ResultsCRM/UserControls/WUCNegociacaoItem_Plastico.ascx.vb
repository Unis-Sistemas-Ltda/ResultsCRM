Partial Public Class WUCNegociacaoItem_Plastico
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objNatureza As New UCLNaturezaOperacao

        TxtQuantidade.Attributes.Add("OnKeyPress", "return(formatarNumerico(this,'.',',',event,4));")
        TxtQuantidade.Attributes.Add("OnBlur", "submit();")
        TxtQuantidadeUD.Attributes.Add("OnKeyPress", "return(formatarNumerico(this,'.',',',event,4));")
        TxtQuantidadeUD.Attributes.Add("OnBlur", "submit();")

        Try
            If Not IsPostBack Then
                objNatureza.FillDropDown(DdlNaturOper, True, "")
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                Else
                    Call CarregaNovaPK()
                End If
                Call CarregaLabelsAuxiliares()
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

        Try
            Call CarregaDescricaoItem()

            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                TxtPrecoUnitario.Text = objItem.PrecoItemCliente(Session("GlEmpresa"), Session("GlEstabelecimento"), LblCodEmitente.Text, LblCNPJ.Text, TxtCodItem.Text, "", "").ToString("F4")
                TxtValorDesconto.Text = 0
                TxtNarrativa.Text = objItem.GetNarrativa(TxtCodItem.Text)
                Call CarregaUnidades()
                Session("SCodItemPesquisado") = TxtCodItem.Text
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
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtCodItem.Text) Then
            LblErro.Text += "Preencha o campo Item.<br/>"
        End If

        If Quantidade = 0 Then
            LblErro.Text += "Preencha corretamente o campo Quantidade.<br/>"
        End If

        If QuantidadeUD = 0 Then
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
        objNegociacaoItem.Quantidade = Quantidade
        objNegociacaoItem.QuantidadeUD = QuantidadeUD
        objNegociacaoItem.PrecoUnitario = TxtPrecoUnitario.Text
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
        objNegociacaoItem.ValorDesconto = TxtValorDesconto.Text
        objNegociacaoItem.ValorMercadoria = LblValorMercadoria.Text
        objNegociacaoItem.Aux1 = TxtAux1.Text.GetValidInputContent
        objNegociacaoItem.Aux2 = TxtAux2.Text.GetValidInputContent
        objNegociacaoItem.Aux3 = TxtAux3.Text.GetValidInputContent
        objNegociacaoItem.Aux4 = TxtAux4.Text.GetValidInputContent
        objNegociacaoItem.Aux5 = TxtAux5.Text.GetValidInputContent
        objNegociacaoItem.Aux6 = TxtAux6.Text.GetValidInputContent
        objNegociacaoItem.Aux7 = TxtAux7.Text.GetValidInputContent
        objNegociacaoItem.Aux8 = TxtAux8.Text.GetValidInputContent
        objNegociacaoItem.Aux9 = TxtAux9.Text.GetValidInputContent
        objNegociacaoItem.Aux10 = TxtAux10.Text.GetValidInputContent
        objNegociacaoItem.Aux11 = TxtAux11.Text.GetValidInputContent
        objNegociacaoItem.Aux12 = TxtAux12.Text.GetValidInputContent
        objNegociacaoItem.Altura = TxtH.Text
        objNegociacaoItem.Largura = TxtC.Text
        objNegociacaoItem.Espessura = TxtE.Text

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
                End If

                Response.Redirect("WGNegociacaoItem.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub CalculaTotais()
        Dim objCalculoImposto As New UCLCalculoImposto
        Dim retorno As String

        If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
            objCalculoImposto.Empresa = Session("GlEmpresa")
            objCalculoImposto.Estabelecimento = Session("GlEstabelecimento")
            objCalculoImposto.CodItem = TxtCodItem.Text
            objCalculoImposto.Quantidade = Quantidade
            objCalculoImposto.QuantidadeUD = QuantidadeUD
            objCalculoImposto.PrecoUnitario = CDbl(TxtPrecoUnitario.Text)
            objCalculoImposto.PrecoUnitarioUD = CDbl(LblValorUD.Text)
            objCalculoImposto.ValorDesconto = CDbl(TxtValorDesconto.Text)
            objCalculoImposto.CodEmitente = LblCodEmitente.Text
            objCalculoImposto.CNPJ = LblCNPJ.Text
            objCalculoImposto.CodNaturOper = DdlNaturOper.SelectedValue
            retorno = objCalculoImposto.CalculaTotais()
            LblErro.Text = retorno
            If retorno = "" Then
                LblBaseIcmsSubstituicao.Text = objCalculoImposto.BaseIcmsSubstituicao.ToString("F4")
                LblICMSST.Text = objCalculoImposto.IcmsSubstituicao.ToString("F4")
                LblValorMercadoria.Text = objCalculoImposto.ValorMercadoria.ToString("F2")
                LblValorTotal.Text = objCalculoImposto.ValorTotalMercadoria.ToString("F2")
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

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("WGNegociacaoItem.aspx")
    End Sub

    Protected Sub CarregaLabelsAuxiliares()
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        objNegociacaoItem.Empresa = Session("GlEmpresa")
        objNegociacaoItem.Estabelecimento = Session("GlEstabelecimento")
        objNegociacaoItem.CodNegociacao = CodNegociacao
        objNegociacaoItem.SeqItem = SeqItem
        objNegociacaoItem.Buscar()
        LblAux1.Text = objNegociacaoItem.Aux1Label
        LblAux2.Text = objNegociacaoItem.Aux2Label
        LblAux3.Text = objNegociacaoItem.Aux3Label
        LblAux4.Text = objNegociacaoItem.Aux4Label
        LblAux5.Text = objNegociacaoItem.Aux5Label
        LblAux6.Text = objNegociacaoItem.Aux6Label
        LblAux7.Text = objNegociacaoItem.Aux7Label
        LblAux8.Text = objNegociacaoItem.Aux8Label
        LblAux9.Text = objNegociacaoItem.Aux9Label
        LblAux10.Text = objNegociacaoItem.Aux10Label
        LblAux11.Text = objNegociacaoItem.Aux11Label
        LblAux12.Text = objNegociacaoItem.Aux12Label
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
        Call CarregaUnidades()
        DdlUD.SelectedValue = objNegociacaoItem.CodUnidade
        TxtPrecoUnitario.Text = objNegociacaoItem.PrecoUnitario
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
        TxtAux1.Text = objNegociacaoItem.Aux1
        TxtAux2.Text = objNegociacaoItem.Aux2
        TxtAux3.Text = objNegociacaoItem.Aux3
        TxtAux4.Text = objNegociacaoItem.Aux4
        TxtAux5.Text = objNegociacaoItem.Aux5
        TxtAux6.Text = objNegociacaoItem.Aux6
        TxtAux7.Text = objNegociacaoItem.Aux7
        TxtAux8.Text = objNegociacaoItem.Aux8
        TxtAux9.Text = objNegociacaoItem.Aux9
        TxtAux10.Text = objNegociacaoItem.Aux10
        TxtAux11.Text = objNegociacaoItem.Aux11
        TxtAux12.Text = objNegociacaoItem.Aux12
        TxtH.Text = objNegociacaoItem.Altura
        TxtC.Text = objNegociacaoItem.Largura
        TxtE.Text = objNegociacaoItem.Espessura
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

    Private Sub QuantidadeAlterada(ByVal Tipo As String, ByVal StrQuantidade As String)
        Dim ObjItem As New UCLItem
        Dim TipoFaturamento As String
        Dim FatorConversao As Double
        Dim quantidade As Double

        If String.IsNullOrEmpty(Tipo) OrElse String.IsNullOrEmpty(StrQuantidade) Then
            Return
        Else
            If Not IsNumeric(StrQuantidade) Then
                LblErro.Text = "Informe um número válido para a quantidade."
                Return
            End If
        End If

        quantidade = CDbl(StrQuantidade)

        objItem.CodItem = TxtCodItem.Text
        objItem.Buscar()

        tipoFaturamento = objItem.TipoFaturamento

        If tipoFaturamento = "P" Then
            If DdlUD.SelectedValue = "0" Then
                FatorConversao = 1
            Else
                FatorConversao = ObjItem.GetFatorConversaoItemUnidade(TxtCodItem.Text, DdlUD.SelectedValue)
            End If
        Else
            FatorConversao = ObjItem.GetFatorConversaoUD(TxtCodItem.Text)
        End If

        If FatorConversao = Nothing OrElse FatorConversao = 0 Then
            FatorConversao = 1
        End If

        If Tipo = "qtd_pedida" Then
            TxtQuantidadeUD.Text = (quantidade / FatorConversao).ToString("F4")
        ElseIf Tipo = "qtd_ud" Then
            TxtQuantidade.Text = (quantidade * FatorConversao).ToString("F4")
        End If

    End Sub

    Protected Sub TxtQuantidade_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtQuantidade.TextChanged
        Call QuantidadeAlterada("qtd_pedida", TxtQuantidade.Text)
    End Sub

    Protected Sub TxtQuantidadeUD_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtQuantidadeUD.TextChanged
        Call QuantidadeAlterada("qtd_ud", TxtQuantidadeUD.Text)
    End Sub


End Class