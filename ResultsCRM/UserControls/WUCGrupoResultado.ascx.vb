Public Class WUCGrupoResultado
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodGrupoResultado As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodGrupoResultado() As String
        Get
            Return _CodGrupoResultado
        End Get
        Set(ByVal value As String)
            _CodGrupoResultado = value
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
        Dim objGrupoResultado As New UCLGrupoResultadoItemAvaliado
        LblCodGrupoResultado.Text = CodGrupoResultado
        objGrupoResultado.Buscar(Session("GlEmpresa"), CodGrupoResultado)
        TxtDescricao.Text = objGrupoResultado.GetConteudo("descricao")
    End Sub

    Private Sub CarregaNovaPK()
        Dim objGrupoResultado As New UCLGrupoResultadoItemAvaliado
        LblCodGrupoResultado.Text = objGrupoResultado.GetProximoCodigo(Session("GlEmpresa"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objGrupoResultado As New UCLGrupoResultadoItemAvaliado
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objGrupoResultado.SetConteudo("empresa", Session("GlEmpresa"))
                    objGrupoResultado.SetConteudo("cod_grupo_resultado", LblCodGrupoResultado.Text)
                    objGrupoResultado = CarregaObjeto(objGrupoResultado)
                    objGrupoResultado.Alterar()
                    LblErro.Text = "Dados foram alterados com sucesso."
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objGrupoResultado.SetConteudo("empresa", Session("GlEmpresa"))
                    objGrupoResultado.SetConteudo("cod_grupo_resultado", LblCodGrupoResultado.Text)
                    objGrupoResultado = CarregaObjeto(objGrupoResultado)
                    objGrupoResultado.Incluir()
                    LblErro.Text = "Dados foram incluídos com sucesso."
                    Session("SAcaoGrupoResultado") = "ALTERAR"
                    Acao = Session("SAcaoGrupoResultado")
                    Session("SCodGrupoResultado") = LblCodGrupoResultado.Text
                    CodGrupoResultado = Session("SCodGrupoResultado")
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

    Protected Function CarregaObjeto(ByRef objGrupoResultado As UCLGrupoResultadoItemAvaliado) As UCLGrupoResultadoItemAvaliado
        objGrupoResultado.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        Return objGrupoResultado
    End Function

End Class