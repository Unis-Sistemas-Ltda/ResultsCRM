Partial Public Class WFCausa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCCausa1.Acao = Session("SAcao")
        WUCCausa1.CodCausa = Session("SCodCausa")
    End Sub

End Class