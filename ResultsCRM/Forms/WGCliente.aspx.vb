Partial Public Class WGCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("GlBloquearCadastroEmitenteRepresentante") = "S" Then
            BtnNovoRegistro.Visible = False
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodEmitente") = e.CommandArgument
            Response.Redirect("WFCliente.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Try
                Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
                objEmitente.CodEmitente = e.CommandArgument
                objEmitente.Excluir()
            Catch ex As Exception
                If ex.Message.Contains("FK_") Then
                    LblErro.Text = "Não é possível excluir o registro por o mesmo já possui vínculos."
                Else
                    LblErro.Text = ex.Message
                End If
            End Try
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodEmitente") = -1
        Response.Redirect("WFCliente.aspx")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles BtnFiltrar.Click

    End Sub
End Class