Public Class UCLEmitenteTEF
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("emitente_tef")
    End Sub

    Public Function Buscar(ByVal pCodEmitente As String) As Boolean
        Try
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodEmitente As String)
        Try
            Me.SetConteudo("cod_emitente", pCodEmitente)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
