Public Class WFConsultaHistoricoPontoAtendimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Redirect("WFConsultaPontoAtendimento.aspx?ceid=" + Session("SCodEmitente") + "&paid=" + Session("SNumeroPontoAtendimento") + "&v=2")
    End Sub

End Class