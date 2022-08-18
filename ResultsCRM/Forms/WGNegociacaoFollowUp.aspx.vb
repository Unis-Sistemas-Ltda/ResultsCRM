Public Partial Class WGNegociacaoFollowUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SSeqFolowUp") = e.CommandArgument
            Session("SAcaoFollowUp") = "ALTERAR"
            Response.Redirect("WFNegociacaoFollowUp.aspx")
        ElseIf e.CommandName = "EXPANDIR" Then
            Call Processa(e.CommandArgument)
        End If
    End Sub

    Protected Sub Processa(ByVal codFollowUp As String)
        Dim expandido As Boolean
        Dim linha As GridViewRow = Nothing

        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                If CType(row.FindControl("LblCodFollowUp"), Label).Text = codFollowUp Then
                    linha = row
                    expandido = CType(row.FindControl("LblDetalhes"), Label).Visible
                    Exit For
                End If
            End If
        Next

        If linha IsNot Nothing Then
            If expandido Then
                Call OcultaDetalhamento(linha)
            Else
                Call Expande(linha)
            End If
        End If

    End Sub

    Protected Sub Expande(ByVal row As GridViewRow)
        Dim LblDetalhes As Label
        Dim LinkExpansao As LinkButton

        LblDetalhes = row.FindControl("LblDetalhes")
        LblDetalhes.Visible = True

        LinkExpansao = row.FindControl("LinkExpansao")
        LinkExpansao.Text = "-"
    End Sub

    Protected Sub OcultaDetalhamento(ByVal row As GridViewRow)
        Dim LblDetalhes As Label
        Dim LinkExpansao As LinkButton

        LblDetalhes = row.FindControl("LblDetalhes")
        LblDetalhes.Visible = False

        LinkExpansao = row.FindControl("LinkExpansao")
        LinkExpansao.Text = "+"
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        If Session("SCodNegociacao") <> -1 Then
            Session("SSeqFollowUp") = -1
            Session("SAcaoFollowUp") = "INCLUIR"
            Response.Redirect("WFNegociacaoFollowUp.aspx")
        Else
            LblErro.Text = "Não é permitido incluir um registro de item antes de salvar o cabeçalho da negociação."
        End If
    End Sub
End Class