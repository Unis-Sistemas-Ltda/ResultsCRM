Public Partial Class WFAtendimentoPedidoTecnico
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim objAgenteTecnico As New UCLAgenteTecnico
                objAgenteTecnico.FillDropDown(DdlAgenteTecnico, False, "", "")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnIncluir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnIncluir.Click
        Try
            Call Incluir()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub Incluir()
        Try
            Dim objPedidoVendaAgenteTecnico As New UCLPedidoVendaAgenteTecnico(StrConexaoUsuario(Session("GlUsuario")))
            LblErro.Text = ""

            objPedidoVendaAgenteTecnico.Empresa = Session("GlEmpresa")
            objPedidoVendaAgenteTecnico.Estabelecimento = Session("GlEstabelecimento")
            objPedidoVendaAgenteTecnico.CodPedidoVenda = Session("SAtCodPedido")
            objPedidoVendaAgenteTecnico.CodAgenteTecnico = DdlAgenteTecnico.SelectedValue

            If objPedidoVendaAgenteTecnico.Existe() Then
                LblErro.Text = "Agente técnico já vinculado."
            Else
                objPedidoVendaAgenteTecnico.Incluir()
                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Call Excluir(e.CommandArgument)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub Excluir(ByVal codAgenteTecnico As String)
        Try
            Dim objPedidoVendaAgenteTecnico As New UCLPedidoVendaAgenteTecnico(StrConexaoUsuario(Session("GlUsuario")))
            LblErro.Text = ""

            objPedidoVendaAgenteTecnico.Empresa = Session("GlEmpresa")
            objPedidoVendaAgenteTecnico.Estabelecimento = Session("GlEstabelecimento")
            objPedidoVendaAgenteTecnico.CodPedidoVenda = Session("SAtCodPedido")
            objPedidoVendaAgenteTecnico.CodAgenteTecnico = codAgenteTecnico
            objPedidoVendaAgenteTecnico.Excluir()

            LblErro.Text = "Agente técnico desvinculado com sucesso."

            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGAtendimentoPedidoItem.aspx")
    End Sub
End Class