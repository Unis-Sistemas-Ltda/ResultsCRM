Public Class WGOSDespesa
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
        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                totalGeral += CDbl(CType(row.FindControl("LblValorTotal"), Label).Text)
            End If
        Next
        If GridView1.Rows.Count > 0 Then
            CType(GridView1.FooterRow.FindControl("LblTotalGeral"), Label).Text = totalGeral.ToString("F2")
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAtCodTipoDespAcess") = e.CommandArgument
            Session("SAcaoDespesa") = "ALTERAR"
            Call CarregaCabecalho()
        ElseIf e.CommandName = "EXCLUIR" Then
            Try
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
                    GridView1.DataBind()
                End If

                Call SetaParaInclusao()
                Call CarregaCabecalho()

            Catch ex As Exception
                LblErro.Text = ex.Message.ToString
            End Try
        End If
    End Sub

    Protected Sub SetaParaInclusao()
        If Session("SAtCodPedido") <> -1 Then
            Session("SAtCodTipoDespAcess") = -1
            Session("SAcaoDespesa") = "INCLUIR"
        Else
            Mensagem("Antes de adicionar um item, você deve salvar o cabeçalho da OS.")
            WUCAtendimentoPedidoDespesa1.Visible = False
        End If
    End Sub

    Protected Sub MantemCabecalhoCarregado()
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            WUCAtendimentoPedidoDespesa1.Acao = Session("SAcaoDespesa")
            WUCAtendimentoPedidoDespesa1.CodPedidoVenda = Session("SAtCodPedido")
            WUCAtendimentoPedidoDespesa1.CodTipoDespAcess = Session("SAtCodTipoDespAcess")
            WUCAtendimentoPedidoDespesa1.MostraBotaoVoltar = False
            objPedido.empresa = Session("GlEmpresa")
            objPedido.estabelecimento = Session("GlEstabelecimento")
            objPedido.codPedidoVenda = Session("SAtCodPedido")

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
            Call WUCAtendimentoPedidoDespesa1.Carregar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub


End Class