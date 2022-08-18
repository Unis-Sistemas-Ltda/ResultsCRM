Public Partial Class WFImpressaoOS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("GlClienteUnis") = 388 Then
            Response.Redirect("WFImpressaoOSElfaro.aspx?eid=" + Empresa + "&sid=" + Estabelecimento + "&pid=" + CodPedidoVenda)
        ElseIf Session("GlClienteUnis") = 453 Then
            Response.Redirect("WFImpressaoOSTrueIT.aspx?eid=" + Empresa + "&sid=" + Estabelecimento + "&pid=" + CodPedidoVenda)
        ElseIf Session("GlClienteUnis") = 45 Then
            Response.Redirect("WFImpressaoOSUnis.aspx?eid=" + Empresa + "&sid=" + Estabelecimento + "&pid=" + CodPedidoVenda)
        ElseIf Session("GlClienteUnis") = 702 Then
            Response.Redirect("WFImpressaoOSOffLimits.aspx?eid=" + Empresa + "&sid=" + Estabelecimento + "&pid=" + CodPedidoVenda)
        ElseIf Session("GlClienteUnis") = 93 OrElse Session("GlClienteUnis") = 175 Then
            Response.Redirect("WFImpressaoOSCIMTEL.aspx?eid=" + Empresa + "&sid=" + Estabelecimento + "&pid=" + CodPedidoVenda)
        Else
            Response.Redirect("WFImpressaoOSAtivaSipe.aspx?eid=" + Empresa + "&sid=" + Estabelecimento + "&pid=" + CodPedidoVenda)
        End If
    End Sub

    Private ReadOnly Property Empresa() As String
        Get
            Return Request.QueryString.Item("eid")
        End Get
    End Property

    Private ReadOnly Property Estabelecimento() As String
        Get
            Return Request.QueryString.Item("sid")
        End Get
    End Property

    Private ReadOnly Property CodPedidoVenda() As String
        Get
            Return Request.QueryString.Item("pid")
        End Get
    End Property

End Class