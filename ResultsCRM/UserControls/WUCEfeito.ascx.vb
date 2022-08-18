Public Class WUCEfeito
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodEfeito As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodEfeito() As String
        Get
            Return _CodEfeito
        End Get
        Set(ByVal value As String)
            _CodEfeito = value
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
        Dim ObjEfeito As New UCLEfeito
        LblCodEfeito.Text = CodEfeito

        ObjEfeito.Buscar(Session("GlEmpresa"), CodEfeito)

        TxtDescricao.Text = ObjEfeito.GetConteudo("descricao")
        TxtDescricaoCompleta.Text = ObjEfeito.GetConteudo("descricao_completa")
        TxtSeveridade.Text = ObjEfeito.GetConteudo("severidade")
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjEfeito As New UCLEfeito
        LblCodEfeito.Text = ObjEfeito.GetProximoCodigo(Session("GlEmpresa"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjEfeito As New UCLEfeito
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjEfeito.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjEfeito.SetConteudo("cod_efeito", LblCodEfeito.Text)
                    ObjEfeito = CarregaObjeto(ObjEfeito)
                    ObjEfeito.Alterar()
                    Response.Redirect("WGEfeito.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjEfeito.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjEfeito.SetConteudo("cod_efeito", LblCodEfeito.Text)
                    ObjEfeito = CarregaObjeto(ObjEfeito)
                    ObjEfeito.Incluir()
                    Response.Redirect("WGEfeito.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Descrição Resumida.<br/>"
        End If

        If String.IsNullOrEmpty(TxtSeveridade.Text) Then
            LblErro.Text += "Preencha o campo Severidade.<br/>"
        ElseIf Not IsNumeric(TxtSeveridade.Text) Then
            LblErro.Text += "Preencha correamente o campo Severidade, com um número de 1 a 10.<br/>"
        ElseIf CDbl(TxtSeveridade.Text) < 1 OrElse CDbl(TxtSeveridade.Text) > 10 Then
            LblErro.Text += "Preencha correamente o campo Severidade, com um número de 1 a 10.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjEfeito As UCLEfeito) As UCLEfeito
        ObjEfeito.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        ObjEfeito.SetConteudo("descricao_completa", TxtDescricaoCompleta.Text.GetValidInputContent)
        ObjEfeito.SetConteudo("severidade", TxtSeveridade.Text.GetValidInputContent)
        Return ObjEfeito
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGEfeito.aspx")
    End Sub

End Class