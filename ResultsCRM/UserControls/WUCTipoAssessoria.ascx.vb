Public Class WUCTipoAssessoria
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodTipoAssessoria As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodTipoAssessoria() As String
        Get
            Return _CodTipoAssessoria
        End Get
        Set(ByVal value As String)
            _CodTipoAssessoria = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Dim objTipoAssessoria As New UCLTipoAssessoria
        LblCodTipoAssessoria.Text = CodTipoAssessoria
        objTipoAssessoria.Buscar(CodTipoAssessoria)
        TxtDescricao.Text = objTipoAssessoria.GetConteudo("descricao")
    End Sub

    Private Sub CarregaNovaPK()
        Dim objTipoAssessoria As New UCLTipoAssessoria
        LblCodTipoAssessoria.Text = objTipoAssessoria.GetProximoCodigo()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objTipoAssessoria As New UCLTipoAssessoria
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objTipoAssessoria.SetConteudo("cod_tipo_assessoria", CodTipoAssessoria)
                    objTipoAssessoria = CarregaObjeto(objTipoAssessoria)
                    objTipoAssessoria.Alterar()
                    Response.Redirect("WGTipoAssessoria.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objTipoAssessoria.SetConteudo("cod_tipo_assessoria", LblCodTipoAssessoria.Text)
                    objTipoAssessoria = CarregaObjeto(objTipoAssessoria)
                    objTipoAssessoria.Incluir()
                    Response.Redirect("WGTipoAssessoria.aspx")
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

        Return (LblErro.Text.Trim = "")
    End Function

    Protected Function CarregaObjeto(ByRef objTipoAssessoria As UCLTipoAssessoria) As UCLTipoAssessoria
        objTipoAssessoria.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent())
        Return objTipoAssessoria
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGTipoAssessoria.aspx")
    End Sub

End Class