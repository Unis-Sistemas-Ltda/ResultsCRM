Public Class UCLFAQModulo
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("faq_modulo")
    End Sub

    Public Function Buscar(ByVal pCodFAQ As String, ByVal pCodModulo As String) As Boolean
        Try
            Me.SetConteudo("cod_faq", pCodFAQ)
            Me.SetConteudo("cod_modulo", pCodModulo)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodFAQ As String, ByVal pCodModulo As String)
        Try
            Me.SetConteudo("cod_faq", pCodFAQ)
            Me.SetConteudo("cod_modulo", pCodModulo)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class