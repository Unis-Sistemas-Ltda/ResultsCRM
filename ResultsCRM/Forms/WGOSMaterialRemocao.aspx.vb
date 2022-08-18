Partial Public Class WGOSMaterialRemocao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call SetaParaInclusao()
        End If
        WUCRemocaoMaterial1.Empresa = Session("GlEmpresa")
        WUCRemocaoMaterial1.Estabelecimento = Session("GlEstabelecimento")
        WUCRemocaoMaterial1.CodPedidoVenda = Session("SAtCodPedido")
        WUCRemocaoMaterial1.CaminhoVoltar = "WGOSMaterialRemocao.aspx"
    End Sub

    Private Sub Mensagem(ByVal texto As String)
        LblErro.Text = ""
        If Not String.IsNullOrEmpty(texto) Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('" + texto + "');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "", True)
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Try
                Dim ObjPedidoVendaMovimentacaoMaterial As New UCLPedidoVendaMovimetacaoMaterial(StrConexaoUsuario(Session("GlUsuario")))

                ObjPedidoVendaMovimentacaoMaterial.Empresa = Session("GlEmpresa")
                ObjPedidoVendaMovimentacaoMaterial.Estabelecimento = Session("GlEstabelecimento")
                ObjPedidoVendaMovimentacaoMaterial.CodPedidoVenda = Session("SAtCodPedido")
                ObjPedidoVendaMovimentacaoMaterial.SeqMovimentacao = e.CommandArgument
                ObjPedidoVendaMovimentacaoMaterial.Excluir()

                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()

                Call SetaParaInclusao()

                Mensagem("Remoção de Material foi estornada com sucesso!")
            Catch ex As Exception
                LblErro.Text = ex.Message.ToString
            End Try
        End If
    End Sub

    Protected Sub SetaParaInclusao()
        If Session("SAtCodPedido") <> -1 Then
            Session("SAtSolicitacao") = -1
            Session("SAcaoAtPedido") = "INCLUIR"
        Else
            Mensagem("Antes de adicionar um item, você deve salvar o cabeçalho da OS.")
            WUCRemocaoMaterial1.Visible = False
        End If
    End Sub

End Class