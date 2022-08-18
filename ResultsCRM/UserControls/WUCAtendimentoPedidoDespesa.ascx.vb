Public Class WUCAtendimentoPedidoDespesa
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodPedidoVenda As String
    Private _CodTipoDespAcess As String
    Public Property MostraBotaoVoltar As Boolean = False

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodPedidoVenda() As String
        Get
            Return _CodPedidoVenda
        End Get
        Set(ByVal value As String)
            _CodPedidoVenda = value
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

    Public Sub Carregar()
        Try
            Call CarregaDropDowns()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call Carregar()
        End If
    End Sub

    Private Function CarregaObjeto(ByRef objPedidoVendaDespesa As UCLPedidoVendaDespesas) As UCLPedidoVendaDespesas
        objPedidoVendaDespesa.SetConteudo("valor", TxtValor.Text)
        Return objPedidoVendaDespesa
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objPedidoVendaDespesa As New UCLPedidoVendaDespesas
        Try

            If DdlTipoDespAcess.SelectedValue = 0 Then
                LblErro.Text = "Informe o tipo de despesa."
                Return
            End If

            If Not IsNumeric(TxtValor.Text) OrElse CDbl(TxtValor.Text) <= 0 Then
                LblErro.Text = "Informe corretamente o valor da despesa."
                Return
            End If

            If Acao = "INCLUIR" AndAlso objPedidoVendaDespesa.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"), CodPedidoVenda, DdlTipoDespAcess.SelectedValue) Then
                LblErro.Text = "Despesa já incluída."
                Return
            End If

            objPedidoVendaDespesa.SetConteudo("empresa", Session("GlEmpresa"))
            objPedidoVendaDespesa.SetConteudo("estabelecimento", Session("GlEstabelecimento"))
            objPedidoVendaDespesa.SetConteudo("cod_pedido_venda", CodPedidoVenda)
            objPedidoVendaDespesa.SetConteudo("cod_tipo_desp_acess", DdlTipoDespAcess.SelectedValue)
            objPedidoVendaDespesa = CarregaObjeto(objPedidoVendaDespesa)

            If Acao = "INCLUIR" Then
                objPedidoVendaDespesa.Incluir()
            ElseIf Acao = "ALTERAR" Then
                objPedidoVendaDespesa.Alterar()
            End If

            If MostraBotaoVoltar Then
                Response.Redirect("WGAtendimentoPedidoItem.aspx")
            Else
                Response.Redirect("WGOSDespesa.aspx")
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGAtendimentoPedidoItem.aspx")
    End Sub

    Protected Sub CarregaFormulario()
        Try
            Dim objPedidoVendaDespesa As New UCLPedidoVendaDespesas
            DdlTipoDespAcess.SelectedValue = CodTipoDespAcess
            DdlTipoDespAcess.Enabled = False
            If objPedidoVendaDespesa.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"), CodPedidoVenda, CodTipoDespAcess) Then
                TxtValor.Text = objPedidoVendaDespesa.GetConteudo("valor")
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

    Protected Sub CarregaDropDowns()
        Try
            Dim objTipoDespesa As New UCLTipoDespesaAcessoria
            objTipoDespesa.FillDropDown(Session("GlEmpresa"), DdlTipoDespAcess, True, "(selecione)", 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class