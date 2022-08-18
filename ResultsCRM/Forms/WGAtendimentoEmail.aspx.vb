Partial Public Class WGAtendimentoEmail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Eid = "E" Then
            BtnEnviarEmails.Visible = False
            BtnNovoRegistro.Visible = False
            GridView1.EmptyDataText = "Nenhum e-mail foi enviado até o momento para o chamado em questão."
            LblIdentificador.Text = "Enviados"
        Else
            GridView1.EmptyDataText = "Nenhum e-mail está pendente de envio."
            LblIdentificador.Text = "Pendentes"
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEnviarEmails.Click
        Try
            Dim objEmailSaida As New UCLEmailSaida

            If String.IsNullOrEmpty(Session("SCodAtendimento")) Then Return
            If String.IsNullOrEmpty(Session("GlEmpresa")) Then Return

            objEmailSaida.EnviaEmailsPendentes(Session("GlEmpresa"), Session("SCodAtendimento"))
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('Os e-mails pendentes serão enviados dentro de 5 minutos.');", True)

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "ALTERAR" Then
                Session("SSeqEmail") = e.CommandArgument
                Session("SAcaoEmail") = e.CommandName
                Response.Redirect("WFAtendimentoEmail.aspx?eid=" + Eid)
            ElseIf e.CommandName = "EXCLUIR" Then
                Dim objEmail As New UCLEmailSaida
                objEmail.Email = e.CommandArgument
                objEmail.Buscar()
                If objEmail.EnviarAutomatico = "S" And objEmail.EnviadoAutomatico = "S" Then
                    LblErro.Text = "Não foi possível excluir o e-mail selecionado pois o mesmo já foi enviado."
                Else
                    objEmail.Excluir()
                    SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                    SqlDataSource1.DataBind()
                    GridView1.DataBind()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcaoEmail") = "INCLUIR"
        Response.Redirect("WFEmailDetalhes.aspx?p=WFEmail&e=0&t=4")
    End Sub

    Private ReadOnly Property Eid() As String
        Get
            Return Request.QueryString.Item("eid")
        End Get
    End Property

    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim HyperLink1 As HyperLink = e.Row.FindControl("HyperLink1")
            Dim HyperLink2 As HyperLink = e.Row.FindControl("HyperLink2")
            Dim HyperLink3 As HyperLink = e.Row.FindControl("HyperLink3")

            If HyperLink1.Visible And Not String.IsNullOrWhiteSpace(HyperLink1.Text) Then
                HyperLink1.NavigateUrl = DominioAnexoEmail + HyperLink1.Text
            End If

            If HyperLink2.Visible And Not String.IsNullOrWhiteSpace(HyperLink2.Text) Then
                HyperLink2.NavigateUrl = DominioAnexoEmail + HyperLink2.Text
            End If

            If HyperLink3.Visible And Not String.IsNullOrWhiteSpace(HyperLink3.Text) Then
                HyperLink3.NavigateUrl = DominioAnexoEmail + HyperLink3.Text
            End If

        End If
    End Sub
End Class