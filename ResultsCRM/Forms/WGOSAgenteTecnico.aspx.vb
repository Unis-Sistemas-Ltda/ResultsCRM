Partial Public Class WGOSAgenteTecnico
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("SAtCodPedido") = -1 Then
                BtnVincularTecnico.Enabled = False
                BtnVincularTecnico.ToolTip = "Você deve Salvar a Ordem de Serviço antes de vincular um agente técnico."
            End If

            If Not IsPostBack Then
                Dim objAgenteTecnico As New UCLAgenteTecnico
                objAgenteTecnico.FillDropDown(DdlAgenteTecnico, False, "", "")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub Mensagem(ByVal texto As String)
        If Not String.IsNullOrEmpty(texto) Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('" + texto + "');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "", True)
        End If
    End Sub

    Protected Sub BtnVincularTecnico_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVincularTecnico.Click
        Try
            Call IncluirTecnico()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub IncluirTecnico()
        Try
            Dim objPedidoVendaAgenteTecnico As New UCLPedidoVendaAgenteTecnico(StrConexaoUsuario(Session("GlUsuario")))

            objPedidoVendaAgenteTecnico.Empresa = Session("GlEmpresa")
            objPedidoVendaAgenteTecnico.Estabelecimento = Session("GlEstabelecimento")
            objPedidoVendaAgenteTecnico.CodPedidoVenda = Session("SAtCodPedido")
            objPedidoVendaAgenteTecnico.CodAgenteTecnico = DdlAgenteTecnico.SelectedValue

            If objPedidoVendaAgenteTecnico.Existe() Then
                Mensagem("Agente técnico já vinculado.")
            Else
                If TipoTela = "2" Then
                    objPedidoVendaAgenteTecnico.IgnoraValidacoes = True
                End If

                objPedidoVendaAgenteTecnico.Incluir()
                SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                SqlDataSource2.DataBind()
                GridView2.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Call ExcluirTecnico(e.CommandArgument)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub ExcluirTecnico(ByVal codAgenteTecnico As String)
        Try
            Dim objPedidoVendaAgenteTecnico As New UCLPedidoVendaAgenteTecnico(StrConexaoUsuario(Session("GlUsuario")))

            objPedidoVendaAgenteTecnico.Empresa = Session("GlEmpresa")
            objPedidoVendaAgenteTecnico.Estabelecimento = Session("GlEstabelecimento")
            objPedidoVendaAgenteTecnico.CodPedidoVenda = Session("SAtCodPedido")
            objPedidoVendaAgenteTecnico.CodAgenteTecnico = codAgenteTecnico

            If TipoTela = "2" Then
                objPedidoVendaAgenteTecnico.IgnoraValidacoes = True
            End If

            objPedidoVendaAgenteTecnico.Excluir()

            SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            SqlDataSource2.DataBind()
            GridView2.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private ReadOnly Property TipoTela() As String
        Get
            Return Request.QueryString.Item("tt")
        End Get
    End Property


End Class