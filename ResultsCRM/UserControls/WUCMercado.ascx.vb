Public Class WUCMercado
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodMercado As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodMercado() As String
        Get
            Return _CodMercado
        End Get
        Set(ByVal value As String)
            _CodMercado = value
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
        Dim objMercado As New UCLMercado
        LblCodMercado.Text = CodMercado

        objMercado.Buscar(LblCodMercado.Text)

        TxtDescricao.Text = objMercado.GetConteudo("descricao").ToString
    End Sub

    Private Sub CarregaNovaPK()
        Dim objMercado As New UCLMercado
        LblCodMercado.Text = objMercado.GetProximoCodigo
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objMercado As New UCLMercado
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objMercado.SetConteudo("cod_mercado", LblCodMercado.Text)
                    objMercado = CarregaObjeto(objMercado)
                    objMercado.Alterar()
                    Response.Redirect("WGMercado.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objMercado.SetConteudo("cod_mercado", LblCodMercado.Text)
                    objMercado = CarregaObjeto(objMercado)
                    objMercado.Incluir()
                    Response.Redirect("WGMercado.aspx")
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

    Protected Function CarregaObjeto(ByRef objMercado As UCLMercado) As UCLMercado
        objMercado.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        Return objMercado
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGMercado.aspx")
    End Sub

End Class