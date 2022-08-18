Public Class WUCEmailVisualizacao
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _Empresa As String
    Private _SeqEmail As String

    Private ReadOnly Property Prop_T() As String
        Get
            Return Request.QueryString.Item("t")
        End Get
    End Property

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property SeqEmail() As String
        Get
            Return _SeqEmail
        End Get
        Set(ByVal value As String)
            _SeqEmail = value
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
        Try
            If Not IsPostBack Then
                Call CarregaFormulario()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Dim objEmail2 As New UCLEmail2()

        LblNrEmail.Text = objEmail2.GetProximoCodigo(Session("GlEmpresa"))
        SeqEmail = LblNrEmail.Text
    End Sub

    Private Sub CarregaFormulario()
        Dim objEmail As New UCLEmail2

        If objEmail.Buscar(Empresa, SeqEmail) Then
            LblNrEmail.Text = SeqEmail
            LblData.Text = objEmail.GetConteudoData("data_mensagem").ToString("dd/MM/yyyy")
            LblHora.Text = objEmail.GetConteudoData("data_mensagem").ToString("HH:mm:ss")
           
            LblRemetenteNome.Text = objEmail.GetConteudo("remetente_nome") + " [" + objEmail.GetConteudo("remetente_email") + "]"
            LblDestinatario.Text = objEmail.GetConteudo("destinatario_email")
            LblEmailCC.Text = objEmail.GetConteudo("destinatario_cc")
            LblCCO.Text = objEmail.GetConteudo("destinatario_cco")

            LblAssunto.Text = objEmail.GetConteudo("assunto")
            LblMensagem.Text = objEmail.GetConteudo("corpo").Replace(Chr(13), "<br>")
            LblErro.Text = objEmail.GetConteudo("descricao_erro")

            objEmail.SetSituacaoLeitura(Empresa, SeqEmail, "1")
        End If
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim objEmail As New UCLEmail2
        objEmail.Buscar(Session("GlEmpresa"), SeqEmail)

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim HyperLink1 As HyperLink = e.Row.FindControl("HyperLink1")

            If HyperLink1.Visible And Not String.IsNullOrWhiteSpace(HyperLink1.Text) Then
                If objEmail.GetConteudo("tipo_email") = "0" Then
                    HyperLink1.NavigateUrl = DominioAnexoEmailRecebido + HyperLink1.Text
                Else
                    HyperLink1.NavigateUrl = DominioAnexoEmailEnviado + HyperLink1.Text
                End If

            End If
        End If
    End Sub
End Class