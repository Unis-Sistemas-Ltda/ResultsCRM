Public Partial Class WFNegociacaoItem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call TestaRedirecionamento()
        WUCNegociacaoItem1.CodNegociacao = Session("SCodNegociacao")
        WUCNegociacaoItem1.SeqItem = Session("SSeqItemNegociacao")
        WUCNegociacaoItem1.Acao = Session("SAcaoItem")

    End Sub

    Private Sub TestaRedirecionamento()
        Dim objParametrosFaturamento As New UCLParametrosFaturamento
        Dim segmento As String

        objParametrosFaturamento.Empresa = Session("GlEmpresa")
        objParametrosFaturamento.Estabelecimento = Session("SEstabelecimentoNegociacao")
        objParametrosFaturamento.Buscar()
        segmento = objParametrosFaturamento.Segmento

        Select Case segmento
            Case "P" 'Plástico
                Response.Redirect("WFNegociacaoItem_Plastico.aspx")
            Case "O" 'Fármacos 2
                Response.Redirect("WFNegociacaoItem_Farmacos2.aspx")
            Case "D" 'Distribuidor
                Response.Redirect("WFNegociacaoItem_Dist.aspx")
            Case "G" 'Confecção com Grade
                Response.Redirect("WFNegociacaoItem_Grade.aspx")
            Case "S" 'Distribuidor de Pedras
                Response.Redirect("WFNegociacaoItem_Pedras.aspx")
        End Select

    End Sub

End Class