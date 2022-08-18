Partial Public Class WUCPais
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodPais As String
    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property CodPais() As String
        Get
            Return _CodPais
        End Get
        Set(ByVal value As String)
            _CodPais = value
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
        Dim objAcao As New UCLPais
        objAcao.CodPais = CodPais
        LblCodigo.Text = CodPais
        objAcao.Buscar()
        TxtPais.Text = objAcao.Nome
        TxtSigla.Text = objAcao.Sigla
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objAcao As New UCLPais
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objAcao.CodPais = LblCodigo.Text
                    objAcao = CarregaObjeto(objAcao)
                    objAcao.Alterar()
                    Response.Redirect("WGPais.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objAcao.CodPais = LblCodigo.Text
                    objAcao = CarregaObjeto(objAcao)
                    objAcao.Incluir()
                    Response.Redirect("WGPais.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Function CarregaObjeto(ByRef objAcao As UCLPais) As UCLPais
        objAcao.Nome = TxtPais.Text.GetValidInputContent
        objAcao.Sigla = TxtSigla.Text.GetValidInputContent
        Return objAcao
    End Function
    Private Sub CarregaNovaPK()
        Dim objAcao As New UCLPais
        LblCodigo.Text = objAcao.GetProximoCodigo
    End Sub
    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""
        If String.IsNullOrEmpty(TxtPais.Text) Then
            LblErro.Text += "Preencha o campo País.<br/>"
        End If
        If String.IsNullOrEmpty(TxtSigla.Text) Then
            LblErro.Text += "Preencha o campo Sigla.<br/>"
        End If
        Return LblErro.Text.Trim = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Try
            Response.Redirect("WGPais.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try

    End Sub
End Class