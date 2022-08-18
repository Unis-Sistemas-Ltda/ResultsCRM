Partial Public Class WUCFollowUP
    Inherits System.Web.UI.UserControl

    Private _empresa As String
    Private _estabelecimento As String
    Private _codPedidoVenda As String
    Private _acao As String
    Private _camVoltar As String

    Public Property Acao() As String
        Get
            Return _acao
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "INCLUIR"
                    LblAcao.Text = "INCLUSÃO"
                    BtnGravar.Text = "Incluir"
                Case "ALTERAR"
                    LblAcao.Text = "ALTERAÇÃO"
                    BtnGravar.Text = "Salvar alterações"
            End Select
            _acao = value
        End Set
    End Property

    Public Property CaminhoVoltar() As String
        Get
            Return _camVoltar
        End Get
        Set(ByVal value As String)
            _camVoltar = value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return _empresa
        End Get
        Set(ByVal value As String)
            _empresa = value
        End Set
    End Property

    Public Property Estabelecimento() As String
        Get
            Return _estabelecimento
        End Get
        Set(ByVal value As String)
            _estabelecimento = value
        End Set
    End Property

    Public Property CodPedidoVenda() As String
        Get
            Return _codPedidoVenda
        End Get
        Set(ByVal value As String)
            _codPedidoVenda = value
        End Set
    End Property

    Public Property CodEmitente() As String
    Public Property SeqFollowUp As String
    Public Property MostraBotaoVoltar As Boolean = False

    Private Sub CarregaFormulario()
        Try
            Dim ObjFollowUp As New UCLFollowUpEmitente(StrConexaoUsuario(Session("GlUsuario")))
            ObjFollowUp.Empresa = Empresa
            ObjFollowUp.Estabelecimento = Estabelecimento
            ObjFollowUp.CodPedidoVenda = CodPedidoVenda
            ObjFollowUp.CodEmitente = CodEmitente
            ObjFollowUp.SeqFollowUP = SeqFollowUp
            ObjFollowUp.Buscar()
            LblSeqFollowUp.Text = SeqFollowUp
            TxtData.Text = ObjFollowUp.DataFollowUp
            TxtDescricao.Text = ObjFollowUp.Descricao
            If ObjFollowUp.OcultarPortal = "S" Then
                CbxOcultarPortal.Checked = True
            Else
                CbxOcultarPortal.Checked = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Carregar()
        Try
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            Else
                Call CarregaNovaPK()
                TxtDescricao.Text = ""
                TxtData.Text = Now.Date.ToString("dd/MM/yyyy")
            End If
            If MostraBotaoVoltar Then
                BtnVoltar.Visible = True
            Else
                BtnVoltar.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TxtDescricao.Attributes.Add("OnFocus", "selecionaCampo(this)")

            If Not IsPostBack Then
                Call Carregar()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjFollowUP As New UCLFollowUpEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim ObjPedido As New UCLPedidoVenda(StrConexao)

        ObjPedido.Empresa = Session("GlEmpresa")
        ObjPedido.Estabelecimento = Session("GlEstabelecimento")
        ObjPedido.codPedidoVenda = CodPedidoVenda
        ObjPedido.Buscar()

        LblSeqFollowUp.Text = ObjFollowUP.GetProximoCodigo(Session("GlEmpresa"), Session("GlEstabelecimento"), ObjPedido.codEmitente)
    End Sub

    Private Function Salvar() As Boolean
        Try
            Dim objFollowUp As New UCLFollowUpEmitente(StrConexaoUsuario(Session("GlUsuario")))

            If IsDigitacaoOK() Then
                If Acao = "INCLUIR" Then
                    CarregaNovaPK()
                End If

                objFollowUp.Empresa = Empresa
                objFollowUp.Estabelecimento = Estabelecimento
                objFollowUp.CodPedidoVenda = CodPedidoVenda
                objFollowUp.SeqFollowUP = LblSeqFollowUp.Text
                objFollowUp.DataFollowUp = TxtData.Text
                objFollowUp.HoraFollowUp = Now.ToString("HH:mm")
                objFollowUp.CodContato = "null"
                objFollowUp.CodEmitente = CodEmitente
                objFollowUp.Assunto = ""
                objFollowUp.Descricao = TxtDescricao.Text.GetValidInputContent
                objFollowUp.Tipo = 3
                objFollowUp.CodUsuario = Session("GlCodUsuario")
                objFollowUp.CodAcao = "null"
                objFollowUp.EnviaEmail = "N"
                If CbxOcultarPortal.Checked Then
                    objFollowUp.OcultarPortal = "S"
                Else
                    objFollowUp.OcultarPortal = "N"
                End If
                If Acao = "INCLUIR" Then
                    objFollowUp.Incluir()
                Else
                    objFollowUp.Alterar()
                End If

                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub Executa_BtnSalvar()
        Try
            If Salvar() Then
                Response.Redirect(CaminhoVoltar)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Call Executa_BtnSalvar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Function IsDigitacaoOK() As Boolean

        Try
            LblErro.Text = ""

            If String.IsNullOrWhiteSpace(TxtData.Text) Then
                LblErro.Text += "Informe a data.<br/>"
            Else
                If Not isValidDate(TxtData.Text) Then
                    LblErro.Text += "Informe a data corretamente. (dd/mm/aaaa)<br/>"
                End If
            End If

            If String.IsNullOrWhiteSpace(TxtDescricao.Text) Then
                LblErro.Text += "Informe a descrição.<br/>"
            End If

            Return LblErro.Text = ""
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Protected Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect(CaminhoVoltar)
    End Sub
End Class