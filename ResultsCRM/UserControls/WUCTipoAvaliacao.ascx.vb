Public Class WUCTipoAvaliacao
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodTipoAvaliacao As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodTipoAvaliacao() As String
        Get
            Return _CodTipoAvaliacao
        End Get
        Set(ByVal value As String)
            _CodTipoAvaliacao = value
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
        Dim objTipoAvaliacao As New UCLTipoAvaliacao
        LblCodTipoAvaliacao.Text = CodTipoAvaliacao
        objTipoAvaliacao.Buscar(Session("GlEmpresa"), CodTipoAvaliacao)
        TxtDescricao.Text = objTipoAvaliacao.GetConteudo("descricao")
    End Sub

    Private Sub CarregaNovaPK()
        Dim objTipoAvaliacao As New UCLTipoAvaliacao
        LblCodTipoAvaliacao.Text = objTipoAvaliacao.GetProximoCodigo(Session("GlEmpresa"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objTipoAvaliacao As New UCLTipoAvaliacao
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objTipoAvaliacao.SetConteudo("empresa", Session("GlEmpresa"))
                    objTipoAvaliacao.SetConteudo("cod_tipo_avaliacao", LblCodTipoAvaliacao.Text)
                    objTipoAvaliacao = CarregaObjeto(objTipoAvaliacao)
                    objTipoAvaliacao.Alterar()
                    LblErro.Text = "Dados foram alterados com sucesso."
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objTipoAvaliacao.SetConteudo("empresa", Session("GlEmpresa"))
                    objTipoAvaliacao.SetConteudo("cod_tipo_avaliacao", LblCodTipoAvaliacao.Text)
                    objTipoAvaliacao = CarregaObjeto(objTipoAvaliacao)
                    objTipoAvaliacao.Incluir()
                    LblErro.Text = "Dados foram incluídos com sucesso."
                    Session("SAcaoTipoAvaliacao") = "ALTERAR"
                    Acao = Session("SAcaoTipoAvaliacao")
                    Session("SCodTipoAvaliacao") = LblCodTipoAvaliacao.Text
                    CodTipoAvaliacao = Session("SCodTipoAvaliacao")
                    Call CarregaFormulario()
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

    Protected Function CarregaObjeto(ByRef objTipoAvaliacao As UCLTipoAvaliacao) As UCLTipoAvaliacao
        objTipoAvaliacao.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        Return objTipoAvaliacao
    End Function

End Class