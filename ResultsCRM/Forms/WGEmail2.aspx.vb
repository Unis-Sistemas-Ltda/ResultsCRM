Public Class WGEmail2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("SAcaoEmailAuxiliar") = ""
            Session("SSeqEmailAuxiliar") = "0"
            LblMenuSelecionado.Text = MnuTabs.Items.Item(1).Value
            Call CarregaFrame(FrameSuperior, LblMenuSelecionado.Text)
            Call CarregaMenuMarcadores()
        End If
    End Sub

    Private Sub CarregaMenuMarcadores()
        Try
            Dim objMarcador As New UCLMarcador
            objMarcador.FillMenu(MnuMarcadores, Session("GlEmpresa"), False, "", "0", "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.DataBind()
    End Sub

    Protected Sub MnuTabs_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuTabs.MenuItemClick
        Dim pagina As String = e.Item.Value
        Dim carregar As String = pagina
        If pagina = "#" Then
            For Each mi As MenuItem In MnuTabs.Items
                If mi.Value = LblMenuSelecionado.Text Then
                    mi.Selected = True
                ElseIf mi.Value = "#" Then
                    mi.Selected = False
                End If
            Next
            MnuTabs.DataBind()
            carregar = LblMenuSelecionado.Text
        Else
            If pagina = "!" Then
                For Each mi As MenuItem In MnuTabs.Items
                    If mi.Value = "!" Then
                        mi.Selected = False
                    ElseIf mi.Value = "WGEmail3.aspx?t=4&tc=0&cc=0" Then
                        mi.Selected = True
                    End If
                Next
                MnuTabs.DataBind()
                Session("SAcaoEmail") = "INCLUIR"
                LblMenuSelecionado.Text = "WGEmail3.aspx?t=4&tc=0&cc=0"
                carregar = "WFEmailDetalhes.aspx?p=WFEmail&e=0&t=4&tc=0&cc=0"
            Else
                LblMenuSelecionado.Text = pagina
            End If
        End If
        Call CarregaFrame(FrameSuperior, carregar)
    End Sub

    Protected Sub MnuMarcadores_MenuItemClick(sender As Object, e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuMarcadores.MenuItemClick
        Session("S_PEM_DdlMarcador") = e.Item.Value
        Call CarregaFrame(FrameSuperior, LblMenuSelecionado.Text)
    End Sub
End Class