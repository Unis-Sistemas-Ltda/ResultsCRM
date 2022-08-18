Public Partial Class WFClose
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim controle As String
        Dim valor As String
        If Request.QueryString.Count > 0 Then
            controle = Request.QueryString.Item("cid")
            valor = Request.QueryString.Item("valor")
            body1.Attributes.Add("onLoad", "window.opener.document.forms(0)." & controle & ".value = '" & valor & "';window.opener.document.forms[0].submit();window.close()")
        Else
            body1.Attributes.Add("onLoad", "window.opener.document.forms[0].submit();self.close()")
        End If

    End Sub

End Class