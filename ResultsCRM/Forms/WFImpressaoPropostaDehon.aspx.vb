Partial Public Class WFImpressaoPropostaDehon
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
        Call CarregaFormulario()
        body1.Attributes.Remove("onload")
        BtnImprimir.Visible = True
    End Sub

    Private Sub CarregaFormulario()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Dim dt As DataTable

        objNegociacao.Empresa = Empresa
        objNegociacao.Estabelecimento = Estabelecimento
        objNegociacao.CodNegociacao = CodNegociacao
        dt = objNegociacao.DadosNegociacao()

        If dt.Rows.Count > 0 Then
            LblCodNegociacao.Text = CodNegociacao
            LblEnderecoEmpresa.Text = dt.Rows.Item(0).Item("endereco_empresa").ToString + " - " + dt.Rows.Item(0).Item("bairro_empresa").ToString
            LblSite.Text = dt.Rows.Item(0).Item("homepage").ToString
            LblCidadeEmpresa.Text = dt.Rows.Item(0).Item("cidade_empresa").ToString + "/" + dt.Rows.Item(0).Item("uf_empresa").ToString
            LblTelefoneEmpresa.Text = dt.Rows.Item(0).Item("fones_empresa").ToString
            LblEmailEmpresa.Text = dt.Rows.Item(0).Item("email_empresa").ToString
            LblDataCadastramento.Text = CDate(dt.Rows.Item(0).Item("data_cadastramento")).ToString("dd/MM/yyyy")

            'Mostra o representante... se não estiver preenchido mostra o agente de vendas
            LblVendedor.Text = dt.Rows.Item(0).Item("nome_representante").ToString
            If Not String.IsNullOrEmpty(LblVendedor.Text) Then
                LblVendedor.Text += " (" + dt.Rows.Item(0).Item("cod_representante").ToString + ")"
            Else
                LblVendedor.Text = dt.Rows.Item(0).Item("nome_agente_vendas").ToString
                If Not String.IsNullOrEmpty(LblVendedor.Text) Then
                    LblVendedor.Text += " (" + dt.Rows.Item(0).Item("cod_agente_vendas").ToString + ")"
                End If
            End If

            LblTransportadora.Text = dt.Rows.Item(0).Item("nome_transportadora").ToString
            If Not String.IsNullOrEmpty(LblTransportadora.Text) Then
                LblTransportadora.Text += " (" + dt.Rows.Item(0).Item("cod_transportadora").ToString + ")"
            End If
            LblRazaoSocial.Text = dt.Rows.Item(0).Item("nome_cliente").ToString
            LblEndereco.Text = dt.Rows.Item(0).Item("endereco_cliente").ToString
            LblCepCliente.Text = dt.Rows.Item(0).Item("cep_cliente").ToString
            LblCidade.Text = dt.Rows.Item(0).Item("cidade_cliente").ToString + "/" + dt.Rows.Item(0).Item("uf_cliente").ToString
            LblTelefone.Text = dt.Rows.Item(0).Item("telefone_cliente").ToString
            LblCNPJ.Text = dt.Rows.Item(0).Item("cnpj_cliente").ToString.MascaraCNPJ
            LblInscricaoEstadual.Text = dt.Rows.Item(0).Item("ie_cliente").ToString
            LblContato.Text = dt.Rows.Item(0).Item("contato_cliente").ToString
            LblEmailCliente.Text = dt.Rows.Item(0).Item("email_cliente").ToString
            LblCelularCliente.Text = dt.Rows.Item(0).Item("celular_cliente").ToString
            LblCabecalho.Text = ImprimeTexto(dt.Rows.Item(0).Item("cabecalho_proposta").ToString)
            LblRodape.Text = ImprimeTexto(dt.Rows.Item(0).Item("rodape_proposta").ToString)
            LblObservacao.Text = ImprimeTexto(dt.Rows.Item(0).Item("observacao").ToString)
            LblAux1.Text = dt.Rows.Item(0).Item("aux1").ToString
            LblAux1Label.Text = dt.Rows.Item(0).Item("aux1_label").ToString
            LblAux2.Text = dt.Rows.Item(0).Item("aux2").ToString
            LblAux2Label.Text = dt.Rows.Item(0).Item("aux2_label").ToString
            LblAux3.Text = dt.Rows.Item(0).Item("aux3").ToString.Replace("S", "Sim").Replace("N", "Não")
            LblAux3Label.Text = dt.Rows.Item(0).Item("aux3_label").ToString
            LblValorTotal.Text = CDbl(dt.Rows.Item(0).Item("valor_total")).ToString("N2")
            LblCondPagto.Text = dt.Rows.Item(0).Item("descricao_cond_pagto").ToString
            If Not String.IsNullOrEmpty(LblCondPagto.Text) Then
                LblCondPagto.Text += " (" + dt.Rows.Item(0).Item("cod_cond_pagto").ToString + ")"
            End If
        End If
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        Dim empresa As String = Request.QueryString.Item("eid")
        Dim estabelecimento As String = Request.QueryString.Item("sid")
        Dim negociacao As String = Request.QueryString.Item("nid")

        If e.Row.RowType = DataControlRowType.Header Then

            objNegociacaoItem.Empresa = empresa
            objNegociacaoItem.Estabelecimento = estabelecimento
            objNegociacaoItem.CodNegociacao = negociacao
            objNegociacaoItem.SeqItem = 9999
            objNegociacaoItem.Buscar()

            CType(e.Row.FindControl("LblAux1"), Label).Text = objNegociacaoItem.Aux1Label.Replace(":", "")
            CType(e.Row.FindControl("LblAux2"), Label).Text = objNegociacaoItem.Aux2Label.Replace(":", "")
            CType(e.Row.FindControl("LblAux3"), Label).Text = objNegociacaoItem.Aux3Label.Replace(":", "")
            CType(e.Row.FindControl("LblAux4"), Label).Text = objNegociacaoItem.Aux4Label.Replace(":", "")
            CType(e.Row.FindControl("LblAux5"), Label).Text = objNegociacaoItem.Aux5Label.Replace(":", "")
            CType(e.Row.FindControl("LblAux6"), Label).Text = objNegociacaoItem.Aux6Label.Replace(":", "")
            CType(e.Row.FindControl("LblAux7"), Label).Text = objNegociacaoItem.Aux7Label.Replace(":", "")
            CType(e.Row.FindControl("LblAux8"), Label).Text = objNegociacaoItem.Aux8Label.Replace(":", "")
            CType(e.Row.FindControl("LblAux9"), Label).Text = objNegociacaoItem.Aux9Label.Replace(":", "")
            CType(e.Row.FindControl("LblAux10"), Label).Text = objNegociacaoItem.Aux10Label.Replace(":", "")

        End If
    End Sub

    Protected Sub BtnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImprimir.Click
        BtnImprimir.Visible = False
        body1.Attributes.Add("onload", "window.print(); document.forms['form1'].submit(); ")
    End Sub
End Class