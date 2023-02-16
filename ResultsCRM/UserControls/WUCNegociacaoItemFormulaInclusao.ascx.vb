Public Class WUCNegociacaoItemFormulaInclusao1
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodNegociacao As String
    Private _SeqItem As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property


    Public Property CodNegociacao() As String
        Get
            Return _CodNegociacao
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property

    Public Property SeqItem() As String
        Get
            Return _SeqItem
        End Get
        Set(ByVal value As String)
            _SeqItem = value
        End Set
    End Property

    Private _SeqFormula As String
    Public Property SeqFormula() As String
        Get
            Return _SeqFormula
        End Get
        Set(ByVal value As String)
            _SeqFormula = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                Else
                    Call NovoRegistro()
                End If
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub NovoRegistro()
        Try
            Dim objNegociacaoItemFormula As New UCLNegociacaoItemFormula(StrConexaoUsuario(Session("GlUsuario")))
            Call CarregaNovaPK(objNegociacaoItemFormula)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNovaPK(ByRef objNegociacaoItemFormula As UCLNegociacaoItemFormula)
        'Dim objNegociacaoItemFormula As New UCLNegociacaoItemFormula(StrConexaoUsuario(Session("GlUsuario")))
        objNegociacaoItemFormula.Empresa = Session("GlEmpresa")
        objNegociacaoItemFormula.Estabelecimento = Session("SEstabelecimentoNegociacao")
        objNegociacaoItemFormula.CodNegociacao = CodNegociacao
        objNegociacaoItemFormula.SeqItem = SeqItem
        objNegociacaoItemFormula.SeqFormula = objNegociacaoItemFormula.GetProximoCodigo
        LblSeqItem.Text = objNegociacaoItemFormula.SeqItem
        LblSeqItemFormaula.Text = objNegociacaoItemFormula.SeqFormula

    End Sub

    Private Function IsDigitacaoOK()

        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtDescricaoComponente.Text) Then
            LblErro.Text += "Preencha o campo Componente/Matéria Prima.<br/>"
        End If

        If String.IsNullOrEmpty(TxtPercentual.Text) Then
            LblErro.Text += "Preencha o campo Componente/Matéria Prima.<br/>"
        End If

        Return LblErro.Text = ""
    End Function

    Private Sub CarregaObjeto(ByRef objNegociacaoItemFormula As UCLNegociacaoItemFormula)

        objNegociacaoItemFormula.DescricaoComponente = TxtDescricaoComponente.Text
        objNegociacaoItemFormula.Percentual = TxtPercentual.Text
        If ChkQsp.Checked Then
            objNegociacaoItemFormula.Qsp = "S"
            objNegociacaoItemFormula.Percentual = objNegociacaoItemFormula.GetPercentualQsp
        Else
            objNegociacaoItemFormula.Qsp = "N"
        End If

    End Sub


    Protected Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles BtnGravar.Click
        Dim objNegociacaoItemFormula As New UCLNegociacaoItemFormula(StrConexaoUsuario(Session("GlUsuario")))
        Try
            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objNegociacaoItemFormula.CodNegociacao = CodNegociacao
                    objNegociacaoItemFormula.SeqItem = SeqItem
                    objNegociacaoItemFormula.SeqFormula = SeqFormula
                    objNegociacaoItemFormula.Empresa = Session("GlEmpresa")
                    objNegociacaoItemFormula.Estabelecimento = Session("SEstabelecimentoNegociacao")
                    'objNegociacaoItemFormula.Buscar()
                    CarregaObjeto(objNegociacaoItemFormula)
                    objNegociacaoItemFormula.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    CarregaNovaPK(objNegociacaoItemFormula)
                    'objNegociacaoItemFormula.CodNegociacao = CodNegociacao
                    'objNegociacaoItemFormula.SeqItem = LblSeqItem.Text
                    'objNegociacaoItemFormula.SeqFormula = SeqFormula
                    'objNegociacaoItemFormula.Empresa = Session("GlEmpresa")
                    'objNegociacaoItemFormula.Estabelecimento = Session("SEstabelecimentoNegociacao")
                    'objNegociacaoItemFormula.Buscar()
                    CarregaObjeto(objNegociacaoItemFormula)
                    objNegociacaoItemFormula.Incluir()
                End If

                Response.Redirect("WGNegociacaoItemFormula.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("WGNegociacaoItemFormula.aspx")
    End Sub

    Protected Sub CarregaFormulario()
        Dim objNegociacaoItemFormula As New UCLNegociacaoItemFormula(StrConexaoUsuario(Session("GlUsuario")))

        objNegociacaoItemFormula.Empresa = Session("GlEmpresa")
        objNegociacaoItemFormula.Estabelecimento = Session("SEstabelecimentoNegociacao")
        objNegociacaoItemFormula.CodNegociacao = CodNegociacao
        objNegociacaoItemFormula.SeqItem = SeqItem
        objNegociacaoItemFormula.SeqFormula = SeqFormula
        objNegociacaoItemFormula.Buscar()
        LblSeqItem.Text = objNegociacaoItemFormula.SeqItem
        LblSeqItemFormaula.Text = objNegociacaoItemFormula.SeqFormula
        TxtDescricaoComponente.Text = objNegociacaoItemFormula.DescricaoComponente
        TxtPercentual.Text = objNegociacaoItemFormula.Percentual
        If objNegociacaoItemFormula.Qsp = "S" Then
            ChkQsp.Checked = True
        Else
            ChkQsp.Checked = False
        End If
    End Sub

End Class