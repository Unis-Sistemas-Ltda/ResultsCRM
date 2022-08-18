Partial Public Class WFClienteDados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim menuItem As MenuItem
            Dim tpPessoa As String = objEmitente.GetTipoPessoa(Session("SCodEmitente"))
            If tpPessoa = "PF" Then
                menuItem = New MenuItem
                menuItem.Text = "PJ Vinculados"
                menuItem.Value = "WGPosVendaPJVinculados.aspx"
                MnuTabs.Items.Add(menuItem)
            End If
            Call CarregaFrame(FrameDados, "WFClienteCabecalho.aspx?embeeded=False&vcodemi=SCodEmitente&vcodemp=SCodClientePesquisado&valtecc=SAlterouCodCliente&vrecdc=SRecarregaDdlContatos&ccodcon=SCodContatoNegociacao&cnpjemi=SCNPJEmitente&vcodemin=SCodEmitenteNegociacao")
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
        Call CarregaFrame(FrameDados, pagina)
    End Sub

End Class