Public Class UCLTransferenciaTecnicoInstalacaoRetorno

    Private ObjAcessoDados As UCLAcessoDados

    Public Property empresa As String
    Public Property estabelecimento As String
    Public Property cod_transferencia As String
    Public Property seq_transferencia As String
    Public Property seq_retorno As String
    Public Property seq_baixa_origem As String
    Public Property cod_pedido_venda As String
    Public Property datahora As String
    Public Property d_datahora As Date
    Public Property h_datahora As String
    Public Property cod_usuario As String
    Public Property cod_item_baixa As String
    Public Property quantidade_baixa As String
    Public Property lote_baixa As String
    Public Property referencia_baixa As String
    Public Property cod_item_retorno As String
    Public Property quantidade_retorno As String
    Public Property lote_retorno As String
    Public Property referencia_retorno As String
    Public Property atualizado As String
    Public Property cod_usuario_atualizacao As String
    Public Property datahora_atualizacao As String
    Public Property d_datahora_atualizacao As Date
    Public Property h_datahora_atualizacao As String

    Public Sub New(ByVal StrConn)
        ObjAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Sub ExcluirPorBaixaOriginal()
        Try
            Dim StrSql As String
            StrSql = " delete from transferencia_tecnico_instalacao_retorno where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_transferencia = " + cod_transferencia + " and seq_transferencia = " + seq_transferencia + " and seq_baixa_origem = " + seq_baixa_origem + " and isnull(atualizado,'N') = 'N' and isnull(cancelamento_aprovado,'N') = 'N' "
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = "select * from transferencia_tecnico_instalacao_retorno where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_transferencia = " + cod_transferencia + " and seq_transferencia = " + seq_transferencia + " and seq_retorno = " + seq_retorno
            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                seq_baixa_origem = dt.Rows.Item(0).Item("seq_baixa_origem").ToString
                cod_pedido_venda = dt.Rows.Item(0).Item("cod_pedido_venda").ToString
                If Not IsDBNull(dt.Rows.Item(0).Item("datahora")) Then
                    datahora = CType(dt.Rows.Item(0).Item("datahora"), DateTime).ToString("dd/MM/yyyy HH:mm:ss")
                    d_datahora = CDate(dt.Rows.Item(0).Item("datahora"))
                    h_datahora = CType(dt.Rows.Item(0).Item("datahora"), DateTime).ToString("HH:mm:ss")
                Else
                    datahora = ""
                    d_datahora = Nothing
                    h_datahora = ""
                End If
                cod_usuario = dt.Rows.Item(0).Item("cod_usuario").ToString
                cod_item_baixa = dt.Rows.Item(0).Item("cod_item_baixa").ToString
                quantidade_baixa = dt.Rows.Item(0).Item("quantidade_baixa").ToString
                lote_baixa = dt.Rows.Item(0).Item("lote_baixa").ToString
                referencia_baixa = dt.Rows.Item(0).Item("referencia_baixa").ToString
                cod_item_retorno = dt.Rows.Item(0).Item("cod_item_retorno").ToString
                quantidade_retorno = dt.Rows.Item(0).Item("quantidade_retorno").ToString
                lote_retorno = dt.Rows.Item(0).Item("lote_retorno").ToString
                referencia_retorno = dt.Rows.Item(0).Item("referencia_retorno").ToString
                atualizado = dt.Rows.Item(0).Item("atualizado").ToString
                cod_usuario_atualizacao = dt.Rows.Item(0).Item("cod_usuario_atualizacao").ToString
                If Not IsDBNull(dt.Rows.Item(0).Item("datahora_atualizacao")) Then
                    datahora_atualizacao = CType(dt.Rows.Item(0).Item("datahora_atualizacao"), DateTime).ToString("dd/MM/yyyy HH:mm:ss")
                    d_datahora_atualizacao = CDate(dt.Rows.Item(0).Item("datahora_atualizacao"))
                    h_datahora_atualizacao = CType(dt.Rows.Item(0).Item("datahora_atualizacao"), DateTime).ToString("HH:mm:ss")
                Else
                    datahora_atualizacao = ""
                    d_datahora_atualizacao = Nothing
                    h_datahora_atualizacao = ""
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
            Dim ls_cod_item_retorno As String
            Dim ls_lote_retorno As String
            Dim ls_referencia_retorno As String
            Dim ls_quantidade_retorno As String

            If String.IsNullOrWhiteSpace(cod_item_retorno) Then
                ls_cod_item_retorno = "null"
            Else
                ls_cod_item_retorno = "'" + cod_item_retorno + "'"
            End If

            If String.IsNullOrWhiteSpace(lote_retorno) Then
                ls_lote_retorno = "null"
            Else
                ls_lote_retorno = "'" + lote_retorno + "'"
            End If

            If String.IsNullOrWhiteSpace(referencia_retorno) Then
                ls_referencia_retorno = "null"
            Else
                ls_referencia_retorno = "'" + referencia_retorno + "'"
            End If

            If String.IsNullOrWhiteSpace(quantidade_retorno) Then
                ls_quantidade_retorno = "null"
            Else
                ls_quantidade_retorno = quantidade_retorno.Replace(",", ".")
            End If

            StrSql = " insert into transferencia_tecnico_instalacao_retorno(empresa, estabelecimento, cod_transferencia, seq_transferencia, seq_retorno, seq_baixa_origem, cod_pedido_venda, datahora, cod_usuario, cod_item_baixa, quantidade_baixa, lote_baixa, referencia_baixa, cod_item_retorno, quantidade_retorno, lote_retorno, referencia_retorno, atualizado, cod_usuario_atualizacao, datahora_atualizacao) "
            StrSql += " values ( " + empresa + ", " + estabelecimento + ", " + cod_transferencia + ", " + seq_transferencia + ", " + seq_retorno + ", " + seq_baixa_origem + ", " + cod_pedido_venda + ", getdate(), " + cod_usuario + ", '" + cod_item_baixa + "', " + quantidade_baixa.Replace(",", ".") + ", '" + lote_baixa + "', '" + referencia_baixa + "', " + ls_cod_item_retorno + ", " + ls_quantidade_retorno + ", " + ls_lote_retorno + ", " + ls_referencia_retorno + ", null, null, null) "
            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(seq_retorno),0) + 1 max from transferencia_tecnico_instalacao_retorno where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_transferencia = " + cod_transferencia + " and seq_transferencia = " + seq_transferencia
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
