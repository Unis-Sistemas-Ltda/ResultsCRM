Public Class WUCEmitenteAssessoriaEtapa
    Inherits System.Web.UI.UserControl

    Public Property Acao() As String
    Public Property CodEmitente() As String
    Public Property CodAssessoria() As String
    Public Property CodFornecedor() As String
    Public Property SeqEtapa() As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaEtapaAssessoria()
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaNovaPK()
        Dim objEmitenteAssessoriaEtapa As New UCLEmitenteAssessoriaEtapa
        LblSeqEtapa.Text = objEmitenteAssessoriaEtapa.GetProximoCodigo(Session("GlEmpresa"), CodEmitente, CodAssessoria, CodFornecedor)
    End Sub

    Private Sub CarregaFormulario()
        Dim objEmitenteAssessoriaEtapa As New UCLEmitenteAssessoriaEtapa
        objEmitenteAssessoriaEtapa.Buscar(Session("GlEmpresa"), CodEmitente, CodAssessoria, CodFornecedor, SeqEtapa)
        LblSeqEtapa.Text = SeqEtapa
        Call CarregaEtapaAssessoria()
        DdlEtapa.SelectedValue = objEmitenteAssessoriaEtapa.GetConteudo("cod_etapa")
        If Not objEmitenteAssessoriaEtapa.IsNull("data_inicio") Then
            TxtDataInicio.Text = objEmitenteAssessoriaEtapa.GetConteudoData("data_inicio").ToString("dd/MM/yyyy")
        End If
        If Not objEmitenteAssessoriaEtapa.IsNull("data_fim") Then
            TxtDataFim.Text = objEmitenteAssessoriaEtapa.GetConteudoData("data_fim").ToString("dd/MM/yyyy")
        End If
        TxtObservacao.Text = objEmitenteAssessoriaEtapa.GetConteudo("observacao")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objEmitenteAssessoriaEtapa As New UCLEmitenteAssessoriaEtapa
        Try
            If IsDigitacaoOk() Then

                If Acao = "ALTERAR" Then
                    'Busca com dados originais
                    objEmitenteAssessoriaEtapa.Buscar(Session("GlEmpresa"), CodEmitente, CodAssessoria, CodFornecedor, LblSeqEtapa.Text)
                    objEmitenteAssessoriaEtapa = CarregaObjeto(objEmitenteAssessoriaEtapa)
                    objEmitenteAssessoriaEtapa.Alterar()
                    Response.Redirect("WGEmitenteAssessoriaEtapa.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objEmitenteAssessoriaEtapa.Buscar(Session("GlEmpresa"), CodEmitente, CodAssessoria, CodFornecedor, LblSeqEtapa.Text)
                    objEmitenteAssessoriaEtapa = CarregaObjeto(objEmitenteAssessoriaEtapa)
                    objEmitenteAssessoriaEtapa.Incluir()
                    Response.Redirect("WGEmitenteAssessoriaEtapa.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(DdlEtapa.SelectedValue) OrElse DdlEtapa.SelectedValue <= 0 Then
            LblErro.Text += "Preencha o campo Etapa.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef objEmitenteAssessoriaEtapa As UCLEmitenteAssessoriaEtapa) As UCLEmitenteAssessoriaEtapa
        objEmitenteAssessoriaEtapa.SetConteudo("cod_etapa", DdlEtapa.SelectedValue)
        objEmitenteAssessoriaEtapa.SetConteudo("data_inicio", TxtDataInicio.Text)
        objEmitenteAssessoriaEtapa.SetConteudo("data_fim", TxtDataFim.Text)
        objEmitenteAssessoriaEtapa.SetConteudo("observacao", TxtObservacao.Text.GetValidInputContent())
        If Acao = "INCLUIR" Then
            objEmitenteAssessoriaEtapa.SetConteudo("cod_usuario_inclusao", Session("GlCodUsuario"))
            objEmitenteAssessoriaEtapa.SetConteudo("data_inclusao", Now().ToString("yyyy-MM-dd HH:mm:ss.fff"))
        End If
        objEmitenteAssessoriaEtapa.SetConteudo("cod_usuario_alteracao", Session("GlCodUsuario"))
        objEmitenteAssessoriaEtapa.SetConteudo("data_alteracao", Now().ToString("yyyy-MM-dd HH:mm:ss.fff"))
        Return objEmitenteAssessoriaEtapa
    End Function

    Private Sub CarregaEtapaAssessoria()
        Dim objEtapa As New UCLAssessoriaEtapa
        objEtapa.FillDropDown(CodAssessoria, DdlEtapa, True, "(selecione)", 0)
    End Sub

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("WGEmitenteAssessoriaEtapa.aspx")
    End Sub
End Class
