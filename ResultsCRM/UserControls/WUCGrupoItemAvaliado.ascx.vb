Public Class WUCGrupoItemAvaliado
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodGrupoItem As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodGrupoItem() As String
        Get
            Return _CodGrupoItem
        End Get
        Set(ByVal value As String)
            _CodGrupoItem = value
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
        Dim ObjGrupo As New UCLGrupoItemAvaliado
        LblCodGrupoItem.Text = CodGrupoItem
        ObjGrupo.Buscar(Session("GlEmpresa"), CodGrupoItem)
        TxtDescricao.Text = ObjGrupo.GetConteudo("descricao")
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjGrupo As New UCLGrupoItemAvaliado
        LblCodGrupoItem.Text = ObjGrupo.GetProximoCodigo(Session("GlEmpresa"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjGrupo As New UCLGrupoItemAvaliado
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjGrupo.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjGrupo.SetConteudo("cod_grupo_item", LblCodGrupoItem.Text)
                    ObjGrupo = CarregaObjeto(ObjGrupo)
                    ObjGrupo.Alterar()
                    Response.Redirect("WGGrupoItemAvaliado.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjGrupo.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjGrupo.SetConteudo("cod_grupo_item", LblCodGrupoItem.Text)
                    ObjGrupo = CarregaObjeto(ObjGrupo)
                    ObjGrupo.Incluir()
                    Response.Redirect("WGGrupoItemAvaliado.aspx")
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

    Protected Function CarregaObjeto(ByRef ObjGrupo As UCLGrupoItemAvaliado) As UCLGrupoItemAvaliado
        ObjGrupo.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        Return ObjGrupo
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGGrupoItemAvaliado.aspx")
    End Sub

End Class