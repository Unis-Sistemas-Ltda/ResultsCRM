Partial Public Class WGNegociacaoEmail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEnviarEmails.Click
        Try
            Dim objEmail As New UCLNegociacaoEmail(StrConexaoUsuario(Session("GlUsuario")))

            If String.IsNullOrEmpty(Session("SCodNegociacao")) Then Return
            If String.IsNullOrEmpty(Session("GlEstabelecimento")) Then Return
            If String.IsNullOrEmpty(Session("GlEmpresa")) Then Return

            objEmail.EnviaEmailsPendentes(Session("GlEmpresa"), Session("GlEstabelecimento"), Session("SCodNegociacao"))
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
                Response.Redirect("WFNegociacaoEmail.aspx?")
            ElseIf e.CommandName = "EXCLUIR" Then
                Dim objEmail As New UCLNegociacaoEmail(StrConexaoUsuario(Session("GlUsuario")))
                objEmail.Seq = e.CommandArgument
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
        Session("SSeqEmail") = -1
        Session("SAcaoEmail") = "INCLUIR"
        Response.Redirect("WFNegociacaoEmail.aspx?")
    End Sub
End Class