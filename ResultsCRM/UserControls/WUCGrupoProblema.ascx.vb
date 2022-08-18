Public Class WUCGrupoProblema
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodGrupo As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodGrupo() As String
        Get
            Return _CodGrupo
        End Get
        Set(ByVal value As String)
            _CodGrupo = value
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
        Dim ObjGrupoProblema As New UCLGrupoProblema
        LblCodGrupo.Text = CodGrupo
        ObjGrupoProblema.Buscar(Session("GlEmpresa"), LblCodGrupo.Text)
        TxtDescricao.Text = ObjGrupoProblema.GetConteudo("descricao")
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjGrupoProblema As New UCLGrupoProblema
        LblCodGrupo.Text = ObjGrupoProblema.GetProximoCodigo(Session("GlEmpresa"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjGrupoProblema As New UCLGrupoProblema
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjGrupoProblema.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjGrupoProblema.SetConteudo("cod_grupo", LblCodGrupo.Text)
                    ObjGrupoProblema = CarregaObjeto(ObjGrupoProblema)
                    ObjGrupoProblema.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjGrupoProblema.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjGrupoProblema.SetConteudo("cod_grupo", LblCodGrupo.Text)
                    ObjGrupoProblema = CarregaObjeto(ObjGrupoProblema)
                    ObjGrupoProblema.Incluir()
                End If
                Response.Redirect("WGGrupoProblema.aspx")
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

    Protected Function CarregaObjeto(ByRef ObjGrupoProblema As UCLGrupoProblema) As UCLGrupoProblema
        ObjGrupoProblema.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        Return ObjGrupoProblema
    End Function

End Class