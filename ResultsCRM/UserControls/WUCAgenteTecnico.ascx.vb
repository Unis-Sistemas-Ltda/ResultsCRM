Partial Public Class WUCAgenteTecnico
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodAgente As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodAgente() As String
        Get
            Return _CodAgente
        End Get
        Set(ByVal value As String)
            _CodAgente = value
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
        Dim objAgente As New UCLAgenteTecnico
        LblCodAgenteTecnico.Text = CodAgente

        objAgente.CodAgenteTecnico = CodAgente
        objAgente.Buscar()

        TxtEmail.Text = objAgente.Email
        TxtTelefone.Text = objAgente.Telefone
        TxtRamal.Text = objAgente.Ramal
        TxtCodUsuario.Text = objAgente.CodUsuario
        TxtNome.Text = objAgente.Nome
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
        Dim objAgente As New UCLAgenteTecnico
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objAgente.CodAgenteTecnico = LblCodAgenteTecnico.Text
                    objAgente = CarregaObjeto(objAgente)
                    objAgente.Alterar()
                    Response.Redirect("WGAgenteTecnico.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objAgente.CodAgenteTecnico = LblCodAgenteTecnico.Text
                    objAgente = CarregaObjeto(objAgente)
                    objAgente.Incluir()
                    Response.Redirect("WGAgenteTecnico.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtNome.Text) Then
            LblErro.Text += "Preencha o campo Nome.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjAgente As UCLAgenteTecnico) As UCLAgenteTecnico

        ObjAgente.Email = TxtEmail.Text.GetValidInputContent
        ObjAgente.Telefone = TxtTelefone.Text
        ObjAgente.Ramal = TxtRamal.Text
        ObjAgente.CodUsuario = TxtCodUsuario.Text
        ObjAgente.Nome = TxtNome.Text.GetValidInputContent

        Return ObjAgente
    End Function

    Private Sub CarregaNovaPK()
        Try
            Dim objAgente As New UCLAgenteTecnico
            LblCodAgenteTecnico.Text = objAgente.GetProximoCodigo()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGAgenteTecnico.aspx")
    End Sub
End Class