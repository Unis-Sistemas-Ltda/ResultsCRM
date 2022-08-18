Partial Public Class WFFAQ
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim acao As String = Session("SAcao")
        WUCFAQ1.CodFAQ = Session("SCodFAQ")

        If acao = "INCLUIR" Then
            WUCFAQ1.Modo = ModoFormulario.Inclusao
        Else
            WUCFAQ1.Modo = ModoFormulario.ConsultaAlteracaoExclusao
        End If

    End Sub

End Class