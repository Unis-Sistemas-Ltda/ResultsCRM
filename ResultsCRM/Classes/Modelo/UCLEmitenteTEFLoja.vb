Public Class UCLEmitenteTEFLoja
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("emitente_tef_loja")
    End Sub

    Public Function Buscar(ByVal pCodEmitente As String, ByVal pCNPJ As String) As Boolean
        Try
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cnpj", pCNPJ)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodEmitente As String, ByVal pCNPJ As String)
        Try
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cnpj", pCNPJ)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
