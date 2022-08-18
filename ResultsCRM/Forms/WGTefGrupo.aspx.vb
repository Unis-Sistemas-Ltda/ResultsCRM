Public Class WGTefGrupo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objAdquirente As New UCLTefAdquirente
            Dim objOperadora As New UCLTefOperadora

            If Not IsPostBack Then
                objAdquirente.FillDropDown(DdlAdquirente, True, "( selecione )", 0, "")
                objOperadora.FillDropDown(DdlOperadora, True, "( selecione )", 0)
                Call AplicarFiltro()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub TxtCodCampanha_TextChanged(sender As Object, e As EventArgs) Handles TxtCodCampanha.TextChanged
        Call AplicarFiltro()
    End Sub

    Private Sub AplicarFiltro()
        Try
            GridView1.DataBind()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub TxtNomeCampanha_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeCampanha.TextChanged
        Call AplicarFiltro()
    End Sub

    Protected Sub DdlAdquirente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlAdquirente.SelectedIndexChanged
        Call AplicarFiltro()
    End Sub

    Protected Sub DdlOperadora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlOperadora.SelectedIndexChanged
        Call AplicarFiltro()
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SCodGrupoTEF") = e.CommandArgument
            Session("SAcaoGrupoTEF") = "ALTERAR"
            Response.Redirect("WFCampanhaDetalhes.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objGrupo As New UCLTefGrupo
            objGrupo.Excluir(Session("GlEmpresa"), e.CommandArgument)
            Call AplicarFiltro()
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcaoGrupoTEF") = "INCLUIR"
        Session("SCodGrupoTEF") = -1
        Response.Redirect("WFCampanhaDetalhes.aspx")
    End Sub
End Class