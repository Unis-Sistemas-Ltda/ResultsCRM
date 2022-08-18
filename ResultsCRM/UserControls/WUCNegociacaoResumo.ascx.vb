Partial Public Class WUCNegociacaoResumo
    Inherits System.Web.UI.UserControl

    Private _Empresa As String
    Private _Estabelecimento As String
    Private _CodNegociacao As String

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property Estabelecimento() As String
        Get
            Return _Estabelecimento
        End Get
        Set(ByVal value As String)
            _Estabelecimento = value
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Carrega()
    End Sub

    Public Sub Carrega()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Dim ObjEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

        If Not String.IsNullOrEmpty(CodNegociacao) Then
            objNegociacao.Empresa = Empresa
            objNegociacao.Estabelecimento = Estabelecimento
            objNegociacao.CodNegociacao = CodNegociacao
            objNegociacao.Buscar()

            LblCodNegociacao.Text = CodNegociacao

            If Not String.IsNullOrWhiteSpace(objNegociacao.CodCliente) Then
                ObjEmitente.CodEmitente = objNegociacao.CodCliente
                ObjEmitente.Buscar()
                LblCliente.Text = ObjEmitente.Nome + " ( " + ObjEmitente.CodEmitente + " )"
            End If
        End If
    End Sub

End Class