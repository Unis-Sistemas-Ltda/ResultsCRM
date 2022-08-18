Public Class UCLTransferenciaTecnicoPendenciaSolicitacao

    Private ObjAcessoDados As UCLAcessoDados

    Public Property empresa As String
    Public Property estabelecimento As String
    Public Property cod_transferencia As String
    Public Property seq_transferencia As String
    Public Property seq_pendencia As String
    Public Property seq_baixa As String
    Public Property cod_item As String
    Public Property lote As String
    Public Property referencia As String
    Public Property quantidade As String
    Public Property datahora As String
    Public Property cod_usuario As String
    Public Property cod_pedido_venda As String
    Public Property d_datahora As Date
    Public Property h_datahora As String
    Public Property situacao As String
    Public Property cod_solicitacao

    Public Sub New(ByVal StrConn As String)
        ObjAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String
            StrSql = " delete from transferencia_tecnico_pendencia_solicitacao where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_transferencia = " + cod_transferencia + " and seq_transferencia = " + seq_transferencia + " and seq_pendencia = " + seq_pendencia
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ExcluirPorBaixaOriginal()
        Try
            Dim StrSql As String
            StrSql = " delete from transferencia_tecnico_pendencia_solicitacao where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_transferencia = " + cod_transferencia + " and seq_transferencia = " + seq_transferencia + " and seq_baixa = " + seq_baixa
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = "select cod_item, lote, referencia, cod_pedido_venda, quantidade, datahora, cod_usuario, situacao from transferencia_tecnico_pendencia_solicitacao f where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_transferencia = " + cod_transferencia + " and seq_transferencia = " + seq_transferencia + " and seq_pendencia = " + seq_pendencia
            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                cod_item = dt.Rows.Item(0).Item("cod_item").ToString
                lote = dt.Rows.Item(0).Item("lote").ToString
                referencia = dt.Rows.Item(0).Item("referencia").ToString
                quantidade = dt.Rows.Item(0).Item("quantidade").ToString
                cod_usuario = dt.Rows.Item(0).Item("cod_usuario").ToString
                cod_pedido_venda = dt.Rows.Item(0).Item("cod_pedido_venda").ToString
                situacao = dt.Rows.Item(0).Item("situacao").ToString
                If Not IsDBNull(dt.Rows.Item(0).Item("datahora")) Then
                    datahora = CType(dt.Rows.Item(0).Item("datahora"), DateTime).ToString("dd/MM/yyyy HH:mm:ss")
                    d_datahora = CDate(dt.Rows.Item(0).Item("datahora"))
                    h_datahora = CType(dt.Rows.Item(0).Item("datahora"), DateTime).ToString("HH:mm:ss")
                Else
                    datahora = ""
                    d_datahora = Nothing
                    h_datahora = ""
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Incluir()
        Try
            Dim StrSql As String

            StrSql = " insert into transferencia_tecnico_pendencia_solicitacao(empresa, estabelecimento, cod_transferencia, seq_transferencia, seq_pendencia, seq_baixa, cod_item, quantidade, lote, referencia, datahora, cod_usuario, cod_pedido_venda, situacao, cod_solicitacao)"
            StrSql += " values ( " + empresa + ", " + estabelecimento + ", " + cod_transferencia + ", " + seq_transferencia + ", " + seq_pendencia + ", " + seq_baixa + ", '" + cod_item + "', " + quantidade.Replace(",", ".") + ", '" + lote + "', '" + referencia + "', getdate(), " + cod_usuario + ", " + cod_pedido_venda + ", 1, null)"
            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(seq_pendencia),0) + 1 max from transferencia_tecnico_pendencia_solicitacao where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_transferencia = " + cod_transferencia + " and seq_transferencia = " + seq_transferencia
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
