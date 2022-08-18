Public Class WGPosVendaNegociacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SCamVoltar") = "WGPosVendaNegociacao.aspx"
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SCodNegociacao") = e.CommandArgument
            ''Response.Redirect("WFNegociacaoDetalhes.aspx?b=WFNegociacaoFiltro.aspx")
            ''Call CarregaFrame(FrameConteudo, "WFNegociacaoDetalhes.aspx?b=WFNegociacaoFiltro.aspx")
        End If
    End Sub

    Protected Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.FrameBorder = "0"
        frame.Scrolling = "no"
        frame.DataBind()
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Session("SCodContato") = -1
        ''Response.Redirect("WFContato.aspx?a=I&vcodc=SCodContato&vcode=SCodEmitente")
    End Sub
End Class