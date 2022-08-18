Public Class WUCProblema
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodProblema As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodProblema() As String
        Get
            Return _CodProblema
        End Get
        Set(ByVal value As String)
            _CodProblema = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaGrupo()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjProblema As New UCLProblemaPadrao
        LblCodProblema.Text = CodProblema

        ObjProblema.Buscar(Session("GlEmpresa"), LblCodProblema.Text)

        TxtAssunto.Text = ObjProblema.GetConteudo("assunto")
        TxtPergunta.Text = ObjProblema.GetConteudo("pergunta")
        TxtResposta.Text = ObjProblema.GetConteudo("resposta")
        CbxFaturar.Checked = IIf(ObjProblema.GetConteudo("id_faturar") = "S", True, False)
        If ObjProblema.GetConteudo("cod_grupo") <> "" Then
            DdlGrupo.SelectedValue = ObjProblema.GetConteudo("cod_grupo")
        Else
            DdlGrupo.SelectedValue = "0"
        End If
        TxtCriticidade.Text = ObjProblema.GetConteudo("criticidade")
        TxtDeteccao.Text = ObjProblema.GetConteudo("deteccao")
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjProblema As New UCLProblemaPadrao
        LblCodProblema.Text = ObjProblema.GetProximoCodigo(Session("GlEmpresa"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjProblema As New UCLProblemaPadrao
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjProblema.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjProblema.SetConteudo("cod_problema", LblCodProblema.Text)
                    ObjProblema = CarregaObjeto(ObjProblema)
                    ObjProblema.Alterar()
                    LblErro.Text = "Cadastro alterado com sucesso."
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjProblema.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjProblema.SetConteudo("cod_problema", LblCodProblema.Text)
                    ObjProblema = CarregaObjeto(ObjProblema)
                    ObjProblema.Incluir()
                    Session("SCodProblema") = LblCodProblema.Text
                    Session("SAcao") = "ALTERAR"
                    LblErro.Text = "Cadastro incluído com sucesso."
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(DdlGrupo.SelectedValue) OrElse DdlGrupo.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Grupo de Problema / Modo de Falha.<br/>"
        End If

        If String.IsNullOrEmpty(TxtAssunto.Text) Then
            LblErro.Text += "Preencha o campo Descrição Resumida.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjProblema As UCLProblemaPadrao) As UCLProblemaPadrao
        ObjProblema.SetConteudo("assunto", TxtAssunto.Text.GetValidInputContent)
        ObjProblema.SetConteudo("pergunta", TxtPergunta.Text.GetValidInputContent)
        ObjProblema.SetConteudo("resposta", TxtResposta.Text.GetValidInputContent)
        ObjProblema.SetConteudo("id_faturar", IIf(CbxFaturar.Checked, "S", "N"))
        ObjProblema.SetConteudo("cod_grupo", DdlGrupo.SelectedValue)
        ObjProblema.SetConteudo("criticidade", TxtCriticidade.Text)
        ObjProblema.SetConteudo("deteccao", TxtDeteccao.Text)
        Return ObjProblema
    End Function

    Private Sub CarregaGrupo()
        Dim objGrupoProblema As New UCLGrupoProblema
        objGrupoProblema.FillDropDown(DdlGrupo, Session("GlEmpresa"), True, "(selecione)", 0)
    End Sub
End Class