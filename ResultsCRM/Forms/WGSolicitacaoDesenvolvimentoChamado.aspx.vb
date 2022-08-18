Partial Public Class WGSolicitacaoDesenvolvimentoChamado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnVincular_Click(sender As Object, e As EventArgs) Handles BtnVincular.Click
        Try
            Dim ObjChamadoSolicitacaoDesenvolvimento As New UCLChamadoSolicitacaoDesenvolvimento
            Dim ObjChamado As New UCLAtendimento(StrConexao)

            If Not IsNumeric(TxtNrChamado.Text) Then
                Throw New Exception("Informe corretamente o número do chamado a ser vinculado.")
            End If

            If ObjChamadoSolicitacaoDesenvolvimento.Buscar(Session("GlEmpresa"), TxtNrChamado.Text, Session("SCodSolicitacao")) Then
                Throw New Exception("Chamado já vinculado à solicitação em questão.")
            End If

            ObjChamado.Empresa = Session("GlEmpresa")
            ObjChamado.CodChamado = TxtNrChamado.Text
            If Not ObjChamado.Buscar() Then
                Throw New Exception("Chamado informado não foi encontrado.")
            End If

            ObjChamadoSolicitacaoDesenvolvimento.SetConteudo("empresa", Session("GlEmpresa"))
            ObjChamadoSolicitacaoDesenvolvimento.SetConteudo("cod_chamado", TxtNrChamado.Text)
            ObjChamadoSolicitacaoDesenvolvimento.SetConteudo("cod_solicitacao", Session("SCodSolicitacao"))
            ObjChamadoSolicitacaoDesenvolvimento.Incluir()

            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()

            TxtNrChamado.Text = ""
            LblErro.Text = ""

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim ObjChamadoSolicitacaoDesenvolvimento As New UCLChamadoSolicitacaoDesenvolvimento

                If Not ObjChamadoSolicitacaoDesenvolvimento.Buscar(Session("GlEmpresa"), e.CommandArgument, Session("SCodSolicitacao")) Then
                    Throw New Exception("Chamado " + e.CommandArgument + "não vinculado à solicitação em questão.")
                End If

                ObjChamadoSolicitacaoDesenvolvimento.SetConteudo("empresa", Session("GlEmpresa"))
                ObjChamadoSolicitacaoDesenvolvimento.SetConteudo("cod_chamado", e.CommandArgument)
                ObjChamadoSolicitacaoDesenvolvimento.SetConteudo("cod_solicitacao", Session("SCodSolicitacao"))
                ObjChamadoSolicitacaoDesenvolvimento.Excluir()

                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()

                LblErro.Text = ""
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class