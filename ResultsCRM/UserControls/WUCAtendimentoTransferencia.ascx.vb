Partial Public Class WUCAtendimentoTransferencia
    Inherits System.Web.UI.UserControl

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Acao = "TRANSFERIR" Then
                    Call CarregaFormulario()
                End If
            Else
                Call ChecaPesquisaCliente()
                Call ChecaEdicaoContato()
                Call ChecaPesquisaClienteAtendimento()
                Call ChecaPesquisaPontoAtendimento()
                Call ChecaEdicaoContatoAtendimento()
            End If
            Call MostraNomeCliente()
            Call MostraNomeClienteAtendimento()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub ChecaPesquisaCliente()
        Try
            Dim CodClientePesquisado As String
            Dim CnpjClientePesquisado As String
            Dim alterouCodCliente As Long

            If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
                alterouCodCliente = Session("SAlterouCodCliente")
            Else
                alterouCodCliente = 0
            End If

            CodClientePesquisado = Session("SCodClientePesquisado")
            CnpjClientePesquisado = Session("SCNPJClientePesquisado")

            If Not String.IsNullOrEmpty(CodClientePesquisado) Then
                If alterouCodCliente > 0 Then
                    If TxtCliente.Text <> CodClientePesquisado Then
                        TxtCliente.Text = CodClientePesquisado
                        Call CodigoClienteMudou(True)
                    End If
                    If DdlCNPJ.SelectedValue <> CnpjClientePesquisado Then
                        DdlCNPJ.SelectedValue = CnpjClientePesquisado
                        Call CNPJMudou()
                    End If
                    Session("SAlterouCodCliente") = alterouCodCliente - 2
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChecaPesquisaPontoAtendimento()
        Try
            Dim PontoPesquisado As String
            Dim alterouPontoAtendimento As Long

            If Not String.IsNullOrEmpty(Session("SAlterouNumeroPontoAtendimento")) Then
                alterouPontoAtendimento = Session("SAlterouNumeroPontoAtendimento")
            Else
                alterouPontoAtendimento = 0
            End If

            PontoPesquisado = Session("SPontoPesquisado")

            If Not String.IsNullOrEmpty(PontoPesquisado) Then
                If alterouPontoAtendimento > 0 Then
                    If TxtNrPontoAtendimento.Text <> PontoPesquisado Then
                        TxtNrPontoAtendimento.Text = PontoPesquisado
                        Call NrPontoAtendimentoMudou()
                    End If
                    Session("SAlterouNumeroPontoAtendimento") = alterouPontoAtendimento - 2
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChecaPesquisaClienteAtendimento()
        Try
            Dim CodClientePesquisado As String
            Dim cnpjPesquisado As String
            Dim alterouCliente As Long

            If Not String.IsNullOrEmpty(Session("SAlterouCodClienteAt")) Then
                alterouCliente = Session("SAlterouCodClienteAt")
            Else
                alterouCliente = 0
            End If

            CodClientePesquisado = Session("SCodClienteAtPesquisado")
            cnpjPesquisado = Session("SCNPJAtPesquisado")

            If Not String.IsNullOrEmpty(CodClientePesquisado) Then
                If alterouCliente > 0 Then
                    If TxtClienteAtendimento.Text <> CodClientePesquisado Then
                        TxtClienteAtendimento.Text = CodClientePesquisado
                        Call CodigoClienteAtendimentoMudou()
                    End If
                    Session("SAlterouCodClienteAt") = alterouCliente - 2
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

    Private Sub ChecaEdicaoContatoAtendimento()
        Try
            Dim CodContatoRetornado As String
            Dim recarregaContatos As Long

            If Not String.IsNullOrEmpty(Session("SRecarregaDdlContatosAt")) Then
                recarregaContatos = Session("SRecarregaDdlContatosAt")
            Else
                recarregaContatos = 0
            End If

            If recarregaContatos > 0 Then
                CodContatoRetornado = Session("SCodContatoNegociacaoAt")
                Call CarregaContatoAtendimento()
                If Not String.IsNullOrEmpty(CodContatoRetornado) Then
                    DdlContatoAtendimento.SelectedValue = CodContatoRetornado
                    Call ContatoSelecionadoAtendimentoMudou()
                End If
                Session("SRecarregaDdlContatosAt") = recarregaContatos - 1
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
            objAnalista.Codigo = Session("GlCodUsuario")
            If objAnalista.Buscar() Then
                prazo = objAnalista.PrazoResolucao
            Else
                prazo = 0
            End If

            encerramento = F_DateAdd(System.DateTime.Now.Date, "d", prazo, "u")

            LblCodUsuario.Text = Session("GlCodUsuario")
            LblUsuario.Text = Session("GlNomeUsuario")
            TxtData.Text = Now.Date.ToString("dd/MM/yyyy")
            TxtHora.Text = Now.TimeOfDay.Hours.ToString.PadLeft(2, "0") + ":" + Now.TimeOfDay.Minutes.ToString.PadLeft(2, "0")

            LblDataEncerramentoPrevisto.Text = encerramento.ToString("dd/MM/yyyy")
            LblHoraEncerramentoPrevisto.Text = "23:59"

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

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim CodChamadoOriginal As String = ""
        Dim CodChamadoNovo As String = ""
        Dim CodStatusOriginal As String = ""
        Try
            Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objStatusChamado As New UCLStatusChamado()
            If IsDigitacaoOk() Then
                If Acao = "TRANSFERIR" Then
                    CodChamadoOriginal = Session("SCodAtendimento")
                    objAtendimento.Empresa = Session("GlEmpresa")
                    objAtendimento.CodChamado = CodChamadoOriginal
                    objAtendimento.Buscar()
                    CodStatusOriginal = objAtendimento.CodStatus
                    objAtendimento.CodStatus = objStatusChamado.GetFirstCodStatus(UCLStatusChamado.TipoStatusChamado.Cancelado)
                    objAtendimento.Alterar(Session("GlEmpresa"), Session("GlEstabelecimento"), objAtendimento.CodChamado)

                    CodChamadoNovo = objAtendimento.GetProximoCodigo()
                    objAtendimento.CodChamado = CodChamadoNovo
                    objAtendimento = CarregaObjeto(objAtendimento)
                    objAtendimento.CodChamadoOriginal = Session("SCodAtendimento")
                    objAtendimento.Incluir(Session("GlEmpresa"), Session("GlEstabelecimento"), objAtendimento.CodChamado)

                    objAtendimento.TransferirOSs(Session("GlEmpresa"), Session("SCodAtendimento"), objAtendimento.CodChamado)

                    CodChamadoOriginal = ""
                    CodChamadoNovo = ""
                    CodStatusOriginal = ""

                    Response.Redirect("WGAtendimento.aspx")
                End If
            End If
        Catch ex As Exception
            If Not String.IsNullOrWhiteSpace(CodChamadoOriginal) AndAlso Not String.IsNullOrEmpty(CodChamadoNovo) AndAlso Not String.IsNullOrEmpty(CodStatusOriginal) AndAlso ex IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(ex.Message.ToString) Then
                Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
                Dim objStatusChamado As New UCLStatusChamado()
                objAtendimento.Empresa = Session("GlEmpresa")
                objAtendimento.CodChamado = CodChamadoOriginal
                objAtendimento.Buscar()
                objAtendimento.CodStatus = CodStatusOriginal
                objAtendimento.Alterar(Session("GlEmpresa"), objAtendimento.Estabelecimento, objAtendimento.CodChamado)

                objAtendimento.Empresa = Session("GlEmpresa")
                objAtendimento.CodChamado = CodChamadoNovo
                objAtendimento.CodStatus = objStatusChamado.GetFirstCodStatus(UCLStatusChamado.TipoStatusChamado.Cancelado)
                objAtendimento.Observacao = "Erro ao transferir OS"
                objAtendimento.Alterar(Session("GlEmpresa"), objAtendimento.Estabelecimento, objAtendimento.CodChamado)
            End If

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
            objStatusChamado.FillDropDown(DdlStatus, True, "(selecione)", "-1", UCLStatusChamado.TipoDropDown.Completo, CodStatus)
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

    Private Sub CarregaContatoAtendimento()
        Dim objContato As New UCLContato
        If Not String.IsNullOrEmpty(TxtClienteAtendimento.Text) Then
            objContato.CodEmitente = TxtClienteAtendimento.Text
            objContato.NumeroPontoAtendimento = TxtNrPontoAtendimento.Text
            objContato.FillDropDown(DdlContatoAtendimento, True, "", "-1")
            DdlContatoAtendimento.DataBind()
        End If
    End Sub

    Private Sub CarregaCNPJ()
        Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
        If Not String.IsNullOrEmpty(TxtCliente.Text) Then
            objEnderecoEmitente.CodEmitente = TxtCliente.Text
            objEnderecoEmitente.FillDropDownCNPJ(DdlCNPJ, True)
        End If
    End Sub

    Private Sub CarregaInfoContatoAtendimento()
        Dim objContato As New UCLContato
        If Not String.IsNullOrEmpty(TxtClienteAtendimento.Text) And Not String.IsNullOrEmpty(DdlContatoAtendimento.SelectedValue) Then
            objContato.CodEmitente = TxtClienteAtendimento.Text
            objContato.Codigo = DdlContatoAtendimento.SelectedValue
            objContato.Buscar()
            LblEmailAtendimento.Text = objContato.Email
        Else
            LblEmailAtendimento.Text = ""
        End If
    End Sub

    Protected Sub ContatoSelecionadoMudou()
        Session("SCodContatoNegociacao") = DdlContato.SelectedValue
    End Sub

    Protected Sub ContatoSelecionadoAtendimentoMudou()
        Session("SCodContatoNegociacaoAt") = DdlContatoAtendimento.SelectedValue
        Call CarregaInfoContatoAtendimento()
    End Sub

    Protected Sub DdlContato_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlContato.SelectedIndexChanged
        Call ContatoSelecionadoMudou()
    End Sub

    Protected Sub CodigoClienteMudou(ByVal procCompleto As Boolean)
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim qtdTitulosEmAberto As Long
        Dim diasInadimplente As Long

        If procCompleto Then
            Call CarregaCNPJ()
            Call CarregaContato()
        End If

        objEmitente.CodEmitente = TxtCliente.Text
        objEmitente.Buscar()
        LblNomeCliente.Text = objEmitente.Nome

        If procCompleto Then
            DdlContato.SelectedValue = -1
            Call ContatoSelecionadoMudou()
        End If

        Session("SCodEmitenteNegociacao") = TxtCliente.Text
        Session("SCodClientePesquisado") = TxtCliente.Text

        qtdTitulosEmAberto = objEmitente.TitulosEmAbertoVencidos(Session("GlEmpresa"))
        diasInadimplente = objEmitente.DiasInadimplente(Session("GlEmpresa"))
        If qtdTitulosEmAberto > 0 AndAlso diasInadimplente > 0 Then
            LblInadimplente.Text = "Cliente possui " + qtdTitulosEmAberto.ToString + " título(s) em aberto e está inadimplente há " + diasInadimplente.ToString + " dias"
        End If

        If procCompleto Then
            Call CNPJMudou()
        End If

        Call CarregaSLA(TxtCliente.Text, "0")
        Call CarregaPrazos()

    End Sub

    Protected Sub CodigoClienteAtendimentoMudou()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

        Session("SCodEmitenteAtNegociacao") = TxtClienteAtendimento.Text
        Session("SCodClienteAtPesquisado") = TxtClienteAtendimento.Text

        Call NrPontoAtendimentoMudou()

    End Sub

    Protected Sub TxtCliente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCliente.TextChanged
        Call CodigoClienteMudou(True)
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        Try
            Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objStatusChamado As New UCLStatusChamado
            Dim tmpChamado As String
            LblErro.Text = ""

            If String.IsNullOrEmpty(TxtData.Text) Then
                LblErro.Text += "Preencha o campo Data.<br/>"
            ElseIf Not isValidDate(TxtData.Text) Then
                LblErro.Text += "Preencha corretamente o campo Data.<br/>"
            End If


            If String.IsNullOrEmpty(LblDataEncerramentoPrevisto.Text) Then
                LblErro.Text += "Preencha o campo Data Previsão Encerramento.<br/>"
            ElseIf Not isValidDate(LblDataEncerramentoPrevisto.Text) Then
                LblErro.Text += "Preencha corretamente o campo Data Previsão Encerramento.<br/>"
            End If

            If DdlStatus.SelectedValue = "-1" Then
                LblErro.Text += "Preencha o campo Status.<br/>"
            Else
                If GetTipoStatus(DdlStatus.SelectedValue) = "4" Then
                    If String.IsNullOrEmpty(TxtMotivo.Text) Then
                        LblErro.Text += "Preencha o campo Motivo.<br/>"
                    End If
                    If TemOS() Then
                        LblErro.Text += "Para cancelar o atendimento, é necessário que você primeiro exclua as OSs vinculadas.<br/>"
                    End If
                End If
            End If

            If String.IsNullOrEmpty(TxtAssunto.Text) Then
                LblErro.Text += "Preencha o campo Assunto.<br/>"
            End If

            If DdlAnalista.SelectedValue = "-1" Then
                LblErro.Text += "Preencha o campo Analista.<br/>"
            End If

            If String.IsNullOrEmpty(TxtCliente.Text) Then
                LblErro.Text += "Preencha o campo Cliente (Tomador).<br/>"
            End If

            If String.IsNullOrEmpty(TxtClienteAtendimento.Text) Then
                LblErro.Text += "Preencha o campo Cliente (Ponto de Atendimento).<br/>"
            End If

            If Not String.IsNullOrEmpty(TxtOSCliente.Text) Then
                tmpChamado = objAtendimento.GetNumeroChamado(Session("GlEmpresa"), TxtCliente.Text, TxtOSCliente.Text.Trim)
                If Not String.IsNullOrEmpty(tmpChamado) AndAlso tmpChamado.Trim <> CodAtendimento.Trim Then
                    LblErro.Text += "ATENÇÃO: O número do Chamado Cliente que você informou (" + TxtOSCliente.Text + ") já consta no atendimento nº " + tmpChamado + ". Não é permitido incluir o mesmo Chamado Cliente mais de uma vez. <br/>"
                End If
            End If

            objAtendimento.Empresa = Session("GlEmpresa")
            objAtendimento.CodChamado = CodAtendimento
            If objAtendimento.ExistemOSsAbertas() Then
                objStatusChamado.CodStatus = DdlStatus.SelectedValue
                objStatusChamado.Buscar()
                If objStatusChamado.Tipo = 3 Then
                    LblErro.Text += "ERRO: Não é permitido encerrar chamado cujas OS's estão em aberto.<br/>"
                End If
            End If

            Return LblErro.Text.Trim = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetTipoStatus(ByVal CodStatus As String) As String
        Try
            Dim objStatusChamado As New UCLStatusChamado
            objStatusChamado.CodStatus = CodStatus
            objStatusChamado.Buscar()
            Return objStatusChamado.Tipo
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

        If DdlSLA.SelectedValue = "-1" OrElse String.IsNullOrEmpty(DdlSLA.SelectedValue) OrElse DdlSLA.SelectedValue = "0" Then
            objAtendimento.CodSla = ""
        Else
            objAtendimento.CodSla = DdlSLA.SelectedValue
        End If

        If DdlTipo.SelectedValue = "-1" Then
            objAtendimento.TipoChamado = ""
        Else
            objAtendimento.TipoChamado = DdlTipo.SelectedValue
        End If

        objAtendimento.CodUsuario = Session("GlCodUsuario")
        objAtendimento.MotivoCancelamento = TxtMotivo.Text

        If DdlStatus.SelectedValue = "-1" Then
            objAtendimento.CodStatus = ""
        Else
            objAtendimento.CodStatus = DdlStatus.SelectedValue
        End If

        objAtendimento.NumeroPontoAtendimento = TxtNrPontoAtendimento.Text

        If DdlContatoAtendimento.Items.Count = 0 OrElse DdlContatoAtendimento.SelectedValue = "-1" OrElse DdlContatoAtendimento.SelectedValue = "0" Then
            objAtendimento.CodContatoAtendimento = ""
        Else
            objAtendimento.CodContatoAtendimento = DdlContatoAtendimento.SelectedValue
        End If

        objAtendimento.DataChamado = TxtData.Text
        objAtendimento.HoraChamado = TxtHora.Text
        objAtendimento.DataEncerramentoPrevistaInicio = LblDataEncerramentoPrevisto.Text
        objAtendimento.HoraEncerramentoPrevistaInicio = LblHoraEncerramentoPrevisto.Text
        objAtendimento.DataEncerramentoPrevista = LblDataEncerramentoPrevisto.Text
        objAtendimento.HoraEncerramentoPrevista = LblHoraEncerramentoPrevisto.Text
        objAtendimento.DataChegadaPrevista = LblDataChegadaPrevista.Text
        objAtendimento.HoraChegadaPrevista = LblHoraChegadaPrevista.Text
        objAtendimento.DataChegada = LblDataChegada.Text
        objAtendimento.HoraChegada = LblHoraChegada.Text
        objAtendimento.Assunto = TxtAssunto.Text.GetValidInputContent
        objAtendimento.OSCliente = TxtOSCliente.Text.GetValidInputContent
        objAtendimento.Observacao = TxtObservacao.Text.GetValidInputContent
        objAtendimento.Cnpj = DdlCNPJ.SelectedValue
        objAtendimento.CodVeiculo = ""
        objAtendimento.CodEmitenteAtendimento = TxtClienteAtendimento.Text
        objAtendimento.SAG = TxtSAG.Text

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
        If Not String.IsNullOrEmpty(DdlCNPJ.SelectedValue) AndAlso DdlCNPJ.SelectedValue <> "0" Then
            objEmitenteEndereco.CodEmitente = TxtCliente.Text
            objEmitenteEndereco.CNPJ = DdlCNPJ.SelectedValue
            objEmitenteEndereco.Buscar()
            LblNomeCliente.Text = objEmitenteEndereco.NomeAbreviado
        End If
    End Sub

    Private Sub MostraNomeClienteAtendimento()
        Try
            Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objTipoPontoAtendimento As New UCLTipoPontoAtendimento
            If Not String.IsNullOrEmpty(TxtClienteAtendimento.Text) Then
                objPontoAtendimento.CodEmitente = TxtClienteAtendimento.Text
                objPontoAtendimento.NumeroPontoAtendimento = TxtNrPontoAtendimento.Text

                If Not String.IsNullOrEmpty(objPontoAtendimento.CodEmitente) Then
                    objEmitente.CodEmitente = objPontoAtendimento.CodEmitente
                    objEmitente.Buscar()
                    LblRazaoSocialPontoAtendimento.Text = objEmitente.Nome
                End If

                If Not String.IsNullOrEmpty(objPontoAtendimento.CodEmitente) AndAlso Not String.IsNullOrEmpty(objPontoAtendimento.NumeroPontoAtendimento) Then
                    objPontoAtendimento.Buscar()

                    objTipoPontoAtendimento.CodTipoPontoAtendimento = objPontoAtendimento.CodTipoPontoAtendimento
                    If Not String.IsNullOrEmpty(objTipoPontoAtendimento.CodTipoPontoAtendimento) Then
                        objTipoPontoAtendimento.Buscar()
                    End If

                    LblNomePontoAtendimento.Text = objTipoPontoAtendimento.Descricao + "  " + objPontoAtendimento.NumeroPontoAtendimento + " ─ " + objPontoAtendimento.Descricao
                    LblObsPontoAtendimento.Text = objPontoAtendimento.Observacao
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
        Dim objUsuario As New UCLUsuario
        Dim objAnalistaEditando As New UCLAnalista
        Dim permiteAlterarDataAberturaChamado As Boolean = False

        LblNrAtendimento.Text = CodAtendimento

        objAtendimento.Empresa = Session("GlEmpresa")
        objAtendimento.CodChamado = CodAtendimento
        objAtendimento.Buscar()

        LblNrAtendimentoNovo.Text = objAtendimento.GetProximoCodigo()

        TxtData.Text = objAtendimento.DataChamado
        TxtHora.Text = objAtendimento.HoraChamado
        TxtMotivo.Text = objAtendimento.MotivoCancelamento
        LblDataEncerramento.Text = objAtendimento.DataEncerramento
        LblHoraEncerramento.Text = objAtendimento.HoraEncerramento
        CodStatus = objAtendimento.CodStatus
        CodAnalista = objAtendimento.CodAnalista

        'TxtCliente.Text = objAtendimento.CodEmitente
        'Call CodigoClienteMudou(False)

        'Call CarregaCNPJ()
        'DdlCNPJ.SelectedValue = objAtendimento.Cnpj
        'Necessário para que a alteração de emitente funcione via tela do chamado, não retirar
        '----------------------------------------------
        'Session("SCNPJEmitente") = objAtendimento.Cnpj
        '----------------------------------------------

        'Call CarregaContato()
        'If Not String.IsNullOrEmpty(objAtendimento.CodContato) Then
        '   DdlContato.SelectedValue = objAtendimento.CodContato
        '   Call ContatoSelecionadoMudou()
        'End If

        TxtClienteAtendimento.Text = objAtendimento.CodEmitenteAtendimento
        Call CodigoClienteAtendimentoMudou()

        TxtNrPontoAtendimento.Text = objAtendimento.NumeroPontoAtendimento
        Call NrPontoAtendimentoMudou()

        'Necessário para que a alteração de emitente funcione via tela do chamado, não retirar
        '----------------------------------------------
        Session("SPontoAtendimento") = TxtNrPontoAtendimento.Text
        '----------------------------------------------

        Call CarregaContatoAtendimento()
        If Not String.IsNullOrEmpty(objAtendimento.CodContatoAtendimento) Then
            DdlContatoAtendimento.SelectedValue = objAtendimento.CodContatoAtendimento
            Call ContatoSelecionadoAtendimentoMudou()
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
        'TxtOSCliente.Text = objAtendimento.OSCliente
        TxtObservacao.Text = objAtendimento.Observacao
        LblCodUsuario.Text = objAtendimento.CodUsuario
        objUsuario.CodUsuario = objAtendimento.CodUsuario
        objUsuario.BuscarPorCodigo()
        LblUsuario.Text = objUsuario.NomeUsuario

        If Not String.IsNullOrEmpty(objAtendimento.DataEncerramentoPrevista) Then
            LblDataEncerramentoPrevisto.Text = objAtendimento.DataEncerramentoPrevista
            LblHoraEncerramentoPrevisto.Text = objAtendimento.HoraEncerramentoPrevista
        End If
        If Not String.IsNullOrEmpty(objAtendimento.DataChegadaPrevista) Then
            LblDataChegadaPrevista.Text = objAtendimento.DataChegadaPrevista
            LblHoraChegadaPrevista.Text = objAtendimento.HoraChegadaPrevista
        End If
        LblDataChegada.Text = objAtendimento.DataChegada
        LblHoraChegada.Text = objAtendimento.HoraChegada

        TxtSAG.Text = objAtendimento.SAG

        objAnalistaEditando.Codigo = Session("GlCodUsuario")
        If objAnalistaEditando.Buscar() Then
            If objAnalistaEditando.PermiteAlterarDataAberturaChamado = "S" Then
                permiteAlterarDataAberturaChamado = True
            End If
        End If

        TxtData.Enabled = permiteAlterarDataAberturaChamado
        TxtHora.Enabled = permiteAlterarDataAberturaChamado


    End Sub

    Private Function TemOS() As Boolean
        Try
            Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            objAtendimento.Empresa = Session("GlEmpresa")
            objAtendimento.CodChamado = CodAtendimento
            Return objAtendimento.TemOS()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CarregaNovaPK()
        Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
        objAtendimento.Empresa = Session("GlEmpresa")
        LblNrAtendimento.Text = objAtendimento.GetProximoCodigo
    End Sub

    Protected Sub DdlCNPJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlCNPJ.SelectedIndexChanged
        Call CNPJMudou()
    End Sub

    Private Sub CNPJMudou()
        Try
            Dim objEndereco As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))

            'Necessário para que a alteração de emitente funcione via tela da negociação, não retirar
            Session("SCNPJEmitente") = DdlCNPJ.SelectedValue

            objEndereco.CodEmitente = TxtCliente.Text
            objEndereco.CNPJ = DdlCNPJ.SelectedValue
            objEndereco.Buscar()
            LblNomeCliente.Text = objEndereco.NomeAbreviado
            LblTelefone.Text = objEndereco.Fone1
            If Not String.IsNullOrEmpty(objEndereco.Fone2) Then
                LblTelefone.Text += " / " + objEndereco.Fone2
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CarregaSLA(ByVal pCodCliente As String, ByVal pCodSlaAtual As String)
        Try
            Dim objSla As New UCLSLA
            objSla.FillDropDown(DdlSLA, False, "", pCodCliente, "0", "0", "0", pCodSlaAtual)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NrPontoAtendimentoMudou()
        Try
            'Dim objEndereco As New UCLEnderecoEmitente
            Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEstado As New UCLEstado
            Dim objCidade As New UCLCidade

            'Necessário para que a alteração de emitente funcione via tela da negociação, não retirar
            Session("SPontoAtendimento") = TxtNrPontoAtendimento.Text
            Session("SPontoPesquisado") = TxtNrPontoAtendimento.Text

            If Not String.IsNullOrEmpty(TxtClienteAtendimento.Text) AndAlso Not String.IsNullOrEmpty(TxtNrPontoAtendimento.Text) Then
                objPontoAtendimento.CodEmitente = TxtClienteAtendimento.Text
                objPontoAtendimento.NumeroPontoAtendimento = TxtNrPontoAtendimento.Text
                objPontoAtendimento.Buscar()
                If Not String.IsNullOrEmpty(objPontoAtendimento.CodEstado) AndAlso Not String.IsNullOrEmpty(objPontoAtendimento.CodCidade) Then
                    objEstado.CodPais = objPontoAtendimento.CodPais
                    objEstado.CodEstado = objPontoAtendimento.CodEstado
                    objEstado.Buscar()

                    objCidade.CodPais = objPontoAtendimento.CodPais
                    objCidade.CodEstado = objPontoAtendimento.CodEstado
                    objCidade.CodCidade = objPontoAtendimento.CodCidade
                    objCidade.Buscar()

                    LblEnderecoAtendimento.Text = objPontoAtendimento.Logradouro
                    If Not String.IsNullOrEmpty(objPontoAtendimento.Numero) AndAlso objPontoAtendimento.Numero <> 0 Then
                        LblEnderecoAtendimento.Text += ", " + objPontoAtendimento.Numero
                    End If
                    LblEnderecoAtendimento.Text += " - " + objCidade.NomeCidade
                    LblEnderecoAtendimento.Text += "/" + objEstado.Sigla
                Else
                    LblEnderecoAtendimento.Text = "(não informado)"
                End If

                LblTelefoneAtendimento.Text = objPontoAtendimento.Fone1
                If Not String.IsNullOrEmpty(objPontoAtendimento.Fone2) Then
                    LblTelefoneAtendimento.Text += " / " + objPontoAtendimento.Fone2
                End If

                Call MostraNomeClienteAtendimento()

                Call CarregaContatoAtendimento()

                DdlContatoAtendimento.SelectedValue = -1
                Call ContatoSelecionadoAtendimentoMudou()
                Call CarregaPrazos()

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub TxtNrPontoAtendimento_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtNrPontoAtendimento.TextChanged
        Call NrPontoAtendimentoMudou()
    End Sub

    Protected Sub TxtClienteAtendimento_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtClienteAtendimento.TextChanged
        Call CodigoClienteAtendimentoMudou()
    End Sub

    Protected Sub DdlContatoAtendimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlContatoAtendimento.SelectedIndexChanged
        Call ContatoSelecionadoAtendimentoMudou()
    End Sub

    Protected Sub DdlSLA_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlSLA.SelectedIndexChanged
        Try
            Call CarregaPrazos()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CarregaPrazos()
        Try
            Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim prazoChegada As Long
            Dim prazoEncerramento As Long
            Dim dataChamado As DateTime
            Dim dataEncerramentoPrevisto As DateTime
            Dim dataChegadaPrevista As DateTime

            objAtendimento.CodEmitente = TxtCliente.Text
            objAtendimento.CodSla = DdlSLA.SelectedValue
            objAtendimento.CodEmitenteAtendimento = TxtClienteAtendimento.Text
            objAtendimento.NumeroPontoAtendimento = TxtNrPontoAtendimento.Text
            objAtendimento.CarregaPrazos()

            prazoChegada = IIf(IsNumeric(objAtendimento.PrazoChegada), objAtendimento.PrazoChegada, 0)
            prazoEncerramento = IIf(IsNumeric(objAtendimento.PrazoChegada), objAtendimento.PrazoEncerramento, 0)

            If isValidDate(TxtData.Text) Then
                If String.IsNullOrEmpty(TxtHora.Text) Then
                    dataChamado = New DateTime(CDate(TxtData.Text).Year, CDate(TxtData.Text).Month, CDate(TxtData.Text).Day)
                Else
                    dataChamado = New DateTime(CDate(TxtData.Text).Year, CDate(TxtData.Text).Month, CDate(TxtData.Text).Day, CLng(TxtHora.Text.Substring(0, 2)), CLng(TxtHora.Text.Substring(3, 2)), 0)
                End If
            End If

            dataChegadaPrevista = dataChamado.AddHours(prazoChegada)
            dataEncerramentoPrevisto = dataChamado.AddHours(prazoEncerramento)

            If dataChegadaPrevista.DayOfWeek = DayOfWeek.Saturday Or dataChegadaPrevista.DayOfWeek = DayOfWeek.Sunday Then
                dataChegadaPrevista = dataChegadaPrevista.AddHours(48)
            End If

            If dataEncerramentoPrevisto.DayOfWeek = DayOfWeek.Saturday Or dataEncerramentoPrevisto.DayOfWeek = DayOfWeek.Sunday Then
                dataEncerramentoPrevisto = dataEncerramentoPrevisto.AddHours(48)
            End If

            LblDataEncerramentoPrevisto.Text = dataEncerramentoPrevisto.ToString("dd/MM/yyyy")
            LblHoraEncerramentoPrevisto.Text = dataEncerramentoPrevisto.ToString("HH:mm")

            LblDataChegadaPrevista.Text = dataChegadaPrevista.ToString("dd/MM/yyyy")
            LblHoraChegadaPrevista.Text = dataChegadaPrevista.ToString("HH:mm")

        Catch ex As Exception

        End Try
    End Sub
End Class