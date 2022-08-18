Public Class WGNegociacaoCampanhaTEF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Dim args As String() = e.CommandArgument.ToString.Split(";")
            Session("SAcao") = e.CommandName
            Session("SCodLoja") = args(0)
            Session("SCNPJLoja") = args(1)
            Response.Redirect("WFTEF.aspx?ori=N")
        ElseIf e.CommandName = "EXCLUIR" Then
            Try
                Dim args As String() = e.CommandArgument.ToString.Split(";")
                Dim objAdesaoLoja As New UCLAdesaoTEFLoja
                objAdesaoLoja.Excluir(Session("GlEmpresa"), args(0), args(1))
            Catch ex As Exception
                If ex.Message.Contains("FK_") Then
                    LblErro.Text = "Não é possível excluir o registro por o mesmo já possui vínculos."
                Else
                    LblErro.Text = ex.Message
                End If
            End Try
        End If
    End Sub

End Class