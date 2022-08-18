Public Class WFRelListagemChamadosResumido
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub GridView2_DataBound(sender As Object, e As System.EventArgs)
        Dim LblValorOS As Label
        Dim LblQtdChamados As Label
        Dim total As Double = 0
        Dim qtdChamados As Double = 0
        Dim GridView2 As GridView = CType(sender, GridView)
        For i As Long = 0 To GridView2.Rows.Count - 1
            If GridView2.Rows.Item(i).RowType = DataControlRowType.DataRow Then
                LblValorOS = CType(GridView2.Rows.Item(i).FindControl("LblValorOS0"), Label)
                LblQtdChamados = CType(GridView2.Rows.Item(i).FindControl("LblQtdChamados0"), Label)
                If IsNumeric(LblValorOS.Text) Then
                    total += CDbl(LblValorOS.Text)
                End If
                If IsNumeric(LblQtdChamados.Text) Then
                    qtdChamados += CDbl(LblQtdChamados.Text)
                End If
            End If
        Next
        If GridView2.Rows.Count > 0 Then
            CType(GridView2.FooterRow.FindControl("LblTotal0"), Label).Text = total.ToString("F2")
            CType(GridView2.FooterRow.FindControl("LblQtdTotalChamados0"), Label).Text = qtdChamados.ToString("F0")
        End If
    End Sub

    Public Sub GridView1_DataBound(sender As Object, e As System.EventArgs)
        Dim LblValorOS As Label
        Dim total As Double = 0
        Dim GridView1 As GridView = CType(sender, GridView)
        For i As Long = 0 To GridView1.Rows.Count - 1
            If GridView1.Rows.Item(i).RowType = DataControlRowType.DataRow Then
                LblValorOS = CType(GridView1.Rows.Item(i).FindControl("LblValorOS"), Label)
                If IsNumeric(LblValorOS.Text) Then
                    total += CDbl(LblValorOS.Text)
                End If
            End If
        Next
        If GridView1.Rows.Count > 0 Then
            CType(GridView1.FooterRow.FindControl("LblTotal"), Label).Text = total.ToString("F2")
        End If
    End Sub

End Class