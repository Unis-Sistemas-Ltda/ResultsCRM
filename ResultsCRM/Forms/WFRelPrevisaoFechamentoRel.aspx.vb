Imports System.IO

Public Class WFRelPrevisaoFechamentoRel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        'se o grid tiver mais que 65536  linhas não podemos exportar
        If GridView1.Rows.Count.ToString + 1 < 65536 Then

            GridView1.AllowPaging = "False"
            GridView1.AllowSorting = "false"
            GridView1.DataBind()

            Dim tw As New StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim frm As HtmlForm = New HtmlForm()

            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment;filename=" & "PrevisaoFechamento.xls")
            Response.Charset = ""
            EnableViewState = False

            Controls.Add(frm)
            frm.Controls.Add(GridView1)
            frm.RenderControl(hw)

            Response.Write(tw.ToString())
            Response.End()
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onload", "alert('Planilha possui mais linhas do que o Excel suporta. Dessa forma, não será possível exportá-la.')", True)
        End If
    End Sub

    Private Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound
        Dim total As Double = 0
        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                total += CDbl(CType(row.FindControl("LblValor"), Label).Text.Replace(".", ""))
            End If
        Next
        LblTotalGeral.Text = total.ToString("N2")
    End Sub
End Class