Partial Public Class WUCNegociacaoItem
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

    Private Sub CarregaEquipamentoCliente(ByVal numeroSerieSelecionado As String)
        Try
            Dim objEquipamentoCliente As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))

            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("GlEstabelecimento")
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
                DdlEquipamento.DataBind()
            End If
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
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Session("SModoCadEquipamento") = WUCEquipamento.ModoJanela.AberturaPorOutraTela

            TxtQuantidade.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")
            TxtQuantidade.Attributes.Add("OnBlur", "submit();")
            TxtQuantidadeUD.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")
            TxtQuantidadeUD.Attributes.Add("OnBlur", "submit();")

            If Not IsPostBack Then
                Dim objNatureza As New UCLNaturezaOperacao
                objNatureza.FillDropDown(DdlNaturOper, True, "")
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                    BtnIncluirOpcional.Enabled = True
                Else
                    Call CarregaEquipamentoCliente("0")
                    Call CarregaNovaPK()
                End If

                Dim codFunil As String = ""
                Dim objNegociacaoCliente As New UCLNegociacao(StrConexao)
                Dim objFunil As New UCLFunilVenda
                objNegociacaoCliente.Empresa = Session("GlEmpresa")
                objNegociacaoCliente.Estabelecimento = Session("GlEstabelecimento")
                objNegociacaoCliente.CodNegociacao = CodNegociacao
                objNegociacaoCliente.Buscar()
                codFunil = IIf(String.IsNullOrEmpty(objNegociacaoCliente.CodFunil), "0", objNegociacaoCliente.CodFunil)
                objFunil.Empresa = Session("GlEmpresa")
                objFunil.Codigo = codFunil
                If objFunil.Buscar() Then
                    LblEquipamento.Visible = (objFunil.OcultarEquipamento <> "S")
                    DdlEquipamento.Visible = (objFunil.OcultarEquipamento <> "S")
                    BtnIncluirEquipamento.Visible = (objFunil.OcultarEquipamento <> "S")
                    BtnAlterarEquipamento.Visible = (objFunil.OcultarEquipamento <> "S")
                    BtnPesquisarEquipamento.Visible = (objFunil.OcultarEquipamento <> "S")
                End If

            Else
                ChecaAlteracaoNumeroSerie()
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
                        CodItemMudou()
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
        Dim objChamado As New UCLAtendimento(StrConexao)
        Dim codClienteAtendimento As String
        Dim numeroPontoAtendimento As String
        Try
            Call CarregaDescricaoItem()

            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                ObjNegociacao.Empresa = Session("GlEmpresa")
                ObjNegociacao.Estabelecimento = Session("GlEstabelecimento")
                ObjNegociacao.CodNegociacao = CodNegociacao
                ObjNegociacao.Buscar()

                If Not String.IsNullOrEmpty(ObjNegociacao.CodChamado) Then
                    objChamado.Empresa = ObjNegociacao.Empresa
                    objChamado.CodChamado = ObjNegociacao.CodChamado
                    objChamado.Buscar()

                    codClienteAtendimento = objChamado.CodEmitenteAtendimento
                    numeroPontoAtendimento = objChamado.NumeroPontoAtendimento
                Else
                    codClienteAtendimento = ""
                    numeroPontoAtendimento = ""
                End If

                TxtPrecoUnitario.Text = objItem.PrecoItemCliente(Session("GlEmpresa"), Session("GlEstabelecimento"), LblCodEmitente.Text, LblCNPJ.Text, TxtCodItem.Text, codClienteAtendimento, numeroPontoAtendimento).ToString("F4")
                TxtValorDesconto.Text = 0
                TxtNarrativa.Text = objItem.GetNarrativa(TxtCodItem.Text)
                Call CarregaUnidades()
                Session("SCodItemPesquisado") = TxtCodItem.Text

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
        objNegociacaoItem.Referencia = DdlReferencia.SelectedValue
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
        objNegociacaoItem.PrazoEntrega = TxtPrazoEntrega.Text
        objNegociacaoItem.TpPrazoEntrega = DdlTpPrazoEntrega.SelectedValue

        If DdlEquipamento.SelectedValue = "-1" OrElse DdlEquipamento.SelectedValue = "0" Then
            objNegociacaoItem.NumeroSerie = ""
        Else
            objNegociacaoItem.NumeroSerie = DdlEquipamento.SelectedValue
        End If

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
            If Gravar() Then
                Response.Redirect("WGNegociacaoItem.aspx")
            End If
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
            objCalculoImposto.Quantidade = Quantidade
            objCalculoImposto.QuantidadeUD = QuantidadeUD
            objCalculoImposto.PrecoUnitario = CDbl(TxtPrecoUnitario.Text) + GetTotalOpcionais()
            objCalculoImposto.PrecoUnitarioUD = CDbl(LblValorUD.Text)
            objCalculoImposto.ValorDesconto = CDbl(TxtValorDesconto.Text)
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
        CarregaEquipamentoCliente(objNegociacaoItem.NumeroSerie)
        DdlEquipamento.SelectedValue =
        TxtPrazoEntrega.Text = objNegociacaoItem.PrazoEntrega
        DdlTpPrazoEntrega.SelectedValue = objNegociacaoItem.TpPrazoEntrega
        Session("SNumeroSerieItemPedido") = objNegociacaoItem.NumeroSerie
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
        TxtQuantidadeUD.Text = CalculaQuantidade_Unidade_UD(Quantidade, QuantidadeUD, TipoQuantidadeCalcular.QtdUD, TxtCodItem.Text, "").ToString("F4")
        TxtQuantidadeUD.DataBind()
    End Sub

    Protected Sub TxtQuantidadeUD_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtQuantidadeUD.TextChanged
        TxtQuantidade.Text = CalculaQuantidade_Unidade_UD(Quantidade, QuantidadeUD, TipoQuantidadeCalcular.QtdPedida, TxtCodItem.Text, "").ToString("F4")
        TxtQuantidade.DataBind()
    End Sub

    Protected Sub DdlUD_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlUD.SelectedIndexChanged
        TxtQuantidadeUD.Text = CalculaQuantidade_Unidade_UD(Quantidade, QuantidadeUD, TipoQuantidadeCalcular.QtdUD, TxtCodItem.Text, "").ToString("F4")
        TxtQuantidadeUD.DataBind()
    End Sub

    Protected Sub BtnIncluirOpcional_Click(sender As Object, e As EventArgs) Handles BtnIncluirOpcional.Click

    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            Dim ObjNegociacaoClienteItemEstrutura As New UCLNegociacaoItemEstrutura(StrConexaoUsuario(Session("GlUsuario")))
            If e.CommandName = "EXCLUIR" Then
                ObjNegociacaoClienteItemEstrutura.Empresa = Session("GlEmpresa")
                ObjNegociacaoClienteItemEstrutura.Estabelecimento = Session("SEstabelecimentoNegociacao")
                ObjNegociacaoClienteItemEstrutura.CodNegociacaoCliente = Session("SCodNegociacao")
                ObjNegociacaoClienteItemEstrutura.SeqItem = Session("SSeqItemNegociacao")
                ObjNegociacaoClienteItemEstrutura.SeqItemEstrutura = e.CommandArgument
                ObjNegociacaoClienteItemEstrutura.Excluir()

                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()

                Call CalculaTotais()
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

            Call CalculaTotais()
            If Not String.IsNullOrEmpty(TxtCodItem.Text) And Not Quantidade = 0 Then
                Call Gravar()
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub DdlEquipamento_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlEquipamento.SelectedIndexChanged
        Try
            Session("SNumeroSerieItemPedido") = DdlEquipamento.SelectedValue
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

End Class