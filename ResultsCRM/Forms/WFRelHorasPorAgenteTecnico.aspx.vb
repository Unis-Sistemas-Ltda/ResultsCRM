Public Class WFRelHorasPorAgenteTecnico
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'txtDataI.Attributes.Add("OnBlur", "formataCampoData(this)")
        'TxtDataF.Attributes.Add("OnBlur", "formataCampoData(this)")
        'txtDataI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
        'TxtDataF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")

        If Not IsPostBack Then
            Dim objAgenteTecnico As New UCLAgenteTecnico
            objAgenteTecnico.FillDropDown(DdlAgente, True, " (Todos) ", "", True)

            txtDataI.Text = (New Date(Now.Year, Now.Month, 1)).ToString("dd/MM/yyyy")
            TxtDataF.Text = (New Date(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month))).ToString("dd/MM/yyyy")
            GridView1.DataBind()
            Totalizar()
        End If
    End Sub

    Protected Sub BtnAplicarFiltro_Click(sender As Object, e As EventArgs) Handles BtnAplicarFiltro.Click
        If DdlModelo.SelectedValue = "R" Then
            GridView1.Visible = True
            GridView2.Visible = False
        ElseIf DdlModelo.SelectedValue = "D" Then
            GridView1.Visible = False
            GridView2.Visible = True
        End If
        GridView1.DataBind()
        GridView2.DataBind()
        Totalizar()
    End Sub

    Private Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound
        Try
            Dim qtdTotalHoras As Double = 0
            Dim LblQtdHoras As Label
            Dim LblQtdTotalHoras As Label

            For Each row As GridViewRow In GridView1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    LblQtdHoras = CType(row.FindControl("LblQtdHoras"), Label)
                    qtdTotalHoras += CDbl(LblQtdHoras.Text)
                End If
            Next

            If GridView1.Rows.Count > 0 Then
                LblQtdTotalHoras = CType(GridView1.FooterRow.FindControl("LblQtdTotalHoras"), Label)
                LblQtdTotalHoras.Text = qtdTotalHoras.ToString("F2")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView2_DataBound(sender As Object, e As System.EventArgs) Handles GridView2.DataBound
        Try
            Dim qtdTotalHoras As Double = 0
            Dim LblQtdHoras As Label
            Dim LblQtdTotalHoras As Label

            For Each row As GridViewRow In GridView2.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    LblQtdHoras = CType(row.FindControl("LblQtdHoras"), Label)
                    qtdTotalHoras += CDbl(LblQtdHoras.Text)
                End If
            Next

            If GridView2.Rows.Count > 0 Then
                LblQtdTotalHoras = CType(GridView2.FooterRow.FindControl("LblQtdTotalHoras"), Label)
                LblQtdTotalHoras.Text = qtdTotalHoras.ToString("F2")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub Totalizar()
        Try
            Dim codigo As String
            Dim descricao As String
            Dim quantidade As String
            Dim codigos As New List(Of String)
            Dim descricoes As New List(Of String)
            Dim quantidades As New List(Of Double)
            Dim pos As Long

            If GridView1.Visible Then
                For Each row As GridViewRow In GridView1.Rows
                    If row.RowType = DataControlRowType.DataRow Then
                        codigo = CType(row.FindControl("LblCodTipoCobrancaOS"), Label).Text
                        descricao = CType(row.FindControl("LblDescricaoTipoCobrancaOS"), Label).Text
                        quantidade = CDbl(CType(row.FindControl("LblQtdHoras"), Label).Text)
                        pos = codigos.IndexOf(codigo)
                        If pos >= 0 Then
                            quantidades.Item(pos) += quantidade
                        Else
                            codigos.Add(codigo)
                            descricoes.Add(descricao)
                            quantidades.Add(quantidade)
                        End If
                    End If
                Next
            Else
                For Each row As GridViewRow In GridView2.Rows
                    If row.RowType = DataControlRowType.DataRow Then
                        codigo = CType(row.FindControl("LblCodTipoCobrancaOS"), Label).Text
                        descricao = CType(row.FindControl("LblDescricaoTipoCobrancaOS"), Label).Text
                        quantidade = CDbl(CType(row.FindControl("LblQtdHoras"), Label).Text)
                        pos = codigos.IndexOf(codigo)
                        If pos >= 0 Then
                            quantidades.Item(pos) += quantidade
                        Else
                            codigos.Add(codigo)
                            descricoes.Add(descricao)
                            quantidades.Add(quantidade)
                        End If
                    End If
                Next
            End If

            LblTotalizacao.Text = "TOTAL POR TIPO DE COBRANÇA<br><br>"

            For i As Long = 0 To codigos.Count - 1
                LblTotalizacao.Text += IIf(String.IsNullOrEmpty(descricoes(i)), "(tipo de cobrança não informado)", descricoes(i)) + ": " + quantidades(i).ToString("F2") + " h <br>"
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class