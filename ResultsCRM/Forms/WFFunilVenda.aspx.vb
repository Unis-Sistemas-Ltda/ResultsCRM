Partial Public Class WFFunilVenda
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCFunilVenda1.Acao = Session("SAcao")
        WUCFunilVenda1.CodFunil = Session("SCodFunil")
    End Sub
End Class