Public Partial Class WUCOrigemNegociacao
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _Codigo As String
    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPk()
            End If

        End If

    End Sub

    Private Sub CarregaNovaPk()
        Dim ObjOrigem As New UCLFonteOrigem
        LblCodigo.Text = ObjOrigem.GetProximoCodigo
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjOrigem As New UCLFonteOrigem
        ObjOrigem.CodFonte = Codigo
        ObjOrigem.Buscar()
        LblCodigo.Text = ObjOrigem.CodFonte
        TxtDescricao.Text = ObjOrigem.Descricao
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjOrigem As New UCLFonteOrigem
        If IsDigitacaoOK() Then
            If Acao = "ALTERAR" Then
                ObjOrigem.CodFonte = LblCodigo.Text
                ObjOrigem.Descricao = TxtDescricao.Text
                ObjOrigem.Alterar()
                Response.Redirect("WGOrigemNegociacao.aspx")
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPk()
                ObjOrigem.CodFonte = LblCodigo.Text
                ObjOrigem.Descricao = TxtDescricao.Text
                ObjOrigem.Incluir()
                Response.Redirect("WGOrigemNegociacao.aspx")
            End If
        End If
    End Sub

    Private Function IsDigitacaoOK() As Boolean
        LblErro.Text = ""
        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text = "Digite a Descrição"
        End If
        Return LblErro.Text = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGOrigemNegociacao.aspx")
    End Sub
End Class