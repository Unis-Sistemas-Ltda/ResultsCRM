Public Class UCLFunilVendaEtapaNegociacao

    Private ObjAcessoDados As UCLAcessoDados

    Public Sub New()
        ObjAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Incluir(ByVal pEmpresa As String, ByVal pCodFunil As String, ByVal pCodEtapa As String, ByVal pSeqPipeLine As String) As Boolean
        Try
            Dim StrSql As String
            StrSql = " insert into funil_venda_etapa_negociacao(empresa, cod_funil, cod_etapa, seq_pipeline) "
            StrSql += "  select " + pEmpresa + ", " + pCodFunil + ", " + pCodEtapa + ", " + IIf(String.IsNullOrEmpty(pSeqPipeLine), "null", pSeqPipeLine)
            StrSql += "    from dummy "
            StrSql += "   where not exists(select 1 from funil_venda_etapa_negociacao where empresa = " + pEmpresa + " and cod_funil = " + pCodFunil + " and cod_etapa = " + pCodEtapa + ")"
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Excluir(ByVal pEmpresa As String, ByVal pCodFunil As String, ByVal pCodEtapa As String) As Boolean
        Try
            Dim StrSql As String
            StrSql = " delete from funil_venda_etapa_negociacao "
            StrSql += " where empresa = " + pEmpresa + " and cod_funil = " + pCodFunil + " and cod_etapa = " + pCodEtapa
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
