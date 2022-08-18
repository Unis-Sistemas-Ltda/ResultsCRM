Partial Public Class WUCCausa
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodCausa As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodCausa() As String
        Get
            Return _CodCausa
        End Get
        Set(ByVal value As String)
            _CodCausa = value
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
        Dim ObjCausa As New UCLCausa
        LblCodCausa.Text = CodCausa

        ObjCausa.Empresa = Session("GlEmpresa")
        ObjCausa.Codigo = CodCausa
        ObjCausa.Buscar()

        TxtDescricao.Text = ObjCausa.Descricao
        TxtDescricaoCompleta.Text = ObjCausa.DescricaoCompleta
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjCausa As New UCLCausa
        LblCodCausa.Text = ObjCausa.GetProximoCodigo(Session("GlEmpresa"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjCausa As New UCLCausa
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjCausa.Empresa = Session("GlEmpresa")
                    ObjCausa.Codigo = LblCodCausa.Text
                    ObjCausa = CarregaObjeto(ObjCausa)
                    ObjCausa.Alterar()
                    LblErro.Text = "Cadastro alterado com sucesso."
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjCausa.Empresa = Session("GlEmpresa")
                    ObjCausa.Codigo = LblCodCausa.Text
                    ObjCausa = CarregaObjeto(ObjCausa)
                    ObjCausa.Incluir()
                    Session("SCodCausa") = LblCodCausa.Text
                    Session("SAcao") = "ALTERAR"
                    LblErro.Text = "Cadastro incluído com sucesso."
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

    Protected Function CarregaObjeto(ByRef ObjCausa As UCLCausa) As UCLCausa
        ObjCausa.Descricao = TxtDescricao.Text.GetValidInputContent
        ObjCausa.DescricaoCompleta = TxtDescricaoCompleta.Text.GetValidInputContent
        Return ObjCausa
    End Function

End Class