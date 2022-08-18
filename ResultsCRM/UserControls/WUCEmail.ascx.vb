Public Class WUCEmail
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _Empresa As String
    Private _SeqEmail As String

    Private ReadOnly Property Prop_T() As String
        Get
            Return Request.QueryString.Item("t")
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

    Public Property AcaoAuxiliar As String
    Public Property SeqEmailAuxiliar As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim nomeUsuario As String = ""
            Dim emailUsuario As String = ""
            If Not IsPostBack Then
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                ElseIf Acao = "INCLUIR" Then
                    CarregaNovaPK()

                    Dim objUsuario As New UCLSysUsuario
                    objUsuario.Buscar(Session("GlCodUsuario"))

                    nomeUsuario = objUsuario.GetConteudo("email_remetente")
                    emailUsuario = objUsuario.GetConteudo("email")

                    TxtData.Text = Now.ToString("dd/MM/yyyy")
                    TxtHora.Text = Now.ToString("HH:mm:ss")
                    LblRemetenteNome.Text = nomeUsuario + " [" + emailUsuario + "]"

                    If AcaoAuxiliar = "RESPONDER" Then
                        Dim objEmail2 As New UCLEmail2
                        If objEmail2.Buscar(Session("GlEmpresa"), SeqEmailAuxiliar) Then
                            TxtDestinatarioEmail.Text = objEmail2.GetConteudo("remetente_email")
                            TxtEmailCC.Text = objEmail2.GetConteudo("destinatario_cc")
                            TxtAssunto.Text = "RE: " + objEmail2.GetConteudo("assunto")
                            TxtMensagem.Text = vbCrLf + vbCrLf + "---------- Original message ----------" + vbCrLf + "From: " + objEmail2.GetConteudo("remetente_nome") + " <" + objEmail2.GetConteudo("remetente_email") + ">" + vbCrLf + "Date: " + objEmail2.GetConteudoData("data_mensagem").ToString("yyyy-MM-dd HH:mm:sszzz") + vbCrLf + "Subject: " + objEmail2.GetConteudo("assunto") + vbCrLf + "To: " + objEmail2.GetConteudo("destinatario_email") + vbCrLf + vbCrLf + objEmail2.GetConteudo("corpo").Replace("<br>", vbCrLf).Replace("<br/>", vbCrLf).Replace("<br />", vbCrLf)
                        End If
                    ElseIf AcaoAuxiliar = "ENCAMINHAR" Then
                        Dim objEmail2 As New UCLEmail2
                        If objEmail2.Buscar(Session("GlEmpresa"), SeqEmailAuxiliar) Then
                            TxtAssunto.Text = "FW: " + objEmail2.GetConteudo("assunto")
                            TxtMensagem.Text = vbCrLf + vbCrLf + "---------- Forwarded message ----------" + vbCrLf + "From: " + objEmail2.GetConteudo("remetente_nome") + " <" + objEmail2.GetConteudo("remetente_email") + ">" + vbCrLf + "Date: " + objEmail2.GetConteudoData("data_mensagem").ToString("yyyy-MM-dd HH:mm:sszzz") + vbCrLf + "Subject: " + objEmail2.GetConteudo("assunto") + vbCrLf + "To: " + objEmail2.GetConteudo("destinatario_email") + vbCrLf + vbCrLf + objEmail2.GetConteudo("corpo").Replace("<br>", vbCrLf).Replace("<br/>", vbCrLf).Replace("<br />", vbCrLf)
                        End If

                        Call CarregaAnexosEmTela(SeqEmailAuxiliar)
                    End If
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Dim objEmail2 As New UCLEmail2()
        LblNrEmail.Text = objEmail2.GetProximoCodigo(Session("GlEmpresa"))
        SeqEmail = LblNrEmail.Text
    End Sub

    Private Sub CarregaAnexosEmTela(ByVal pSeqEmail As String)
        Try
            Dim objEmail As New UCLEmail2
            LblCaminhoAnexo1.Text = ""
            LblCaminhoAnexo2.Text = ""
            LblCaminhoAnexo3.Text = ""
            LblCaminhoAnexo4.Text = ""
            LblCaminhoAnexo5.Text = ""
            LblAnexo1.Text = ""
            LblAnexo2.Text = ""
            LblAnexo3.Text = ""
            LblAnexo4.Text = ""
            LblAnexo5.Text = ""

            Dim anexos As List(Of UCLEmailAnexo) = objEmail.GetAnexos(Empresa, pSeqEmail)

            For i As Integer = 0 To anexos.Count - 1
                If i = 0 Then
                    LblCaminhoAnexo1.Text = anexos.Item(i).GetConteudo("arquivo")
                ElseIf i = 1 Then
                    LblCaminhoAnexo2.Text = anexos.Item(i).GetConteudo("arquivo")
                ElseIf i = 2 Then
                    LblCaminhoAnexo3.Text = anexos.Item(i).GetConteudo("arquivo")
                ElseIf i = 3 Then
                    LblCaminhoAnexo4.Text = anexos.Item(i).GetConteudo("arquivo")
                ElseIf i = 4 Then
                    LblCaminhoAnexo5.Text = anexos.Item(i).GetConteudo("arquivo")
                End If
            Next

            If Not String.IsNullOrEmpty(LblCaminhoAnexo1.Text) Then
                LblAnexo1.Text = GetFileName(LblCaminhoAnexo1.Text)
                LblAnexo1.NavigateUrl = DominioAnexoEmailEnviado + LblAnexo1.Text
                LblAnexo1.Visible = True
                BtnExcluirAnexo1.Visible = True
                FUAnexo1.Visible = False
            End If

            If Not String.IsNullOrEmpty(LblCaminhoAnexo2.Text) Then
                LblAnexo2.Text = GetFileName(LblCaminhoAnexo2.Text)
                LblAnexo2.NavigateUrl = DominioAnexoEmailEnviado + LblAnexo2.Text
                LblAnexo2.Visible = True
                BtnExcluirAnexo2.Visible = True
                FUAnexo2.Visible = False
            End If

            If Not String.IsNullOrEmpty(LblCaminhoAnexo3.Text) Then
                LblAnexo3.Text = GetFileName(LblCaminhoAnexo3.Text)
                LblAnexo3.NavigateUrl = DominioAnexoEmailEnviado + LblAnexo3.Text
                LblAnexo3.Visible = True
                BtnExcluirAnexo3.Visible = True
                FUAnexo3.Visible = False
            End If

            If Not String.IsNullOrEmpty(LblCaminhoAnexo4.Text) Then
                LblAnexo4.Text = GetFileName(LblCaminhoAnexo4.Text)
                LblAnexo4.NavigateUrl = DominioAnexoEmailEnviado + LblAnexo4.Text
                LblAnexo4.Visible = True
                BtnExcluirAnexo4.Visible = True
                FUAnexo4.Visible = False
            End If

            If Not String.IsNullOrEmpty(LblCaminhoAnexo5.Text) Then
                LblAnexo5.Text = GetFileName(LblCaminhoAnexo5.Text)
                LblAnexo5.NavigateUrl = DominioAnexoEmailEnviado + LblAnexo5.Text
                LblAnexo5.Visible = True
                BtnExcluirAnexo5.Visible = True
                FUAnexo5.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Dim objEmail As New UCLEmail2

        If objEmail.Buscar(Empresa, SeqEmail) Then

            LblNrEmail.Text = SeqEmail
            TxtData.Text = objEmail.GetConteudoData("data_mensagem").ToString("dd/MM/yyyy")
            TxtHora.Text = objEmail.GetConteudoData("data_mensagem").ToString("HH:mm:ss")

            LblRemetenteNome.Text = objEmail.GetConteudo("remetente_nome") + " [" + objEmail.GetConteudo("remetente_email") + "]"
            TxtDestinatarioEmail.Text = objEmail.GetConteudo("destinatario_email")
            TxtEmailCC.Text = objEmail.GetConteudo("destinatario_cc")
            TxtCCO.Text = objEmail.GetConteudo("destinatario_cco")

            TxtAssunto.Text = objEmail.GetConteudo("assunto")
            TxtMensagem.Text = objEmail.GetConteudo("corpo")

            LblErro.Text = objEmail.GetConteudo("descricao_erro")

            objEmail.SetConteudo("situacao_leitura", "1")
            objEmail.Alterar()

            Call CarregaAnexosEmTela(LblNrEmail.Text)
        End If
    End Sub

    Private Function IsDigitacaoOK()
        LblErro.Text = ""

        If Not IsDate(TxtData.Text) Then
            LblErro.Text += "Preencha o campo Data.<br/>"
        End If

        If String.IsNullOrEmpty(TxtHora.Text) Then
            LblErro.Text += "Preencha corretamente o campo Hora.<br/>"
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

    Private Function CarregaObjetos(ByRef objEmail As UCLEmail2, ByVal pEnviar As Boolean) As UCLEmail2
        objEmail.SetConteudoData("data_mensagem", New DateTime(TxtData.Text.Substring(6, 4), TxtData.Text.Substring(3, 2), TxtData.Text.Substring(0, 2), TxtHora.Text.Substring(0, 2), TxtHora.Text.Substring(3, 2), TxtHora.Text.Substring(6, 2)))
        objEmail.SetConteudo("remetente_nome", LblRemetenteNome.Text.Substring(0, LblRemetenteNome.Text.IndexOf("[")).Replace("]", "").Replace("]", "").Trim)
        objEmail.SetConteudo("remetente_email", LblRemetenteNome.Text.Substring(LblRemetenteNome.Text.IndexOf("[")).Replace("[", "").Replace("]", "").Trim)
        objEmail.SetConteudo("destinatario_email", TxtDestinatarioEmail.Text)
        objEmail.SetConteudo("destinatario_cc", TxtEmailCC.Text)
        objEmail.SetConteudo("destinatario_cco", TxtCCO.Text)
        objEmail.SetConteudo("assunto", TxtAssunto.Text)
        objEmail.SetConteudo("corpo", TxtMensagem.Text)
        objEmail.SetConteudo("tipo_email", "1")
        If pEnviar Then
            objEmail.SetConteudo("situacao", "1")
        Else
            If Acao = "INCLUIR" Then
                objEmail.SetConteudo("situacao", "0")
            Else
                objEmail.SetConteudo("situacao", Prop_T)
            End If
        End If
        objEmail.SetConteudo("cod_usuario", Session("GlCodUsuario"))

        objEmail.SetConteudoData("data_inclusao", Now())
        objEmail.SetConteudoData("data_alteracao", Now())
        objEmail.SetConteudo("situacao_leitura", "1")
        objEmail.SetConteudo("conta_principal", "N")
        Return objEmail
    End Function

    Protected Function Salvar(ByVal pEnviar As Boolean) As Boolean
        Try
            Dim objEmail As New UCLEmail2
            Dim objEmailAux As New UCLEmail2
            Dim CorpoMensagem As String = ""
            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objEmail.SetConteudo("empresa", Session("GlEmpresa"))
                    objEmail.SetConteudo("seq_email", LblNrEmail.Text)
                    objEmail.Buscar(Session("GlEmpresa"), LblNrEmail.Text)
                    objEmail = CarregaObjetos(objEmail, pEnviar)
                    objEmail.Alterar()
                    Call SalvaAnexos()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objEmail.SetConteudo("empresa", Session("GlEmpresa"))
                    objEmail.SetConteudo("seq_email", LblNrEmail.Text)
                    objEmail = CarregaObjetos(objEmail, pEnviar)
                    CorpoMensagem = objEmail.GetConteudo("corpo")
                    objEmail.SetConteudo("corpo", "")
                    objEmail.Incluir()

                    objEmail.SetConteudo("corpo", CorpoMensagem)
                    objEmail.Alterar()
                    objEmail.SetConteudo("corpo", CorpoMensagem)
                    If Request.QueryString.Item("tc") = 1 Then
                        Dim objEmailChamado As New UCLEmailChamado
                        objEmailChamado.SetConteudo("empresa", Session("GlEmpresa"))
                        objEmailChamado.SetConteudo("seq_email", LblNrEmail.Text)
                        objEmailChamado.SetConteudo("cod_chamado", Request.QueryString.Item("cc"))
                        objEmailChamado.Incluir()
                    End If

                    Call SalvaAnexos()
                    If AcaoAuxiliar = "ENCAMINHAR" Then
                        Dim objEmailHistorico As New UCLEmailHistorico
                        objEmailHistorico.SetConteudo("empresa", Session("GlEmpresa"))
                        objEmailHistorico.SetConteudo("seq_email", SeqEmailAuxiliar)
                        objEmailHistorico.SetConteudo("seq_historico", objEmailHistorico.GetProximoCodigo(Session("GlEmpresa"), SeqEmailAuxiliar))
                        objEmailHistorico.SetConteudoData("data_historico", Now())
                        objEmailHistorico.SetConteudo("descricao", "E-mail foi encaminhado. Novo seq. email:" + LblNrEmail.Text + ".")
                        objEmailHistorico.SetConteudo("cod_usuario", Session("GlCodUsuario"))
                        objEmailHistorico.Incluir()

                        objEmail.SetConteudo("seq_email_original", SeqEmailAuxiliar)
                        If objEmailAux.Buscar(Session("GlEmpresa"), SeqEmailAuxiliar) Then
                            If objEmailAux.IsNull("seq_email_agrupador") Then
                                objEmail.SetConteudo("seq_email_agrupador", SeqEmailAuxiliar)
                            Else
                                objEmail.SetConteudo("seq_email_agrupador", objEmailAux.GetConteudo("seq_email_agrupador"))
                            End If
                        End If
                        objEmail.Alterar()
                    ElseIf AcaoAuxiliar = "RESPONDER" Then
                        Dim objEmailHistorico As New UCLEmailHistorico
                        objEmailHistorico.SetConteudo("empresa", Session("GlEmpresa"))
                        objEmailHistorico.SetConteudo("seq_email", SeqEmailAuxiliar)
                        objEmailHistorico.SetConteudo("seq_historico", objEmailHistorico.GetProximoCodigo(Session("GlEmpresa"), SeqEmailAuxiliar))
                        objEmailHistorico.SetConteudoData("data_historico", Now())
                        objEmailHistorico.SetConteudo("descricao", "E-mail foi respondido. Novo seq. email:" + LblNrEmail.Text + ".")
                        objEmailHistorico.SetConteudo("cod_usuario", Session("GlCodUsuario"))
                        objEmailHistorico.Incluir()

                        objEmail.SetConteudo("seq_email_original", SeqEmailAuxiliar)
                        If objEmailAux.Buscar(Session("GlEmpresa"), SeqEmailAuxiliar) Then
                            If objEmailAux.IsNull("seq_email_agrupador") Then
                                objEmail.SetConteudo("seq_email_agrupador", SeqEmailAuxiliar)
                            Else
                                objEmail.SetConteudo("seq_email_agrupador", objEmailAux.GetConteudo("seq_email_agrupador"))
                            End If
                        End If
                        objEmail.Alterar()
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

    Protected Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click
        Try
            Call Salvar(False)
            'Session("SAcaoEmail") = "ALTERAR"
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "voltar()", True)
            'Response.Redirect("WFEmail.aspx?e=" + LblNrEmail.Text + "&t=" + Prop_T)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnEnviar_Click(sender As Object, e As EventArgs) Handles BtnEnviar.Click
        Try
            If Salvar(True) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "voltar()", True)
                'Response.Redirect("WGEmail3.aspx?t=" + Prop_T)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private ReadOnly Property CaminhoFisicoAnexo1() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosEmail
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Empresa)

            If Not String.IsNullOrEmpty(FUAnexo1.FileName) Then
                caminhoanexo = FUAnexo1.FileName
                arquivoanexo = GetFileName(caminhoanexo)
                arquivoanexo = objParametrosManutencao.GetConteudo("diretorio_anexo_email_enviado") + "\" + LblNrEmail.Text.PadLeft(7, "0") + "_" + arquivoanexo
            Else
                arquivoanexo = LblCaminhoAnexo1.Text
            End If
            Return arquivoanexo
        End Get
    End Property

    Private ReadOnly Property CaminhoFisicoAnexo2() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosEmail
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Empresa)

            If Not String.IsNullOrEmpty(FUAnexo2.FileName) Then
                caminhoanexo = FUAnexo2.FileName
                arquivoanexo = GetFileName(caminhoanexo)
                arquivoanexo = objParametrosManutencao.GetConteudo("diretorio_anexo_email_enviado") + "\" + LblNrEmail.Text.PadLeft(7, "0") + "_" + arquivoanexo
            Else
                arquivoanexo = LblCaminhoAnexo2.Text
            End If
            Return arquivoanexo
        End Get
    End Property

    Private ReadOnly Property CaminhoFisicoAnexo3() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosEmail
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Empresa)

            If Not String.IsNullOrEmpty(FUAnexo3.FileName) Then
                caminhoanexo = FUAnexo3.FileName
                arquivoanexo = GetFileName(caminhoanexo)
                arquivoanexo = objParametrosManutencao.GetConteudo("diretorio_anexo_email_enviado") + "\" + LblNrEmail.Text.PadLeft(7, "0") + "_" + arquivoanexo
            Else
                arquivoanexo = LblCaminhoAnexo3.Text
            End If
            Return arquivoanexo
        End Get
    End Property

    Private ReadOnly Property CaminhoFisicoAnexo4() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosEmail
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Empresa)

            If Not String.IsNullOrEmpty(FUAnexo4.FileName) Then
                caminhoanexo = FUAnexo4.FileName
                arquivoanexo = GetFileName(caminhoanexo)
                arquivoanexo = objParametrosManutencao.GetConteudo("diretorio_anexo_email_enviado") + "\" + LblNrEmail.Text.PadLeft(7, "0") + "_" + arquivoanexo
            Else
                arquivoanexo = LblCaminhoAnexo4.Text
            End If
            Return arquivoanexo
        End Get
    End Property

    Private ReadOnly Property CaminhoFisicoAnexo5() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosEmail
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Empresa)

            If Not String.IsNullOrEmpty(FUAnexo5.FileName) Then
                caminhoanexo = FUAnexo5.FileName
                arquivoanexo = GetFileName(caminhoanexo)
                arquivoanexo = objParametrosManutencao.GetConteudo("diretorio_anexo_email_enviado") + "\\" + LblNrEmail.Text.PadLeft(7, "0") + "_" + arquivoanexo
            Else
                arquivoanexo = LblCaminhoAnexo5.Text
            End If
            Return arquivoanexo
        End Get
    End Property

    Protected Function GetFileName(ByVal arquivo As String) As String
        Try
            Dim pos As Long = 0
            For i As Long = arquivo.Length - 1 To 0 Step -1
                If arquivo.Substring(i, 1) = "/" OrElse arquivo.Substring(i, 1) = "\" Then
                    pos = i
                    Exit For
                End If
            Next
            arquivo = arquivo.Substring(pos)
            Return arquivo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub SalvaAnexos()
        Try
            If Not String.IsNullOrEmpty(FUAnexo1.FileName) Then
                FUAnexo1.SaveAs(CaminhoFisicoAnexo1)
            End If

            If Not String.IsNullOrEmpty(FUAnexo2.FileName) Then
                FUAnexo2.SaveAs(CaminhoFisicoAnexo2)
            End If

            If Not String.IsNullOrEmpty(FUAnexo3.FileName) Then
                FUAnexo3.SaveAs(CaminhoFisicoAnexo3)
            End If

            If Not String.IsNullOrEmpty(FUAnexo4.FileName) Then
                FUAnexo4.SaveAs(CaminhoFisicoAnexo4)
            End If

            If Not String.IsNullOrEmpty(FUAnexo5.FileName) Then
                FUAnexo5.SaveAs(CaminhoFisicoAnexo5)
            End If

            Dim objEmailAnexo As New UCLEmailAnexo
            objEmailAnexo.Excluir(Empresa, LblNrEmail.Text)

            If Not String.IsNullOrEmpty(CaminhoFisicoAnexo1) Then
                objEmailAnexo = New UCLEmailAnexo
                objEmailAnexo.SetConteudo("empresa", Empresa)
                objEmailAnexo.SetConteudo("seq_email", LblNrEmail.Text)
                objEmailAnexo.SetConteudo("seq_anexo", objEmailAnexo.GetProximoCodigo(Empresa, LblNrEmail.Text))
                objEmailAnexo.SetConteudo("arquivo", GetFileName(CaminhoFisicoAnexo1))
                objEmailAnexo.Incluir()
            End If
            If Not String.IsNullOrEmpty(CaminhoFisicoAnexo2) Then
                objEmailAnexo = New UCLEmailAnexo
                objEmailAnexo.SetConteudo("empresa", Empresa)
                objEmailAnexo.SetConteudo("seq_email", LblNrEmail.Text)
                objEmailAnexo.SetConteudo("seq_anexo", objEmailAnexo.GetProximoCodigo(Empresa, LblNrEmail.Text))
                objEmailAnexo.SetConteudo("arquivo", GetFileName(CaminhoFisicoAnexo2))
                objEmailAnexo.Incluir()
            End If
            If Not String.IsNullOrEmpty(CaminhoFisicoAnexo3) Then
                objEmailAnexo = New UCLEmailAnexo
                objEmailAnexo.SetConteudo("empresa", Empresa)
                objEmailAnexo.SetConteudo("seq_email", LblNrEmail.Text)
                objEmailAnexo.SetConteudo("seq_anexo", objEmailAnexo.GetProximoCodigo(Empresa, LblNrEmail.Text))
                objEmailAnexo.SetConteudo("arquivo", GetFileName(CaminhoFisicoAnexo3))
                objEmailAnexo.Incluir()
            End If
            If Not String.IsNullOrEmpty(CaminhoFisicoAnexo4) Then
                objEmailAnexo = New UCLEmailAnexo
                objEmailAnexo.SetConteudo("empresa", Empresa)
                objEmailAnexo.SetConteudo("seq_email", LblNrEmail.Text)
                objEmailAnexo.SetConteudo("seq_anexo", objEmailAnexo.GetProximoCodigo(Empresa, LblNrEmail.Text))
                objEmailAnexo.SetConteudo("arquivo", GetFileName(CaminhoFisicoAnexo4))
                objEmailAnexo.Incluir()
            End If
            If Not String.IsNullOrEmpty(CaminhoFisicoAnexo5) Then
                objEmailAnexo = New UCLEmailAnexo
                objEmailAnexo.SetConteudo("empresa", Empresa)
                objEmailAnexo.SetConteudo("seq_email", LblNrEmail.Text)
                objEmailAnexo.SetConteudo("seq_anexo", objEmailAnexo.GetProximoCodigo(Empresa, LblNrEmail.Text))
                objEmailAnexo.SetConteudo("arquivo", GetFileName(CaminhoFisicoAnexo5))
                objEmailAnexo.Incluir()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnExcluirAnexo1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExcluirAnexo1.Click
        Try
            System.IO.File.Delete(LblCaminhoAnexo1.Text)
            LblAnexo1.Text = ""
            LblAnexo1.NavigateUrl = ""
            LblCaminhoAnexo1.Text = ""
            LblAnexo1.Visible = False
            BtnExcluirAnexo1.Visible = False
            FUAnexo1.Visible = True
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub BtnExcluirAnexo2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExcluirAnexo2.Click
        Try
            System.IO.File.Delete(LblCaminhoAnexo2.Text)
            LblAnexo2.Text = ""
            LblAnexo2.NavigateUrl = ""
            LblCaminhoAnexo2.Text = ""
            LblAnexo2.Visible = False
            BtnExcluirAnexo2.Visible = False
            FUAnexo2.Visible = True
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub BtnExcluirAnexo3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExcluirAnexo3.Click
        Try
            System.IO.File.Delete(LblCaminhoAnexo3.Text)
            LblAnexo3.Text = ""
            LblAnexo3.NavigateUrl = ""
            LblCaminhoAnexo3.Text = ""
            LblAnexo3.Visible = False
            BtnExcluirAnexo3.Visible = False
            FUAnexo3.Visible = True
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub BtnExcluirAnexo4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExcluirAnexo4.Click
        Try
            System.IO.File.Delete(LblCaminhoAnexo4.Text)
            LblAnexo4.Text = ""
            LblAnexo4.NavigateUrl = ""
            LblCaminhoAnexo4.Text = ""
            LblAnexo4.Visible = False
            BtnExcluirAnexo4.Visible = False
            FUAnexo4.Visible = True
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub BtnExcluirAnexo5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExcluirAnexo5.Click
        Try
            System.IO.File.Delete(LblCaminhoAnexo4.Text)
            LblAnexo5.Text = ""
            LblAnexo5.NavigateUrl = ""
            LblCaminhoAnexo5.Text = ""
            LblAnexo5.Visible = False
            BtnExcluirAnexo5.Visible = False
            FUAnexo5.Visible = True
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
End Class