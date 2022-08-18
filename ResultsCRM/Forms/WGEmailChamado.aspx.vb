Public Class WGEmailChamado
    Inherits System.Web.UI.Page

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodAtendimento") = e.CommandArgument
            Session("SModoAbertura") = 1
            Session("SCamVoltar") = "WGEmailChamado.aspx?e=" + Request.QueryString.Item("e") + "&t=" + Request.QueryString.Item("t")
            Session("SSequenciaEmail") = Request.QueryString.Item("e")
            Response.Redirect("WFAtendimento.aspx")
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(sender As Object, e As EventArgs) Handles BtnNovoRegistro.Click
        Try
            Dim objContatos As New UCLContato
            Dim objEmail2 As New UCLEmail2
            Dim objEmitente As New UCLEmitente(StrConexao)

            Dim objAnalista As New UCLAnalista
            objAnalista.Codigo = Session("GlCodUsuario")

            If Not objAnalista.Buscar() Then
                Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('Usuário não é analista. Não é possível incluir chamado.')", True)
                Return
            End If

            Session("SAcao") = "INCLUIR"
            Session("SCodAtendimento") = -1
            Session("SModoAbertura") = 1
            Session("SCamVoltar") = "WGEmailChamado.aspx?e=" + Request.QueryString.Item("e") + "&t=" + Request.QueryString.Item("t")
            Session("SSequenciaEmail") = Request.QueryString.Item("e")
            If objEmail2.Buscar(Session("GlEmpresa"), Request.QueryString.Item("e").ToString()) Then
                Session("SCodEmitente") = objContatos.GetCodEmitentePeloEmail(objEmail2.GetConteudo("remetente_email"))
                If String.IsNullOrEmpty(Session("SCodEmitente")) OrElse Session("SCodEmitente") = "-1" Then
                    Session.Remove("SCodEmitente")
                    Session.Remove("SCNPJEmitente")
                Else
                    Session("SCNPJEmitente") = objEmitente.GetCNPJ(Session("SCodEmitente"), UCLEmitente.TipoCNPJ.Preferencial)
                End If
                Session("SAssuntoChamado") = objEmail2.GetConteudo("assunto")
            Else
                Session.Remove("SCodEmitente")
                Session.Remove("SCNPJEmitente")
                Session("SAssuntoChamado") = ""
            End If

            Response.Redirect("WFAtendimento.aspx")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not String.IsNullOrEmpty(TxtVincularChamado.Text) Then
            If Not IsNumeric(TxtVincularChamado.Text) Then
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "onload", "alert('Informe corretamente o número do chamado a ser vinculado.')", True)
            Else
                Dim objChamado As New UCLAtendimento(StrConexao)
                objChamado.Empresa = Session("GlEmpresa")
                objChamado.CodChamado = TxtVincularChamado.Text.GetValidInputContent
                If Not objChamado.Buscar() Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "onload", "alert('Chamado não cadastrado. Informe um número de chamado válido.')", True)
                Else
                    Dim objEmailChamado As New UCLEmailChamado
                    If objEmailChamado.Buscar(Session("GlEmpresa"), Request.QueryString.Item("e"), TxtVincularChamado.Text) Then
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "onload", "alert('Chamado já foi vinculado a este e-mail.')", True)
                    Else
                        objEmailChamado.Incluir()
                        GridView1.DataBind()
                        TxtVincularChamado.Text = ""
                    End If
                End If
            End If
        Else
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "onload", "alert('Informe o número do chamado a ser vinculado.')", True)
        End If
    End Sub


End Class