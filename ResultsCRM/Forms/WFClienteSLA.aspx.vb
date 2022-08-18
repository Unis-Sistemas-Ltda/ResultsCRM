Partial Public Class WFClienteSLA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCClienteCSLA1.Acao = Session("SAcaoSLA")
        WUCClienteCSLA1.CodCliente = Session("SCodEmitente")
        WUCClienteCSLA1.CodSLA = Session("SCodSLA")
    End Sub
End Class