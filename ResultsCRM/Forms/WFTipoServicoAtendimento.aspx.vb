Partial Public Class WFTipoServicoAtendimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCTipoServicoAtendimento1.Acao = Session("SAcao")
        WUCTipoServicoAtendimento1.CodTipoServico = Session("SCodTipoServico")
    End Sub

End Class