Imports System.IO
Partial Public Class WFRelOSItem
    Inherits System.Web.UI.Page

    Dim objParametrosManutencao As New UCLParametrosManutencao

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objTipoChamado As New UCLTipoChamado
            Dim objStatusChamado As New UCLStatusChamado
            Dim objAnalista As New UCLAnalista

            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
            If objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 2 OrElse objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 3 OrElse objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 4 Then
                LblPontoAtend.Visible = False
                TxtPontoDeAtendimento.Visible = False
                LblTecnico.Visible = False
                ddlAgenteTecnico.Visible = False
                GVRelOS.Columns.Item(2).Visible = False
                GVRelOS.Columns.Item(3).Visible = False
                GVRelOS.Columns.Item(5).Visible = False
                GVRelOS.Columns.Item(6).Visible = False
            End If

            If Not IsPostBack Then
                Call CarregaRegiao()
                Call CarregaAnalista()
                Call CarregaTecnico()
                objTipoChamado.FillDropDown(Session("GlEmpresa"), ddlTipoChamado, True, "(Todos)", -1)
                objStatusChamado.FillDropDown(DdlStatus, True, "(Todos)", -1, UCLStatusChamado.TipoDropDown.Completo, "0")
                Call CarregaContatos()
                Call CarregaTipoCobranca()
                'Call AplicaFiltro()
            End If

            objAnalista.Codigo = Session("GlCodUsuario")
            If Not objAnalista.Buscar OrElse objAnalista.Inativo = "S" Then
                LblErro.Text = "ACESSO NEGADO.<br/><br/>Prezado usuário<br>Para ter acesso ao painel de atendimentos, é necessário que você solicite à pessoa responsável o seu cadastramento como analista no Results."
                GVRelOS.Visible = False
                TxtNrAtendimento.Enabled = False
                DdlStatus.Enabled = False
                ddlTipoStatus.Enabled = False
                TxtCodEmitente.Enabled = False
                TxtNomeEmitente.Enabled = False
                DdlContato.Enabled = False
                ddlTipoChamado.Enabled = False
                ddlAnalista.Enabled = False
                TxtAssunto.Enabled = False
            End If

            txtDataI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            txtDataFinalizacaoOSI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            txtDataFinalizacaoOSF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            txtDataInclusaoOSI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            txtDataInclusaoOSF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            txtDataTerminoExecucaoOSI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            txtDataTerminoExecucaoOSF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            txtDataInicioExecucaoOSI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            txtDataInicioExecucaoOSF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub Colore()
        Dim LblTipoStatus As Label
        Dim LblDias As Label
        For Each row As GridViewRow In GVRelOS.Rows
            If row.RowType = DataControlRowType.DataRow Then
                LblTipoStatus = CType(row.FindControl("LblTipoStatus"), Label)
                LblDias = CType(row.FindControl("LblDias"), Label)

                If LblTipoStatus.Text = "3" Then
                    row.ForeColor = Drawing.Color.Green
                Else
                    If CDbl(LblDias.Text) < 0 Then
                        row.ForeColor = Drawing.Color.Red
                    ElseIf CDbl(LblDias.Text) = 0 Then
                        row.ForeColor = Drawing.Color.Blue
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub CarregaAnalista()
        Dim objAnalista As New UCLAnalista
        objAnalista.FillDropDown(ddlAnalista, True, "(Todos)", -1, True, False, -1, "")

        If objParametrosManutencao.GetConteudo("filtro_todos_analistas") = "S" Then
            ddlAnalista.Items.FindByValue(-1).Selected = True
        Else
            If ddlAnalista.Items.FindByValue(Session("GlCodUsuario")) IsNot Nothing Then
                ddlAnalista.Items.FindByValue(Session("GlCodUsuario")).Selected = True
            End If
        End If

    End Sub

    Private Sub CarregaTecnico()
        Dim objAgTecnico As New UCLAgenteTecnico
        objAgTecnico.FillDropDown(ddlAgenteTecnico, True, "(Todos)", -1)
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVRelOS.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SCodAtendimento") = e.CommandArgument
            Session("SAcao") = "ALTERAR"
            Response.Redirect("WFAtendimento.aspx")
        End If
    End Sub

    Protected Sub AplicaFiltro()
        SqlDataSource1.SelectCommand = "call sp_rel_painel_os_item(:empresa, :cod_chamado, :assunto, :cod_status, :cod_analista, :cod_usuario, :cod_emitente, :cod_contato, :tipo_chamado, :tipo_status, :nome_emitente, :os_cliente, :os_interna, :ponto_atendimento, :agente_tecnico, :abertura_i, :abertura_f, :data_inicio_execucao_i, :data_inicio_execucao_f, :data_termino_execucao_i, :data_termino_execucao_f, :data_inclusao_os_i, :data_inclusao_os_f, :data_finalizacao_os_i, :data_finalizacao_os_f, :cod_tipo_cobranca_os, :servico_solicitado, :servico_realizado, :cod_regiao)"
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GVRelOS.DataBind()
        'Call Colore()
    End Sub

    Private Sub CarregaContatos()
        Try
            Dim objContato As New UCLContato
            objContato.CodEmitente = TxtCodEmitente.Text
            objContato.FillDropDown(DdlContato, True, "(Todos)", -1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtCodEmitente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCodEmitente.TextChanged
        Call CarregaContatos()
        'Call AplicaFiltro()
    End Sub

    Protected Sub TxtNrAtendimento_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtNrAtendimento.TextChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub TxtOSCliente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtOSCliente.TextChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub TxtOSInterna_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtOSInterna.TextChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub TxtNomeEmitente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtNomeEmitente.TextChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub DdlContato_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlContato.SelectedIndexChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub TxtPontoDeAtendimento_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtPontoDeAtendimento.TextChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub ddlTipoChamado_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlTipoChamado.SelectedIndexChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub ddlTipoStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlTipoStatus.SelectedIndexChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub DdlStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlStatus.SelectedIndexChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub TxtAssunto_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtAssunto.TextChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub ddlAnalista_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlAnalista.SelectedIndexChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub ddlAgenteTecnico_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlAgenteTecnico.SelectedIndexChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Call exportarExcel()
    End Sub

    Protected Sub txtDataI_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDataI.TextChanged
        Call AplicaFiltro()
    End Sub

    Protected Sub txtDataF_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDataF.TextChanged
        Call AplicaFiltro()
    End Sub

    Sub exportarExcel()

        'se o grid tiver mais que 65536  linhas não podemos exportar
        If GVRelOS.Rows.Count.ToString + 1 < 65536 Then

            GVRelOS.AllowPaging = "False"
            GVRelOS.AllowSorting = "false"
            GVRelOS.DataBind()


            Dim tw As New StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim frm As HtmlForm = New HtmlForm()

            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment;filename=" & "AcompanhamentoDemandaItem.xls")
            Response.Charset = ""
            EnableViewState = False

            Controls.Add(frm)
            frm.Controls.Add(GVRelOS)
            frm.RenderControl(hw)

            Response.Write(tw.ToString())
            Response.End()

            GVRelOS.AllowPaging = "True"
            GVRelOS.AllowSorting = "True"
            GVRelOS.DataBind()

        Else
            LblErro.Text = " planilha possui muitas linhas, não é possível exportar para o EXcel"
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call AplicaFiltro()
    End Sub

    Private Sub CarregaTipoCobranca()
        Dim objtipo As New UCLTipoCobrancaOS
        objtipo.FillDropDown(ddlTipoCobrancaOS, True, "(Todos)", "0")
    End Sub

    Private Sub CarregaRegiao()
        Dim objRegiao As New UCLRegiao
        objRegiao.FillDropDown(Session("GlEmpresa"), ddlRegiao, True, "(Todas)")
    End Sub
End Class