Public Class WFTEF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaFrame(FrameDetalhe, "WFTEFCabecalho.aspx")
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
        If pagina = "#" Then
            If Request.QueryString.Item("ori") = "P" Then
                Response.Redirect("WGTEF.aspx?t=" + Now.ToString("ddMMyyyyHHmmss"))
            ElseIf Request.QueryString.Item("ori") = "N" Then
                Response.Redirect("WGNegociacaoCampanhaTEF.aspx?t=" + Now.ToString("ddMMyyyyHHmmss"))
            End If
        Else
            Call CarregaFrame(FrameDetalhe, pagina)
        End If
    End Sub

End Class