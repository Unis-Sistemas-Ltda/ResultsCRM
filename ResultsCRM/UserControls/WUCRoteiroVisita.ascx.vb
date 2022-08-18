Public Class WUCRoteiroVisita
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodRoteiro As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodRoteiro() As String
        Get
            Return _CodRoteiro
        End Get
        Set(ByVal value As String)
            _CodRoteiro = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Call CarregaRepresentante()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaRepresentante()
        Dim objEmitente As New UCLEmitente(StrConexao)
        objEmitente.FillDropDown(DdlRepresentante, True, "(selecione)", UCLEmitente.TipoEmitenteDDL.Representante, "0", True, UCLEmitente.TipoExibicaoDDL.Nome, Session("GlCodGestor"))
        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
            DdlRepresentante.SelectedValue = Session("GlCodEmitenteExterno")
            DdlRepresentante.Enabled = False
        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjRoteiro As New UCLRoteiroVisita
        ObjRoteiro.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"), CodRoteiro)
        LblCodRoteiro.Text = CodRoteiro
        Call CarregaRepresentante()
        DdlRepresentante.SelectedValue = ObjRoteiro.GetConteudo("cod_representante")
        TxtDataInicial.Text = ConverteDataDoBancoParaTela(ObjRoteiro.GetConteudo("data_inicio"))
        TxtDataFinal.Text = ConverteDataDoBancoParaTela(ObjRoteiro.GetConteudo("data_termino"))
        DdlSituacao.SelectedValue = ObjRoteiro.GetConteudo("situacao")
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjRoteiro As New UCLRoteiroVisita
        LblCodRoteiro.Text = ObjRoteiro.GetProximoCodigo(Session("GlEmpresa"), Session("GlEstabelecimento"))
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjRoteiro As New UCLRoteiroVisita
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjRoteiro.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjRoteiro.SetConteudo("estabelecimento", Session("GlEstabelecimento"))
                    ObjRoteiro.SetConteudo("cod_roteiro_visita", LblCodRoteiro.Text)
                    ObjRoteiro = CarregaObjeto(ObjRoteiro)
                    ObjRoteiro.Alterar()
                    LblErro.Text = "Dados alterados com sucesso."
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjRoteiro.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjRoteiro.SetConteudo("estabelecimento", Session("GlEstabelecimento"))
                    ObjRoteiro.SetConteudo("cod_roteiro_visita", LblCodRoteiro.Text)
                    ObjRoteiro = CarregaObjeto(ObjRoteiro)
                    ObjRoteiro.Incluir()
                    LblErro.Text = "Dados incluídos com sucesso."
                    Session("SCodRoteiroVisita") = LblCodRoteiro.Text
                    Session("SAcaoRoteiroVisita") = "ALTERAR"
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtDataInicial.Text) Then
            LblErro.Text += "Preencha o campo Data Inicial.<br/>"
        ElseIf Not isValidDate(TxtDataInicial.Text) Then
            LblErro.Text += "Preencha corretamente o campo Data Inicial.<br/>"
        End If

        If String.IsNullOrEmpty(TxtDataFinal.Text) Then
            LblErro.Text += "Preencha o campo Data Final.<br/>"
        ElseIf Not isValidDate(TxtDataFinal.Text) Then
            LblErro.Text += "Preencha corretamente o campo Data Final.<br/>"
        End If

        If String.IsNullOrEmpty(DdlRepresentante.SelectedValue) OrElse DdlRepresentante.SelectedValue = "0" Then
            LblErro.Text += "Selecione o vendedor/representante.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjRoteiro As UCLRoteiroVisita) As UCLRoteiroVisita
        ObjRoteiro.SetConteudo("data_inicio", TxtDataInicial.Text)
        ObjRoteiro.SetConteudo("data_termino", TxtDataFinal.Text)
        ObjRoteiro.SetConteudo("cod_representante", DdlRepresentante.SelectedValue)
        ObjRoteiro.SetConteudo("situacao", DdlSituacao.SelectedValue)
        Return ObjRoteiro
    End Function

    Private Sub GridView5_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView5.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SSeqVisita") = e.CommandArgument
            Session("SAcaoVisitacao") = "ALTERAR"
            Response.Redirect("WFRoteiroVisitaVisitacoesDetalhes.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objVisita As New UCLVisitacao
            objVisita.Excluir(Session("GlEmpresa"), Session("GlEstabelecimento"), e.CommandArgument)
            GridView5.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Acao = "INCLUIR" Then
            LblErro.Text = "Somente é permitido incluir registro de visita após salvar os dados do roteiro. Clique no botão Gravar junto aos dados do roteiro e depois tente novamente incluir a visita."
            Return
        End If
        Session("SAcaoVisitacao") = "INCLUIR"
        Session("SSeqVisita") = -1
        Response.Redirect("WFRoteiroVisitaVisitacoesDetalhes.aspx")
    End Sub

End Class