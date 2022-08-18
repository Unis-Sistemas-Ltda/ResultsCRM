Public Class WUCProgramacaoAtendimento
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodProgramacao As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodProgramacao() As String
        Get
            Return _CodProgramacao
        End Get
        Set(ByVal value As String)
            _CodProgramacao = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    Call CarregaDropDowns("")
                End If
            Else
                Call ChecaPesquisaCliente()
            End If
            Call MostraNomeCliente()
        Catch ex As Exception
            LblErro.Text = ex.Message
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
                    If TxtCodEmitente.Text <> CodClientePesquisado Then
                        TxtCodEmitente.Text = CodClientePesquisado
                        Call CodigoClienteMudou(True, "")
                    End If
                    If DdlCNPJ.SelectedValue <> CnpjClientePesquisado Then
                        DdlCNPJ.SelectedValue = CnpjClientePesquisado
                        Call CNPJMudou("")
                    End If
                    Session("SAlterouCodCliente") = alterouCodCliente - 2
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CodigoClienteMudou(ByVal procCompleto As Boolean, ByVal codContrato As String)
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

        If procCompleto Then
            Call CarregaCNPJ()
            Call CarregaContato()
        End If

        objEmitente.CodEmitente = TxtCodEmitente.Text
        objEmitente.Buscar()
        LblNomeCliente.Text = objEmitente.Nome

        If procCompleto Then
            DdlContato.SelectedValue = -1
        End If

        Session("SCodEmitenteNegociacao") = TxtCodEmitente.Text
        Session("SCodClientePesquisado") = TxtCodEmitente.Text

        If procCompleto Then
            Call CNPJMudou(codContrato)
        End If
    End Sub

    Private Sub CarregaContato()
        Dim objContato As New UCLContato
        If Not String.IsNullOrEmpty(TxtCodEmitente.Text) Then
            objContato.CodEmitente = TxtCodEmitente.Text
            objContato.FillDropDown(DdlContato, True, "", "-1")
            DdlContato.DataBind()
        End If
    End Sub

    Private Sub CarregaCNPJ()
        Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
        If Not String.IsNullOrEmpty(TxtCodEmitente.Text) Then
            objEnderecoEmitente.CodEmitente = TxtCodEmitente.Text
            objEnderecoEmitente.FillDropDownCNPJ(DdlCNPJ, True)
        End If
    End Sub

    Private Sub CNPJMudou(ByVal codContrato As String)
        Try
            Dim objEndereco As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))

            'Necessário para que a alteração de emitente funcione via tela da negociação, não retirar
            Session("SCNPJEmitente") = DdlCNPJ.SelectedValue

            objEndereco.CodEmitente = TxtCodEmitente.Text
            objEndereco.CNPJ = DdlCNPJ.SelectedValue
            objEndereco.Buscar()
            LblNomeCliente.Text = objEndereco.NomeAbreviado

            Call CarregaContratos(codContrato)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub CarregaFormulario()
        Dim objProgramacao As New UCLProgramacaoAtendimento
        LblCodProgramacao.Text = CodProgramacao

        objProgramacao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"), CodProgramacao)

        Call CarregaDropDowns(objProgramacao.GetConteudo("cod_analista"))

        TxtCodEmitente.Text = objProgramacao.GetConteudo("cod_emitente")

        Call CodigoClienteMudou(True, objProgramacao.GetConteudo("contrato"))
        Call CarregaCNPJ()

        Session("SCNPJEmitente") = objProgramacao.GetConteudo("cnpj")

        DdlCNPJ.SelectedValue = objProgramacao.GetConteudo("cnpj")
        Call CarregaContato()

        DdlContato.SelectedValue = objProgramacao.GetConteudo("cod_contato")
        DdlAnalista.SelectedValue = objProgramacao.GetConteudo("cod_analista")
        DdlTipoChamado.SelectedValue = objProgramacao.GetConteudo("cod_tipo_chamado")
        TxtAssunto.Text = objProgramacao.GetConteudo("assunto")
        TxtObservacao.Text = objProgramacao.GetConteudo("observacao")
        DdlContrato.SelectedValue = objProgramacao.GetConteudo("contrato")
        DdlTipoAgendamento.SelectedValue = objProgramacao.GetConteudo("tipo_agendamento")
        DdlSituacao.SelectedValue = objProgramacao.GetConteudo("situacao")
        TxtFollowUp.Text = objProgramacao.GetConteudo("follow_up_inicial")
    End Sub

    Private Sub CarregaNovaPK()
        Dim objProgramacao As New UCLProgramacaoAtendimento
        LblCodProgramacao.Text = objProgramacao.GetProximoCodigo(Session("GlEmpresa"), Session("GlEstabelecimento"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objProgramacao As New UCLProgramacaoAtendimento
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objProgramacao.SetConteudo("empresa", Session("GlEmpresa"))
                    objProgramacao.SetConteudo("estabelecimento", Session("GlEstabelecimento"))
                    objProgramacao.SetConteudo("cod_programacao", LblCodProgramacao.Text)
                    objProgramacao = CarregaObjeto(objProgramacao)
                    objProgramacao.Alterar()
                    Response.Redirect("WGProgramacaoAtendimento.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objProgramacao.SetConteudo("empresa", Session("GlEmpresa"))
                    objProgramacao.SetConteudo("estabelecimento", Session("GlEstabelecimento"))
                    objProgramacao.SetConteudo("cod_programacao", LblCodProgramacao.Text)
                    objProgramacao = CarregaObjeto(objProgramacao)
                    objProgramacao.Incluir()
                    Response.Redirect("WGProgramacaoAtendimento.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtCodEmitente.Text) Then
            LblErro.Text += "Preencha o campo Cliente.<br/>"
        End If

        If String.IsNullOrEmpty(DdlCNPJ.SelectedValue) Then
            LblErro.Text += "Preencha o campo CNPJ.<br/>"
        End If

        If String.IsNullOrEmpty(DdlContato.SelectedValue) Or DdlContato.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Contato.<br/>"
        End If

        If String.IsNullOrEmpty(DdlAnalista.SelectedValue) Or DdlAnalista.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Analista.<br/>"
        End If

        If String.IsNullOrEmpty(DdlTipoChamado.SelectedValue) Or DdlTipoChamado.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Tipo de Chamado.<br/>"
        End If

        If String.IsNullOrEmpty(TxtAssunto.Text) Then
            LblErro.Text += "Preencha o campo Assunto.<br/>"
        End If

        If String.IsNullOrEmpty(DdlContrato.SelectedValue) Then
            LblErro.Text += "Preencha o campo Contrato.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef objProgramacao As UCLProgramacaoAtendimento) As UCLProgramacaoAtendimento
        objProgramacao.SetConteudo("cod_emitente", TxtCodEmitente.Text.GetValidInputContent)
        objProgramacao.SetConteudo("cnpj", DdlCNPJ.Text)
        objProgramacao.SetConteudo("cod_contato", DdlContato.Text)
        objProgramacao.SetConteudo("cod_analista", DdlAnalista.Text)
        objProgramacao.SetConteudo("cod_tipo_chamado", DdlTipoChamado.SelectedValue)
        objProgramacao.SetConteudo("assunto", TxtAssunto.Text.GetValidInputContent)
        objProgramacao.SetConteudo("observacao", TxtObservacao.Text.GetValidInputContent)
        objProgramacao.SetConteudo("contrato", DdlContrato.Text)
        objProgramacao.SetConteudo("tipo_agendamento", DdlTipoAgendamento.SelectedValue)
        objProgramacao.SetConteudo("situacao", DdlSituacao.SelectedValue)
        objProgramacao.SetConteudo("follow_up_inicial", TxtFollowUp.Text.GetValidInputContent)
        Return objProgramacao
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGProgramacaoAtendimento.aspx")
    End Sub

    Private Sub CarregaDropDowns(ByVal pCodAnalista As String)
        Try
            Call CarregaTipoChamado()
            Call CarregaAnalista(pCodAnalista)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaTipoChamado()
        Try
            Dim objTipoChamado As New UCLTipoChamado
            objTipoChamado.FillDropDown(Session("GlEmpresa"), DdlTipoChamado, True, "(selecione)", "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaAnalista(ByVal pCodAnalista As String)
        Try
            Dim objAnalista As New UCLAnalista
            objAnalista.FillDropDown(DdlAnalista, True, "(selecione)", "0", True, False, pCodAnalista, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MostraNomeCliente()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim objEmitenteEndereco As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
        If Not String.IsNullOrEmpty(TxtCodEmitente.Text) Then
            objEmitente.CodEmitente = TxtCodEmitente.Text
            objEmitente.Buscar()
            LblNomeCliente.Text = objEmitente.Nome
        End If
        If Not String.IsNullOrEmpty(DdlCNPJ.SelectedValue) AndAlso DdlCNPJ.SelectedValue <> "0" Then
            objEmitenteEndereco.CodEmitente = TxtCodEmitente.Text
            objEmitenteEndereco.CNPJ = DdlCNPJ.SelectedValue
            objEmitenteEndereco.Buscar()
            LblNomeCliente.Text = objEmitenteEndereco.NomeAbreviado
        End If
    End Sub

    Private Sub CarregaContratos(ByVal codContrato As String)
        Try
            Dim objContrato As New UCLContratoManutencao
            objContrato.FillDropDown(DdlContrato, True, "(não selecionado)", TxtCodEmitente.Text, DdlCNPJ.SelectedValue, Session("GlEmpresa"), codContrato)
            If DdlContrato.Items.Count = 2 Then
                DdlContrato.SelectedValue = DdlContrato.Items.Item(1).Value
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtCodEmitente_TextChanged(sender As Object, e As EventArgs) Handles TxtCodEmitente.TextChanged
        Call CodigoClienteMudou(True, "")
    End Sub

    Protected Sub DdlCNPJ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlCNPJ.SelectedIndexChanged
        Call CNPJMudou("")
    End Sub
End Class
