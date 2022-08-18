Partial Public Class WGAtendimentoFollowUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SSeqFolowUp") = e.CommandArgument
            Session("SAcaoFollowUp") = "ALTERAR"
            Response.Redirect("WFAtendimentoFollowUp.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objFollowUp As New UCLAtendimentoFollowUp(StrConexaoUsuario(Session("GlUsuario")))
            objFollowUp.Empresa = Session("GlEmpresa")
            objFollowUp.CodChamado = Session("SCodAtendimento")
            objFollowUp.SeqFollowUP = e.CommandArgument
            objFollowUp.Excluir()
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onload", "alert('Follow-up excluído com sucesso!')", True)
        End If
    End Sub

    Protected Sub LblIncluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LblIncluir.Click
        If Session("SCodAtendimento") <> -1 Then
            Session("SSeqFollowUp") = -1
            Session("SAcaoFollowUp") = "INCLUIR"
            Response.Redirect("WFAtendimentoFollowUp.aspx")
        Else
            LblErro.Text = "Não é permitido incluir um follow-up antes de salvar o chamado. Por favor clique no botão Salvar localizado no rodapé do lado esquerdo da tela."
        End If
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim HyperLink1 As HyperLink = e.Row.FindControl("HyperLink1")
            Dim HyperLink2 As HyperLink = e.Row.FindControl("HyperLink2")
            Dim HyperLink3 As HyperLink = e.Row.FindControl("HyperLink3")

            If HyperLink1.Visible And Not String.IsNullOrWhiteSpace(HyperLink1.Text) Then
                'HyperLink1.NavigateUrl = DominioAnexoFollowUpChamado() + HyperLink1.Text
            End If

            If HyperLink2.Visible And Not String.IsNullOrWhiteSpace(HyperLink2.Text) Then
                'HyperLink2.NavigateUrl = DominioAnexoFollowUpChamado() + HyperLink2.Text
            End If

            If HyperLink3.Visible And Not String.IsNullOrWhiteSpace(HyperLink3.Text) Then
                'HyperLink3.NavigateUrl = DominioAnexoFollowUpChamado() + HyperLink3.Text
            End If

        End If
    End Sub
End Class