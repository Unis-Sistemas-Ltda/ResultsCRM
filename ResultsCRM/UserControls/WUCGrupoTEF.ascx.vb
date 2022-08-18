Public Class WUCGrupoTEF
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _Codigo As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
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
        Dim objAdesaoTEF As New UCLAdesaoTEF
        LblCodAdesao.Text = Codigo

        objAdesaoTEF.Buscar(Session("GlEmpresa"), LblCodAdesao.Text)

        TxtNomeRede.Text = objAdesaoTEF.GetConteudo("nome_rede").ToString
        TxtNomeResponsavel.Text = objAdesaoTEF.GetConteudo("nome_responsavel").ToString
        TxtTelefoneResponsavel.Text = objAdesaoTEF.GetConteudo("telefone_responsavel").ToString
        TxtEmailResponsavel.Text = objAdesaoTEF.GetConteudo("email_responsavel").ToString
        TxtNomeRepresentanteLegal.Text = objAdesaoTEF.GetConteudo("nome_representante_legal").ToString
        TxtCPFRepresentanteLegal.Text = objAdesaoTEF.GetConteudo("cpf_representante_legal").ToString
        TxtDataNascimentoRepresentanteLegal.Text = objAdesaoTEF.GetConteudo("data_nascimento_representante_legal").ToString
        TxtValorCustoAtivacao.Text = objAdesaoTEF.GetConteudo("valor_custo_ativacao").ToString
        TxtValorVendaAtivacao.Text = objAdesaoTEF.GetConteudo("valor_venda_ativacao").ToString
        TxtValorMensal.Text = objAdesaoTEF.GetConteudo("valor_mensal").ToString
        DdlAutorizadora.SelectedValue = objAdesaoTEF.GetConteudo("cod_autorizadora").ToString
    End Sub

    Private Sub CarregaNovaPK()
        Dim objAdesaoTEF As New UCLAdesaoTEF
        LblCodAdesao.Text = objAdesaoTEF.GetProximoCodigo(Session("GlEmpresa"))
    End Sub

    Private Sub CarregaDropDowns()
        Call CarregaAutorizadora()
    End Sub

    Private Sub CarregaAutorizadora()
        Try
            Dim objAutorizadora As New UCLAutorizadoraTEF
            objAutorizadora.FillDropDown(DdlAutorizadora, True, "(selecione)", "-1")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objAdesaoTEF As New UCLAdesaoTEF
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objAdesaoTEF.SetConteudo("empresa", Session("GlEmpresa"))
                    objAdesaoTEF.SetConteudo("cod_adesao", LblCodAdesao.Text)
                    objAdesaoTEF = CarregaObjeto(objAdesaoTEF)
                    objAdesaoTEF.Alterar()
                    Response.Redirect("WGGrupoTEF.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objAdesaoTEF.SetConteudo("empresa", Session("GlEmpresa"))
                    objAdesaoTEF.SetConteudo("cod_adesao", LblCodAdesao.Text)
                    objAdesaoTEF = CarregaObjeto(objAdesaoTEF)
                    objAdesaoTEF.Incluir()
                    Response.Redirect("WGGrupoTEF.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtNomeRede.Text) Then
            LblErro.Text += "Preencha o campo Nome do Grupo.<br/>"
        End If

        If DdlAutorizadora.SelectedValue = -1 Then
            LblErro.Text += "Preencha o campo Autorizadora.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef objAdesaoTEF As UCLAdesaoTEF) As UCLAdesaoTEF
        objAdesaoTEF.SetConteudo("nome_rede", TxtNomeRede.Text.GetValidInputContent)
        objAdesaoTEF.SetConteudo("nome_responsavel", TxtNomeResponsavel.Text.GetValidInputContent)
        objAdesaoTEF.SetConteudo("telefone_responsavel", TxtTelefoneResponsavel.Text.GetValidInputContent)
        objAdesaoTEF.SetConteudo("email_responsavel", TxtEmailResponsavel.Text.GetValidInputContent)
        objAdesaoTEF.SetConteudo("nome_representante_legal", TxtNomeRepresentanteLegal.Text.GetValidInputContent)
        objAdesaoTEF.SetConteudo("cpf_representante_legal", TxtCPFRepresentanteLegal.Text.GetValidInputContent)
        objAdesaoTEF.SetConteudo("data_nascimento_representante_legal", TxtDataNascimentoRepresentanteLegal.Text.GetValidInputContent)
        objAdesaoTEF.SetConteudo("valor_custo_ativacao", TxtValorCustoAtivacao.Text.GetValidInputContent)
        objAdesaoTEF.SetConteudo("valor_venda_ativacao", TxtValorVendaAtivacao.Text.GetValidInputContent)
        objAdesaoTEF.SetConteudo("valor_mensal", TxtValorMensal.Text.GetValidInputContent)
        objAdesaoTEF.SetConteudo("cod_autorizadora", DdlAutorizadora.SelectedValue)
        Return objAdesaoTEF
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGGrupoTEF.aspx")
    End Sub

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim objEmailCampanhaTEF As New UCLEmailCampanhaTef
            Dim objAdesaoTEF As New UCLAdesaoTEF
            Dim lojas As List(Of UCLAdesaoTEF.StLoja) = objAdesaoTEF.GetLojasPendentes(LblCodAdesao.Text)
            Dim objParametrosEmail As New UCLParametrosEmail
            Dim qtd As Long = 0

            objAdesaoTEF.Buscar(Session("GlEmpresa"), LblCodAdesao.Text)
            objParametrosEmail.Buscar(Session("GlEmpresa"))

            For Each loja As UCLAdesaoTEF.StLoja In lojas
                Dim objEmitente As New UCLEmitente(StrConexao)
                objEmitente.CodEmitente = loja.CodEmitente
                objEmitente.Buscar()

                Dim objContato As New UCLContato
                objContato.CodEmitente = objEmitente.CodEmitente
                objContato.Codigo = objContato.GetCodContatoPreferencial()
                objContato.Buscar()

                If String.IsNullOrEmpty(objContato.Email) Then
                    Continue For
                End If

                objEmailCampanhaTEF.SeqEmail = objEmailCampanhaTEF.GetProximoCodigo()
                objEmailCampanhaTEF.DEnviado = Now.ToString("dd/MM/yyyy")
                objEmailCampanhaTEF.HEnviado = Now.ToString("HH:mm:ss")
                objEmailCampanhaTEF.DDataEmail = Now.ToString("dd/MM/yyyy")
                objEmailCampanhaTEF.HHoraEmail = Now.ToString("HH:mm:ss")
                objEmailCampanhaTEF.Destinatario = objEmitente.Nome
                objEmailCampanhaTEF.Para = objContato.Email
                objEmailCampanhaTEF.DestinatarioCC = objAdesaoTEF.GetConteudo("email_campanha_cc")
                objEmailCampanhaTEF.Assunto = objAdesaoTEF.GetConteudo("assunto_email_campanha").ToString.Replace("#nome_grupo#", objAdesaoTEF.GetConteudo("nome_rede"))
                objEmailCampanhaTEF.Mensagem = objAdesaoTEF.GetConteudo("mensagem_email_campanha").ToString.Replace("#cod_emitente#", objEmitente.CodEmitente).Replace("#cod_adesao#", LblCodAdesao.Text).Replace("#nome_grupo#", objAdesaoTEF.GetConteudo("nome_rede")).Replace("#nome_usuario#", "").Replace("#nome_emitente#", objEmitente.Nome)
                objEmailCampanhaTEF.CodEmitente = objEmitente.CodEmitente
                objEmailCampanhaTEF.CNPJ = loja.CNPJ
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
                qtd += 1
            Next

            If qtd = 0 Then
                LblErro.Text = "Nenhum e-mail a ser enviado."
            ElseIf qtd = 1 Then
                LblErro.Text = "1 e-mail enviado."
            Else
                LblErro.Text = qtd.ToString() + " e-mails enviados."
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class