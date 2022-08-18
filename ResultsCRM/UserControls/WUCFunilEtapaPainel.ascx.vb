Public Class WUCFunilEtapaPainel
    Inherits System.Web.UI.UserControl

    Public Property CodEtapa As String
        Get
            Return LblCodEtapa.Text
        End Get
        Set(value As String)
            LblCodEtapa.Text = value
        End Set
    End Property

    Public Property NomeEtapa As String
        Get
            Return LblNomeEtapa.Text
        End Get
        Set(value As String)
            LblNomeEtapa.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound
        Dim Total As Double = 0
        If GridView1.Rows.Count > 0 Then
            For i As Long = 0 To GridView1.Rows.Count - 1
                If IsNumeric(CType(GridView1.Rows.Item(i).FindControl("LblValor"), Label).Text) Then
                    Total += CDbl(CType(GridView1.Rows.Item(i).FindControl("LblValor"), Label).Text)
                End If
            Next
            CType(GridView1.HeaderRow.FindControl("LblTitulo"), Label).Text = LblNomeEtapa.Text
            CType(GridView1.HeaderRow.FindControl("LblQtdNegociacoes"), Label).Text = GridView1.Rows.Count.ToString + " negócios"
            CType(GridView1.HeaderRow.FindControl("LblValorTotal"), Label).Text = Total.ToString("N2")
        Else
            CType(GridView1.HeaderRow.FindControl("LblTitulo"), Label).Text = LblNomeEtapa.Text
        End If
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SCodNegociacao") = e.CommandArgument
            Session("SAcaoNegociacao") = "ALTERAR"
            Session("SRedir") = "WFNegociacaoDetalhes.aspx?b=WFNegociacaoFiltro.aspx"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "cmd", "b = parent.document.getElementById('BtnRedirect'); b.click()", True)
        End If
    End Sub
End Class