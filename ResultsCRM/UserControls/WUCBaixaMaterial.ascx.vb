Partial Public Class WUCBaixaMaterial
    Inherits System.Web.UI.UserControl

    Private _empresa As String
    Private _estabelecimento As String
    Private _codPedidoVenda As String
    Private _codSolicitacao As String
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

    Public Property CodSolicitacao() As String
        Get
            Return _codSolicitacao
        End Get
        Set(ByVal value As String)
            _codSolicitacao = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("STipoMaterialBaixa") IsNot Nothing AndAlso Session("STipoMaterialBaixa") = "C" Then
                    DdlTipoMaterial.SelectedValue = "C"
                    Call TipoMaterialMudou()
                End If
                Call Carregar()
            End If

            If Not String.IsNullOrEmpty(Session("SCodItemPesquisado")) Then
                If Session("SAlterouCodItem") = "S" Then
                    If TxtCodItemRetorno.Text <> Session("SCodItemPesquisado") Then
                        TxtCodItemRetorno.Text = Session("SCodItemPesquisado")
                        Call CodItemRetornoMudou()
                    End If
                    Session("SAlterouCodItem") = "N"
                End If
            End If

            If Not String.IsNullOrEmpty(Session("SLotePesquisado")) Then
                If Session("SAlterouLote") = "S" Then
                    If TxtLoteBaixa.Text <> Session("SLotePesquisado") Then
                        TxtLoteBaixa.Text = Session("SLotePesquisado")
                        Call LoteMudou()
                        Call VerificaLoteBaixa(False)
                    End If
                    Session("SAlterouLote") = "N"
                End If
            End If

            If IsPostBack Then
                Call CarregaDescricaoItemRetorno()
            End If

            TxtQuantidadeBaixa.Attributes.Add("OnFocus", "selecionaCampo(this)")

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub Carregar()
        Try
            Call CarregaEstabelecimento()
            Call CarregaAgenteTecnico()
            Call CarregaFormulario()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Try
            Call Transferencia_Mudou()
            Call CarregaDescricaoItemRetorno()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CodItemRetornoMudou()
        Try
            Call CarregaDescricaoItemRetorno()

            If Not String.IsNullOrEmpty(TxtCodItemRetorno.Text) Then
                Session("SCodItemPesquisado") = TxtCodItemRetorno.Text
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoteMudou()
        Try
            If Not String.IsNullOrEmpty(TxtLoteBaixa.Text) Then
                Session("SLotePesquisado") = TxtLoteBaixa.Text
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
            Dim objTransferenciaTecnicoBaixa As New UCLTransferenciaTecnicoBaixa(StrConexaoUsuario(Session("GlUsuario")))
            Dim objTransferenciaTecnicoRemessa As New UCLTransferenciaTecnicoRemessa(StrConexaoUsuario(Session("GlUsuario")))
            If IsDigitacaoOK() Then
                objTransferenciaTecnicoRemessa.empresa = Empresa
                objTransferenciaTecnicoRemessa.estabelecimento = Estabelecimento
                objTransferenciaTecnicoRemessa.cod_transferencia = LblCodTransferencia.Text
                objTransferenciaTecnicoRemessa.seq_transferencia = LblSeqItemTransferencia.Text
                objTransferenciaTecnicoRemessa.Buscar()

                If Not IsNumeric(TxtQuantidadeBaixa.Text) Then
                    Throw New Exception("Informe corretamente a quantidade instalada.")
                Else
                    If CDbl(TxtQuantidadeBaixa.Text) <= 0 Then
                        Throw New Exception("Qtde. instalada deve ser maior do que 0,00.")
                    End If
                    If IsNumeric(objTransferenciaTecnicoRemessa.quantidade_pendente) Then
                        If CDbl(objTransferenciaTecnicoRemessa.quantidade_pendente) < CDbl(TxtQuantidadeBaixa.Text) Then
                            Throw New Exception("Qtde. instalada não pode ser maior do que " + objTransferenciaTecnicoRemessa.quantidade_pendente + ".")
                        End If
                    End If
                End If

                objTransferenciaTecnicoBaixa.empresa = Empresa
                objTransferenciaTecnicoBaixa.estabelecimento = Estabelecimento
                objTransferenciaTecnicoBaixa.cod_transferencia = LblCodTransferencia.Text
                objTransferenciaTecnicoBaixa.seq_transferencia = LblSeqItemTransferencia.Text
                objTransferenciaTecnicoBaixa.seq_baixa = objTransferenciaTecnicoBaixa.GetProximoCodigo()
                objTransferenciaTecnicoBaixa.cod_item = LblCodItem.Text
                objTransferenciaTecnicoBaixa.quantidade = TxtQuantidadeBaixa.Text
                objTransferenciaTecnicoBaixa.lote = LblLote.Text
                objTransferenciaTecnicoBaixa.referencia = ""
                objTransferenciaTecnicoBaixa.cod_usuario = Session("GlCodUsuario")
                objTransferenciaTecnicoBaixa.cod_pedido_venda = CodPedidoVenda
                objTransferenciaTecnicoBaixa.Incluir()
                If ChkGerarRetorno.Checked Then
                    Dim objTransferenciaTecnicoInstalacaoRetorno As New UCLTransferenciaTecnicoInstalacaoRetorno(StrConexaoUsuario(Session("GlUsuario")))
                    objTransferenciaTecnicoInstalacaoRetorno.empresa = objTransferenciaTecnicoBaixa.empresa
                    objTransferenciaTecnicoInstalacaoRetorno.estabelecimento = objTransferenciaTecnicoBaixa.estabelecimento
                    objTransferenciaTecnicoInstalacaoRetorno.cod_transferencia = objTransferenciaTecnicoBaixa.cod_transferencia
                    objTransferenciaTecnicoInstalacaoRetorno.seq_transferencia = objTransferenciaTecnicoBaixa.seq_transferencia
                    objTransferenciaTecnicoInstalacaoRetorno.seq_retorno = objTransferenciaTecnicoInstalacaoRetorno.GetProximoCodigo()
                    objTransferenciaTecnicoInstalacaoRetorno.seq_baixa_origem = objTransferenciaTecnicoBaixa.seq_baixa
                    objTransferenciaTecnicoInstalacaoRetorno.cod_pedido_venda = objTransferenciaTecnicoBaixa.cod_pedido_venda
                    objTransferenciaTecnicoInstalacaoRetorno.cod_usuario = objTransferenciaTecnicoBaixa.cod_usuario
                    objTransferenciaTecnicoInstalacaoRetorno.cod_item_baixa = objTransferenciaTecnicoBaixa.cod_item
                    objTransferenciaTecnicoInstalacaoRetorno.quantidade_baixa = objTransferenciaTecnicoBaixa.quantidade
                    objTransferenciaTecnicoInstalacaoRetorno.lote_baixa = objTransferenciaTecnicoBaixa.lote
                    objTransferenciaTecnicoInstalacaoRetorno.referencia_baixa = objTransferenciaTecnicoBaixa.referencia
                    objTransferenciaTecnicoInstalacaoRetorno.cod_item_retorno = TxtCodItemRetorno.Text
                    objTransferenciaTecnicoInstalacaoRetorno.quantidade_retorno = objTransferenciaTecnicoBaixa.quantidade
                    objTransferenciaTecnicoInstalacaoRetorno.lote_retorno = TxtLoteRetorno.Text
                    objTransferenciaTecnicoInstalacaoRetorno.referencia_retorno = ""
                    objTransferenciaTecnicoInstalacaoRetorno.Incluir()
                End If
                If ChkGerarSolicitacaoMaterialTecnico.Checked Then
                    Dim objTransferenciaTecnicoPendenciaSolicitacao As New UCLTransferenciaTecnicoPendenciaSolicitacao(StrConexaoUsuario(Session("GlUsuario")))
                    objTransferenciaTecnicoPendenciaSolicitacao.empresa = objTransferenciaTecnicoBaixa.empresa
                    objTransferenciaTecnicoPendenciaSolicitacao.estabelecimento = objTransferenciaTecnicoBaixa.estabelecimento
                    objTransferenciaTecnicoPendenciaSolicitacao.cod_transferencia = objTransferenciaTecnicoBaixa.cod_transferencia
                    objTransferenciaTecnicoPendenciaSolicitacao.seq_transferencia = objTransferenciaTecnicoBaixa.seq_transferencia
                    objTransferenciaTecnicoPendenciaSolicitacao.seq_pendencia = objTransferenciaTecnicoPendenciaSolicitacao.GetProximoCodigo()
                    objTransferenciaTecnicoPendenciaSolicitacao.seq_baixa = objTransferenciaTecnicoBaixa.seq_baixa
                    objTransferenciaTecnicoPendenciaSolicitacao.cod_pedido_venda = objTransferenciaTecnicoBaixa.cod_pedido_venda
                    objTransferenciaTecnicoPendenciaSolicitacao.cod_usuario = objTransferenciaTecnicoBaixa.cod_usuario
                    objTransferenciaTecnicoPendenciaSolicitacao.cod_item = objTransferenciaTecnicoBaixa.cod_item
                    objTransferenciaTecnicoPendenciaSolicitacao.quantidade = objTransferenciaTecnicoBaixa.quantidade
                    objTransferenciaTecnicoPendenciaSolicitacao.lote = objTransferenciaTecnicoBaixa.lote
                    objTransferenciaTecnicoPendenciaSolicitacao.referencia = objTransferenciaTecnicoBaixa.referencia
                    objTransferenciaTecnicoPendenciaSolicitacao.Incluir()
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub Executa_BtnSalvar()
        Try
            If Salvar() Then
                Response.Redirect(CaminhoVoltar)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Call Executa_BtnSalvar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Function IsDigitacaoOK() As Boolean

        Try
            LblErro.Text = ""

            If String.IsNullOrWhiteSpace(LblCodItem.Text) Then
                LblErro.Text += "Escolha na lista o material.<br/>"
            End If

            Return LblErro.Text = ""
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub CarregaDescricaoItemRetorno()
        Try
            Dim objItem As New UCLItem
            If Not String.IsNullOrEmpty(TxtCodItemRetorno.Text) Then
                objItem.CodItem = TxtCodItemRetorno.Text
                objItem.Buscar()
                LblDescricaoItem.Text = objItem.Descricao
            Else
                LblDescricaoItem.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaEstabelecimento()
        Try
            Dim objEstabelecimento As New UCLEstabelecimento
            objEstabelecimento.CodEmpresa = Empresa
            objEstabelecimento.FillDropDown(DdlEstabelecimento, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaAgenteTecnico()
        Try
            Dim objAgenteTecnico As New UCLAgenteTecnico
            objAgenteTecnico.FillDropDown(DdlAgenteTecnico, False, "", "", Session("GlEmpresa"), DdlEstabelecimento.SelectedValue, CodPedidoVenda)
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            DdlTransferencia.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlAgenteTecnico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlAgenteTecnico.SelectedIndexChanged
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        DdlTransferencia.DataBind()
        Call Transferencia_Mudou()
    End Sub

    Protected Sub DdlTransferencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlTransferencia.SelectedIndexChanged
        Try
            Call Transferencia_Mudou()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Transferencia_Mudou()
        Try
            Dim CodTransferencia As String
            Dim SeqItemTransferencia As String
            Dim Chave As String
            Dim objTransferenciaRemessa As New UCLTransferenciaTecnicoRemessa(StrConexaoUsuario(Session("GlUsuario")))

            Chave = DdlTransferencia.SelectedValue

            If Chave.Contains(";") Then
                CodTransferencia = Chave.Substring(0, Chave.IndexOf(";"))
                SeqItemTransferencia = Chave.Substring(Chave.IndexOf(";") + 1)

                LblCodTransferencia.Text = CodTransferencia
                LblSeqItemTransferencia.Text = SeqItemTransferencia

                objTransferenciaRemessa.empresa = Empresa
                objTransferenciaRemessa.estabelecimento = DdlEstabelecimento.SelectedValue
                objTransferenciaRemessa.cod_transferencia = CodTransferencia
                objTransferenciaRemessa.seq_transferencia = SeqItemTransferencia
                objTransferenciaRemessa.Buscar()

                LblCodItem.Text = objTransferenciaRemessa.cod_item
                If DdlTipoMaterial.SelectedValue = "R" Then
                    TxtQuantidadeBaixa.Text = objTransferenciaRemessa.quantidade
                Else
                    TxtQuantidadeBaixa.Text = objTransferenciaRemessa.quantidade_pendente
                End If
                LblLote.Text = objTransferenciaRemessa.lote
                Call CarregaDescricaoItemRetorno()
            Else
                CodTransferencia = "0"
                SeqItemTransferencia = "0"
                LblCodItem.Text = ""
                LblDescricaoItem.Text = ""
                TxtQuantidadeBaixa.Text = ""
                LblCodTransferencia.Text = "0"
                LblSeqItemTransferencia.Text = "0"
                LblLote.Text = ""
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ChkGerarRetorno.CheckedChanged
        TxtCodItemRetorno.Visible = ChkGerarRetorno.Checked
        BtnFiltrarItem.Visible = ChkGerarRetorno.Checked
        LblDescricaoItem.Visible = ChkGerarRetorno.Checked
        Lbl_1.Visible = ChkGerarRetorno.Checked
        Lbl_2.Visible = ChkGerarRetorno.Checked
        TxtLoteRetorno.Visible = ChkGerarRetorno.Checked
    End Sub

    Private Sub TipoMaterialMudou()
        If DdlTipoMaterial.SelectedValue = "R" Then
            TxtLoteBaixa.Visible = True
            LblLabelLoteBaixa.Visible = True
            TxtQuantidadeBaixa.Visible = False
            Lbl_3.Visible = False
            Session("STipoMaterialBaixa") = "R"
            ChkGerarRetorno.Visible = True
            ChkGerarSolicitacaoMaterialTecnico.Visible = False
            LblSeqItemTransferencia.Width = New System.Web.UI.WebControls.Unit(235, UnitType.Pixel)
        Else
            TxtLoteBaixa.Visible = False
            LblLabelLoteBaixa.Visible = False
            TxtQuantidadeBaixa.Visible = True
            Lbl_3.Visible = True
            Session("STipoMaterialBaixa") = "C"
            ChkGerarRetorno.Visible = False
            ChkGerarSolicitacaoMaterialTecnico.Visible = True
            LblSeqItemTransferencia.Width = New System.Web.UI.WebControls.Unit(87, UnitType.Pixel)
        End If
        TxtLoteBaixa.Text = ""
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        DdlTransferencia.DataBind()
        Call Transferencia_Mudou()
    End Sub

    Protected Sub DdlTipoMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlTipoMaterial.SelectedIndexChanged
        Call TipoMaterialMudou()
    End Sub

    Public Sub VerificaLoteBaixa(ByVal efetivar As Boolean)
        Try
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            DdlTransferencia.DataBind()
            Call Transferencia_Mudou()
            If Not String.IsNullOrWhiteSpace(TxtLoteBaixa.Text) Then
                If DdlTransferencia.Items.Count = 1 Then
                    If efetivar Then
                        Call Executa_BtnSalvar()
                    End If
                ElseIf DdlTransferencia.Items.Count = 0 Then
                    LblErro.Text = "Lote de Material informado não existe para o técnico."
                Else
                    LblErro.Text = "O sistema encontrou mais de uma solicitação para o lote informado. Selecione abaixo o material solicitado e clique em Registrar."
                End If
            Else
                LblErro.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtLoteBaixa_TextChanged(sender As Object, e As EventArgs) Handles TxtLoteBaixa.TextChanged
        Try
            Call VerificaLoteBaixa(True)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class