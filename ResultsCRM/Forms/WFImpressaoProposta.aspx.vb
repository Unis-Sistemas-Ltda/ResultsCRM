Public Partial Class WFImpressaoProposta
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
    End Sub

    Private Sub CarregaFormulario()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Dim dt As DataTable

        objNegociacao.Empresa = Empresa
        objNegociacao.Estabelecimento = Estabelecimento
        objNegociacao.CodNegociacao = CodNegociacao
        dt = objNegociacao.DadosNegociacao()

        If dt.Rows.Count > 0 Then
            LblRazaoSocialEmpresa.Text = dt.Rows.Item(0).Item("nome_empresa").ToString
            LblEnderecoEmpresa.Text = dt.Rows.Item(0).Item("endereco_empresa").ToString
            LblSite.Text = dt.Rows.Item(0).Item("homepage").ToString
            LblMensagem.Text = dt.Rows.Item(0).Item("informacao").ToString
            LblCidadeEmpresa.Text = dt.Rows.Item(0).Item("cidade_empresa").ToString + "/" + dt.Rows.Item(0).Item("uf_empresa").ToString
            LblTelefoneEmpresa.Text = dt.Rows.Item(0).Item("fones_empresa").ToString
            LblCNPJEmpresa.Text = dt.Rows.Item(0).Item("cnpj_empresa").ToString.MascaraCNPJ
            LblInscricaoEstadualEmpresa.Text = dt.Rows.Item(0).Item("ie_empresa").ToString
            LblRazaoSocial.Text = dt.Rows.Item(0).Item("nome_cliente").ToString
            LblEndereco.Text = dt.Rows.Item(0).Item("endereco_cliente").ToString
            LblCidade.Text = dt.Rows.Item(0).Item("cidade_cliente").ToString + "/" + dt.Rows.Item(0).Item("uf_cliente").ToString
            LblTelefone.Text = dt.Rows.Item(0).Item("telefone_cliente").ToString
            LblCNPJ.Text = dt.Rows.Item(0).Item("cnpj_cliente").ToString.MascaraCNPJ
            LblInscricaoEstadual.Text = dt.Rows.Item(0).Item("ie_cliente").ToString
            LblContato.Text = dt.Rows.Item(0).Item("contato_cliente").ToString
            LblCabecalho.Text = ImprimeTexto(dt.Rows.Item(0).Item("cabecalho_proposta").ToString)
            LblRodape.Text = ImprimeTexto(dt.Rows.Item(0).Item("rodape_proposta").ToString)
            LblValorTotal.Text = CDbl(dt.Rows.Item(0).Item("valor_total")).ToString("N2")
        End If
    End Sub

End Class