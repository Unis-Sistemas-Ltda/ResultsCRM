Partial Public Class WFClienteSLAEstado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCClienteCSLAEstado1.Acao = Session("SAcaoSLAUF")
        WUCClienteCSLAEstado1.CodCliente = Session("SCodEmitente")
        WUCClienteCSLAEstado1.CodSLA = Session("SCodSLA")
        WUCClienteCSLAEstado1.CodPais = Session("SCodPaisSLA")
        WUCClienteCSLAEstado1.CodEstado = Session("SCodEstadoSLA")
    End Sub
End Class