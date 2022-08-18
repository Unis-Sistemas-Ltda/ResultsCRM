Public Class WUCAvaliacao
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodAvaliacao As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodAvaliacao() As String
        Get
            Return _CodAvaliacao
        End Get
        Set(ByVal value As String)
            _CodAvaliacao = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim alterouCodCliente As Short
        Dim codClientePesquisado As String

        If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
            alterouCodCliente = Session("SAlterouCodCliente")
        Else
            alterouCodCliente = 0
        End If

        codClientePesquisado = Session("SCodClientePesquisado")

        If Not String.IsNullOrEmpty(codClientePesquisado) Then
            If alterouCodCliente > 0 Then
                If TxtCliente.Text <> codClientePesquisado Then
                    TxtCliente.Text = codClientePesquisado
                    Call CodigoClienteMudou()
                End If
                Session("SAlterouCodCliente") = alterouCodCliente - 1
            End If
        End If

        If Not IsPostBack Then
            Call CarregaDropDowns()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
                TxtDataAvaliacao.Text = Now.ToString("dd/MM/yyyy")
                DdlAvaliador.SelectedValue = Session("GlCodUsuario")
            End If
            Select Case Session("GlTipoAcesso")
                Case UCLUsuario.TipoAcesso.Representante
                    DdlAvaliador.Enabled = False
            End Select
        End If
    End Sub

    Sub CodigoClienteMudou()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

            Call CarregaCNPJ()

            If Not String.IsNullOrWhiteSpace(TxtCliente.Text) Then
                objEmitente.CodEmitente = TxtCliente.Text
                objEmitente.Buscar()
                LblNomeCliente.Text = objEmitente.Nome
            Else
                LblNomeCliente.Text = ""
            End If

            Session("SCodEmitenteNegociacao") = TxtCliente.Text
            Session("SCodClientePesquisado") = TxtCliente.Text

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaCNPJ()
        Try
            Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
            If Not String.IsNullOrEmpty(TxtCliente.Text) Then
                objEnderecoEmitente.CodEmitente = TxtCliente.Text
                objEnderecoEmitente.FillDropDownCNPJ(DdlCNPJ)
            Else
                DdlCNPJ.Items.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Dim objAvaliacao As New UCLAvaliacaoCliente
        objAvaliacao.Buscar(Session("GlEmpresa"), CodAvaliacao)
        TxtDataAvaliacao.Text = objAvaliacao.GetConteudoData("data_avaliacao").ToString("dd/MM/yyyy")
        DdlTipoAvaliacao.SelectedValue = objAvaliacao.GetConteudo("cod_tipo_avaliacao")
        DdlTipoAvaliacao.Enabled = False
        TxtCliente.Text = objAvaliacao.GetConteudo("cod_emitente")
        Call CodigoClienteMudou()
        DdlCNPJ.SelectedValue = objAvaliacao.GetConteudo("cnpj")
        DdlAvaliador.SelectedValue = objAvaliacao.GetConteudo("cod_avaliador")
    End Sub

    Private Sub CarregaNovaPK()
        Dim objAvaliacao As New UCLAvaliacaoCliente
        LblCodAvaliacao.Text = objAvaliacao.GetProximoCodigo(Session("GlEmpresa"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objAvaliacao As New UCLAvaliacaoCliente
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objAvaliacao.SetConteudo("empresa", Session("GlEmpresa"))
                    objAvaliacao.SetConteudo("cod_avaliacao", LblCodAvaliacao.Text)
                    objAvaliacao = CarregaObjeto(objAvaliacao)
                    objAvaliacao.Alterar()
                    LblErro.Text = "Dados foram alterados com sucesso."
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objAvaliacao.SetConteudo("empresa", Session("GlEmpresa"))
                    objAvaliacao.SetConteudo("cod_avaliacao", LblCodAvaliacao.Text)
                    objAvaliacao = CarregaObjeto(objAvaliacao)
                    objAvaliacao.Incluir()
                    LblErro.Text = "Dados foram incluídos com sucesso."
                    Session("SAcaoAvaliacao") = "ALTERAR"
                    Acao = Session("SAcaoAvaliacao")
                    Session("SCodAvaliacao") = LblCodAvaliacao.Text
                    CodAvaliacao = Session("SCodAvaliacao")
                    Call CarregaFormulario()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If Not isValidDate(TxtDataAvaliacao.Text) Then
            LblErro.Text += "Preencha corretamente o campo Data.<br/>"
        End If

        If DdlTipoAvaliacao.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Tipo Avaliação.<br/>"
        End If

        If String.IsNullOrEmpty(TxtCliente.Text) Then
            LblErro.Text += "Preencha o campo Código do Cliente.<br/>"
        ElseIf Not IsNumeric(TxtCliente.Text) Then
            LblErro.Text += "Preencha corretamente o campo Código do Cliente.<br/>"
        End If

        If DdlCNPJ.SelectedValue = "" Then
            LblErro.Text += "Preencha o campo CNPJ.<br/>"
        End If

        If DdlAvaliador.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Avaliador.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef objAvaliacao As UCLAvaliacaoCliente) As UCLAvaliacaoCliente
        objAvaliacao.SetConteudoData("data_avaliacao", CDate(TxtDataAvaliacao.Text))
        objAvaliacao.SetConteudo("cod_tipo_avaliacao", DdlTipoAvaliacao.SelectedValue)
        objAvaliacao.SetConteudo("cod_emitente", TxtCliente.Text)
        objAvaliacao.SetConteudo("cnpj", DdlCNPJ.SelectedValue)
        objAvaliacao.SetConteudo("cod_avaliador", DdlAvaliador.SelectedValue)

        If objAvaliacao.IsNull("cod_usuario_inclusao") Then
            objAvaliacao.SetConteudo("cod_usuario_inclusao", Session("GlCodUsuario"))
        End If
        If objAvaliacao.IsNull("data_inclusao") Then
            objAvaliacao.SetConteudo("data_inclusao", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        End If

        objAvaliacao.SetConteudo("cod_usuario_alteracao", Session("GlCodUsuario"))
        objAvaliacao.SetConteudo("data_alteracao", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))

        Return objAvaliacao
    End Function

    Protected Sub TxtCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCliente.TextChanged
        Try
            Call CodigoClienteMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub CarregaDropDowns()
        Dim objTipoAvaliacao As New UCLTipoAvaliacao
        Dim objAvaliador As New UCLUsuario
        objTipoAvaliacao.FillDropDown(Session("GlEmpresa"), DdlTipoAvaliacao, True, "(selecione)")
        objAvaliador.FillControl(DdlAvaliador, True, "(selecione)")
    End Sub

End Class