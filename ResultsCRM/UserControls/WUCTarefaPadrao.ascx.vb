Partial Public Class WUCTarefaPadrao
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodTarefa As String
    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property CodTarefa() As String
        Get
            Return _CodTarefa
        End Get
        Set(ByVal value As String)
            _CodTarefa = value
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
        Dim objTarefa As New UCLTarefaPadrao
        objTarefa.CodTarefaPadrao = CodTarefa
        LblCodigo.Text = CodTarefa
        objTarefa.Buscar()
        TxtDescricaoResumida.Text = objTarefa.DescricaoResumida
        DdlPrioridade.SelectedValue = objTarefa.Prioridade
        TxtDescricao.Text = objTarefa.Descricao
        DdlTipoResponsavel.SelectedValue = objTarefa.TipoResponsavel
        TxtManterInformado.Text = objTarefa.ManterInformado
        TxtTitulo.Text = objTarefa.Titulo
        TxtObservacao.Text = objTarefa.Observacao
        TxtDiasPrevisao.Text = objTarefa.DiasPrevisao
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objTarefa As New UCLTarefaPadrao
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objTarefa.CodTarefaPadrao = LblCodigo.Text
                    objTarefa = CarregaObjeto(objTarefa)
                    objTarefa.Alterar()
                    Response.Redirect("WGTarefaPadrao.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objTarefa.CodTarefaPadrao = LblCodigo.Text
                    objTarefa = CarregaObjeto(objTarefa)
                    objTarefa.Incluir()
                    Response.Redirect("WGTarefaPadrao.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Function CarregaObjeto(ByRef objTarefa As UCLTarefaPadrao) As UCLTarefaPadrao
        objTarefa.DescricaoResumida = TxtDescricaoResumida.Text.GetValidInputContent
        objTarefa.DiasPrevisao = TxtDiasPrevisao.Text
        objTarefa.Prioridade = DdlPrioridade.SelectedValue
        objTarefa.Descricao = TxtDescricao.Text.GetValidInputContent
        objTarefa.TipoResponsavel = DdlTipoResponsavel.SelectedValue
        objTarefa.ManterInformado = TxtManterInformado.Text.GetValidInputContent
        objTarefa.Titulo = TxtTitulo.Text.GetValidInputContent
        objTarefa.Observacao = TxtObservacao.Text.GetValidInputContent
        Return objTarefa
    End Function
    Private Sub CarregaNovaPK()
        Dim objTarefa As New UCLTarefaPadrao
        LblCodigo.Text = objTarefa.GetProximoCodigo
    End Sub
    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""
        If String.IsNullOrEmpty(TxtDescricaoResumida.Text) Then
            LblErro.Text += "Preencha o campo Descrição Resumida.<br/>"
        End If
        If String.IsNullOrEmpty(TxtDiasPrevisao.Text) Then
            LblErro.Text += "Preencha o campo Dias previsão.<br/>"
        End If
        If DdlTipoResponsavel.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Responsável.<br/>"
        End If
        Return LblErro.Text.Trim = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGTarefaPadrao.aspx")
    End Sub
End Class