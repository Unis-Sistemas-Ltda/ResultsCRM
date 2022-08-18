Partial Public Class WUCAtendimentoCabecalho_Suporte
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
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    Call CarregaDropDowns()
                    Call CarregaInformacoesComplementares()
                    If ModoAbertura = 1 Then
                        If Not String.IsNullOrEmpty(Session("SCodEmitente")) Then
                            TxtCliente.Text = Session("SCodEmitente")
                            Call CodigoClienteMudou(True, True, "")
                            If Not String.IsNullOrEmpty(Session("SCNPJEmitente")) Then
                                If DdlCNPJ.Items.FindByValue(Session("SCNPJEmitente")) IsNot Nothing Then
                                    DdlCNPJ.SelectedValue = Session("SCNPJEmitente")
                                    Call CNPJMudou(True, "")
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
            GravaLog("WUCAtendimentoCabecalho_Suporte: Page_Load " + vbCr + vbLf + ex.ToString)
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
                        Call CodigoClienteMudou(True, True, "")
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

            TxtDataPrevisaoInicio.Text = encerramento.ToString("dd/MM/yyyy")
            TxtHoraPrevisaoInicio.Text = "23:59"
            TxtDataPrevisaoFim.Text = encerramento.ToString("dd/MM/yyyy")
            TxtHoraPrevisaoFim.Text = "23:59"

            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
            If Not String.IsNullOrEmpty(objParametrosManutencao.GetConteudo("cod_status_inicial")) Then
                If DdlStatus.Items.FindByValue(objParametrosManutencao.GetConteudo("cod_status_inicial")) IsNot Nothing Then
                    DdlStatus.SelectedValue = objParametrosManutencao.GetConteudo("cod_status_inicial")
                End If
            End If

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
        Dim objContrato As New UCLContratoManutencao
        Dim horasContratadas As Double = 0
        Dim horasConsumidas As Double = 0
        Dim acaoIncluir As Boolean = False
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then

                    objAtendimento.Empresa = Session("GlEmpresa")
                    objAtendimento.CodChamado = LblNrAtendimento.Text

                    objAtendimento.Buscar()

                    objAtendimento = CarregaObjeto(objAtendimento)

                    objAtendimento.Alterar(Session("GlEmpresa"), Session("GlEstabelecimento"), objAtendimento.CodChamado)
                ElseIf Acao = "INCLUIR" Then

                    Call CarregaNovaPK()
                    Session("SCodAtendimento") = LblNrAtendimento.Text

                    objAtendimento.Empresa = Session("GlEmpresa")
                    objAtendimento.CodChamado = LblNrAtendimento.Text

                    objAtendimento = CarregaObjeto(objAtendimento)

                    acaoIncluir = True
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
                        objFollowUp.CodAcao = "null"
                        objFollowUp.Incluir()
                        TxtFollowUP.Visible = False
                        LblFollowUPLbl.Text = "<br><br>"
                    End If

                End If

                Dim objEmailChamado As New UCLEmailChamado
                Dim seq As String

                If Not IsNothing(Session("SSequenciaEmail")) Then
                    seq = Session("SSequenciaEmail").ToString()
                Else
                    seq = 0
                End If

                If Not String.IsNullOrEmpty(seq) AndAlso IsNumeric(seq) AndAlso seq > 0 Then
                    If Not objEmailChamado.Buscar(Session("GlEmpresa"), seq, objAtendimento.CodChamado) Then
                        objEmailChamado.Incluir()
                    End If
                End If

                LblErro.Text = "Os dados foram salvos com sucesso."

                If objAtendimento.ChecaEnvioEmailStatus Then
                    objAtendimento.EnviaEmailStatus(StrConexaoUsuario(Session("GlUsuario")), Session("GlEmpresa"), objAtendimento.CodChamado)
                End If

                If acaoIncluir Then
                    Dim codContrato As String = DdlContrato.SelectedValue
                    Dim dataIni As Date
                    Dim dataFim As Date
                    dataIni = CDate(TxtData.Text)
                    dataIni = New Date(Year(dataIni), Month(dataIni), 1)
                    dataFim = dataIni.AddMonths(1).AddDays(-1)
                    horasContratadas = objContrato.GetQuantidadeHorasContratada(Session("GlEmpresa"), codContrato)
                    horasConsumidas = objContrato.GetQuantidadeHorasConsumidaNoPeriodo(Session("GlEmpresa"), Session("GlEstabelecimento"), codContrato, dataIni, dataFim)

                    If horasContratadas > 0 AndAlso horasConsumidas > 0 Then
                        If (horasConsumidas / horasContratadas) * 100 >= 100 Then
                            objAtendimento.EnviaEmailConsumoHoras(StrConexaoUsuario(Session("GlUsuario")), Session("GlEmpresa"), objAtendimento.CodChamado)
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            GravaLog("WUCAtendimentoCabecalho_Suporte: BtnGravar_Click " + vbCr + vbLf + ex.ToString)
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub CarregaDropDowns()
        Call CarregaTipoChamado()
        Call CarregaStatus()
        Call CarregaAnalista()
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
            objEnderecoEmitente.FillDropDownCNPJ(DdlCNPJ)
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

    Protected Sub CodigoClienteMudou(ByVal procCompleto As Boolean, ByVal verificaHoras As Boolean, ByVal codContrato As String)
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim qtdTitulosEmAberto As Long
        Dim diasInadimplente As Long
        Dim objParametrosManutencao As New UCLParametrosManutencao

        If procCompleto Then
            Call CarregaCNPJ()
            Call CarregaContato()
            Call CarregaContratos(verificaHoras, codContrato)
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
            objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
            If Not objParametrosManutencao.IsNull("mensagem_cliente_inadimplente_chamado") AndAlso objParametrosManutencao.GetConteudo("mensagem_cliente_inadimplente_chamado") = "S" Then
                LblInadimplente.Text = "Cliente possui " + qtdTitulosEmAberto.ToString + " título(s) em aberto e está inadimplente há " + diasInadimplente.ToString + " dias"
                If diasInadimplente <= 30 Then
                    LblInadimplente.ForeColor = Drawing.Color.Black
                End If
            Else
                LblInadimplente.Text = ""
            End If
        Else
            LblInadimplente.Text = ""
        End If

        If procCompleto Then
            Call CNPJMudou(verificaHoras, codContrato)
        End If

    End Sub

    Protected Sub TxtCliente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCliente.TextChanged
        Call CodigoClienteMudou(True, True, "")
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        Try
            Dim objStatusChamado As New UCLStatusChamado
            Dim objParametrosManutencao As New UCLParametrosManutencao
            Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim tmpChamado As String
            LblErro.Text = ""

            If String.IsNullOrEmpty(TxtData.Text) Then
                LblErro.Text += "Preencha o campo Data.<br/>"
            ElseIf Not isValidDate(TxtData.Text) Then
                LblErro.Text += "Preencha corretamente o campo Data.<br/>"
            End If

            If String.IsNullOrEmpty(TxtDataPrevisaoInicio.Text) Then
                LblErro.Text += "Preencha o campo Data Previsão (Início).<br/>"
            ElseIf Not isValidDate(TxtDataPrevisaoInicio.Text) Then
                LblErro.Text += "Preencha corretamente o campo Data Previsão (Início).<br/>"
            End If

            If String.IsNullOrEmpty(TxtDataPrevisaoFim.Text) Then
                LblErro.Text += "Preencha o campo Data Previsão (Término).<br/>"
            ElseIf Not isValidDate(TxtDataPrevisaoFim.Text) Then
                LblErro.Text += "Preencha corretamente o campo Data Previsão (Término).<br/>"
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

            If String.IsNullOrEmpty(DdlContato.SelectedValue) Then
                LblErro.Text += "Preencha o campo Contato.<br/>"
            Else
                If DdlContato.SelectedValue = "0" OrElse DdlContato.SelectedValue = "-1" Then
                    LblErro.Text += "Preencha o campo Contato.<br/>"
                End If
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

        If DdlContrato.SelectedValue <> "-1" Then
            objAtendimento.Contrato = DdlContrato.SelectedValue
        Else
            objAtendimento.Contrato = ""
        End If

        objAtendimento.CodUsuario = Session("GlCodUsuario")

        If DdlStatus.SelectedValue = "-1" Then
            objAtendimento.CodStatus = ""
        Else
            objAtendimento.CodStatus = DdlStatus.SelectedValue
        End If

        objAtendimento.DataChamado = TxtData.Text
        objAtendimento.HoraChamado = TxtHora.Text
        objAtendimento.DataEncerramentoPrevistaInicio = TxtDataPrevisaoInicio.Text
        objAtendimento.HoraEncerramentoPrevistaInicio = TxtHoraPrevisaoInicio.Text
        objAtendimento.DataEncerramentoPrevista = TxtDataPrevisaoFim.Text
        objAtendimento.HoraEncerramentoPrevista = TxtHoraPrevisaoFim.Text
        objAtendimento.Assunto = TxtAssunto.Text.GetValidInputContent
        objAtendimento.OSCliente = TxtOSCliente.Text.GetValidInputContent
        objAtendimento.Observacao = TxtObservacao.Text.GetValidInputContent
        objAtendimento.Cnpj = DdlCNPJ.SelectedValue
        objAtendimento.CodVeiculo = ""

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
        TxtDataPrevisaoInicio.Text = objAtendimento.DataEncerramentoPrevistaInicio
        TxtHoraPrevisaoInicio.Text = objAtendimento.HoraEncerramentoPrevistaInicio
        TxtDataPrevisaoFim.Text = objAtendimento.DataEncerramentoPrevista
        TxtHoraPrevisaoFim.Text = objAtendimento.HoraEncerramentoPrevista
        CodStatus = objAtendimento.CodStatus
        CodAnalista = objAtendimento.CodAnalista

        TxtCliente.Text = objAtendimento.CodEmitente
        Call CodigoClienteMudou(False, False, objAtendimento.Contrato)

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

        Call CarregaContratos(False, objAtendimento.Contrato)
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

    End Sub

    Private Sub CarregaNovaPK()
        Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
        objAtendimento.Empresa = Session("GlEmpresa")
        LblNrAtendimento.Text = objAtendimento.GetProximoCodigo
    End Sub

    Protected Sub DdlCNPJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlCNPJ.SelectedIndexChanged
        Call CNPJMudou(True, "")
    End Sub

    Private Sub CNPJMudou(ByVal verificaHoras As Boolean, ByVal codContrato As String)
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
            Call CarregaContratos(verificaHoras, codContrato)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CarregaContratos(ByVal verificaHoras As Boolean, ByVal codContrato As String)
        Try
            Dim objContrato As New UCLContratoManutencao
            objContrato.FillDropDown(DdlContrato, True, "(não selecionado)", TxtCliente.Text, DdlCNPJ.SelectedValue, Session("GlEmpresa"), codContrato)
            If DdlContrato.Items.Count = 2 Then
                DdlContrato.SelectedValue = DdlContrato.Items.Item(1).Value
                If verificaHoras Then
                    Call VerificaHorasExtrapoladasContrato()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VerificaHorasExtrapoladasContrato()
        Try
            Dim StrHorasContratadas As String = ""
            Dim StrHorasConsumidas As String = ""
            Dim horasContratadas As Double = 0
            Dim horasConsumidas As Double = 0
            Dim ObjContrato As New UCLContratoManutencao
            Dim codContrato As String = DdlContrato.SelectedValue
            Dim dataIni As Date
            Dim dataFim As Date
            Dim extrapolou As Boolean = False

            dataIni = CDate(TxtData.Text)
            dataIni = New Date(Year(dataIni), Month(dataIni), 1)
            dataFim = dataIni.AddMonths(1).AddDays(-1)

            horasContratadas = ObjContrato.GetQuantidadeHorasContratada(Session("GlEmpresa"), codContrato)
            horasConsumidas = ObjContrato.GetQuantidadeHorasConsumidaNoPeriodo(Session("GlEmpresa"), Session("GlEstabelecimento"), codContrato, dataIni, dataFim)

            If horasContratadas <> 0 AndAlso horasConsumidas >= horasContratadas Then
                extrapolou = True
            End If

            If extrapolou Then
                StrHorasContratadas = Math.Floor(horasContratadas).ToString + "h"
                If Math.Floor(horasContratadas - Math.Floor(horasContratadas)) > 0 Then
                    StrHorasContratadas += " " + Math.Floor(horasContratadas - Math.Floor(horasContratadas)).ToString + "min "
                End If
                StrHorasConsumidas = Math.Floor(horasConsumidas).ToString + "h "
                If Math.Floor(horasConsumidas - Math.Floor(horasConsumidas)) > 0 Then
                    StrHorasConsumidas += " " + Math.Floor(horasConsumidas - Math.Floor(horasConsumidas)).ToString + "min "
                End If
                LblMensagemConfirmacao.Text = "<br>ATENÇÃO:<br><br>Este cliente possui " + StrHorasContratadas + " contratada(s) e consumiu até o momento " + StrHorasConsumidas + ".<br><br>Como a quantidade de horas já ultrapassou o previsto em contrato, as horas referentes a este atendimento serão faturadas para o cliente na geração da próxima fatura.<br><br><b>Cliente precisa autorizar este atendimento.</b><br><br><br>Deseja prosseguir com o atendimento?<br><br>"
                AcertaVisibilidadeComponentesConfirmacaoHorasExtrapoladasContrato(MensagemHorasExtrapoladasContrato.MostrarMensagemDeConfirmacao)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Enum MensagemHorasExtrapoladasContrato As Integer
        MostrarMensagemDeConfirmacao = 1
        EsconderMensagemDeConfirmacao = 2
    End Enum

    Private Sub AcertaVisibilidadeComponentesConfirmacaoHorasExtrapoladasContrato(ByVal tipo As MensagemHorasExtrapoladasContrato)
        Try
            If tipo = MensagemHorasExtrapoladasContrato.EsconderMensagemDeConfirmacao Then
                LblMensagemConfirmacao.Visible = False
                BtnNao.Visible = False
                BtnSim.Visible = False
                DivConfirmacao.Visible = False
                DivConfirmacao.Style.Remove("visibility")
                DivConfirmacao.Style.Remove("background-color")
                DivConfirmacao.Style.Remove("border")
                DivConfirmacao.Style.Add("visibility", "hidden")
            ElseIf tipo = MensagemHorasExtrapoladasContrato.MostrarMensagemDeConfirmacao Then
                LblMensagemConfirmacao.Visible = True
                BtnNao.Visible = True
                BtnSim.Visible = True
                DivConfirmacao.Visible = True
                DivConfirmacao.Style.Remove("visibility")
                DivConfirmacao.Style.Remove("background-color")
                DivConfirmacao.Style.Remove("border")
                DivConfirmacao.Style.Add("background-color", "#FFFFFF")
                DivConfirmacao.Style.Add("border", "1px solid #CCCCCC")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnSim_Click(sender As Object, e As EventArgs) Handles BtnSim.Click
        Call AcertaVisibilidadeComponentesConfirmacaoHorasExtrapoladasContrato(MensagemHorasExtrapoladasContrato.EsconderMensagemDeConfirmacao)
    End Sub

    Protected Sub BtnNao_Click(sender As Object, e As EventArgs) Handles BtnNao.Click
        TxtCliente.Text = "0"
        Call CodigoClienteMudou(True, False, "")
        Call AcertaVisibilidadeComponentesConfirmacaoHorasExtrapoladasContrato(MensagemHorasExtrapoladasContrato.EsconderMensagemDeConfirmacao)
    End Sub

    Protected Sub DdlContrato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlContrato.SelectedIndexChanged
        Call VerificaHorasExtrapoladasContrato()
    End Sub
End Class