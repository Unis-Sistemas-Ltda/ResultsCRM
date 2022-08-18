Public Class WUCNegociacaoDespesa
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodNegociacao As String
    Private _CodTipoDespAcess As String

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

    Public Property CodTipoDespAcess() As String
        Get
            Return _CodTipoDespAcess
        End Get
        Set(ByVal value As String)
            _CodTipoDespAcess = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaDropDowns()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            End If
        End If
    End Sub


    Private Function CarregaObjeto(ByRef objNegociacaoDespAcess As UCLNegociacaoClienteDespesas) As UCLNegociacaoClienteDespesas
        objNegociacaoDespAcess.SetConteudo("valor", TxtValor.Text)
        Return objNegociacaoDespAcess
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objNegociacaoDespAcess As New UCLNegociacaoClienteDespesas
        Try

            If DdlTipoDespAcess.SelectedValue = 0 Then
                LblErro.Text = "Informe o tipo de despesa."
                Return
            End If

            If Not IsNumeric(TxtValor.Text) OrElse CDbl(TxtValor.Text) <= 0 Then
                LblErro.Text = "Informe corretamente o valor da despesa."
                Return
            End If

            If Acao = "INCLUIR" AndAlso objNegociacaoDespAcess.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"), CodNegociacao, DdlTipoDespAcess.SelectedValue) Then
                LblErro.Text = "Despesa já incluída."
                Return
            End If

            objNegociacaoDespAcess.SetConteudo("empresa", Session("GlEmpresa"))
            objNegociacaoDespAcess.SetConteudo("estabelecimento", Session("SEstabelecimentoNegociacao"))
            objNegociacaoDespAcess.SetConteudo("cod_negociacao_cliente", CodNegociacao)
            objNegociacaoDespAcess.SetConteudo("cod_tipo_desp_acess", DdlTipoDespAcess.SelectedValue)
            objNegociacaoDespAcess = CarregaObjeto(objNegociacaoDespAcess)

            If Acao = "INCLUIR" Then
                objNegociacaoDespAcess.Incluir()
            ElseIf Acao = "ALTERAR" Then
                objNegociacaoDespAcess.Alterar()
            End If

            Response.Redirect("WGNegociacaoDespesa.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("WGNegociacaoDespesa.aspx")
    End Sub

    Protected Sub CarregaFormulario()
        Try
            Dim objNegociacaoDespAcess As New UCLNegociacaoClienteDespesas
            DdlTipoDespAcess.SelectedValue = CodTipoDespAcess
            DdlTipoDespAcess.Enabled = False
            If objNegociacaoDespAcess.Buscar(Session("GlEmpresa"), Session("SEstabelecimentoNegociacao"), CodNegociacao, CodTipoDespAcess) Then
                TxtValor.Text = objNegociacaoDespAcess.GetConteudo("valor")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CarregaDropDowns()
        Try
            Dim objTipoDespesa As New UCLTipoDespesaAcessoria
            objTipoDespesa.FillDropDown(Session("GlEmpresa"), DdlTipoDespAcess, True, "(selecione)", 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class