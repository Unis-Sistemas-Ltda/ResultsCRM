Public Class WFRelConsumoHoras
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TxtDataI.Text = New Date(Year(Today()), Month(Today), 1).ToString("dd/MM/yyyy")
            TxtDataF.Text = New Date(Year(Today()), Month(Today), Date.DaysInMonth(Year(Today()), Month(Today()))).ToString("dd/MM/yyyy")
            GridView2.DataBind()
        End If
    End Sub

    Protected Sub BtnAplicarFiltro_Click(sender As Object, e As EventArgs) Handles BtnAplicarFiltro.Click
        GridView2.DataBind()
    End Sub
End Class