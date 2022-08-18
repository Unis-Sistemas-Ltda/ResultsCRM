Public Class WUCTEF
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodLoja As String
    Private _CNPJLoja As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodLoja() As String
        Get
            Return _CodLoja
        End Get
        Set(ByVal value As String)
            _CodLoja = value
        End Set
    End Property

    Public Property CNPJLoja() As String
        Get
            Return _CNPJLoja
        End Get
        Set(ByVal value As String)
            _CNPJLoja = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaDropDowns()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjAdesaoTEFLoja As New UCLAdesaoTEFLoja
        Dim objContato As New UCLContato
        TxtCodEmitente.Text = CodLoja

        ObjAdesaoTEFLoja.Buscar(Session("GlEmpresa"), CodLoja, CNPJLoja)

        TxtRazaoSocial.Text = ObjAdesaoTEFLoja.GetConteudo("razao_social").ToString
        TxtCNPJ.Text = ObjAdesaoTEFLoja.GetConteudo("cnpj").ToString
        DdlGrupoTEF.SelectedValue = ObjAdesaoTEFLoja.GetConteudo("cod_adesao").ToString
        TxtNomeSoftwareHouse.Text = ObjAdesaoTEFLoja.GetConteudo("nome_software_house").ToString
        TxtContatoSoftwareHouse.Text = ObjAdesaoTEFLoja.GetConteudo("contato_software_house").ToString
        TxtNomeAplicativoComercial.Text = ObjAdesaoTEFLoja.GetConteudo("nome_aplicativo_comercial").ToString
        TxtEmailSoftwareHouse.Text = ObjAdesaoTEFLoja.GetConteudo("email_software_house").ToString
        TxtTelefoneSoftwareHouse.Text = ObjAdesaoTEFLoja.GetConteudo("telefone_software_house").ToString
        TxtVersaoAplicativoComercial.Text = ObjAdesaoTEFLoja.GetConteudo("versao_aplicativo_comercial").ToString
        CbxGerarChamadoInstalacao.Checked = IIf(ObjAdesaoTEFLoja.GetConteudo("gerar_chamado_instalacao").ToString = "S", True, False)
        TxtCodChamadoInstalacao.Text = ObjAdesaoTEFLoja.GetConteudo("cod_chamado_instalacao").ToString
        TxtQtdPDVs.Text = ObjAdesaoTEFLoja.GetConteudo("qtd_pdv").ToString
        CbxPinpadEnviado.Checked = IIf(ObjAdesaoTEFLoja.GetConteudo("pinpad_enviado").ToString = "S", True, False)
        CbxRecebeuPinpad.Checked = IIf(ObjAdesaoTEFLoja.GetConteudo("recebeu_pinpad").ToString = "S", True, False)
        CbxInstalado.Checked = IIf(ObjAdesaoTEFLoja.GetConteudo("instalado").ToString = "S", True, False)
        CbxTestado.Checked = IIf(ObjAdesaoTEFLoja.GetConteudo("testado").ToString = "S", True, False)
        TxtBanco.Text = ObjAdesaoTEFLoja.GetConteudo("banco")
        TxtAgencia.Text = ObjAdesaoTEFLoja.GetConteudo("agencia")
        TxtConta.Text = ObjAdesaoTEFLoja.GetConteudo("conta")
        TxtCodNegociacaoCliente.Text = ObjAdesaoTEFLoja.GetConteudo("cod_negociacao_cliente")
        If Not String.IsNullOrWhiteSpace(ObjAdesaoTEFLoja.GetConteudo("cod_status").ToString) Then
            DdlStatus.SelectedValue = ObjAdesaoTEFLoja.GetConteudo("cod_status").ToString
        Else
            DdlStatus.SelectedValue = -1
        End If
        TxtCodEmitente.Enabled = False
        TxtCNPJ.Enabled = False

        objContato.CodEmitente = TxtCodEmitente.Text
        If objContato.GetCodContatoPreferencial() > 0 Then
            objContato.Codigo = objContato.GetCodContatoPreferencial()
            objContato.Buscar()
            TxtNomeContato.Text = objContato.Nome
            TxtTelefoneContato.Text = objContato.Telefone
            TxtEmailContato.Text = objContato.Email
            If String.IsNullOrEmpty(TxtTelefoneContato.Text) Then
                Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexao)
                objEnderecoEmitente.CodEmitente = TxtCodEmitente.Text
                objEnderecoEmitente.CNPJ = TxtCNPJ.Text.Trim.GetValidInputContent.Replace("/", "").Replace("-", "").Replace(".", "")
                objEnderecoEmitente.Buscar()
                TxtTelefoneContato.Text = objEnderecoEmitente.Fone1
            End If
        End If
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjEmitente As New UCLEmitente(StrConexao)
        TxtCodEmitente.Text = ObjEmitente.GetProximoCodigo
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjAdesaoTEFLoja As New UCLAdesaoTEFLoja
        Dim objContato As New UCLContato
        Try
            If IsDigitacaoOk() Then
                objContato.CodEmitente = TxtCodEmitente.Text
                If objContato.GetCodContatoPreferencial() > 0 Then
                    objContato.Codigo = objContato.GetCodContatoPreferencial()
                    objContato.Buscar()
                Else
                    objContato.Codigo = objContato.GetProximoCodigo
                    objContato.Preferencial = "S"
                End If

                If Acao = "ALTERAR" Then
                    ObjAdesaoTEFLoja.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjAdesaoTEFLoja.SetConteudo("cod_emitente", TxtCodEmitente.Text)
                    ObjAdesaoTEFLoja.SetConteudo("cnpj", TxtCNPJ.Text)
                    ObjAdesaoTEFLoja = CarregaObjeto(ObjAdesaoTEFLoja, objContato)
                    ObjAdesaoTEFLoja.Alterar()

                    If objContato.GetCodContatoPreferencial() > 0 Then
                        objContato.Alterar()
                    Else
                        objContato.Incluir()
                    End If

                    LblErro.Text = "Cadastro alterado com sucesso."

                ElseIf Acao = "INCLUIR" Then
                    Dim ObjEmitente As New UCLEmitente(StrConexao)

                    ObjEmitente.CodEmitente = TxtCodEmitente.Text
                    If ObjEmitente.Buscar.Rows.Count = 0 Then
                        ObjEmitente.TpPessoa = "PJ"
                        ObjEmitente.Nome = TxtRazaoSocial.Text.GetValidInputContent
                        ObjEmitente.NomeAbreviado = TxtRazaoSocial.Text.GetValidInputContent
                        ObjEmitente.Situacao = "2" 'Ativo
                        ObjEmitente.Tipo = "2" 'Cliente
                        ObjEmitente.Procedencia = "N" 'Nacional
                        ObjEmitente.Natureza = "3" 'Serviço
                        ObjEmitente.Funcionario = "N"
                        ObjEmitente.Transportador = "N"
                        ObjEmitente.Representante = "N"
                        ObjEmitente.ConfirmacaoEncerramentoOS = "N"
                        ObjEmitente.Licenciador = "N"
                        ObjEmitente.OptantePeloSimples = "N"
                        ObjEmitente.ExigeFotoOS = "N"
                        ObjEmitente.Incluir()
                    End If

                    Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexao)
                    objEnderecoEmitente.CodEmitente = TxtCodEmitente.Text
                    objEnderecoEmitente.CNPJ = TxtCNPJ.Text.GetValidInputContent.Replace("/", "").Replace(".", "").Replace("-", "")
                    If Not objEnderecoEmitente.Buscar() Then
                        objEnderecoEmitente.CodEmitente = TxtCodEmitente.Text
                        objEnderecoEmitente.CNPJ = TxtCNPJ.Text.GetValidInputContent.Replace("/", "").Replace(".", "").Replace("-", "")
                        objEnderecoEmitente.RazaoSocial = TxtRazaoSocial.Text.GetValidInputContent
                        objEnderecoEmitente.NomeAbreviado = TxtRazaoSocial.Text.GetValidInputContent
                        objEnderecoEmitente.Preferencial = "N"
                        objEnderecoEmitente.Cobranca = "N"
                        objEnderecoEmitente.CodPais = 1
                        objEnderecoEmitente.CodEstado = 1
                        objEnderecoEmitente.CodCidade = 1
                        objEnderecoEmitente.Logradouro = ""
                        objEnderecoEmitente.Logradouro = ""
                        objEnderecoEmitente.Ativo = "S"
                        objEnderecoEmitente.Fone1 = TxtTelefoneContato.Text
                        objEnderecoEmitente.Incluir()
                    End If

                    ObjAdesaoTEFLoja.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjAdesaoTEFLoja.SetConteudo("cod_emitente", TxtCodEmitente.Text)
                    ObjAdesaoTEFLoja.SetConteudo("cnpj", TxtCNPJ.Text.GetValidInputContent.Replace("/", "").Replace(".", "").Replace("-", ""))
                    ObjAdesaoTEFLoja = CarregaObjeto(ObjAdesaoTEFLoja, objContato)
                    ObjAdesaoTEFLoja.Incluir()

                    If objContato.GetCodContatoPreferencial() > 0 Then
                        objContato.Alterar()
                    Else
                        objContato.Incluir()
                    End If

                    Session("SAcao") = "ALTERAR"
                    Session("SCodLoja") = TxtCodEmitente.Text
                    LblErro.Text = "Cadastro incluído com sucesso."

                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtCodEmitente.Text) Then
            LblErro.Text += "Preencha o campo Código.<br/>"
        End If

        If String.IsNullOrEmpty(TxtRazaoSocial.Text) Then
            LblErro.Text += "Preencha o campo Razão Social.<br/>"
        End If

        If String.IsNullOrEmpty(TxtCNPJ.Text) Then
            LblErro.Text += "Preencha o campo CNPJ.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjAdesaoTEFLoja As UCLAdesaoTEFLoja, ByRef objContato As UCLContato) As UCLAdesaoTEFLoja
        ObjAdesaoTEFLoja.SetConteudo("razao_social", TxtRazaoSocial.Text.GetValidInputContent)
        ObjAdesaoTEFLoja.SetConteudo("cnpj", TxtCNPJ.Text.GetValidInputContent.Replace(".", "").Replace("/", "").Replace("-", "").Trim)
        If DdlGrupoTEF.SelectedValue <> -1 Then
            ObjAdesaoTEFLoja.SetConteudo("cod_adesao", DdlGrupoTEF.SelectedValue)
        Else
            ObjAdesaoTEFLoja.SetConteudo("cod_adesao", "")
        End If
        ObjAdesaoTEFLoja.SetConteudo("cod_negociacao_cliente", TxtCodNegociacaoCliente.Text.GetValidInputContent)
        ObjAdesaoTEFLoja.SetConteudo("banco", TxtBanco.Text.GetValidInputContent)
        ObjAdesaoTEFLoja.SetConteudo("agencia", TxtAgencia.Text.GetValidInputContent)
        ObjAdesaoTEFLoja.SetConteudo("conta", TxtConta.Text)
        ObjAdesaoTEFLoja.SetConteudo("nome_software_house", TxtNomeSoftwareHouse.Text.GetValidInputContent)
        ObjAdesaoTEFLoja.SetConteudo("contato_software_house", TxtContatoSoftwareHouse.Text.GetValidInputContent)
        ObjAdesaoTEFLoja.SetConteudo("email_software_house", TxtEmailSoftwareHouse.Text)
        ObjAdesaoTEFLoja.SetConteudo("telefone_software_house", TxtTelefoneSoftwareHouse.Text)
        ObjAdesaoTEFLoja.SetConteudo("nome_aplicativo_comercial", TxtNomeAplicativoComercial.Text.GetValidInputContent)
        ObjAdesaoTEFLoja.SetConteudo("versao_aplicativo_comercial", TxtVersaoAplicativoComercial.Text.GetValidInputContent)
        ObjAdesaoTEFLoja.SetConteudo("gerar_chamado_instalacao", IIf(CbxGerarChamadoInstalacao.Checked, "S", "N"))
        ObjAdesaoTEFLoja.SetConteudo("cod_chamado_instalacao", TxtCodChamadoInstalacao.Text.GetValidInputContent)
        ObjAdesaoTEFLoja.SetConteudo("qtd_pdv", TxtQtdPDVs.Text.GetValidInputContent)
        ObjAdesaoTEFLoja.SetConteudo("pinpad_enviado", IIf(CbxPinpadEnviado.Checked, "S", "N"))
        ObjAdesaoTEFLoja.SetConteudo("recebeu_pinpad", IIf(CbxRecebeuPinpad.Checked, "S", "N"))
        ObjAdesaoTEFLoja.SetConteudo("instalado", IIf(CbxInstalado.Checked, "S", "N"))
        ObjAdesaoTEFLoja.SetConteudo("testado", IIf(CbxTestado.Checked, "S", "N"))
        ObjAdesaoTEFLoja.SetConteudo("cod_usuario_alteracao", Session("GlCodUsuario"))
        ObjAdesaoTEFLoja.SetConteudo("data_alteracao", Now.ToString("yyyy-MM-dd HH:mm:ss"))
        If ObjAdesaoTEFLoja.IsNull("cod_usuario_inclusao") Then
            ObjAdesaoTEFLoja.SetConteudo("cod_usuario_inclusao", Session("GlCodUsuario"))
            ObjAdesaoTEFLoja.SetConteudo("data_inclusao", Now.ToString("yyyy-MM-dd HH:mm:ss"))
        End If
        If DdlStatus.SelectedValue <> -1 Then
            ObjAdesaoTEFLoja.SetConteudo("cod_status", DdlStatus.SelectedValue)
        Else
            ObjAdesaoTEFLoja.SetConteudo("cod_status", "")
        End If

        objContato.Nome = TxtNomeContato.Text.GetValidInputContent
        objContato.Telefone = TxtTelefoneContato.Text.GetValidInputContent
        objContato.Email = TxtEmailContato.Text.GetValidInputContent

        Return ObjAdesaoTEFLoja
    End Function

    

    Private Sub CarregaDropDowns()
        Call CarregaGrupoTEF()
        Call CarregaStatus()
    End Sub

    Private Sub CarregaGrupoTEF()
        Try
            Dim objAdesaoTEF As New UCLAdesaoTEF
            objAdesaoTEF.FillDropDown(DdlGrupoTEF, True, "(selecione)", -1, Session("GlEmpresa"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaStatus()
        Try
            Dim objStatusAdesaoTEF As New UCLStatusAdesaoTEF
            objStatusAdesaoTEF.FillDropDown(DdlStatus, True, "(selecione)", -1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    
    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim objEmailCampanhaTEF As New UCLEmailCampanhaTef
            Dim objAdesaoTEF As New UCLAdesaoTEF
            Dim objParametrosEmail As New UCLParametrosEmail
            Dim qtd As Long = 0

            objAdesaoTEF.Buscar(Session("GlEmpresa"), DdlGrupoTEF.SelectedValue)
            objParametrosEmail.Buscar(Session("GlEmpresa"))

            Dim objEmitente As New UCLEmitente(StrConexao)
            objEmitente.CodEmitente = TxtCodEmitente.Text
            objEmitente.Buscar()

            If String.IsNullOrEmpty(TxtEmailContato.Text) Then
                LblErro.Text = "E-mail para contato não foi informado."
            End If

            objEmailCampanhaTEF.SeqEmail = objEmailCampanhaTEF.GetProximoCodigo()
            objEmailCampanhaTEF.DEnviado = Now.ToString("dd/MM/yyyy")
            objEmailCampanhaTEF.HEnviado = Now.ToString("HH:mm:ss")
            objEmailCampanhaTEF.DDataEmail = Now.ToString("dd/MM/yyyy")
            objEmailCampanhaTEF.HHoraEmail = Now.ToString("HH:mm:ss")
            objEmailCampanhaTEF.Destinatario = objEmitente.Nome
            objEmailCampanhaTEF.Para = TxtEmailContato.Text
            objEmailCampanhaTEF.DestinatarioCC = objAdesaoTEF.GetConteudo("email_campanha_cc")
            objEmailCampanhaTEF.Assunto = objAdesaoTEF.GetConteudo("assunto_email_campanha").ToString.Replace("#nome_grupo#", objAdesaoTEF.GetConteudo("nome_rede"))
            objEmailCampanhaTEF.Mensagem = objAdesaoTEF.GetConteudo("mensagem_email_campanha").ToString.Replace("#cod_emitente#", objEmitente.CodEmitente).Replace("#cod_adesao#", DdlGrupoTEF.SelectedValue).Replace("#nome_grupo#", objAdesaoTEF.GetConteudo("nome_rede")).Replace("#nome_usuario#", Session("GlNomeUsuario")).Replace("#nome_emitente#", objEmitente.Nome)
            objEmailCampanhaTEF.CodEmitente = objEmitente.CodEmitente
            objEmailCampanhaTEF.CNPJ = TxtCNPJ.Text.GetValidInputContent.Trim.Replace("/", "").Replace(".", "").Replace("-", "")
            objEmailCampanhaTEF.Remetente = objAdesaoTEF.GetConteudo("nome_remetente_email_campanha").ToString.Replace("#nome_grupo#", objAdesaoTEF.GetConteudo("nome_rede"))
            objEmailCampanhaTEF.De = objAdesaoTEF.GetConteudo("email_remetente_email_campanha")
            objEmailCampanhaTEF.EnviarAutomatico = "S"
            objEmailCampanhaTEF.DestinatarioCCO = ""
            objEmailCampanhaTEF.Anexo = ""

            If objAdesaoTEF.GetConteudo("inserir_anexo_email") = "S" Then
                For i As Integer = 1 To 5
                    If Not String.IsNullOrEmpty(objAdesaoTEF.GetConteudo("anexo" + i.ToString() + "_email_campanha")) Then
                        objEmailCampanhaTEF.Anexo += objParametrosEmail.GetConteudo("caminho_arquivos_campanha_tef") + IIf(objParametrosEmail.GetConteudo("caminho_arquivos_campanha_tef").ToString.EndsWith("\"), "", "\") + objAdesaoTEF.GetConteudo("anexo" + i.ToString() + "_email_campanha") + ";"
                    End If
                Next
            End If

            objEmailCampanhaTEF.Incluir()

            LblErro.Text = "1 e-mail enviado."

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim CodEmitente As String

        Try

            Dim objNegociacao As New UCLNegociacao(StrConexao)

            CodEmitente = TxtCodEmitente.Text
            objNegociacao.GeraNegociacaoAdesaoTEF(Session("GlEmpresa"), CodEmitente)

            LblErro.Text = "Negociação gerada com sucesso."

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class