Public Class WGFalta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaEstabelecimentos()
            Call CarregaTecnicos()
        End If
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoFalta") = e.CommandName
            Session("SCodFalta") = e.CommandArgument
            Response.Redirect("WFFalta.aspx")
        End If
    End Sub

    Protected Sub BtnNovoRegistro_Click(sender As Object, e As EventArgs) Handles BtnNovoRegistro.Click
        Session("SAcaoFalta") = "INCLUIR"
        Session("SCodFalta") = -1
        Response.Redirect("WFFalta.aspx")
    End Sub

    Protected Sub BtnLimparFiltro_Click(sender As Object, e As EventArgs) Handles BtnLimparFiltro.Click
        DdlEstabelecimento.SelectedValue = DdlEstabelecimento.Items.Item(0).Value
        DdlAgenteTecnico.SelectedValue = "0"
        TxtDataI.Text = ""
        TxtDataF.Text = ""
        TxtMotivo.Text = ""
        DdlJustificadas.SelectedValue = "A"
    End Sub

    Protected Sub BtnPesquisar_Click(sender As Object, e As EventArgs) Handles BtnPesquisar.Click
        GridView1.DataBind()
    End Sub

    Private Sub CarregaEstabelecimentos()
        Try
            Dim objEstabelecimento As New UCLEstabelecimento
            objEstabelecimento.CodEmpresa = Session("GlEmpresa")
            objEstabelecimento.FillDropDown(DdlEstabelecimento, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaTecnicos()
        Try
            Dim objAgenteTecnico As New UCLAgenteTecnico
            objAgenteTecnico.FillDropDown(DdlAgenteTecnico, True, "(selecione)", "0", False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class