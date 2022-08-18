Partial Public Class WUCNegociacaoMotivoFechamento
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodNegociacao As String
    Private _CodMotivo As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodNegociacao() As String
        Get
            Return _CodNegociacao
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property

    Public Property CodMotivo() As String
        Get
            Return _CodMotivo
        End Get
        Set(ByVal value As String)
            _CodMotivo = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaMotivos()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            End If
        End If
    End Sub


    Private Function CarregaObjeto(ByRef objNegociacaoMotivoFechamento As UCLNegociacaoMotivoFechamento) As UCLNegociacaoMotivoFechamento

        objNegociacaoMotivoFechamento.Empresa = Session("GlEmpresa")
        objNegociacaoMotivoFechamento.Estabelecimento = Session("GlEstabelecimento")
        objNegociacaoMotivoFechamento.CodNegociacao = CodNegociacao
        objNegociacaoMotivoFechamento.CodMotivo = DdlMotivoFechamento.SelectedValue

        Return objNegociacaoMotivoFechamento
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objNegociacaoMotivo As New UCLNegociacaoMotivoFechamento(StrConexaoUsuario(Session("GlUsuario")))
        Try

            If Acao = "INCLUIR" Then
                If DdlMotivoFechamento.SelectedValue <> 0 Then
                    objNegociacaoMotivo = CarregaObjeto(objNegociacaoMotivo)
                    objNegociacaoMotivo.Incluir()
                End If
            End If

            Response.Redirect("WGNegociacaoMotivoFechamento.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("WGNegociacaoMotivoFechamento.aspx")
    End Sub

    Protected Sub CarregaFormulario()
        DdlMotivoFechamento.SelectedValue = CodMotivo
    End Sub

    Protected Sub CarregaMotivos()
        Dim objMotivo As New UCLMotivoFechamento
        objMotivo.FillDropDown(DdlMotivoFechamento, True, "")
    End Sub

End Class