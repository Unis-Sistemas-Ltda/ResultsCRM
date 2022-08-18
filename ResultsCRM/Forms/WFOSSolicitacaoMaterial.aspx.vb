Partial Public Class WFOSSolicitacaoMaterial
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

            WUCSolicitacaoMaterial1.Empresa = Session("GlEmpresa")
            WUCSolicitacaoMaterial1.Estabelecimento = Session("GlEstabelecimento")
            WUCSolicitacaoMaterial1.CodPedidoVenda = Session("SAtCodPedido")
            WUCSolicitacaoMaterial1.CodSolicitacao = Session("SAtSolicitacao")
            WUCSolicitacaoMaterial1.Acao = Session("SAcaoAtPedido")
            WUCSolicitacaoMaterial1.CaminhoVoltar = "WGAtendimentoPedidoItem.aspx"

            objPedido.empresa = WUCSolicitacaoMaterial1.Empresa
            objPedido.estabelecimento = WUCSolicitacaoMaterial1.Estabelecimento
            objPedido.codPedidoVenda = WUCSolicitacaoMaterial1.CodPedidoVenda
            If Not String.IsNullOrEmpty(objPedido.empresa) AndAlso Not String.IsNullOrEmpty(objPedido.estabelecimento) AndAlso Not String.IsNullOrEmpty(objPedido.codPedidoVenda) Then
                If objPedido.Buscar() Then
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

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class