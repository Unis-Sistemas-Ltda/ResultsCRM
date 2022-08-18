Public Class WGAtendimentoHoras
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Mensagem(ByVal texto As String)
        If Not String.IsNullOrEmpty(texto) Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('" + texto + "');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "", True)
        End If
    End Sub

    Protected Sub BtnIncluirOS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluirOS.Click
        Try
            Session("SAcaoHoraChamado") = "INCLUIR"
            Session("SAtHora") = -1
            Response.Redirect("WFChamadoHoras.aspx")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView3_DataBound(sender As Object, e As System.EventArgs) Handles GridView3.DataBound
        Dim totalGeralHoras As Double = 0
        Dim strHoras As String
        For Each row As GridViewRow In GridView3.Rows
            If row.RowType = DataControlRowType.DataRow Then
                strHoras = CType(row.FindControl("LblTotalHoras"), Label).Text
                If Not String.IsNullOrEmpty(strHoras) AndAlso IsNumeric(strHoras) Then
                    totalGeralHoras += CDbl(strHoras)
                End If
            End If
        Next
        If totalGeralHoras > 0 Then
            CType(GridView3.FooterRow.FindControl("LblTotalGeralHoras"), Label).Text = totalGeralHoras.ToString("F4")
        End If
    End Sub

    Private Sub GridView3_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView3.RowCommand
        Try
            If e.CommandName = "ALTERAR" Then
                Session("SAtHora") = e.CommandArgument
                Session("SAcaoHoraChamado") = e.CommandName
                Response.Redirect("WFChamadoHoras.aspx")
            ElseIf e.CommandName = "EXCLUIR" Then
                Dim objChamadoHoraTrabalhada As New UCLChamadoHoraTrabalhada
                objChamadoHoraTrabalhada.Excluir(Session("GlEmpresa"), Session("SCodAtendimento"), e.CommandArgument)
                Mensagem("Registro excluído com sucesso.")
                SqlDataSource3.Select(DataSourceSelectArguments.Empty)
                SqlDataSource3.DataBind()
                GridView3.DataBind()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
End Class