Imports Sybase.DataWindow
Imports Sybase.DataWindow.Web

Partial Public Class WFRelVisitacaoRel2
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ReportViewer1.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("WFRelVisitacaoFiltro.aspx")
    End Sub
End Class