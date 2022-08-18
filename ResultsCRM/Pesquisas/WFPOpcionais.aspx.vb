Partial Public Class WFPOpcionais
    Inherits System.Web.UI.Page
    Dim Comando As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                LblCodItem.Text = Session("SCodItemPesquisado")
                LblDescricaoItem.Text = DescricaoItem(LblCodItem.Text)
                MultiViewExpanse.ActiveViewIndex = 0

                If GridView2.Rows.Count > 0 Then
                    CType(GridView2.HeaderRow.FindControl("LblHeader"), Label).Text = "Marque os itens"
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "SELECIONAR" Then
                LblCodItemGrupo.Text = e.CommandArgument.ToString.Trim.Substring(0, e.CommandArgument.ToString.Trim.IndexOf(";"))
                LblDescricaoItemGrupo.Text = DescricaoItem(LblCodItemGrupo.Text)

                LblSeqEstrutura.Text = e.CommandArgument.ToString.Trim.Substring(e.CommandArgument.ToString.Trim.IndexOf(";") + 1)

                SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                SqlDataSource2.DataBind()
                GridView2.DataBind()

                If GridView2.Rows.Count > 0 Then
                    CType(GridView2.HeaderRow.FindControl("LblHeader"), Label).Text = "Marque os itens - " + LblDescricaoItemGrupo.Text + " (" + LblCodItemGrupo.Text + ")"
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnOkay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOkay.Click
        Try
            MultiViewExpanse.ActiveViewIndex = 0
            ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)

        Catch ex As Exception

            ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onError();", True)
            MultiViewExpanse.ActiveViewIndex = 0
        End Try
    End Sub

    Private Function DescricaoItem(ByVal CodItem As String) As String
        Try
            Dim ObjItem As New UCLItem
            ObjItem.CodItem = CodItem
            ObjItem.Buscar()
            Return ObjItem.Descricao
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Enum TipoOperacao As Integer
        Inclusao = 1
        Alteracao = 2
        Exclusao = 3
    End Enum

    Private Sub ProcessaAlteracoes(sender As Object)
        Try
            Dim RowIndex As Long
            Dim seqItemEstrutura As Long
            Dim cbx As CheckBox = Nothing
            Dim txt As TextBox = Nothing
            Dim CbxSelecao As New CheckBox
            Dim txtQuantidade As New TextBox
            Dim TxtPrecoUnitario As New TextBox
            Dim codComponenteAlternativo As String = ""
            Dim ObjNegociacaoClienteItemEstrutura As New UCLNegociacaoItemEstrutura(StrConexao) ' StrConexaoUsuario(Session("GlUsuario")))
            Dim valorFixo As Long = 0
            Dim TipoValor As Long = 0
            Dim TipoSoma As Long = 0
            Dim operacao As TipoOperacao

            LblErro.Text = ""

            If TypeOf sender Is CheckBox Then
                cbx = CType(sender, CheckBox)
                RowIndex = CType(cbx.Parent.Parent, GridViewRow).RowIndex
            ElseIf TypeOf sender Is TextBox Then
                txt = CType(sender, TextBox)
                RowIndex = CType(txt.Parent.Parent, GridViewRow).RowIndex
            End If

            For Each row As GridViewRow In GridView2.Rows
                If row.RowIndex = RowIndex Then
                    codComponenteAlternativo = CType(row.FindControl("LblCodigo"), Label).Text
                    If TypeOf sender Is CheckBox Then
                        If cbx.ID = "CbxSelecao" Then
                            CbxSelecao = cbx
                            TxtPrecoUnitario = row.FindControl("TxtPrecoUnitario")
                            txtQuantidade = row.FindControl("TxtQuantidade")
                        End If
                    ElseIf TypeOf sender Is TextBox Then
                        If txt.ID = "TxtPrecoUnitario" Then
                            TxtPrecoUnitario = sender
                            txtQuantidade = row.FindControl("TxtQuantidade")
                            CbxSelecao = row.FindControl("CbxSelecao")
                        ElseIf txt.ID = "TxtQuantidade" Then
                            TxtPrecoUnitario = row.FindControl("TxtPrecoUnitario")
                            txtQuantidade = sender
                            CbxSelecao = row.FindControl("CbxSelecao")
                        End If
                    End If
                    Exit For
                End If
            Next

            If TypeOf sender Is CheckBox Then
                If cbx.Checked Then
                    operacao = TipoOperacao.Inclusao
                Else
                    operacao = TipoOperacao.Exclusao
                End If
            ElseIf TypeOf sender Is TextBox Then
                If CbxSelecao.Checked Then
                    operacao = TipoOperacao.Alteracao
                Else
                    operacao = TipoOperacao.Inclusao
                End If
            End If

            ObjNegociacaoClienteItemEstrutura.Empresa = Session("GlEmpresa")
            ObjNegociacaoClienteItemEstrutura.Estabelecimento = Session("GlEstabelecimento")
            ObjNegociacaoClienteItemEstrutura.CodNegociacaoCliente = Session("SCodNegociacao")
            ObjNegociacaoClienteItemEstrutura.SeqItem = Session("SSeqItemNegociacao")
            ObjNegociacaoClienteItemEstrutura.CodItem = LblCodItem.Text
            ObjNegociacaoClienteItemEstrutura.SeqEstrutura = LblSeqEstrutura.Text
            ObjNegociacaoClienteItemEstrutura.CodComponenteAlternativo = codComponenteAlternativo
            ObjNegociacaoClienteItemEstrutura.ReferenciaComponenteAlternativo = ""

            seqItemEstrutura = ObjNegociacaoClienteItemEstrutura.GetSeqItemEstrutura(ObjNegociacaoClienteItemEstrutura.Empresa, ObjNegociacaoClienteItemEstrutura.Estabelecimento, ObjNegociacaoClienteItemEstrutura.CodNegociacaoCliente, ObjNegociacaoClienteItemEstrutura.SeqItem, ObjNegociacaoClienteItemEstrutura.SeqEstrutura, ObjNegociacaoClienteItemEstrutura.CodComponenteAlternativo, ObjNegociacaoClienteItemEstrutura.ReferenciaComponenteAlternativo)

            If seqItemEstrutura > 0 AndAlso (operacao = TipoOperacao.Exclusao OrElse operacao = TipoOperacao.Alteracao) Then
                ObjNegociacaoClienteItemEstrutura.SeqItemEstrutura = seqItemEstrutura
                ObjNegociacaoClienteItemEstrutura.Excluir()
            End If

            If operacao = TipoOperacao.Inclusao OrElse operacao = TipoOperacao.Alteracao Then
                If Not IsNumeric(TxtPrecoUnitario.Text) Then
                    TxtPrecoUnitario.Text = "0"
                End If
                If Not IsNumeric(txtQuantidade.Text) Then
                    txtQuantidade.Text = "1"
                End If
                If ObjNegociacaoClienteItemEstrutura.PermiteMultiplo(ObjNegociacaoClienteItemEstrutura.CodItem, ObjNegociacaoClienteItemEstrutura.SeqEstrutura) OrElse ObjNegociacaoClienteItemEstrutura.QuantidadeItensGrupoConfiguracao() = 0 Then
                    seqItemEstrutura = ObjNegociacaoClienteItemEstrutura.GetProximoCodigo()
                    ObjNegociacaoClienteItemEstrutura.SeqItemEstrutura = seqItemEstrutura
                    ObjNegociacaoClienteItemEstrutura.PrecoUnitario = CDbl(TxtPrecoUnitario.Text)
                    ObjNegociacaoClienteItemEstrutura.Quantidade = CDbl(txtQuantidade.Text)
                    ObjNegociacaoClienteItemEstrutura.QuantidadeTotal = ObjNegociacaoClienteItemEstrutura.Quantidade
                    ObjNegociacaoClienteItemEstrutura.PrecoTotal = ObjNegociacaoClienteItemEstrutura.Quantidade * ObjNegociacaoClienteItemEstrutura.PrecoUnitario
                    ObjNegociacaoClienteItemEstrutura.CarregaCamposEstruturaCompAlternativos(ObjNegociacaoClienteItemEstrutura.CodItem, ObjNegociacaoClienteItemEstrutura.SeqEstrutura, ObjNegociacaoClienteItemEstrutura.CodComponenteAlternativo, valorFixo, TipoValor, TipoSoma)
                    ObjNegociacaoClienteItemEstrutura.TipoValor = TipoValor
                    ObjNegociacaoClienteItemEstrutura.ValorFixo = valorFixo
                    ObjNegociacaoClienteItemEstrutura.TipoSoma = TipoSoma
                    ObjNegociacaoClienteItemEstrutura.Incluir()
                Else
                    If cbx IsNot Nothing Then
                        cbx.Checked = False
                    End If
                    Throw New Exception("Para o Grupo de Configuração selecionado é permitido incluir somente um componente.")
                End If

            End If

            SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            SqlDataSource2.DataBind()
            GridView2.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        Try
            Call ProcessaAlteracoes(sender)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub


    Protected Sub TxtQuantidade_TextChanged(sender As Object, e As EventArgs)
        Try
            Call ProcessaAlteracoes(sender)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub TxtPrecoUnitario_TextChanged(sender As Object, e As EventArgs)
        Try
            Call ProcessaAlteracoes(sender)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles BtnFiltrar.Click
        SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        SqlDataSource2.DataBind()
        GridView2.DataBind()
    End Sub

End Class