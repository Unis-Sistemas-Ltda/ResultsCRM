Partial Public Class WFPosVendaDetalhes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaFrame(FrameDetalhe, "WGPosVendaChamados.aspx")
            If Session("GlClienteUnis") = 45 Then
                MnuTabs.Items(7).Text = "TEF"
                MnuTabs.Items(7).Value = "WFClienteTEF.aspx?e=" + Session("SCodEmitente").ToString()
            End If
            If Session("GlClienteUnis") <> 47 Then
                MnuTabs.Items.RemoveAt(2)
                MnuTabs.Items.RemoveAt(1)
            End If
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
        Call CarregaFrame(FrameDetalhe, pagina)
    End Sub

End Class