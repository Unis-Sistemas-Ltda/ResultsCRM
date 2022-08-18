Public Class WFAtendimentoEmailDetalhes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaFrame(FrameDetalhe, "WGEmail3.aspx?t=0&tc=1&cc=" + Session("SCodAtendimento"))
        End If
    End Sub

    Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        body1.Attributes.Add("onLoad", "resizeIframeMeio();")
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.DataBind()
    End Sub

    Protected Sub MnuTabs_MenuItemClick(ByVal sender As Object, e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuTabs.MenuItemClick
        Dim value As String = e.Item.Value
        Dim carregar As String

        If value = "!" Then
            For Each mi As MenuItem In MnuTabs.Items
                If mi.Value = "!" Then
                    mi.Selected = False
                ElseIf mi.Value = "0" Then
                    mi.Selected = True
                End If
            Next
            MnuTabs.DataBind()
            Session("SAcaoEmail") = "INCLUIR"
            carregar = "WFEmailDetalhes.aspx?p=WFEmail&e=0&t=0&tc=1&cc=" + Session("SCodAtendimento")
        Else
            carregar = "WGEmail3.aspx?t=" + value + "&tc=1&cc=" + Session("SCodAtendimento")
        End If

        Call CarregaFrame(FrameDetalhe, carregar)
    End Sub
End Class