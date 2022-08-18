Public Class WGClienteSLA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnIncluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluir.Click
        Session("SAcaoSLA") = "INCLUIR"
        Session("SCodSLA") = -1
        Response.Redirect("WFClienteSLADetalhes.aspx")
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoSLA") = e.CommandName
            Session("SCodSLA") = e.CommandArgument
            Response.Redirect("WFClienteSLADetalhes.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objSLAEmitente As New UCLSLAEmitente
            'Exclui
            objSLAEmitente.CodEmitente = Session("SCodEmitente")
            objSLAEmitente.CodSLA = e.CommandArgument
            objSLAEmitente.Excluir()
            'Recarrega Grid em Tela
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        End If
    End Sub

End Class