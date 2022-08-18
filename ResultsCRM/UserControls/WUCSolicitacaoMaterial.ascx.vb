Partial Public Class WUCSolicitacaoMaterial
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

    Public Property Acao() As String
        Get
            Return _acao
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "INCLUIR"
                    LblAcao.Text = "INCLUSÃO"
                    BtnGravar.Text = "Incluir"
                Case "ALTERAR"
                    LblAcao.Text = "ALTERAÇÃO"
                    BtnGravar.Text = "Salvar alterações"
            End Select
            _acao = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call Carregar()
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

            If IsPostBack Then
                Call CarregaDescricaoItem()
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub Carregar()
        Try
            Call CarregaEstabelecimento()
            Call CarregaAgenteTecnico()
            Call CarregaSolicitante()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            Else
                Call CarregaNovaPK()
                TxtQuantidade.Text = 1
                TxtDataSolicitacao.Text = System.DateTime.Now.ToString("dd/MM/yyyy")
                TxtHoraSolicitacao.Text = System.DateTime.Now.ToString("HH:mm")
                TxtDataEntrega.Text = TxtDataSolicitacao.Text
                TxtCodItem.Text = ""
                If DdlSolicitante.Items.FindByValue(Session("GlCodUsuario")) IsNot Nothing Then
                    DdlSolicitante.SelectedValue = Session("GlCodUsuario")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim objSolicitacaoTecnico As New UCLSolicitacaoTecnico(StrConexaoUsuario(Session("GlUsuario")))

            objSolicitacaoTecnico.Buscar(Empresa, Estabelecimento, CodSolicitacao)


            LblCodSolicitacao.Text = CodSolicitacao
            DdlEstabelecimento.SelectedValue = objSolicitacaoTecnico.estabelecimento
            DdlEstabelecimento.Enabled = False
            DdlSolicitante.SelectedValue = objSolicitacaoTecnico.cod_solicitante
            DdlAgenteTecnico.SelectedValue = objSolicitacaoTecnico.cod_agente_tecnico
            TxtCodItem.Text = objSolicitacaoTecnico.cod_item
            TxtQuantidade.Text = CDbl(objSolicitacaoTecnico.quantidade).ToString
            TxtDataSolicitacao.Text = objSolicitacaoTecnico.ddata_solicitacao.ToString("dd/MM/yyyy")
            TxtHoraSolicitacao.Text = objSolicitacaoTecnico.HoraSolicitacao
            TxtDataEntrega.Text = objSolicitacaoTecnico.ddata_entrega.ToString("dd/MM/yyyy")
            TxtHoraEntrega.Text = objSolicitacaoTecnico.HoraEntrega
            DdlPrioridade.SelectedValue = objSolicitacaoTecnico.prioridade
            DdlFormaEntrega.SelectedValue = objSolicitacaoTecnico.forma_entrega

            Call CarregaDescricaoItem()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CodItemMudou()
        Try
            Call CarregaDescricaoItem()

            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                Session("SCodItemPesquisado") = TxtCodItem.Text
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
            Dim objSolicitacaoTecnico As New UCLSolicitacaoTecnico(StrConexaoUsuario(Session("GlUsuario")))
            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objSolicitacaoTecnico.empresa = Empresa
                    objSolicitacaoTecnico.estabelecimento = Estabelecimento
                    objSolicitacaoTecnico.cod_solicitacao = CodSolicitacao
                    objSolicitacaoTecnico.Buscar(Empresa, Estabelecimento, CodSolicitacao)
                    Call CarregaObjeto(objSolicitacaoTecnico)
                    objSolicitacaoTecnico.Alterar()
                    Return True
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objSolicitacaoTecnico.empresa = Empresa
                    objSolicitacaoTecnico.estabelecimento = Estabelecimento
                    objSolicitacaoTecnico.cod_solicitacao = LblCodSolicitacao.Text
                    Call CarregaObjeto(objSolicitacaoTecnico)
                    objSolicitacaoTecnico.Incluir()
                    Session("SAcaoAtPedido") = "ALTERAR"
                    LblCodSolicitacao.Text = objSolicitacaoTecnico.cod_solicitacao
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
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

            If String.IsNullOrWhiteSpace(TxtCodItem.Text) Then
                LblErro.Text += "Informe o item.<br/>"
            End If

            If Not IsNumeric(TxtQuantidade.Text) Then
                LblErro.Text += "Informe corretamente a quantidade.<br/>"
            Else
                If CDbl(TxtQuantidade.Text) <= 0 Then
                    LblErro.Text += "Informe corretamente a quantidade.<br/>"
                End If
            End If

            If Not isValidDate(TxtDataSolicitacao.Text) Then
                LblErro.Text += "Informe corretamente a data de solicitação.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtHoraSolicitacao.Text) Then
                LblErro.Text += "Informe corretamente a hora de solicitação.<br/>"
            Else
                If TxtHoraSolicitacao.Text.Trim.Length <> 5 Then
                    LblErro.Text += "Informe corretamente a hora de solicitação [formato HH:mm].<br/>"
                Else
                    If Not IsNumeric(TxtHoraSolicitacao.Text.Substring(0, 2)) OrElse Not IsNumeric(TxtHoraSolicitacao.Text.Substring(3, 2)) Then
                        LblErro.Text += "Informe corretamente a hora de solicitação [formato HH:mm].<br/>"
                    Else
                        If CLng(TxtHoraSolicitacao.Text.Substring(0, 2)) < 0 OrElse CLng(TxtHoraSolicitacao.Text.Substring(0, 2)) > 23 OrElse CLng(TxtHoraSolicitacao.Text.Substring(3, 2)) < 0 OrElse CLng(TxtHoraSolicitacao.Text.Substring(3, 2)) > 59 Then
                            LblErro.Text += "Informe corretamente a hora de solicitação [formato HH:mm].<br/>"
                        End If
                    End If
                End If
            End If

            If Not isValidDate(TxtDataEntrega.Text) Then
                LblErro.Text += "Informe corretamente a data de entrega.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtHoraEntrega.Text) Then
                LblErro.Text += "Informe corretamente a hora de entrega.<br/>"
            Else
                If TxtHoraEntrega.Text.Trim.Length <> 5 Then
                    LblErro.Text += "Informe corretamente a hora de entrega [formato HH:mm].<br/>"
                Else
                    If Not IsNumeric(TxtHoraEntrega.Text.Substring(0, 2)) OrElse Not IsNumeric(TxtHoraEntrega.Text.Substring(3, 2)) Then
                        LblErro.Text += "Informe corretamente a hora de entrega [formato HH:mm].<br/>"
                    Else
                        If CLng(TxtHoraEntrega.Text.Substring(0, 2)) < 0 OrElse CLng(TxtHoraEntrega.Text.Substring(0, 2)) > 23 OrElse CLng(TxtHoraEntrega.Text.Substring(3, 2)) < 0 OrElse CLng(TxtHoraEntrega.Text.Substring(3, 2)) > 59 Then
                            LblErro.Text += "Informe corretamente a hora de solicitação [formato HH:mm].<br/>"
                        End If
                    End If
                End If
            End If

            Return LblErro.Text = ""
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub CarregaObjeto(ByRef objSolicitacaoTecnico As UCLSolicitacaoTecnico)
        Try
            objSolicitacaoTecnico.cod_pedido_venda = CodPedidoVenda
            objSolicitacaoTecnico.estabelecimento = DdlEstabelecimento.SelectedValue
            objSolicitacaoTecnico.cod_solicitante = DdlSolicitante.SelectedValue
            objSolicitacaoTecnico.cod_agente_tecnico = DdlAgenteTecnico.SelectedValue
            objSolicitacaoTecnico.cod_item = TxtCodItem.Text
            objSolicitacaoTecnico.quantidade = TxtQuantidade.Text
            objSolicitacaoTecnico.data_solicitacao = TxtDataSolicitacao.Text
            objSolicitacaoTecnico.HoraSolicitacao = TxtHoraSolicitacao.Text
            objSolicitacaoTecnico.data_entrega = TxtDataEntrega.Text
            objSolicitacaoTecnico.HoraEntrega = TxtHoraEntrega.Text
            objSolicitacaoTecnico.prioridade = DdlPrioridade.SelectedValue
            objSolicitacaoTecnico.forma_entrega = DdlFormaEntrega.SelectedValue
            objSolicitacaoTecnico.situacao = IIf(String.IsNullOrWhiteSpace(objSolicitacaoTecnico.situacao), "1", objSolicitacaoTecnico.situacao)
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

    Private Sub CarregaNovaPK()
        Try
            Dim objSolicitacaoTecnico As New UCLSolicitacaoTecnico(StrConexaoUsuario(Session("GlUsuario")))
            objSolicitacaoTecnico.empresa = Empresa
            LblCodSolicitacao.Text = objSolicitacaoTecnico.GetProximoCodigo()
            CodSolicitacao = LblCodSolicitacao.Text
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtCodItem_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCodItem.TextChanged
        If String.IsNullOrEmpty(TxtQuantidade.Text) OrElse (IsNumeric(TxtQuantidade.Text) AndAlso TxtQuantidade.Text <= 0) Then
            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                TxtQuantidade.Text = 1
            End If
        End If
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

    Private Sub CarregaSolicitante()
        Try
            Dim objUsuario As New UCLUsuario
            objUsuario.FillControl(DdlSolicitante, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaAgenteTecnico()
        Try
            Dim objAgenteTecnico As New UCLAgenteTecnico
            objAgenteTecnico.FillDropDown(DdlAgenteTecnico, False, "", "", Empresa, Estabelecimento, CodPedidoVenda)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class