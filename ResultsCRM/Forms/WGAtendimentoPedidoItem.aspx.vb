Public Partial Class WGAtendimentoPedidoItem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objParametrosManutencao As New UCLParametrosManutencao
            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))

            If Not IsPostBack Then
                Dim objAgenteTecnico As New UCLAgenteTecnico
                objAgenteTecnico.FillDropDown(DdlAgenteTecnico, False, "", "")
            End If

            If Session("GlTipoFaturamento").ToString = "G" Then
                GridView1.Columns.Item(1).HeaderText = "Produto / Solicitação"
                GridView1.Columns.Item(2).Visible = False
            End If

            WUCAtendimentoPedidoCabecalho1.Empresa = Session("GlEmpresa")
            WUCAtendimentoPedidoCabecalho1.Estabelecimento = Session("GlEstabelecimento")
            WUCAtendimentoPedidoCabecalho1.CodAtendimento = Session("SCodAtendimento")
            WUCAtendimentoPedidoCabecalho1.Acao = IIf(Session("SAtCodPedido") = -1, "INCLUIR", "ALTERAR")
            WUCAtendimentoPedidoCabecalho1.OrigemAberturaTela = WUCAtendimentoPedidoCabecalho.TipoAberturaTela.Atendimento
            If WUCAtendimentoPedidoCabecalho1.Acao = "INCLUIR" Then
                If String.IsNullOrEmpty(WUCAtendimentoPedidoCabecalho1.CodPedidoVenda) Then
                    WUCAtendimentoPedidoCabecalho1.CodPedidoVenda = Session("SAtCodPedido")
                End If
            Else
                WUCAtendimentoPedidoCabecalho1.CodPedidoVenda = Session("SAtCodPedido")
            End If

            If objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 1 Then
                LblItensOSTitulo.Visible = False
                GridView4.Visible = False
                BtnIncluirItem.Visible = False
                LblFollowUpOS.Visible = False
                GridView5.Visible = False
                BtnIncluirFollowUpOS.Visible = False
            Else
                LblItensOSTitulo.Visible = True
                LblMateriaisTitulo.Visible = False
                GridView3.Visible = False
                BtnIncluirSolicitacaoMaterial.Visible = False
                LblFollowUpOS.Visible = True
                GridView5.Visible = True
                BtnIncluirFollowUpOS.Visible = True
                GridView4.Visible = True
                BtnIncluirItem.Visible = True
                If objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 2 OrElse objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 4 Then
                    GridView4.Columns.Item(5).Visible = False
                    GridView4.Columns.Item(6).Visible = False
                Else
                    GridView4.Columns.Item(5).Visible = True
                    GridView4.Columns.Item(6).Visible = True
                End If
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub Mensagem(ByVal texto As String)
        If Not String.IsNullOrEmpty(texto) Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('" + texto + "');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "", True)
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAtSeqItemPedido") = e.CommandArgument
            Session("SAcaoAtPedido") = "ALTERAR"
            Response.Redirect("WFOSSolicitacao.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Try
                Dim objPedidoSolicitacao As New UCLPedidoVendaSolicitacao(StrConexaoUsuario(Session("GlUsuario")))
                Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

                objPedido.empresa = Session("GlEmpresa")
                objPedido.estabelecimento = Session("GlEstabelecimento")
                objPedido.codPedidoVenda = Session("SAtCodPedido")
                objPedido.Buscar()

                If objPedido.statusDigitacao = "2" Then
                    Mensagem("OS já está encerrada. Não foi possível excluir a solicitação.")
                Else
                    objPedidoSolicitacao.Empresa = Session("GlEmpresa")
                    objPedidoSolicitacao.Estabelecimento = Session("GlEstabelecimento")
                    objPedidoSolicitacao.CodPedidoVenda = Session("SAtCodPedido")
                    objPedidoSolicitacao.SeqSolicitacao = e.CommandArgument

                    Call objPedidoSolicitacao.Excluir()

                    Mensagem("Solicitação foi excluído da OS com sucesso!")

                    SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                    SqlDataSource1.DataBind()
                    GridView1.DataBind()
                End If
            Catch ex As Exception
                LblErro.Text = ex.Message.ToString
            End Try
        End If
    End Sub

    Protected Sub BtnVincularTecnico_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVincularTecnico.Click
        Try
            Call IncluirTecnico()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub IncluirTecnico()
        Try
            If Session("SAtCodPedido") = -1 Then
                BtnVincularTecnico.Enabled = False
                BtnVincularTecnico.ToolTip = "Você deve Salvar a Ordem de Serviço antes de vincular um agente técnico."
            End If

            Dim objPedidoVendaAgenteTecnico As New UCLPedidoVendaAgenteTecnico(StrConexaoUsuario(Session("GlUsuario")))

            objPedidoVendaAgenteTecnico.Empresa = Session("GlEmpresa")
            objPedidoVendaAgenteTecnico.Estabelecimento = Session("GlEstabelecimento")
            objPedidoVendaAgenteTecnico.CodPedidoVenda = Session("SAtCodPedido")
            objPedidoVendaAgenteTecnico.CodAgenteTecnico = DdlAgenteTecnico.SelectedValue

            If objPedidoVendaAgenteTecnico.Existe() Then
                Mensagem("Agente técnico já vinculado.")
            Else
                objPedidoVendaAgenteTecnico.Incluir()
                SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                SqlDataSource2.DataBind()
                GridView2.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Call ExcluirTecnico(e.CommandArgument)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub ExcluirTecnico(ByVal codAgenteTecnico As String)
        Try
            Dim objPedidoVendaAgenteTecnico As New UCLPedidoVendaAgenteTecnico(StrConexaoUsuario(Session("GlUsuario")))

            objPedidoVendaAgenteTecnico.Empresa = Session("GlEmpresa")
            objPedidoVendaAgenteTecnico.Estabelecimento = Session("GlEstabelecimento")
            objPedidoVendaAgenteTecnico.CodPedidoVenda = Session("SAtCodPedido")
            objPedidoVendaAgenteTecnico.CodAgenteTecnico = codAgenteTecnico
            objPedidoVendaAgenteTecnico.Excluir()

            SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            SqlDataSource2.DataBind()
            GridView2.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnIncluirServicoSolicitado_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluirServicoSolicitado.Click
        If Session("SAtCodPedido") <> -1 Then
            Session("SAtSeqItemPedido") = -1
            Session("SAcaoAtPedido") = "INCLUIR"
            Response.Redirect("WFOSSolicitacao.aspx")
        Else
            LblErro.Text = "Antes de adicionar um serviço solicitado, você deve salvar o cabeçalho da OS."
        End If
    End Sub

    Protected Sub BtnIncluirSolicitacaoMaterial_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluirSolicitacaoMaterial.Click
        If Session("SAtCodPedido") <> -1 Then
            Session("SAtSolicitacao") = -1
            Session("SAcaoAtPedido") = "INCLUIR"
            Response.Redirect("WFOSSolicitacaoMaterial.aspx")
        Else
            LblErro.Text = "Antes de adicionar uma solicitação de material, você deve salvar o cabeçalho da OS."
        End If
    End Sub

    Private Sub GridView3_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView3.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAtSolicitacao") = e.CommandArgument
            Session("SAcaoAtPedido") = "ALTERAR"
            Response.Redirect("WFOSSolicitacaoMaterial.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Try
                Dim objSolicitacao As New UCLSolicitacaoTecnico(StrConexaoUsuario(Session("GlUsuario")))
                objSolicitacao.empresa = Session("GlEmpresa")
                objSolicitacao.estabelecimento = Session("GlEstabelecimento")
                objSolicitacao.cod_solicitacao = e.CommandArgument
                objSolicitacao.Excluir(objSolicitacao.empresa, objSolicitacao.estabelecimento, objSolicitacao.cod_solicitacao)
                SqlDataSource3.Select(DataSourceSelectArguments.Empty)
                SqlDataSource3.DataBind()
                GridView3.DataBind()
                Mensagem("Solicitação de material excluída com sucesso!")
            Catch ex As Exception
                LblErro.Text = ex.Message.ToString
            End Try
        End If
    End Sub

    Protected Sub BtnIncluirItem_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluirItem.Click
        If Session("SAtCodPedido") <> -1 Then
            Session("SAtSeqItemPedido") = -1
            Session("SAcaoAtPedido") = "INCLUIR"
            Response.Redirect("WFOSItem.aspx")
        Else
            LblErro.Text = "Antes de adicionar um item à OS, você deve salvar o cabeçalho."
        End If
    End Sub

    Private Sub GridView4_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView4.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAtSeqItemPedido") = e.CommandArgument
            Session("SAcaoAtPedido") = "ALTERAR"
            Response.Redirect("WFOSItem.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Try
                Dim objPedidoItem As New UCLPedidoVendaItem(StrConexaoUsuario(Session("GlUsuario")))
                Dim objPedidoItemProg As New UCLPedidoVendaItemProgramacao(StrConexaoUsuario(Session("GlUsuario")))
                Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
                Dim ObjPedidoItemEquipComp As New UCLPedidoVendaItemEquipamentoComponente(StrConexaoUsuario(Session("GlUsuario")))

                objPedido.empresa = Session("GlEmpresa")
                objPedido.estabelecimento = Session("GlEstabelecimento")
                objPedido.codPedidoVenda = Session("SAtCodPedido")
                objPedido.Buscar()

                If objPedido.statusDigitacao = "2" Then
                    Mensagem("OS já está encerrada. Não foi possível excluir o item.")
                Else
                    objPedidoItem.empresa = Session("GlEmpresa")
                    objPedidoItem.estabelecimento = Session("GlEstabelecimento")
                    objPedidoItem.codPedidoVenda = Session("SAtCodPedido")
                    objPedidoItem.seqItem = e.CommandArgument

                    objPedidoItemProg.Empresa = Session("GlEmpresa")
                    objPedidoItemProg.Estabelecimento = Session("GlEstabelecimento")
                    objPedidoItemProg.CodPedidoVenda = Session("SAtCodPedido")
                    objPedidoItemProg.SeqItem = e.CommandArgument
                    objPedidoItemProg.seqProgramacao = 1

                    ObjPedidoItemEquipComp.Empresa = Session("GlEmpresa")
                    ObjPedidoItemEquipComp.Estabelecimento = Session("GlEstabelecimento")
                    ObjPedidoItemEquipComp.CodPedidoVenda = Session("SAtCodPedido")
                    ObjPedidoItemEquipComp.SeqItem = e.CommandArgument

                    Call ObjPedidoItemEquipComp.ExcluirTodos()
                    Call objPedidoItemProg.Excluir()
                    Call objPedidoItem.Excluir()

                    Mensagem("Item da OS foi excluido com sucesso!")

                    SqlDataSource4.Select(DataSourceSelectArguments.Empty)
                    SqlDataSource4.DataBind()
                    GridView4.DataBind()
                End If
            Catch ex As Exception
                LblErro.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub GridView4_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView4.DataBound
        Dim totalGeral As Double = 0
        Dim valorVisible As Boolean = True
        For Each row As GridViewRow In GridView4.Rows
            If row.RowType = DataControlRowType.DataRow Then
                valorVisible = CBool(CType(row.FindControl("LblValorVisible"), Label).Text)
                totalGeral += CDbl(CType(row.FindControl("LblValorTotal"), Label).Text)
            End If
        Next
        If GridView4.Rows.Count > 0 Then
            CType(GridView4.FooterRow.FindControl("LblTotalGeral"), Label).Text = totalGeral.ToString("F2")
        End If

        GridView4.Columns.Item(5).Visible = valorVisible
        GridView4.Columns.Item(6).Visible = valorVisible

    End Sub

    Private Sub GridView5_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView5.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SPdSeqFollowUP") = e.CommandArgument
            Session("SAcaoPdFollowUP") = "ALTERAR"
            Response.Redirect("WFOSFollowUp.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim ObjFollowUP As New UCLFollowUpEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

            objPedido.empresa = Session("GlEmpresa")
            objPedido.estabelecimento = Session("GlEstabelecimento")
            objPedido.codPedidoVenda = Session("SAtCodPedido")
            objPedido.Buscar()

            If objPedido.statusDigitacao = "2" Then
                Mensagem("OS já está encerrada. Não é possível excluir follow-up.")
            Else
                ObjFollowUP.Empresa = Session("GlEmpresa")
                ObjFollowUP.Estabelecimento = Session("GlEstabelecimento")
                ObjFollowUP.SeqFollowUP = e.CommandArgument
                ObjFollowUP.Excluir()

                Mensagem("Follow-up excluído com sucesso!")

                SqlDataSource5.Select(DataSourceSelectArguments.Empty)
                SqlDataSource5.DataBind()
                GridView5.DataBind()
            End If
        End If
    End Sub

    Protected Sub BtnIncluirFollowUpOS_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluirFollowUpOS.Click
        Session("SPdSeqFollowUP") = -1
        Session("SAcaoPdFollowUP") = "INCLUIR"
        Response.Redirect("WFOSFollowUp.aspx")
    End Sub

    Protected Sub BtnIncluirDespesaAcessoria_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluirDespesaAcessoria.Click
        Session("SAtCodTipoDespAcess") = -1
        Session("SAcaoDespesa") = "INCLUIR"
        Response.Redirect("WFAtendimentoPedidoDespesa.aspx")
    End Sub

    Private Sub GridView6_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView6.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAtCodTipoDespAcess") = e.CommandArgument
            Session("SAcaoDespesa") = "ALTERAR"
            Response.Redirect("WFAtendimentoPedidoDespesa.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim ObjPedidoDespesa As New UCLPedidoVendaDespesas
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

            objPedido.empresa = Session("GlEmpresa")
            objPedido.estabelecimento = Session("GlEstabelecimento")
            objPedido.codPedidoVenda = Session("SAtCodPedido")
            objPedido.Buscar()

            If objPedido.statusDigitacao = "2" Then
                Mensagem("OS já está encerrada. Não é possível excluir despesa acessória.")
            Else
                ObjPedidoDespesa.Excluir(Session("GlEmpresa"), Session("GlEstabelecimento"), Session("SAtCodPedido"), e.CommandArgument)
                
                Mensagem("Despesa excluída com sucesso!")

                SqlDataSource6.Select(DataSourceSelectArguments.Empty)
                SqlDataSource6.DataBind()
                GridView6.DataBind()
            End If
        End If
    End Sub
End Class