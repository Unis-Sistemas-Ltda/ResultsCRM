Partial Public Class WFSLA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCSLA1.Acao = Session("SAcao")
        WUCSLA1.CodSLA = Session("SCodSLA")
    End Sub
End Class