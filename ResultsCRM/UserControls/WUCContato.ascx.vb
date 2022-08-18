Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Linq

Partial Public Class WUCContato
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodContato As String
    Private _CodEmitente As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
        End Set
    End Property

    Public Property CodContato() As String
        Get
            Return _CodContato
        End Get
        Set(ByVal value As String)
            _CodContato = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CarregaTipoContato()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
            If Not ExisteVariavelQueryString("vrecc") Then
                BtnVoltar.Visible = True
                Page.ClientScript.RegisterStartupScript(Me.GetType, "onload", "OcultarBotaoFechar();", True)
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType, "onload", "ExibirBotaoFechar();", True)
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjContato As New UCLContato
        LblCodContato.Text = CodContato

        ObjContato.CodEmitente = CodEmitente
        ObjContato.Codigo = CodContato
        ObjContato.Buscar()

        TxtNome.Text = ObjContato.Nome
        TxtTitulo.Text = ObjContato.Titulo
        RblPreferencial.SelectedValue = ObjContato.Preferencial
        RblAtivo.SelectedValue = ObjContato.Ativo
        TxtCPF.Text = ObjContato.CPF.MascaraCPF
        TxtRG.Text = ObjContato.RG
        TxtTelefone1.Text = ObjContato.Telefone
        TxtTelefone2.Text = ObjContato.Telefone2
        TxtCelular1.Text = ObjContato.Celular
        TxtCelular2.Text = ObjContato.Celular2
        TxtWhatsApp.Text = ObjContato.WhatsApp
        TxtEmail.Text = ObjContato.Email
        TxtMatricula.Text = ObjContato.Matricula
        DdlTipo.SelectedValue = ObjContato.Tipo
        ChkRecebeEmailCobranca.Checked = ObjContato.RecebeEmailCobranca.ToString.Replace("N", "False").Replace("S", "True")
        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Regional Then
            TxtNome.Enabled = False
            TxtTitulo.Enabled = False
            RblPreferencial.Enabled = False
            RblAtivo.Enabled = False
            TxtRG.Enabled = False
            TxtMatricula.Enabled = False
        End If
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjContato As New UCLContato
        ObjContato.CodEmitente = CodEmitente
        LblCodContato.Text = ObjContato.GetProximoCodigo
    End Sub

    Private Sub CarregaTipoContato()
        Try
            Dim objTipo As New UCLContato
            objTipo.FillDropDownTipo(DdlTipo, True, " ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjContato As New UCLContato
        Dim recarregaContatos As Long

        If Not String.IsNullOrEmpty(Session(VariavelRecarregamento)) Then
            recarregaContatos = Session(VariavelRecarregamento)
        Else
            recarregaContatos = 0
        End If
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjContato.CodEmitente = CodEmitente
                    ObjContato.Codigo = LblCodContato.Text
                    ObjContato.Buscar()
                    ObjContato = CarregaObjeto(ObjContato)
                    ObjContato.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjContato.CodEmitente = CodEmitente
                    ObjContato.Codigo = LblCodContato.Text
                    ObjContato = CarregaObjeto(ObjContato)
                    ObjContato.Incluir()
                End If
                recarregaContatos += 2
                If ExisteVariavelQueryString("vrecc") Then
                    Session(VariavelRecarregamento) = recarregaContatos
                    Session(VariavelCodContato) = LblCodContato.Text
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
                Else
                    If Not String.IsNullOrEmpty(Session("SCamVoltar")) Then
                        Response.Redirect(Session("SCamVoltar"))
                    End If
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtNome.Text) Then
            LblErro.Text += "Preencha o campo Nome. Este é um campo obrigatório<br/>"
        End If

        If Not String.IsNullOrEmpty(TxtCPF.Text) AndAlso Not TxtCPF.Text.IsValidCPF Then
            LblErro.Text += "O CPF informado não é válido.<br/>"
        End If

        If String.IsNullOrEmpty(DdlTipo.SelectedValue) Or DdlTipo.SelectedValue = 0 Then
            LblErro.Text += "Preencha o campo Tipo de Contato. Este é um campo obrigatório<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjContato As UCLContato) As UCLContato

        ObjContato.Nome = TxtNome.Text.GetValidInputContent
        ObjContato.Titulo = TxtTitulo.Text.GetValidInputContent
        ObjContato.Preferencial = RblPreferencial.SelectedValue
        ObjContato.Ativo = RblAtivo.SelectedValue
        If RblAtivo.SelectedValue = "S" Then
            ObjContato.Situacao = "1"
        Else
            ObjContato.Situacao = "2"
        End If
        ObjContato.Tipo = DdlTipo.SelectedValue
        ObjContato.CPF = TxtCPF.Text.GetValidInputContent
        ObjContato.RG = TxtRG.Text.GetValidInputContent
        ObjContato.Telefone = TxtTelefone1.Text.GetValidInputContent
        ObjContato.Telefone2 = TxtTelefone2.Text.GetValidInputContent
        ObjContato.Celular = TxtCelular1.Text.GetValidInputContent
        ObjContato.Celular2 = TxtCelular2.Text.GetValidInputContent
        ObjContato.WhatsApp = TxtWhatsApp.Text.GetValidInputContent
        ObjContato.Email = TxtEmail.Text
        ObjContato.Matricula = TxtMatricula.Text.GetValidInputContent
        ObjContato.RecebeEmailCobranca = ChkRecebeEmailCobranca.Checked.ToString.Replace("False", "N").Replace("True", "S")
        If Not String.IsNullOrEmpty(Session(VariavelPontoAtendimento)) Then
            ObjContato.NumeroPontoAtendimento = Session(VariavelPontoAtendimento)
        End If

        Return ObjContato
    End Function

    Private Function ExisteVariavelQueryString(ByVal nome As String) As Boolean
        Try
            For i As Long = 0 To Request.QueryString.Count - 1
                If nome = Request.QueryString.AllKeys.GetValue(i) Then
                    Return True
                End If
            Next
            Return False

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public ReadOnly Property VariavelRecarregamento()
        Get
            If ExisteVariavelQueryString("vrecc") Then
                Return Request.QueryString.Item("vrecc").ToString
            Else
                Return ""
            End If
        End Get
    End Property

    Public ReadOnly Property VariavelCodContato()
        Get
            If ExisteVariavelQueryString("vcodc") Then
                Return Request.QueryString.Item("vcodc").ToString
            Else
                Return ""
            End If
        End Get
    End Property

    Public ReadOnly Property VariavelPontoAtendimento()
        Get
            If ExisteVariavelQueryString("ptat") Then
                Return Request.QueryString.Item("ptat").ToString
            Else
                Return ""
            End If
        End Get
    End Property

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect(Session("SCamVoltar"))
    End Sub
End Class