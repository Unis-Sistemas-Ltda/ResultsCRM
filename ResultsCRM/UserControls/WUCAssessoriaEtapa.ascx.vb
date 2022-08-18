Public Class WUCAssessoriaEtapa
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodAssessoria As String
    Private _CodAssessoriaEtapa As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodAssessoria() As String
        Get
            Return _CodAssessoria
        End Get
        Set(ByVal value As String)
            _CodAssessoria = value
        End Set
    End Property

    Public Property CodAssessoriaEtapa() As String
        Get
            Return _CodAssessoriaEtapa
        End Get
        Set(ByVal value As String)
            _CodAssessoriaEtapa = value
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
        Dim ObjAssessoriaEtapa As New UCLAssessoriaEtapa
        LblCodAssessoriaEtapa.Text = CodAssessoriaEtapa
        ObjAssessoriaEtapa.Buscar(CodAssessoria, CodAssessoriaEtapa)
        TxtDescricao.Text = ObjAssessoriaEtapa.GetConteudo("descricao")
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjAssessoriaEtapa As New UCLAssessoriaEtapa
        LblCodAssessoriaEtapa.Text = ObjAssessoriaEtapa.GetProximoCodigo(CodAssessoria)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjAssessoriaEtapa As New UCLAssessoriaEtapa
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjAssessoriaEtapa.SetConteudo("cod_assessoria", CodAssessoria)
                    ObjAssessoriaEtapa.SetConteudo("cod_etapa", CodAssessoriaEtapa)
                    ObjAssessoriaEtapa = CarregaObjeto(ObjAssessoriaEtapa)
                    ObjAssessoriaEtapa.Alterar()
                    Response.Redirect("WGAssessoriaEtapa.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjAssessoriaEtapa.SetConteudo("cod_assessoria", CodAssessoria)
                    ObjAssessoriaEtapa.SetConteudo("cod_etapa", LblCodAssessoriaEtapa.Text)
                    ObjAssessoriaEtapa = CarregaObjeto(ObjAssessoriaEtapa)
                    ObjAssessoriaEtapa.Incluir()
                    Response.Redirect("WGAssessoriaEtapa.aspx")
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

    Protected Function CarregaObjeto(ByRef ObjAssessoriaEtapa As UCLAssessoriaEtapa) As UCLAssessoriaEtapa
        ObjAssessoriaEtapa.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        Return ObjAssessoriaEtapa
    End Function

    Protected Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGAssessoriaEtapa.aspx")
    End Sub
End Class