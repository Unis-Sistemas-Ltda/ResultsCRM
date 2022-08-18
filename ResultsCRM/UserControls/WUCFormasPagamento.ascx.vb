Public Partial Class WUCFormasPagamento
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _Codigo As String
    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPk()
            End If

        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjFormaPagto As New UCLFormaPagto
        ObjFormaPagto.Codigo = Codigo
        ObjFormaPagto.Buscar()
        LblCodigo.Text = ObjFormaPagto.Codigo
        TxtDescricao.Text = ObjFormaPagto.Descricao
        DdlEventoBaixa.SelectedValue = ObjFormaPagto.EventoBaixa
        DdlTipo.SelectedValue = ObjFormaPagto.Tipo
        If ObjFormaPagto.ImprimirReciboRomaneio = "S" Then
            ChkRecibo.Checked = True
        End If

    End Sub

    Private Sub CarregaNovaPk()
        Dim ObjFormaPagto As New UCLFormaPagto
        LblCodigo.Text = ObjFormaPagto.GetProximoCodigo
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjFormaPagto As New UCLFormaPagto
        If IsDigitacaoOK() Then
            ObjFormaPagto.Codigo = LblCodigo.Text
            ObjFormaPagto.Descricao = TxtDescricao.Text
            ObjFormaPagto.Tipo = DdlTipo.SelectedValue
            ObjFormaPagto.EventoBaixa = DdlEventoBaixa.SelectedValue
            If ChkRecibo.Checked Then
                ObjFormaPagto.ImprimirReciboRomaneio = "S"
            Else
                ObjFormaPagto.ImprimirReciboRomaneio = "N"
            End If


            If Acao = "ALTERAR" Then
                ObjFormaPagto.Alterar()
                Response.Redirect("WGFormasPagamento.aspx")
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPk()
                ObjFormaPagto.Codigo = LblCodigo.Text
                ObjFormaPagto.Incluir()
                Response.Redirect("WGFormasPagamento.aspx")
            End If
        End If
    End Sub

    Private Function IsDigitacaoOK() As Boolean
        lblErro.Text = ""
        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            lblErro.Text = "Digite a Descrição"
        End If
        Return lblErro.Text = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGFormasPagamento.aspx")
    End Sub
End Class