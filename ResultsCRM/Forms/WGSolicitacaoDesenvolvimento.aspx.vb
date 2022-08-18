Partial Public Class WGSolicitacaoDesenvolvimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPeriodoI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
        txtPeriodoF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
        txtPeriodoI.Attributes.Add("OnFocus", "selecionaCampo(this)")
        txtPeriodoF.Attributes.Add("OnFocus", "selecionaCampo(this)")

        txtEntregaI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
        txtEntregaF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
        txtEntregaI.Attributes.Add("OnFocus", "selecionaCampo(this)")
        txtEntregaF.Attributes.Add("OnFocus", "selecionaCampo(this)")

        If Not IsPostBack Then
            Call CarregaAnalista()
            Call CarregaDesenvolvedor()
            Call CarregaVersao()
        End If
    End Sub

    Private Sub CarregaVersao()
        Dim ObjVersaoSistema As New UCLBancoDadosVersao
        ObjVersaoSistema.FillDropDown(DdlReleaseVersaoBanco, True, "")
    End Sub

    Private Sub CarregaAnalista()
        Dim objAnalista As New UCLAnalista
        objAnalista.FillDropDown(ddlAnalista, True, "(Todos)", 0, True, False, 0, "")
        ddlAnalista.Items.FindByValue(0).Selected = True
    End Sub

    Private Sub CarregaDesenvolvedor()
        Dim objAnalista As New UCLAnalista
        objAnalista.FillDropDown(ddlDesenvolvedor, True, "(Todos)", 0, True, False, 0, "")
        ddlDesenvolvedor.Items.FindByValue(0).Selected = True
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodSolicitacao") = e.CommandArgument
            Response.Redirect("WFSolicitacaoDesenvolvimentoDetalhes.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            'Try
            '    Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            '    objEmitente.CodEmitente = e.CommandArgument
            '    objEmitente.Excluir()
            'Catch ex As Exception
            '    If ex.Message.Contains("FK_") Then
            '        LblErro.Text = "Não é possível excluir o registro por o mesmo já possui vínculos."
            '    Else
            '        LblErro.Text = ex.Message
            '    End If
            'End Try
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodSolicitacao") = -1
        Response.Redirect("WFSolicitacaoDesenvolvimentoDetalhes.aspx")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub ddlUrgencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUrgencia.SelectedIndexChanged

    End Sub
End Class