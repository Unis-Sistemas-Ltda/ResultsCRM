Partial Public Class WUCSLA
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodSLA As String
    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property CodSLA() As String
        Get
            Return _CodSLA
        End Get
        Set(ByVal value As String)
            _CodSLA = value
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
        Dim objSLA As New UCLSLA
        objSLA.CodSLA = CodSLA
        LblCodigo.Text = CodSLA
        objSLA.Buscar()
        TxtDescricao.Text = objSLA.Descricao
        TxtPrazoEncerramento.Text = objSLA.PrazoEncerramento
        TxtPrazoChegada.Text = objSLA.PrazoChegada
        TxtCodigoIntegracao.Text = objSLA.CodigoIntegracao
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objSLA As New UCLSLA
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objSLA.CodSLA = LblCodigo.Text
                    objSLA = CarregaObjeto(objSLA)
                    objSLA.Alterar()
                    Response.Redirect("WGSLA.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objSLA.CodSLA = LblCodigo.Text
                    objSLA = CarregaObjeto(objSLA)
                    objSLA.Incluir()
                    Response.Redirect("WGSLA.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Function CarregaObjeto(ByRef objSLA As UCLSLA) As UCLSLA
        objSLA.PrazoEncerramento = TxtPrazoEncerramento.Text.GetValidInputContent
        objSLA.PrazoChegada = TxtPrazoChegada.Text.GetValidInputContent
        objSLA.Descricao = TxtDescricao.Text.GetValidInputContent
        objSLA.CodigoIntegracao = TxtCodigoIntegracao.Text
        Return objSLA
    End Function
    Private Sub CarregaNovaPK()
        Dim objSLA As New UCLSLA
        LblCodigo.Text = objSLA.GetProximoCodigo
    End Sub
    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""
        If String.IsNullOrEmpty(TxtPrazoEncerramento.Text) Then
            LblErro.Text += "Preencha o campo Prazo Encerramento.<br/>"
        End If
        If String.IsNullOrEmpty(TxtPrazoChegada.Text) Then
            LblErro.Text += "Preencha o campo Prazo Chegada.<br/>"
        End If
        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Descrição.<br/>"
        End If
        Return LblErro.Text.Trim = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Try
            Response.Redirect("WGSLA.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try

    End Sub
End Class