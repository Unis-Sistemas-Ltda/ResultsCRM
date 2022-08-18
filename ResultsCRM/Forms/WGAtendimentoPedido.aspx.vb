Public Partial Class WGAtendimentoPedido
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objParametrosManutencao As New UCLParametrosManutencao
            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))

            If objParametrosManutencao.GetConteudo("modelo_chamado_crm") <> 1 Then
                GridView3.Columns.Item(2).Visible = False
                GridView3.Columns.Item(3).Visible = False
                GridView3.Columns.Item(4).Visible = False
            End If

            If Not IsPostBack Then
                If objParametrosManutencao.GetConteudo("chamado_os_unica") = "S" Then
                    Dim objChamado As New UCLAtendimento(StrConexao)
                    Dim OSs As List(Of String) = objChamado.GetOSsChamado(Session("GlEmpresa"), Session("GlEstabelecimento"), Session("SCodAtendimento"))
                    If OSs.Count = 1 Then
                        Session("SAtCodPedido") = OSs.Item(0)
                        Session("SAcaoAtPedidoCab") = "ALTERAR"
                        Response.Redirect("WGAtendimentoPedidoItem.aspx?rd=WGAtendimentoPedido.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub Mensagem(ByVal texto As String)
        If Not String.IsNullOrEmpty(texto) Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('" + texto + "');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "", True)
        End If
    End Sub

    Protected Sub BtnIncluirOS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluirOS.Click
        Try
            If String.IsNullOrEmpty(Session("SCodAtendimento")) OrElse Session("SCodAtendimento") = -1 Then
                Mensagem("Antes de inserir a OS você deve gravar o chamado. Por favor clique no botão Salvar localizado no rodapé do lado esquerdo da tela.")
            Else
                Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
                Dim objChamadoStatus As New UCLStatusChamado

                objChamado.Empresa = Session("GlEmpresa")
                objChamado.CodChamado = Session("SCodAtendimento")
                If objChamado.Buscar() Then

                    objChamadoStatus.CodStatus = objChamado.CodStatus
                    objChamadoStatus.Buscar()

                    If objChamadoStatus.Tipo = UCLStatusChamado.TipoStatusChamado.Final Then
                        Mensagem("Não é possível adicionar Ordem de Serviço a um chamado que já está fechado.")
                    Else
                        If objChamadoStatus.Tipo = UCLStatusChamado.TipoStatusChamado.Cancelado Then
                            Mensagem("Não é possível adicionar Ordem de Serviço a um chamado cancelado.")
                        Else
                            Session("SAcaoAtPedidoCab") = "INCLUIR"
                            Session("SAtCodPedido") = -1
                            Response.Redirect("WGAtendimentoPedidoItem.aspx?rd=WGAtendimentoPedido.aspx")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView3_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView3.RowCommand
        Try
            If e.CommandName = "ALTERAR" Then
                Session("SAtCodPedido") = e.CommandArgument
                Session("SAcaoAtPedidoCab") = e.CommandName
                Response.Redirect("WGAtendimentoPedidoItem.aspx?rd=WGAtendimentoPedido.aspx")
            ElseIf e.CommandName = "IMPRIMIR" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "window.open('WFImpressaoOS.aspx?eid=" + Session("GlEmpresa") + "&sid=" + Session("GlEstabelecimento") + "&pid=" + e.CommandArgument + "');", True)
            ElseIf e.CommandName = "EXCLUIR" Then
                Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
                Dim objPedidoVendaItem As New UCLPedidoVendaItem(StrConexaoUsuario(Session("GlUsuario")))
                Dim objPedidoVendaItemProgramacao As New UCLPedidoVendaItemProgramacao(StrConexaoUsuario(Session("GlUsuario")))
                Dim objPedidoVendaSolicitacao As New UCLPedidoVendaSolicitacao(StrConexaoUsuario(Session("GlUsuario")))
                Dim objPedidoVendaSolicitacaoEquipamentoComponente As New UCLPedidoVendaSolicitacaoEquipamentoComponente(StrConexaoUsuario(Session("GlUsuario")))
                Dim objPedidoVendaAgenteTecnico As New UCLPedidoVendaAgenteTecnico(StrConexaoUsuario(Session("GlUsuario")))

                objPedidoVenda.empresa = Session("GlEmpresa")
                objPedidoVenda.estabelecimento = Session("GlEstabelecimento")
                objPedidoVenda.codPedidoVenda = e.CommandArgument
                objPedidoVenda.Buscar()

                If objPedidoVenda.statusDigitacao = "2" Then
                    LblErro.Text = "OS encerrada não pode ser excluída. Caso deseje realmente excluí-la, é necessário que a mesma seja reaberta antes da exclusão."
                    Return
                End If

                objPedidoVendaItem.empresa = objPedidoVenda.empresa
                objPedidoVendaItem.estabelecimento = objPedidoVenda.estabelecimento
                objPedidoVendaItem.codPedidoVenda = objPedidoVenda.codPedidoVenda

                objPedidoVendaItemProgramacao.Empresa = objPedidoVenda.empresa
                objPedidoVendaItemProgramacao.Estabelecimento = objPedidoVenda.estabelecimento
                objPedidoVendaItemProgramacao.CodPedidoVenda = objPedidoVenda.codPedidoVenda

                objPedidoVendaSolicitacao.Empresa = objPedidoVenda.empresa
                objPedidoVendaSolicitacao.Estabelecimento = objPedidoVenda.estabelecimento
                objPedidoVendaSolicitacao.CodPedidoVenda = objPedidoVenda.codPedidoVenda

                objPedidoVendaSolicitacaoEquipamentoComponente.Empresa = objPedidoVenda.empresa
                objPedidoVendaSolicitacaoEquipamentoComponente.Estabelecimento = objPedidoVenda.estabelecimento
                objPedidoVendaSolicitacaoEquipamentoComponente.CodPedidoVenda = objPedidoVenda.codPedidoVenda

                objPedidoVendaAgenteTecnico.Empresa = objPedidoVenda.empresa
                objPedidoVendaAgenteTecnico.Estabelecimento = objPedidoVenda.estabelecimento
                objPedidoVendaAgenteTecnico.CodPedidoVenda = objPedidoVenda.codPedidoVenda

                objPedidoVendaAgenteTecnico.Excluir()
                objPedidoVendaItemProgramacao.Excluir()
                objPedidoVendaItem.Excluir()
                objPedidoVendaSolicitacaoEquipamentoComponente.ExcluirTodos()
                objPedidoVendaSolicitacao.Excluir()
                objPedidoVenda.Excluir()

                Mensagem("OS excluída com sucesso.")

                SqlDataSource3.Select(DataSourceSelectArguments.Empty)
                SqlDataSource3.DataBind()
                GridView3.DataBind()

            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

End Class