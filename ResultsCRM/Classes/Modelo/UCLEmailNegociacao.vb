Public Class UCLEmailNegociacao
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("email_negociacao", StrConexaoEmail)
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pSeqEmail As String, ByVal pCodNegociacaoCliente As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("seq_email", pSeqEmail)
            Me.SetConteudo("cod_negociacao_cliente", pCodNegociacaoCliente)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pSeqEmail As String, ByVal pCodNegociacaoCliente As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("seq_email", pSeqEmail)
            Me.SetConteudo("cod_negociacao_cliente", pCodNegociacaoCliente)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
