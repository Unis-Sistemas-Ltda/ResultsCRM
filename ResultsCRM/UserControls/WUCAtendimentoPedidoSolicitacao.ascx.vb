Partial Public Class WUCAtendimentoPedidoSolicitacao
    Inherits System.Web.UI.UserControl

    Private _empresa As String
    Private _estabelecimento As String
    Private _codPedidoVenda As String
    Private _seqSolicitacao As String
    Private _acao As String
    Private _camVoltar As String

    Public Property MostraBotaoVoltar As Boolean = False

    Public Property CaminhoVoltar() As String
        Set(ByVal value As String)
            _camVoltar = value
        End Set
        Get
            Return _camVoltar
        End Get
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

    Public Property SeqSolicitacao() As String
        Get
            Return _seqSolicitacao
        End Get
        Set(ByVal value As String)
            _seqSolicitacao = value
        End Set
    End Property

    Public Property Acao() As String
        Get
            Return _acao
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "INCLUIR"
                    LblAcao.Text = "INCLUSÃO"
                Case "ALTERAR"
                    LblAcao.Text = "ALTERAÇÃO"
            End Select
            _acao = value
        End Set
    End Property

    Public Sub Carregar()
        Try
            If Session("GlClienteUnis") = 702 Then
                LblEquipamentoLabel.Text = "Equipamento:"
                BtnIncluirEquipamento.ToolTip = "Incluir Equipamento"
                BtnIncluirEquipamento.AlternateText = BtnIncluirEquipamento.ToolTip
                BtnAlterarEquipamento.ToolTip = "Alterar informações do Equipamento"
                BtnIncluirEquipamento.AlternateText = "Alterar informações do Equipamento"
                BtnPesquisarEquipamento.ToolTip = "Pesquisar Equipamento"
                BtnPesquisarEquipamento.AlternateText = BtnPesquisarEquipamento.ToolTip
                BtnIncluirEquipamento.OnClientClick = "ShowEditModal('../Forms/WFEquipamento2.aspx?aid=I','EditModalPopupClientes','IframeEdit');"
                BtnAlterarEquipamento.OnClientClick = "ShowEditModal('../Forms/WFEquipamento2.aspx?aid=A','EditModalPopupClientes','IframeEdit');"
                BtnPesquisarEquipamento.OnClientClick = "ShowEditModal('../Pesquisas/WFPEquipamento2.aspx','EditModalPopupClientes','IframeEdit');"
            ElseIf Session("GlTipoFaturamento").ToString = "G" Then
                LblEquipamentoLabel.Text = "Produto:"
                BtnIncluirEquipamento.ToolTip = "Incluir Produto"
                BtnIncluirEquipamento.AlternateText = BtnIncluirEquipamento.ToolTip
                BtnAlterarEquipamento.ToolTip = "Alterar informações do Produto"
                BtnIncluirEquipamento.AlternateText = "Alterar Produto"
                BtnPesquisarEquipamento.ToolTip = "Pesquisar Produto"
                BtnPesquisarEquipamento.AlternateText = BtnPesquisarEquipamento.ToolTip
                LblComponenteLabel.Visible = False
                DdlComponente.Visible = False
                BtnIncluir.Visible = False
                GridView1.Visible = False
                BtnIncluirEquipamento.OnClientClick = "ShowEditModal('../Forms/WFEquipamento2.aspx?aid=I','EditModalPopupClientes','IframeEdit');"
                BtnAlterarEquipamento.OnClientClick = "ShowEditModal('../Forms/WFEquipamento2.aspx?aid=A','EditModalPopupClientes','IframeEdit');"
                BtnPesquisarEquipamento.OnClientClick = "ShowEditModal('../Pesquisas/WFPEquipamento2.aspx','EditModalPopupClientes','IframeEdit');"
            End If


            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
                BtnSalvar.Text = "Salvar alteração"
            Else
                Call CarregaEquipamentoCliente("0")
                Call CarregaNovaPK()
                BtnSalvar.Text = "Incluir"
            End If
            Call CarregaListaServicos()
            If MostraBotaoVoltar Then
                BtnVoltar.Visible = True
            Else
                BtnVoltar.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call Carregar()
            End If

            If IsPostBack Then
                Call ChecaAlteracaoNumeroSerie()
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim objPedidoSolicitacao As New UCLPedidoVendaSolicitacao(StrConexaoUsuario(Session("GlUsuario")))
            objPedidoSolicitacao.empresa = Empresa
            objPedidoSolicitacao.estabelecimento = Estabelecimento
            objPedidoSolicitacao.codPedidoVenda = CodPedidoVenda
            objPedidoSolicitacao.SeqSolicitacao = SeqSolicitacao
            objPedidoSolicitacao.Buscar()

            LblSeqSolicitacao.Text = SeqSolicitacao
            TxtServicoSolicitado.Text = objPedidoSolicitacao.ServicoSolicitado
            Call CarregaEquipamentoCliente(objPedidoSolicitacao.NumeroSerie)
            DdlEquipamento.SelectedValue = objPedidoSolicitacao.NumeroSerie
            Call CarregaComponentes()

            Session("SNumeroSerieItemPedido") = objPedidoSolicitacao.NumeroSerie
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function Salvar() As Boolean
        Try
            Dim objPedidoSolicitacao As New UCLPedidoVendaSolicitacao(StrConexaoUsuario(Session("GlUsuario")))
            If IsDigitacaoOK() Then
                objPedidoSolicitacao.Empresa = Empresa
                objPedidoSolicitacao.Estabelecimento = Estabelecimento
                objPedidoSolicitacao.CodPedidoVenda = CodPedidoVenda
                objPedidoSolicitacao.SeqSolicitacao = LblSeqSolicitacao.Text
                Acao = "ALTERAR"
                If Not objPedidoSolicitacao.Buscar() Then
                    Call CarregaNovaPK()
                    objPedidoSolicitacao.Empresa = Empresa
                    objPedidoSolicitacao.Estabelecimento = Estabelecimento
                    objPedidoSolicitacao.CodPedidoVenda = CodPedidoVenda
                    objPedidoSolicitacao.SeqSolicitacao = LblSeqSolicitacao.Text
                    Acao = "INCLUIR"
                End If
                Call CarregaObjeto(objPedidoSolicitacao)
                If Acao = "ALTERAR" Then
                    objPedidoSolicitacao.Alterar()
                    Call GravaListaServicos()
                    Return True
                ElseIf Acao = "INCLUIR" Then
                    objPedidoSolicitacao.Incluir()
                    Session("SAcaoAtPedido") = "ALTERAR"
                    LblSeqSolicitacao.Text = objPedidoSolicitacao.SeqSolicitacao
                    Call GravaListaServicos()
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnSalvar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSalvar.Click
        Try
            If Salvar() Then
                Response.Redirect(CaminhoVoltar)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Function IsDigitacaoOK() As Boolean

        Try
            LblErro.Text = ""

            'testes aqui

            Return LblErro.Text = ""
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub CarregaObjeto(ByRef objPedidoVendaSolicitacao As UCLPedidoVendaSolicitacao)
        Try
            Dim objParametrosManutencao As New UCLParametrosManutencao
            objParametrosManutencao.Buscar(Empresa, Estabelecimento)
            objPedidoVendaSolicitacao.NumeroSerie = DdlEquipamento.SelectedValue
            If objParametrosManutencao.GetConteudo("descricao_servico_maiusculo") = "S" Then
                objPedidoVendaSolicitacao.ServicoSolicitado = TxtServicoSolicitado.Text.ToUpper
            Else
                objPedidoVendaSolicitacao.ServicoSolicitado = TxtServicoSolicitado.Text
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
                Call CarregaComponentes()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Try
            Dim objPedidoSolicitacao As New UCLPedidoVendaSolicitacao(StrConexaoUsuario(Session("GlUsuario")))
            objPedidoSolicitacao.Empresa = Empresa
            objPedidoSolicitacao.Estabelecimento = Estabelecimento
            objPedidoSolicitacao.CodPedidoVenda = CodPedidoVenda
            LblSeqSolicitacao.Text = objPedidoSolicitacao.GetProximoCodigo()
            SeqSolicitacao = LblSeqSolicitacao.Text
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaEquipamentoCliente(ByVal numeroSerieSelecionado As String)
        Try
            Dim objEquipamentoCliente As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objParametrosManutencao As New UCLParametrosManutencao
            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))

            objPedidoVenda.empresa = Empresa
            objPedidoVenda.estabelecimento = Estabelecimento
            objPedidoVenda.codPedidoVenda = CodPedidoVenda
            objPedidoVenda.Buscar()
            If Not String.IsNullOrEmpty(objPedidoVenda.codChamado) Then
                objChamado.Empresa = objPedidoVenda.empresa
                objChamado.CodChamado = objPedidoVenda.codChamado
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

                If Session("GlTipoFaturamento").ToString = "G" OrElse objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 4 Then
                    objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.DescricaoItem, numeroSerieSelecionado)
                Else
                    objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.Observacao, numeroSerieSelecionado)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlEquipamento_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlEquipamento.SelectedIndexChanged
        Try
            Session("SNumeroSerieItemPedido") = DdlEquipamento.SelectedValue
            Call CarregaComponentes()
            Dim objPedidoVendaSolicitacaoEquipamentoComponente As New UCLPedidoVendaSolicitacaoEquipamentoComponente(StrConexaoUsuario(Session("GlUsuario")))
            objPedidoVendaSolicitacaoEquipamentoComponente.Empresa = Empresa
            objPedidoVendaSolicitacaoEquipamentoComponente.Estabelecimento = Estabelecimento
            objPedidoVendaSolicitacaoEquipamentoComponente.CodPedidoVenda = CodPedidoVenda
            objPedidoVendaSolicitacaoEquipamentoComponente.SeqSolicitacao = LblSeqSolicitacao.Text
            objPedidoVendaSolicitacaoEquipamentoComponente.ExcluirTodos()
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub CarregaComponentes()
        Try
            Dim objEquipamentoComponente As New UCLEquipamentoComponente(StrConexaoUsuario(Session("GlUsuario")))
            objEquipamentoComponente.Empresa = Empresa
            objEquipamentoComponente.NumeroSerie = DdlEquipamento.SelectedValue
            objEquipamentoComponente.FillDropDown(DdlComponente, False, "", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnIncluir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnIncluir.Click
        Try
            Dim objPedidoVendaEquipamentoComponente As New UCLPedidoVendaSolicitacaoEquipamentoComponente(StrConexaoUsuario(Session("GlUsuario")))
            If Acao = "ALTERAR" OrElse (Acao = "INCLUIR" AndAlso Salvar()) Then
                If DdlComponente.Items.Count > 0 Then
                    objPedidoVendaEquipamentoComponente.Empresa = Empresa
                    objPedidoVendaEquipamentoComponente.Estabelecimento = Estabelecimento
                    objPedidoVendaEquipamentoComponente.CodPedidoVenda = CodPedidoVenda
                    objPedidoVendaEquipamentoComponente.SeqSolicitacao = LblSeqSolicitacao.Text
                    objPedidoVendaEquipamentoComponente.NumeroSerie = DdlEquipamento.SelectedValue
                    objPedidoVendaEquipamentoComponente.SeqComponente = DdlComponente.SelectedValue
                    If objPedidoVendaEquipamentoComponente.Existe Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('Componente já inserido.');", True)
                    Else
                        objPedidoVendaEquipamentoComponente.Incluir()
                        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                        SqlDataSource1.DataBind()
                        GridView1.DataBind()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            Dim chave As String
            Dim numeroSerie As String
            Dim seqComponente As String
            Dim objPedidoVendaEquipamentoComponente As New UCLPedidoVendaSolicitacaoEquipamentoComponente(StrConexaoUsuario(Session("GlUsuario")))
            If e.CommandName = "EXCLUIR" Then
                chave = e.CommandArgument
                If chave.Contains("§") Then
                    numeroSerie = chave.Substring(0, chave.IndexOf("§"))
                    seqComponente = chave.Substring(chave.IndexOf("§") + 1)

                    objPedidoVendaEquipamentoComponente.Empresa = Empresa
                    objPedidoVendaEquipamentoComponente.Estabelecimento = Estabelecimento
                    objPedidoVendaEquipamentoComponente.CodPedidoVenda = CodPedidoVenda
                    objPedidoVendaEquipamentoComponente.SeqSolicitacao = LblSeqSolicitacao.Text
                    objPedidoVendaEquipamentoComponente.NumeroSerie = numeroSerie
                    objPedidoVendaEquipamentoComponente.SeqComponente = seqComponente
                    objPedidoVendaEquipamentoComponente.Excluir()
                    SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                    SqlDataSource1.DataBind()
                    GridView1.DataBind()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub CarregaListaServicos()
        Try
            Dim ObjTipoServicoAtendimento As New UCLTipoServicoAtendimento
            Dim ObjPedidoVendaSolicitacaoTipoServicoAtendimento As New UCLPedidoVendaSolicitacaoTipoServicoAtendimento
            Dim servicos As List(Of UCLTipoServicoAtendimento) = ObjTipoServicoAtendimento.GetLista()
            Dim li As ListItem

            CbxServico.Items.Clear()

            For Each servico As UCLTipoServicoAtendimento In servicos
                li = New ListItem
                li.Value = servico.GetConteudo("cod_tipo_servico")
                li.Text = servico.GetConteudo("descricao")
                li.Selected = ObjPedidoVendaSolicitacaoTipoServicoAtendimento.Existe(Empresa, Estabelecimento, CodPedidoVenda, LblSeqSolicitacao.Text, li.Value)
                CbxServico.Items.Add(li)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GravaListaServicos()
        Try
            Dim ObjPedidoVendaSolicitacaoTipoServicoAtendimento As New UCLPedidoVendaSolicitacaoTipoServicoAtendimento
            ObjPedidoVendaSolicitacaoTipoServicoAtendimento.Excluir(Empresa, Estabelecimento, CodPedidoVenda, LblSeqSolicitacao.Text)
            For Each li As ListItem In CbxServico.Items
                If li.Selected Then
                    ObjPedidoVendaSolicitacaoTipoServicoAtendimento = New UCLPedidoVendaSolicitacaoTipoServicoAtendimento
                    ObjPedidoVendaSolicitacaoTipoServicoAtendimento.SetConteudo("empresa", Empresa)
                    ObjPedidoVendaSolicitacaoTipoServicoAtendimento.SetConteudo("estabelecimento", Estabelecimento)
                    ObjPedidoVendaSolicitacaoTipoServicoAtendimento.SetConteudo("cod_pedido_venda", CodPedidoVenda)
                    ObjPedidoVendaSolicitacaoTipoServicoAtendimento.SetConteudo("seq_solicitacao", LblSeqSolicitacao.Text)
                    ObjPedidoVendaSolicitacaoTipoServicoAtendimento.SetConteudo("cod_tipo_servico", li.Value)
                    ObjPedidoVendaSolicitacaoTipoServicoAtendimento.Incluir()
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect(CaminhoVoltar)
    End Sub
End Class