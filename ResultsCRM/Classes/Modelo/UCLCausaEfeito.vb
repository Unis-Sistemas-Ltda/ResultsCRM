Public Class UCLCausaEfeito
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("causa_efeito")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodCausa As String, ByVal pCodEfeito As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_causa", pCodCausa)
            Me.SetConteudo("cod_efeito", pCodEfeito)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodCausa As String, ByVal pCodEfeito As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_causa", pCodCausa)
            Me.SetConteudo("cod_efeito", pCodEfeito)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class

