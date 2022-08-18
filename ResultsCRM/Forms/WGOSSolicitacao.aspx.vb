Partial Public Class WGOSSolicitacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call SetaParaInclusao()
            Call CarregaCabecalho()
        Else
            Call MantemCabecalhoCarregado()
        End If
        If Session("GlTipoFaturamento").ToString = "G" Then
            GridView1.Columns.Item(1).HeaderText = "Produto / Componente"
        End If
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
            CarregaCabecalho()
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
                    objPedidoSolicitacao.empresa = Session("GlEmpresa")
                    objPedidoSolicitacao.estabelecimento = Session("GlEstabelecimento")
                    objPedidoSolicitacao.codPedidoVenda = Session("SAtCodPedido")
                    objPedidoSolicitacao.SeqSolicitacao = e.CommandArgument

                    Call objPedidoSolicitacao.Excluir()

                    Mensagem("Solicitação foi excluído da OS com sucesso!")

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
            LblErro.Text = "Antes de adicionar uma solicitação, você deve salvar o cabeçalho da OS."
            WUCAtendimentoPedidoSolicitacao1.Visible = False
        End If
    End Sub

    Protected Sub MantemCabecalhoCarregado()
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))

            WUCAtendimentoPedidoSolicitacao1.Empresa = Session("GlEmpresa")
            WUCAtendimentoPedidoSolicitacao1.Estabelecimento = Session("GlEstabelecimento")
            WUCAtendimentoPedidoSolicitacao1.CodPedidoVenda = Session("SAtCodPedido")
            WUCAtendimentoPedidoSolicitacao1.SeqSolicitacao = Session("SAtSeqItemPedido")
            WUCAtendimentoPedidoSolicitacao1.Acao = Session("SAcaoAtPedido")
            WUCAtendimentoPedidoSolicitacao1.CaminhoVoltar = "WGOSSolicitacao.aspx"

            objPedido.empresa = WUCAtendimentoPedidoSolicitacao1.Empresa
            objPedido.estabelecimento = WUCAtendimentoPedidoSolicitacao1.Estabelecimento
            objPedido.codPedidoVenda = WUCAtendimentoPedidoSolicitacao1.CodPedidoVenda
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
            Call WUCAtendimentoPedidoSolicitacao1.Carregar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

End Class