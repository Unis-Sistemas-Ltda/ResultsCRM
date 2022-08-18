Public Partial Class WUCCliente
    Inherits System.Web.UI.UserControl
    Private _Controle As String
    Private _Fechar As String

    Public Property Controle() As String
        Get
            Return _Controle
        End Get
        Set(ByVal value As String)
            _Controle = value
        End Set
    End Property

    Public Property Fechar() As String
        Get
            Return _Fechar
        End Get
        Set(ByVal value As String)
            _Fechar = value
        End Set
    End Property

    Dim Comando As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim btnSelecionar As ImageButton
        Dim lblCodigo As Label

        btnSelecionar = CType(e.Row.FindControl("BtnSelecionar"), ImageButton)
        lblCodigo = CType(e.Row.FindControl("LblCodigo"), Label)

        If Not btnSelecionar Is Nothing Then
            Comando = "window.opener.document.forms(0)." & Controle & ".value = '" & lblCodigo.Text & "';window.opener.document.forms[0].submit();" & Fechar
            btnSelecionar.Attributes.Add("OnClick", Comando)
        End If
    End Sub

    Protected Sub TxtFornecedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNome.TextChanged
        TxtNome.Text = TxtNome.Text
    End Sub

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFiltrar.Click
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub

End Class