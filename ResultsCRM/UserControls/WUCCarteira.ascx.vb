Public Partial Class WUCCarteira
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodCarteira As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodCarteira() As String
        Get
            Return _CodCarteira
        End Get
        Set(ByVal value As String)
            _CodCarteira = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim alterouCodEmitente As Long
        Dim CodEmitentePesquisado As String = Session("SCodEmitentePesquisado")

        If Not String.IsNullOrEmpty(Session("SAlterouCodEmitente")) Then
            alterouCodEmitente = Session("SAlterouCodEmitente")
        Else
            alterouCodEmitente = 0
        End If

        If Not String.IsNullOrEmpty(CodEmitentePesquisado) Then
            If alterouCodEmitente > 0 Then
                If TxtCodRepresentante.Text <> CodEmitentePesquisado Then
                    TxtCodRepresentante.Text = CodEmitentePesquisado
                End If
                Session("SAlterouCodEmitente") = alterouCodEmitente - 1
            End If
        End If

        If Not IsPostBack Then
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If

        Call MostraNomeVendedor()
    End Sub

    Private Sub CarregaFormulario()
        Dim objCarteira As New UCLCarteiraCRM
        LblCodCarteira.Text = CodCarteira

        objCarteira.CodCarteira = CodCarteira
        objCarteira.Buscar()

        TxtCodRepresentante.Text = objCarteira.CodRepresentante
        RblTipo.SelectedValue = objCarteira.Tipo
        TxtDescricao.Text = objCarteira.Descricao

        If RblTipo.SelectedValue = "V" Then
            TxtCodRepresentante.Enabled = True
        End If

    End Sub

    Private Sub CarregaNovaPK()
        Dim objCarteira As New UCLCarteiraCRM
        LblCodCarteira.Text = objCarteira.GetProximoCodigo
    End Sub

    Private Sub MostraNomeVendedor()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        If Not String.IsNullOrEmpty(TxtCodRepresentante.Text) Then
            objEmitente.CodEmitente = TxtCodRepresentante.Text
            objEmitente.Buscar()
            LblNomeRepresentante.Text = objEmitente.Nome
        End If
    End Sub

    Protected Sub RblTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RblTipo.SelectedIndexChanged
        If RblTipo.SelectedValue = "L" Then
            TxtCodRepresentante.Text = ""
            TxtCodRepresentante.Enabled = False
        Else
            TxtCodRepresentante.Enabled = True
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objCarteira As New UCLCarteiraCRM
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objCarteira.CodCarteira = LblCodCarteira.Text
                    objCarteira = CarregaObjeto(objCarteira)
                    objCarteira.Alterar()
                    Response.Redirect("WGCarteira.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objCarteira.CodCarteira = LblCodCarteira.Text
                    objCarteira = CarregaObjeto(objCarteira)
                    objCarteira.Incluir()
                    Response.Redirect("WGCarteira.aspx")
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

        If String.IsNullOrEmpty(TxtCodRepresentante.Text) AndAlso RblTipo.SelectedValue = "V" Then
            LblErro.Text += "Preencha o campo Vendedor.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef objCarteira As UCLCarteiraCRM) As UCLCarteiraCRM

        objCarteira.CodRepresentante = TxtCodRepresentante.Text
        objCarteira.Descricao = TxtDescricao.Text.GetValidInputContent
        objCarteira.Tipo = RblTipo.SelectedValue

        Return objCarteira
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGCarteira.aspx")
    End Sub
End Class