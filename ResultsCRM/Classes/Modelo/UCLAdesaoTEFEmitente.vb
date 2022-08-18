Public Class UCLAdesaoTEFEmitente
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("adesao_tef_emitente")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodEmitente As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodEmitente As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_emitente", pCodEmitente)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
