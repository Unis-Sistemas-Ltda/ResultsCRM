Partial Public Class WUCStatusNegociacao
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodStatus As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodStatus() As String
        Get
            Return _CodStatus
        End Get
        Set(ByVal value As String)
            _CodStatus = value
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
        Dim objStatus As New UCLStatusNegociacao
        LblCodStatus.Text = CodStatus

        objStatus.Codigo = CodStatus
        objStatus.Buscar()

        TxtDescricao.Text = objStatus.Descricao
    End Sub

    Private Sub CarregaNovaPK()
        Dim objStatus As New UCLStatusNegociacao
        LblCodStatus.Text = objStatus.GetProximoCodigo
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objStatus As New UCLStatusNegociacao
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objStatus.Codigo = LblCodStatus.Text
                    objStatus = CarregaObjeto(objStatus)
                    objStatus.Alterar()
                    Response.Redirect("WGStatusNegociacao.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objStatus.Codigo = LblCodStatus.Text
                    objStatus = CarregaObjeto(objStatus)
                    objStatus.Incluir()
                    Response.Redirect("WGStatusNegociacao.aspx")
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

    Protected Function CarregaObjeto(ByRef objStatus As UCLStatusNegociacao) As UCLStatusNegociacao
        objStatus.Descricao = TxtDescricao.Text.GetValidInputContent
        Return objStatus
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGStatusNegociacao.aspx")
    End Sub
End Class