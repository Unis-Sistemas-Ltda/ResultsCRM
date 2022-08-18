Partial Public Class WFClienteSLAEstadoCidade
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCClienteCSLAEstadoCidade1.Acao = Session("SAcaoSLAMun")
        WUCClienteCSLAEstadoCidade1.CodCliente = Session("SCodEmitente")
        WUCClienteCSLAEstadoCidade1.CodSLA = Session("SCodSLA")
        WUCClienteCSLAEstadoCidade1.CodPais = Session("SCodPaisSLA")
        WUCClienteCSLAEstadoCidade1.CodEstado = Session("SCodEstadoSLA")
        WUCClienteCSLAEstadoCidade1.CodCidade = Session("SCodCidadeSLA")
    End Sub
End Class