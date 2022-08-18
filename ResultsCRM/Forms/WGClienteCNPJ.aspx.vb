Public Partial Class WGClienteCNPJ
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("GlBloquearCadastroEmitenteRepresentante") = "S" Then
            BtnNovoRegistro.Visible = False
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcaoCNPJ") = "INCLUIR"
        Session("SCNPJEmitente") = ""
        Response.Redirect("WFClienteCNPJ.aspx?embeeded=False&vcodemi=SCodEmitente&vcodemp=SCodClientePesquisado&valtecc=SAlterouCodCliente&vrecdc=SRecarregaDdlContatos&ccodcon=SCodContatoNegociacao&cnpjemi=SCNPJEmitente&vcodemin=SCodEmitente")
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoCNPJ") = e.CommandName
            Session("SCNPJEmitente") = e.CommandArgument
            Response.Redirect("WFClienteCNPJ.aspx?embeeded=False&vcodemi=SCodEmitente&vcodemp=SCodClientePesquisado&valtecc=SAlterouCodCliente&vrecdc=SRecarregaDdlContatos&ccodcon=SCodContatoNegociacao&cnpjemi=SCNPJEmitente&vcodemin=SCodEmitente")
        ElseIf e.CommandName = "EXCLUIR" Then
            Try
                Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
                objEnderecoEmitente.CodEmitente = Session("SCodEmitente")
                objEnderecoEmitente.CNPJ = e.CommandArgument
                objEnderecoEmitente.Excluir()
                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "onload", "alert('Registro excluído com sucesso!')", True)
            Catch ex As Exception
                If ex.Message.Contains("FK_") Then
                    LblErro.Text = "Não é possível excluir o registro pois o mesmo já possui vínculos."
                Else
                    LblErro.Text = ex.Message
                End If
            End Try
        End If
    End Sub

    Protected Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles BtnFiltrar.Click
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub
End Class