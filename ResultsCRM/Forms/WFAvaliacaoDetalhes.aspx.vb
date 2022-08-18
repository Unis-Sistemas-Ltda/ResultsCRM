Public Class WFAvaliacaoDetalhes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaFrame(FrameSuperior, "WFAvaliacao.aspx")
        End If
    End Sub

    Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.Scrolling = "no"
        frame.Carregar()
    End Sub

    Protected Sub MnuTabs_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuTabs.MenuItemClick
        Dim pagina As String = e.Item.Value
        If pagina = "#" Then
            Response.Redirect("WGAvaliacao.aspx")
        Else
            Dim objAvaliacao As New UCLAvaliacaoCliente
            objAvaliacao.Buscar(Session("GlEmpresa"), Session("SCodAvaliacao"))
            Session("SCodTipoAvaliacao") = objAvaliacao.GetConteudo("cod_tipo_avaliacao")
            Call CarregaFrame(FrameSuperior, pagina)
        End If
    End Sub

End Class