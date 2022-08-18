Partial Public Class WUCAtendimentoFollowUp
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _Empresa As String
    Private _CodAtendimento As String
    Private _SeqFollowUp As String

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
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

    Public Property SeqFollowUp() As String
        Get
            Return _SeqFollowUp
        End Get
        Set(ByVal value As String)
            _SeqFollowUp = value
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
        If Not IsPostBack Then
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            Else
                Call CarregaFormularioInclusao()
            End If
            Call CarregaAcao()
            Session.Remove("SDescricaoFollowUpSelecionado")
        Else
            If Session("SDescricaoFollowUpSelecionado") IsNot Nothing AndAlso Not String.IsNullOrEmpty(Session("SDescricaoFollowUpSelecionado")) Then
                TxtDescricao.Text = Session("SDescricaoFollowUpSelecionado")
                Session.Remove("SDescricaoFollowUpSelecionado")
            End If
        End If
    End Sub

    Private Sub CarregaAcao()
        Dim objAcao As New UCLAcaoFollowUp
        objAcao.FillDropDown(DdlAcao, True, "")

    End Sub

    Private Sub CarregaFormularioInclusao()
        LblCodUsuario.Text = Session("GlCodUsuario")
        LblNomeUsuario.Text = Session("GlNomeUsuario")
        CarregaNovaPK()
        BtnExcluirAnexo1.Visible = False
        BtnExcluirAnexo2.Visible = False
        BtnExcluirAnexo3.Visible = False
        LblAnexo1.Visible = False
        LblAnexo2.Visible = False
        LblAnexo3.Visible = False
    End Sub
    

    Private Sub CarregaFormulario()
        Dim ObjFollowUp As New UCLAtendimentoFollowUp(StrConexaoUsuario(Session("GlUsuario")))
        Dim objUsuario As New UCLUsuario
        Dim objAnexo As New UCLAtendimentoFollowUpAnexo(StrConexaoUsuario(Session("GlUsuario")))
        Dim auxanexo As String
        Dim pos As Long
        Dim anexo As String


        ObjFollowUp.Empresa = Empresa
        ObjFollowUp.CodChamado = CodAtendimento
        ObjFollowUp.SeqFollowUP = SeqFollowUp
        ObjFollowUp.Buscar()

        If Not String.IsNullOrEmpty(ObjFollowUp.CodAcao) Then
            DdlAcao.SelectedValue = ObjFollowUp.CodAcao
        End If

        LblSeq.Text = ObjFollowUp.SeqFollowUP
        LblCodUsuario.Text = ObjFollowUp.CodUsuario
        TxtData.Text = ObjFollowUp.DataFollowUp
        TxtHora.Text = ObjFollowUp.HoraFollowUp
        DdlTipo.SelectedValue = ObjFollowUp.Tipo
        RblEmail.SelectedValue = ObjFollowUp.Email
        LblDataEmail.Text = ObjFollowUp.DataEmail
        LblHoraEmail.Text = ObjFollowUp.HoraEmail
        TxtDescricao.Text = ObjFollowUp.Descricao

        objUsuario.CodUsuario = ObjFollowUp.CodUsuario
        objUsuario.BuscarPorCodigo()
        LblNomeUsuario.Text = objUsuario.NomeUsuario

        LblCaminhoAnexo1.Text = ""
        LblCaminhoAnexo2.Text = ""
        LblCaminhoAnexo3.Text = ""
        LblAnexo1.Text = ""
        LblAnexo2.Text = ""
        LblAnexo3.Text = ""

        auxanexo = ""

        For i As Integer = 1 To 3
            objAnexo.Empresa = Empresa
            objAnexo.CodChamado = CodAtendimento
            objAnexo.SeqFollowUP = SeqFollowUp
            objAnexo.SeqAnexo = i.ToString
            objAnexo.Buscar()
            auxanexo += objAnexo.Arquivo + ";"
        Next

        If Not String.IsNullOrEmpty(auxanexo) Then
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
            LblAnexo1.Text = GetFileName(LblCaminhoAnexo1.Text)
            LblAnexo1.NavigateUrl = DominioAnexoFollowUpChamado() + LblAnexo1.Text
            LblAnexo1.Visible = True
            BtnExcluirAnexo1.Visible = True
            FUAnexo1.Visible = False
        End If

        If Not String.IsNullOrEmpty(LblCaminhoAnexo2.Text) Then
            LblAnexo2.Text = GetFileName(LblCaminhoAnexo2.Text)
            LblAnexo2.NavigateUrl = DominioAnexoFollowUpChamado() + LblAnexo2.Text
            LblAnexo2.Visible = True
            BtnExcluirAnexo2.Visible = True
            FUAnexo2.Visible = False
        End If

        If Not String.IsNullOrEmpty(LblCaminhoAnexo3.Text) Then
            LblAnexo3.Text = GetFileName(LblCaminhoAnexo3.Text)
            LblAnexo3.NavigateUrl = DominioAnexoFollowUpChamado() + LblAnexo3.Text
            LblAnexo3.Visible = True
            BtnExcluirAnexo3.Visible = True
            FUAnexo3.Visible = False
        End If

    End Sub

    Private Sub CarregaNovaPK()
        Dim objAtendimentoFollowUp As New UCLAtendimentoFollowUp(StrConexaoUsuario(Session("GlUsuario")))

        objAtendimentoFollowUp.Empresa = Session("GlEmpresa")
        objAtendimentoFollowUp.CodChamado = CodAtendimento
        LblSeq.Text = objAtendimentoFollowUp.GetProximoCodigo
        SeqFollowUp = LblSeq.Text

        TxtData.Text = Date.Now.ToString("dd/MM/yyyy")
        TxtHora.Text = DateTime.Now.ToString("HH:mm")
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objAtendimentoFollowUp As New UCLAtendimentoFollowUp(StrConexaoUsuario(Session("GlUsuario")))
            Dim retEmail As String
            Dim erroEmail As Boolean
            Dim enviaEmailAtual As String
            Dim enviaEmailAnterior As String
            Dim objFollowUpAnexo1 As New UCLAtendimentoFollowUpAnexo(StrConexaoUsuario(Session("GlUsuario")))
            Dim objFollowUpAnexo2 As New UCLAtendimentoFollowUpAnexo(StrConexaoUsuario(Session("GlUsuario")))
            Dim objFollowUpAnexo3 As New UCLAtendimentoFollowUpAnexo(StrConexaoUsuario(Session("GlUsuario")))

            retEmail = ""
            erroEmail = False

            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objAtendimentoFollowUp.CodChamado = CodAtendimento
                    objAtendimentoFollowUp.SeqFollowUP = SeqFollowUp
                    objAtendimentoFollowUp.Empresa = Session("GlEmpresa")
                    objAtendimentoFollowUp.Buscar()
                    enviaEmailAnterior = objAtendimentoFollowUp.Email
                    enviaEmailAtual = RblEmail.SelectedValue
                    objAtendimentoFollowUp = CarregaObjetos(objAtendimentoFollowUp, objFollowUpAnexo1, objFollowUpAnexo2, objFollowUpAnexo3)
                    objAtendimentoFollowUp.Alterar()

                    Call SalvaAnexos(objFollowUpAnexo1, objFollowUpAnexo2, objFollowUpAnexo3)

                    LblErro.Text = "Follow-up foi alterado com sucesso. "

                    If enviaEmailAtual = "S" AndAlso enviaEmailAtual <> enviaEmailAnterior Then
                        retEmail = EnviaEmail()
                    End If

                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objAtendimentoFollowUp.CodChamado = CodAtendimento
                    objAtendimentoFollowUp.SeqFollowUP = SeqFollowUp
                    objAtendimentoFollowUp.Empresa = Session("GlEmpresa")
                    objAtendimentoFollowUp = CarregaObjetos(objAtendimentoFollowUp, objFollowUpAnexo1, objFollowUpAnexo2, objFollowUpAnexo3)
                    objAtendimentoFollowUp.Incluir()

                    Call SalvaAnexos(objFollowUpAnexo1, objFollowUpAnexo2, objFollowUpAnexo3)

                    LblErro.Text = "Follow-up foi incluído com sucesso. "

                    If RblEmail.SelectedValue = "S" Then
                        retEmail = EnviaEmail()
                    End If

                    Session("SAcaoFollowUp") = "ALTERAR"
                    Session("SSeqFolowUp") = LblSeq.Text
                End If

                erroEmail = (Not String.IsNullOrEmpty(retEmail))

                If Not erroEmail Then
                    Response.Redirect("WGAtendimentoFollowUp.aspx",False)
                Else
                    LblErro.Text += "Entretanto, o e-mail não pôde ser enviado pelo motivo abaixo:<br/><br/>"
                    LblErro.Text += retEmail
                End If

            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
            GravaLog(ex.ToString)
        End Try
    End Sub

    Protected Sub SalvaAnexos(ByRef objAnexo1 As UCLAtendimentoFollowUpAnexo, ByRef objAnexo2 As UCLAtendimentoFollowUpAnexo, ByRef objAnexo3 As UCLAtendimentoFollowUpAnexo)
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

            If Not String.IsNullOrWhiteSpace(CaminhoFisicoAnexo1) Then
                If objAnexo1.Existe() Then
                    objAnexo1.Alterar()
                Else
                    objAnexo1.Incluir()
                End If
            Else
                objAnexo1.Excluir()
            End If

            If Not String.IsNullOrWhiteSpace(CaminhoFisicoAnexo2) Then
                If objAnexo2.Existe() Then
                    objAnexo2.Alterar()
                Else
                    objAnexo2.Incluir()
                End If
            Else
                objAnexo2.Excluir()
            End If

            If Not String.IsNullOrWhiteSpace(CaminhoFisicoAnexo3) Then
                If objAnexo3.Existe() Then
                    objAnexo3.Alterar()
                Else
                    objAnexo3.Incluir()
                End If
            Else
                objAnexo3.Excluir()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function EnviaEmail() As String
        Try
            Dim retorno As String
            Dim objAtendimentoFollowUp As New UCLAtendimentoFollowUp(StrConexaoUsuario(Session("GlUsuario")))
            objAtendimentoFollowUp.Empresa = Empresa
            objAtendimentoFollowUp.CodChamado = CodAtendimento
            objAtendimentoFollowUp.SeqFollowUP = LblSeq.Text
            retorno = objAtendimentoFollowUp.EnviaEmailFollowUP(StrConexaoUsuario(Session("GlUsuario")))
            Return retorno
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function CarregaObjetos(ByRef objAtendimentoFollowUp As UCLAtendimentoFollowUp, ByRef objAnexo1 As UCLAtendimentoFollowUpAnexo, ByRef objAnexo2 As UCLAtendimentoFollowUpAnexo, ByRef objAnexo3 As UCLAtendimentoFollowUpAnexo) As UCLAtendimentoFollowUp

        objAtendimentoFollowUp.DataFollowUp = TxtData.Text
        objAtendimentoFollowUp.HoraFollowUp = TxtHora.Text
        objAtendimentoFollowUp.Tipo = DdlTipo.SelectedValue
        objAtendimentoFollowUp.Email = RblEmail.SelectedValue
        objAtendimentoFollowUp.CodAcao = DdlAcao.SelectedValue
        If RblEmail.SelectedValue = "S" Then
            If String.IsNullOrEmpty(LblDataEmail.Text) Then
                LblDataEmail.Text = Now.Date.ToString("dd/MM/yyyy")
                LblHoraEmail.Text = Now.TimeOfDay.Hours.ToString.PadLeft(2, "0") + Now.TimeOfDay.Minutes.ToString.PadLeft(2, "0")
            End If
        End If

        objAtendimentoFollowUp.Descricao = TxtDescricao.Text.RetiraAspas
        objAtendimentoFollowUp.CodUsuario = LblCodUsuario.Text

        objAnexo1.Empresa = Empresa
        objAnexo1.CodChamado = CodAtendimento
        objAnexo1.SeqFollowUP = SeqFollowUp
        objAnexo1.SeqAnexo = 1

        objAnexo2.Empresa = Empresa
        objAnexo2.CodChamado = CodAtendimento
        objAnexo2.SeqFollowUP = SeqFollowUp
        objAnexo2.SeqAnexo = 2

        objAnexo3.Empresa = Empresa
        objAnexo3.CodChamado = CodAtendimento
        objAnexo3.SeqFollowUP = SeqFollowUp
        objAnexo3.SeqAnexo = 3

        If Not String.IsNullOrEmpty(CaminhoFisicoAnexo1) Then
            objAnexo1.Arquivo = GetFileName(CaminhoFisicoAnexo1)
        End If

        If Not String.IsNullOrEmpty(CaminhoFisicoAnexo2) Then
            objAnexo2.Arquivo = GetFileName(CaminhoFisicoAnexo2)
        End If

        If Not String.IsNullOrEmpty(CaminhoFisicoAnexo3) Then
            objAnexo3.Arquivo = GetFileName(CaminhoFisicoAnexo3)
        End If

        Return objAtendimentoFollowUp
    End Function

    Private Function IsDigitacaoOK()

        Dim objParametrosVenda As New UCLParametrosVenda

        objParametrosVenda.Buscar(Session("GlEmpresa"))

        LblErro.Text = ""
        If objParametrosVenda.GetConteudo("exigir_acao_follow_up_negociacao_crm") = "S" Then
            If String.IsNullOrEmpty(DdlAcao.SelectedValue) OrElse DdlAcao.SelectedValue = "0" Then
                LblErro.Text += "Preencha o campo Ação.<br/>"
            End If
        End If

        If Not IsDate(TxtData.Text) Then
            LblErro.Text += "Preencha o campo Data.<br/>"
        End If

        If String.IsNullOrEmpty(TxtHora.Text) Then
            LblErro.Text += "Preencha corretamente o campo Hora.<br/>"
        End If

        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha corretamente campo Comentário.<br/>"
        End If

        Return LblErro.Text = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGAtendimentoFollowUp.aspx")
    End Sub

    Protected Sub BtnExcluirAnexo1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExcluirAnexo1.Click
        Try
            If System.IO.File.Exists(LblCaminhoAnexo1.Text) Then
                System.IO.File.Delete(LblCaminhoAnexo1.Text)
            End If
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
            If System.IO.File.Exists(LblCaminhoAnexo2.Text) Then
                System.IO.File.Delete(LblCaminhoAnexo2.Text)
            End If
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
            If System.IO.File.Exists(LblCaminhoAnexo3.Text) Then
                System.IO.File.Delete(LblCaminhoAnexo3.Text)
            End If
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

    Private ReadOnly Property CaminhoFisicoAnexo1() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosManutencao
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Empresa, Session("GlEstabelecimento"))

            If Not String.IsNullOrEmpty(FUAnexo1.FileName) Then
                caminhoanexo = FUAnexo1.FileName
                arquivoanexo = caminhoanexo
                arquivoanexo = CaminhoFisicoAnexoChamado + CodAtendimento + "_" + SeqFollowUp + "_1_" + arquivoanexo
            Else
                If Not String.IsNullOrWhiteSpace(LblCaminhoAnexo1.Text) Then
                    arquivoanexo = CaminhoFisicoAnexoChamado + LblCaminhoAnexo1.Text
                Else
                    arquivoanexo = ""
                End If
            End If
            Return arquivoanexo
        End Get
    End Property

    Private ReadOnly Property CaminhoFisicoAnexo2() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosManutencao
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Empresa, Session("GlEstabelecimento"))

            If Not String.IsNullOrEmpty(FUAnexo2.FileName) Then
                caminhoanexo = FUAnexo2.FileName
                arquivoanexo = caminhoanexo
                arquivoanexo = CaminhoFisicoAnexoChamado + CodAtendimento + "_" + SeqFollowUp + "_2_" + arquivoanexo
            Else
                If Not String.IsNullOrWhiteSpace(LblCaminhoAnexo2.Text) Then
                    arquivoanexo = CaminhoFisicoAnexoChamado + LblCaminhoAnexo2.Text
                Else
                    arquivoanexo = ""
                End If
            End If
            Return arquivoanexo
        End Get
    End Property

    Private ReadOnly Property CaminhoFisicoAnexo3() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosManutencao
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Empresa, Session("GlEstabelecimento"))

            If Not String.IsNullOrEmpty(FUAnexo3.FileName) Then
                caminhoanexo = FUAnexo3.FileName
                arquivoanexo = caminhoanexo
                arquivoanexo = CaminhoFisicoAnexoChamado + CodAtendimento + "_" + SeqFollowUp + "_3_" + arquivoanexo
            Else
                If Not String.IsNullOrWhiteSpace(LblCaminhoAnexo3.Text) Then
                    arquivoanexo = CaminhoFisicoAnexoChamado + LblCaminhoAnexo3.Text
                Else
                    arquivoanexo = ""
                End If
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
            arquivo = arquivo.Substring(pos + 1)
            Return arquivo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class