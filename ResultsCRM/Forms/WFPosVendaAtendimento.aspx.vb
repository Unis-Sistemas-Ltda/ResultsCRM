Public Class WFPosVendaAtendimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim objParametrosManutencao As New UCLParametrosManutencao
            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))

            If objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 1 Then
                CarregaFrame(FrameDetalhes, "WFAtendimentoCabecalho.aspx")
            ElseIf objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 2 Then
                CarregaFrame(FrameDetalhes, "WFAtendimentoCabecalho_Suporte.aspx")
            ElseIf objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 3 Then
                CarregaFrame(FrameDetalhes, "WFAtendimentoCabecalho_Suporte_Software.aspx")
            ElseIf objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 4 Then
                CarregaFrame(FrameDetalhes, "WFAtendimentoCabecalho_AssistenciaTecnica2.aspx")
            End If
        End If
        If Not String.IsNullOrEmpty(Session("SCamVoltar")) Then
            BtnVoltar.Visible = True
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
        Response.Redirect(Session("SCamVoltar"))
    End Sub
End Class