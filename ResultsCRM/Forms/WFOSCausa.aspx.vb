Public Class WFOSCausa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("GlTipoFaturamento").ToString = "G" Then
            LblEquipamentoLbl.Text = "Produto:"
        End If
        If Not IsPostBack Then
            Call CarregaEquipamentoCliente()
            Call CarregaCausa()
            Call CarregaFormulario()
        End If
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim objPedidoVendaSolicitacao As New UCLPedidoVendaSolicitacao(StrConexaoUsuario(Session("GlUsuario")))
            objPedidoVendaSolicitacao.Empresa = Session("GlEmpresa")
            objPedidoVendaSolicitacao.Estabelecimento = Session("GlEstabelecimento")
            objPedidoVendaSolicitacao.CodPedidoVenda = Session("SAtCodPedido")
            objPedidoVendaSolicitacao.SeqSolicitacao = Session("SAtSeqItemPedidoCausa")
            objPedidoVendaSolicitacao.Buscar()
            LblSolicitacao.Text = objPedidoVendaSolicitacao.ServicoSolicitado.Replace(Chr(10), "<br>")
            If Not String.IsNullOrWhiteSpace(objPedidoVendaSolicitacao.NumeroSerie) Then
                DdlEquipamento.SelectedValue = objPedidoVendaSolicitacao.NumeroSerie
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaEquipamentoCliente()
        Try
            Dim objEquipamentoCliente As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedidoVenda As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))

            objPedidoVenda.empresa = Session("GlEmpresa")
            objPedidoVenda.estabelecimento = Session("GlEstabelecimento")
            objPedidoVenda.codPedidoVenda = Session("SAtCodPedido")
            objPedidoVenda.Buscar()
            If Not String.IsNullOrEmpty(objPedidoVenda.codChamado) Then
                objChamado.Empresa = objPedidoVenda.empresa
                objChamado.CodChamado = objPedidoVenda.codChamado
                objChamado.Buscar()
                If Not String.IsNullOrEmpty(objChamado.CodEmitenteAtendimento) And Not String.IsNullOrEmpty(objChamado.NumeroPontoAtendimento) Then
                    objEquipamentoCliente.CodCliente = objChamado.CodEmitenteAtendimento
                    objEquipamentoCliente.Empresa = objChamado.Empresa
                    objEquipamentoCliente.NumeroPontoAtendimento = objChamado.NumeroPontoAtendimento
                    If Session("GlTipoFaturamento").ToString = "G" Then
                        objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.DescricaoItem, "0")
                    Else
                        objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.Observacao, "0")
                    End If
                    Session("SPAEquipamento") = objChamado.NumeroPontoAtendimento
                    Session("SCliEquipamento") = objChamado.CodEmitenteAtendimento
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaCausa()
        Try
            Dim ObjCausa As New UCLCausa
            ObjCausa.FillDropDown(Session("GlEmpresa"), DdlCausa, False, "", "0")
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnVincularCausa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVincularCausa.Click
        Try
            Call IncluirCausa()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub IncluirCausa()
        Try
            LblErro.Text = ""
            Dim objPedidoVendaSolicitacaoCausa As New UCLPedidoVendaSolicitacaoCausa(StrConexaoUsuario(Session("GlUsuario")))

            objPedidoVendaSolicitacaoCausa.Empresa = Session("GlEmpresa")
            objPedidoVendaSolicitacaoCausa.Estabelecimento = Session("GlEstabelecimento")
            objPedidoVendaSolicitacaoCausa.CodPedidoVenda = Session("SAtCodPedido")
            objPedidoVendaSolicitacaoCausa.SeqSolicitacao = Session("SAtSeqItemPedidoCausa")
            objPedidoVendaSolicitacaoCausa.CodCausa = DdlCausa.SelectedValue

            If objPedidoVendaSolicitacaoCausa.Existe() Then
                LblErro.Text = "Causa já vinculada. Selecione outra."
            Else
                objPedidoVendaSolicitacaoCausa.Incluir()
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
                Call ExcluirCausa(e.CommandArgument)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub ExcluirCausa(ByVal CodCausa As String)
        Try
            Dim objPedidoVendaSolicitacaoCausa As New UCLPedidoVendaSolicitacaoCausa(StrConexaoUsuario(Session("GlUsuario")))

            objPedidoVendaSolicitacaoCausa.Empresa = Session("GlEmpresa")
            objPedidoVendaSolicitacaoCausa.Estabelecimento = Session("GlEstabelecimento")
            objPedidoVendaSolicitacaoCausa.CodPedidoVenda = Session("SAtCodPedido")
            objPedidoVendaSolicitacaoCausa.SeqSolicitacao = Session("SAtSeqItemPedidoCausa")
            objPedidoVendaSolicitacaoCausa.CodCausa = CodCausa
            objPedidoVendaSolicitacaoCausa.Excluir()

            SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            SqlDataSource2.DataBind()
            GridView2.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("WGOSCausa.aspx")
    End Sub
End Class