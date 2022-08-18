Partial Public Class WGProgramacaoAtendimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objTipoChamado As New UCLTipoChamado

            If Not IsPostBack Then
                Call CarregaAnalista()
                objTipoChamado.FillDropDown(Session("GlEmpresa"), ddlTipoChamado, True, "(Todos)", "")
                Call AplicaFiltro(False)
            End If
        Catch ex As Exception
            LblErro.Text = ex.ToString
        End Try
    End Sub

    Private Sub CarregaAnalista()
        Dim objAnalista As New UCLAnalista
        objAnalista.FillDropDown(ddlAnalista, True, "(Todos)", "", True, False, "", "")
        ddlAnalista.SelectedValue = ""
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SCodProgramacao") = e.CommandArgument
            Session("SAcao") = "ALTERAR"
            Response.Redirect("WFProgramacaoAtendimento.aspx")
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodProgramacao") = -1
        Response.Redirect("WFProgramacaoAtendimento.aspx")
    End Sub

    Protected Sub AplicaFiltro(ByVal postback As Boolean)
        Try
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            LblErro.Text = ex.ToString
        End Try
    End Sub

    Protected Sub TxtCodEmitente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCodEmitente.TextChanged
        Call AplicaFiltro(True)
    End Sub

    Protected Sub TxtNrAtendimento_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCodProgramacao.TextChanged
        Call AplicaFiltro(True)
    End Sub

    Protected Sub TxtNomeEmitente_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtNomeEmitente.TextChanged
        Call AplicaFiltro(True)
    End Sub

    Protected Sub ddlTipoChamado_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlTipoChamado.SelectedIndexChanged
        Call AplicaFiltro(True)
    End Sub

    Protected Sub TxtAssunto_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtAssunto.TextChanged
        Call AplicaFiltro(True)
    End Sub

    Protected Sub ddlAnalista_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlAnalista.SelectedIndexChanged
        Call AplicaFiltro(True)
    End Sub

End Class