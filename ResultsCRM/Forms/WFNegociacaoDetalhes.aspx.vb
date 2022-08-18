Public Partial Class WFNegociacaoDetalhes
    Inherits System.Web.UI.Page

    Public ReadOnly Property BackTo As String
        Get
            Return Request.QueryString.Item("b").ToString()
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            WUCNegociacaoTotais1.Empresa = Session("GlEmpresa")
            WUCNegociacaoTotais1.Estabelecimento = Session("GlEstabelecimento")
            WUCNegociacaoTotais1.CodNegociacao = Session("SCodNegociacao")

            WUCNegociacaoResumo1.Empresa = Session("GlEmpresa")
            WUCNegociacaoResumo1.Estabelecimento = Session("GlEstabelecimento")
            WUCNegociacaoResumo1.CodNegociacao = Session("SCodNegociacao")

            If Not IsPostBack Then
                If Session("GlClienteUnis") = 47 Then
                    Call CarregaFrame(FrameDetalhe, "WFNegociacaoCabecalhoAnfarmag.aspx")
                Else
                    Call CarregaFrame(FrameDetalhe, "WFNegociacaoCabecalho.aspx")
                End If

                If BackTo <> "" Then
                    MnuTabs.Items(MnuTabs.Items.Count - 1).NavigateUrl = BackTo
                    tdTitulo.Attributes.Remove("class")
                    tdTitulo.Attributes.Add("class", "SubTituloMovimento")
                End If
                If Session("GlClienteUnis") <> 45 Then
                    MnuTabs.Items.RemoveAt(9)
                    MnuTabs.Items.RemoveAt(8)
                End If
            End If

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
        If pagina <> "WFNegociacaoCabecalho.aspx" Then
            WUCNegociacaoResumo1.Visible = True
        Else
            If Session("GlClienteUnis") = 47 Then
                pagina = "WFNegociacaoCabecalhoAnfarmag.aspx"
            End If
            WUCNegociacaoResumo1.Visible = False
        End If
        Call CarregaFrame(FrameDetalhe, pagina)
    End Sub

End Class