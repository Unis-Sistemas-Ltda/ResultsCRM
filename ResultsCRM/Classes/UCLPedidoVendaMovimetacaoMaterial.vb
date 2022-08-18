Public Class UCLPedidoVendaMovimetacaoMaterial

    Private ObjAcessoDados As UCLAcessoDados
    Public Property Empresa As String
    Public Property Estabelecimento As String
    Public Property CodPedidoVenda As String
    Public Property SeqMovimentacao As String
    Public Property Tipo As String
    Public Property CodItem As String
    Public Property Lote As String
    Public Property Quantidade As String
    Public Property CodAgenteTecnico As String
    Public Property CodTransferencia As String
    Public Property CodUsuarioInclusao As String
    Public Property DataInclusao As String

    Public Sub New(ByVal pStrConexao As String)
        ObjAcessoDados = New UCLAcessoDados(pStrConexao)
    End Sub

    Public Sub Incluir()
        Try
            Dim StrSql As String

            StrSql = " insert into pedido_venda_movimentacao_material ( empresa, "
            StrSql += "   estabelecimento, "
            StrSql += "   cod_pedido_venda, "
            StrSql += "   seq_movimentacao, "
            StrSql += "   tipo, "
            StrSql += "   cod_item, "
            StrSql += "   lote, "
            StrSql += "   quantidade, "
            StrSql += "   cod_agente_tecnico, "
            StrSql += "   cod_transferencia, "
            StrSql += "   cod_usuario_inclusao, "
            StrSql += "   data_inclusao ) "
            StrSql += " values ( " + Empresa + ", "
            StrSql += Estabelecimento + ", "
            StrSql += CodPedidoVenda + ", "
            StrSql += SeqMovimentacao + ", "
            StrSql += "'" + Tipo + "', "
            StrSql += "'" + CodItem + "', "
            StrSql += "'" + Lote + "', "
            StrSql += Quantidade.Replace(".", "").Replace(",", ".") + ", "
            StrSql += CodAgenteTecnico + ", "
            StrSql += IIf(String.IsNullOrWhiteSpace(CodTransferencia), "null", CodTransferencia) + ", "
            StrSql += " f_busca_cod_usuario(current user), "
            StrSql += " getdate() ) "
            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim StrSql As String

            StrSql = " update pedido_venda_movimentacao_material "
            StrSql += "   set tipo               = '" + Tipo + "', "
            StrSql += "       cod_item           = '" + CodItem + "', "
            StrSql += "       lote               = '" + Lote + "', "
            StrSql += "       quantidade         = " + Quantidade.Replace(".", "").Replace(",", ".") + ", "
            StrSql += "       cod_agente_tecnico = " + CodAgenteTecnico + ", "
            StrSql += "       cod_transferencia  = " + IIf(String.IsNullOrWhiteSpace(CodTransferencia), "null", CodTransferencia)
            StrSql += " where empresa          = " + Empresa
            StrSql += "   and estabelecimento  = " + Estabelecimento
            StrSql += "   and cod_pedido_venda = " + CodPedidoVenda
            StrSql += "   and seq_movimentacao = " + SeqMovimentacao
            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String

            StrSql = " delete from pedido_venda_movimentacao_material "
            StrSql += " where empresa          = " + Empresa
            StrSql += "   and estabelecimento  = " + Estabelecimento
            StrSql += "   and cod_pedido_venda = " + CodPedidoVenda
            StrSql += "   and seq_movimentacao = " + SeqMovimentacao
            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = " select tipo, cod_item, lote, quantidade, cod_agente_tecnico, cod_transferencia, cod_usuario_inclusao, data_inclusao"
            StrSql += "  from pedido_venda_movimentacao_material "
            StrSql += " where empresa          = " + Empresa
            StrSql += "   and estabelecimento  = " + Estabelecimento
            StrSql += "   and cod_pedido_venda = " + CodPedidoVenda
            StrSql += "   and seq_movimentacao = " + SeqMovimentacao
            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                Tipo = dt.Rows.Item(0).Item("tipo").ToString
                CodItem = dt.Rows.Item(0).Item("cod_item").ToString
                Lote = dt.Rows.Item(0).Item("lote").ToString
                Quantidade = CDbl(dt.Rows.Item(0).Item("quantidade")).ToString("F3")
                CodAgenteTecnico = dt.Rows.Item(0).Item("cod_agente_tecnico").ToString
                CodTransferencia = dt.Rows.Item(0).Item("cod_transferencia").ToString
                CodUsuarioInclusao = dt.Rows.Item(0).Item("cod_usuario_inclusao").ToString
                DataInclusao = CType(dt.Rows.Item(0).Item("data_inclusao"), DateTime).ToString("dd/MM/yyyy HH:mm:ss")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(seq_movimentacao),0) + 1 max from pedido_venda_movimentacao_material where empresa = " + Empresa + " and estabelecimento = " + Estabelecimento + " and cod_pedido_venda = " + CodPedidoVenda
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
