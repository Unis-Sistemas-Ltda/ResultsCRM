Public Partial Class WFAprovFinancOSHistoricoPA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
        Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))

        objPedido.empresa = Session("GlEmpresa")
        objPedido.estabelecimento = Session("GlEstabelecimento")
        objPedido.codPedidoVenda = Session("SAtCodPedido")
        If objPedido.Buscar() Then
            objChamado.Empresa = objPedido.empresa
            objChamado.CodChamado = objPedido.codChamado
            If objChamado.Buscar() Then
                If Not String.IsNullOrEmpty(objChamado.CodEmitenteAtendimento) And Not String.IsNullOrEmpty(objChamado.NumeroPontoAtendimento) Then
                    Response.Redirect("WFConsultaPontoAtendimento.aspx?paid=" + objChamado.NumeroPontoAtendimento + "&ceid=" + objChamado.CodEmitenteAtendimento + "&v=2")
                End If
            End If
        End If
    End Sub

End Class