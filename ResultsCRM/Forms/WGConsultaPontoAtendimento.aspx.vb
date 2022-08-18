Partial Public Class WGConsultaPontoAtendimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            Dim CodEmitente As String
            Dim NumeroPontoAtendimento As String
            Dim CommandArgument As String
            Dim Posicao As Long
            If e.CommandName = "DETALHAR" Then
                CommandArgument = e.CommandArgument
                Posicao = CommandArgument.IndexOf(";")
                If Posicao > 0 Then
                    CodEmitente = Left(CommandArgument, Posicao)
                    NumeroPontoAtendimento = CommandArgument.Replace(CodEmitente + ";", "")
                    Response.Redirect("WFConsultaPontoAtendimento.aspx?ceid=" + CodEmitente + "&paid=" + NumeroPontoAtendimento + "&v=1")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub AplicaFiltro()
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub

    Protected Sub TxtCodEmitente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCodEmitente.TextChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub TxtNomeEmitente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtNomeEmitente.TextChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub TxtNumeroPontoAtendimento_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtPontoAtendimento.TextChanged
        Call AplicaFiltro()
    End Sub

End Class