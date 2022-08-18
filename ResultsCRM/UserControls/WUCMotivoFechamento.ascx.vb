Partial Public Class WUCMotivoFechamento
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodMotivo As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodMotivo() As String
        Get
            Return _CodMotivo
        End Get
        Set(ByVal value As String)
            _CodMotivo = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If

    End Sub

    Private Sub CarregaFormulario()
        Dim objMotivo As New UCLMotivoFechamento
        LblCodMotivo.Text = CodMotivo

        objMotivo.CodMotivo = CodMotivo
        objMotivo.Buscar()

        RblTipo.SelectedValue = objMotivo.Tipo
        TxtDescricao.Text = objMotivo.Descricao
    End Sub

    Private Sub CarregaNovaPK()
        Dim objMotivo As New UCLMotivoFechamento
        LblCodMotivo.Text = objMotivo.GetProximoCodigo
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objMotivo As New UCLMotivoFechamento
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objMotivo.CodMotivo = LblCodMotivo.Text
                    objMotivo = CarregaObjeto(objMotivo)
                    objMotivo.Alterar()
                    Response.Redirect("WGMotivoFechamento.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objMotivo.CodMotivo = LblCodMotivo.Text
                    objMotivo = CarregaObjeto(objMotivo)
                    objMotivo.Incluir()
                    Response.Redirect("WGMotivoFechamento.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Descrição.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef objMotivo As UCLMotivoFechamento) As UCLMotivoFechamento

        objMotivo.Descricao = TxtDescricao.Text.GetValidInputContent
        objMotivo.Tipo = RblTipo.SelectedValue

        Return objMotivo
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGMotivoFechamento.aspx")
    End Sub
End Class