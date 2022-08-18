Partial Public Class WUCNegociacaoItem_Grade
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objNatureza As New UCLNaturezaOperacao
        Dim objItem As New UCLItem

        TxtQuantidade.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")
        TxtQuantidade.Attributes.Add("OnBlur", "submit();")
        TxtQuantidadeUD.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")
        TxtQuantidadeUD.Attributes.Add("OnBlur", "submit();")

        Try
            If Not IsPostBack Then
                objNatureza.FillDropDown(DdlNaturOper, True, "")
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                    BtnIncluirReferencia.Enabled = True
                Else
                    Call CarregaNovaPK()
                End If
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
                        If objItem.GetComGrade(TxtCodItem.Text) = "S" Then
                            Session("SReferenciaPesquisada") = ""
                            DdlReferencia.SelectedValue = ""
                            DdlReferencia.Visible = False
                            LblReferencia.Visible = False
                            BtnFiltrarReferencia.Visible = False
                            Call MostraGridReferencias(True)
                            TxtQuantidade.Enabled = False
                            TxtQuantidadeUD.Enabled = False
                        Else
                            DdlReferencia.SelectedValue = Session("SReferenciaPesquisada")
                            DdlReferencia.Visible = True
                            LblReferencia.Visible = True
                            BtnFiltrarReferencia.Visible = True
                            Call MostraGridReferencias(False)
                            TxtQuantidade.Enabled = True
                            TxtQuantidadeUD.Enabled = True
                        End If
                        CodItemMudou()
                        Session("SNAlterouCodItem") = Session("SNAlterouCodItem") + 1
                    End If
                    If Session("SNAlterouCodItem") > 1 Then
                        Session("SAlterouCodItem") = "N"
                        Session("SNAlterouCodItem") = 0
                    End If
                End If
            End If

            If Not String.IsNullOrEmpty(Session("SReferenciaPesquisada")) Then
                If Session("SNAlterouReferencia") Is Nothing Then
                    Session("SNAlterouReferencia") = 0
                End If
                If Not IsNumeric(Session("SNAlterouReferencia")) Then
                    Session("SNAlterouReferencia") = 0
                End If
                If Session("SAlterouReferencia") = "S" Then
                    If DdlReferencia.SelectedValue <> Session("SReferenciaPesquisada") Then
                        DdlReferencia.SelectedValue = Session("SReferenciaPesquisada")
                        Session("SNAlterouReferencia") = Session("SNAlterouReferencia") + 1
                    End If
                    If Session("SNAlterouReferencia") > 1 Then
                        Session("SAlterouReferencia") = "N"
                        Session("SNAlterouReferencia") = 0
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

        Try
            Call CarregaDescricaoItem()

            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
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

                If objItem.GetComGrade(TxtCodItem.Text) = "S" Then
                    DdlReferencia.SelectedValue = ""
                    DdlReferencia.Visible = False
                    LblReferencia.Visible = False
                    BtnFiltrarReferencia.Visible = False
                    Call MostraGridReferencias(True)
                    Call CarregaDdlReferencias(TxtCodItem.Text, "")
                    TxtQuantidade.Enabled = False
                    TxtQuantidadeUD.Enabled = False
                Else
                    DdlReferencia.Visible = True
                    LblReferencia.Visible = True
                    BtnFiltrarReferencia.Visible = True
                    Call MostraGridReferencias(False)
                    Call CarregaDdlReferencias(TxtCodItem.Text, DdlReferencia.SelectedValue)
                    TxtQuantidade.Enabled = True
                    TxtQuantidadeUD.Enabled = True
                End If

                Call CalculaTotais()
                Call Gravar()
            Else
                Call CarregaDdlReferencias("", "")
            End If

            Dim objNegociacaoItemProgramacao As New UCLNegociacaoItemProgramacao
            objNegociacaoItemProgramacao.Excluir(Session("GlEmpresa"), Session("GlEstabelecimento"), CodNegociacao, LblSeqItem.Text)
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

        If String.IsNullOrEmpty(TxtPrecoUnitario.Text) Then
            LblErro.Text += "Preencha o campo Preço Unitário.<br/>"
        End If

        If Not IsNumeric(TxtPrecoUnitario.Text) Then
            LblErro.Text += "Preencha corretamente campo Preço Unitário.<br/>"
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
                    BtnIncluirReferencia.Enabled = True
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
            Dim lAcao As String = Acao
            Call Gravar()
            If lAcao = "ALTERAR" Then
                LblErro.Text = "Dados foram salvos com sucesso."
            ElseIf lAcao = "INCLUIR" Then
                LblErro.Text = "Dados foram incluídos com sucesso."
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
        Dim objItem As New UCLItem
        objNegociacaoItem.Empresa = Session("GlEmpresa")
        objNegociacaoItem.Estabelecimento = Session("GlEstabelecimento")
        objNegociacaoItem.CodNegociacao = CodNegociacao
        objNegociacaoItem.SeqItem = SeqItem
        objNegociacaoItem.Buscar()
        LblSeqItem.Text = objNegociacaoItem.SeqItem
        TxtCodItem.Text = objNegociacaoItem.CodItem
        Call CarregaDdlReferencias(objNegociacaoItem.CodItem, objNegociacaoItem.Referencia)
        DdlReferencia.SelectedValue = objNegociacaoItem.Referencia
        Session("SCodItemPesquisado") = TxtCodItem.Text
        Session("SReferenciaPesquisada") = objNegociacaoItem.Referencia
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
        If objItem.GetComGrade(TxtCodItem.Text) = "S" Then
            DdlReferencia.Visible = False
            LblReferencia.Visible = False
            BtnFiltrarReferencia.Visible = False
            Call MostraGridReferencias(True)
            TxtQuantidade.Enabled = False
            TxtQuantidadeUD.Enabled = False
        Else
            DdlReferencia.Visible = True
            LblReferencia.Visible = True
            BtnFiltrarReferencia.Visible = True
            Call MostraGridReferencias(False)
            TxtQuantidade.Enabled = True
            TxtQuantidadeUD.Enabled = True
        End If
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

    Private Enum TipoAlteracaoQuantidade
        Pedida = 1
        UD = 2
    End Enum

    Private Sub AlterouQuantidade(tipo As TipoAlteracaoQuantidade)
        Try
            If tipo = TipoAlteracaoQuantidade.Pedida Then
                TxtQuantidadeUD.Text = CalculaQuantidade_Unidade_UD(Quantidade, QuantidadeUD, TipoQuantidadeCalcular.QtdUD, TxtCodItem.Text, "").ToString("F4")
                TxtQuantidadeUD.DataBind()
            ElseIf tipo = TipoAlteracaoQuantidade.UD Then
                TxtQuantidade.Text = CalculaQuantidade_Unidade_UD(Quantidade, QuantidadeUD, TipoQuantidadeCalcular.QtdPedida, TxtCodItem.Text, "").ToString("F4")
                TxtQuantidade.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtQuantidade_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtQuantidade.TextChanged
        Call AlterouQuantidade(TipoAlteracaoQuantidade.Pedida)
    End Sub

    Protected Sub TxtQuantidadeUD_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtQuantidadeUD.TextChanged
        Call AlterouQuantidade(TipoAlteracaoQuantidade.UD)
    End Sub

    Protected Sub DdlUD_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlUD.SelectedIndexChanged
        Call AlterouQuantidade(TipoAlteracaoQuantidade.Pedida)
    End Sub

    Protected Sub BtnIncluirOpcional_Click(sender As Object, e As EventArgs) Handles BtnIncluirReferencia.Click

    End Sub



    Protected Sub BtnAtualizarGrid_Click(sender As Object, e As EventArgs) Handles BtnAtualizarGrid.Click
        Try
            LblErro.Text = ""
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
            Call AtualizaQuantidadeDeAcordoComAsProgramacoes()
            Call AlterouQuantidade(TipoAlteracaoQuantidade.Pedida)
            Call CalculaTotais()
            Call Gravar()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub AtualizaQuantidadeDeAcordoComAsProgramacoes()
        Try
            Dim objNegociacaoClienteItemProgramacao As New UCLNegociacaoItemProgramacao
            TxtQuantidade.Text = objNegociacaoClienteItemProgramacao.GetQuantidadeTotalItem(Session("GlEmpresa"), Session("GlEstabelecimento"), Session("SCodNegociacao"), Session("SSeqItemNegociacao")).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MostraGridReferencias(ByVal mostra As Boolean)
        Try
            LblCoresTamanhos.Visible = mostra
            BtnIncluirReferencia.Visible = mostra
            GridView1.Visible = mostra
            BtnAtualizarGrid.Visible = mostra
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaDdlReferencias(ByVal pCodItem As String, ByVal pReferencia As String)
        Try
            Dim StrSql As String = ""
            Dim dt, dtaux As DataTable
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)

            StrSql += "select r.cod_referencia, r.descricao "
            StrSql += "  from referencia r inner join item_referencia ir on ir.cod_referencia = r.cod_referencia"
            StrSql += " where ir.cod_item = '" + pCodItem + "'"
            StrSql += " order by r.descricao"

            dt = objAcessoDados.BuscarDados(StrSql)

            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_referencia") = ""
            NovaLinha("descricao") = ""
            dt.Rows.InsertAt(NovaLinha, 0)

            If pReferencia.Trim <> "" Then
                StrSql = ""
                StrSql += "select r.cod_referencia, r.descricao "
                StrSql += "  from referencia r inner join item_referencia ir on ir.cod_referencia = r.cod_referencia"
                StrSql += " where ir.cod_item = '" + pCodItem + "'"
                StrSql += "   and ir.cod_referencia = '" + pReferencia + "'"
                dtaux = objAcessoDados.BuscarDados(StrSql)

                If dtaux.Rows.Count = 0 Then
                    NovaLinha = dt.NewRow
                    NovaLinha("cod_referencia") = pReferencia
                    NovaLinha("descricao") = pReferencia
                    dt.Rows.InsertAt(NovaLinha, 0)
                End If
            End If

            DdlReferencia.DataSource = dt
            DdlReferencia.DataTextField = "descricao"
            DdlReferencia.DataValueField = "cod_referencia"
            DdlReferencia.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound
        If GridView1.Rows.Count > 0 Then
            For i As Int16 = 1 To 35
                If CType(GridView1.Rows.Item(0).FindControl("LblVisibleTam" + i.ToString), Label).Text = "false" Then
                    GridView1.Columns.Item(i).Visible = False
                Else
                    CType(GridView1.HeaderRow.FindControl("LblTituloTam" + i.ToString), Label).Text = CType(GridView1.Rows.Item(0).FindControl("LblTam" + i.ToString), Label).Text
                End If
            Next
        End If
    End Sub
End Class