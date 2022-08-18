Partial Public Class WFAtendimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'bodyAtendimento.Attributes.Remove("onLoad")
        'bodyAtendimento.Attributes.Add("onLoad", "resizeIframeAtendimento();")

        If Not IsPostBack Then
            Call CarregaCabecalhoAtendimento()
            Dim ObjParametrosManutencao As New UCLParametrosManutencao
            ObjParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
            If ObjParametrosManutencao.GetConteudo("mostrar_pasta_horas_chamado_crm") = "N" Then
                MnuTabs.Items.RemoveAt(9)
            End If
        End If
    End Sub

    Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.Scrolling = "no"
        frame.Carregar()
        'frame.DataBind()
    End Sub

    Protected Sub MnuTabs_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuTabs.MenuItemClick
        Dim pagina As String = e.Item.Value
        If pagina = "WFAtendimentoCabecalho.aspx" Then
            Call CarregaCabecalhoAtendimento()
        ElseIf pagina = "#" Then
            Response.Redirect(Session("SCamVoltar"))
        Else
            Call CarregaFrame(FrameSuperior, pagina)
        End If
    End Sub

    Private Sub CarregaCabecalhoAtendimento()
        Try
            Dim objParametrosManutencao As New UCLParametrosManutencao
            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
            If objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 1 Then
                CarregaFrame(FrameSuperior, "WFAtendimentoCabecalho.aspx")
            ElseIf objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 2 Then
                CarregaFrame(FrameSuperior, "WFAtendimentoCabecalho_Suporte.aspx")
            ElseIf objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 3 Then
                CarregaFrame(FrameSuperior, "WFAtendimentoCabecalho_Suporte_Software.aspx")
            ElseIf objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 4 Then
                CarregaFrame(FrameSuperior, "WFAtendimentoCabecalho_AssistenciaTecnica2.aspx")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class