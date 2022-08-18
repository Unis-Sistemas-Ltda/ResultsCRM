Partial Public Class WFCampanhaDetalhes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCCampanhaResumo1.Empresa = Session("GlEmpresa")
        WUCCampanhaResumo1.CodCampanha = Session("SCodCampanha")

        If Not IsPostBack Then
            Call CarregaFrame(FrameDetalhe, "WFCampanhaCabecalho.aspx")
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
        If pagina <> "WFCampanhaCabecalho.aspx" Then
            WUCCampanhaResumo1.Visible = True
        Else
            WUCCampanhaResumo1.Visible = False
        End If
        Call CarregaFrame(FrameDetalhe, pagina)
    End Sub

End Class