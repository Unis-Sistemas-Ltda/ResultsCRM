Partial Public Class WUCAtendimentoCabecalho_Suporte_Software
    Inherits System.Web.UI.UserControl

    Private _ModoAbertura As Long
    Private _CodAtendimento As String
    Private _Acao As String
    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property CodAtendimento() As String
        Get
            Return _CodAtendimento
        End Get
        Set(ByVal value As String)
            _CodAtendimento = value
        End Set
    End Property
    Public Property ModoAbertura As Long
        Get
            If _ModoAbertura = Nothing Then
                _ModoAbertura = 0
            End If
            Return _ModoAbertura
        End Get
        Set(ByVal value As Long)
            _ModoAbertura = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                    TxtFollowUP.Visible = False
                    LblFollowUPLbl.Text = "<br><br>"
                    BtnSolicitacao.Visible = True
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    Call CarregaDropDowns()
                    Call CarregaInformacoesComplementares()
                    If ModoAbertura = 1 Then
                        If Not String.IsNullOrEmpty(Session("SCodEmitente")) Then
                            TxtCliente.Text = Session("SCodEmitente")
                            Call CodigoClienteMudou(True, "")
                            If Not String.IsNullOrEmpty(Session("SCNPJEmitente")) Then
                                If DdlCNPJ.Items.FindByValue(Session("SCNPJEmitente")) IsNot Nothing Then
                                    DdlCNPJ.SelectedValue = Session("SCNPJEmitente")
                                    Call CNPJMudou("")
                                End If
                            End If
                        End If
                    End If
                    TxtFollowUP.Visible = True
                End If
            Else
                Call ChecaPesquisaCliente()
                Call ChecaEdicaoContato()
            End If
            Call MostraNomeCliente()

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub ChecaPesquisaCliente()
        Try
            Dim CodClientePesquisado As String
            Dim alterouCodCliente As Long

            If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
                alterouCodCliente = Session("SAlterouCodCliente")
            Else
                alterouCodCliente = 0
            End If

            CodClientePesquisado = Session("SCodClientePesquisado")

            If Not String.IsNullOrEmpty(CodClientePesquisado) Then
                If alterouCodCliente > 0 Then
                    If TxtCliente.Text <> CodClientePesquisado Then
                        TxtCliente.Text = CodClientePesquisado
                        Call CodigoClienteMudou(True, "")
                    End If
                    Session("SAlterouCodCliente") = alterouCodCliente - 2
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChecaEdicaoContato()
        Try
            Dim CodContatoRetornado As String
            Dim recarregaContatos As Long

            If Not String.IsNullOrEmpty(Session("SRecarregaDdlContatos")) Then
                recarregaContatos = Session("SRecarregaDdlContatos")
            Else
                recarregaContatos = 0
            End If

            If recarregaContatos > 0 Then
                CodContatoRetornado = Session("SCodContatoNegociacao")
                Call CarregaContato()
                If Not String.IsNullOrEmpty(CodContatoRetornado) Then
                    DdlContato.SelectedValue = CodContatoRetornado
                    Call ContatoSelecionadoMudou()
                End If
                Session("SRecarregaDdlContatos") = recarregaContatos - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CarregaInformacoesComplementares()
        Try
            Dim objAnalista As New UCLAnalista
            Dim objParametrosManutencao As New UCLParametrosManutencao
            Dim prazo As Long
            Dim encerramento As Date
            Dim hoje As DateTime
            objAnalista.Codigo = Session("GlCodUsuario")
            If objAnalista.Buscar() Then
                prazo = objAnalista.PrazoResolucao
            Else
                prazo = 0
            End If

            hoje = System.DateTime.Now

            encerramento = F_DateAdd(hoje, "d", prazo, "s")

            LblCodUsuario.Text = Session("GlCodUsuario")
            LblUsuario.Text = Session("GlNomeUsuario")
            TxtData.Text = hoje.ToString("dd/MM/yyyy")
            TxtHora.Text = hoje.TimeOfDay.Hours.ToString.PadLeft(2, "0") + ":" + hoje.TimeOfDay.Minutes.ToString.PadLeft(2, "0")

            'TxtDataPrevisaoFim.Text = encerramento.ToString("dd/MM/yyyy")
            'TxtHoraPrevisaoFim.Text = "23:59"

            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
            'If Not String.IsNullOrEmpty(objParametrosManutencao.CodStatusInicial) Then
            'If DdlStatus.Items.FindByValue(objParametrosManutencao.CodStatusInicial) IsNot Nothing Then
            DdlStatus.SelectedValue = 1 'objParametrosManutencao.CodStatusInicial
            'End If
            'End If

            If Not String.IsNullOrEmpty(objParametrosManutencao.GetConteudo("tipo_chamado_padrao")) Then
                DdlTipo.SelectedValue = objParametrosManutencao.GetConteudo("tipo_chamado_padrao")
            End If

            If DdlAnalista.Items.FindByValue(objAnalista.Codigo) IsNot Nothing Then
                DdlAnalista.SelectedValue = objAnalista.Codigo
            End If

            If Session("SAssuntoChamado") IsNot Nothing Then
                TxtAssunto.Text = Session("SAssuntoChamado")
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
        Dim objFollowUp As New UCLAtendimentoFollowUp(StrConexaoUsuario(Session("GlUsuario")))
        Try
            If IsDigitacaoOk() Then
                If Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    Session("SCodAtendimento") = LblNrAtendimento.Text
                End If

                objAtendimento.Empresa = Session("GlEmpresa")
                objAtendimento.CodChamado = LblNrAtendimento.Text

                If Acao = "ALTERAR" Then
                    objAtendimento.Buscar()
                End If

                objAtendimento = CarregaObjeto(objAtendimento)

                If Acao = "ALTERAR" Then
                    objAtendimento.Alterar(Session("GlEmpresa"), Session("GlEstabelecimento"), objAtendimento.CodChamado)
                ElseIf Acao = "INCLUIR" Then
                    objAtendimento.Incluir(Session("GlEmpresa"), Session("GlEstabelecimento"), objAtendimento.CodChamado)
                    Session("SAcao") = "ALTERAR"

                    If Not String.IsNullOrEmpty(TxtFollowUP.Text) Then
                        objFollowUp.Empresa = objAtendimento.Empresa
                        objFollowUp.CodChamado = objAtendimento.CodChamado
                        objFollowUp.SeqFollowUP = objFollowUp.GetProximoCodigo()
                        objFollowUp.CodUsuario = Session("GlCodUsuario")
                        objFollowUp.DataFollowUp = Now.ToString("dd/MM/yyyy")
                        objFollowUp.Descricao = TxtFollowUP.Text.GetValidInputContent
                        objFollowUp.Email = "N"
                        objFollowUp.HoraFollowUp = Now.ToString("HH:mm")
                        objFollowUp.Tipo = 2
                        objFollowUp.Incluir()
                        TxtFollowUP.Visible = False
                        LblFollowUPLbl.Text = "<br><br>"
                    End If

                End If

                Dim objEmailChamado As New UCLEmailChamado
                Dim seq As String = Session("SSequenciaEmail").ToString()

                If Not String.IsNullOrEmpty(seq) AndAlso IsNumeric(seq) AndAlso seq > 0 Then
                    If Not objEmailChamado.Buscar(Session("GlEmpresa"), seq, objAtendimento.CodChamado) Then
                        objEmailChamado.Incluir()
                    End If
                End If

                LblErro.Text = "Os dados foram salvos com sucesso."
                BtnSolicitacao.Visible = True

                If objAtendimento.ChecaEnvioEmailStatus Then
                    objAtendimento.EnviaEmailStatus(StrConexaoUsuario(Session("GlUsuario")), Session("GlEmpresa"), objAtendimento.CodChamado)
                End If

            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub CarregaDropDowns()
        Try
            Call CarregaTipoChamado()
            Call CarregaStatus()
            Call CarregaAnalista()
            Call CarregaSistema()
            Call CarregaModulo()
            Call CarregaSLA()
            Call CarregaPrazos()
            Call TipoChamadoMudou()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaContratos(ByVal codContrato As String)
        Try
            Dim objContrato As New UCLContratoManutencao
            objContrato.FillDropDown(DdlContrato, True, "(não selecionado)", TxtCliente.Text, DdlCNPJ.SelectedValue, Session("GlEmpresa"), codContrato)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaStatus()
        Try
            Dim objStatusChamado As New UCLStatusChamado
            objStatusChamado.FillDropDown(DdlStatus, True, "(selecione)", "-1", UCLStatusChamado.TipoDropDown.SubSeq, CodStatus)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaTipoChamado()
        Try
            Dim objTipoChamado As New UCLTipoChamado
            objTipoChamado.FillDropDown(Session("GlEmpresa"), DdlTipo, True, "(selecione)", "-1")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaAnalista()
        Try
            Dim objAnalista As New UCLAnalista
            objAnalista.FillDropDown(DdlAnalista, True, "(selecione)", "-1", True, False, CodAnalista, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Property CodStatus() As String
        Get
            If String.IsNullOrEmpty(LblCodStatus.Text) Then
                LblCodStatus.Text = "-1"
            End If
            Return LblCodStatus.Text
        End Get
        Set(ByVal value As String)
            LblCodStatus.Text = value
        End Set
    End Property

    Private Property CodAnalista() As String
        Get
            If String.IsNullOrEmpty(LblCodAnalista.Text) Then
                LblCodAnalista.Text = "-1"
            End If
            Return LblCodAnalista.Text
        End Get
        Set(ByVal value As String)
            LblCodAnalista.Text = value
        End Set
    End Property

    Private Sub CarregaContato()
        Dim objContato As New UCLContato
        If Not String.IsNullOrEmpty(TxtCliente.Text) Then
            objContato.CodEmitente = TxtCliente.Text
            objContato.FillDropDown(DdlContato, True, "", "-1")
            DdlContato.DataBind()
        End If
    End Sub

    Private Sub CarregaCNPJ()
        Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
        If Not String.IsNullOrEmpty(TxtCliente.Text) Then
            objEnderecoEmitente.CodEmitente = TxtCliente.Text
            objEnderecoEmitente.FillDropDownCNPJ(DdlCNPJ, True)
        End If
    End Sub

    Private Sub CarregaInfoContato()
        Dim objContato As New UCLContato
        If Not String.IsNullOrEmpty(TxtCliente.Text) And Not String.IsNullOrEmpty(DdlContato.SelectedValue) Then
            objContato.CodEmitente = TxtCliente.Text
            objContato.Codigo = DdlContato.SelectedValue
            objContato.Buscar()
            LblEmail.Text = objContato.Email
        End If
    End Sub

    Protected Sub ContatoSelecionadoMudou()
        Session("SCodContatoNegociacao") = DdlContato.SelectedValue
        Call CarregaInfoContato()
    End Sub

    Protected Sub DdlContato_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlContato.SelectedIndexChanged
        Call ContatoSelecionadoMudou()
    End Sub

    Protected Sub CodigoClienteMudou(ByVal procCompleto As Boolean, ByVal codContrato As String)
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim qtdTitulosEmAberto As Long
        Dim diasInadimplente As Long

        If procCompleto Then
            Call CarregaCNPJ()
            Call CarregaContato()
            Call CarregaContratos(codContrato)
        End If

        objEmitente.CodEmitente = TxtCliente.Text
        objEmitente.Buscar()
        LblNomeCliente.Text = objEmitente.Nome

        If procCompleto Then
            DdlContato.SelectedValue = -1
            Call ContatoSelecionadoMudou()
            LblEmail.Text = ""
        End If

        Session("SCodEmitenteNegociacao") = TxtCliente.Text
        Session("SCodClientePesquisado") = TxtCliente.Text

        qtdTitulosEmAberto = objEmitente.TitulosEmAbertoVencidos(Session("GlEmpresa"))
        diasInadimplente = objEmitente.DiasInadimplente(Session("GlEmpresa"))
        If qtdTitulosEmAberto > 0 AndAlso diasInadimplente > 0 Then
            LblInadimplente.Text = "ATENÇÃO: Cliente possui " + qtdTitulosEmAberto.ToString + " título(s) em aberto e está inadimplente há " + diasInadimplente.ToString + " dia(s)."
        Else
            LblInadimplente.Text = ""
        End If

        If procCompleto Then
            Call CNPJMudou(codContrato)
        End If

    End Sub

    Private Sub CarregaSistema()
        Dim objSistema As New UCLSistema
        objSistema.FillDropDown(DdlSistema)
    End Sub

    Private Sub CarregaModulo()
        Dim objModulo As New UCLModulo
        objModulo.FillDropDown(DdlModulo)
    End Sub

    Protected Sub CarregaPrazos()
        Try
            Dim ObjSLA As New UCLSLA
            Dim prazoEncerramento As Long
            Dim dataChamado As DateTime
            Dim dataEncerramentoPrevisto As DateTime
            Dim dif As Long

            If DdlSLA.Items.Count = 0 Then
                Return
            End If

            ObjSLA.CodSLA = DdlSLA.SelectedValue
            ObjSLA.Buscar()

            If IsNumeric(ObjSLA.PrazoEncerramento) Then
                prazoEncerramento = ObjSLA.PrazoEncerramento
            Else
                prazoEncerramento = 0
            End If

            If String.IsNullOrWhiteSpace(TxtHora.Text) Then
                If Acao = "INCLUIR" Then
                    TxtHora.Text = Now.ToString("HH:mm")
                End If
            End If

            If isValidDate(TxtData.Text) Then
                If String.IsNullOrEmpty(TxtHora.Text) Then
                    dataChamado = New DateTime(CDate(TxtData.Text).Year, CDate(TxtData.Text).Month, CDate(TxtData.Text).Day)
                Else
                    dataChamado = New DateTime(CDate(TxtData.Text).Year, CDate(TxtData.Text).Month, CDate(TxtData.Text).Day, CLng(TxtHora.Text.Substring(0, 2)), CLng(TxtHora.Text.Substring(3, 2)), 0)
                End If
            Else
                dataChamado = Now()
            End If

            If dataChamado.Hour < 8 Then
                dataChamado = New DateTime(dataChamado.Year, dataChamado.Month, dataChamado.Day, 8, 0, 0)
            ElseIf dataChamado.Hour >= 18 Then
                dataChamado.AddDays(1)
                dataChamado = New DateTime(dataChamado.Year, dataChamado.Month, dataChamado.Day, 8, 0, 0)
            End If

            dataEncerramentoPrevisto = dataChamado.AddHours(prazoEncerramento)

            If dataEncerramentoPrevisto.Hour >= 18 Then
                dif = DateDiff(DateInterval.Minute, dataEncerramentoPrevisto, New DateTime(dataEncerramentoPrevisto.Year, dataEncerramentoPrevisto.Month, dataEncerramentoPrevisto.Day, 18, 0, 0))
                dataEncerramentoPrevisto = dataEncerramentoPrevisto.AddDays(1)
                dataEncerramentoPrevisto = New DateTime(dataEncerramentoPrevisto.Year, dataEncerramentoPrevisto.Month, dataEncerramentoPrevisto.Day, 8, 0, 0).AddMinutes(dif * -1)
            End If

            If dataEncerramentoPrevisto.DayOfWeek = DayOfWeek.Saturday Or dataEncerramentoPrevisto.DayOfWeek = DayOfWeek.Sunday Then
                dataEncerramentoPrevisto = dataEncerramentoPrevisto.AddHours(48)
            End If

            TxtDataPrevisaoFim.Text = dataEncerramentoPrevisto.ToString("dd/MM/yyyy")
            TxtHoraPrevisaoFim.Text = dataEncerramentoPrevisto.ToString("HH:mm")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub TxtCliente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCliente.TextChanged
        Call CodigoClienteMudou(True, "")
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        Try
            Dim objStatusChamado As New UCLStatusChamado
            Dim objParametrosManutencao As New UCLParametrosManutencao
            Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim tmpChamado As String
            LblErro.Text = ""

            If String.IsNullOrEmpty(TxtData.Text) Then
                LblErro.Text += "Preencha o campo Abertura.<br/>"
            ElseIf Not isValidDate(TxtData.Text) Then
                LblErro.Text += "Preencha corretamente o campo Abertura.<br/>"
            End If

            If Not String.IsNullOrEmpty(TxtDataPrevisaoFim.Text) Then
                If Not isValidDate(TxtDataPrevisaoFim.Text) Then
                    LblErro.Text += "Preencha corretamente o campo Data Previsão.<br/>"
                End If
            End If

            If DdlStatus.SelectedValue = "-1" Then
                LblErro.Text += "Preencha o campo Status.<br/>"
            End If

            If String.IsNullOrEmpty(TxtAssunto.Text) Then
                LblErro.Text += "Preencha o campo Assunto.<br/>"
            End If

            If DdlAnalista.SelectedValue = "-1" Then
                LblErro.Text += "Preencha o campo Analista.<br/>"
            End If

            If String.IsNullOrEmpty(TxtCliente.Text) Then
                LblErro.Text += "Preencha o campo Cliente.<br/>"
            End If

            If Not String.IsNullOrEmpty(TxtOSCliente.Text) Then
                tmpChamado = objAtendimento.GetNumeroChamado(Session("GlEmpresa"), TxtCliente.Text, TxtOSCliente.Text.Trim)
                If Not String.IsNullOrEmpty(tmpChamado) AndAlso tmpChamado.Trim <> CodAtendimento.Trim Then
                    LblErro.Text += "ATENÇÃO: O número da OS Cliente que você informou (" + TxtOSCliente.Text + ") já consta no atendimento nº " + tmpChamado + ". Não é permitido incluir a mesma OS Cliente mais de uma vez. <br/>"
                End If
            End If

            If objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento")) Then
                objStatusChamado.CodStatus = DdlStatus.SelectedValue
                If objStatusChamado.Buscar() Then
                    If objStatusChamado.Tipo = UCLStatusChamado.TipoStatusChamado.Final Then
                        If objParametrosManutencao.GetConteudo("permitir_encerrar_chamado_os_aberta") = "N" Then
                            objAtendimento.Empresa = Session("GlEmpresa")
                            objAtendimento.CodChamado = LblNrAtendimento.Text
                            If objAtendimento.ExistemOSsAbertas() Then
                                LblErro.Text += "Existem OSs não encerradas para este atendimento. Não é permitido encerrar o atendimento antes de encerrar as respectivas OSs.<br/>"
                            End If
                        End If
                    End If
                End If
            End If

            Return LblErro.Text.Trim = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Function CarregaObjeto(ByRef objAtendimento As UCLAtendimento) As UCLAtendimento
        Dim objAtendimentoChk As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
        objAtendimento.CodEmitente = TxtCliente.Text

        If DdlContato.SelectedValue = "-1" OrElse DdlContato.SelectedValue = "0" Then
            objAtendimento.CodContato = ""
        Else
            objAtendimento.CodContato = DdlContato.SelectedValue
        End If

        If DdlAnalista.SelectedValue = "-1" Then
            objAtendimento.CodAnalista = ""
        Else
            objAtendimento.CodAnalista = DdlAnalista.SelectedValue
        End If

        If DdlTipo.SelectedValue = "-1" Then
            objAtendimento.TipoChamado = ""
        Else
            objAtendimento.TipoChamado = DdlTipo.SelectedValue
        End If

        objAtendimento.CodUsuario = Session("GlCodUsuario")

        If DdlStatus.SelectedValue = "-1" Then
            objAtendimento.CodStatus = ""
        Else
            objAtendimento.CodStatus = DdlStatus.SelectedValue
        End If

        If DdlSLA.Items.Count > 0 Then
            objAtendimento.CodSla = DdlSLA.SelectedValue
        End If

        objAtendimento.CodSistema = DdlSistema.SelectedValue
        objAtendimento.CodModulo = DdlModulo.SelectedValue
        objAtendimento.Programa = TxtPrograma.Text.GetValidInputContent
        objAtendimento.CaminhoMenu = TxtCaminhoMenu.Text.GetValidInputContent

        objAtendimento.DataChamado = TxtData.Text
        objAtendimento.HoraChamado = TxtHora.Text
        objAtendimento.DataEncerramentoPrevistaInicio = TxtDataPrevisaoFim.Text
        objAtendimento.HoraEncerramentoPrevistaInicio = TxtHoraPrevisaoFim.Text
        objAtendimento.DataEncerramentoPrevista = TxtDataPrevisaoFim.Text
        objAtendimento.HoraEncerramentoPrevista = TxtHoraPrevisaoFim.Text
        objAtendimento.Assunto = TxtAssunto.Text.GetValidInputContent
        objAtendimento.OSCliente = TxtOSCliente.Text.GetValidInputContent
        objAtendimento.Observacao = TxtObservacao.Text.GetValidInputContent
        objAtendimento.Cnpj = DdlCNPJ.SelectedValue
        objAtendimento.CodVeiculo = ""

        objAtendimento.DataLiberacaoOSTEF = txtLiberacaoOSTEF.Text
        objAtendimento.DataInstalacaoTEF = TxtInstalacaoTEF.Text

        If DdlContrato.SelectedValue <> "-1" Then
            objAtendimento.Contrato = DdlContrato.SelectedValue
        Else
            objAtendimento.Contrato = ""
        End If


        'Testa se é para gerar e-mail ou não
        objAtendimento.ChecaEnvioEmailStatus = False
        objAtendimentoChk.Empresa = objAtendimento.Empresa
        objAtendimentoChk.CodChamado = objAtendimento.CodChamado
        If objAtendimentoChk.Buscar() Then
            If Not String.IsNullOrEmpty(objAtendimento.CodStatus) And Not String.IsNullOrEmpty(objAtendimentoChk.CodStatus) Then
                If objAtendimento.CodStatus <> objAtendimentoChk.CodStatus Then
                    objAtendimento.ChecaEnvioEmailStatus = True
                End If
            End If
        Else
            objAtendimento.ChecaEnvioEmailStatus = True
        End If

        Return objAtendimento
    End Function

    Private Sub MostraNomeCliente()
        Try
            Dim objClienteFinanceiro As New UCLClienteFinanceiro()
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEmitenteEndereco As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
            If Not String.IsNullOrEmpty(TxtCliente.Text) Then
                objEmitente.CodEmitente = TxtCliente.Text
                objEmitente.Buscar()
                LblNomeCliente.Text = objEmitente.Nome
            End If
            If Not String.IsNullOrEmpty(DdlCNPJ.SelectedValue) Then
                objEmitenteEndereco.CodEmitente = TxtCliente.Text
                objEmitenteEndereco.CNPJ = DdlCNPJ.SelectedValue
                objEmitenteEndereco.Buscar()
                LblTelefone.Text = objEmitenteEndereco.Fone1
                If Not String.IsNullOrEmpty(objEmitenteEndereco.Fone2) Then
                    LblTelefone.Text += " / " + objEmitenteEndereco.Fone2
                End If
            End If
            If Not String.IsNullOrEmpty(TxtCliente.Text) Then
                objClienteFinanceiro.Empresa = Session("GlEmpresa")
                objClienteFinanceiro.CodEmitente = TxtCliente.Text
                objClienteFinanceiro.Buscar()

                If Not String.IsNullOrEmpty(objClienteFinanceiro.CodParceiro) Then
                    objEmitente.CodEmitente = objClienteFinanceiro.CodParceiro
                    objEmitente.Buscar()
                    LblParceiro.Text = objEmitente.NomeAbreviado
                    LblValorRepasse.Text = objClienteFinanceiro.ValorRepasseParceiro
                Else
                    LblParceiro.Text = ""
                    LblValorRepasse.Text = ""
                End If

                If Not String.IsNullOrEmpty(objClienteFinanceiro.CodAdquirenteTef) Then
                    objEmitente.CodEmitente = objClienteFinanceiro.CodAdquirenteTef
                    objEmitente.Buscar()
                    LblAdquirentePrincipal.Text = objEmitente.NomeAbreviado
                Else
                    LblAdquirentePrincipal.Text = ""
                End If

                If Not String.IsNullOrEmpty(objClienteFinanceiro.CodProvedorTef) Then
                    objEmitente.CodEmitente = objClienteFinanceiro.CodProvedorTef
                    objEmitente.Buscar()
                    LblProvedorTEF.Text = objEmitente.NomeAbreviado
                Else
                    LblProvedorTEF.Text = ""
                End If
            Else
                LblParceiro.Text = ""
                LblValorRepasse.Text = ""
                LblAdquirentePrincipal.Text = ""
                LblProvedorTEF.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
        Dim objUsuario As New UCLUsuario
        Dim objAnalistaEditando As New UCLAnalista
        Dim permiteAlterarDataAberturaChamado As Boolean
        LblNrAtendimento.Text = CodAtendimento

        objAtendimento.Empresa = Session("GlEmpresa")
        objAtendimento.CodChamado = CodAtendimento
        objAtendimento.Buscar()

        TxtData.Text = objAtendimento.DataChamado
        TxtHora.Text = objAtendimento.HoraChamado
        LblDataEncerramento.Text = objAtendimento.DataEncerramento
        LblHoraEncerramento.Text = objAtendimento.HoraEncerramento
        TxtDataPrevisaoFim.Text = objAtendimento.DataEncerramentoPrevista
        TxtHoraPrevisaoFim.Text = objAtendimento.HoraEncerramentoPrevista
        CodStatus = objAtendimento.CodStatus
        CodAnalista = objAtendimento.CodAnalista

        TxtInstalacaoTEF.Text = objAtendimento.DataInstalacaoTEF
        txtLiberacaoOSTEF.Text = objAtendimento.DataLiberacaoOSTEF

        TxtCliente.Text = objAtendimento.CodEmitente
        Call CodigoClienteMudou(False, objAtendimento.Contrato)

        Call CarregaCNPJ()
        DdlCNPJ.SelectedValue = objAtendimento.Cnpj
        'Necessário para que a alteração de emitente funcione via tela do chamado, não retirar
        '----------------------------------------------
        Session("SCNPJEmitente") = objAtendimento.Cnpj
        '----------------------------------------------

        Call CarregaContato()
        If Not String.IsNullOrEmpty(objAtendimento.CodContato) Then
            DdlContato.SelectedValue = objAtendimento.CodContato
            Call ContatoSelecionadoMudou()
        End If

        Call CarregaContratos(objAtendimento.Contrato)
        If DdlContrato.Items.FindByValue(objAtendimento.Contrato) IsNot Nothing Then
            DdlContrato.SelectedValue = objAtendimento.Contrato
        End If

        Call CarregaDropDowns()

        If Not String.IsNullOrEmpty(objAtendimento.TipoChamado) Then
            DdlTipo.SelectedValue = objAtendimento.TipoChamado
        End If
        If Not String.IsNullOrEmpty(objAtendimento.CodStatus) Then
            DdlStatus.SelectedValue = objAtendimento.CodStatus
        End If
        If Not String.IsNullOrEmpty(objAtendimento.CodAnalista) Then
            DdlAnalista.SelectedValue = objAtendimento.CodAnalista
        End If

        TxtAssunto.Text = objAtendimento.Assunto
        TxtOSCliente.Text = objAtendimento.OSCliente
        TxtObservacao.Text = objAtendimento.Observacao
        LblCodUsuario.Text = objAtendimento.CodUsuario
        objUsuario.CodUsuario = objAtendimento.CodUsuario
        objUsuario.BuscarPorCodigo()
        LblUsuario.Text = objUsuario.NomeUsuario

        objAnalistaEditando.Codigo = Session("GlCodUsuario")
        If objAnalistaEditando.Buscar() Then
            If objAnalistaEditando.PermiteAlterarDataAberturaChamado = "S" Then
                permiteAlterarDataAberturaChamado = True
            End If
        End If

        TxtData.Enabled = permiteAlterarDataAberturaChamado
        TxtHora.Enabled = permiteAlterarDataAberturaChamado

        If Not String.IsNullOrEmpty(objAtendimento.CodSistema) Then
            DdlSistema.SelectedValue = objAtendimento.CodSistema
        End If
        If Not String.IsNullOrEmpty(objAtendimento.CodModulo) Then
            DdlModulo.SelectedValue = objAtendimento.CodModulo
        End If
        TxtCaminhoMenu.Text = objAtendimento.CaminhoMenu
        TxtPrograma.Text = objAtendimento.Programa

        If Not String.IsNullOrWhiteSpace(objAtendimento.CodSla) Then
            DdlSLA.SelectedValue = objAtendimento.CodSla
            CarregaPrazos()
        End If

        Call TipoChamadoMudou()

        TxtDataPrevisaoFim.Text = objAtendimento.DataEncerramentoPrevista
        TxtHoraPrevisaoFim.Text = objAtendimento.HoraEncerramentoPrevista

    End Sub

    Private Sub CarregaNovaPK()
        Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
        objAtendimento.Empresa = Session("GlEmpresa")
        LblNrAtendimento.Text = objAtendimento.GetProximoCodigo
    End Sub

    Protected Sub DdlCNPJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlCNPJ.SelectedIndexChanged
        Call CNPJMudou("")
    End Sub

    Private Sub CNPJMudou(ByVal codContrato As String)
        Try
            Dim objEndereco As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))

            'Necessário para que a alteração de emitente funcione via tela da negociação, não retirar
            Session("SCNPJEmitente") = DdlCNPJ.SelectedValue

            objEndereco.CodEmitente = TxtCliente.Text
            objEndereco.CNPJ = DdlCNPJ.SelectedValue
            objEndereco.Buscar()
            LblTelefone.Text = objEndereco.Fone1
            If Not String.IsNullOrEmpty(objEndereco.Fone2) Then
                LblTelefone.Text += " / " + objEndereco.Fone2
            End If
            Call CarregaContratos(codContrato)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CarregaSLA()
        Try
            Dim objSla As New UCLSLA
            objSla.FillDropDown(DdlSLA, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlSLA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlSLA.SelectedIndexChanged
        Call CarregaPrazos()
    End Sub

    Protected Sub BtnSolicitacao_Click(sender As Object, e As EventArgs) Handles BtnSolicitacao.Click
        Try
            Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            objAtendimento.Empresa = Session("GlEmpresa")
            objAtendimento.CodChamado = LblNrAtendimento.Text
            objAtendimento.Buscar()
            LblMensagem.Text = ""
            If objAtendimento.GeraSolicitacaoDesenvolvimento(StrConexaoUsuario(Session("GlUsuario"))) Then
                LblMensagem.Text = "  Solicitação de Desenvolvimento gerada com sucesso!  "
            End If
            Call CarregaFormulario()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub TipoChamadoMudou()
        Try
            If Not String.IsNullOrWhiteSpace(DdlTipo.SelectedValue) Then
                Dim ObjTipoChamado As New UCLTipoChamado
                If ObjTipoChamado.Buscar(Session("GlEmpresa"), DdlTipo.SelectedValue) Then
                    If ObjTipoChamado.GetConteudo("tipo_agendamento") = "2" Then
                        DdlSLA.Enabled = False
                        DdlSLA.Items.Clear()
                        TxtDataPrevisaoFim.Enabled = True
                        TxtDataPrevisaoFim.Text = ""
                        TxtHoraPrevisaoFim.Enabled = True
                        TxtHoraPrevisaoFim.Text = ""
                    Else
                        DdlSLA.Enabled = True
                        Call CarregaSLA()
                        Call CarregaPrazos()
                        TxtDataPrevisaoFim.Enabled = False
                        TxtHoraPrevisaoFim.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlTipo.SelectedIndexChanged
        Try
            Call TipoChamadoMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class