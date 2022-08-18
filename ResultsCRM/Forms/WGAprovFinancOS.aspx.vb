Public Partial Class WGAprovFinancOS
    Inherits System.Web.UI.Page

    Dim objParametrosManutencao As New UCLParametrosManutencao
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objTipoChamado As New UCLTipoChamado
            Dim objStatusChamado As New UCLStatusChamado
            Dim objAnalista As New UCLAnalista
            Dim dataIni As Date
            Dim dataFim As Date
            Dim dataReferencia As Date

            TxtEncerramento_I.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtEncerramento_F.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")

            If Not IsPostBack Then

                dataReferencia = Now.Date

                If Now.Date.Day <= 5 Then
                    dataReferencia = dataReferencia.AddMonths(-1)
                End If

                dataIni = New Date(dataReferencia.Year, dataReferencia.Month, 1)
                dataFim = dataIni.AddMonths(1).AddDays(-1)

                TxtEncerramento_I.Text = dataIni.ToString("dd/MM/yyyy")
                TxtEncerramento_F.Text = dataFim.ToString("dd/MM/yyyy")

                objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
                Call CarregaContatos()
                Call CarregaAnalista()
                Call AplicaFiltro()
            End If

            objAnalista.Codigo = Session("GlCodUsuario")
            If Not objAnalista.Buscar OrElse objAnalista.Inativo = "S" Then
                LblErro.Text = "ACESSO NEGADO.<br/><br/>Prezado usuário<br>Para ter acesso ao painel de Ordens de Serviço, é necessário que você solicite à pessoa responsável o seu cadastramento como analista no Results."
                GridView1.Visible = False
                TxtCodPedidoVenda.Enabled = False
                DdlStatusAprovacao.Enabled = False
                TxtCodEmitente.Enabled = False
                TxtNomeEmitente.Enabled = False
                DdlContato.Enabled = False
                DdlTop.Enabled = False
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub RegistraRecebimentoOS(ByVal empresa As String, ByVal estabelecimento As String, ByVal codPedidoVenda As String)
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

            objPedido.empresa = empresa
            objPedido.estabelecimento = estabelecimento
            objPedido.codPedidoVenda = codPedidoVenda
            objPedido.Buscar()
            objPedido.statusRecebimento = "2"
            objPedido.Alterar()

            Call AplicaFiltro()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAtCodPedido") = e.CommandArgument
            Session("SAcaoAtPedidoCab") = "ALTERAR"
            Response.Redirect("WFAprovFinancOS.aspx")
        End If
    End Sub

    Protected Sub AplicaFiltro()
        Try
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()

            SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            SqlDataSource2.DataBind()
            GridView2.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
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
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If CType(e.Row.FindControl("LblStatusRec"), Label).Text = "Pendente" Then
                CType(e.Row.FindControl("CbxMarcado"), CheckBox).Visible = True
                If CType(e.Row.FindControl("LblStatusDig"), Label).Text <> "Encerrada" Then
                    e.Row.ToolTip = "Esta OS ainda está aberta. Para registrar o recebimento, a OS precisa estar encerrada. "
                    CType(e.Row.FindControl("CbxMarcado"), CheckBox).Visible = False
                End If
            End If
        End If
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

    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles BtnRegistrarRecebimento.Click
        Dim OSmarcada As String = ""
        Try
            Dim marcadas As New List(Of String)
            For Each row As GridViewRow In GridView1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    If CType(row.FindControl("CbxMarcado"), CheckBox).Checked Then
                        marcadas.Add(CType(row.FindControl("LblCodPedidoVenda"), Label).Text)
                    End If
                End If
            Next

            If marcadas.Count = 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('Nenhuma OS selecionada.');", True)
                Return
            End If

            For Each OSmarcada In marcadas
                Call RegistraRecebimentoOS(Session("GlEmpresa"), Session("GlEstabelecimento"), OSmarcada)
            Next

            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('O recebimento das OSs selecionadas foi registrado com sucesso.');", True)

        Catch ex As Exception
            LblErro.Text = ex.Message

            If Not String.IsNullOrEmpty(OSmarcada) Then
                LblErro.Text = "Erro ao registrar o recebimento da OS nº " + OSmarcada + ".<br/>" + LblErro.Text
            End If

        End Try
    End Sub

    Protected Sub BtnMarcar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim marcou As Boolean = False
            For Each row As GridViewRow In GridView1.Rows
                If CType(row.FindControl("CbxMarcado"), CheckBox).Visible Then
                    CType(row.FindControl("CbxMarcado"), CheckBox).Checked = True
                    marcou = True
                End If
            Next
            If Not marcou Then
                Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('Não há OSs a serem marcadas.');", True)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

End Class