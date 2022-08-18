Public Class WUCAssessoria
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodAssessoria As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodAssessoria() As String
        Get
            Return _CodAssessoria
        End Get
        Set(ByVal value As String)
            _CodAssessoria = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim objTipoAssessoria As New UCLTipoAssessoria
            objTipoAssessoria.FillDropDown(DdlTipoAssessoria, True, "(selecione)")
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim objAssessoria As New UCLAssessoria
        LblCodAssessoria.Text = CodAssessoria

        objAssessoria.Buscar(CodAssessoria)
        TxtDescricao.Text = objAssessoria.GetConteudo("descricao")
        DdlTipoAssessoria.SelectedValue = objAssessoria.GetConteudo("cod_tipo_assessoria")
    End Sub

    Private Sub CarregaNovaPK()
        Dim objAssessoria As New UCLAssessoria
        LblCodAssessoria.Text = objAssessoria.GetProximoCodigo()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objAssessoria As New UCLAssessoria
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objAssessoria.SetConteudo("cod_assessoria", LblCodAssessoria.Text)
                    objAssessoria = CarregaObjeto(objAssessoria)
                    objAssessoria.Alterar()
                    LblErro.Text = "Cadastro alterado com sucesso."
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objAssessoria.SetConteudo("cod_assessoria", LblCodAssessoria.Text)
                    objAssessoria = CarregaObjeto(objAssessoria)
                    objAssessoria.Incluir()
                    Session("SCodAssessoria") = LblCodAssessoria.Text
                    Session("SAcaoAssessoria") = "ALTERAR"
                    LblErro.Text = "Cadastro incluído com sucesso."
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

        If String.IsNullOrEmpty(DdlTipoAssessoria.SelectedValue) Then
            LblErro.Text += "Preencha o campo Tipo.<br/>"
        Else
            If DdlTipoAssessoria.SelectedValue <= 0 Then
                LblErro.Text += "Preencha o campo Tipo.<br/>"
            End If
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef objAssessoria As UCLAssessoria) As UCLAssessoria
        objAssessoria.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent())
        objAssessoria.SetConteudo("cod_tipo_assessoria", DdlTipoAssessoria.SelectedValue)
        Return objAssessoria
    End Function

End Class