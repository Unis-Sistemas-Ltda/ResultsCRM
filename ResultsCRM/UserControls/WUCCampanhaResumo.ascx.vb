Partial Public Class WUCCampanhaResumo
    Inherits System.Web.UI.UserControl

    Private _Empresa As String
    Private _CodCampanha As String

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property CodCampanha() As String
        Get
            Return _CodCampanha
        End Get
        Set(ByVal value As String)
            _CodCampanha = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Carrega()
    End Sub

    Public Sub Carrega()
        Dim objTefGrupo As New UCLTefGrupo()
        If Not String.IsNullOrEmpty(CodCampanha) Then
            objTefGrupo.Buscar(Empresa, CodCampanha)
            LblCodCampanha.Text = CodCampanha
            LblDescricaoCampanha.Text = objTefGrupo.GetConteudo("nome_rede")
        End If
    End Sub

End Class