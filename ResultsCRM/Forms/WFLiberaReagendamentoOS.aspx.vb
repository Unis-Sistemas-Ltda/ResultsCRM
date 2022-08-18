Public Class WFLiberaReagendamentoOS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

            If String.IsNullOrEmpty(TxtNumeroOS.Text) Then
                LblErro.Text = "Informe o número da OS."
                Return
            Else
                If Not IsNumeric(TxtNumeroOS.Text) Then
                    LblErro.Text = "Informe corretamente o número da OS."
                    Return
                End If
            End If

            objPedido.empresa = Session("GlEmpresa")
            objPedido.estabelecimento = Session("GlEstabelecimento")
            objPedido.codPedidoVenda = TxtNumeroOS.Text

            If Not objPedido.Buscar() Then
                LblErro.Text = "OS não encontrada."
            Else
                objPedido.SeqAlteracaoEntrega = 0
                objPedido.Alterar()
                LblErro.Text = "Reagendamento liberado com sucesso."
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

End Class