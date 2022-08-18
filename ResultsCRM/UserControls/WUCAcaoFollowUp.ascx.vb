Public Partial Class WUCAcaoFollowUp
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodAcao As String
    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property CodAcao() As String
        Get
            Return _CodAcao
        End Get
        Set(ByVal value As String)
            _CodAcao = value
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
        Dim objAcao As New UCLAcaoFollowUp
        objAcao.CodAcao = CodAcao
        LblCodigo.Text = CodAcao
        objAcao.Buscar()
        TxtDescricao.Text = objAcao.Descricao
        ChkEnviaEmail.Checked = objAcao.EnviaEmail.ToString.Replace("S", "True").Replace("N", "False")
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objAcao As New UCLAcaoFollowUp
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objAcao.CodAcao = LblCodigo.Text
                    objAcao = CarregaObjeto(objAcao)
                    objAcao.Alterar()
                    Response.Redirect("WGAcaoFollowUp.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objAcao.CodAcao = LblCodigo.Text
                    objAcao = CarregaObjeto(objAcao)
                    objAcao.Incluir()
                    Response.Redirect("WGAcaoFollowUp.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Function CarregaObjeto(ByRef objAcao As UCLAcaoFollowUp) As UCLAcaoFollowUp
        objAcao.Descricao = TxtDescricao.Text.GetValidInputContent
        objAcao.EnviaEmail = ChkEnviaEmail.Checked.ToString.Replace("True", "S").Replace("False", "N")
        Return objAcao
    End Function
    Private Sub CarregaNovaPK()
        Dim objAcao As New UCLAcaoFollowUp
        LblCodigo.Text = objAcao.GetProximoCodigo
    End Sub
    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""
        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha o campo País.<br/>"
        End If
        Return LblErro.Text.Trim = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGAcaoFollowUp.aspx")
    End Sub
End Class