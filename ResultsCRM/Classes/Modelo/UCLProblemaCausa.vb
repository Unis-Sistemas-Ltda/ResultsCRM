Public Class UCLProblemaCausa
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("problema_causa")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodProblema As String, ByVal pCodCausa As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_problema", pCodProblema)
            Me.SetConteudo("cod_causa", pCodCausa)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodProblema As String, ByVal pCodCausa As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_problema", pCodProblema)
            Me.SetConteudo("cod_causa", pCodCausa)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
