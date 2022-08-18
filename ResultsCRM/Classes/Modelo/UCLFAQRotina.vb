Public Class UCLFAQRotina
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("faq_rotina")
    End Sub

    Public Function Buscar(ByVal pCodFAQ As String, ByVal pCodRotina As String) As Boolean
        Try
            Me.SetConteudo("cod_faq", pCodFAQ)
            Me.SetConteudo("cod_rotina", pCodRotina)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodFAQ As String, ByVal pCodRotina As String)
        Try
            Me.SetConteudo("cod_faq", pCodFAQ)
            Me.SetConteudo("cod_rotina", pCodRotina)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class