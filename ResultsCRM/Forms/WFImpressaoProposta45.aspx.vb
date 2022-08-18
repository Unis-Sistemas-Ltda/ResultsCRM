Partial Public Class WFImpressaoProposta45
    Inherits System.Web.UI.Page

    Private ReadOnly Property Empresa()
        Get
            Return Request.QueryString.Item("eid")
        End Get
    End Property

    Private ReadOnly Property Estabelecimento()
        Get
            Return Request.QueryString.Item("sid")
        End Get
    End Property

    Private ReadOnly Property CodNegociacao()
        Get
            Return Request.QueryString.Item("nid")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SqlDataSource3.Select(DataSourceSelectArguments.Empty)
        SqlDataSource3.DataBind()
        GridView2.DataBind()
        Call CarregaFormulario()
    End Sub

    Private Sub CarregaFormulario()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Dim dt As DataTable

        objNegociacao.Empresa = Empresa
        objNegociacao.Estabelecimento = Estabelecimento
        objNegociacao.CodNegociacao = CodNegociacao
        dt = objNegociacao.DadosNegociacao()

        If dt.Rows.Count > 0 Then
            LblCodNegociacaoCliente.Text = CodNegociacao
            LblDataNegociacao.Text = CDate(dt.Rows.Item(0).Item("data_cadastramento")).ToString("dd/MM/yyyy")
            If Not IsDBNull(dt.Rows.Item(0).Item("validade_negociacao")) Then
                LblValidade.Text = CDate(dt.Rows.Item(0).Item("validade_negociacao")).ToString("dd/MM/yyyy")
            Else
                LblValidade.Text = ""
            End If
            LblRazaoSocialEmpresa.Text = dt.Rows.Item(0).Item("nome_empresa").ToString
            LblEnderecoEmpresa.Text = dt.Rows.Item(0).Item("endereco_empresa").ToString
            LblCidadeEmpresa.Text = dt.Rows.Item(0).Item("cidade_empresa").ToString + "/" + dt.Rows.Item(0).Item("uf_empresa").ToString
            LblTelefoneEmpresa.Text = dt.Rows.Item(0).Item("fones_empresa").ToString
            LblCNPJEmpresa.Text = dt.Rows.Item(0).Item("cnpj_empresa").ToString.MascaraCNPJ
            LblRazaoSocial.Text = dt.Rows.Item(0).Item("nome_cliente").ToString
            LblEndereco.Text = dt.Rows.Item(0).Item("endereco_cliente").ToString
            LblCidade.Text = dt.Rows.Item(0).Item("cidade_cliente").ToString + "/" + dt.Rows.Item(0).Item("uf_cliente").ToString
            LblTelefone.Text = dt.Rows.Item(0).Item("telefone_cliente").ToString
            LblCNPJ.Text = dt.Rows.Item(0).Item("cnpj_cliente").ToString.MascaraCNPJ
            LblInscricaoEstadual.Text = dt.Rows.Item(0).Item("ie_cliente").ToString
            LblContato.Text = dt.Rows.Item(0).Item("contato_cliente").ToString
            LblEmitenteEmail.Text = dt.Rows.Item(0).Item("email_cadastro_cliente").ToString
            LblCabecalho.Text = ImprimeTexto(dt.Rows.Item(0).Item("cabecalho_proposta").ToString)
            LblRodape.Text = ImprimeTexto(dt.Rows.Item(0).Item("rodape_proposta").ToString)
            LblCondicaoPagamento.Text = dt.Rows.Item(0).Item("descricao_cond_pagto").ToString
            LblFormaPagamento.Text = dt.Rows.Item(0).Item("descricao_forma_pagamento").ToString
            LblObservacao.Text = "<br/>" + ImprimeTexto(dt.Rows.Item(0).Item("observacao").ToString)
            LblNomeAgenteVendas.Text = dt.Rows.Item(0).Item("nome_agente_vendas").ToString
            LblEmailAgenteVendas.Text = dt.Rows.Item(0).Item("email_agente_venda").ToString
            LblSkypeAgenteVendas.Text = dt.Rows.Item(0).Item("skype_agente_venda").ToString
        End If

    End Sub

    Public Sub GridView1_DataBound(sender As Object, e As System.EventArgs)
        Dim this As GridView = sender
        Dim total As Double = 0
        If this.Rows.Count > 0 Then
            For Each row As GridViewRow In this.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    total += CDbl(CType(row.FindControl("LblValorMercadoria"), Label).Text)
                End If
            Next
        End If
        CType(this.FooterRow.FindControl("LblTotal"), Label).Text = total.ToString("F2")
    End Sub
End Class