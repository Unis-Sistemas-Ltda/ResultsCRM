Partial Public Class WFPrincipal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim periodo As String = ""
            Dim nPos As Long

            If String.IsNullOrEmpty(Session("GlCodUsuario")) Then
                Response.Redirect("~/WFDesconectar.aspx")
            End If

            If Session("GlConexao") = "CONTATO" Then
                Response.Redirect("~/WFDesconectar.aspx")
            End If

            If Not IsPostBack Then
                Call ChecaMenu(MnuPrincipal)
            End If

            Select Case Session("GlTipoAcesso")
                Case UCLUsuario.TipoAcesso.SemAcesso
                    Response.Redirect("~/WFDesconectar.aspx")
                Case UCLUsuario.TipoAcesso.Vendas, UCLUsuario.TipoAcesso.Total, UCLUsuario.TipoAcesso.Representante
                    BtnNegociacao.Visible = True
                    BtnCliente.Visible = True
                    BtnTarefas.Visible = True
                    If Not IsPostBack Then
                        'Comentado em 16/02/2023 para não carregar o popup de tarefas
                        'body1.Attributes.Add("onLoad", "window.open('WGTarefas.aspx?tid=1'); ") 'resizeIframe();")
                    Else
                        body1.Attributes.Remove("onLoad")
                        'body1.Attributes.Add("onLoad", "resizeIframe();")
                    End If
                    Call CarregaFrame(FrameConteudo, "WFNegociacaoFiltro.aspx")
                    If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Total Then
                        BtnAtendimentos.Visible = True
                    ElseIf Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
                        MnuPrincipal.Items.Item(0).ChildItems.Item(1).Enabled = False
                        MnuPrincipal.Items.Item(0).ChildItems.Item(2).Enabled = False
                        MnuPrincipal.Items.Item(0).ChildItems.Item(3).Enabled = False
                        MnuPrincipal.Items.Item(0).ChildItems.Item(4).Enabled = False
                        MnuPrincipal.Items.Item(0).ChildItems.Item(5).Enabled = False
                        MnuPrincipal.Items.Item(0).ChildItems.Item(6).Enabled = False

                        'MnuPrincipal.Items.Item(1).ChildItems.Item(2).Enabled = False
                        'MnuPrincipal.Items.Item(1).ChildItems.Item(3).Enabled = False
                        MnuPrincipal.Items.Item(1).ChildItems.Item(4).Enabled = False
                        MnuPrincipal.Items.Item(1).ChildItems.Item(7).Enabled = False
                        MnuPrincipal.Items.Item(1).ChildItems.Item(8).Enabled = False
                        MnuPrincipal.Items.Item(1).ChildItems.Item(11).Enabled = False
                        MnuPrincipal.Items.Item(1).ChildItems.Item(12).Enabled = False
                        MnuPrincipal.Items.Item(1).ChildItems.Item(13).Enabled = False
                        MnuPrincipal.Items.Item(1).ChildItems.Item(14).Enabled = False
                        MnuPrincipal.Items.Item(1).ChildItems.Item(15).Enabled = False
                        MnuPrincipal.Items.Item(1).ChildItems.Item(16).Enabled = False
                        MnuPrincipal.Items(2).ChildItems(1).Enabled = False
                        MnuPrincipal.Items(2).ChildItems(2).Enabled = False

                        MnuPrincipal.Items(3).Enabled = False
                        BtnAtendimentos.Visible = True
                    End If
                Case UCLUsuario.TipoAcesso.PosVendas
                    BtnCliente.Visible = True
                    BtnAtendimentos.Visible = True
                    body1.Attributes.Remove("onLoad")
                    'body1.Attributes.Add("onLoad", "resizeIframe();")
                    Call CarregaFrame(FrameConteudo, "WGAtendimento.aspx")
                Case UCLUsuario.TipoAcesso.Regional
                    MnuPrincipal.Enabled = False
                    BtnNegociacao.Visible = True
                    BtnCliente.Visible = True
                    BtnTarefas.Visible = True
                    BtnAtendimentos.Visible = True
                    Call CarregaFrame(FrameConteudo, "WFNegociacaoFiltro.aspx")

            End Select

            If Not IsPostBack Then
                Select Case Session("GlClienteUnis")
                    Case 45, 388
                    Case Else
                        MnuPrincipal.Items.Item(1).ChildItems.Item(6).Enabled = False
                End Select
                LblRelogio.Text = Now.ToString("dd/MM/yy  HH:mm")
            End If

            Select Case System.DateTime.Now.Hour
                Case 4 To 11
                    periodo = "Bom dia!"
                Case 12 To 17
                    periodo = "Boa tarde!"
                Case 18 To 23, 0 To 3
                    periodo = "Boa noite!"
            End Select

            nPos = Session("GlNomeUsuario").ToString.Trim.IndexOf(" ")
            If nPos = -1 Then
                nPos = Session("GlNomeUsuario").ToString.Trim.Length
            End If

            LblNomeUsuario.Text = "Olá, " + Session("GlNomeUsuario").ToString.Trim.Substring(0, nPos) + "! " + periodo
            LblRazaoSocial.Text = Session("GlRazaoSocial")

            Call SetPermissaoMenu_Old()
            'Call SetPermissaoMenu(Session("GlCodGrupoExterno"), (Session("GlIDSituacao") = 1))

        Catch ex As Exception
            'Response.Redirect("~/WFDesconectar.aspx")
            LblErro.Text = ex.Message
        End Try

    End Sub

    Protected Sub ChecaMenu(ByVal mnu As Menu)
        Session("GlMenu") = mnu
    End Sub

    Protected Sub MnuPrincipal_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuPrincipal.MenuItemClick
        Dim pagina As String = e.Item.Value
        Call CarregaFrame(FrameConteudo, pagina)
    End Sub

    Protected Sub BtnTarefas_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnTarefas.Click
        Call CarregaFrame(FrameConteudo, "WGTarefas.aspx?tid=0")
    End Sub

    Protected Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.FrameBorder = "0"
        frame.Scrolling = "no"
        frame.DataBind()
    End Sub

    Protected Sub BtnNegociacao_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNegociacao.Click
        Call CarregaFrame(FrameConteudo, "WFNegociacaoFiltro.aspx")
    End Sub

    Protected Sub BtnCliente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCliente.Click
        Dim objParametrosCRM As New UCLParametrosCRM
        objParametrosCRM.Empresa = Session("GlEmpresa")
        If objParametrosCRM.Buscar() Then
            If objParametrosCRM.TipoPainelCliente = 1 Then
                Call CarregaFrame(FrameConteudo, "WGPosVenda.aspx")
            Else
                Call CarregaFrame(FrameConteudo, "WGPosVenda.aspx")
            End If
        Else
            Call CarregaFrame(FrameConteudo, "WGPosVenda.aspx")
        End If
    End Sub

    Protected Sub BtnAtendimentos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAtendimentos.Click
        Session.Remove("S_PCH_TxtNrAtendimento")
        Session.Remove("S_PCH_TxtOSCliente")
        Session.Remove("S_PCH_TxtOSInterna")
        Session.Remove("S_PCH_TxtData")
        Session.Remove("S_PCH_TxtCodEmitente")
        Session.Remove("S_PCH_TxtNomeEmitente")
        Session.Remove("S_PCH_DdlContato")
        Session.Remove("S_PCH_TxtPontoDeAtendimento")
        Session.Remove("S_PCH_DdlReabertura")
        Session.Remove("S_PCH_ddlTipoChamado")
        Session.Remove("S_PCH_ddlTipoStatus")
        Session.Remove("S_PCH_DdlStatus")
        Session.Remove("S_PCH_TxtAssunto")
        Session.Remove("S_PCH_ddlAnalista")
        Session.Remove("S_PCH_ddlAgenteTecnico")
        Session.Remove("S_PCH_TxtObservacao")
        Session.Remove("S_PCH_DdlTop")
        Call CarregaFrame(FrameConteudo, "WGAtendimento.aspx")
    End Sub

    Protected Sub SetPermissaoMenu(ByVal pCodGrupoExterno As String, ByVal pAdministrador As Boolean)
        Try
            Dim objGrupo As New UCLSysGrupoExterno
            Dim objGrupoExternoPermissoes As New List(Of UCLSysGrupoExternoPermissao)
            Dim permissoes As New List(Of String)
            Dim m1, m2, m3, m4, m5 As MenuItem

            If pAdministrador Then
                Return
            End If

            objGrupo.Buscar(pCodGrupoExterno)
            objGrupoExternoPermissoes = objGrupo.Permissoes(Session("GlEmpresa"), pCodGrupoExterno)

            For Each perm As UCLSysGrupoExternoPermissao In objGrupoExternoPermissoes
                permissoes.Add(perm.NomeMenuItem)
            Next

            For i As Long = MnuPrincipal.Items.Count - 1 To 0 Step -1
                m1 = MnuPrincipal.Items.Item(i)
                If m1.ChildItems.Count > 0 Then
                    For j As Long = m1.ChildItems.Count - 1 To 0 Step -1
                        m2 = m1.ChildItems.Item(j)
                        If m2.ChildItems.Count > 0 Then
                            For k As Long = m2.ChildItems.Count - 1 To 0 Step -1
                                m3 = m2.ChildItems.Item(k)
                                If m3.ChildItems.Count > 0 Then
                                    For l As Long = m3.ChildItems.Count - 1 To 0 Step -1
                                        m4 = m3.ChildItems.Item(l)
                                        If m4.ChildItems.Count > 0 Then
                                            For m As Long = m4.ChildItems.Count - 1 To 0 Step -1
                                                m5 = m4.ChildItems.Item(m)
                                                If m5.ChildItems.Count > 0 Then
                                                    If Not permissoes.Contains(m4.Value) Then
                                                        m5.ChildItems.RemoveAt(m)
                                                    End If
                                                Else
                                                    If Not permissoes.Contains(m5.Value) Then
                                                        m4.ChildItems.RemoveAt(m)
                                                    End If
                                                End If
                                            Next
                                        Else
                                            If Not permissoes.Contains(m4.Value) Then
                                                m3.ChildItems.RemoveAt(l)
                                            End If
                                        End If
                                    Next
                                Else
                                    If Not permissoes.Contains(m3.Value) Then
                                        m2.ChildItems.RemoveAt(k)
                                    End If
                                End If
                            Next
                        Else
                            If Not permissoes.Contains(m2.Value) Then
                                m1.ChildItems.RemoveAt(j)
                            End If
                        End If
                    Next
                Else
                    If Not permissoes.Contains(m1.Value) Then
                        MnuPrincipal.Items.RemoveAt(i)
                    End If
                End If
            Next

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub SetPermissaoMenu_Old()
        Dim isAgenteVendas As Boolean
        Dim isAgentePosVendas As Boolean

        Select Case Session("GlTipoAcesso")
            Case UCLUsuario.TipoAcesso.SemAcesso
                isAgenteVendas = False
                isAgentePosVendas = False
            Case UCLUsuario.TipoAcesso.Total
                isAgenteVendas = True
                isAgentePosVendas = True
            Case UCLUsuario.TipoAcesso.PosVendas
                isAgenteVendas = False
                isAgentePosVendas = True
            Case UCLUsuario.TipoAcesso.Vendas
                isAgenteVendas = True
                isAgentePosVendas = False
            Case UCLUsuario.TipoAcesso.Representante
                isAgenteVendas = True
                isAgentePosVendas = True
        End Select

        MnuPrincipal.Items.Item(1).ChildItems.Item(1).Enabled = isAgenteVendas
        MnuPrincipal.Items.Item(1).ChildItems.Item(2).Enabled = isAgentePosVendas
        MnuPrincipal.Items.Item(1).ChildItems.Item(3).Enabled = isAgentePosVendas
        MnuPrincipal.Items.Item(1).ChildItems.Item(4).Enabled = isAgentePosVendas
        MnuPrincipal.Items.Item(1).ChildItems.Item(5).Enabled = (isAgentePosVendas OrElse isAgenteVendas)
        MnuPrincipal.Items.Item(2).ChildItems.Item(0).Enabled = isAgenteVendas

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim nPos As Long
        Dim periodo As String = ""
        LblRelogio.Text = Now.ToString("dd/MM/yy  HH:mm")

        Select Case System.DateTime.Now.Hour
            Case 4 To 11
                periodo = "Bom dia!"
            Case 12 To 17
                periodo = "Boa tarde!"
            Case 18 To 23, 0 To 3
                periodo = "Boa noite!"
        End Select

        nPos = Session("GlNomeUsuario").ToString.Trim.IndexOf(" ")
        If nPos = -1 Then
            nPos = Session("GlNomeUsuario").ToString.Trim.Length
        End If

        LblNomeUsuario.Text = "Olá, " + Session("GlNomeUsuario").ToString.Trim.Substring(0, nPos) + "! " + periodo
    End Sub

    Private Sub BtnNegociacao_Command(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs) Handles BtnNegociacao.Command

    End Sub
End Class