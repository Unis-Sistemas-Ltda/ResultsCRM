Public Class UCLChamadoSolicitacaoDesenvolvimento
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("chamado_solicitacao_desenvolvimento")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodChamado As String, ByVal pCodSolicitacao As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_chamado", pCodChamado)
            Me.SetConteudo("cod_solicitacao", pCodSolicitacao)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

