Public Class UCLPedidoVendaItemEquipamentoComponente

    Private ObjAcessoDados As UCLAcessoDados

    Private _empresa As String
    Private _estabelecimento As String
    Private _codPedidoVenda As String
    Private _seqItem As String
    Private _numeroSerie As String
    Private _seqComponente As String

    Public Property Empresa() As String
        Get
            Return _empresa
        End Get
        Set(ByVal value As String)
            _empresa = value
        End Set
    End Property

    Public Property Estabelecimento() As String
        Get
            Return _estabelecimento
        End Get
        Set(ByVal value As String)
            _estabelecimento = value
        End Set
    End Property

    Public Property CodPedidoVenda() As String
        Get
            Return _codPedidoVenda
        End Get
        Set(ByVal value As String)
            _codPedidoVenda = value
        End Set
    End Property

    Public Property SeqItem() As String
        Get
            Return _seqItem
        End Get
        Set(ByVal value As String)
            _seqItem = value
        End Set
    End Property

    Public Property NumeroSerie() As String
        Get
            Return _numeroSerie
        End Get
        Set(ByVal value As String)
            _numeroSerie = value
        End Set
    End Property

    Public Property SeqComponente() As String
        Get
            Return _seqComponente
        End Get
        Set(ByVal value As String)
            _seqComponente = value
        End Set
    End Property

    Public Sub New(ByVal StrConn As String)
        ObjAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Function Existe() As Boolean
        Try
            Dim StrSql As String
            Dim dt As DataTable
            StrSql = "  select empresa "
            StrSql += "   from pedido_venda_item_equipamento_componente "
            StrSql += "  where empresa           = " + Empresa
            StrSql += "    and estabelecimento   = " + Estabelecimento
            StrSql += "    and cod_pedido_venda  = " + CodPedidoVenda
            StrSql += "    and seq_item          = " + SeqItem
            StrSql += "    and numero_serie      = '" + NumeroSerie + "'"
            StrSql += "    and seq_componente    = " + SeqComponente
            dt = ObjAcessoDados.BuscarDados(StrSql)
            Return dt.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Incluir()
        Try
            Dim StrSql As String = ""

            StrSql += " call sp_sysvar(); "
            StrSql += " insert into pedido_venda_item_equipamento_componente ( "
            StrSql += "    empresa, "
            StrSql += "    estabelecimento, "
            StrSql += "    cod_pedido_venda, "
            StrSql += "    seq_item, "
            StrSql += "    numero_serie, "
            StrSql += "    seq_componente ) "
            StrSql += " values ( "
            StrSql += Empresa + ", "
            StrSql += Estabelecimento + ", "
            StrSql += CodPedidoVenda + ", "
            StrSql += SeqItem + ", "
            StrSql += "'" + NumeroSerie + "', "
            StrSql += SeqComponente + ")"
            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String
            StrSql = " call sp_sysvar();"
            StrSql += " delete from pedido_venda_item_equipamento_componente "
            StrSql += "  where empresa           = " + Empresa
            StrSql += "    and estabelecimento   = " + Estabelecimento
            StrSql += "    and cod_pedido_venda  = " + CodPedidoVenda
            StrSql += "    and seq_item          = " + SeqItem
            StrSql += "    and numero_serie      = '" + NumeroSerie + "'"
            StrSql += "    and seq_componente    = " + SeqComponente
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ExcluirTodos()
        Try
            Dim StrSql As String
            StrSql = " call sp_sysvar();"
            StrSql += " delete from pedido_venda_item_equipamento_componente "
            StrSql += "  where empresa           = " + Empresa
            StrSql += "    and estabelecimento   = " + Estabelecimento
            StrSql += "    and cod_pedido_venda  = " + CodPedidoVenda
            If Not String.IsNullOrEmpty(SeqItem) Then
                StrSql += "    and seq_item      = " + SeqItem
            End If
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
