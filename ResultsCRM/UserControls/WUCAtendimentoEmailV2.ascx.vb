Partial Public Class WUCAtendimentoEmailV2
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _Empresa As String
    Private _SeqEmail As String
    Private ReadOnly Dominio As String = "http://sinamm.no-ip.info/anfarmag_anexos/" 'Anfarmag
    'Private ReadOnly Dominio As String = "http://localhost/ativa_anexos/" 'Ativa

    Private ReadOnly Property Eid() As String
        Get
            Return Request.QueryString.Item("eid")
        End Get
    End Property

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property SeqEmail() As String
        Get
            Return _SeqEmail
        End Get
        Set(ByVal value As String)
            _SeqEmail = value
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtHora.Attributes.Add("OnKeyPress", "formatacampo(this,'??:??')")
        TxtData.Attributes.Add("OnKeyPress", "formatacampo(this,'??/??/????')")
        Try
            If Not IsPostBack Then
                If Acao = "ALTERAR" Then
                    BtnEnviar.Text = "Enviar"
                    Call CarregaFormulario()
                Else
                    Call CarregaFormularioInclusao()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub CarregaFormularioInclusao()
        Try
            Dim objAnalista As New UCLAnalista
            objAnalista.Codigo = Session("GlCodUsuario")
            If objAnalista.Buscar() Then
                LblRemetenteNome.Text = objAnalista.Nome
                LblRemetenteEmail.Text = objAnalista.Email
            End If
            TxtData.Text = Date.Now.ToString("dd/MM/yyyy")
            TxtHora.Text = DateTime.Now.ToString("HH:mm")
            'BtnExcluirAnexo1.Visible = False
            'BtnExcluirAnexo2.Visible = False
            'BtnExcluirAnexo3.Visible = False
            'LblAnexo1.Visible = False
            'LblAnexo2.Visible = False
            'LblAnexo3.Visible = False
            CarregaNovaPK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Dim objEmail As New UCLEmailSaida()

        LblNrEmail.Text = objEmail.GetProximoCodigo
        SeqEmail = LblNrEmail.Text
    End Sub

    Private Sub CarregaFormulario()
        Dim objEmail As New UCLEmailSaida
        Dim auxanexo, anexo As String
        Dim pos As Long

        HabilitaCampos(True)

        objEmail.Email = SeqEmail
        If objEmail.Buscar() Then

            LblNrEmail.Text = SeqEmail
            If objEmail.DDataEmail = Nothing Then
                TxtData.Text = ""
                TxtHora.Text = ""
            Else
                TxtData.Text = objEmail.DDataEmail.ToString("dd/MM/yyyy")
                TxtHora.Text = objEmail.HHoraEmail
            End If

            If objEmail.DEnviado = Nothing Then
                LblEnviadoData.Text = ""
                LblEnviadoHora.Text = ""
            Else
                LblEnviadoData.Text = objEmail.DEnviado.ToString("dd/MM/yy")
                LblEnviadoHora.Text = objEmail.HEnviado
                BtnEnviar.Text = "Encaminhar"
            End If

            LblRemetenteNome.Text = objEmail.Remetente
            LblRemetenteEmail.Text = objEmail.De
            TxtDestinatario.Text = objEmail.Destinatario
            TxtDestinatarioEmail.Text = objEmail.Para
            TxtEmailCC.Text = objEmail.DestinatarioCC
            TxtCCO.Text = objEmail.DestinatarioCCO
            TxtAssunto.Text = objEmail.Assunto
            TxtMensagem.Text = objEmail.Mensagem

            LblCaminhoAnexo1.Text = ""
            LblCaminhoAnexo2.Text = ""
            LblCaminhoAnexo3.Text = ""
            'LblAnexo1.Text = ""
            'LblAnexo2.Text = ""
            'LblAnexo3.Text = ""
            If Not String.IsNullOrEmpty(objEmail.Anexo) Then
                auxanexo = objEmail.Anexo
                For i As Integer = 1 To 3
                    pos = auxanexo.IndexOf(";")
                    If pos < 0 Then
                        anexo = auxanexo
                        auxanexo = ""
                    Else
                        anexo = auxanexo.Substring(0, pos)
                        auxanexo = auxanexo.Substring(pos + 1)
                    End If
                    If i = 1 Then
                        LblCaminhoAnexo1.Text = anexo
                    ElseIf i = 2 Then
                        LblCaminhoAnexo2.Text = anexo
                    ElseIf i = 3 Then
                        LblCaminhoAnexo3.Text = anexo
                    End If
                Next
            End If

            If Not String.IsNullOrEmpty(LblCaminhoAnexo1.Text) Then
                'LblAnexo1.Text = GetFileName(LblCaminhoAnexo1.Text)
                'LblAnexo1.NavigateUrl = Dominio + LblAnexo1.Text
                'LblAnexo1.Visible = True
                'BtnExcluirAnexo1.Visible = True
                'FUAnexo1.Visible = False
            End If

            If Not String.IsNullOrEmpty(LblCaminhoAnexo2.Text) Then
                'LblAnexo2.Text = GetFileName(LblCaminhoAnexo2.Text)
                'LblAnexo2.NavigateUrl = Dominio + LblAnexo2.Text
                'LblAnexo2.Visible = True
                'BtnExcluirAnexo2.Visible = True
                'FUAnexo2.Visible = False
            End If

            If Not String.IsNullOrEmpty(LblCaminhoAnexo3.Text) Then
                'LblAnexo3.Text = GetFileName(LblCaminhoAnexo3.Text)
                'LblAnexo3.NavigateUrl = Dominio + LblAnexo3.Text
                'LblAnexo3.Visible = True
                'BtnExcluirAnexo3.Visible = True
                'FUAnexo3.Visible = False
            End If

            If objEmail.EnviarAutomatico = "S" And objEmail.EnviadoAutomatico = "S" Then
                HabilitaCampos(False)
            End If

        End If
    End Sub

    Public Function HabilitaCampos(ByVal habilita As Boolean) As Boolean
        Try
            TxtData.Enabled = habilita
            TxtHora.Enabled = habilita
            TxtDestinatario.Enabled = habilita
            TxtDestinatarioEmail.Enabled = habilita
            TxtEmailCC.Enabled = habilita
            TxtAssunto.Enabled = habilita
            TxtMensagem.Enabled = habilita
            TxtCCO.Enabled = habilita

            If Not habilita Then
                BtnVoltar.Visible = True
                BtnSalvar.Visible = False
                BtnEnviar.Visible = True
                'BtnExcluirAnexo1.Enabled = False
                'BtnExcluirAnexo2.Enabled = False
                'BtnExcluirAnexo3.Enabled = False
            Else
                BtnVoltar.Visible = True
                BtnSalvar.Visible = True
                BtnEnviar.Visible = True
                'BtnExcluirAnexo1.Enabled = True
                'BtnExcluirAnexo2.Enabled = True
                'BtnExcluirAnexo3.Enabled = True
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGAtendimentoEmail.aspx?eid=" + Eid)
    End Sub

    Private Function IsDigitacaoOK()
        LblErro.Text = ""

        If Not IsDate(TxtData.Text) Then
            LblErro.Text += "Preencha o campo Data.<br/>"
        End If

        If String.IsNullOrEmpty(TxtHora.Text) Then
            LblErro.Text += "Preencha corretamente o campo Hora.<br/>"
        End If

        If String.IsNullOrEmpty(TxtDestinatario.Text) Then
            LblErro.Text += "Preencha corretamente campo Destinatário (nome).<br/>"
        End If

        If String.IsNullOrEmpty(TxtDestinatarioEmail.Text) Then
            LblErro.Text += "Preencha corretamente campo Destinatário (e-mail).<br/>"
        End If

        If String.IsNullOrEmpty(TxtAssunto.Text) Then
            LblErro.Text += "Preencha corretamente campo Assunto.<br/>"
        End If

        If String.IsNullOrEmpty(TxtMensagem.Text) Then
            LblErro.Text += "Preencha corretamente campo Mensagem.<br/>"
        End If

        Return LblErro.Text = ""
    End Function

    Private Function CarregaObjetos(ByRef objEmail As UCLEmailSaida) As UCLEmailSaida

        objEmail.DDataEmail = TxtData.Text
        objEmail.HHoraEmail = TxtHora.Text
        objEmail.Destinatario = TxtDestinatario.Text
        objEmail.Para = TxtDestinatarioEmail.Text
        objEmail.DestinatarioCC = TxtEmailCC.Text
        objEmail.Assunto = TxtAssunto.Text
        objEmail.Mensagem = TxtMensagem.Text
        objEmail.Empresa = Session("GlEmpresa")
        objEmail.CodChamado = Session("SCodAtendimento")
        objEmail.Remetente = LblRemetenteNome.Text
        objEmail.De = LblRemetenteEmail.Text
        objEmail.EnviarAutomatico = "S"
        objEmail.DestinatarioCC = TxtEmailCC.Text
        objEmail.DestinatarioCCO = TxtCCO.Text

        objEmail.Anexo = ""
        If Not String.IsNullOrEmpty(CaminhoFisicoAnexo1) Then
            objEmail.Anexo += CaminhoFisicoAnexo1
        End If
        If Not String.IsNullOrEmpty(CaminhoFisicoAnexo2) Then
            If Not String.IsNullOrEmpty(objEmail.Anexo) Then objEmail.Anexo += ";"
            objEmail.Anexo += CaminhoFisicoAnexo2
        End If
        If Not String.IsNullOrEmpty(CaminhoFisicoAnexo3) Then
            If Not String.IsNullOrEmpty(objEmail.Anexo) Then objEmail.Anexo += ";"
            objEmail.Anexo += CaminhoFisicoAnexo3
        End If

        Return objEmail
    End Function

    Protected Function Salvar() As Boolean
        Try
            Dim objEmail As New UCLEmailSaida
            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objEmail.Email = SeqEmail
                    objEmail.Buscar()
                    objEmail = CarregaObjetos(objEmail)
                    objEmail.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objEmail.Email = SeqEmail
                    objEmail = CarregaObjetos(objEmail)
                    objEmail.Incluir()
                End If
                Call SalvaAnexos()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private ReadOnly Property CaminhoFisicoAnexo1() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosManutencao
            'Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Empresa, Session("GlEstabelecimento"))

            'If Not String.IsNullOrEmpty(FUAnexo1.FileName) Then
            'caminhoanexo = FUAnexo1.FileName
            'arquivoanexo = GetFileName(caminhoanexo)
            'arquivoanexo = objParametrosManutencao.CaminhoAnexoEmail + "\" + LblNrEmail.Text.PadLeft(7, "0") + "_" + arquivoanexo
            'Else
            'arquivoanexo = LblCaminhoAnexo1.Text
            'End If
            Return arquivoanexo
        End Get
    End Property

    Private ReadOnly Property CaminhoFisicoAnexo2() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosManutencao
            'Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Empresa, Session("GlEstabelecimento"))

            'If Not String.IsNullOrEmpty(FUAnexo2.FileName) Then
            '    caminhoanexo = FUAnexo2.FileName
            '    arquivoanexo = GetFileName(caminhoanexo)
            '    arquivoanexo = objParametrosManutencao.CaminhoAnexoEmail + "\" + LblNrEmail.Text.PadLeft(7, "0") + "_" + arquivoanexo
            'Else
            '    arquivoanexo = LblCaminhoAnexo2.Text
            'End If
            Return arquivoanexo
        End Get
    End Property

    Private ReadOnly Property CaminhoFisicoAnexo3() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosManutencao
            'Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Empresa, Session("GlEstabelecimento"))

            'If Not String.IsNullOrEmpty(FUAnexo3.FileName) Then
            '    caminhoanexo = FUAnexo3.FileName
            '    arquivoanexo = GetFileName(caminhoanexo)
            '    arquivoanexo = objParametrosManutencao.CaminhoAnexoEmail + "\" + LblNrEmail.Text.PadLeft(7, "0") + "_" + arquivoanexo
            'Else
            '    arquivoanexo = LblCaminhoAnexo3.Text
            'End If
            Return arquivoanexo
        End Get
    End Property

    Protected Sub SalvaAnexos()
        Try
            'If Not String.IsNullOrEmpty(FUAnexo1.FileName) Then
            '    FUAnexo1.SaveAs(CaminhoFisicoAnexo1)
            'End If

            'If Not String.IsNullOrEmpty(FUAnexo2.FileName) Then
            '    FUAnexo2.SaveAs(CaminhoFisicoAnexo2)
            'End If

            'If Not String.IsNullOrEmpty(FUAnexo3.FileName) Then
            '    FUAnexo3.SaveAs(CaminhoFisicoAnexo3)
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Function GetFileName(ByVal arquivo As String) As String
        Try
            Dim pos As Long = 0
            For i As Long = arquivo.Length - 1 To 0 Step -1
                If arquivo.Substring(i, 1) = "/" OrElse arquivo.Substring(i, 1) = "\" Then
                    pos = i
                    Exit For
                End If
            Next
            arquivo = arquivo.Substring(pos + 1)
            Return arquivo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnSalvar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSalvar.Click
        Try
            If Salvar() Then
                Response.Redirect("WGAtendimentoEmail.aspx?eid=" + Eid)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub BtnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEnviar.Click
        Try
            If BtnEnviar.Text = "Enviar" Then
                If Salvar() Then
                    Call EnviaEmail()
                    LblErro.Text = "O e-mail será enviado dentro de alguns minutos."
                    HabilitaCampos(False)
                End If
            ElseIf BtnEnviar.Text = "Encaminhar" Then
                Dim objEmail As New UCLEmailSaida
                objEmail.Email = SeqEmail
                objEmail.Buscar()
                objEmail.Assunto = "Enc: " + objEmail.Assunto
                objEmail.Enviado = ""
                objEmail.DataEmail = System.DateTime.Now.ToString("dd/MM/yyyy")
                objEmail.DDataEmail = System.DateTime.Now.Date
                objEmail.HHoraEmail = System.DateTime.Now.ToString("HH:mm")
                objEmail.DEnviado = Nothing
                objEmail.HEnviado = ""
                objEmail.EnviadoAutomatico = ""
                objEmail.DataEnvioAutomatico = ""
                objEmail.DDataEnvioAutomatico = Nothing
                objEmail.HHoraEnvioAutomatico = ""
                objEmail.Email = objEmail.GetProximoCodigo()
                objEmail.Incluir()
                Session("SSeqEmail") = objEmail.Email
                Session("SAcaoEmail") = "ALTERAR"
                Response.Redirect("WFAtendimentoEmail.aspx?eid=" + Eid)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub EnviaEmail()
        Try
            Dim objEmail As New UCLEmailSaida
            objEmail.Email = SeqEmail
            objEmail.Buscar()
            objEmail.Enviado = Now.Date.ToString("dd/MM/yy")
            objEmail.DEnviado = Now.Date.ToString("yyyy-MM-dd")
            objEmail.HEnviado = Now.Hour.ToString.PadLeft(2, "0") + ":" + Now.Minute.ToString.PadLeft(2, "0")
            objEmail.Alterar()
            LblEnviadoData.Text = objEmail.Enviado
            LblEnviadoHora.Text = objEmail.HEnviado

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class