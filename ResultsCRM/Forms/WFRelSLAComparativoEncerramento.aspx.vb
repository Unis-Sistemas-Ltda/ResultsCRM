Imports System.IO
Public Class WFRelSLAComparativoEncerramento
    Inherits System.Web.UI.Page
    Dim objParametrosManutencao As New UCLParametrosManutencao

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim objTipoChamado As New UCLTipoChamado
            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))

            TxtDataEncerramentoI.Text = "01/" + Now.Month.ToString.PadLeft(2, "0") + "/" + Now.Year.ToString
            TxtDataEncerramentoF.Text = CDate(TxtDataEncerramentoI.Text).AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy")

            Call CarregaAnalista()
            Call CarregaTecnico()
            Call CarregaRegiao()
            Call CarregaSLA()

            objTipoChamado.FillDropDown(Session("GlEmpresa"), ddlTipoChamado, True, "(Todos)", -1)

            Call AplicaFiltro()
        End If
    End Sub

    Protected Sub BtnAplicarFiltro_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAplicarFiltro.Click
        Call AplicaFiltro()
    End Sub

    Private Sub AplicaFiltro()
        LblErro.Text = ""
        If Not isValidDate(TxtDataEncerramentoI.Text) Then
            LblErro.Text += "Preencha corretamente o início do período de encerramento.<br/>"
        End If
        If Not isValidDate(TxtDataEncerramentoF.Text) Then
            LblErro.Text += "Preencha corretamente o fim do período de encerramento.<br/>"
        End If
        If LblErro.Text = "" Then
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        End If
    End Sub

    Private Sub CarregaSLA()
        Try
            Dim objSla As New UCLSLA
            objSla.FillDropDown(ddlsla, True, "(Todos)")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaAnalista()
        Dim objAnalista As New UCLAnalista
        objAnalista.FillDropDown(ddlAnalista, True, "(Todos)", -1, True, False, -1, "")

        If objParametrosManutencao.GetConteudo("filtro_todos_analistas") = "S" Then
            ddlAnalista.Items.FindByValue(-1).Selected = True
        Else
            If ddlAnalista.Items.FindByValue(Session("GlCodUsuario")) IsNot Nothing Then
                ddlAnalista.Items.FindByValue(Session("GlCodUsuario")).Selected = True
            End If
        End If

    End Sub

    Private Sub CarregaTecnico()
        Dim objAgTecnico As New UCLAgenteTecnico
        objAgTecnico.FillDropDown(ddlAgenteTecnico, True, "(Todos)", -1)
    End Sub

    Private Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        Try
            Dim totalAbsoluto As Long = 0
            Dim totalConforme As Long = 0
            Dim totalNaoConforme As Long = 0
            Dim lbl As Label
            For Each row As GridViewRow In GridView1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    totalAbsoluto += 1
                    lbl = row.FindControl("LblSituacao")
                    If lbl.Text = "No Prazo" Then
                        totalConforme += 1
                    Else
                        totalNaoConforme += 1
                    End If
                End If
            Next

            LblTotalAbsoluto.Text = totalAbsoluto.ToString("F0")
            LblTotalConforme.Text = totalConforme.ToString("F0")
            LblTotalNaoConforme.Text = totalNaoConforme.ToString("F0")
            LblTotalPercentual.Text = "100,00 %"
            LblPercentualConforme.Text = ((CDbl(totalConforme) / totalAbsoluto) * 100).ToString("F2") + " %"
            LblPercentualNaoConforme.Text = ((CDbl(totalNaoConforme) / totalAbsoluto) * 100).ToString("F2") + " %"

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Call exportarExcel()
    End Sub

    Private Sub exportarExcel()

        'se o grid tiver mais que 65536  linhas não podemos exportar
        If GridView1.Rows.Count.ToString + 1 < 65536 Then

            GridView1.AllowPaging = "False"
            GridView1.AllowSorting = "false"
            GridView1.DataBind()

            Dim tw As New StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim frm As HtmlForm = New HtmlForm()

            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment;filename=" & "AcompanhamentoSLAEncerramento.xls")
            Response.Charset = ""
            EnableViewState = False

            Controls.Add(frm)
            frm.Controls.Add(GridView1)
            frm.RenderControl(hw)

            Response.Write(tw.ToString())
            Response.End()
        Else
            LblErro.Text = "Planilha possui mais linhas do que o Excel suporta. Dessa forma, não será possível exportá-la."
        End If

    End Sub

    Private Sub CarregaRegiao()
        Dim objRegiao As New UCLRegiao
        objRegiao.FillDropDown(Session("GlEmpresa"), ddlRegiao, True, "(Todas)")
    End Sub

End Class