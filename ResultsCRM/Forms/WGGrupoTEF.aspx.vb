Public Class WGGrupoTEF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodAdesao") = e.CommandArgument
            Response.Redirect("WFGrupoTEF.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Try
                Dim objAdesao As New UCLAdesaoTEF
                objAdesao.Excluir(Session("GlEmpresa"), e.CommandArgument)
            Catch ex As Exception
                If ex.Message.Contains("FK_") Then
                    LblErro.Text = "Não é possível excluir este registro pois o mesmo já possui vínculos cadastrais."
                Else
                    LblErro.Text = ex.Message
                End If
            End Try
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodAdesao") = -1
        Response.Redirect("WFGrupoTEF.aspx")
    End Sub

End Class