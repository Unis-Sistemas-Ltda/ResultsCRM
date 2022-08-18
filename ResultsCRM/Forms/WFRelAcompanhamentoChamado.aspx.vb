Imports System.IO
Public Class WFRelAcompanhamentoChamado
    Inherits System.Web.UI.Page
    Dim objParametrosManutencao As New UCLParametrosManutencao

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objTipoChamado As New UCLTipoChamado

        TxtDataAberturaI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
        TxtDataAberturaF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
        TxtDataEncerramentoI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
        TxtDataEncerramentoF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")

        objParametrosManutencao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"))

        If Not IsPostBack Then
            TxtDataAberturaI.Text = "01/" + Now.Month.ToString.PadLeft(2, "0") + "/" + Now.Year.ToString
            TxtDataAberturaF.Text = CDate(TxtDataAberturaI.Text).AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy")
            TxtDataEncerramentoI.Text = "01/01/1900"
            TxtDataEncerramentoF.Text = "31/12/2999"
            TxtCodEmitente.Text = "0"

            Call CarregaAnalista()
            Call CarregaDepartamento()
            Call CarregaRegiao()

            objTipoChamado.FillDropDown(Session("GlEmpresa"), ddlTipoChamado, True, "(Todos)", 0)

            Call AplicaFiltro()
        End If
    End Sub

    Protected Sub BtnAplicarFiltro_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAplicarFiltro.Click
        Call AplicaFiltro()
    End Sub

    Private Sub CarregaRegiao()
        Dim objRegiao As New UCLRegiao
        objRegiao.FillDropDown(Session("GlEmpresa"), ddlRegiao, True, "(Todas)")
    End Sub

    Private Sub AplicaFiltro()
        LblErro.Text = ""
        If Not isValidDate(TxtDataAberturaI.Text) Then
            LblErro.Text += "Preencha corretamente o início do período de abertura.<br/>"
        End If
        If Not isValidDate(TxtDataAberturaF.Text) Then
            LblErro.Text += "Preencha corretamente o término do período de abertura.<br/>"
        End If
        If Not isValidDate(TxtDataEncerramentoI.Text) Then
            LblErro.Text += "Preencha corretamente o início do período de encerramento.<br/>"
        End If
        If Not isValidDate(TxtDataEncerramentoF.Text) Then
            LblErro.Text += "Preencha corretamente o término do período de encerramento.<br/>"
        End If
        If TxtCodEmitente.Text.Trim.Length = 0 Then
            TxtCodEmitente.Text = "0"
        End If
        If LblErro.Text = "" Then
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        End If
    End Sub

    Private Sub CarregaAnalista()
        Dim objAnalista As New UCLAnalista
        objAnalista.FillDropDown(ddlAnalista, True, "(Todos)", 0, True, False, 0, "")
        ddlAnalista.Items.FindByValue(0).Selected = True
    End Sub

    Private Sub CarregaDepartamento()
        Dim ObjUsuario As New UCLUsuario
        ObjUsuario.FillDropDownDepartamentos(DdlDepartamento, True, "(Todos)")
        DdlDepartamento.Items.FindByValue(0).Selected = True
    End Sub

    Private Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        Try
            Dim totalAbsoluto As Long = 0
            Dim totalConforme As Long = 0
            Dim totalNaoConforme As Long = 0
            Dim LblNoPrazo As Label
            Dim tempoHoras As Double = 0
            Dim tempoDias As Double = 0

            For Each row As GridViewRow In GridView1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    totalAbsoluto += 1
                    LblNoPrazo = row.FindControl("LblSituacao")
                    tempoHoras += CType(row.FindControl("LblTempoH"), Label).Text
                    tempoDias += CType(row.FindControl("LblTempoDias"), Label).Text
                    If LblNoPrazo.Text = "SIM" Then
                        totalConforme += 1
                    Else
                        totalNaoConforme += 1
                    End If
                End If
            Next

            LblTotalAbsoluto.Text = totalAbsoluto.ToString("F0")
            LblTotalConforme.Text = totalConforme.ToString("F0")
            LblTotalNaoConforme.Text = totalNaoConforme.ToString("F0")
            LblTotalPercentual.Text = "100,00 %"
            LblPercentualConforme.Text = ((CDbl(totalConforme) / totalAbsoluto) * 100).ToString("F2") + " %"
            LblPercentualNaoConforme.Text = ((CDbl(totalNaoConforme) / totalAbsoluto) * 100).ToString("F2") + " %"

            LblQtdMediaHoras.Text = (tempoHoras / totalAbsoluto).ToString("F2")
            LblQtdMediaDias.Text = (tempoDias / totalAbsoluto).ToString("F2")

        Catch ex As Exception
            LblErro.Text = ex.Message
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
            Response.AddHeader("content-disposition", "attachment;filename=" & "AcompanhamentoSLAChegada.xls")
            Response.Charset = ""
            EnableViewState = False

            Controls.Add(frm)
            frm.Controls.Add(GridView1)
            frm.RenderControl(hw)

            Response.Write(tw.ToString())
            Response.End()
        Else
            LblErro.Text = "Planilha possui mais linhas do que o Excel suporta. Dessa forma, não será possível exportá-la."
        End If

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Call exportarExcel()
    End Sub
End Class