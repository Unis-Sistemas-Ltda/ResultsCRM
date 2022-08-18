Public Partial Class WFFaleConosco
    Inherits System.Web.UI.Page

    Private ReadOnly Property Empresa() As String
        Get
            Return 1
        End Get
    End Property

    Private ReadOnly Property Estabelecimento() As String
        Get
            Return 1
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjEstabelecimento As New UCLEstabelecimento

        TxtFone1.Attributes.Add("OnKeyPress", "return(formata(this,'(??)????-????',event))")
        TxtFone2.Attributes.Add("OnKeyPress", "return(formata(this,'(??)????-????',event))")

        Call CarregaVariaveisDeSessao()

        ObjEstabelecimento.CodEmpresa = Empresa
        ObjEstabelecimento.Estabelecimento = Estabelecimento
        ObjEstabelecimento.Buscar()

        If Not IsPostBack Then
            Call CarregaEstado(ObjEstabelecimento.CodPais)
            DdlEstado.SelectedValue = ObjEstabelecimento.CodEstado
            Call CarregaCidade(ObjEstabelecimento.CodPais)
            DdlCidade.SelectedValue = ObjEstabelecimento.CodCidade
        End If
    End Sub

    Private Sub CarregaSLA()
        Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaVariaveisDeSessao()
        Dim objUsuario As New UCLUsuario()
        Dim objEmpresa As New UCLEmpresa()
        Dim objParametrosCRM As New UCLParametrosCRM()

        objEmpresa.CodEmpresa = Empresa
        objEmpresa.Buscar()

        objParametrosCRM.Empresa = Empresa
        If Not objParametrosCRM.Buscar() Then
            LblErro.Text = "Parametros CRM não configurados."
            BtnEnviar.Enabled = False
            BtnLimparCampos.Enabled = False
        End If

        objUsuario.Usuario = objParametrosCRM.UsuarioPadrao
        objUsuario.Buscar()

        Session("GlCodUsuario") = objUsuario.CodUsuario
        Session("GlUsuario") = objParametrosCRM.UsuarioPadrao
        Session("GlEmpresa") = Empresa
        Session("GlRazaoSocial") = objEmpresa.RazaoSocial
        Session("GlEstabelecimento") = Estabelecimento
        Session("GlNomeUsuario") = objUsuario.NomeUsuario
        Session("GlSenhaUsuario") = objUsuario.Senha
        Session("GlClienteUnis") = objEmpresa.CodClienteUnis
        Session("GlConexao") = "CONTATO"

        LblCodCanalVendaPadrao.Text = objParametrosCRM.CodCanalVendasPadrao
        LblCodEtapaPadrao.Text = objParametrosCRM.CodEtapaPadrao
        LblCodFontePadrao.Text = objParametrosCRM.CodFontePadrao
        LblCodAcaoPadrao.Text = objParametrosCRM.CodAcaoPadrao

        'SetUidBD(objParametrosCRM.UsuarioPadrao)

    End Sub

    Protected Sub BtnLimparCampos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnLimparCampos.Click
        TxtNome.Text = ""
        TxtFone1.Text = ""
        TxtFone2.Text = ""
        TxtEmail.Text = ""
        TxtCNPJ.Text = ""
        TxtLogradouro.Text = ""
        TxtNumero.Text = ""
        TxtBairro.Text = ""
        TxtMensagem.Text = ""
        LblErro.Text = ""
        BtnEnviar.Enabled = True
    End Sub

    Protected Sub BtnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEnviar.Click
        Try
            If IsDigitacaoOk() Then
                Call Gravar()
                LblErro.Text = "Sua mensagem foi encaminhada com sucesso."
                BtnEnviar.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Gravar()
        Dim ObjEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim ObjEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim ObjNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Dim ObjNegociacaoFollowUp As New UCLFollowUpEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim codEmitente As String
        Dim cnpj As String
        Dim ObjEstabelecimento As New UCLEstabelecimento

        ObjEstabelecimento.CodEmpresa = Empresa
        ObjEstabelecimento.Estabelecimento = Estabelecimento
        ObjEstabelecimento.Buscar()

        If String.IsNullOrEmpty(TxtCNPJ.Text) Then TxtCNPJ.Text = "0"

        'Verifica se o emitente já está cadastrado (CNPJ)
        'Retorno da função abaixo: se CNPJ tem 3 dígitos ou menos (ou ainda se vazio) retorna cód. emitente cadastrado na tabela estabelecimento
        '                          se CNPJ está cadastrado retorna código do respectivo emitente
        '                          se CNPJ não está cadastrado retorna 0
        codEmitente = ObjEnderecoEmitente.GetCodEmitente(TxtCNPJ.Text)

        'Se não estiver cadastrado, inclui emitente e endereço
        If codEmitente = 0 Then
            ObjEmitente.CodEmitente = ObjEmitente.GetProximoCodigo
            ObjEmitente.DataCadastramento = Today()
            ObjEmitente.DataAlteracao = Today
            ObjEmitente.Funcionario = "N" 'Não
            ObjEmitente.Licenciador = "N" 'Não
            ObjEmitente.Natureza = "1" 'Indústria
            ObjEmitente.Nome = TxtNome.Text.GetValidInputContent
            ObjEmitente.NomeAbreviado = ObjEmitente.Nome
            ObjEmitente.OptantePeloSimples = "N" 'Não
            ObjEmitente.Procedencia = "N" 'Nacional
            ObjEmitente.Representante = "N" 'Não
            ObjEmitente.Situacao = "2" 'Ativo
            ObjEmitente.Tipo = "2" 'Cliente
            ObjEmitente.TpPessoa = "PJ" 'Pessoa Jurídica
            ObjEmitente.Transportador = "N" 'Não
            ObjEmitente.UsuarioCadastramento = Session("GlCodUsuario")
            ObjEmitente.UsuarioAlteracao = Session("GlCodUsuario")
            ObjEmitente.Incluir()

            ObjEnderecoEmitente.CodEmitente = ObjEmitente.CodEmitente
            ObjEnderecoEmitente.CNPJ = TxtCNPJ.Text.GetValidInputContent.Replace("/", "").Replace(".", "").Replace("-", "").Replace(" ", "")
            ObjEnderecoEmitente.Ativo = "S" 'Sim
            ObjEnderecoEmitente.Bairro = TxtBairro.Text.GetValidInputContent
            ObjEnderecoEmitente.CEP = ""
            ObjEnderecoEmitente.Cobranca = "S" 'Sim
            ObjEnderecoEmitente.CodCidade = DdlCidade.SelectedValue
            ObjEnderecoEmitente.CodEstado = DdlEstado.SelectedValue
            ObjEnderecoEmitente.CodPais = ObjEstabelecimento.CodPais
            ObjEnderecoEmitente.Fax = ""
            ObjEnderecoEmitente.Fone1 = TxtFone1.Text.GetValidInputContent
            ObjEnderecoEmitente.Fone2 = TxtFone2.Text.GetValidInputContent
            ObjEnderecoEmitente.IE = ""
            ObjEnderecoEmitente.IM = ""
            ObjEnderecoEmitente.Logradouro = TxtLogradouro.Text.GetValidInputContent
            ObjEnderecoEmitente.NomeAbreviado = TxtNome.Text.GetValidInputContent
            ObjEnderecoEmitente.Numero = TxtNumero.Text.GetValidInputContent
            ObjEnderecoEmitente.Preferencial = "S" 'Sim
            ObjEnderecoEmitente.RazaoSocial = TxtNome.Text.GetValidInputContent
            ObjEnderecoEmitente.Incluir()

            codEmitente = ObjEmitente.CodEmitente
            cnpj = ObjEnderecoEmitente.CNPJ

        Else

            cnpj = TxtCNPJ.Text.GetValidInputContent.Replace("/", "").Replace(".", "").Replace("-", "").Replace(" ", "")

        End If

        'Insere negociação
        ObjNegociacao.Empresa = Empresa
        ObjNegociacao.Estabelecimento = Estabelecimento
        ObjNegociacao.CodNegociacao = ObjNegociacao.GetProximoCodigo
        ObjNegociacao.CodCliente = codEmitente
        ObjNegociacao.CNPJ = cnpj
        ObjNegociacao.CodContato = "null"
        ObjNegociacao.CodCarteira = "null"
        ObjNegociacao.CodGestorConta = "null"
        ObjNegociacao.CodAgenteVenda = Session("GlCodUsuario")
        ObjNegociacao.CodCanalVendas = LblCodCanalVendaPadrao.Text
        ObjNegociacao.CodNaturOper = "null"
        ObjNegociacao.CodModelo = "null"
        ObjNegociacao.GerarPedido = "N"
        ObjNegociacao.ManterInformado = ""
        ObjNegociacao.CodEtapaNegociacao = LblCodEtapaPadrao.Text
        ObjNegociacao.ProbabilidadeSucesso = "null"
        ObjNegociacao.Prioridade = "M"
        ObjNegociacao.Receptividade = "M"
        ObjNegociacao.CodFormaPagto = "null"
        ObjNegociacao.CodCondPagto = "null"
        ObjNegociacao.CodFonteOrigemNegociacao = LblCodFontePadrao.Text
        ObjNegociacao.CodStatus = "null"
        ObjNegociacao.Moeda = "1"
        ObjNegociacao.Incluir()

        'Insere follow-up na negociação
        ObjNegociacaoFollowUp.Empresa = Empresa
        ObjNegociacaoFollowUp.Estabelecimento = Estabelecimento
        ObjNegociacaoFollowUp.CodEmitente = codEmitente
        ObjNegociacaoFollowUp.CodNegociacaoCliente = ObjNegociacao.CodNegociacao
        ObjNegociacaoFollowUp.SeqFollowUP = ObjNegociacaoFollowUp.GetProximoCodigo(Empresa, Estabelecimento, codEmitente)
        ObjNegociacaoFollowUp.CodAcao = LblCodAcaoPadrao.Text
        ObjNegociacaoFollowUp.CodUsuario = Session("GlCodUsuario")
        ObjNegociacaoFollowUp.DataFollowUp = System.DateTime.Now.Date
        ObjNegociacaoFollowUp.HoraFollowUp = System.DateTime.Now.TimeOfDay.ToString
        ObjNegociacaoFollowUp.CodContato = "null"
        ObjNegociacaoFollowUp.Assunto = "Contato feito através do site"
        ObjNegociacaoFollowUp.Descricao = TxtMensagem.Text.GetValidInputContent

        ObjNegociacaoFollowUp.Descricao += " [ Nome: " + TxtNome.Text.GetValidInputContent
        ObjNegociacaoFollowUp.Descricao += " / Fone: " + TxtFone1.Text.Trim + "." + TxtFone2.Text.Trim
        ObjNegociacaoFollowUp.Descricao += " / Email: " + TxtEmail.Text.GetValidInputContent
        ObjNegociacaoFollowUp.Descricao += " / End.: " + TxtLogradouro.Text.GetValidInputContent.Trim + " " + TxtNumero.Text + " - " + TxtBairro.Text.Trim
        ObjNegociacaoFollowUp.Descricao += " - " + DdlCidade.SelectedItem.Text + "/" + DdlEstado.SelectedItem.Text + " ]"

        ObjNegociacaoFollowUp.Incluir()

    End Sub

    Protected Sub DdlEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlEstado.SelectedIndexChanged
        Dim ObjEstabelecimento As New UCLEstabelecimento
        ObjEstabelecimento.CodEmpresa = Empresa
        ObjEstabelecimento.Estabelecimento = Estabelecimento
        ObjEstabelecimento.Buscar()
        Call CarregaCidade(ObjEstabelecimento.CodPais)
    End Sub

    Public Sub CarregaCidade(ByVal CodPais As String)
        Dim objCidade As New UCLCidade
        objCidade.CodPais = CodPais
        objCidade.CodEstado = DdlEstado.SelectedValue
        objCidade.FillDropDown(DdlCidade, True, "( Escolha a cidade )")
        DdlCidade.SelectedValue = "0"
    End Sub

    Public Sub CarregaEstado(ByVal CodPais As String)
        Dim ObjEstado As New UCLEstado
        ObjEstado.CodPais = CodPais
        ObjEstado.FillDropDown(DdlEstado, False, "", UCLEstado.Tipo.NomeEstado)
    End Sub

    Public Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtNome.Text.Trim) Then
            LblErro.Text += "Informe o nome.<br>"
        End If

        If String.IsNullOrEmpty(TxtFone1.Text.Trim) Then
            LblErro.Text += "Informe o telefone para contato.<br>"
        End If

        If Not String.IsNullOrEmpty(TxtCNPJ.Text.Trim) Then
            If Not TxtCNPJ.Text.IsValidCNPJ And Not TxtCNPJ.Text.IsValidCPF Then
                LblErro.Text += "Informe corretamente o CNPJ/CPF ou deixe-o em branco.<br>"
            End If
        End If

        If String.IsNullOrEmpty(TxtEmail.Text.Trim) Then
            LblErro.Text += "Informe o e-mail.<br>"
        Else
            If Not TxtEmail.Text.IsValidEmail Then
                LblErro.Text += "Informe um endereço de e-mail válido.<br>"
            End If
        End If

        Return LblErro.Text = ""

    End Function

End Class