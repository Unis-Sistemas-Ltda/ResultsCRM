Partial Public Class WFClienteSLAEstadoRegiao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCClienteCSLARegiao1.Acao = Session("SAcaoSLAReg")
        WUCClienteCSLARegiao1.CodCliente = Session("SCodEmitente")
        WUCClienteCSLARegiao1.CodSLA = Session("SCodSLA")
        WUCClienteCSLARegiao1.CodPais = Session("SCodPaisSLA")
        WUCClienteCSLARegiao1.CodEstado = Session("SCodEstadoSLA")
        WUCClienteCSLARegiao1.CodRegiao = Session("SCodRegiaoSLA")
    End Sub
End Class