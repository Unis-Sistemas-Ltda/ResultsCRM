Public Partial Class WUCGestorConta
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodGestor As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodGestor() As String
        Get
            Return _CodGestor
        End Get
        Set(ByVal value As String)
            _CodGestor = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim alterouCodUsuario As Long
        Dim CodUsuarioPesquisado As String = Session("SCodUsuarioPesquisado")

        If Not String.IsNullOrEmpty(Session("SAlterouCodUsuario")) Then
            alterouCodUsuario = Session("SAlterouCodUsuario")
        Else
            alterouCodUsuario = 0
        End If

        If Not String.IsNullOrEmpty(CodUsuarioPesquisado) Then
            If alterouCodUsuario > 0 Then
                If TxtCodUsuario.Text <> CodUsuarioPesquisado Then
                    TxtCodUsuario.Text = CodUsuarioPesquisado
                End If
                Session("SAlterouCodUsuario") = alterouCodUsuario - 1
            End If
        End If

        If Not IsPostBack Then
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If

        Call MostraNomeUsuario()
    End Sub

    Private Sub CarregaFormulario()
        Dim objGestor As New UCLGestorConta
        LblCodGestor.Text = CodGestor

        objGestor.Codigo = CodGestor
        objGestor.Buscar()

        TxtCodUsuario.Text = objGestor.CodUsuario
        TxtEmail.Text = objGestor.Email
    End Sub

    Private Sub CarregaNovaPK()
        Dim objGestor As New UCLGestorConta
        LblCodGestor.Text = objGestor.GetProximoCodigo
    End Sub

    Private Sub MostraNomeUsuario()
        Dim objUsuario As New UCLUsuario
        If Not String.IsNullOrEmpty(TxtCodUsuario.Text) Then
            objUsuario.CodUsuario = TxtCodUsuario.Text
            objUsuario.BuscarPorCodigo()
            LblNomeUsuario.Text = objUsuario.NomeUsuario
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objGestor As New UCLGestorConta
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objGestor.Codigo = LblCodGestor.Text
                    objGestor = CarregaObjeto(objGestor)
                    objGestor.Alterar()
                    Response.Redirect("WGGestorConta.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objGestor.Codigo = LblCodGestor.Text
                    objGestor = CarregaObjeto(objGestor)
                    objGestor.Incluir()
                    Response.Redirect("WGGestorConta.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtEmail.Text) Then
            LblErro.Text += "Preencha o campo Email.<br/>"
        End If

        If String.IsNullOrEmpty(TxtCodUsuario.Text) Then
            LblErro.Text += "Preencha o campo Usuário.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjGestor As UCLGestorConta) As UCLGestorConta

        ObjGestor.CodUsuario = TxtCodUsuario.Text
        ObjGestor.Email = TxtEmail.Text.GetValidInputContent

        Return ObjGestor
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGGestorConta.aspx")
    End Sub
End Class