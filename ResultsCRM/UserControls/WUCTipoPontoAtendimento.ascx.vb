Partial Public Class WUCTipoPontoAtendimento
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodTipoPontoAtendimento As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property CodTipoPontoAtendimento() As String
        Get
            Return _CodTipoPontoAtendimento
        End Get
        Set(ByVal value As String)
            _CodTipoPontoAtendimento = value
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
        Dim objTipoPontoAtendimento As New UCLTipoPontoAtendimento
        objTipoPontoAtendimento.CodTipoPontoAtendimento = CodTipoPontoAtendimento
        LblCodigo.Text = CodTipoPontoAtendimento
        objTipoPontoAtendimento.Buscar()
        TxtDescricao.Text = objTipoPontoAtendimento.Descricao
        If objTipoPontoAtendimento.SequencialAutomatico = "S" Then
            CbxSequencialAutomatico.Checked = True
        Else
            CbxSequencialAutomatico.Checked = False
        End If
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objTipoPontoAtendimento As New UCLTipoPontoAtendimento
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objTipoPontoAtendimento.CodTipoPontoAtendimento = LblCodigo.Text
                    objTipoPontoAtendimento = CarregaObjeto(objTipoPontoAtendimento)
                    objTipoPontoAtendimento.Alterar()
                    Response.Redirect("WGTipoPontoAtendimento.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objTipoPontoAtendimento.CodTipoPontoAtendimento = LblCodigo.Text
                    objTipoPontoAtendimento = CarregaObjeto(objTipoPontoAtendimento)
                    objTipoPontoAtendimento.Incluir()
                    Response.Redirect("WGTipoPontoAtendimento.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Function CarregaObjeto(ByRef objTipoPontoAtendimento As UCLTipoPontoAtendimento) As UCLTipoPontoAtendimento
        objTipoPontoAtendimento.Descricao = TxtDescricao.Text.GetValidInputContent
        If CbxSequencialAutomatico.Checked Then
            objTipoPontoAtendimento.SequencialAutomatico = "S"
        Else
            objTipoPontoAtendimento.SequencialAutomatico = "N"
        End If
        Return objTipoPontoAtendimento
    End Function

    Private Sub CarregaNovaPK()
        Dim objTipoPontoAtendimento As New UCLTipoPontoAtendimento
        LblCodigo.Text = objTipoPontoAtendimento.GetProximoCodigo
    End Sub
    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""
        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Descrição.<br/>"
        End If
        Return LblErro.Text.Trim = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Try
            Response.Redirect("WGTipoPontoAtendimento.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
End Class