Public Partial Class WUCEtapaNegociacao
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodEtapa As String
    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property CodEtapa() As String
        Get
            Return _CodEtapa
        End Get
        Set(ByVal value As String)
            _CodEtapa = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim alterouCor As Long
        Dim CorPesquisada As String = Session("SCorPesquisada")

        If Not String.IsNullOrEmpty(Session("SAlterouCor")) Then
            alterouCor = Session("SAlterouCor")
        Else
            alterouCor = 0
        End If

        If Not String.IsNullOrEmpty(CorPesquisada) Then
            If alterouCor > 0 Then
                If TxtCorBotao.Text <> CorPesquisada Then
                    TxtCorBotao.Text = CorPesquisada
                End If
                Session("SAlterouCor") = alterouCor - 1
            End If
        End If

        If Not IsPostBack Then
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If

        Call ColoreBotaoCor()
    End Sub

    Private Sub ColoreBotaoCor()
        If Not String.IsNullOrEmpty(TxtCorBotao.Text) Then
            BtnCor.BackColor = System.Drawing.Color.FromArgb(TxtCorBotao.Text)
            BtnCor.BorderColor = System.Drawing.Color.FromArgb(TxtCorBotao.Text)
        End If
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim objEtapa As New UCLEtapaNegociacao
            objEtapa.Empresa = Session("GLEmpresa")
            objEtapa.Codigo = CodEtapa
            LblCodigo.Text = CodEtapa
            objEtapa.Buscar()
            TxtDescricao.Text = objEtapa.Descricao
            RblStatus.SelectedValue = objEtapa.Status
            TxtCorBotao.Text = objEtapa.Cor
            TxtPercentualFechamento.Text = objEtapa.PercentualFechamento
            TxtTempoMaximo.Text = objEtapa.TempoMaximo
            CbxNaoExigirDataPrevisao.Checked = (objEtapa.NaoExigirDataPrevisao = "S")
            CbxExigirDataRecontato.Checked = (objEtapa.ExigirDataRecontato = "S")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objEtapa As New UCLEtapaNegociacao
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objEtapa.Empresa = Session("GLEmpresa")
                    objEtapa.Codigo = LblCodigo.Text
                    objEtapa = CarregaObjeto(objEtapa)
                    objEtapa.Alterar()
                    Response.Redirect("WGEtapaNegociacao.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objEtapa.Empresa = Session("GLEmpresa")
                    objEtapa.Codigo = LblCodigo.Text
                    objEtapa = CarregaObjeto(objEtapa)
                    objEtapa.Incluir()
                    Response.Redirect("WGEtapaNegociacao.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Function CarregaObjeto(ByRef objEtapa As UCLEtapaNegociacao) As UCLEtapaNegociacao
        objEtapa.Descricao = TxtDescricao.Text.GetValidInputContent
        objEtapa.Status = RblStatus.SelectedValue
        objEtapa.PercentualFechamento = TxtPercentualFechamento.Text
        TxtCorBotao.Text = BtnCor.BackColor.ToArgb
        objEtapa.Cor = TxtCorBotao.Text
        objEtapa.TempoMaximo = TxtTempoMaximo.Text
        objEtapa.NaoExigirDataPrevisao = IIf(CbxNaoExigirDataPrevisao.Checked, "S", "N")
        objEtapa.ExigirDataRecontato = IIf(CbxExigirDataRecontato.Checked, "S", "N")
        Return objEtapa
    End Function
    Private Sub CarregaNovaPK()
        Dim objEtapa As New UCLEtapaNegociacao
        objEtapa.Empresa = Session("GLEmpresa")
        LblCodigo.Text = objEtapa.GetProximoCodigo
    End Sub
    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""
        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Descrição.<br/>"
        End If
        If String.IsNullOrEmpty(RblStatus.SelectedValue) Then
            LblErro.Text += "Selecione um Status.<br/>"
        End If
        Return LblErro.Text.Trim = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGEtapaNegociacao.aspx")
    End Sub
End Class