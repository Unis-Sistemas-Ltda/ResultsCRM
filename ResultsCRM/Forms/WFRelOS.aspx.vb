Imports System.IO
Partial Public Class WFRelOS
    Inherits System.Web.UI.Page

    Dim objParametrosManutencao As New UCLParametrosManutencao

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objTipoChamado As New UCLTipoChamado
            Dim objStatusChamado As New UCLStatusChamado
            Dim objAnalista As New UCLAnalista

            'Session("datai") = ""
            'Session("dataf") = ""

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
                LblRegiaoAtend.Visible = False
                ddlRegiao.Visible = False
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

    Private Sub CarregaTipoCobranca()
        Dim objtipo As New UCLTipoCobrancaOS
        objtipo.FillDropDown(ddlTipoCobrancaOS, True, "(Todos)", "0")
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVRelOS.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SCodAtendimento") = e.CommandArgument
            Session("SAcao") = "ALTERAR"
            Response.Redirect("WFAtendimento.aspx")
        End If
    End Sub

    Protected Sub AplicaFiltro()
        SqlDataSource1.SelectCommand = "call sp_rel_painel_os(:empresa, :cod_chamado, :assunto, :cod_status, :cod_analista, :cod_usuario, :cod_emitente, :cod_contato, :tipo_chamado, :tipo_status, :nome_emitente, :os_cliente, :os_interna, :ponto_atendimento, :agente_tecnico, :abertura_i, :abertura_f, :data_inicio_execucao_i, :data_inicio_execucao_f, :data_termino_execucao_i, :data_termino_execucao_f, :data_inclusao_os_i, :data_inclusao_os_f, :data_finalizacao_os_i, :data_finalizacao_os_f, :cod_tipo_cobranca_os, :servico_solicitado, :servico_realizado, :cod_regiao)"
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
        Call AplicaFiltro()
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Call exportarExcel()
    End Sub

    Sub exportarExcel()

        'se o grid tiver mais que 65536  linhas não podemos exportar
        If GVRelOS.Rows.Count.ToString + 1 < 65536 Then

            SqlDataSource1.SelectCommand = "call sp_rel_painel_os(:empresa, :cod_chamado, :assunto, :cod_status, :cod_analista, :cod_usuario, :cod_emitente, :cod_contato, :tipo_chamado, :tipo_status, :nome_emitente, :os_cliente, :os_interna, :ponto_atendimento, :agente_tecnico, :abertura_i, :abertura_f, :data_inicio_execucao_i, :data_inicio_execucao_f, :data_termino_execucao_i, :data_termino_execucao_f, :data_inclusao_os_i, :data_inclusao_os_f, :data_finalizacao_os_i, :data_finalizacao_os_f, :cod_tipo_cobranca_os, :servico_solicitado, :servico_realizado, :cod_regiao)"
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()

            GVRelOS.AllowPaging = "False"
            GVRelOS.AllowSorting = "false"
            GVRelOS.DataBind()

            Dim tw As New StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim frm As HtmlForm = New HtmlForm()

            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment;filename=" & "AcompanhamentoDemanda.xls")
            Response.Charset = ""
            EnableViewState = False

            Controls.Add(frm)
            frm.Controls.Add(GVRelOS)
            frm.RenderControl(hw)

            Response.Write(tw.ToString())
            Response.End()

            SqlDataSource1.SelectCommand = "call sp_rel_painel_os(:empresa, :cod_chamado, :assunto, :cod_status, :cod_analista, :cod_usuario, :cod_emitente, :cod_contato, :tipo_chamado, :tipo_status, :nome_emitente, :os_cliente, :os_interna, :ponto_atendimento, :agente_tecnico, :abertura_i, :abertura_f, :data_inicio_execucao_i, :data_inicio_execucao_f, :data_termino_execucao_i, :data_termino_execucao_f, :data_inclusao_os_i, :data_inclusao_os_f, :data_finalizacao_os_i, :data_finalizacao_os_f, :cod_tipo_cobranca_os, :servico_solicitado, :servico_realizado, :cod_regiao)"
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()

            GVRelOS.AllowPaging = "True"
            GVRelOS.AllowSorting = "True"
            GVRelOS.DataBind()

        Else
            LblErro.Text = "Planilha possui mais linhas do que o Excel suporta. Dessa forma, não será possível exportá-la."
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Call AplicaFiltro()
    End Sub

    Private Sub CarregaRegiao()
        Dim objRegiao As New UCLRegiao
        objRegiao.FillDropDown(Session("GlEmpresa"), ddlRegiao, True, "(Todas)")
    End Sub

End Class