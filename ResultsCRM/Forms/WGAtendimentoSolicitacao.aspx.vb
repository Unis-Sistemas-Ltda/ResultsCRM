Partial Public Class WGAtendimentoSolicitacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnVincular_Click(sender As Object, e As EventArgs) Handles BtnVincular.Click
        Try
            Dim ObjChamadoSolicitacaoDesenvolvimento As New UCLChamadoSolicitacaoDesenvolvimento
            Dim ObjSolicitacaoDesenvolvimento As New UCLSolicitacaoDesenvolvimento

            If Not IsNumeric(TxtCodSolicitacao.Text) Then
                Throw New Exception("Informe corretamente o número da SD a ser vinculada.")
            End If

            If ObjChamadoSolicitacaoDesenvolvimento.Buscar(Session("GlEmpresa"), Session("SCodAtendimento"), TxtCodSolicitacao.Text) Then
                Throw New Exception("SD já vinculada ao chamado em questão.")
            End If

            ObjSolicitacaoDesenvolvimento.Empresa = Session("GlEmpresa")
            ObjSolicitacaoDesenvolvimento.CodSolicitacao = TxtCodSolicitacao.Text
            If Not ObjSolicitacaoDesenvolvimento.Buscar() Then
                Throw New Exception("SD informada não foi encontrada.")
            End If

            ObjChamadoSolicitacaoDesenvolvimento.SetConteudo("empresa", Session("GlEmpresa"))
            ObjChamadoSolicitacaoDesenvolvimento.SetConteudo("cod_chamado", Session("SCodAtendimento"))
            ObjChamadoSolicitacaoDesenvolvimento.SetConteudo("cod_solicitacao", TxtCodSolicitacao.Text)
            ObjChamadoSolicitacaoDesenvolvimento.Incluir()

            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()

            TxtCodSolicitacao.Text = ""
            LblErro.Text = ""

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim ObjChamadoSolicitacaoDesenvolvimento As New UCLChamadoSolicitacaoDesenvolvimento

                If Not ObjChamadoSolicitacaoDesenvolvimento.Buscar(Session("GlEmpresa"), Session("SCodAtendimento"), e.CommandArgument) Then
                    Throw New Exception("SD " + e.CommandArgument + "não vinculada ao chamado em questão.")
                End If

                ObjChamadoSolicitacaoDesenvolvimento.SetConteudo("empresa", Session("GlEmpresa"))
                ObjChamadoSolicitacaoDesenvolvimento.SetConteudo("cod_chamado", Session("SCodAtendimento"))
                ObjChamadoSolicitacaoDesenvolvimento.SetConteudo("cod_solicitacao", e.CommandArgument)
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