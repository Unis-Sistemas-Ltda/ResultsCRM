Partial Public Class WUCSolicitacaoDesenvolvimento
    Inherits System.Web.UI.UserControl

    Public Property Empresa As String
    Public Property CodSolicitacao As String
    Public Property Acao As String

    Public Property AcaoOriginal() As String
        Get
            Return Session("SAcaoOriginal")
        End Get
        Set(ByVal value As String)
            Session("SAcaoOriginal") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim alterouCodCliente As Long
        Dim CodClientePesquisado As String
        If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
            alterouCodCliente = Session("SAlterouCodCliente")
        Else
            alterouCodCliente = 0
        End If

        CodClientePesquisado = Session("SCodClientePesquisado")

        If Not String.IsNullOrEmpty(CodClientePesquisado) Then
            If alterouCodCliente > 0 Then
                If TxtCliente.Text <> CodClientePesquisado Then
                    TxtCliente.Text = CodClientePesquisado
                    Call CodigoClienteMudou()
                End If
                Session("SAlterouCodCliente") = alterouCodCliente - 1
            End If
        End If

        If Not IsPostBack Then
            Call CarregaDropDowns()
            AcaoOriginal = Acao
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Session("SAcaoSolicitacao") = Acao
                Call CarregaNovaPK()
                txtDataSolicitacao.Text = Now.Date.ToString("dd/MM/yyyy")
                If ddlAnalista.Items.FindByValue(Session("GlCodUsuario")) IsNot Nothing Then
                    ddlAnalista.SelectedValue = Session("GlCodUsuario")
                End If
                Call CarregaFrame(WUCFrame1, "WGSolicitacaoDesenvolvimentoFollowUp.aspx")
            End If
        End If
    End Sub

    Private Sub CarregaDropDowns()
        Call CarregaAnalista()
        Call CarregaSistema()
        Call CarregaVersao()
    End Sub

    Private Sub CarregaVersao()
        Dim ObjVersaoSistema As New UCLBancoDadosVersao
        ObjVersaoSistema.FillDropDown(DdlReleaseVersaoBanco, True, "")
    End Sub

    Private Sub CarregaAnalista()
        Dim objAnalista As New UCLAnalista
        objAnalista.FillDropDown(ddlAnalista, False, "", "", True, False, Session("GlCodUsuario"), "")
        objAnalista.FillDropDown(ddlDesenvolvedor, True, "", "0", True, False, Session("GlCodUsuario"), "")
    End Sub

    Private Sub CarregaSistema()
        Dim objSistema As New UCLSistema
        objSistema.FillDropDown(DdlSistema)
    End Sub

    Private Function Gravar() As Boolean
        Dim ObjSolicitacao As New UCLSolicitacaoDesenvolvimento()
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjSolicitacao.CodSolicitacao = LblCodSolicitacao.Text
                    ObjSolicitacao.Empresa = Session("GlEmpresa")
                    ObjSolicitacao.Buscar()
                    ObjSolicitacao = CarregaObjeto(ObjSolicitacao)
                    ObjSolicitacao.Alterar()
                    LblErro.Text = "Dados salvos com sucesso."
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjSolicitacao.CodSolicitacao = LblCodSolicitacao.Text
                    ObjSolicitacao.Empresa = Session("GlEmpresa")
                    ObjSolicitacao.Buscar()
                    ObjSolicitacao = CarregaObjeto(ObjSolicitacao)
                    ObjSolicitacao.Incluir()
                    LblErro.Text = "Dados salvos com sucesso."
                    Session("SAcao") = "ALTERAR"
                    Session("SCodSolicitacao") = LblCodSolicitacao.Text
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Call Gravar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(txtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Nome.<br/>"
        End If

        If String.IsNullOrEmpty(txtAssunto.Text) Then
            LblErro.Text += "Preencha o campo Assunto.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjSolicitacaoDesenvolvimento As UCLSolicitacaoDesenvolvimento) As UCLSolicitacaoDesenvolvimento
        ObjSolicitacaoDesenvolvimento.Empresa = Session("GlEmpresa")
        ObjSolicitacaoDesenvolvimento.CodSolicitacao = LblCodSolicitacao.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.DataSolicitacao = txtDataSolicitacao.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.Origem = DdlOrigem.SelectedValue
        ObjSolicitacaoDesenvolvimento.CodAnalista = ddlAnalista.SelectedValue
        ObjSolicitacaoDesenvolvimento.CodDesenvolvedor = ddlDesenvolvedor.SelectedValue
        ObjSolicitacaoDesenvolvimento.CodEmitente = TxtCliente.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.CodSistema = DdlSistema.SelectedValue
        ObjSolicitacaoDesenvolvimento.Descricao = txtDescricao.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.RegraNegocio = txtRegraNegocio.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.Urgencia = ddlUrgencia.SelectedValue
        ObjSolicitacaoDesenvolvimento.PrazoObrigatorio = ChkPrazoObrigatorio.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjSolicitacaoDesenvolvimento.DataObrigatoria = txtPrazoObrigatorio.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.DataPrevisaoEntrega = txtDataEntregaPrevista.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.EmailClienteAprovar = ChkClienteAprovar.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjSolicitacaoDesenvolvimento.Assunto = txtAssunto.Text
        ObjSolicitacaoDesenvolvimento.ProximaVisita = txtProximaVisita.Text
        ObjSolicitacaoDesenvolvimento.Status = DdlStatus.SelectedValue
        ObjSolicitacaoDesenvolvimento.Tipo = DdlTipo.SelectedValue
        If DdlReleaseVersaoBanco.SelectedValue = "0" Then
            ObjSolicitacaoDesenvolvimento.Versao = ""
            ObjSolicitacaoDesenvolvimento.Release = ""
        Else
            ObjSolicitacaoDesenvolvimento.Versao = "1"
            ObjSolicitacaoDesenvolvimento.Release = DdlReleaseVersaoBanco.SelectedValue
        End If
        Return ObjSolicitacaoDesenvolvimento
    End Function

    Private Sub CarregaFormulario()
        Dim ObjSolicitacaoDesenvolvimento As New UCLSolicitacaoDesenvolvimento()
        Dim ObjUsuario As New UCLUsuario

        ObjSolicitacaoDesenvolvimento.CodSolicitacao = CodSolicitacao
        ObjSolicitacaoDesenvolvimento.Empresa = Session("GlEmpresa")
        ObjSolicitacaoDesenvolvimento.Buscar()
        LblCodSolicitacao.Text = CodSolicitacao
        DdlTipo.SelectedValue = ObjSolicitacaoDesenvolvimento.Tipo
        txtDataSolicitacao.Text = ObjSolicitacaoDesenvolvimento.DataSolicitacao
        txtDataEntregaPrevista.Text = ObjSolicitacaoDesenvolvimento.DataPrevisaoEntrega
        DdlOrigem.SelectedValue = ObjSolicitacaoDesenvolvimento.Origem
        ddlAnalista.SelectedValue = ObjSolicitacaoDesenvolvimento.CodAnalista
        ddlDesenvolvedor.SelectedValue = ObjSolicitacaoDesenvolvimento.CodDesenvolvedor
        TxtCliente.Text = ObjSolicitacaoDesenvolvimento.CodEmitente
        DdlSistema.SelectedValue = ObjSolicitacaoDesenvolvimento.CodSistema
        txtDescricao.Text = ObjSolicitacaoDesenvolvimento.Descricao
        txtRegraNegocio.Text = ObjSolicitacaoDesenvolvimento.RegraNegocio
        ddlUrgencia.SelectedValue = ObjSolicitacaoDesenvolvimento.Urgencia
        If Not String.IsNullOrWhiteSpace(ObjSolicitacaoDesenvolvimento.PrazoObrigatorio) Then
            ChkPrazoObrigatorio.Checked = ObjSolicitacaoDesenvolvimento.PrazoObrigatorio.ToString.Replace("N", "False").Replace("S", "True")
        End If
        txtPrazoObrigatorio.Text = ObjSolicitacaoDesenvolvimento.DataObrigatoria
        If Not String.IsNullOrWhiteSpace(ObjSolicitacaoDesenvolvimento.EmailClienteAprovar) Then
            ChkClienteAprovar.Checked = ObjSolicitacaoDesenvolvimento.EmailClienteAprovar.ToString.Replace("N", "False").Replace("S", "True")
        End If
        txtAssunto.Text = ObjSolicitacaoDesenvolvimento.Assunto
        txtProximaVisita.Text = ObjSolicitacaoDesenvolvimento.ProximaVisita
        DdlStatus.SelectedValue = ObjSolicitacaoDesenvolvimento.Status
        If DdlReleaseVersaoBanco.Items.FindByValue(ObjSolicitacaoDesenvolvimento.Release) IsNot Nothing Then
            DdlReleaseVersaoBanco.SelectedValue = ObjSolicitacaoDesenvolvimento.Release
        End If
        Call CodigoClienteMudou()
        Call CarregaFrame(WUCFrame1, "WGSolicitacaoDesenvolvimentoFollowUp.aspx")
    End Sub

    Private Sub CarregaNovaPK()
        Dim objSolicitacaoDesenvolvimento As New UCLSolicitacaoDesenvolvimento()
        objSolicitacaoDesenvolvimento.Empresa = Session("GlEmpresa")
        LblCodSolicitacao.Text = objSolicitacaoDesenvolvimento.GetProximoCodigo
    End Sub

    Private Sub MostraNomeCliente()
        Try
            Dim ObjEmitente As New UCLEmitente(StrConexao)
            ObjEmitente.CodEmitente = TxtCliente.Text
            ObjEmitente.Buscar()
            LblNomeCliente.Text = ObjEmitente.Nome
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub CodigoClienteMudou()
        Call MostraNomeCliente()
        'Session("SCodEmitenteNegociacao") = TxtCliente.Text
        Session("SCodClientePesquisado") = TxtCliente.Text
    End Sub

    Protected Sub TxtCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCliente.TextChanged
        Call CodigoClienteMudou()
    End Sub

    Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.DataBind()
    End Sub
End Class