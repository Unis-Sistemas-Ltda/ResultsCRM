Partial Public Class WGClientePontoAtendimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaTipoPontoAtendimento()
        End If
        If Session("GlBloquearCadastroEmitenteRepresentante") = "S" Then
            BtnNovoRegistro.Visible = False
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcaoCNPJ") = "INCLUIR"
        Session("SNumeroPontoAtendimento") = ""
        Response.Redirect("WFClientePontoAtendimentoDetalhes.aspx")
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoCNPJ") = e.CommandName
            Session("SNumeroPontoAtendimento") = e.CommandArgument
            Response.Redirect("WFClientePontoAtendimentoDetalhes.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Try
                Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
                objPontoAtendimento.CodEmitente = Session("SCodEmitente")
                objPontoAtendimento.NumeroPontoAtendimento = e.CommandArgument
                objPontoAtendimento.Excluir()
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

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFiltrar.Click
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub

    Private Sub CarregaTipoPontoAtendimento()
        Try
            Dim objTipoPontoAtendimento As New UCLTipoPontoAtendimento
            objTipoPontoAtendimento.FillDropDown(DdlTipoPontoAtendimento, True, " ")
            DdlTipoPontoAtendimento.SelectedValue = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class