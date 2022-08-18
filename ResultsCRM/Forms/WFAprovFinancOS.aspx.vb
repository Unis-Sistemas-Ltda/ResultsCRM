Public Partial Class WFAprovFinancOS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CarregaFrame(FrameSuperior, "WFAprovFinancOSCabecalho.aspx")
            CarregaFrame(FrameInferior, "WFAprovFinancOSDetalhes.aspx")
        End If
    End Sub

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGAprovFinancOS.aspx")
    End Sub

    Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.DataBind()
    End Sub

End Class