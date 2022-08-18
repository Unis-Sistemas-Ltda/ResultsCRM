Partial Public Class WGOSItem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objParametrosManutencao As New UCLParametrosManutencao
        objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
        If Not IsPostBack Then
            Call SetaParaInclusao()
            Call CarregaCabecalho()
        Else
            Call MantemCabecalhoCarregado()
        End If
        If Session("GlTipoFaturamento").ToString = "G" Then
            GridView1.Columns.Item(3).HeaderText = "Produto"
        End If
        If objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 2 OrElse objParametrosManutencao.GetConteudo("modelo_chamado_crm") = 4 Then
            GridView1.Columns.Item(5).Visible = False
            GridView1.Columns.Item(6).Visible = False
        Else
            GridView1.Columns.Item(5).Visible = True
            GridView1.Columns.Item(6).Visible = True
        End If
    End Sub

    Private Sub Mensagem(ByVal texto As String)
        If Not String.IsNullOrEmpty(texto) Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('" + texto + "');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "", True)
        End If
    End Sub

    Private Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        Dim totalGeral As Double = 0
        Dim valorVisible As Boolean = True
        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                valorVisible = CBool(CType(row.FindControl("LblValorVisible"), Label).Text)
                totalGeral += CDbl(CType(row.FindControl("LblValorTotal"), Label).Text)
            End If
        Next
        If GridView1.Rows.Count > 0 Then
            CType(GridView1.FooterRow.FindControl("LblTotalGeral"), Label).Text = totalGeral.ToString("F2")
        End If
        GridView1.Columns.Item(5).Visible = valorVisible
        GridView1.Columns.Item(6).Visible = valorVisible
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAtSeqItemPedido") = e.CommandArgument
            Session("SAcaoAtPedido") = "ALTERAR"
            Call CarregaCabecalho()
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

                    SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                    SqlDataSource1.DataBind()
                    GridView1.DataBind()

                    Call SetaParaInclusao()
                    Call CarregaCabecalho()
                End If

            Catch ex As Exception
                LblErro.Text = ex.Message.ToString
            End Try
        End If
    End Sub

    Protected Sub SetaParaInclusao()
        If Session("SAtCodPedido") <> -1 Then
            Session("SAtSeqItemPedido") = -1
            Session("SAcaoAtPedido") = "INCLUIR"
        Else
            Mensagem("Antes de adicionar um item, você deve salvar o cabeçalho da OS.")
            WUCAtendimentoPedidoItem1.Visible = False
        End If
    End Sub

    Protected Sub MantemCabecalhoCarregado()
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            WUCAtendimentoPedidoItem1.Empresa = Session("GlEmpresa")
            WUCAtendimentoPedidoItem1.Estabelecimento = Session("GlEstabelecimento")
            WUCAtendimentoPedidoItem1.CodPedidoVenda = Session("SAtCodPedido")
            WUCAtendimentoPedidoItem1.SeqItem = Session("SAtSeqItemPedido")
            WUCAtendimentoPedidoItem1.Acao = Session("SAcaoAtPedido")
            WUCAtendimentoPedidoItem1.CaminhoVoltar = "WGOSItem.aspx"
            objPedido.empresa = WUCAtendimentoPedidoItem1.Empresa
            objPedido.estabelecimento = WUCAtendimentoPedidoItem1.Estabelecimento
            objPedido.codPedidoVenda = WUCAtendimentoPedidoItem1.CodPedidoVenda

            If Not String.IsNullOrEmpty(objPedido.empresa) AndAlso Not String.IsNullOrEmpty(objPedido.estabelecimento) AndAlso Not String.IsNullOrEmpty(objPedido.codPedidoVenda) Then
                If objPedido.Buscar() Then
                    Session("SCodAtendimento") = objPedido.codChamado
                    Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
                    objChamado.Empresa = objPedido.empresa
                    objChamado.CodChamado = objPedido.codChamado
                    If Not String.IsNullOrEmpty(objChamado.Empresa) AndAlso Not String.IsNullOrEmpty(objChamado.CodChamado) Then
                        If objChamado.Buscar() Then
                            Session("SCodEmitenteAtNegociacao") = objChamado.CodEmitenteAtendimento
                            Session("SCNPJEmitenteAtendimento") = objChamado.CnpjAtendimento
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CarregaCabecalho()
        Try
            Call MantemCabecalhoCarregado()
            Call WUCAtendimentoPedidoItem1.Carregar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

End Class