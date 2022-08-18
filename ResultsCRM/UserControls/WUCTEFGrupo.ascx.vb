Public Class WUCTEFGrupo
    Inherits System.Web.UI.UserControl

    Private _CodGrupo As String
    Private _Acao As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodGrupo() As String
        Get
            Return _CodGrupo
        End Get
        Set(ByVal value As String)
            _CodGrupo = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaDropDowns()
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objGrupo As New UCLTefGrupo
        Try
            If IsDigitacaoOk() Then
                If Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    Session("SCodGrupoTEF") = TxtCodGrupo.Text
                End If

                objGrupo.SetConteudo("empresa", Session("GlEmpresa"))
                objGrupo.SetConteudo("cod_grupo", TxtCodGrupo.Text)

                If Acao = "ALTERAR" Then
                    objGrupo.Buscar(objGrupo.GetConteudo("empresa"), objGrupo.GetConteudo("cod_grupo"))
                End If

                objGrupo = CarregaObjeto(objGrupo)

                If Acao = "ALTERAR" Then
                    objGrupo.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    objGrupo.Incluir()
                    Session("SAcaoGrupoTEF") = "ALTERAR"
                End If

                LblErro.Text = "Os dados foram salvos com sucesso."
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub CarregaDropDowns()
        Call CarregaAdquirentePadrao()
        Call CarregaOperadoraPadrao()
    End Sub

    Private Sub CarregaAdquirentePadrao()
        Try
            Dim objAdquirente As New UCLTefAdquirente
            objAdquirente.FillDropDown(DdlAdquirentePadrao, True, "(selecione)", "-1", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaOperadoraPadrao()
        Try
            Dim objOperadora As New UCLTefOperadora
            objOperadora.FillDropDown(DdlOperadoraPadrao, True, "(selecione)", "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        Try
            Dim objAtendimento As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objStatusChamado As New UCLStatusChamado
            Dim tmpChamado As String
            LblErro.Text = ""

            If String.IsNullOrEmpty(TxtDescricao.Text) Then
                LblErro.Text += "Preencha o campo Nome da Rede/Campanha.<br/>"
            End If

            Return LblErro.Text.Trim = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Function CarregaObjeto(ByRef objGrupo As UCLTefGrupo) As UCLTefGrupo

        objGrupo.SetConteudo("nome_rede", TxtDescricao.Text.GetValidInputContent)
        objGrupo.SetConteudo("nome_responsavel", TxtNomeResponsavel.Text.GetValidInputContent)
        objGrupo.SetConteudo("telefone_responsavel", TxtTelefoneResponsavel.Text.GetValidInputContent)
        objGrupo.SetConteudo("email_responsavel", TxtEmailResponsavel.Text.GetValidInputContent)
        objGrupo.SetConteudo("cod_adquirente_padrao", IIf(DdlAdquirentePadrao.SelectedValue = "0", "", DdlAdquirentePadrao.SelectedValue))
        objGrupo.SetConteudo("cod_operadora", IIf(DdlOperadoraPadrao.SelectedValue = "0", "", DdlOperadoraPadrao.SelectedValue))
        objGrupo.SetConteudo("valor_instalacao", TxtValorInstalacao.Text)
        objGrupo.SetConteudo("valor_mensalidade", TxtValorMensalidade.Text)
        objGrupo.SetConteudo("valor_reinstalacao", TxtValorReinstalacao.Text)
        objGrupo.SetConteudo("valor_mensalidade_pdv_adicional", TxtValorMensalidadePDVAdicional.Text)
        objGrupo.SetConteudo("valor_poo", TxtValorPOO.Text)
        objGrupo.SetConteudo("valor_pos", TxtValorPOS.Text)
        objGrupo.SetConteudo("valor_repasse", TxtValorRepasse.Text)

        Return objGrupo
    End Function

    Private Sub CarregaFormulario()
        Dim objGrupo As New UCLTefGrupo

        TxtCodGrupo.Text = CodGrupo
        objGrupo.Buscar(Session("GlEmpresa"), CodGrupo)
        TxtDescricao.Text = objGrupo.GetConteudo("nome_rede")
        TxtNomeResponsavel.Text = objGrupo.GetConteudo("nome_responsavel")
        TxtTelefoneResponsavel.Text = objGrupo.GetConteudo("telefone_responsavel")
        TxtEmailResponsavel.Text = objGrupo.GetConteudo("email_responsavel")
        DdlAdquirentePadrao.SelectedValue = objGrupo.GetConteudo("cod_adquirente_padrao")
        DdlOperadoraPadrao.SelectedValue = objGrupo.GetConteudo("cod_operadora")
        TxtValorInstalacao.Text = objGrupo.GetConteudo("valor_instalacao")
        TxtValorMensalidade.Text = objGrupo.GetConteudo("valor_mensalidade")
        TxtValorReinstalacao.Text = objGrupo.GetConteudo("valor_reinstalacao")
        TxtValorMensalidadePDVAdicional.Text = objGrupo.GetConteudo("valor_mensalidade_pdv_adicional")
        TxtValorPOO.Text = objGrupo.GetConteudo("valor_poo")
        TxtValorPOS.Text = objGrupo.GetConteudo("valor_pos")
        TxtValorRepasse.Text = objGrupo.GetConteudo("valor_repasse")
    End Sub

    Private Sub CarregaNovaPK()
        Dim objGrupo As New UCLTefGrupo()
        TxtCodGrupo.Text = objGrupo.GetProximoCodigo(Session("GlEmpresa"))
    End Sub

End Class