Partial Public Class WFOSFollowUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            objPedido.empresa = Session("GlEmpresa")
            objPedido.estabelecimento = Session("GlEstabelecimento")
            objPedido.codPedidoVenda = Session("SAtCodPedido")
            objPedido.Buscar()

            WUCFollowUP1.Empresa = Session("GlEmpresa")
            WUCFollowUP1.Estabelecimento = Session("GlEstabelecimento")
            WUCFollowUP1.CodPedidoVenda = Session("SAtCodPedido")
            WUCFollowUP1.SeqFollowUp = Session("SPdSeqFollowUP")
            WUCFollowUP1.Acao = Session("SAcaoPdFollowUP")
            WUCFollowUP1.CodEmitente = objPedido.codEmitente
            WUCFollowUP1.CaminhoVoltar = "WGAtendimentoPedidoItem.aspx"
            WUCFollowUP1.MostraBotaoVoltar = True

            Session("SCodAtendimento") = objPedido.codChamado
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            objChamado.Empresa = objPedido.empresa
            objChamado.CodChamado = objPedido.codChamado
            If Not String.IsNullOrEmpty(objChamado.Empresa) AndAlso Not String.IsNullOrEmpty(objChamado.CodChamado) Then
                If objChamado.Buscar() Then
                    Session("SCodEmitenteAtNegociacao") = objChamado.CodEmitenteAtendimento
                    Session("SCNPJEmitenteAtendimento") = objChamado.CnpjAtendimento
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class