Public Class WGNegociacaoAdesaoTEF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound
        Dim lnk As LinkButton
        Dim LblCodEmitente As Label
        Dim LblCodAdesao As Label
        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                lnk = row.FindControl("LnkAdesao")
                LblCodAdesao = row.FindControl("LblCodAdesao")
                LblCodEmitente = row.FindControl("LblCodEmitente")
                lnk.OnClientClick = "window.open('http://matriz.unissistemas.com.br/webdeskunis/simulador-tef/WFRedirecionar.aspx?e=" + LblCodEmitente.Text + "&a=" + LblCodAdesao.Text + "&t=2&r=WFAdesaoTEF_paspx_ie_q" + LblCodEmitente.Text + "'); return false;"
            End If
        Next
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Dim chaves As String() = e.CommandArgument.ToString.Split(";")
            Response.Redirect("WFAdesaoTEF.aspx?e=" + chaves(0) + "&c=" + chaves(1) + "&ori=N")
        End If
    End Sub

End Class