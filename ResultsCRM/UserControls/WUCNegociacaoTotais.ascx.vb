Public Partial Class WUCNegociacaoTotais
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

        If Not String.IsNullOrEmpty(CodNegociacao) Then
            objNegociacao.Empresa = Empresa
            objNegociacao.Estabelecimento = Estabelecimento
            objNegociacao.CodNegociacao = CodNegociacao
            objNegociacao.Buscar()

            LblTotalDesconto.Text = objNegociacao.TotalDesconto
            LblTotalGeral.Text = objNegociacao.TotalPedido
            LblTotalICMS.Text = objNegociacao.TotalICMS
            LblTotalICMSST.Text = objNegociacao.TotalICMSST
            LblTotalIPI.Text = objNegociacao.TotalIPI
            LblTotalMercadoria.Text = objNegociacao.TotalMercadoria
        End If
    End Sub

End Class