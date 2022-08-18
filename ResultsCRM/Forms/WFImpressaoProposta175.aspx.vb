Partial Public Class WFImpressaoProposta175
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
        SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        SqlDataSource2.DataBind()
        GridView1.DataBind()
        Call CarregaFormulario()
    End Sub

    Private Sub CarregaFormulario()
        Dim objNegociacao As New UCLNegociacao(StrConexao)
        Dim dt As DataTable
        Dim valor As Double
        Dim codItem As String
        Dim TotalValorMercadoria As Double = 0
        Dim TotalIPI As Double = 0
        Dim ValorIPI As Double = 0
        Dim TotalST As Double = 0
        Dim ValorST As Double = 0
        Dim ValorTotal As Double = 0
        Dim TotalDespesas As Double = 0
        Dim TipoFrete As String = ""

        objNegociacao.Empresa = Empresa
        objNegociacao.Estabelecimento = Estabelecimento
        objNegociacao.CodNegociacao = CodNegociacao
        dt = objNegociacao.DadosNegociacao()

        If dt.Rows.Count > 0 Then
            LblCodNegociacaoCliente.Text = CodNegociacao.ToString.PadLeft(6, "0")
            LblDataNegociacao.Text = CDate(dt.Rows.Item(0).Item("data_cadastramento")).ToString("dd/MM/yyyy")
            If Not IsDBNull(dt.Rows.Item(0).Item("validade_negociacao")) Then
                LblValidade.Text = CDate(dt.Rows.Item(0).Item("validade_negociacao")).ToString("dd/MM/yyyy")
            Else
                LblValidade.Text = ""
            End If
            LblRazaoSocialEmpresa.Text = dt.Rows.Item(0).Item("nome_empresa").ToString
            LblEnderecoEmpresa.Text = dt.Rows.Item(0).Item("endereco_empresa").ToString + " CEP: " + dt.Rows.Item(0).Item("cep_empresa").ToString
            LblCidadeEmpresa.Text = dt.Rows.Item(0).Item("bairro_empresa").ToString + " - " + dt.Rows.Item(0).Item("cidade_empresa").ToString + "/" + dt.Rows.Item(0).Item("uf_empresa").ToString
            LblTelefoneEmpresa.Text = dt.Rows.Item(0).Item("fones_empresa").ToString + " - " + dt.Rows.Item(0).Item("email_empresa").ToString
            LblCNPJEmpresa.Text = dt.Rows.Item(0).Item("cnpj_empresa").ToString.MascaraCNPJ
            LblRazaoSocial.Text = dt.Rows.Item(0).Item("nome_cliente").ToString
            LblEndereco.Text = dt.Rows.Item(0).Item("endereco_cliente").ToString
            LblCidade.Text = dt.Rows.Item(0).Item("cidade_cliente").ToString + "/" + dt.Rows.Item(0).Item("uf_cliente").ToString
            LblTelefone.Text = dt.Rows.Item(0).Item("telefone_cliente").ToString
            LblCNPJ.Text = dt.Rows.Item(0).Item("cnpj_cliente").ToString.MascaraCNPJ
            LblInscricaoEstadual.Text = dt.Rows.Item(0).Item("ie_cliente").ToString
            LblContato.Text = dt.Rows.Item(0).Item("contato_cliente").ToString
            LblContatoEmail.Text = dt.Rows.Item(0).Item("email_cliente").ToString
            LblCabecalho.Text = ImprimeTexto(dt.Rows.Item(0).Item("cabecalho_proposta").ToString)
            LblRodape.Text = ImprimeTexto(dt.Rows.Item(0).Item("rodape_proposta").ToString)
            LblCondicaoPagamento.Text = dt.Rows.Item(0).Item("descricao_cond_pagto").ToString
            LblFormaPagamento.Text = dt.Rows.Item(0).Item("descricao_forma_pagamento").ToString
            LblObservacao.Text = "<br/>" + ImprimeTexto(dt.Rows.Item(0).Item("observacao").ToString)
            LblNomeAgenteVendas.Text = dt.Rows.Item(0).Item("nome_agente_vendas").ToString
            LlbRepresentante.Text = dt.Rows.Item(0).Item("nome_representante").ToString + "(" + dt.Rows.Item(0).Item("cod_representante").ToString + ")"
            LblTransportador.Text = dt.Rows.Item(0).Item("nome_transportadora").ToString + "(" + dt.Rows.Item(0).Item("cod_transportadora").ToString + ")"
            TotalDespesas = CDbl(dt.Rows.Item(0).Item("total_despesas"))
            LblTotalDespesas.Text = TotalDespesas.ToString("N2")

            TipoFrete = dt.Rows.Item(0).Item("tipo_frete").ToString

            If TipoFrete = "1" Then
                lblFrete.Text = "CIF"
            ElseIf TipoFrete = "2" Then
                lblFrete.Text = "FOB"
            End If

        End If

        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                codItem = CType(row.FindControl("LblCodItem"), Label).Text
                valor = CDbl(CType(row.FindControl("LblValorMercadoria"), Label).Text)
                ValorIPI = CDbl(CType(row.FindControl("LblValorIPI"), Label).Text)
                ValorST = CDbl(CType(row.FindControl("LblICMSST"), Label).Text)
                TotalValorMercadoria += valor
                TotalIPI += ValorIPI
                TotalST += ValorST
            End If
        Next

        If TotalValorMercadoria > 0 Then
            LblTotalMateriais.Text = TotalValorMercadoria.ToString("N2")
        End If

        If TotalIPI > 0 Then
            LblTotalIPI.Text = TotalIPI.ToString("N2")
        End If

        If TotalST > 0 Then
            LblTotalST.Text = TotalST.ToString("N2")
        End If

        ValorTotal = TotalValorMercadoria + TotalIPI + TotalST + TotalDespesas

        If ValorTotal > 0 Then
            LblTotal.Text = ValorTotal.ToString("N2")
        End If

    End Sub

End Class