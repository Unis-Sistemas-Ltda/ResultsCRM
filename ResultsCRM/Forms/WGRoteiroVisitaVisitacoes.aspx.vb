Public Class WGRoteiroVisitaVisitacoes
    Inherits System.Web.UI.Page

    Private Sub GridView5_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView5.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SSeqVisita") = e.CommandArgument
            Session("SAcaoVisitacao") = "ALTERAR"
            Response.Redirect("WFRoteiroVisitaVisitacoesDetalhes.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objVisita As New UCLVisitacao
            objVisita.Excluir(Session("GlEmpresa"), Session("GlEstabelecimento"), e.CommandArgument)
            GridView5.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session("SAcaoVisitacao") = "INCLUIR"
        Session("SSeqVisita") = -1
        Response.Redirect("WFRoteiroVisitaVisitacoesDetalhes.aspx")
    End Sub
End Class