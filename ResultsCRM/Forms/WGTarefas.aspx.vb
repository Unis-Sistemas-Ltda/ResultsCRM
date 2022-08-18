Public Partial Class WGTarefas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call ProcessaRblTipo()
            Call CarregaAgentesVenda(Session("GlCodUsuario"))
            If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Total Then
                GridView1.Columns.Item(0).Visible = True
                DdlAgenteVendas.SelectedValue = 0
                DdlAgenteVendas.Enabled = True
            Else
                GridView1.Columns.Item(0).Visible = False
                DdlAgenteVendas.SelectedValue = Session("GlCodUsuario")
                DdlAgenteVendas.Enabled = False
            End If
            Call Filtrar()
        End If
    End Sub

    Private Sub CarregaAgentesVenda(ByVal codAgenteVenda As String)
        Dim objAgente As New UCLAgenteVendas
        If Session("GlAgenteVendaMaster") = "S" OrElse Session("GlRestricaoAcessoAgenteVenda") = 0 Then
            objAgente.FillDropDown(DdlAgenteVendas, True, "(Todos)", 0, UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
        Else
            objAgente.FillDropDown(DdlAgenteVendas, True, "(Todos)", Session("GlCodUsuario"), UCLAgenteVendas.TipoRestricaoAcesso.SomenteOProprioAgenteDeVendasNoCRMeNoResults)
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim negociacao As String
        Dim seqTarefa As String
        If e.CommandName = "ALTERAR" Then
            negociacao = Left(e.CommandArgument.ToString, 8)
            seqTarefa = Right(e.CommandArgument.ToString, 4)
            Session("SCodNegociacao") = negociacao
            Session("SSeqTarefaNegociacao") = seqTarefa
            Session("SAcaoItem") = "ALTERAR"
            Response.Redirect("WFNegociacaoTarefa.aspx?tid=1")
        End If
    End Sub

    Protected Sub RblPeriodo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RblPeriodo.SelectedIndexChanged
        Call ProcessaRblTipo()
    End Sub

    Protected Sub ProcessaRblTipo()
        Dim diaDaSemana As Long
        Dim mes As Long
        Dim ano As Long
        Dim data As Date
        Dim dataInicial As Date
        Dim dataFinal As Date
        If RblPeriodo.SelectedValue = "H" Then
            dataInicial = Today
            dataFinal = Today
        ElseIf RblPeriodo.SelectedValue = "M" Then
            data = Today
            ano = data.Year
            mes = data.Month
            dataInicial = New Date(ano, mes, 1)
            dataFinal = New Date(ano, mes, 1)
            dataFinal = dataFinal.AddMonths(1)
            dataFinal = dataFinal.AddDays(-1)
        ElseIf RblPeriodo.SelectedValue = "A" Then
            data = Today
            ano = data.Year
            dataInicial = New Date(ano, 1, 1)
            dataFinal = New Date(ano + 1, 1, 1)
            dataFinal = dataFinal.AddDays(-1)
        ElseIf RblPeriodo.SelectedValue = "S" Then
            data = Today
            diaDaSemana = Weekday(data, Microsoft.VisualBasic.FirstDayOfWeek.Sunday)
            While diaDaSemana > 1
                data = data.AddDays(-1)
                diaDaSemana -= 1
            End While
            dataInicial = data
            dataFinal = data.AddDays(6)
        End If
        TxtDataInicial.Text = dataInicial.ToString("dd/MM/yyyy")
        TxtDataFinal.Text = dataFinal.ToString("dd/MM/yyyy")
    End Sub

    Protected Sub ProcessaTextoData(ByRef Txt As TextBox, ByRef Lbl As Label)
        Dim data As Date
        If IsDate(Txt.Text) Then
            data = Txt.Text
            Lbl.Text = data.ToString("yyyy-MM-dd")
        Else
            Lbl.Text = ""
        End If
    End Sub

    Protected Sub CarregaGrid()
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFiltrar.Click
        Call Filtrar()
    End Sub

    Private Sub Filtrar()
        Try
            Call ProcessaTextoData(TxtDataInicial, LblDataInicial)
            Call ProcessaTextoData(TxtDataFinal, LblDataFinal)
            Call CarregaGrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class