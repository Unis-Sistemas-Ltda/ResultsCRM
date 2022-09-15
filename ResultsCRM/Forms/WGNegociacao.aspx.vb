Imports Microsoft.Reporting

Partial Public Class WGNegociacao
    Inherits System.Web.UI.Page
    Dim valor As Decimal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Remove("SCodRoteiroVisita")
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
            lblQuantidadeRegistros.Text = GridView1.Rows.Count
            lblValorTotal.Text = "R$ " + valor.ToString("N2")
        End If
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim LblDataRecontato As Label
        Dim dataRecontato As Date
        Dim LblCor As Label
        Dim LblColorida As Label
        Dim BtnImprimir As ImageButton
        Dim LblCodNegociacao As Label

        If e.Row.RowType = DataControlRowType.DataRow Then
            valor = valor + e.Row.Cells(12).Text
            LblDataRecontato = CType(e.Row.FindControl("LblDataRecontato"), Label)
            LblCor = CType(e.Row.FindControl("LblCor"), Label)
            LblColorida = CType(e.Row.FindControl("LblColorida"), Label)
            LblCodNegociacao = CType(e.Row.FindControl("LblCodNegociacao"), Label)

            BtnImprimir = CType(e.Row.FindControl("BtnImprimir"), ImageButton)
            BtnImprimir.Attributes.Add("OnClick", "window.open('WFImpressaoPropostaPDF.aspx?eid=" + Session("GlEmpresa") + "&sid=" + Session("GlEstabelecimento") + "&nid=" + LblCodNegociacao.Text + "&ucid=" + Session("GlClienteUnis") + "&li=../Imagens/logo_proposta.jpg');")
            If Not String.IsNullOrEmpty(LblDataRecontato.Text.Trim) Then
                dataRecontato = LblDataRecontato.Text.Substring(0, 8)
            Else
                dataRecontato = New Date(2199, 12, 31)
            End If

            If dataRecontato < Today Then
                e.Row.ForeColor = Drawing.Color.Red
            ElseIf dataRecontato = Today Then
                e.Row.ForeColor = Drawing.Color.Blue
            End If

            LblColorida.BackColor = System.Drawing.Color.FromArgb(LblCor.Text)
            LblColorida.ForeColor = System.Drawing.Color.FromArgb(LblCor.Text)
            LblColorida.BorderColor = System.Drawing.Color.FromArgb(LblCor.Text)

        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Dim chave As String()
            chave = e.CommandArgument.ToString.Split(";")
            Session("SEstabelecimentoNegociacao") = chave(0)
            Session("SCodNegociacao") = chave(1)

            Session("SAcaoNegociacao") = "ALTERAR"
            Session("SRedir") = "WFNegociacaoDetalhes.aspx?b=WFNegociacaoFiltro.aspx"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "cmd", "b = parent.document.getElementById('BtnRedirect'); b.click()", True)
            'Response.Redirect("WFNegociacaoDetalhes.aspx")
        ElseIf e.CommandName = "COPIAR" Then
            Dim chave As String()
            chave = e.CommandArgument.ToString.Split(";")
            Session("SEstabelecimentoNegociacao") = chave(0)
            Session("SCodNegociacao") = chave(1)
            Session("SAcaoNegociacao") = "COPIAR"
            Session("SRedir") = "WFCopiaNegociacao.aspx?b=WFNegociacaoFiltro.aspx"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "cmd", "b = parent.document.getElementById('BtnRedirect'); b.click()", True)
            'Response.Redirect("WFCopiaNegociacao.aspx")
        End If
    End Sub

End Class