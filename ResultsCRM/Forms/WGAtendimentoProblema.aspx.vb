Public Class WGAtendimentoProblema
    Inherits System.Web.UI.Page

    Private Const NAO_SELECIONADO As String = "0"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("GlClienteUnis") = 702 Then
                    BtnIncluirEquipamento.ToolTip = "Incluir Equipamento"
                    BtnIncluirEquipamento.AlternateText = BtnIncluirEquipamento.ToolTip
                    BtnAlterarEquipamento.ToolTip = "Alterar informações do Equipamento"
                    BtnIncluirEquipamento.AlternateText = "Alterar informações do Equipamento"
                    BtnIncluirEquipamento.OnClientClick = "ShowEditModal('../Forms/WFEquipamento2.aspx?aid=I','EditModalPopupClientes','IframeEdit');"
                    BtnAlterarEquipamento.OnClientClick = "ShowEditModal('../Forms/WFEquipamento2.aspx?aid=A','EditModalPopupClientes','IframeEdit');"
                ElseIf Session("GlTipoFaturamento").ToString = "G" Then
                    BtnIncluirEquipamento.ToolTip = "Incluir Produto"
                    BtnIncluirEquipamento.AlternateText = BtnIncluirEquipamento.ToolTip
                    BtnAlterarEquipamento.ToolTip = "Alterar informações do Produto"
                    BtnIncluirEquipamento.AlternateText = "Alterar Produto"
                    BtnIncluir.Visible = False
                    GridView1.Visible = False
                    BtnIncluirEquipamento.OnClientClick = "ShowEditModal('../Forms/WFEquipamento2.aspx?aid=I','EditModalPopupClientes','IframeEdit');"
                    BtnAlterarEquipamento.OnClientClick = "ShowEditModal('../Forms/WFEquipamento2.aspx?aid=A','EditModalPopupClientes','IframeEdit');"
                End If
                Call CarregaEquipamentoCliente("0")
                Dim objGrupoProblema As New UCLGrupoProblema
                objGrupoProblema.FillDropDown(DdlGrupo, Session("GlEmpresa"), True, "(selecione)", NAO_SELECIONADO)

                Dim objChamadoProblema As New UCLChamadoProblema
                objChamadoProblema.FillDropDown(DdlProblemaCausa, Session("GlEmpresa"), Session("SCodAtendimento"))
                If DdlProblemaCausa.Items.Count > 0 Then
                    Call CarregaCausas()
                End If

                objChamadoProblema.FillDropDown(DdlProblemaEfeito, Session("GlEmpresa"), Session("SCodAtendimento"))
                If DdlProblemaEfeito.Items.Count > 0 Then
                    Call CarregaCausasEfeito()
                End If
            End If

            If IsPostBack Then
                Call ChecaAlteracaoNumeroSerie()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaCausasEfeito()
        Try
            Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa
            If DdlProblemaEfeito.Items.Count = 0 Then
                Return
            End If
            If DdlProblemaEfeito.SelectedValue = "" Then
                Return
            End If
            objChamadoProblemaCausa.FillDropDown(DdlCausaEfeito, Session("GlEmpresa"), Session("SCodAtendimento"), DdlProblemaEfeito.SelectedValue, True)
            If DdlCausa.Items.Count = 0 Then
                Return
            Else
                Call CarregaEfeitos()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaEfeitos()
        Try
            Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa
            Dim objChamadoProblemaCausaEfeito As New UCLChamadoProblemaCausaEfeito
            If DdlProblemaEfeito.Items.Count = 0 Then
                Return
            End If
            If DdlProblemaEfeito.SelectedValue = "" Then
                Return
            End If
            If DdlCausaEfeito.Items.Count = 0 Then
                DdlEfeito.Items.Clear()
                Return
            Else
                objChamadoProblemaCausaEfeito.FillDropDown(DdlEfeito, Session("GlEmpresa"), Session("SCodAtendimento"), DdlProblemaEfeito.SelectedValue, DdlCausaEfeito.SelectedValue)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnIncluirEfeito_Click(sender As Object, e As EventArgs) Handles BtnIncluirEfeito.Click
        Try
            Dim objChamadoProblemaCausaEfeito As New UCLChamadoProblemaCausaEfeito

            If DdlProblemaEfeito.Items.Count = 0 OrElse DdlProblemaEfeito.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione um problema."
                Return
            End If

            If DdlCausaEfeito.Items.Count = 0 OrElse DdlCausaEfeito.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione uma causa."
                Return
            End If

            If DdlEfeito.Items.Count = 0 OrElse DdlEfeito.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione um efeito."
                Return
            End If

            If Not objChamadoProblemaCausaEfeito.Buscar(Session("GlEmpresa"), Session("SCodAtendimento"), DdlProblemaEfeito.SelectedValue, DdlCausaEfeito.SelectedValue, DdlEfeito.SelectedValue) Then
                objChamadoProblemaCausaEfeito.SetConteudo("empresa", Session("GlEmpresa"))
                objChamadoProblemaCausaEfeito.SetConteudo("cod_chamado", Session("SCodAtendimento"))
                objChamadoProblemaCausaEfeito.SetConteudo("seq_problema", DdlProblemaEfeito.SelectedValue)
                objChamadoProblemaCausaEfeito.SetConteudo("cod_causa", DdlCausaEfeito.SelectedValue)
                objChamadoProblemaCausaEfeito.SetConteudo("cod_efeito", DdlEfeito.SelectedValue)
                objChamadoProblemaCausaEfeito.Incluir()
                LblErro.Text = "Efeito incluído com sucesso."
                GridView3.DataBind()
            Else
                LblErro.Text = "Efeito selecionado já incluído."
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub ChecaAlteracaoNumeroSerie()
        Try
            Dim NumeroSerieRetornado As String
            Dim recarregaEquipamentos As Long

            If Not String.IsNullOrEmpty(Session("SAlterouNumeroSerieItemPedido")) Then
                recarregaEquipamentos = Session("SAlterouNumeroSerieItemPedido")
            Else
                recarregaEquipamentos = 0
            End If

            If recarregaEquipamentos > 0 Then
                NumeroSerieRetornado = Session("SNumeroSerieItemPedido")
                Call CarregaEquipamentoCliente(NumeroSerieRetornado)
                If Not String.IsNullOrEmpty(NumeroSerieRetornado) Then
                    DdlEquipamento.SelectedValue = NumeroSerieRetornado
                End If
                Session("SAlterouNumeroSerieItemPedido") = recarregaEquipamentos - 2
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaEquipamentoCliente(ByVal numeroSerieSelecionado As String)
        Try
            Dim objEquipamentoCliente As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))

            objChamado.Empresa = Session("GlEmpresa")
            objChamado.CodChamado = Session("SCodAtendimento")
            objChamado.Buscar()

            objEquipamentoCliente.Empresa = objChamado.Empresa
            If Not String.IsNullOrEmpty(objChamado.CodEmitenteAtendimento) And Not String.IsNullOrEmpty(objChamado.NumeroPontoAtendimento) Then
                objEquipamentoCliente.CodCliente = objChamado.CodEmitenteAtendimento
                objEquipamentoCliente.NumeroPontoAtendimento = objChamado.NumeroPontoAtendimento
                Session("SPAEquipamento") = objChamado.NumeroPontoAtendimento
                Session("SCliEquipamento") = objChamado.CodEmitenteAtendimento
            Else
                objEquipamentoCliente.CodCliente = objChamado.CodEmitente
                objEquipamentoCliente.NumeroPontoAtendimento = ""
                Session("SPAEquipamento") = ""
                Session("SCliEquipamento") = objChamado.CodEmitente
            End If

            If Session("GlTipoFaturamento").ToString = "G" Then
                objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.DescricaoItem, numeroSerieSelecionado)
            Else
                objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.Observacao, numeroSerieSelecionado)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Try
            Dim objChamadoProblema As New UCLChamadoProblema

            If DdlEquipamento.Items.Count = 0 OrElse DdlEquipamento.SelectedValue = "" Then
                LblErro.Text = "Selecione um equipamento."
                Return
            End If

            If DdlProblema.Items.Count = 0 OrElse DdlProblema.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione um problema."
                Return
            End If

            If Not objChamadoProblema.BuscarPorCodProblema(Session("GlEmpresa"), Session("SCodAtendimento"), DdlProblema.SelectedValue) Then
                objChamadoProblema.SetConteudo("empresa", Session("GlEmpresa"))
                objChamadoProblema.SetConteudo("cod_chamado", Session("SCodAtendimento"))
                objChamadoProblema.SetConteudo("seq_problema", objChamadoProblema.GetProximoCodigo(Session("GlEmpresa"), Session("SCodAtendimento")))
                objChamadoProblema.SetConteudo("cod_problema", DdlProblema.SelectedValue)
                If Not String.IsNullOrEmpty(DdlEquipamento.SelectedValue) AndAlso DdlEquipamento.SelectedValue <> "-1" Then
                    objChamadoProblema.SetConteudo("numero_serie", DdlEquipamento.SelectedValue)
                End If

                objChamadoProblema.Incluir()
                LblErro.Text = "Problema incluído com sucesso."
                GridView1.DataBind()
            Else
                LblErro.Text = "Problema selecionado já incluído."
            End If

            objChamadoProblema.FillDropDown(DdlProblemaCausa, Session("GlEmpresa"), Session("SCodAtendimento"))
            Call CarregaCausas(objChamadoProblema.GetConteudo("seq_problema"))

            objChamadoProblema.FillDropDown(DdlProblemaEfeito, Session("GlEmpresa"), Session("SCodAtendimento"))
            Call CarregaCausasEfeito()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim objChamadoProblema As New UCLChamadoProblema
            objChamadoProblema.ExcluirPorCodProblema(Session("GlEmpresa"), Session("SCodAtendimento"), e.CommandArgument)
            GridView1.DataBind()

            objChamadoProblema.FillDropDown(DdlProblemaCausa, Session("GlEmpresa"), Session("SCodAtendimento"))
            Call CarregaCausas()
            GridView2.DataBind()

            objChamadoProblema.FillDropDown(DdlProblemaEfeito, Session("GlEmpresa"), Session("SCodAtendimento"))
            Call CarregaCausasEfeito()

            GridView3.DataBind()
        End If
    End Sub

    Protected Sub DdlGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlGrupo.SelectedIndexChanged
        Dim objProblema As New UCLProblemaPadrao
        objProblema.FillDropDown(DdlProblema, Session("GlEmpresa"), DdlGrupo.SelectedValue, True, "(selecione)", NAO_SELECIONADO)
    End Sub

    Protected Sub DdlEquipamento_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlEquipamento.SelectedIndexChanged
        Try
            Session("SNumeroSerieItemPedido") = DdlEquipamento.SelectedValue
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    '
    Private Sub CarregaCausas(Optional ByVal pSeqProblema As String = "")
        Try
            Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa
            If DdlProblemaCausa.Items.Count = 0 Then
                Return
            End If
            If DdlProblemaCausa.SelectedValue = "" Then
                Return
            End If
            objChamadoProblemaCausa.FillDropDown(DdlCausa, Session("GlEmpresa"), Session("SCodAtendimento"), IIf(String.IsNullOrEmpty(pSeqProblema), DdlProblemaCausa.SelectedValue, pSeqProblema), False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnIncluirCausa_Click(sender As Object, e As EventArgs) Handles BtnIncluirCausa.Click
        Try
            Dim objChamadoProblema As New UCLChamadoProblema
            Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa

            If DdlCausa.Items.Count = 0 OrElse DdlCausa.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione uma causa."
                Return
            End If

            If Not objChamadoProblemaCausa.Buscar(Session("GlEmpresa"), Session("SCodAtendimento"), DdlProblemaCausa.SelectedValue, DdlCausa.SelectedValue) Then
                objChamadoProblemaCausa.SetConteudo("empresa", Session("GlEmpresa"))
                objChamadoProblemaCausa.SetConteudo("cod_chamado", Session("SCodAtendimento"))
                objChamadoProblemaCausa.SetConteudo("seq_problema", DdlProblemaCausa.SelectedValue)
                objChamadoProblemaCausa.SetConteudo("cod_causa", DdlCausa.SelectedValue)
                objChamadoProblemaCausa.Incluir()
                LblErro.Text = "Causa incluída com sucesso."
                GridView2.DataBind()
            Else
                LblErro.Text = "Causa selecionada já incluída."
            End If

            objChamadoProblema.FillDropDown(DdlProblemaEfeito, Session("GlEmpresa"), Session("SCodAtendimento"))
            If DdlProblemaEfeito.Items.Count > 0 Then
                Call CarregaCausasEfeito()
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView2_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa
                Dim objChamadoProblema As New UCLChamadoProblema
                Dim args As String() = e.CommandArgument.ToString.Split(";")
                objChamadoProblemaCausa.Excluir(Session("GlEmpresa"), Session("SCodAtendimento"), args(0), args(1))
                GridView2.DataBind()

                objChamadoProblema.FillDropDown(DdlProblemaEfeito, Session("GlEmpresa"), Session("SCodAtendimento"))
                Call CarregaCausasEfeito()

                GridView3.DataBind()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub DdlProblema_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlProblema.SelectedIndexChanged
        Try
            Call CarregaCausas()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView3_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView3.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim objChamadoProblemaCausaEfeito As New UCLChamadoProblemaCausaEfeito
                Dim args As String() = e.CommandArgument.ToString.Split(";")
                objChamadoProblemaCausaEfeito.Excluir(Session("GlEmpresa"), Session("SCodAtendimento"), args(0), args(1), args(2))
                GridView3.DataBind()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub DdlProblemaEfeito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlProblemaEfeito.SelectedIndexChanged
        Try
            Call CarregaCausasEfeito()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub DdlCausaEfeito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlCausaEfeito.SelectedIndexChanged
        Try
            Call CarregaEfeitos()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnIncluirAcao_Click(sender As Object, e As EventArgs) Handles BtnIncluirAcao.Click
        Session("SAcaoChamadoAcao") = "INCLUIR"
        Response.Redirect("WFChamadoAcao.aspx")
    End Sub

    Private Sub GridView4_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView4.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim objChamadoAcao As New UCLChamadoAcao
                objChamadoAcao.Excluir(Session("GlEmpresa"), Session("SCodAtendimento"), e.CommandArgument)
                GridView4.DataBind()
            ElseIf e.CommandName = "ALTERAR" Then
                Session("SAcaoChamadoAcao") = e.CommandName
                Session("SChamadoSeqAcao") = e.CommandArgument
                Response.Redirect("WFChamadoAcao.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

End Class