Public Class UCLNegociacaoClienteDespesas
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("negociacao_cliente_despesas")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacaoCliente As String, ByVal pCodTipoDespAcess As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_negociacao_cliente", pCodNegociacaoCliente)
            Me.SetConteudo("cod_tipo_desp_acess", pCodTipoDespAcess)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacaoCliente As String, ByVal pCodTipoDespAcess As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("estabelecimento", pEstabelecimento)
            Me.SetConteudo("cod_negociacao_cliente", pCodNegociacaoCliente)
            Me.SetConteudo("cod_tipo_desp_acess", pCodTipoDespAcess)
            ObjTabelaGenerica.Excluir()

            
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacaoCliente As String)
        Try
            Dim StrSql As String = " delete from negociacao_cliente_despesas where empresa = " + pEmpresa + " and estabelecimento = " + pEstabelecimento + " and cod_negociacao_cliente = " + pCodNegociacaoCliente
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
