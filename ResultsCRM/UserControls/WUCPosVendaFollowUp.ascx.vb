Partial Public Class WUCPosVendaFollowUp
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodEmitente As String
    Private _SeqFollowUp As String

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
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
                LblCodUsuario.Text = Session("GlCodUsuario")
                LblNomeUsuario.Text = Session("GlNomeUsuario")
                CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjFollowUp As New UCLEmitenteFollowUp(StrConexaoUsuario(Session("GlUsuario")))
        Dim objUsuario As New UCLUsuario
        ObjFollowUp.Empresa = Session("GlEmpresa")
        ObjFollowUp.CodEmitente = CodEmitente
        ObjFollowUp.SeqFollowUP = SeqFollowUp
        ObjFollowUp.Buscar()

        LblSeq.Text = ObjFollowUp.SeqFollowUP
        LblCodUsuario.Text = ObjFollowUp.CodUsuario
        TxtData.Text = ObjFollowUp.DataFollowUp
        TxtHora.Text = ObjFollowUp.HoraFollowUp
        TxtDescricao.Text = ObjFollowUp.Descricao

        objUsuario.CodUsuario = ObjFollowUp.CodUsuario
        objUsuario.BuscarPorCodigo()
        LblNomeUsuario.Text = objUsuario.NomeUsuario

    End Sub

    Private Sub CarregaNovaPK()
        Dim objEmitenteFollowUp As New UCLEmitenteFollowUp(StrConexaoUsuario(Session("GlUsuario")))

        objEmitenteFollowUp.Empresa = Session("GlEmpresa")
        objEmitenteFollowUp.CodEmitente = CodEmitente
        LblSeq.Text = objEmitenteFollowUp.GetProximoCodigo
        SeqFollowUp = LblSeq.Text

        TxtData.Text = Date.Now.ToString("dd/MM/yyyy")
        TxtHora.Text = DateTime.Now.ToString("HH:mm")
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objFollowUp As New UCLEmitenteFollowUp(StrConexaoUsuario(Session("GlUsuario")))
        Dim retEmail As String
        Dim erroEmail As Boolean
        'Dim enviaEmailAtual As String
        'Dim enviaEmailAnterior As String
        Try
            retEmail = ""
            erroEmail = False

            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objFollowUp.CodEmitente = CodEmitente
                    objFollowUp.SeqFollowUP = SeqFollowUp
                    objFollowUp.Empresa = Session("GlEmpresa")
                    objFollowUp.Buscar()
                    objFollowUp = CarregaObjetos(objFollowUp)
                    objFollowUp.Alterar()
                    LblErro.Text = "Follow-up foi alterado com sucesso. "

                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objFollowUp.CodEmitente = CodEmitente
                    objFollowUp.SeqFollowUP = SeqFollowUp
                    objFollowUp.Empresa = Session("GlEmpresa")
                    objFollowUp = CarregaObjetos(objFollowUp)
                    objFollowUp.Incluir()
                    LblErro.Text = "Follow-up foi incluído com sucesso. "

                    Session("SAcaoFollowUp") = "ALTERAR"
                    Session("SSeqFolowUp") = LblSeq.Text
                End If

                erroEmail = False

                If Not erroEmail Then
                    Response.Redirect("WGPosVendaFollowUP.aspx")
                End If

            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Function CarregaObjetos(ByRef objFollowUp As UCLEmitenteFollowUp) As UCLEmitenteFollowUp

        objFollowUp.DataFollowUp = TxtData.Text
        objFollowUp.HoraFollowUp = TxtHora.Text
        objFollowUp.Tipo = 1
        objFollowUp.Estabelecimento = Session("GlEstabelecimento")
        objFollowUp.Descricao = TxtDescricao.Text.RetiraAspas
        objFollowUp.CodUsuario = LblCodUsuario.Text

        Return objFollowUp
    End Function

    Private Function IsDigitacaoOK()
        LblErro.Text = ""

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
        Response.Redirect("WGPosVendaFollowUp.aspx")
    End Sub
End Class