Partial Public Class WUCRemocaoMaterial
    Inherits System.Web.UI.UserControl

    Private _empresa As String
    Private _estabelecimento As String
    Private _codPedidoVenda As String
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaAgenteTecnico()
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

            TxtQuantidade.Attributes.Add("OnFocus", "selecionaCampo(this)")

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
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

    Private Function Salvar() As Boolean
        Try
            Dim ObjPedidoVendaMovimentacaoMaterial As New UCLPedidoVendaMovimetacaoMaterial(StrConexaoUsuario(Session("GlUsuario")))
            If IsDigitacaoOK() Then
                ObjPedidoVendaMovimentacaoMaterial.Empresa = Empresa
                ObjPedidoVendaMovimentacaoMaterial.Estabelecimento = Estabelecimento
                ObjPedidoVendaMovimentacaoMaterial.CodPedidoVenda = CodPedidoVenda
                ObjPedidoVendaMovimentacaoMaterial.SeqMovimentacao = ObjPedidoVendaMovimentacaoMaterial.GetProximoCodigo()
                ObjPedidoVendaMovimentacaoMaterial.Tipo = "E"
                ObjPedidoVendaMovimentacaoMaterial.CodItem = TxtCodItem.Text
                ObjPedidoVendaMovimentacaoMaterial.Lote = TxtLote.Text.Trim
                ObjPedidoVendaMovimentacaoMaterial.Quantidade = TxtQuantidade.Text
                ObjPedidoVendaMovimentacaoMaterial.CodAgenteTecnico = DdlAgenteTecnico.SelectedValue
                ObjPedidoVendaMovimentacaoMaterial.Incluir()
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

            If String.IsNullOrWhiteSpace(TxtCodItem.Text) Then
                LblErro.Text += "Informe o item removido.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtQuantidade.Text) Then
                LblErro.Text += "Informe a quantidade.<br/>"
            ElseIf Not IsNumeric(TxtQuantidade.Text) Then
                LblErro.Text += "Informe corretamente a quantidade.<br/>"
            End If

            If DdlAgenteTecnico.SelectedValue = "0" Then
                LblErro.Text += "Selecione o agente técnico.<br/>"
            End If

            Return LblErro.Text = ""
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub CarregaDescricaoItem()
        Try
            Dim objItem As New UCLItem
            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                objItem.CodItem = TxtCodItem.Text
                objItem.Buscar()
                LblDescricaoItem.Text = objItem.Descricao
            Else
                LblDescricaoItem.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaAgenteTecnico()
        Try
            Dim objAgenteTecnico As New UCLAgenteTecnico
            objAgenteTecnico.FillDropDown(DdlAgenteTecnico, True, "", "0", Empresa, Estabelecimento, CodPedidoVenda)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class