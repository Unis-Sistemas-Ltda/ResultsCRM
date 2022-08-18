Partial Public Class WUCClienteCNPJ
    Inherits System.Web.UI.UserControl

    Private _CodEmitente As String
    Private _Embeeded As String
    Private _CNPJ As String
    Private _Acao As String
    Private _VarCodEmitente As String
    Private _VarCodEmitentePesquisado As String
    Private _VarAlterouCodCliente As String
    Private _VarRecarregaDdlContatos As String
    Private _VarCodContatoNegociacao As String
    Private _VarCNPJEmitentePesquisado As String
    Private _VarCodEmitenteNegociacao As String

    Public Property Embeeded() As Boolean
        Get
            Return _Embeeded
        End Get
        Set(ByVal value As Boolean)
            _Embeeded = value
        End Set
    End Property

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
        End Set
    End Property

    Public Property CNPJ() As String
        Get
            Return _CNPJ
        End Get
        Set(ByVal value As String)
            _CNPJ = value
        End Set
    End Property

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property VarCodEmitente() As String
        Get
            Return _VarCodEmitente
        End Get
        Set(ByVal value As String)
            _VarCodEmitente = value
        End Set
    End Property

    Public Property VarCodEmitentePesquisado() As String
        Get
            Return _VarCodEmitentePesquisado
        End Get
        Set(ByVal value As String)
            _VarCodEmitentePesquisado = value
        End Set
    End Property

    Public Property VarCodEmitenteNegociacao() As String
        Get
            Return _VarCodEmitenteNegociacao
        End Get
        Set(ByVal value As String)
            _VarCodEmitenteNegociacao = value
        End Set
    End Property

    Public Property VarAlterouCodCliente() As String
        Get
            Return _VarAlterouCodCliente
        End Get
        Set(ByVal value As String)
            _VarAlterouCodCliente = value
        End Set
    End Property

    Public Property VarRecarregaDdlContatos() As String
        Get
            Return _VarRecarregaDdlContatos
        End Get
        Set(ByVal value As String)
            _VarRecarregaDdlContatos = value
        End Set
    End Property

    Public Property VarCodContatoNegociacao() As String
        Get
            Return _VarCodContatoNegociacao
        End Get
        Set(ByVal value As String)
            _VarCodContatoNegociacao = value
        End Set
    End Property

    Public Property VarCNPJEmitentePesquisado() As String
        Get
            Return _VarCNPJEmitentePesquisado
        End Get
        Set(ByVal value As String)
            _VarCNPJEmitentePesquisado = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

        'Verifica se é PF ou PJ para tratar o campo
        objEmitente.CodEmitente = CodEmitente
        objEmitente.Buscar()
        If objEmitente.TpPessoa = "PF" Then
            TxtCNPJ.Tipo = TextBoxCNPJCPF.TipoEdicao.CPF
            LblCNPJCPF1.Text = "CPF"
            LblCNPJCPF2.Text = "CPF"
            LblRazaoSocial.Text = "Nome"
            LblFantasia.Text = "Apelido"
        Else
            TxtCNPJ.Tipo = TextBoxCNPJCPF.TipoEdicao.CNPJ
            LblCNPJCPF1.Text = "CNPJ"
            LblCNPJCPF2.Text = "CNPJ"
            LblRazaoSocial.Text = "Razão Social"
            LblFantasia.Text = "Fantasia"
        End If
        TxtCNPJ.AutoPostBack = True
        TxtCNPJ.DataBind()
        '----

        If Not IsPostBack Then
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
                Call CarregaRazaoSocialEFantasia()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaRazaoSocialEFantasia()
                Call CarregaPais()
            End If
        Else
            'Grava CNPJ alterado em label auxiliar
            If TxtCNPJ.Text <> CNPJ Then
                LblCNPJNovo.Text = TxtCNPJ.Text
            Else
                LblCNPJNovo.Text = ""
            End If
        End If

        If Embeeded Then
            BtnContinuar.Visible = True
            BtnGravar.Visible = False
        Else
            BtnContinuar.Visible = False
            BtnGravar.Visible = True
        End If

        If Session("GlBloquearCadastroEmitenteRepresentante") = "S" Then
            BtnContinuar.Visible = False
            BtnGravar.Visible = False
        End If



    End Sub

    Private Sub CarregaFormulario()
        Dim ObjEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim ObjUsuario As New UCLUsuario

        ObjEnderecoEmitente.CodEmitente = CodEmitente
        ObjEnderecoEmitente.CNPJ = CNPJ
        ObjEnderecoEmitente.Buscar()

        TxtCNPJ.Text = ObjEnderecoEmitente.CNPJ
        TxtNome.Text = ObjEnderecoEmitente.RazaoSocial
        TxtNomeAbreviado.Text = ObjEnderecoEmitente.NomeAbreviado
        ChkPreferencial.Checked = ObjEnderecoEmitente.Preferencial.ToString.Replace("S", "True").Replace("N", "False")
        ChkAtivo.Checked = ObjEnderecoEmitente.Ativo.ToString.Replace("S", "True").Replace("N", "False")
        ChkCobranca.Checked = ObjEnderecoEmitente.Cobranca.ToString.Replace("S", "True").Replace("N", "False")
        TxtLogradouro.Text = ObjEnderecoEmitente.Logradouro
        TxtNumero.Text = ObjEnderecoEmitente.Numero
        TxtCEP.Text = ObjEnderecoEmitente.CEP
        TxtFone1.Text = ObjEnderecoEmitente.Fone1
        TxtFone2.Text = ObjEnderecoEmitente.Fone2
        TxtFax.Text = ObjEnderecoEmitente.Fax
        TxtBairro.Text = ObjEnderecoEmitente.Bairro
        TxtIE.Text = ObjEnderecoEmitente.IE
        TxtIM.Text = ObjEnderecoEmitente.IM
        TxtEmail.Text = ObjEnderecoEmitente.Email
        TxtEmailBoleto.Text = ObjEnderecoEmitente.EmailBoleto
        TxtEmailNFe.Text = ObjEnderecoEmitente.EmailXmlNfe

        'Kilian 09/09/2020
        DdlSituacao.SelectedValue = ObjEnderecoEmitente.Situacao

        Call CarregaPais()
        If DdlPais.Items.FindByValue(ObjEnderecoEmitente.CodPais) IsNot Nothing Then
            DdlPais.SelectedValue = ObjEnderecoEmitente.CodPais

            Call CarregaEstado()
            If DdlEstado.Items.FindByValue(ObjEnderecoEmitente.CodEstado) IsNot Nothing Then
                DdlEstado.SelectedValue = ObjEnderecoEmitente.CodEstado

                Call CarregaCidade()
                If DdlCidade.Items.FindByValue(ObjEnderecoEmitente.CodCidade) IsNot Nothing Then
                    DdlCidade.SelectedValue = ObjEnderecoEmitente.CodCidade
                Else
                    DdlCidade.SelectedValue = "0"
                End If
            Else
                DdlEstado.SelectedValue = "0"
            End If
        End If

        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Regional Then
            LblRazaoSocial.Enabled = False
            TxtNome.Enabled = False
            TxtNomeAbreviado.Enabled = False
            ChkPreferencial.Enabled = False
            ChkAtivo.Enabled = False
            ChkCobranca.Enabled = False
            TxtLogradouro.Enabled = False
            TxtNumero.Enabled = False
            TxtCEP.Enabled = False
            TxtBairro.Enabled = False
            TxtIE.Enabled = False
            TxtIM.Enabled = False
            DdlPais.Enabled = False
            DdlCidade.Enabled = False
            DdlEstado.Enabled = False
        End If

    End Sub

    Public Sub CarregaCidade()
        Dim objCidade As New UCLCidade

        objCidade.CodPais = DdlPais.SelectedValue
        objCidade.CodEstado = DdlEstado.SelectedValue
        objCidade.FillDropDown(DdlCidade, True, "")

    End Sub

    Public Sub CarregaEstado()
        Dim ObjEstado As New UCLEstado

        ObjEstado.CodPais = DdlPais.SelectedValue
        ObjEstado.FillDropDown(DdlEstado, True, "", UCLEstado.Tipo.Sigla)

    End Sub

    Public Sub CarregaPais()
        Dim ObjPais As New UCLPais

        ObjPais.FillDropDown(DdlPais, True, "")
    End Sub

    Protected Sub DdlPais_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlPais.SelectedIndexChanged
        Call CarregaEstado()
        DdlEstado.SelectedValue = "0"
        Call CarregaCidade()
        DdlEstado.SelectedValue = "0"
    End Sub

    Protected Sub DdlEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlEstado.SelectedIndexChanged
        Call CarregaCidade()
        DdlCidade.SelectedValue = "0"
    End Sub

    Private Function Gravar() As Boolean
        Dim ObjEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjEnderecoEmitente.CodEmitente = CodEmitente
                    ObjEnderecoEmitente.CNPJ = CNPJ
                    ObjEnderecoEmitente.Buscar()
                    ObjEnderecoEmitente = CarregaObjeto(ObjEnderecoEmitente)
                    ObjEnderecoEmitente.Situacao = DdlSituacao.SelectedValue
                    ObjEnderecoEmitente.Alterar()

                    If Not Embeeded Then
                        Response.Redirect("WGClienteCNPJ.aspx")
                        BtnContinuar.Visible = False
                    Else
                        LblErro.Text = "Dados foram salvos com sucesso."
                        BtnContinuar.Visible = True
                    End If

                ElseIf Acao = "INCLUIR" Then
                    ObjEnderecoEmitente.CodEmitente = CodEmitente
                    ObjEnderecoEmitente.CNPJ = TxtCNPJ.Text.Replace("-", "").Replace(".", "").Replace("/", "").Replace(" ", "")
                    ObjEnderecoEmitente.Buscar()
                    ObjEnderecoEmitente = CarregaObjeto(ObjEnderecoEmitente)
                    ObjEnderecoEmitente.Incluir()
                    Session(VarCNPJEmitentePesquisado) = ObjEnderecoEmitente.CNPJ
                    Session("SAcaoCNPJ") = "ALTERAR"
                    If Not Embeeded Then
                        Response.Redirect("WGClienteCNPJ.aspx")
                        BtnContinuar.Visible = False
                    Else
                        LblErro.Text = "Dados foram salvos com sucesso."
                        BtnContinuar.Visible = True
                    End If
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Call Gravar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtCNPJ.Text) Then
            LblErro.Text += "Preencha o campo CNPJ/CPF.<br/>"
        End If

        If String.IsNullOrEmpty(TxtNome.Text) Then
            LblErro.Text += "Preencha o campo Razão Social.<br/>"
        End If

        If String.IsNullOrEmpty(TxtNomeAbreviado.Text) Then
            LblErro.Text += "Preencha o campo Fantasia.<br/>"
        End If

        If String.IsNullOrEmpty(TxtLogradouro.Text) Then
            LblErro.Text += "Preencha o campo Logradouro.<br/>"
        End If

        If DdlPais.Items.Count = 0 OrElse DdlPais.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo País.<br/>"
        End If

        If DdlEstado.Items.Count = 0 OrElse DdlEstado.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Estado.<br/>"
        End If

        If DdlCidade.Items.Count = 0 OrElse DdlCidade.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Cidade.<br/>"
        End If

        If Not String.IsNullOrEmpty(TxtEmail.Text) Then
            If Not TxtEmail.Text.Trim.IsValidEmail Then
                LblErro.Text += "Preencha corretamente o campo e-mail ou deixe-o em branco.<br/>"
            End If
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjEnderecoEmitente As UCLEnderecoEmitente) As UCLEnderecoEmitente

        ObjEnderecoEmitente.RazaoSocial = TxtNome.Text.GetValidInputContent
        ObjEnderecoEmitente.NomeAbreviado = TxtNomeAbreviado.Text.GetValidInputContent
        ObjEnderecoEmitente.Preferencial = ChkPreferencial.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjEnderecoEmitente.Cobranca = ChkCobranca.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjEnderecoEmitente.Ativo = ChkAtivo.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjEnderecoEmitente.Logradouro = TxtLogradouro.Text.GetValidInputContent
        ObjEnderecoEmitente.Numero = TxtNumero.Text
        ObjEnderecoEmitente.CEP = TxtCEP.Text.Replace("-", "").Replace(".", "")
        ObjEnderecoEmitente.Fone1 = TxtFone1.Text
        ObjEnderecoEmitente.Fone2 = TxtFone2.Text
        ObjEnderecoEmitente.Fax = TxtFax.Text
        ObjEnderecoEmitente.CodPais = DdlPais.SelectedValue
        ObjEnderecoEmitente.CodEstado = DdlEstado.SelectedValue
        ObjEnderecoEmitente.CodCidade = DdlCidade.SelectedValue
        ObjEnderecoEmitente.Bairro = TxtBairro.Text.GetValidInputContent
        ObjEnderecoEmitente.IE = TxtIE.Text.GetValidInputContent
        ObjEnderecoEmitente.IM = TxtIM.Text.GetValidInputContent
        ObjEnderecoEmitente.CNPJNovo = LblCNPJNovo.Text
        ObjEnderecoEmitente.Email = TxtEmail.Text
        ObjEnderecoEmitente.EmailXmlNfe = TxtEmailNFe.Text
        ObjEnderecoEmitente.EmailBoleto = TxtEmailBoleto.Text

        Return ObjEnderecoEmitente
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        If Embeeded Then
            Response.Redirect("WFClienteEmbeeded.aspx?vcodemi=" + VarCodEmitente + "&vcodemp=" + VarCodEmitentePesquisado + "&valtecc=" + VarAlterouCodCliente + "&vrecdc=" + VarRecarregaDdlContatos + "&ccodcon=" + VarCodContatoNegociacao + "&cnpjemi=" + VarCNPJEmitentePesquisado + "&vcodemin=" + VarCodEmitenteNegociacao)
        Else
            Response.Redirect("WGClienteCNPJ.aspx?")
        End If
    End Sub

    Protected Sub BtnContinuar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnContinuar.Click
        Try
            If Gravar() Then
                Response.Redirect("WFClienteFinanceiro.aspx?embeeded=" & Embeeded & "&vcodemi=" + VarCodEmitente + "&vcodemp=" + VarCodEmitentePesquisado + "&valtecc=" + VarAlterouCodCliente + "&vrecdc=" + VarRecarregaDdlContatos + "&cnpjemi=" + VarCNPJEmitentePesquisado + "&vcodemin=" + VarCodEmitenteNegociacao + "&ccodcon=" + VarCodContatoNegociacao)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub CarregaRazaoSocialEFantasia()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            objEmitente.CodEmitente = CodEmitente
            objEmitente.Buscar()

            TxtNome.Text = IIf(String.IsNullOrEmpty(TxtNome.Text), objEmitente.Nome, TxtNome.Text.Trim)
            TxtNomeAbreviado.Text = IIf(String.IsNullOrEmpty(TxtNomeAbreviado.Text), objEmitente.NomeAbreviado, TxtNomeAbreviado.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class