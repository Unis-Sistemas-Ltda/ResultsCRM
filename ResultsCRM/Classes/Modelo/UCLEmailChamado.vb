Public Class UCLEmailChamado
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("email_chamado", StrConexaoEmail)
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pSeqEmail As String, ByVal pCodChamado As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("seq_email", pSeqEmail)
            Me.SetConteudo("cod_chamado", pCodChamado)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pSeqEmail As String, ByVal pCodChamado As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("seq_email", pSeqEmail)
            Me.SetConteudo("cod_chamado", pCodChamado)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
