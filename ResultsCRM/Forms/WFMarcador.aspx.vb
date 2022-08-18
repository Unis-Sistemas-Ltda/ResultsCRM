Public Class WFMarcador
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCMarcador1.Acao = Session("SAcao")
        WUCMarcador1.CodMarcador = Session("SCodMarcador")
        If Request.QueryString.Item("embeeded") = "True" Then
            If Request.QueryString.Item("A") = "I" Then
                WUCMarcador1.Acao = "INCLUIR"
            End If
        End If
    End Sub

End Class