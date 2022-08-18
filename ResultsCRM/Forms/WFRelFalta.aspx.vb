Imports System.IO

Public Class WFRelFalta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TxtDataI.Text = "01/" + Now.Date.Month.ToString.PadLeft(2, "0") + "/" + Now.Date.Year.ToString.PadLeft(4, "0")
            TxtDataF.Text = Date.DaysInMonth(Now.Date.Year, Now.Date.Month).ToString() + "/" + Now.Date.Month.ToString.PadLeft(2, "0") + "/" + Now.Date.Year.ToString.PadLeft(4, "0")
            Call CarregaEstabelecimentos()
            Call CarregaTecnicos()
            GridView1.DataBind()
        End If
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

    Private Sub exportarExcel()

        'se o grid tiver mais que 65536  linhas não podemos exportar
        If GridView1.Rows.Count.ToString + 1 < 65536 Then

            GridView1.AllowPaging = "False"
            GridView1.AllowSorting = "false"
            GridView1.DataBind()

            Dim tw As New StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim frm As HtmlForm = New HtmlForm()

            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment;filename=" & "RelatorioDeFaltas.xls")
            Response.Charset = ""
            EnableViewState = False

            Controls.Add(frm)
            frm.Controls.Add(GridView1)
            frm.RenderControl(hw)

            Response.Write(tw.ToString())
            Response.End()
        End If

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Call exportarExcel()
    End Sub
End Class