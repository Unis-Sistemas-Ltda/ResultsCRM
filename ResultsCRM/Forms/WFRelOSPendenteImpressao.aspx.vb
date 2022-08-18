Partial Public Class WFRelOSPendenteImpressao
    Inherits System.Web.UI.Page
    Dim objParametrosManutencao As New UCLParametrosManutencao
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objTipoChamado As New UCLTipoChamado
            Dim objStatusChamado As New UCLStatusChamado
            Dim objAnalista As New UCLAnalista

            If Not IsPostBack Then
                objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))
                Call AplicaFiltro()
            End If

            objAnalista.Codigo = Session("GlCodUsuario")
            If Not objAnalista.Buscar OrElse objAnalista.Inativo = "S" Then
                LblErro.Text = "ACESSO NEGADO.<br/><br/>Prezado usuário<br>Para ter acesso ao painel de Ordens de Serviço, é necessário que você solicite à pessoa responsável o seu cadastramento como analista no Results."
                GridView1.Visible = False
                TxtCodPedidoVenda.Enabled = False
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        Dim qtd As Long = 0
        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                qtd += 1
            End If
        Next
        LblNrOS.Text = qtd.ToString
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAtCodPedido") = e.CommandArgument
            Session("SAcaoAtPedidoCab") = "ALTERAR"
            Response.Redirect("WFOS.aspx")
        End If
    End Sub

    Protected Sub AplicaFiltro()
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub

End Class