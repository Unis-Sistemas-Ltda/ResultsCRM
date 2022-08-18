Public Partial Class WUCNegociacaoTarefa
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodNegociacao As String
    Private _SeqTarefa As String
    Private _Chamada As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodNegociacao() As String
        Get
            Return _CodNegociacao
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property

    Public Property SeqTarefa() As String
        Get
            Return _SeqTarefa
        End Get
        Set(ByVal value As String)
            _SeqTarefa = value
        End Set
    End Property

    Public Property Chamada() As String
        Get
            Return _Chamada
        End Get
        Set(ByVal value As String)
            _Chamada = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DdlTarefaPadrao.Attributes.Add("OnChange", "if(confirm('Deseja carregar os campos com base no cadastro da tarefa padrão?')) submit(); ")
        If Not IsPostBack Then
            Call CarregaResponsavel()
            Call CarregaTarefaPadrao()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            Else
                Call CarregaNovaPK()
                TxtDataCadastro.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy")
            End If
        End If
    End Sub


    Private Function IsDigitacaoOK()
        LblErro.Text = ""

        If DdlResponsavel.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Responsável.<br/>"
        End If

        If String.IsNullOrEmpty(TxtDataCadastro.Text) Then
            LblErro.Text += "Preencha o campo Data Cadastro.<br/>"
        End If

        If String.IsNullOrEmpty(TxtPrevisaoFinalizacao.Text) Then
            LblErro.Text += "Preencha o campo Data Cadastro.<br/>"
        End If

        Return LblErro.Text = ""
    End Function

    Private Function CarregaObjeto(ByRef objNegociacaoTarefa As UCLNegociacaoTarefa) As UCLNegociacaoTarefa

        objNegociacaoTarefa.CodTarefaPadrao = DdlTarefaPadrao.SelectedValue
        objNegociacaoTarefa.Prioridade = DdlPrioridade.SelectedValue
        objNegociacaoTarefa.CodResponsavel = DdlResponsavel.SelectedValue
        objNegociacaoTarefa.ManterInformado = TxtManterInformado.Text
        objNegociacaoTarefa.DataCadastro = TxtDataCadastro.Text
        objNegociacaoTarefa.PrevisaoFinalizacao = TxtPrevisaoFinalizacao.Text
        objNegociacaoTarefa.Situacao = DdlSituacao.SelectedValue
        objNegociacaoTarefa.DataConclusao = TxtDataConclusao.Text
        objNegociacaoTarefa.Titulo = TxtTitulo.Text
        objNegociacaoTarefa.Observacao = TxtObservacao.Text
        objNegociacaoTarefa.ObservacaoInterna = TxtObservacaoInterna.Text

        Return objNegociacaoTarefa
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objNegociacaoTarefa As New UCLNegociacaoTarefa(StrConexaoUsuario(Session("GlUsuario")))
        Try
            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objNegociacaoTarefa.CodNegociacaoCliente = CodNegociacao
                    objNegociacaoTarefa.SeqTarefa = SeqTarefa
                    objNegociacaoTarefa.Empresa = Session("GlEmpresa")
                    objNegociacaoTarefa.Estabelecimento = Session("SEstabelecimentoNegociacao")
                    objNegociacaoTarefa.Buscar()
                    objNegociacaoTarefa = CarregaObjeto(objNegociacaoTarefa)
                    objNegociacaoTarefa.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objNegociacaoTarefa.CodNegociacaoCliente = CodNegociacao
                    objNegociacaoTarefa.SeqTarefa = LblSeqTarefa.Text
                    objNegociacaoTarefa.Empresa = Session("GlEmpresa")
                    objNegociacaoTarefa.Estabelecimento = Session("SEstabelecimentoNegociacao")
                    objNegociacaoTarefa.Buscar()
                    objNegociacaoTarefa = CarregaObjeto(objNegociacaoTarefa)
                    objNegociacaoTarefa.Incluir()
                End If
                If Chamada = 0 Then
                    Response.Redirect("WGNegociacaoHistorico.aspx")
                Else
                    Response.Redirect("WGTarefas.aspx")
                End If

            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If Chamada = 0 Then
            Response.Redirect("WGNegociacaoHistorico.aspx")
        Else
            Response.Redirect("WGTarefas.aspx")
        End If
    End Sub

    Protected Sub CarregaFormulario()
        Dim objNegociacaoTarefa As New UCLNegociacaoTarefa(StrConexaoUsuario(Session("GlUsuario")))
        objNegociacaoTarefa.Empresa = Session("GlEmpresa")
        objNegociacaoTarefa.Estabelecimento = Session("SEstabelecimentoNegociacao")
        objNegociacaoTarefa.CodNegociacaoCliente = CodNegociacao
        objNegociacaoTarefa.SeqTarefa = SeqTarefa
        objNegociacaoTarefa.Buscar()
        LblSeqTarefa.Text = objNegociacaoTarefa.SeqTarefa
        DdlTarefaPadrao.SelectedValue = objNegociacaoTarefa.CodTarefaPadrao
        DdlPrioridade.SelectedValue = objNegociacaoTarefa.Prioridade
        DdlResponsavel.Text = objNegociacaoTarefa.CodResponsavel
        TxtManterInformado.Text = objNegociacaoTarefa.ManterInformado
        TxtDataCadastro.Text = objNegociacaoTarefa.DataCadastro
        TxtPrevisaoFinalizacao.Text = objNegociacaoTarefa.PrevisaoFinalizacao
        DdlSituacao.SelectedValue = objNegociacaoTarefa.Situacao
        TxtDataConclusao.Text = objNegociacaoTarefa.DataConclusao
        TxtTitulo.Text = objNegociacaoTarefa.Titulo
        TxtObservacao.Text = objNegociacaoTarefa.Observacao
        TxtObservacaoInterna.Text = objNegociacaoTarefa.ObservacaoInterna
    End Sub

    Private Sub CarregaNovaPK()
        Dim objNegociacaoTarefa As New UCLNegociacaoTarefa(StrConexaoUsuario(Session("GlUsuario")))
        objNegociacaoTarefa.Empresa = Session("GlEmpresa")
        objNegociacaoTarefa.Estabelecimento = Session("SEstabelecimentoNegociacao")
        objNegociacaoTarefa.CodNegociacaoCliente = CodNegociacao
        LblSeqTarefa.Text = objNegociacaoTarefa.GetProximoCodigo()
    End Sub

    Private Sub CarregaResponsavel()
        Dim objUsuario As New UCLUsuario
        objUsuario.FillControl(DdlResponsavel, True, "")
    End Sub

    Private Sub CarregaTarefaPadrao()
        Dim objTarefaPadrao As New UCLTarefaPadrao
        objTarefaPadrao.FillDropDown(DdlTarefaPadrao, True, "")
    End Sub

    Protected Sub DdlTarefaPadrao_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlTarefaPadrao.SelectedIndexChanged
        Call CarregaDadosTarefaPadrao()
    End Sub

    Protected Sub CarregaDadosTarefaPadrao()
        Dim objTarefaPadrao As New UCLTarefaPadrao
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))

        objNegociacao.Empresa = Session("GlEmpresa")
        objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
        objNegociacao.CodNegociacao = CodNegociacao

        objTarefaPadrao.CodTarefaPadrao = DdlTarefaPadrao.SelectedValue
        If objTarefaPadrao.CodTarefaPadrao <> "0" Then
            objTarefaPadrao.Buscar()
            TxtDataCadastro.Text = Today.ToString("dd/MM/yyyy")
            objNegociacao.Buscar()
            If objTarefaPadrao.TipoResponsavel = "1" AndAlso Not String.IsNullOrEmpty(objNegociacao.CodAgenteVenda) Then
                If DdlResponsavel.Items.FindByValue(objNegociacao.CodAgenteVenda) IsNot Nothing Then
                    DdlResponsavel.SelectedValue = objNegociacao.CodAgenteVenda
                End If
            ElseIf objTarefaPadrao.TipoResponsavel = "2" AndAlso Not String.IsNullOrEmpty(objNegociacao.CodGestorConta) Then
                If DdlResponsavel.Items.FindByValue(objNegociacao.CodGestorConta) IsNot Nothing Then
                    DdlResponsavel.SelectedValue = objNegociacao.CodGestorConta
                End If
            End If
            TxtManterInformado.Text = objTarefaPadrao.ManterInformado
            TxtObservacao.Text = objTarefaPadrao.Observacao
            If objTarefaPadrao.DiasPrevisao > 0 Then
                TxtPrevisaoFinalizacao.Text = (DateAdd(DateInterval.Day, CInt(objTarefaPadrao.DiasPrevisao), Today)).ToString("dd/MM/yyyy")
            End If
            TxtTitulo.Text = objTarefaPadrao.Titulo
            DdlPrioridade.SelectedValue = objTarefaPadrao.Prioridade
        End If

    End Sub
End Class