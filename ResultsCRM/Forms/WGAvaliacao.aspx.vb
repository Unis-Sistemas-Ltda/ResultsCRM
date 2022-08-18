Public Class WGAvaliacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaUsuarios()
            Select Case Session("GlTipoAcesso")
                Case UCLUsuario.TipoAcesso.Representante
                    DdlAvaliador.SelectedValue = Session("GlCodUsuario")
                    DdlAvaliador.Enabled = False
            End Select
            GridView1.DataBind()
        End If
    End Sub

    Private Sub CarregaUsuarios()
        Dim objUsuario As New UCLUsuario
        objUsuario.FillControl(DdlAvaliador, True, "(selecione)")
    End Sub

    Protected Sub BtnPesquisar_Click(sender As Object, e As EventArgs) Handles BtnPesquisar.Click
        GridView1.DataBind()
    End Sub

    Protected Sub BtnNovoRegistro_Click(sender As Object, e As EventArgs) Handles BtnNovoRegistro.Click
        Session("SAcaoAvaliacao") = "INCLUIR"
        Session("SCodAvaliacao") = -1
        Response.Redirect("WFAvaliacaoDetalhes.aspx")
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SCodAvaliacao") = e.CommandArgument
            Session("SAcaoAvaliacao") = "ALTERAR"
            Response.Redirect("WFAvaliacaoDetalhes.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objAvaliacao As New UCLAvaliacaoCliente
            objAvaliacao.Excluir(Session("GlEmpresa"), e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

End Class