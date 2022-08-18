Public Class WUCAdesaoTEFFollowUp
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _Empresa As String
    Private _CodEmitente As String
    Private _SeqFollowUp As String

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
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
                Call CarregaFormularioInclusao()
            End If
        End If
    End Sub

    Private Sub CarregaFormularioInclusao()
        LblCodUsuario.Text = Session("GlCodUsuario")
        LblNomeUsuario.Text = Session("GlNomeUsuario")
        CarregaNovaPK()
    End Sub


    Private Sub CarregaFormulario()
        Dim ObjFollowUp As New UCLAdesaoTEFFollowUp
        Dim objUsuario As New UCLUsuario
        Dim objAnexo As New UCLAtendimentoFollowUpAnexo(StrConexaoUsuario(Session("GlUsuario")))

        ObjFollowUp.Buscar(Empresa, CodEmitente, SeqFollowUp)

        LblSeq.Text = ObjFollowUp.GetConteudo("seq_follow_up")
        LblCodUsuario.Text = ObjFollowUp.GetConteudo("cod_usuario_inclusao")
        TxtDescricao.Text = ObjFollowUp.GetConteudo("descricao")

        objUsuario.CodUsuario = ObjFollowUp.GetConteudo("cod_usuario_inclusao")
        objUsuario.BuscarPorCodigo()
        LblNomeUsuario.Text = objUsuario.NomeUsuario
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjFollowUp As New UCLAdesaoTEFFollowUp

        LblSeq.Text = ObjFollowUp.getProximoCodigo(Empresa, CodEmitente)
        
        SeqFollowUp = LblSeq.Text
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objFollowUp As New UCLAdesaoTEFFollowUp
            Dim objAdesaoTEFLoja As New UCLAdesaoTEFLoja
            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objFollowUp.Buscar(Empresa, CodEmitente, SeqFollowUp)
                    objFollowUp = CarregaObjeto(objFollowUp)
                    objFollowUp.Alterar()

                    LblErro.Text = "Follow-up foi alterado com sucesso. "
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objAdesaoTEFLoja.Buscar(Empresa, CodEmitente, Session("SCNPJLoja"))
                    objFollowUp.SetConteudo("empresa", Empresa)
                    objFollowUp.SetConteudo("cod_emitente", CodEmitente)
                    objFollowUp.SetConteudo("cnpj", objAdesaoTEFLoja.GetConteudo("cnpj"))
                    objFollowUp.SetConteudo("seq_follow_up", LblSeq.Text)
                    objFollowUp = CarregaObjeto(objFollowUp)
                    objFollowUp.Incluir()

                    LblErro.Text = "Follow-up foi incluído com sucesso. "

                    Session("SAcaoFollowUp") = "ALTERAR"
                    Session("SSeqFolowUp") = LblSeq.Text
                End If

                Response.Redirect("WGTEFFollowUp.aspx")

            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Function CarregaObjeto(ByRef objFollowUp As UCLAdesaoTEFFollowUp) As UCLAdesaoTEFFollowUp
        objFollowUp.SetConteudo("cod_usuario_inclusao", LblCodUsuario.Text)
        If Acao = "INCLUIR" Then
            objFollowUp.SetConteudo("data_inclusao", Now.ToString("yyyy-MM-dd HH:mm:ss"))
        End If
        objFollowUp.SetConteudo("cod_usuario_alteracao", Session("GlCodUsuario"))
        objFollowUp.SetConteudo("data_alteracao", Now.ToString("yyyy-MM-dd HH:mm:ss"))
        objFollowUp.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        Return objFollowUp
    End Function

    Private Function IsDigitacaoOK()
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha corretamente campo Comentário.<br/>"
        End If

        Return LblErro.Text = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGTEFFollowUp.aspx")
    End Sub

End Class