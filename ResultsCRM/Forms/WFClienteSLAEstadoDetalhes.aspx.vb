Public Class WFClienteSLAEstadoDetalhes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaFrame(FrameDetalhes, "WFClienteSLAEstado.aspx")
        End If
    End Sub

    Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.DataBind()
    End Sub

    Protected Sub MnuTabs_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuTabs.MenuItemClick
        Dim pagina As String = e.Item.Value
        Call CarregaFrame(FrameDetalhes, pagina)
    End Sub

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGClienteSLAEstado.aspx")
    End Sub
End Class