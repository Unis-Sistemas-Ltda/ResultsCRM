Public Class WGAtendimentoNegociacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim BtnImprimir As ImageButton
        Dim LblCodNegociacao As Label
        If e.Row.RowType = DataControlRowType.DataRow Then
            LblCodNegociacao = CType(e.Row.FindControl("LblCodNegociacao"), Label)
            BtnImprimir = CType(e.Row.FindControl("BtnImprimir"), ImageButton)
            BtnImprimir.Attributes.Add("OnClick", "window.open('WFImpressaoPropostaPDF.aspx?eid=" + Session("GlEmpresa") + "&sid=" + Session("GlEstabelecimento") + "&nid=" + LblCodNegociacao.Text + "&ucid=" + Session("GlClienteUnis") + "&li=../Imagens/logo_proposta.jpg');")
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SCodNegociacao") = e.CommandArgument
            Session("SAcaoNegociacao") = "ALTERAR"
            Response.Redirect("WFNegociacaoDetalhes.aspx?b=WGAtendimentoNegociacao.aspx")
        Else
            If e.CommandName = "EXCLUIR" Then
                Try
                    Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
                    objNegociacao.Empresa = Session("GlEmpresa")
                    objNegociacao.Estabelecimento = Session("GlEstabelecimento")
                    objNegociacao.CodNegociacao = e.CommandArgument
                    objNegociacao.Excluir()

                    LblErro.Text = "Negociação excluída com sucesso."

                    SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                    SqlDataSource1.DataBind()
                    GridView1.DataBind()
                Catch ex As Exception
                    LblErro.Text = ex.Message
                End Try
            End If

        End If
    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Session("SCodNegociacao") = -1
        Session("SAcaoNegociacao") = "INCLUIR"
        Response.Redirect("WFNegociacaoDetalhes.aspx?b=WGAtendimentoNegociacao.aspx")
    End Sub

End Class