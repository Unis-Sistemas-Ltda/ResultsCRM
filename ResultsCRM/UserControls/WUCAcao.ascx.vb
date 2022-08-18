Public Class WUCAcao
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodAcao As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodAcao() As String
        Get
            Return _CodAcao
        End Get
        Set(ByVal value As String)
            _CodAcao = value
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
        Dim ObjAcao As New UCLAcao
        LblCodAcao.Text = CodAcao

        ObjAcao.Buscar(Session("GlEmpresa"), CodAcao)

        TxtDescricao.Text = ObjAcao.GetConteudo("descricao")
        TxtDescricaoCompleta.Text = ObjAcao.GetConteudo("descricao_completa")
        DdlTipoAcao.Text = ObjAcao.GetConteudo("tipo_acao")
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjAcao As New UCLAcao
        LblCodAcao.Text = ObjAcao.GetProximoCodigo(Session("GlEmpresa"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjAcao As New UCLAcao
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjAcao.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjAcao.SetConteudo("cod_acao", LblCodAcao.Text)
                    ObjAcao = CarregaObjeto(ObjAcao)
                    ObjAcao.Alterar()
                    Response.Redirect("WGAcao.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjAcao.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjAcao.SetConteudo("cod_acao", LblCodAcao.Text)
                    ObjAcao = CarregaObjeto(ObjAcao)
                    ObjAcao.Incluir()
                    Response.Redirect("WGAcao.aspx")
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

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjAcao As UCLAcao) As UCLAcao
        ObjAcao.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        ObjAcao.SetConteudo("descricao_completa", TxtDescricaoCompleta.Text.GetValidInputContent)
        ObjAcao.SetConteudo("tipo_acao", DdlTipoAcao.SelectedValue)
        Return ObjAcao
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGAcao.aspx")
    End Sub


End Class