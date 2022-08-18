Public Class WUCEmitenteAssessoria
    Inherits System.Web.UI.UserControl

    Public Property Acao() As String
    Public Property CodEmitente() As String
    Public Property CodAssessoria() As String
    Public Property CodFornecedor() As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaDropDowns()
            End If
        Else
            Dim CodFornecedorPesquisado As String
            Dim alterouCodFornecedor As Long

            If Not String.IsNullOrEmpty(Session("SAlterouCodFornecedor")) Then
                alterouCodFornecedor = Session("SAlterouCodFornecedor")
            Else
                alterouCodFornecedor = 0
            End If

            CodFornecedorPesquisado = Session("SCodFornecedorPesquisado")

            If Not String.IsNullOrEmpty(CodFornecedorPesquisado) Then
                If alterouCodFornecedor > 0 Then
                    If TxtFornecedor.Text <> CodFornecedorPesquisado Then
                        TxtFornecedor.Text = CodFornecedorPesquisado
                    End If
                    Session("SAlterouCodFornecedor") = alterouCodFornecedor - 1
                End If
            End If
        End If
        Call MostraNomeFornecedor()
    End Sub

    Private Sub CarregaFormulario()
        Dim objEmitenteAssessoria As New UCLEmitenteAssessoria
        objEmitenteAssessoria.Buscar(Session("GlEmpresa"), CodEmitente, CodAssessoria, CodFornecedor)
        Call CarregaAssessoria()
        DdlAssessoria.SelectedValue = CodAssessoria
        TxtFornecedor.Text = CodFornecedor
        Session("SCodFornecedorPesquisado") = TxtFornecedor.Text
        Call CarregaEtapaAssessoria()
        DdlEtapa.SelectedValue = objEmitenteAssessoria.GetConteudo("cod_etapa")
        If Not objEmitenteAssessoria.IsNull("data_solicitacao") Then
            TxtDataSolicitacao.Text = objEmitenteAssessoria.GetConteudoData("data_solicitacao").ToString("dd/MM/yyyy")
        End If
        If Not objEmitenteAssessoria.IsNull("data_credenciamento") Then
            TxtDataCredenciamento.Text = objEmitenteAssessoria.GetConteudoData("data_credenciamento").ToString("dd/MM/yyyy")
        End If
        If Not objEmitenteAssessoria.IsNull("data_descredenciamento") Then
            TxtDataDescredenciamento.Text = objEmitenteAssessoria.GetConteudoData("data_descredenciamento").ToString("dd/MM/yyyy")
        End If
        TxtLogin.Text = objEmitenteAssessoria.GetConteudo("login")
        TxtSenha.Text = objEmitenteAssessoria.GetConteudo("senha")
        Session("SCodFornecedorAssessoria") = CodFornecedor
        Session("SCodAssessoria") = CodAssessoria
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objEmitenteAssessoria As New UCLEmitenteAssessoria
        Try
            If IsDigitacaoOk() Then

                If Acao = "ALTERAR" Then
                    'Busca com dados originais
                    objEmitenteAssessoria.Buscar(Session("GlEmpresa"), CodEmitente, CodAssessoria, CodFornecedor)
                    objEmitenteAssessoria = CarregaObjeto(objEmitenteAssessoria)

                    'Seta novos conteúdos de campos que fazem parte da chave
                    objEmitenteAssessoria.SetConteudo("cod_assessoria", DdlAssessoria.SelectedValue)
                    objEmitenteAssessoria.SetConteudo("cod_fornecedor", TxtFornecedor.Text)


                    'Seta PK origem com dados originais -------
                    Dim campoAssessoria As UCLTabelaGenericaCampo
                    campoAssessoria = objEmitenteAssessoria.CamposPK.Find(Function(x) x.NomeCampo = "cod_assessoria")
                    campoAssessoria.Conteudo = CodAssessoria
                    campoAssessoria.IsNull = False

                    Dim campoFornecedor As UCLTabelaGenericaCampo
                    campoFornecedor = objEmitenteAssessoria.CamposPK.Find(Function(x) x.NomeCampo = "cod_fornecedor")
                    campoFornecedor.Conteudo = CodFornecedor
                    campoFornecedor.IsNull = False
                    '-------------------------------------------
                    'Isso fará com que na cláusua where fique com os dados originais, mas no set fique com os dados novos

                    objEmitenteAssessoria.Alterar()
                    Session("SCodAssessoria") = DdlAssessoria.SelectedValue
                    Session("SCodFornecedorAssessoria") = TxtFornecedor.Text

                ElseIf Acao = "INCLUIR" Then
                    objEmitenteAssessoria.Buscar(Session("GlEmpresa"), CodEmitente, DdlAssessoria.Text, TxtFornecedor.Text)
                    objEmitenteAssessoria = CarregaObjeto(objEmitenteAssessoria)
                    objEmitenteAssessoria.Incluir()
                    Session("SAcaoEmitenteAssessoria") = "ALTERAR"
                    Session("SCodAssessoria") = DdlAssessoria.SelectedValue
                    Session("SCodFornecedorAssessoria") = TxtFornecedor.Text
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(DdlAssessoria.SelectedValue) OrElse DdlAssessoria.SelectedValue <= 0 Then
            LblErro.Text += "Preencha o campo Assessoria.<br/>"
        End If

        If String.IsNullOrEmpty(TxtFornecedor.Text) Then
            LblErro.Text += "Preencha o campo Fornecedor.<br/>"
        End If

        If String.IsNullOrEmpty(DdlEtapa.SelectedValue) OrElse DdlEtapa.SelectedValue <= 0 Then
            LblErro.Text += "Preencha o campo Etapa.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef objEmitenteAssessoria As UCLEmitenteAssessoria) As UCLEmitenteAssessoria
        objEmitenteAssessoria.SetConteudo("cod_etapa", DdlEtapa.SelectedValue)
        objEmitenteAssessoria.SetConteudo("data_solicitacao", TxtDataSolicitacao.Text)
        objEmitenteAssessoria.SetConteudo("data_credenciamento", TxtDataCredenciamento.Text)
        objEmitenteAssessoria.SetConteudo("data_descredenciamento", TxtDataDescredenciamento.Text)
        objEmitenteAssessoria.SetConteudo("login", TxtLogin.Text)
        objEmitenteAssessoria.SetConteudo("senha", TxtSenha.Text)
        If Acao = "INCLUIR" Then
            objEmitenteAssessoria.SetConteudo("cod_usuario_inclusao", Session("GlCodUsuario"))
            objEmitenteAssessoria.SetConteudo("data_inclusao", Now().ToString("yyyy-MM-dd HH:mm:ss.fff"))
        End If
        objEmitenteAssessoria.SetConteudo("cod_usuario_alteracao", Session("GlCodUsuario"))
        objEmitenteAssessoria.SetConteudo("data_alteracao", Now().ToString("yyyy-MM-dd HH:mm:ss.fff"))
        Return objEmitenteAssessoria
    End Function

    Private Sub CarregaDropDowns()
        Call CarregaAssessoria()
        Call CarregaEtapaAssessoria()
    End Sub

    Private Sub CarregaAssessoria()
        Dim objAssessoria As New UCLAssessoria
        objAssessoria.FillDropDown(DdlAssessoria, True, "(selecione)", 0)
    End Sub

    Private Sub CarregaEtapaAssessoria()
        Dim objEtapa As New UCLAssessoriaEtapa
        objEtapa.FillDropDown(DdlAssessoria.SelectedValue, DdlEtapa, True, "(selecione)", 0)
    End Sub

    Protected Sub DdlAssessoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlAssessoria.SelectedIndexChanged
        Call CarregaEtapaAssessoria()
    End Sub

    Protected Sub TxtFornecedor_TextChanged(sender As Object, e As EventArgs) Handles TxtFornecedor.TextChanged
        Session("SCodFornecedorPesquisado") = TxtFornecedor.Text
    End Sub

    Private Sub MostraNomeFornecedor()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            If Not String.IsNullOrEmpty(TxtFornecedor.Text) Then
                objEmitente.CodEmitente = TxtFornecedor.Text
                objEmitente.Buscar()
                LblNomeFornecedor.Text = objEmitente.Nome
            Else
                LblNomeFornecedor.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class