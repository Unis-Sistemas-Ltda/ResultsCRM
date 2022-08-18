Public Partial Class WUCModelo
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodModelo As String
    Private _Empresa As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodModelo() As String
        Get
            Return _CodModelo
        End Get
        Set(ByVal value As String)
            _CodModelo = value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
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
        Dim ObjModelo As New UCLModeloNegociacao
        LblCodModelo.Text = CodModelo

        ObjModelo.Empresa = Empresa
        ObjModelo.CodModelo = CodModelo
        ObjModelo.Buscar()

        TxtDescricao.Text = ObjModelo.Descricao
        TxtCabecalho.Text = ObjModelo.Cabecalho
        TxtRodape.Text = ObjModelo.Rodape
    End Sub

    Private Sub CarregaNovaPK()
        Dim objModelo As New UCLModeloNegociacao
        ObjModelo.Empresa = Empresa
        LblCodModelo.Text = objModelo.GetProximoCodigo
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjModelo As New UCLModeloNegociacao
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjModelo.Empresa = Empresa
                    ObjModelo.CodModelo = LblCodModelo.Text
                    ObjModelo = CarregaObjeto(ObjModelo)
                    ObjModelo.Alterar()
                    Response.Redirect("WGModelo.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjModelo.Empresa = Empresa
                    ObjModelo.CodModelo = LblCodModelo.Text
                    ObjModelo = CarregaObjeto(ObjModelo)
                    ObjModelo.Incluir()
                    Response.Redirect("WGModelo.aspx")
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

    Protected Function CarregaObjeto(ByRef ObjModelo As UCLModeloNegociacao) As UCLModeloNegociacao

        ObjModelo.Descricao = TxtDescricao.Text.GetValidInputContent
        ObjModelo.Cabecalho = TxtCabecalho.Text.GetValidInputContent
        ObjModelo.Rodape = TxtRodape.Text.GetValidInputContent

        Return ObjModelo
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGModelo.aspx")
    End Sub
End Class