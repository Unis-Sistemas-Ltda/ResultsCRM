Public Class WFAlterarNumeroPontoAtendimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim existe As Boolean
            LblErro.Text = ""
            LblOK.Text = ""
            If String.IsNullOrWhiteSpace(TxtCodCliente.Text) Then
                LblErro.Text += "Preencha o código do cliente.<br>"
            End If

            If String.IsNullOrWhiteSpace(TxtNumeroPontoAtendimentoAntigo.Text) Then
                LblErro.Text += "Preencha o número original do ponto de atendimento.<br>"
            End If

            If String.IsNullOrWhiteSpace(TxtNumeroPontoAtendimentoNovo.Text) Then
                LblErro.Text += "Preencha o novo número do ponto de atendimento.<br>"
            End If

            If String.IsNullOrWhiteSpace(TxtNumeroPontoAtendimentoNovoConfirmacao.Text) Then
                LblErro.Text += "Preencha a confirmação do novo número do ponto de atendimento.<br>"
            End If

            If String.IsNullOrWhiteSpace(TxtUsuario.Text) Then
                LblErro.Text += "Informe usuário.<br>"
            End If

            If String.IsNullOrWhiteSpace(TxtSenha.Text) Then
                LblErro.Text += "Informe senha.<br>"
            End If

            If LblErro.Text <> "" Then
                Return
            End If

            If TxtNumeroPontoAtendimentoNovo.Text <> TxtNumeroPontoAtendimentoNovoConfirmacao.Text Then
                LblErro.Text += "Novo número do ponto de atendimento não confere com a confirmação.<br>"
                Return
            End If

            If TxtNumeroPontoAtendimentoNovo.Text = TxtNumeroPontoAtendimentoAntigo.Text Then
                LblErro.Text += "Novo número do ponto de atendimento precisa ser diferente do original.<br>"
                Return
            End If

            Dim ObjUsuario As New UCLUsuario

            ObjUsuario.Usuario = TxtUsuario.Text
            If Not ObjUsuario.Buscar() Then
                LblErro.Text += "Usuário não encontrado na base de dados.<br>"
                Return
            Else
                If ObjUsuario.Senha <> TxtSenha.Text Then
                    LblErro.Text += "Senha não confere.<br>"
                    Return
                End If
            End If

            Dim ObjEmitente As New UCLEmitente(StrConexao)
            ObjEmitente.CodEmitente = TxtCodCliente.Text
            If ObjEmitente.Buscar().Rows.Count = 0 Then
                LblErro.Text += "Cliente não encontrado na base de dados. Verifique código informado.<br>"
                Return
            End If

            Dim ObjPontoAtendimento As New UCLPontoAtendimento(StrConexao)
            ObjPontoAtendimento.CodEmitente = TxtCodCliente.Text
            ObjPontoAtendimento.NumeroPontoAtendimento = TxtNumeroPontoAtendimentoAntigo.Text
            If Not ObjPontoAtendimento.Buscar() Then
                LblErro.Text += "Ponto de Atendimento (original) não encontrado. Verifique se informou o código do cliente corretamente e o número do ponto de atendimento.<br>"
                Return
            End If

            ObjPontoAtendimento = New UCLPontoAtendimento(StrConexao)
            ObjPontoAtendimento.CodEmitente = TxtCodCliente.Text
            ObjPontoAtendimento.NumeroPontoAtendimento = TxtNumeroPontoAtendimentoNovo.Text
            If ObjPontoAtendimento.Buscar() Then
                existe = True
            Else
                existe = False
            End If

            ObjPontoAtendimento.AlterarNumeroPontoAtendimento(TxtCodCliente.Text, TxtNumeroPontoAtendimentoAntigo.Text, TxtNumeroPontoAtendimentoNovo.Text, TxtUsuario.Text, existe)

            LblOK.Text = "Ponto de Atendimento migrado com sucesso."
            GridView1.DataBind()

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
End Class