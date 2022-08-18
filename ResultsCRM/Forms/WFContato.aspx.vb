Public Partial Class WFContato
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case Request.QueryString.Item("a")
            Case "I"
                WUCContato1.Acao = "INCLUIR"
            Case "A"
                WUCContato1.Acao = "ALTERAR"
        End Select
        WUCContato1.CodContato = Session(VariavelCodContato)
        WUCContato1.CodEmitente = Session(VariavelCodEmitente)
    End Sub

    Private ReadOnly Property VariavelCodContato()
        Get
            Return Request.QueryString.Item("vcodc").ToString
        End Get
    End Property

    Private ReadOnly Property VariavelCodEmitente()
        Get
            Return Request.QueryString.Item("vcode").ToString
        End Get
    End Property

End Class
