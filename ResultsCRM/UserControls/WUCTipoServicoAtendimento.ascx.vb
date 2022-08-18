Partial Public Class WUCTipoServicoAtendimento
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodTipoServico As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodTipoServico() As String
        Get
            Return _CodTipoServico
        End Get
        Set(ByVal value As String)
            _CodTipoServico = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjTipoServico As New UCLTipoServicoAtendimento
        LblCodTipoServico.Text = CodTipoServico
        ObjTipoServico.Buscar(CodTipoServico)
        TxtDescricao.Text = ObjTipoServico.GetConteudo("descricao")
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjTipoServico As New UCLTipoServicoAtendimento
        LblCodTipoServico.Text = ObjTipoServico.GetProximoCodigo
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjTipoServico As New UCLTipoServicoAtendimento
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjTipoServico.SetConteudo("cod_tipo_servico", LblCodTipoServico.Text)
                    ObjTipoServico = CarregaObjeto(ObjTipoServico)
                    ObjTipoServico.Alterar()
                    Response.Redirect("WGTipoServicoAtendimento.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjTipoServico.SetConteudo("cod_tipo_servico", LblCodTipoServico.Text)
                    ObjTipoServico = CarregaObjeto(ObjTipoServico)
                    ObjTipoServico.Incluir()
                    Response.Redirect("WGTipoServicoAtendimento.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Descrição.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjTipoServico As UCLTipoServicoAtendimento) As UCLTipoServicoAtendimento
        ObjTipoServico.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        Return ObjTipoServico
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGTipoServicoAtendimento.aspx")
    End Sub
End Class