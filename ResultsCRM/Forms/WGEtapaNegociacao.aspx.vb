public Partial Class WGEtapaNegociacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodEtapa") = e.CommandArgument
            Response.Redirect("WFEtapaNegociacao.aspx")
        ElseIf e.CommandName = "TAREFAS" Then
            Session("SAcao") = e.CommandName
            Session("SCodEtapa") = e.CommandArgument
            Response.Redirect("WFEtapaTarefas.aspx")
        End If
    End Sub

    Protected Sub BtnIncluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluir.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodEtapa") = -1
        Response.Redirect("WFEtapaNegociacao.aspx")
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim LblCor As Label
        Dim LblColorida As Label
        If e.Row.RowType = DataControlRowType.DataRow Then
            LblCor = CType(e.Row.FindControl("LblCor"), Label)
            LblColorida = CType(e.Row.FindControl("LblColorido"), Label)
            LblColorida.BackColor = System.Drawing.Color.FromArgb(LblCor.Text)
            LblColorida.ForeColor = System.Drawing.Color.FromArgb(LblCor.Text)
            LblColorida.BorderColor = System.Drawing.Color.FromArgb(LblCor.Text)
        End If
    End Sub
End Class