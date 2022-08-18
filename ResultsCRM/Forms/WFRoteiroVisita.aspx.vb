Public Class WFRoteiroVisita
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCRoteiroVisita1.Acao = Session("SAcaoRoteiroVisita")
        WUCRoteiroVisita1.CodRoteiro = Session("SCodRoteiroVisita")
    End Sub

End Class