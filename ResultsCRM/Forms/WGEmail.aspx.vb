Public Class WGEmail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub AplicaFiltro()
        Try
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RblTipo.SelectedIndexChanged
        Try
            Call AplicaFiltro()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub RadioButtonList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RblStatus.SelectedIndexChanged
        Try
            If RblStatus.SelectedValue = "1" Then
                BtnEnviarEmails.Visible = True
            Else
                BtnEnviarEmails.Visible = False
            End If
            Call AplicaFiltro()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "ENVIAR" Then
                Call EnviarEmail(e.CommandArgument)
                Call AplicaFiltro()
                Page.ClientScript.RegisterStartupScript(Me.GetType, "onload", "alert('O e-mail selecionado será enviado dentro de 5 minutos.')", True)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnEnviarEmails_Click(sender As Object, e As EventArgs) Handles BtnEnviarEmails.Click
        Try
            Dim objEmailSaida As New UCLEmailSaida
            For Each row As GridViewRow In GridView1.Rows
                Call EnviarEmail(CType(row.FindControl("LblSeqEmail"), Label).Text)
            Next
            Call AplicaFiltro()
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onload", "alert('Os e-mails pendentes serão enviados dentro do prazo de 5 minutos.')", True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EnviarEmail(email As String)
        Try
            Dim objEmailSaida As New UCLEmailSaida
            objEmailSaida.Empresa = Session("GlEmpresa")
            objEmailSaida.Email = email
            objEmailSaida.Buscar()
            objEmailSaida.EnviadoAutomatico = "N"
            objEmailSaida.Enviado = System.DateTime.Now.ToString("dd/MM/yyyy")
            objEmailSaida.DEnviado = System.DateTime.Now.Date
            objEmailSaida.HEnviado = System.DateTime.Now.ToString("HH:mm")
            objEmailSaida.Alterar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class