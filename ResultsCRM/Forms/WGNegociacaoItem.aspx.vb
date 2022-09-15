Public Partial Class WGNegociacaoItem
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim objParametrosCRM As New UCLParametrosCRM
                objParametrosCRM.Empresa = Session("GlEmpresa")
                If objParametrosCRM.Buscar() Then
                    If objParametrosCRM.ItensNegociacaoFormatoPlanilha = "S" Then
                        BtnListarItens.Visible = True
                    Else
                        BtnListarItens.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        If e.CommandName = "ALTERAR" Then
            Session("SSeqItemNegociacao") = e.CommandArgument
            Session("SAcaoItem") = "ALTERAR"
            Response.Redirect("WFNegociacaoItem.aspx")
        ElseIf e.CommandName = "ALTERARFICHA" Then
            Session("SSeqItemNegociacao") = e.CommandArgument
            Session("SAcaoItem") = "ALTERAR"
            Response.Redirect("WFNegociacaoItem_Farmacos2FD.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            objNegociacaoItem.Empresa = Session("GlEmpresa")
            objNegociacaoItem.Estabelecimento = Session("SEstabelecimentoNegociacao")
            objNegociacaoItem.CodNegociacao = Session("SCodNegociacao")
            objNegociacaoItem.SeqItem = e.CommandArgument
            objNegociacaoItem.Excluir()
            Response.Redirect("WGNegociacaoItem.aspx") 'Autorrecarregamento
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        If Session("SCodNegociacao") <> -1 Then
            Session("SSeqItemNegociacao") = -1
            Session("SAcaoItem") = "INCLUIR"
            Response.Redirect("WFNegociacaoItem.aspx")
        Else
            LblErro.Text = "Não é permitido incluir um registro de item antes de salvar o cabeçalho da negociação."
        End If

    End Sub

    Protected Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class