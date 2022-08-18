Public Partial Class WFNegociacaoTarefa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim chamada As String = 0

        If Request.QueryString.Count > 0 Then
            chamada = Request.QueryString.Item("tid")
        End If

        WUCNegociacaoTarefa1.CodNegociacao = Session("SCodNegociacao")
        WUCNegociacaoTarefa1.SeqTarefa = Session("SSeqTarefaNegociacao")
        WUCNegociacaoTarefa1.Acao = Session("SAcaoItem")
        WUCNegociacaoTarefa1.Chamada = chamada
    End Sub

End Class