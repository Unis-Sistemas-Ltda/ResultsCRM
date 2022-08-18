Public Class UCLRotinaModulo
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("rotina_modulo")
    End Sub

    Public Function Buscar(ByVal pCodRotina As String, ByVal pCodModulo As String) As Boolean
        Try
            Me.SetConteudo("cod_rotina", pCodRotina)
            Me.SetConteudo("cod_modulo", pCodModulo)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodRotina As String, ByVal pCodModulo As String)
        Try
            Me.SetConteudo("cod_rotina", pCodRotina)
            Me.SetConteudo("cod_modulo", pCodModulo)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class