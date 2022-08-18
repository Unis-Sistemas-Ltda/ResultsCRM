Public Class WGTEFFollowUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SSeqFolowUp") = e.CommandArgument
            Session("SAcaoFollowUp") = "ALTERAR"
            Response.Redirect("WFTEFFollowUp.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objTEFFollowUp As New UCLAdesaoTEFFollowUp
            objTEFFollowUp.Excluir(Session("GlEmpresa"), Session("SCodLoja"), e.CommandArgument)
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onload", "alert('Follow-up excluído com sucesso!')", True)
        End If
    End Sub

    Protected Sub LblIncluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LblIncluir.Click
        If Session("SCodLoja") <> -1 Then
            Session("SSeqFollowUp") = -1
            Session("SAcaoFollowUp") = "INCLUIR"
            Response.Redirect("WFTEFFollowUp.aspx")
        Else
            LblErro.Text = "Não é permitido incluir um follow-up antes de salvar os dados da loja."
        End If
    End Sub
End Class