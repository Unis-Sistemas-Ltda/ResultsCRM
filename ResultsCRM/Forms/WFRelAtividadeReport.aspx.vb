Public Class WFRelAtividadeReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ps As System.Drawing.Printing.PageSettings = New System.Drawing.Printing.PageSettings()
            ps.Landscape = True
            ps.PaperSize = New System.Drawing.Printing.PaperSize("A4", 827, 1170)
            ps.PaperSize.RawKind = Convert.ToInt64(System.Drawing.Printing.PaperKind.A4)
            ReportViewer1.SetPageSettings(ps)
        Catch ex As Exception
        End Try

        ReportViewer1.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("WFRelAtividade.aspx")
    End Sub

End Class