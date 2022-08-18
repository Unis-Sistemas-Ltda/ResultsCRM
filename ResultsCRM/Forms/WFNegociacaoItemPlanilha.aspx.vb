Public Class WFNegociacaoItemPlanilha
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

            If Not IsPostBack Then
                objNegociacao.Empresa = Session("GlEmpresa")
                objNegociacao.Estabelecimento = Session("GlEstabelecimento")
                objNegociacao.CodNegociacao = Session("SCodNegociacao")
                objNegociacao.Buscar()

                objEmitente.CodEmitente = objNegociacao.CodCliente
                objEmitente.Buscar()

                LblCodNegociacaoCliente.Text = objNegociacao.CodNegociacao
                LblNomeCliente.Text = objEmitente.Nome

                If objEmitente.TpPessoa = "PF" Then
                    LblCNPJ.Text = objNegociacao.CNPJ.MascaraCPF
                Else
                    LblCNPJ.Text = objNegociacao.CNPJ.MascaraCNPJ
                End If
                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()
                CalculaTotalGeralDaNegociacao()
            End If

            If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
                GridView1.Columns.Item(16).Visible = False
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnGravar.Click
        Try
            Call Calcular()
            Call Gravar()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub Gravar()
        Try
            Dim objNegociacaoItem As UCLNegociacaoItem
            Dim itens As New List(Of UCLNegociacaoItem)
            Dim erros As String

            'Preenche lista de itens da negociação
            For Each row As GridViewRow In GridView1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    objNegociacaoItem = New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
                    If CarregaObjeto(objNegociacaoItem, row) Then
                        itens.Add(objNegociacaoItem)
                    End If
                End If
            Next

            'Verifica preenchimento dos campos
            erros = ""
            For Each objNegociacaoItem In itens
                erros += VerificaPreenchimento(objNegociacaoItem)
            Next

            If Not String.IsNullOrWhiteSpace(erros) Then
                Throw New Exception(erros)
            End If

            'Grava itens da negociação
            For Each objNegociacaoItem In itens
                Call objNegociacaoItem.Gravar()
            Next

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "onload", "var btn; var jan; var janp; jan = window.opener; janp = jan.parent; btn = janp.document.getElementById('BtnCarregaTotal'); btn.click() ; window.opener.document.location.href = 'WGNegociacaoItem.aspx?rand=" + Now.ToString("ddMMYYYYHHmmssfff") + "' ; window.close()", True)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function VerificaPreenchimento(ByRef objNegociacaoItem As UCLNegociacaoItem) As String
        Try
            Dim erro As String = ""
            If String.IsNullOrWhiteSpace(objNegociacaoItem.Quantidade) Then
                erro += "Preencha o campo quantidade unitária no item " + objNegociacaoItem.CodItem + ".<br/>"
            ElseIf IsNumeric(objNegociacaoItem.Quantidade) AndAlso objNegociacaoItem.Quantidade <= 0 Then
                erro += "Preencha corretamente o campo quantidade unitária no item " + objNegociacaoItem.CodItem + ".<br/>"
            End If

            If String.IsNullOrWhiteSpace(objNegociacaoItem.QuantidadeUD) Then
                erro += "Preencha o campo quantidade logística no item " + objNegociacaoItem.CodItem + ".<br/>"
            ElseIf IsNumeric(objNegociacaoItem.QuantidadeUD) AndAlso objNegociacaoItem.QuantidadeUD <= 0 Then
                erro += "Preencha corretamente o campo quantidade logística no item " + objNegociacaoItem.CodItem + ".<br/>"
            End If

            Return erro
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function CarregaObjeto(ByRef objNegociacaoItem As UCLNegociacaoItem, row As GridViewRow) As Boolean
        Try
            Dim LblCodItem As Label
            Dim TxtQtdPedida As TextBox
            Dim TxtQtdUD As TextBox
            Dim LblPrecoUnitario As Label
            Dim LblPrecoUnitarioUD As Label
            Dim LblCodUnidade As Label
            Dim LblAliquotaIPI As Label
            Dim LblAliquotaICMS As Label
            Dim LblBaseICMSSubstituicao As Label
            Dim LblICMSSubstituicao As Label
            Dim LblValorIPI As Label
            Dim LblValorMercadoria As Label
            Dim LblValorTotalMercadoria As Label
            Dim LblValorICMS As Label
            Dim TxtValorDesconto As TextBox
            Dim TxtDescUnitario1 As TextBox
            Dim TxtDescUnitario2 As TextBox
            Dim TxtDescUnitario3 As TextBox
            Dim TxtDescUnitario4 As TextBox
            Dim TxtDescUnitario5 As TextBox
            Dim LblRecurso As Label
            Dim TxtPrecoUnitarioTabela As TextBox
            Dim TxtPercDesconto As TextBox
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))

            LblCodItem = CType(row.FindControl("LblCodItem"), Label)
            TxtQtdPedida = CType(row.FindControl("TxtQtdPedida"), TextBox)
            TxtQtdUD = CType(row.FindControl("TxtQtdUD"), TextBox)
            LblPrecoUnitario = CType(row.FindControl("LblPrecoUnitario"), Label)
            LblPrecoUnitarioUD = CType(row.FindControl("LblPrecoUnitarioUD"), Label)
            LblCodUnidade = CType(row.FindControl("LblCodUnidade"), Label)
            LblAliquotaIPI = CType(row.FindControl("LblAliquotaIPI"), Label)
            LblAliquotaICMS = CType(row.FindControl("LblAliquotaICMS"), Label)
            LblValorICMS = CType(row.FindControl("LblValorICMS"), Label)
            LblBaseICMSSubstituicao = CType(row.FindControl("LblBaseICMSSubstituicao"), Label)
            LblValorIPI = CType(row.FindControl("LblValorIPI"), Label)
            LblICMSSubstituicao = CType(row.FindControl("LblICMSSubstituicao"), Label)
            LblValorMercadoria = CType(row.FindControl("LblValorMercadoria"), Label)
            LblValorTotalMercadoria = CType(row.FindControl("LblValorTotalMercadoria"), Label)
            TxtValorDesconto = CType(row.FindControl("TxtValorDesconto"), TextBox)
            TxtPercDesconto = CType(row.FindControl("TxtPercDesconto"), TextBox)
            TxtDescUnitario1 = CType(row.FindControl("TxtDescUnitario1"), TextBox)
            TxtDescUnitario2 = CType(row.FindControl("TxtDescUnitario2"), TextBox)
            TxtDescUnitario3 = CType(row.FindControl("TxtDescUnitario3"), TextBox)
            TxtDescUnitario4 = CType(row.FindControl("TxtDescUnitario4"), TextBox)
            TxtDescUnitario5 = CType(row.FindControl("TxtDescUnitario5"), TextBox)
            TxtPrecoUnitarioTabela = CType(row.FindControl("TxtPrecoUnitarioTabela"), TextBox)
            LblRecurso = CType(row.FindControl("LblRecurso"), Label)

            If String.IsNullOrWhiteSpace(TxtQtdPedida.Text) AndAlso String.IsNullOrWhiteSpace(TxtQtdUD.Text) Then
                Return False
            End If

            objNegociacaoItem.Empresa = Session("GlEmpresa")
            objNegociacaoItem.Estabelecimento = Session("GlEstabelecimento")
            objNegociacaoItem.CodNegociacao = LblCodNegociacaoCliente.Text
            objNegociacaoItem.CodItem = LblCodItem.Text
            objNegociacaoItem.SeqItem = objNegociacaoItem.GetSeqItemPeloCodItem()
            objNegociacaoItem.Quantidade = TxtQtdPedida.Text
            objNegociacaoItem.QuantidadeUD = TxtQtdUD.Text
            objNegociacaoItem.PrecoUnitario = LblPrecoUnitario.Text
            objNegociacaoItem.PrecoUnitarioUD = LblPrecoUnitarioUD.Text
            objNegociacaoItem.CodUnidade = LblCodUnidade.Text
            objNegociacaoItem.Narrativa = ""
            objNegociacaoItem.AliquotaIPI = LblAliquotaIPI.Text
            objNegociacaoItem.AliquotaICMS = LblAliquotaICMS.Text
            objNegociacaoItem.BaseICMSSubstituicao = LblBaseICMSSubstituicao.Text
            objNegociacaoItem.ICMSST = LblICMSSubstituicao.Text
            objNegociacaoItem.IPI = LblValorIPI.Text
            objNegociacaoItem.ValorTotal = LblValorTotalMercadoria.Text
            objNegociacaoItem.CodNaturOper = objNegociacao.GetCodNaturOper(objNegociacaoItem.Empresa, objNegociacaoItem.Estabelecimento, objNegociacaoItem.CodNegociacao)
            objNegociacaoItem.ICMS = LblValorICMS.Text
            objNegociacaoItem.ValorDesconto = TxtValorDesconto.Text
            objNegociacaoItem.PercentualDesconto = TxtPercDesconto.Text
            objNegociacaoItem.ValorMercadoria = LblValorMercadoria.Text
            objNegociacaoItem.PercDescontoUnitario1 = TxtDescUnitario1.Text
            objNegociacaoItem.PercDescontoUnitario2 = TxtDescUnitario2.Text
            objNegociacaoItem.PercDescontoUnitario3 = TxtDescUnitario3.Text
            objNegociacaoItem.PercDescontoUnitario4 = TxtDescUnitario4.Text
            objNegociacaoItem.PercDescontoUnitario5 = TxtDescUnitario5.Text
            objNegociacaoItem.Recurso = LblRecurso.Text
            objNegociacaoItem.PrecoUnitarioTabela = TxtPrecoUnitarioTabela.Text
        Catch ex As Exception
            Throw ex
        End Try

        Return True
    End Function

    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            Dim TxtDescUnitario1 As TextBox
            Dim TxtDescUnitario2 As TextBox
            Dim TxtDescUnitario3 As TextBox
            Dim TxtDescUnitario4 As TextBox
            Dim TxtDescUnitario5 As TextBox
            Dim TxtPercDesconto As TextBox
            Dim TxtValorDesconto As TextBox
            Dim TxtPrecoUnitarioTabela As TextBox
            Dim TxtQtdPedida As TextBox
            Dim TxtQtdUD As TextBox
            Dim LblCodEmitente As Label
            Dim LblCNPJ As Label
            Dim LblCodItem As Label
            Dim objItem As New UCLItem
            Dim CodTabelaPreco As String
            Dim Desc1, Desc2, Desc3, Desc4, Desc5 As Double

            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If

            TxtDescUnitario1 = CType(e.Row.FindControl("TxtDescUnitario1"), TextBox)
            TxtDescUnitario2 = CType(e.Row.FindControl("TxtDescUnitario2"), TextBox)
            TxtDescUnitario3 = CType(e.Row.FindControl("TxtDescUnitario3"), TextBox)
            TxtDescUnitario4 = CType(e.Row.FindControl("TxtDescUnitario4"), TextBox)
            TxtDescUnitario5 = CType(e.Row.FindControl("TxtDescUnitario5"), TextBox)
            TxtPercDesconto = CType(e.Row.FindControl("TxtPercDesconto"), TextBox)
            TxtValorDesconto = CType(e.Row.FindControl("TxtValorDesconto"), TextBox)

            TxtPrecoUnitarioTabela = CType(e.Row.FindControl("TxtPrecoUnitarioTabela"), TextBox)
            TxtQtdPedida = CType(e.Row.FindControl("TxtQtdPedida"), TextBox)
            TxtQtdUD = CType(e.Row.FindControl("TxtQtdUD"), TextBox)
            LblCodItem = CType(e.Row.FindControl("LblCodItem"), Label)
            LblCodEmitente = CType(e.Row.FindControl("LblCodEmitente"), Label)
            LblCNPJ = CType(e.Row.FindControl("LblCNPJ"), Label)

            TxtPrecoUnitarioTabela.Text = objItem.PrecoItemCliente(Session("GlEmpresa"), Session("GlEstabelecimento"), LblCodEmitente.Text, LblCNPJ.Text, LblCodItem.Text, "", "").ToString("F2")

            CodTabelaPreco = objItem.F_BuscaTabelaPrecoVenda(Session("GlEmpresa"), LblCodEmitente.Text, LblCNPJ.Text)

            Desc1 = 0
            Desc2 = 0
            Desc3 = 0
            Desc4 = 0
            Desc5 = 0

            Call objItem.BuscaDescontosComerciaisUnitarios(Session("GlEmpresa"), Session("GlEstabelecimento"), CodTabelaPreco, LblCodItem.Text, Desc1, Desc2, Desc3, Desc4, Desc5)

            TxtDescUnitario1.Text = Desc1.ToString("F2")
            TxtDescUnitario2.Text = Desc2.ToString("F2")
            TxtDescUnitario3.Text = Desc3.ToString("F2")
            TxtDescUnitario4.Text = Desc4.ToString("F2")
            TxtDescUnitario5.Text = Desc5.ToString("F2")

            TxtDescUnitario1.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtDescUnitario2.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtDescUnitario3.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtDescUnitario4.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtDescUnitario5.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtPrecoUnitarioTabela.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtQtdPedida.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtQtdUD.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtPercDesconto.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtValorDesconto.Attributes.Add("OnFocus", "selecionaCampo(this)")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CalculaTotais()
        Try
            Dim objCalculoImposto As New UCLCalculoImposto
            Dim LblCodItem As Label
            Dim TxtQtdPedida As TextBox
            Dim TxtQtdUD As TextBox
            Dim LblCodEmitente As Label
            Dim LblCNPJ As Label
            Dim LblPrecoUnitario As Label
            Dim LblPrecoUnitarioUD As Label
            Dim LblBaseICMSSubstituicao As Label
            Dim retorno As String
            Dim Quantidade As String
            Dim QuantidadeUD As String
            Dim PercDesconto As String
            Dim ValorDesconto As String
            Dim PrecoUnitario As String
            Dim PrecoUnitarioUD As String
            Dim TxtValorDesconto As TextBox
            Dim TxtPercDesconto As TextBox
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            Dim LblValorMercadoria As Label
            Dim LblValorTotalMercadoria As Label
            Dim LblICMSSubstituicao As Label
            Dim LblValorIPI As Label
            Dim LblAliquotaIPI As Label
            Dim LblValorICMS As Label
            Dim LblAliquotaICMS As Label
            Dim LblRecurso As Label

            LblErro.Text = ""

            For Each row As GridViewRow In GridView1.Rows
                If row.RowType <> DataControlRowType.DataRow Then
                    Continue For
                End If

                LblCodItem = CType(row.FindControl("LblCodItem"), Label)
                LblCodEmitente = CType(row.FindControl("LblCodEmitente"), Label)
                LblCNPJ = CType(row.FindControl("LblCNPJ"), Label)
                TxtQtdPedida = CType(row.FindControl("TxtQtdPedida"), TextBox)
                TxtQtdUD = CType(row.FindControl("TxtQtdUD"), TextBox)
                TxtValorDesconto = CType(row.FindControl("TxtValorDesconto"), TextBox)
                TxtPercDesconto = CType(row.FindControl("TxtPercDesconto"), TextBox)
                LblPrecoUnitario = CType(row.FindControl("LblPrecoUnitario"), Label)
                LblPrecoUnitarioUD = CType(row.FindControl("LblPrecoUnitarioUD"), Label)
                LblValorMercadoria = CType(row.FindControl("LblValorMercadoria"), Label)
                LblValorTotalMercadoria = CType(row.FindControl("LblValorTotalMercadoria"), Label)
                LblBaseICMSSubstituicao = CType(row.FindControl("LblBaseICMSSubstituicao"), Label)
                LblICMSSubstituicao = CType(row.FindControl("LblICMSSubstituicao"), Label)
                LblValorIPI = CType(row.FindControl("LblValorIPI"), Label)
                LblValorICMS = CType(row.FindControl("LblValorICMS"), Label)
                LblAliquotaIPI = CType(row.FindControl("LblAliquotaIPI"), Label)
                LblAliquotaICMS = CType(row.FindControl("LblAliquotaICMS"), Label)
                LblRecurso = CType(row.FindControl("LblRecurso"), Label)

                Quantidade = TxtQtdPedida.Text
                QuantidadeUD = TxtQtdUD.Text

                If String.IsNullOrWhiteSpace(Quantidade) Then
                    Quantidade = 0
                End If

                If String.IsNullOrWhiteSpace(QuantidadeUD) Then
                    QuantidadeUD = 0
                End If

                If Not String.IsNullOrWhiteSpace(TxtQtdPedida.Text) AndAlso Not String.IsNullOrWhiteSpace(TxtQtdUD.Text) Then
                    TxtQtdPedida.Text = CalculaQuantidade_Unidade_UD(Quantidade, QuantidadeUD, TipoQuantidadeCalcular.QtdPedida, LblCodItem.Text, "").ToString("F2")
                Else
                    If Not String.IsNullOrWhiteSpace(TxtQtdPedida.Text) OrElse Not String.IsNullOrWhiteSpace(TxtQtdUD.Text) Then
                        If String.IsNullOrWhiteSpace(TxtQtdPedida.Text) Then
                            TxtQtdPedida.Text = CalculaQuantidade_Unidade_UD(Quantidade, QuantidadeUD, TipoQuantidadeCalcular.QtdPedida, LblCodItem.Text, "").ToString("F2")
                        End If
                        If String.IsNullOrWhiteSpace(TxtQtdUD.Text) Then
                            TxtQtdUD.Text = CalculaQuantidade_Unidade_UD(Quantidade, QuantidadeUD, TipoQuantidadeCalcular.QtdUD, LblCodItem.Text, "").ToString("F2")
                        End If
                    End If
                End If

                Quantidade = TxtQtdPedida.Text
                QuantidadeUD = TxtQtdUD.Text

                If String.IsNullOrWhiteSpace(Quantidade) Then
                    Quantidade = 0
                End If

                If String.IsNullOrWhiteSpace(QuantidadeUD) Then
                    QuantidadeUD = 0
                End If

                PercDesconto = TxtPercDesconto.Text
                ValorDesconto = TxtValorDesconto.Text

                If String.IsNullOrWhiteSpace(PercDesconto) Then
                    PercDesconto = 0
                End If

                If String.IsNullOrWhiteSpace(ValorDesconto) Then
                    ValorDesconto = 0
                End If

                PrecoUnitario = LblPrecoUnitario.Text
                PrecoUnitarioUD = LblPrecoUnitarioUD.Text

                If String.IsNullOrWhiteSpace(PrecoUnitario) Then
                    PrecoUnitario = 0
                End If

                If String.IsNullOrWhiteSpace(PrecoUnitarioUD) Then
                    PrecoUnitarioUD = 0
                End If

                objCalculoImposto.Empresa = Session("GlEmpresa")
                objCalculoImposto.Estabelecimento = Session("GlEstabelecimento")
                objCalculoImposto.CodItem = LblCodItem.Text
                objCalculoImposto.Quantidade = Quantidade
                objCalculoImposto.QuantidadeUD = QuantidadeUD
                objCalculoImposto.PrecoUnitario = CDbl(PrecoUnitario)
                objCalculoImposto.PrecoUnitarioUD = CDbl(PrecoUnitarioUD)
                objCalculoImposto.PercentualDesconto = PercDesconto
                objCalculoImposto.ValorDesconto = ValorDesconto
                objCalculoImposto.CodEmitente = LblCodEmitente.Text
                objCalculoImposto.CNPJ = LblCNPJ.Text
                objCalculoImposto.CodNaturOper = objNegociacao.GetCodNaturOper(Session("GlEmpresa"), Session("GlEstabelecimento"), LblCodNegociacaoCliente.Text)
                retorno = objCalculoImposto.CalculaTotais()
                LblErro.Text += retorno
                LblValorMercadoria.Text = objCalculoImposto.ValorMercadoria.ToString("F2")
                LblValorTotalMercadoria.Text = objCalculoImposto.ValorTotalMercadoria.ToString("F2")
                If retorno = "" Then
                    LblBaseICMSSubstituicao.Text = objCalculoImposto.BaseIcmsSubstituicao.ToString("F4")
                    LblICMSSubstituicao.Text = objCalculoImposto.IcmsSubstituicao.ToString("F2")
                    LblValorIPI.Text = objCalculoImposto.ValorIPI.ToString("F2")
                    LblValorICMS.Text = objCalculoImposto.ValorICMS.ToString("F2")
                    LblAliquotaICMS.Text = objCalculoImposto.AliquotaICMS.ToString("F1")
                    LblAliquotaIPI.Text = objCalculoImposto.AliquotaIPI.ToString("F1")
                    LblPrecoUnitarioUD.Text = objCalculoImposto.PrecoUnitarioUD.ToString("F2")
                    LblRecurso.Text = objCalculoImposto.Recurso.ToString("F4")
                Else
                    LblErro.Text += " Por esse motivo, os valores abaixo podem não ser calculados corretamente no item " + LblCodItem.Text + ".<br/>"
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CalculaValorUnitario()
        Try
            Dim percDesc As Decimal
            Dim precoUnitarioTabela As Decimal
            Dim precoUnitarioFinal As Decimal
            Dim TxtPrecoUnitarioTabela As TextBox
            Dim TxtDescUnitario1 As TextBox
            Dim TxtDescUnitario2 As TextBox
            Dim TxtDescUnitario3 As TextBox
            Dim TxtDescUnitario4 As TextBox
            Dim TxtDescUnitario5 As TextBox
            Dim LblPrecoUnitario As Label

            For Each row As GridViewRow In GridView1.Rows
                If row.RowType = DataControlRowType.DataRow Then

                    TxtPrecoUnitarioTabela = CType(row.FindControl("TxtPrecoUnitarioTabela"), TextBox)
                    TxtDescUnitario1 = CType(row.FindControl("TxtDescUnitario1"), TextBox)
                    TxtDescUnitario2 = CType(row.FindControl("TxtDescUnitario2"), TextBox)
                    TxtDescUnitario3 = CType(row.FindControl("TxtDescUnitario3"), TextBox)
                    TxtDescUnitario4 = CType(row.FindControl("TxtDescUnitario4"), TextBox)
                    TxtDescUnitario5 = CType(row.FindControl("TxtDescUnitario5"), TextBox)
                    LblPrecoUnitario = CType(row.FindControl("LblPrecoUnitario"), Label)

                    If Not IsNumeric(TxtPrecoUnitarioTabela.Text) Then
                        Return
                    End If

                    precoUnitarioTabela = CDbl(TxtPrecoUnitarioTabela.Text)
                    precoUnitarioFinal = precoUnitarioTabela

                    For i As Integer = 1 To 5
                        Select Case i
                            Case 1
                                If IsNumeric(TxtDescUnitario1.Text) Then
                                    percDesc = CDbl(TxtDescUnitario1.Text)
                                Else
                                    percDesc = 0
                                End If
                            Case 2
                                If IsNumeric(TxtDescUnitario2.Text) Then
                                    percDesc = CDbl(TxtDescUnitario2.Text)
                                Else
                                    percDesc = 0
                                End If
                            Case 3
                                If IsNumeric(TxtDescUnitario3.Text) Then
                                    percDesc = CDbl(TxtDescUnitario3.Text)
                                Else
                                    percDesc = 0
                                End If
                            Case 4
                                If IsNumeric(TxtDescUnitario4.Text) Then
                                    percDesc = CDbl(TxtDescUnitario4.Text)
                                Else
                                    percDesc = 0
                                End If
                            Case 5
                                If IsNumeric(TxtDescUnitario5.Text) Then
                                    percDesc = CDbl(TxtDescUnitario5.Text)
                                Else
                                    percDesc = 0
                                End If
                        End Select

                        precoUnitarioFinal = precoUnitarioFinal - (precoUnitarioFinal * percDesc / 100)
                    Next

                    LblPrecoUnitario.Text = precoUnitarioFinal.ToString("F4")
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles BtnCalcular.Click
        Try
            Call Calcular()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub Calcular()
        Try
            Call CalculaValorUnitario()
            Call CalculaTotais()
            Call CalculaTotalGeralDaNegociacao()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CalculaTotalGeralDaNegociacao()
        Try
            Dim totalGeral As Double = 0
            Dim totalItem As Double = 0
            Dim strTotalItem As String
            For Each row As GridViewRow In GridView1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    strTotalItem = CType(row.FindControl("LblValorTotalMercadoria"), Label).Text
                    If Not String.IsNullOrWhiteSpace(strTotalItem) AndAlso IsNumeric(strTotalItem) Then
                        totalItem = CType(row.FindControl("LblValorTotalMercadoria"), Label).Text
                        totalGeral += totalItem
                    End If
                End If
            Next
            LblTotal.Text = totalGeral.ToString("F2")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class