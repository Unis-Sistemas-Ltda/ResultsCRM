Public Class WFProgramacaoAtendimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCProgramacaoAtendimento1.CodProgramacao = Session("SCodProgramacao")
        WUCProgramacaoAtendimento1.Acao = Session("SAcao")
    End Sub

End Class