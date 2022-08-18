Public Class WGAdesaoTEF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaDropdowns()
            DdlGrupoTEF.SelectedValue = -1
            GridView1.DataBind()
        End If
    End Sub

    Private Sub CarregaDropdowns()
        Try
            Dim objAdesaoTEF As New UCLAdesaoTEF
            Dim objAgente As New UCLAgenteVendas
            objAdesaoTEF.FillDropDown(DdlGrupoTEF, True, "(Todos)", -1, Session("GlEmpresa"))
            If Session("GlAgenteVendaMaster") = "S" OrElse Session("GlRestricaoAcessoAgenteVenda") = 0 Then
                objAgente.FillDropDown(ddlAgente, True, "(Todos)", 0, UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
            Else
                objAgente.FillDropDown(ddlAgente, True, "(Todos)", Session("GlCodUsuario"), UCLAgenteVendas.TipoRestricaoAcesso.SomenteOProprioAgenteDeVendasNoCRMeNoResults)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SqlDataSource1_Selected(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected
        LblQtd.Text = e.AffectedRows
    End Sub

    Private Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound
        Dim lnk As LinkButton
        Dim LblCodEmitente As Label
        Dim LblCodAdesao As Label
        For Each row As GridViewRow In GridView1.Rows
            If row.RowType = DataControlRowType.DataRow Then
                lnk = row.FindControl("LnkAdesao")
                LblCodAdesao = row.FindControl("LblCodAdesao")
                LblCodEmitente = row.FindControl("LblCodEmitente")
                lnk.OnClientClick = "window.open('http://matriz.unissistemas.com.br/webdeskunis/simulador-tef/WFRedirecionar.aspx?e=" + LblCodEmitente.Text + "&a=" + LblCodAdesao.Text + "&t=2&r=WFAdesaoTEF_paspx_ie_q" + LblCodEmitente.Text + "'); return false;"
            End If
        Next
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Dim chaves As String() = e.CommandArgument.ToString.Split(";")
            Response.Redirect("WFAdesaoTEF.aspx?e=" + chaves(0) + "&c=" + chaves(1) + "&ori=P")
        End If
    End Sub
End Class