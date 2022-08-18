Partial Public Class WUCClienteCabecalho
    Inherits System.Web.UI.UserControl

    Private _CodEmitente As String
    Private _Acao As String
    Private _Embeeded As String
    Private _VarCodEmitente As String
    Private _VarCodEmitentePesquisado As String
    Private _VarAlterouCodCliente As String
    Private _VarRecarregaDdlContatos As String
    Private _VarCodContatoNegociacao As String
    Private _VarCNPJEmitente As String
    Private _VarCodEmitenteNegociacao As String

    Public Property AcaoOriginal() As String
        Get
            Return Session("SAcaoOriginal")
        End Get
        Set(ByVal value As String)
            Session("SAcaoOriginal") = value
        End Set
    End Property

    Public Property VarCNPJEmitente() As String
        Get
            Return _VarCNPJEmitente
        End Get
        Set(ByVal value As String)
            _VarCNPJEmitente = value
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

    Public Property CNPJEmitente As String
        Get
            Return LblCNPJ.Text.Replace("/", "").Replace("-", "").Replace(".", "").Replace(" ", "")
        End Get
        Set(ByVal value As String)
            LblCNPJ.Text = value
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

    Public Property Embeeded() As Boolean
        Get
            Return _Embeeded
        End Get
        Set(ByVal value As Boolean)
            _Embeeded = value
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

    Public Property VarCodEmitenteNegociacao() As String
        Get
            Return _VarCodEmitenteNegociacao
        End Get
        Set(ByVal value As String)
            _VarCodEmitenteNegociacao = value
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CodClientePesquisado As String
        Dim alterouCodCliente As Long
        Dim CodProprietarioPesquisado As String
        Dim alterouCodProprietario As Long
        Dim CodFranquiaPesquisada As String
        Dim alterouCodFranquia As Long
        Dim CodPessoaFisicaPesquisada As String
        Dim alterouCodPessoaFisica As Long
        If Not IsPostBack Then
            AcaoOriginal = Acao
            If Acao = "ALTERAR" Then
                Session("SAcaoCNPJ") = Acao
                Call CarregaFormulario()
                LblGrupoEmitente.Visible = False
                DdlMercado.Visible = False
            ElseIf Acao = "INCLUIR" Then
                Session("SAcaoCNPJ") = Acao
                Call CarregaNovaPK()
                DdlTipo.SelectedValue = "2"
                Dim objMercado As New UCLMercado
                objMercado.FillDropDown(DdlMercado, True, " (selecione) ")
                LblGrupoEmitente.Visible = True
                DdlMercado.Visible = True
            End If
        End If

        If Not String.IsNullOrEmpty(Session("SAlterouCodRedeAssoc")) Then
            alterouCodCliente = Session("SAlterouCodRedeAssoc")
        Else
            alterouCodCliente = 0
        End If

        CodClientePesquisado = Session("SCodRedeAssocPesquisada")
        If Not String.IsNullOrEmpty(CodClientePesquisado) Then
            If alterouCodCliente > 0 Then
                If TxtRedeAssociativa.Text <> CodClientePesquisado Then
                    TxtRedeAssociativa.Text = CodClientePesquisado
                    Call CodigoRedeAssociativaMudou()
                End If
                Session("SAlterouCodRedeAssoc") = alterouCodCliente - 1
            End If
        End If

        If Not String.IsNullOrEmpty(Session("SAlterouCodProprietario")) Then
            alterouCodProprietario = Session("SAlterouCodProprietario")
        Else
            alterouCodProprietario = 0
        End If

        CodProprietarioPesquisado = Session("SCodProprietarioPesquisado")
        If Not String.IsNullOrEmpty(CodProprietarioPesquisado) Then
            If alterouCodProprietario > 0 Then
                If TxtProprietario.Text <> CodProprietarioPesquisado Then
                    TxtProprietario.Text = CodProprietarioPesquisado
                    Call CodigoProprietarioMudou()
                End If
                Session("SAlterouCodProprietario") = alterouCodProprietario - 1
            End If
        End If

        If Not String.IsNullOrEmpty(Session("SAlterouCodFranquia")) Then
            alterouCodFranquia = Session("SAlterouCodFranquia")
        Else
            alterouCodFranquia = 0
        End If

        CodFranquiaPesquisada = Session("SCodFranquiaPesquisada")
        If Not String.IsNullOrEmpty(CodFranquiaPesquisada) Then
            If alterouCodFranquia > 0 Then
                If TxtFranquia.Text <> CodFranquiaPesquisada Then
                    TxtFranquia.Text = CodFranquiaPesquisada
                    Call CodigoFranquiaMudou()
                End If
                Session("SAlterouCodFranquia") = alterouCodFranquia - 1
            End If
        End If

        If Not String.IsNullOrEmpty(Session("SAlterouCodPessoaFisica")) Then
            alterouCodPessoaFisica = Session("SAlterouCodPessoaFisica")
        Else
            alterouCodPessoaFisica = 0
        End If

        CodPessoaFisicaPesquisada = Session("SCodPessoaFisicaPesquisado")
        If Not String.IsNullOrEmpty(CodPessoaFisicaPesquisada) Then
            If alterouCodPessoaFisica > 0 Then
                If TxtPessoaFisica.Text <> CodPessoaFisicaPesquisada Then
                    TxtPessoaFisica.Text = CodPessoaFisicaPesquisada
                    Call CodigoPessoaFisicaMudou()
                End If
                Session("SAlterouCodPessoaFisica") = alterouCodPessoaFisica - 1
            End If
        End If
        If Embeeded Then
            LblTxtEndereco.Visible = False
            LblLogradouro.Visible = False
            LblTxtBairro.Visible = False
            LblBairro.Visible = False
            LblTxtCEP.Visible = False
            LblCEP.Visible = False
            LblTxtCidadeUF.Visible = False
            LblCidade.Visible = False
            LblCidadeBarra.Visible = False
            LblUF.Visible = False
            LblUFTraco.Visible = False
            LblPais.Visible = False
            LblTxtTelefones.Visible = False
            LblTelefones.Visible = False
            LblTxtFax.Visible = False
            LblFax.Visible = False
            LblTxtEmail.Visible = False
            LblEmail.Visible = False
            LblTxtContatoPreferencial.Visible = False
            LblContatoPreferencial.Visible = False
            LblTxtSenha.Visible = False
            LblSenha.Visible = False



            LblDataCadastramentoLBL.Visible = False
            LblDataCadastro.Visible = False
            LblDataAlteracalLBL.Visible = False
            LblDataAlteracao.Visible = False
            LblUsuarioAlteracaoLBL.Visible = False
            LblUsuarioAlteracao.Visible = False
            LblUsuarioCadastramentoLBL.Visible = False
            LblUsuarioCadastro.Visible = False
            BtnProximo.Visible = True
            BtnCancelar.Visible = True
            BtnGravar.Visible = False
        Else
            LblTxtEndereco.Visible = True
            LblLogradouro.Visible = True
            LblTxtBairro.Visible = True
            LblBairro.Visible = True
            LblTxtCEP.Visible = True
            LblCEP.Visible = True
            LblTxtCidadeUF.Visible = True
            LblCidade.Visible = True
            LblUF.Visible = True
            LblPais.Visible = True
            LblTxtTelefones.Visible = True
            LblTelefones.Visible = True
            LblTxtFax.Visible = True
            LblFax.Visible = True
            LblTxtEmail.Visible = True
            LblEmail.Visible = True
            LblTxtContatoPreferencial.Visible = True
            LblContatoPreferencial.Visible = True
            LblTxtSenha.Visible = True
            LblSenha.Visible = True

            LblDataCadastramentoLBL.Visible = True
            LblDataCadastro.Visible = True
            LblDataAlteracalLBL.Visible = True
            LblDataAlteracao.Visible = True
            LblUsuarioAlteracaoLBL.Visible = True
            LblUsuarioAlteracao.Visible = True
            LblUsuarioCadastramentoLBL.Visible = True
            LblUsuarioCadastro.Visible = True
            BtnProximo.Visible = False
            BtnCancelar.Visible = False
            BtnGravar.Visible = True
        End If

        If Session("GlBloquearCadastroEmitenteRepresentante") = "S" Then
            BtnGravar.Visible = False
            BtnProximo.Visible = False
        End If

    End Sub

    Protected Sub CodigoRedeAssociativaMudou()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))



            If Not String.IsNullOrWhiteSpace(TxtRedeAssociativa.Text) Then
                objEmitente.CodEmitente = TxtRedeAssociativa.Text
                objEmitente.Buscar()
                lblRedeAssociativa.Text = objEmitente.Nome
            Else
                lblRedeAssociativa.Text = ""
            End If

            Session("SCodRedeAssocPesquisada") = TxtRedeAssociativa.Text

            If LblCNPJLbl.Text = "CNPJ" Then
                LblCNPJ.Text = LblCNPJ.Text.Replace("/", "").Replace("-", "").Replace(".", "").Replace(" ", "")
                LblCNPJ.Text = LblCNPJ.Text.MascaraCNPJ
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CodigoProprietarioMudou()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))



            If Not String.IsNullOrWhiteSpace(TxtProprietario.Text) Then
                objEmitente.CodEmitente = TxtProprietario.Text
                objEmitente.Buscar()
                LblProprietario.Text = objEmitente.Nome
            Else
                LblProprietario.Text = ""
            End If

            Session("SCodProprietarioPesquisado") = TxtProprietario.Text

            If LblCNPJLbl.Text = "CNPJ" Then
                LblCNPJ.Text = LblCNPJ.Text.Replace("/", "").Replace("-", "").Replace(".", "").Replace(" ", "")
                LblCNPJ.Text = LblCNPJ.Text.MascaraCNPJ
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CodigoFranquiaMudou()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))



            If Not String.IsNullOrWhiteSpace(TxtFranquia.Text) Then
                objEmitente.CodEmitente = TxtFranquia.Text
                objEmitente.Buscar()
                LblFranquia.Text = objEmitente.Nome
            Else
                LblFranquia.Text = ""
            End If

            Session("SCodFranquiaPesquisado") = TxtFranquia.Text

            If LblCNPJLbl.Text = "CNPJ" Then
                LblCNPJ.Text = LblCNPJ.Text.Replace("/", "").Replace("-", "").Replace(".", "").Replace(" ", "")
                LblCNPJ.Text = LblCNPJ.Text.MascaraCNPJ
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CodigoPessoaFisicaMudou()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))



            If Not String.IsNullOrWhiteSpace(TxtPessoaFisica.Text) Then
                objEmitente.CodEmitente = TxtPessoaFisica.Text
                objEmitente.Buscar()
                LblPessoaFisica.Text = objEmitente.Nome
            Else
                LblPessoaFisica.Text = ""
            End If

            Session("SCodPessoaFisicaPesquisado") = TxtPessoaFisica.Text

            If LblCNPJLbl.Text = "CNPJ" Then
                LblCNPJ.Text = LblCNPJ.Text.Replace("/", "").Replace("-", "").Replace(".", "").Replace(" ", "")
                LblCNPJ.Text = LblCNPJ.Text.MascaraCNPJ
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Function Gravar() As Boolean
        Dim ObjEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjEmitente.CodEmitente = LblCodEmitente.Text
                    ObjEmitente.Buscar()
                    ObjEmitente = CarregaObjeto(ObjEmitente)
                    If Session("GlBloquearCadastroEmitenteRepresentante").ToString <> "S" Then
                        ObjEmitente.Alterar()
                        LblErro.Text = "Os dados foram salvos com sucesso."
                    End If
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjEmitente.CodEmitente = LblCodEmitente.Text
                    ObjEmitente.Buscar()
                    ObjEmitente = CarregaObjeto(ObjEmitente)
                    If Session("GlBloquearCadastroEmitenteRepresentante").ToString <> "S" Then
                        ObjEmitente.Incluir()
                        LblErro.Text = "Os dados foram salvos com sucesso."
                    End If

                    If DdlMercado.Visible Then
                        If DdlMercado.SelectedValue > 0 Then
                            Dim objClienteMercado As New UCLClienteMercado
                            objClienteMercado.SetConteudo("cod_emitente", LblCodEmitente.Text)
                            objClienteMercado.SetConteudo("cod_mercado", DdlMercado.SelectedValue)
                            objClienteMercado.SetConteudo("preferencial", "S")
                            objClienteMercado.Incluir()
                        End If
                    End If

                    Session("SAcao") = "ALTERAR"
                    'Session("SCodEmitente") = LblCodEmitente.Text
                    Session(VarCodEmitente) = LblCodEmitente.Text
                    'Session("SCodClientePesquisado") = LblCodEmitente.Text
                    Session(VarCodEmitentePesquisado) = LblCodEmitente.Text
                    'Session("SAlterouCodCliente") = 2
                    Session(VarAlterouCodCliente) = 2

                    'Session("SRecarregaDdlContatos") = 2
                    Session(VarRecarregaDdlContatos) = 2
                    'Session("SCodContatoNegociacao") = "0"
                    Session(VarCodContatoNegociacao) = "0"
                    Session(VarCNPJEmitente) = ""
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

        If String.IsNullOrEmpty(TxtNome.Text) Then
            LblErro.Text += "Preencha o campo Nome.<br/>"
        End If

        If String.IsNullOrEmpty(TxtFantasia.Text) Then
            LblErro.Text += "Preencha o campo Fantasia.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjEmitente As UCLEmitente) As UCLEmitente

        'ObjEmitente.TpPessoa = DdlTpPessoa.SelectedValue
        ObjEmitente.Nome = TxtNome.Text.GetValidInputContent
        ObjEmitente.NomeAbreviado = TxtFantasia.Text.GetValidInputContent
        ObjEmitente.Situacao = DdlSituacao.SelectedValue
        ObjEmitente.Tipo = DdlTipo.SelectedValue
        ObjEmitente.Procedencia = DdlProcedencia.SelectedValue
        ObjEmitente.Natureza = DdlNatureza.SelectedValue
        ObjEmitente.Funcionario = ChkFuncionario.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjEmitente.Transportador = ChkTransportador.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjEmitente.Representante = ChkRepresentante.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjEmitente.ConfirmacaoEncerramentoOS = CbxConfirma.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjEmitente.Licenciador = ChkLicenciador.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjEmitente.OptantePeloSimples = ChkOptanteSimples.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjEmitente.ExigeFotoOS = ChkExigeFotoOS.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjEmitente.Cliente = ChkCliente.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjEmitente.Fornecedor = ChkFornecedor.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjEmitente.Distribuidor = ChkDistribuidor.Checked.ToString.Replace("False", "N").Replace("True", "S")
        If Not String.IsNullOrWhiteSpace(TxtRedeAssociativa.Text) Then
            ObjEmitente.CodRedeAssociativa = TxtRedeAssociativa.Text
        Else
            ObjEmitente.CodRedeAssociativa = "null"
        End If
        If Not String.IsNullOrWhiteSpace(TxtProprietario.Text) Then
            ObjEmitente.CodProprietario = TxtProprietario.Text
        Else
            ObjEmitente.CodProprietario = "null"
        End If
        If Not String.IsNullOrWhiteSpace(TxtFranquia.Text) Then
            ObjEmitente.CodFranquia = TxtFranquia.Text
        Else
            ObjEmitente.CodFranquia = "null"
        End If
        If Not String.IsNullOrWhiteSpace(TxtPessoaFisica.Text) Then
            ObjEmitente.CodPessoaFisica = TxtPessoaFisica.Text
        Else
            ObjEmitente.CodPessoaFisica = "null"
        End If




        Return ObjEmitente
    End Function

    Private Sub CarregaFormulario()
        Dim ObjEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim objContato As New UCLContato
        Dim objPais As New UCLPais
        Dim objEstado As New UCLEstado
        Dim objCidade As New UCLCidade
        Dim objEmitentePF As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim ObjUsuario As New UCLUsuario
        Dim qtdDiasInadimplente As Long
        Dim qtdTitulosAberto As Long

        ObjEmitente.CodEmitente = CodEmitente
        ObjEmitente.Buscar()

        objEnderecoEmitente.CodEmitente = CodEmitente
        objEnderecoEmitente.CNPJ = CNPJEmitente
        objEnderecoEmitente.Buscar()
        CNPJEmitente = objEnderecoEmitente.CNPJ

        objPais.CodPais = objEnderecoEmitente.CodPais
        objPais.Buscar()

        objEstado.CodPais = objEnderecoEmitente.CodPais
        objEstado.CodEstado = objEnderecoEmitente.CodEstado
        objEstado.Buscar()

        objCidade.CodPais = objEnderecoEmitente.CodPais
        objCidade.CodEstado = objEnderecoEmitente.CodEstado
        objCidade.CodCidade = objEnderecoEmitente.CodCidade
        objCidade.Buscar()

        LblLogradouro.Text = objEnderecoEmitente.Logradouro
        TxtRedeAssociativa.Text = ObjEmitente.CodRedeAssociativa
        TxtProprietario.Text = ObjEmitente.CodProprietario
        TxtFranquia.Text = ObjEmitente.CodFranquia
        TxtPessoaFisica.Text = ObjEmitente.CodPessoaFisica

        If Not String.IsNullOrEmpty(objEnderecoEmitente.Numero) Then
            If IsNumeric(objEnderecoEmitente.Numero) Then
                If objEnderecoEmitente.Numero > 0 Then
                    LblLogradouro.Text += ", Nº " + objEnderecoEmitente.Numero
                End If
            End If
        End If

        LblBairro.Text = objEnderecoEmitente.Bairro
        LblCEP.Text = objEnderecoEmitente.CEP
        LblCidade.Text = objCidade.NomeCidade
        LblUF.Text = objEstado.Sigla
        LblPais.Text = objPais.Nome

        LblTelefones.Text = objEnderecoEmitente.Fone1

        If Not String.IsNullOrEmpty(objEnderecoEmitente.Fone2) Then
            LblTelefones.Text += "   e   " + objEnderecoEmitente.Fone2
        End If

        LblFax.Text = objEnderecoEmitente.Fax
        LblEmail.Text = objEnderecoEmitente.Email
        LblSenha.Text = objEnderecoEmitente.Senha

        If objEnderecoEmitente.Preferencial = "S" Then
            LblPreferencial.Text = "SIM"
        Else
            LblPreferencial.Text = "NÃO"
        End If

        If ObjEmitente.Associado = "S" Then
            LblAssociado.Text = "SIM"
            If ObjEmitente.TpPessoa = "PF" Then
                LblAssociado.Text += ", Pessoa Física"
            Else
                LblAssociado.Text += ", Pessoa Jurídica"
            End If
        Else
            LblAssociado.Text = "NÃO"
        End If



        qtdTitulosAberto = ObjEmitente.TitulosEmAbertoVencidos(Session("GlEmpresa"))
        qtdDiasInadimplente = ObjEmitente.DiasInadimplente(Session("GlEmpresa"))
        If qtdTitulosAberto > 0 AndAlso qtdDiasInadimplente > 0 Then
            LblInadimplente.Text = "Cliente possui " + qtdTitulosAberto.ToString + " título(s) em aberto e está inadimplente há " + qtdDiasInadimplente.ToString + " dias"
            If qtdDiasInadimplente <= 31 Then
                LblInadimplente.ForeColor = Drawing.Color.Black
            End If
        End If

        LblContatoPreferencial.Text = objContato.Nome + " [" + objContato.Email + "]"

        LblCodEmitente.Text = CodEmitente
        'DdlTpPessoa.SelectedValue = ObjEmitente.TpPessoa
        TxtNome.Text = ObjEmitente.Nome
        TxtFantasia.Text = ObjEmitente.NomeAbreviado
        DdlSituacao.SelectedValue = ObjEmitente.Situacao
        DdlTipo.SelectedValue = ObjEmitente.Tipo
        DdlProcedencia.SelectedValue = ObjEmitente.Procedencia
        DdlNatureza.SelectedValue = ObjEmitente.Natureza
        ChkFuncionario.Checked = ObjEmitente.Funcionario.ToString.Replace("N", "False").Replace("S", "True")
        ChkTransportador.Checked = ObjEmitente.Transportador.ToString.Replace("N", "False").Replace("S", "True")
        ChkRepresentante.Checked = ObjEmitente.Representante.ToString.Replace("N", "False").Replace("S", "True")
        ChkLicenciador.Checked = ObjEmitente.Licenciador.ToString.Replace("N", "False").Replace("S", "True")
        ChkCliente.Checked = ObjEmitente.Cliente.ToString.Replace("N", "False").Replace("S", "True")
        ChkFornecedor.Checked = ObjEmitente.Fornecedor.ToString.Replace("N", "False").Replace("S", "True")
        ChkDistribuidor.Checked = ObjEmitente.Distribuidor.ToString.Replace("N", "False").Replace("S", "True")
        ChkOptanteSimples.Checked = ObjEmitente.OptantePeloSimples.ToString.Replace("N", "False").Replace("S", "True")
        LblDataAlteracao.Text = ObjEmitente.DataAlteracao
        LblDataCadastro.Text = ObjEmitente.DataCadastramento
        CbxConfirma.Checked = ObjEmitente.ConfirmacaoEncerramentoOS.ToString.Replace("N", "False").Replace("S", "True")
        ChkExigeFotoOS.Checked = ObjEmitente.ExigeFotoOS.ToString.Replace("N", "False").Replace("S", "True")

        ObjUsuario.CodUsuario = ObjEmitente.UsuarioAlteracao
        ObjUsuario.BuscarPorCodigo()
        LblUsuarioAlteracao.Text = ObjUsuario.NomeUsuario + " (" + ObjUsuario.CodUsuario + ")"

        ObjUsuario.CodUsuario = ObjEmitente.UsuarioCadastramento
        ObjUsuario.BuscarPorCodigo()
        LblUsuarioCadastro.Text = ObjUsuario.NomeUsuario + " (" + ObjUsuario.CodUsuario + ")"

        If ObjEmitente.TpPessoa = "PF" Then
            LblCNPJLbl.Text = "CPF"
            LblCNPJ.Text = LblCNPJ.Text.MascaraCPF
        Else
            LblCNPJLbl.Text = "CNPJ"
            LblCNPJ.Text = LblCNPJ.Text.MascaraCNPJ
        End If
        Call CodigoRedeAssociativaMudou()
        Call CodigoProprietarioMudou()
        Call CodigoFranquiaMudou()
        Call CodigoPessoaFisicaMudou()
        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Regional Then
            LblCodEmitente.Enabled = False
            'DdlTpPessoa.Enabled = False
            TxtNome.Enabled = False
            TxtFantasia.Enabled = False
            DdlSituacao.Enabled = False
            DdlTipo.Enabled = False
            DdlProcedencia.Enabled = False
            DdlNatureza.Enabled = False
            ChkFuncionario.Enabled = False
            ChkTransportador.Enabled = False
            ChkRepresentante.Enabled = False
            ChkLicenciador.Enabled = False
            ChkOptanteSimples.Enabled = False
            LblDataAlteracao.Enabled = False
            LblDataCadastro.Enabled = False
            CbxConfirma.Enabled = False
            ChkExigeFotoOS.Enabled = False
            LblUsuarioCadastro.Enabled = False
        End If

    End Sub

    Private Sub CarregaNovaPK()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        LblCodEmitente.Text = objEmitente.GetProximoCodigo
    End Sub

    Protected Sub BtnProximo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnProximo.Click
        Try
            If Gravar() Then
                If Session("SPulaCNPJCadastro") = "S" Then
                    Response.Redirect("WFClienteFinanceiro.aspx?embeeded=" & Embeeded & "&vcodemi=" + VarCodEmitente + "&vcodemp=" + VarCodEmitentePesquisado + "&valtecc=" + VarAlterouCodCliente + "&vrecdc=" + VarRecarregaDdlContatos + "&cnpjemi=" + VarCNPJEmitente + "&vcodemin=" + VarCodEmitenteNegociacao + "&ccodcon=" + VarCodContatoNegociacao)
                Else
                    Response.Redirect("WFClienteCNPJ.aspx?embeeded=" & Embeeded & "&vcodemi=" + VarCodEmitente + "&vcodemp=" + VarCodEmitentePesquisado + "&valtecc=" + VarAlterouCodCliente + "&vrecdc=" + VarRecarregaDdlContatos + "&ccodcon=" + VarCodContatoNegociacao + "&cnpjemi=" + VarCNPJEmitente + "&vcodemin=" + VarCodEmitenteNegociacao)
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub btnOkay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOkay.Click
        Try
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onError();", True)
        End Try
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancelar.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "cancel();", True)
    End Sub

    Protected Sub TxtRedeAssociativa_TextChanged(sender As Object, e As EventArgs) Handles TxtRedeAssociativa.TextChanged
        Try
            Call CodigoRedeAssociativaMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub TxtProprietario_TextChanged(sender As Object, e As EventArgs) Handles TxtProprietario.TextChanged
        Try
            Call CodigoProprietarioMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub TxtFranquia_TextChanged(sender As Object, e As EventArgs) Handles TxtFranquia.TextChanged
        Try
            Call CodigoFranquiaMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub TxtPessoaFisica_TextChanged(sender As Object, e As EventArgs) Handles TxtPessoaFisica.TextChanged
        Try
            Call CodigoPessoaFisicaMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class