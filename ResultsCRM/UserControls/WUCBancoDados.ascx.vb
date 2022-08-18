Partial Public Class WUCBancoDados
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
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjBancoDados As New UCLBancoDados
        LblCodigo.Text = Codigo

        ObjBancoDados.CodBancoDados = Codigo
        ObjBancoDados.Buscar()

        TxtDescricao.Text = ObjBancoDados.Descricao
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjBancoDados As New UCLBancoDados
        LblCodigo.Text = ObjBancoDados.GetProximoCodigo
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjBancoDados As New UCLBancoDados
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjBancoDados.CodBancoDados = LblCodigo.Text
                    ObjBancoDados = CarregaObjeto(ObjBancoDados)
                    ObjBancoDados.Alterar()
                    Response.Redirect("WGBancoDados.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjBancoDados.CodBancoDados = LblCodigo.Text
                    ObjBancoDados = CarregaObjeto(ObjBancoDados)
                    ObjBancoDados.Incluir()
                    Response.Redirect("WGBancoDados.aspx")
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

    Protected Function CarregaObjeto(ByRef ObjBancoDados As UCLBancoDados) As UCLBancoDados
        ObjBancoDados.Descricao = TxtDescricao.Text.GetValidInputContent
        Return ObjBancoDados
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGBancoDados.aspx")
    End Sub
End Class