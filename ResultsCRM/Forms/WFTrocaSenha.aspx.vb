Public Partial Class WFTrocaSenha
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            If IsDigitacaoOK() Then
                Dim objUsuario As New UCLUsuario
                objUsuario.CodUsuario = Session("GlCodUsuario")
                If objUsuario.BuscarPorCodigo() Then
                    objUsuario.Senha = TxtNovaSenha.Text
                    objUsuario.Alterar()
                    LblErro.Text = "Senha alterada com sucesso."
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Function IsDigitacaoOK() As Boolean
        Try
            Dim objUsuario As New UCLUsuario
            LblErro.Text = ""

            objUsuario.CodUsuario = Session("GlCodUsuario")
            If objUsuario.BuscarPorCodigo() Then

                If String.IsNullOrEmpty(TxtSenhaAtual.Text) Then
                    LblErro.Text += "Informe a senha atual.<br/>"
                Else
                    If TxtSenhaAtual.Text <> objUsuario.Senha Then
                        LblErro.Text += "Senha atual não confere.<br/>"
                    End If
                End If

                If String.IsNullOrEmpty(TxtNovaSenha.Text) Then
                    LblErro.Text += "Informe a nova senha.<br/>"
                End If

                If String.IsNullOrEmpty(TxtConfirmaNovaSenha.Text) Then
                    LblErro.Text += "Informe a confirmação da nova senha.<br/>"
                Else
                    If TxtNovaSenha.Text <> TxtConfirmaNovaSenha.Text Then
                        LblErro.Text += "A confirmação da nova senha não confere com a nova senha informada.<br/>"
                    End If
                End If

            Else
                LblErro.Text += "Usuário não identificado. Para alterar sua senha, entre em contato com o responsável.<br/>"
            End If
            Return (LblErro.Text = "")

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class