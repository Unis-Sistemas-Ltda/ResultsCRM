Public Class UCLEmailMarcador
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("email_marcador", StrConexaoEmail)
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pSeqEmail As String, ByVal pCodMarcador As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("seq_email", pSeqEmail)
            Me.SetConteudo("cod_marcador", pCodMarcador)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pSeqEmail As String, ByVal pCodMarcador As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("seq_email", pSeqEmail)
            Me.SetConteudo("cod_marcador", pCodMarcador)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
