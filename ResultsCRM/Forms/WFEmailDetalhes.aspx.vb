Public Class WFEmailDetalhes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            Call CarregaFrame(FrameEmail, Request.QueryString.Item("p").ToString() + ".aspx?&e=" + Request.QueryString.Item("e").ToString() + "&t=" + Request.QueryString.Item("t").ToString() + "&tc=" + Request.QueryString.Item("tc") + "&cc=" + Request.QueryString.Item("cc"))
        End If
    End Sub

    Private Sub Voltar()
        Response.Redirect("WGEmail3.aspx?t=" + Request.QueryString.Item("t").ToString() + "&tc=" + Request.QueryString.Item("tc") + "&cc=" + Request.QueryString.Item("cc"))
    End Sub

    Protected Sub MnuTabs_MenuItemClick(sender As Object, e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuTabs.MenuItemClick
        If e.Item.Value = "1" Then
            Call CarregaFrame(FrameEmail, Request.QueryString.Item("p").ToString() + ".aspx?&e=" + Request.QueryString.Item("e").ToString() + "&t=" + Request.QueryString.Item("t").ToString() + "&tc=" + Request.QueryString.Item("tc") + "&cc=" + Request.QueryString.Item("cc"))
        ElseIf e.Item.Value = "2" Then
            Call CarregaFrame(FrameEmail, "WGEmailChamado.aspx?&e=" + Request.QueryString.Item("e").ToString() + "&t=" + Request.QueryString.Item("t").ToString() + "&tc=" + Request.QueryString.Item("tc") + "&cc=" + Request.QueryString.Item("cc"))
        ElseIf e.Item.Value = "0" Then
            Call Voltar()
        ElseIf e.Item.Value = "3.1" Then
            Dim objEmail2 As New UCLEmail2
            objEmail2.Buscar(Session("GlEmpresa"), Request.QueryString.Item("e"))
            If objEmail2.GetConteudo("situacao") = "3" OrElse objEmail2.GetConteudo("situacao") = 4 Then
                Session("SAcaoEmail") = "INCLUIR"
                Session("SAcaoEmailAuxiliar") = "RESPONDER"
                Session("SSeqEmailAuxiliar") = Request.QueryString.Item("e").ToString()
                Response.Redirect("WFEmailDetalhes.aspx?p=WFEmail&e=0&t=4&tc=" + Request.QueryString.Item("tc") + "&cc=" + Request.QueryString.Item("cc"))
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('Para responder, selecione uma mensagem localizada na Caixa de Entrada ou arquivada.')", True)
            End If
        ElseIf e.Item.Value = "3.2" Then
            Session("SAcaoEmail") = "INCLUIR"
            Session("SAcaoEmailAuxiliar") = "ENCAMINHAR"
            Session("SSeqEmailAuxiliar") = Request.QueryString.Item("e").ToString()
            Response.Redirect("WFEmailDetalhes.aspx?p=WFEmail&e=0&t=4&tc=" + Request.QueryString.Item("tc") + "&cc=" + Request.QueryString.Item("cc"))
        ElseIf e.Item.Value = "3.3" Then
            Dim objEmail2 As New UCLEmail2
            objEmail2.Buscar(Session("GlEmpresa"), Request.QueryString.Item("e"))
            If objEmail2.GetConteudo("situacao") = "4" Then
                If objEmail2.IsNull("cod_usuario") Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('Não é permitido arquivar um e-mail sem antes um usuário tê-lo assumido.')", True)
                Else
                    objEmail2.SetConteudo("situacao", "3")
                    objEmail2.Alterar()

                    Dim objEmailHistorico As New UCLEmailHistorico
                    objEmailHistorico.SetConteudo("empresa", Session("GlEmpresa"))
                    objEmailHistorico.SetConteudo("seq_email", Request.QueryString.Item("e"))
                    objEmailHistorico.SetConteudo("seq_historico", objEmailHistorico.GetProximoCodigo(Session("GlEmpresa"), Request.QueryString.Item("e")))
                    objEmailHistorico.SetConteudoData("data_historico", Now())
                    objEmailHistorico.SetConteudo("descricao", "E-mail arquivado.")
                    objEmailHistorico.SetConteudo("cod_usuario", Session("GlCodUsuario"))
                    objEmailHistorico.Incluir()

                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('A mensagem foi arquivada.')", True)
                End If
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('Somente mensagens localizadas na Caixa de Entrada podem ser arquivadas.')", True)
            End If
        ElseIf e.Item.Value = "3.4" Then
            Dim objEmail2 As New UCLEmail2
            objEmail2.Buscar(Session("GlEmpresa"), Request.QueryString.Item("e"))
            If objEmail2.GetConteudo("situacao") = "3" Then
                objEmail2.SetConteudo("situacao", "4")
                objEmail2.Alterar()

                Dim objEmailHistorico As New UCLEmailHistorico
                objEmailHistorico.SetConteudo("empresa", Session("GlEmpresa"))
                objEmailHistorico.SetConteudo("seq_email", Request.QueryString.Item("e"))
                objEmailHistorico.SetConteudo("seq_historico", objEmailHistorico.GetProximoCodigo(Session("GlEmpresa"), Request.QueryString.Item("e")))
                objEmailHistorico.SetConteudoData("data_historico", Now())
                objEmailHistorico.SetConteudo("descricao", "E-mail movido para Caixa de Entrada.")
                objEmailHistorico.SetConteudo("cod_usuario", Session("GlCodUsuario"))
                objEmailHistorico.Incluir()

                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('A mensagem foi movida para Caixa de Entrada.')", True)
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('Somente mensagens arquivadas podem ser movidas para Caixa de Entrada.')", True)
            End If
        ElseIf e.Item.Value = "3.5" Then
            Dim objEmail2 As New UCLEmail2
            objEmail2.Buscar(Session("GlEmpresa"), Request.QueryString.Item("e"))

            If objEmail2.GetConteudo("situacao") = "6" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('E-mail já se encontra na lixeira.')", True)
            Else
                objEmail2.SetConteudo("situacao_origem", objEmail2.GetConteudo("situacao"))
                objEmail2.SetConteudo("situacao", "6")
                objEmail2.Alterar()

                Dim objEmailHistorico As New UCLEmailHistorico
                objEmailHistorico.SetConteudo("empresa", Session("GlEmpresa"))
                objEmailHistorico.SetConteudo("seq_email", Request.QueryString.Item("e"))
                objEmailHistorico.SetConteudo("seq_historico", objEmailHistorico.GetProximoCodigo(Session("GlEmpresa"), Request.QueryString.Item("e")))
                objEmailHistorico.SetConteudoData("data_historico", Now())
                objEmailHistorico.SetConteudo("descricao", "E-mail enviado para lixeira.")
                objEmailHistorico.SetConteudo("cod_usuario", Session("GlCodUsuario"))
                objEmailHistorico.Incluir()

                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('A mensagem foi enviada para lixeira.')", True)
            End If
        ElseIf e.Item.Value = "3.6" Then
            Dim objEmail2 As New UCLEmail2
            objEmail2.Buscar(Session("GlEmpresa"), Request.QueryString.Item("e"))

            If objEmail2.GetConteudo("situacao") <> "6" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('E-mail não se encontra na lixeira.')", True)
            Else
                objEmail2.SetConteudo("situacao", objEmail2.GetConteudo("situacao_origem"))
                objEmail2.SetNull("situacao_origem")
                objEmail2.Alterar()

                Dim objEmailHistorico As New UCLEmailHistorico
                objEmailHistorico.SetConteudo("empresa", Session("GlEmpresa"))
                objEmailHistorico.SetConteudo("seq_email", Request.QueryString.Item("e"))
                objEmailHistorico.SetConteudo("seq_historico", objEmailHistorico.GetProximoCodigo(Session("GlEmpresa"), Request.QueryString.Item("e")))
                objEmailHistorico.SetConteudoData("data_historico", Now())
                objEmailHistorico.SetConteudo("descricao", "E-mail restaurado.")
                objEmailHistorico.SetConteudo("cod_usuario", Session("GlCodUsuario"))
                objEmailHistorico.Incluir()

                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('A mensagem foi restaurada.')", True)
            End If
        ElseIf e.Item.Value = "3.7" Then
            Dim objEmail2 As New UCLEmail2
            If objEmail2.GetSituacaoLeitura(Session("GlEmpresa"), Request.QueryString.Item("e")) = 1 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('E-mail já marcado como lido.')", True)
            Else
                objEmail2.SetSituacaoLeitura(Session("GlEmpresa"), Request.QueryString.Item("e"), "1")
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('E-mail foi marcado como lido.')", True)
            End If
        ElseIf e.Item.Value = "3.8" Then
            Dim objEmail2 As New UCLEmail2
            If objEmail2.GetSituacaoLeitura(Session("GlEmpresa"), Request.QueryString.Item("e")) = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('E-mail já marcado como não lido.')", True)
            Else
                objEmail2.SetSituacaoLeitura(Session("GlEmpresa"), Request.QueryString.Item("e"), "0")
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "alert('E-mail foi marcado como não lido.')", True)
            End If
        ElseIf e.Item.Value = "4" Then
            Call CarregaFrame(FrameEmail, "WGEmailHistorico.aspx?&e=" + Request.QueryString.Item("e").ToString() + "&t=" + Request.QueryString.Item("t").ToString() + "&tc=" + Request.QueryString.Item("tc") + "&cc=" + Request.QueryString.Item("cc"))
        ElseIf e.Item.Value = "5" Then
            Call CarregaFrame(FrameEmail, "WGEmailMarcador.aspx?&e=" + Request.QueryString.Item("e").ToString() + "&t=" + Request.QueryString.Item("t").ToString() + "&tc=" + Request.QueryString.Item("tc") + "&cc=" + Request.QueryString.Item("cc"))
        End If
    End Sub

    Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnVoltar.Click
        Call Voltar()
    End Sub
End Class