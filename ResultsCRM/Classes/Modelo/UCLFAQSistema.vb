Public Class UCLFAQSistema
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("faq_sistema")
    End Sub

    Public Function Buscar(ByVal pCodFAQ As String, ByVal pCodSistema As String) As Boolean
        Try
            Me.SetConteudo("cod_faq", pCodFAQ)
            Me.SetConteudo("cod_sistema", pCodSistema)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodFAQ As String, ByVal pCodSistema As String)
        Try
            Me.SetConteudo("cod_faq", pCodFAQ)
            Me.SetConteudo("cod_sistema", pCodSistema)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class