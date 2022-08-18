Public Class UCLPedidoVendaItemProgramacao

    Private ObjAcessoDados As UCLAcessoDados

    Private _empresa As String
    Private _estabelecimento As String
    Private _codPedidoVenda As String
    Private _seqItem As String
    Private _seqProgramacao As String
    Private _qtdUD As String
    Private _qtdPedida As String
    Private _qtdAlocada As String
    Private _qtdEntregue As String
    Private _dataEntrega As String
    Private _dDataEntrega As Date
    Private _alocado As String
    Private _fatorConversao As String
    Private _qtdRecebidaCliente As String
    Private _qtdPesadaEmpresa As String
    Private _lote As String
    Private _fatConverUL As String
    Private _precoUnitarioBaseUL As String
    Private _qtdRecebidaClienteUL As String
    Private _qtdCondenacao As String
    Private _qtdCondenacaoUL As String
    Private _embarqueConferido As String

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

    Public Property seqProgramacao() As String
        Get
            Return _seqProgramacao
        End Get
        Set(ByVal value As String)
            _seqProgramacao = value
        End Set
    End Property

    Public Property qtdUD() As String
        Get
            Return _qtdUD
        End Get
        Set(ByVal value As String)
            _qtdUD = value
        End Set
    End Property

    Public Property qtdPedida() As String
        Get
            Return _qtdPedida
        End Get
        Set(ByVal value As String)
            _qtdPedida = value
        End Set
    End Property

    Public Property qtdAlocada() As String
        Get
            Return _qtdAlocada
        End Get
        Set(ByVal value As String)
            _qtdAlocada = value
        End Set
    End Property

    Public Property qtdEntregue() As String
        Get
            Return _qtdEntregue
        End Get
        Set(ByVal value As String)
            _qtdEntregue = value
        End Set
    End Property
    Public Property dataEntrega() As String
        Get
            Return _dataEntrega
        End Get
        Set(ByVal value As String)
            If value.isValidDate Then
                dDataEntrega = CDate(value)
            End If
            _dataEntrega = value
        End Set
    End Property
    Public Property dDataEntrega() As Date
        Get
            Return _dDataEntrega
        End Get
        Set(ByVal value As Date)
            _dDataEntrega = value
        End Set
    End Property
    Public Property alocado() As String
        Get
            Return _alocado
        End Get
        Set(ByVal value As String)
            _alocado = value
        End Set
    End Property
    Public Property fatorConversao() As String
        Get
            Return _fatorConversao
        End Get
        Set(ByVal value As String)
            _fatorConversao = value
        End Set
    End Property
    Public Property qtdRecebidaCliente() As String
        Get
            Return _qtdRecebidaCliente
        End Get
        Set(ByVal value As String)
            _qtdRecebidaCliente = value
        End Set
    End Property
    Public Property qtdPesadaEmpresa() As String
        Get
            Return _qtdPesadaEmpresa
        End Get
        Set(ByVal value As String)
            _qtdPesadaEmpresa = value
        End Set
    End Property
    Public Property lote() As String
        Get
            Return _lote
        End Get
        Set(ByVal value As String)
            _lote = value
        End Set
    End Property
    Public Property fatConverUL() As String
        Get
            Return _fatConverUL
        End Get
        Set(ByVal value As String)
            _fatConverUL = value
        End Set
    End Property
    Public Property precoUnitarioBaseUL() As String
        Get
            Return _precoUnitarioBaseUL
        End Get
        Set(ByVal value As String)
            _precoUnitarioBaseUL = value
        End Set
    End Property
    Public Property qtdRecebidaClienteUL() As String
        Get
            Return _qtdRecebidaClienteUL
        End Get
        Set(ByVal value As String)
            _qtdRecebidaClienteUL = value
        End Set
    End Property
    Public Property qtdCondenacao() As String
        Get
            Return _qtdCondenacao
        End Get
        Set(ByVal value As String)
            _qtdCondenacao = value
        End Set
    End Property
    Public Property qtdCondenacaoUL() As String
        Get
            Return _qtdCondenacaoUL
        End Get
        Set(ByVal value As String)
            _qtdCondenacaoUL = value
        End Set
    End Property
    Public Property embarqueConferido() As String
        Get
            Return _embarqueConferido
        End Get
        Set(ByVal value As String)
            _embarqueConferido = value
        End Set
    End Property

    Public Sub New(ByVal StrConn As String)
        ObjAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable

            StrSql += " select * "
            StrSql += "   from pedido_venda_item_programacao "
            StrSql += "  where empresa          = " + Empresa
            StrSql += "    and estabelecimento  = " + Estabelecimento
            StrSql += "    and cod_pedido_venda = " + CodPedidoVenda
            StrSql += "    and seq_item         = " + SeqItem
            StrSql += "    and seq_programacao  = " + seqProgramacao

            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                qtdUD = dt.Rows.Item(0).Item("qtd_ud").ToString
                qtdPedida = dt.Rows.Item(0).Item("qtd_pedida").ToString
                qtdAlocada = dt.Rows.Item(0).Item("qtd_alocada").ToString
                qtdEntregue = dt.Rows.Item(0).Item("qtd_entregue").ToString
                If IsDBNull(dt.Rows.Item(0).Item("data_entrega")) Then
                    dataEntrega = ""
                Else
                    dataEntrega = CDate(dt.Rows.Item(0).Item("data_entrega")).ToString("dd/MM/yyyy")
                End If
                alocado = dt.Rows.Item(0).Item("alocado").ToString
                fatorConversao = dt.Rows.Item(0).Item("fator_conversao").ToString
                qtdRecebidaCliente = dt.Rows.Item(0).Item("qtd_recebida_cliente").ToString
                qtdPesadaEmpresa = dt.Rows.Item(0).Item("qtd_pesada_empresa").ToString
                lote = dt.Rows.Item(0).Item("lote").ToString
                fatConverUL = dt.Rows.Item(0).Item("fat_conver_ul").ToString
                precoUnitarioBaseUL = dt.Rows.Item(0).Item("preco_unitario_base_ul").ToString
                qtdRecebidaClienteUL = dt.Rows.Item(0).Item("qtd_recebida_cliente_ul").ToString
                qtdCondenacao = dt.Rows.Item(0).Item("qtd_condenacao").ToString
                qtdCondenacaoUL = dt.Rows.Item(0).Item("qtd_condenacao_ul").ToString
                embarqueConferido = dt.Rows.Item(0).Item("embarque_conferido").ToString
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
            Dim StrSql As String = ""

            qtdUD = IIf(String.IsNullOrEmpty(qtdUD), "null", qtdUD)
            qtdPedida = IIf(String.IsNullOrEmpty(qtdPedida), "null", qtdPedida)
            qtdAlocada = IIf(String.IsNullOrEmpty(qtdAlocada), "null", qtdAlocada)
            qtdEntregue = IIf(String.IsNullOrEmpty(qtdEntregue), "null", qtdEntregue)
            fatorConversao = IIf(String.IsNullOrEmpty(fatorConversao), "null", fatorConversao)
            qtdRecebidaCliente = IIf(String.IsNullOrEmpty(qtdRecebidaCliente), "null", qtdRecebidaCliente)
            qtdPesadaEmpresa = IIf(String.IsNullOrEmpty(qtdPesadaEmpresa), "null", qtdPesadaEmpresa)
            fatConverUL = IIf(String.IsNullOrEmpty(fatConverUL), "null", fatConverUL)
            precoUnitarioBaseUL = IIf(String.IsNullOrEmpty(precoUnitarioBaseUL), "null", precoUnitarioBaseUL)
            qtdRecebidaClienteUL = IIf(String.IsNullOrEmpty(qtdRecebidaClienteUL), "null", qtdRecebidaClienteUL)
            qtdCondenacao = IIf(String.IsNullOrEmpty(qtdCondenacao), "null", qtdCondenacao)
            qtdCondenacaoUL = IIf(String.IsNullOrEmpty(qtdCondenacaoUL), "null", qtdCondenacaoUL)
            embarqueConferido = "N"

            qtdAlocada = 0
            qtdEntregue = 0

            StrSql += " call sp_sysvar(); "
            StrSql += " insert into pedido_venda_item_programacao ( "
            StrSql += "    empresa, "
            StrSql += "    estabelecimento, "
            StrSql += "    cod_pedido_venda, "
            StrSql += "    seq_item, "
            StrSql += "    seq_programacao, "
            StrSql += "    qtd_ud, "
            StrSql += "    qtd_pedida, "
            StrSql += "    qtd_alocada, "
            StrSql += "    qtd_entregue, "
            StrSql += "    data_entrega, "
            StrSql += "    alocado, "
            StrSql += "    fator_conversao, "
            StrSql += "    qtd_recebida_cliente, "
            StrSql += "    qtd_pesada_empresa, "
            StrSql += "    lote, "
            StrSql += "    fat_conver_ul, "
            StrSql += "    preco_unitario_base_ul, "
            StrSql += "    qtd_recebida_cliente_ul, "
            StrSql += "    qtd_condenacao, "
            StrSql += "    qtd_condenacao_ul, "
            StrSql += "    embarque_conferido ) "
            StrSql += " values ( "
            StrSql += Empresa + ", "
            StrSql += Estabelecimento + ", "
            StrSql += CodPedidoVenda + ", "
            StrSql += SeqItem + ", "
            StrSql += seqProgramacao + ", "
            StrSql += qtdUD.Replace(",", ".") + ", "
            StrSql += qtdPedida.Replace(",", ".") + ", "
            StrSql += qtdAlocada.Replace(",", ".") + ", "
            StrSql += qtdEntregue.Replace(",", ".") + ", "
            StrSql += IIf(dDataEntrega = Nothing, "getdate()", "'" + dDataEntrega.ToString("yyyy-MM-dd") + "'") + ", "
            StrSql += "'" + alocado + "', "
            StrSql += fatorConversao.Replace(",", ".") + ", "
            StrSql += qtdRecebidaCliente.Replace(",", ".") + ", "
            StrSql += qtdPesadaEmpresa.Replace(",", ".") + ", "
            StrSql += "'" + lote + "',"
            StrSql += fatConverUL.Replace(",", ".") + ", "
            StrSql += precoUnitarioBaseUL.Replace(",", ".") + ", "
            StrSql += qtdRecebidaClienteUL.Replace(",", ".") + ", "
            StrSql += qtdCondenacao.Replace(",", ".") + ", "
            StrSql += qtdCondenacaoUL.Replace(",", ".") + ", "
            StrSql += "'" + embarqueConferido + "')"

            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim StrSql As String = ""

            qtdUD = IIf(String.IsNullOrEmpty(qtdUD), "0", qtdUD)
            qtdPedida = IIf(String.IsNullOrEmpty(qtdPedida), "0", qtdPedida)
            qtdAlocada = IIf(String.IsNullOrEmpty(qtdAlocada), "0", qtdAlocada)
            qtdEntregue = IIf(String.IsNullOrEmpty(qtdEntregue), "0", qtdEntregue)
            fatorConversao = IIf(String.IsNullOrEmpty(fatorConversao), "null", fatorConversao)
            qtdRecebidaCliente = IIf(String.IsNullOrEmpty(qtdRecebidaCliente), "null", qtdRecebidaCliente)
            qtdPesadaEmpresa = IIf(String.IsNullOrEmpty(qtdPesadaEmpresa), "null", qtdPesadaEmpresa)
            fatConverUL = IIf(String.IsNullOrEmpty(fatConverUL), "null", fatConverUL)
            precoUnitarioBaseUL = IIf(String.IsNullOrEmpty(precoUnitarioBaseUL), "null", precoUnitarioBaseUL)
            qtdRecebidaClienteUL = IIf(String.IsNullOrEmpty(qtdRecebidaClienteUL), "null", qtdRecebidaClienteUL)
            qtdCondenacao = IIf(String.IsNullOrEmpty(qtdCondenacao), "null", qtdCondenacao)
            qtdCondenacaoUL = IIf(String.IsNullOrEmpty(qtdCondenacaoUL), "null", qtdCondenacaoUL)
            embarqueConferido = IIf(String.IsNullOrEmpty(embarqueConferido), "N", embarqueConferido)

            StrSql += " call sp_sysvar(); "
            StrSql += " update pedido_venda_item_programacao "
            StrSql += "    set qtd_ud                  =" + qtdUD.Replace(",", ".") + ", "
            StrSql += "        qtd_pedida              =" + qtdPedida.Replace(",", ".") + ", "
            StrSql += "        qtd_alocada             =" + qtdAlocada.Replace(",", ".") + ", "
            StrSql += "        qtd_entregue            =" + qtdEntregue.Replace(",", ".") + ", "
            StrSql += "        data_entrega            =" + IIf(dDataEntrega = Nothing, "getdate()", "'" + dDataEntrega.ToString("yyyy-MM-dd") + "'") + ", "
            StrSql += "        alocado                 ='" + alocado + "', "
            StrSql += "        fator_conversao         =" + fatorConversao.Replace(",", ".") + ", "
            StrSql += "        qtd_recebida_cliente    =" + qtdRecebidaCliente.Replace(",", ".") + ", "
            StrSql += "        qtd_pesada_empresa      =" + qtdPesadaEmpresa.Replace(",", ".") + ", "
            StrSql += "        lote                    ='" + lote + "',"
            StrSql += "        fat_conver_ul           =" + fatConverUL.Replace(",", ".") + ", "
            StrSql += "        preco_unitario_base_ul  =" + precoUnitarioBaseUL.Replace(",", ".") + ", "
            StrSql += "        qtd_recebida_cliente_ul =" + qtdRecebidaClienteUL.Replace(",", ".") + ", "
            StrSql += "        qtd_condenacao          =" + qtdCondenacao.Replace(",", ".") + ", "
            StrSql += "        qtd_condenacao_ul       =" + qtdCondenacaoUL.Replace(",", ".") + ", "
            StrSql += "        embarque_conferido      ='" + embarqueConferido + "'"
            StrSql += "  where empresa           = " + Empresa
            StrSql += "    and estabelecimento   = " + Estabelecimento
            StrSql += "    and cod_pedido_venda  = " + CodPedidoVenda
            StrSql += "    and seq_item          = " + SeqItem
            StrSql += "    and seq_programacao   = " + seqProgramacao

            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String
            StrSql = "   delete from pedido_venda_item_programacao "
            StrSql += "   where empresa          = " + Empresa
            StrSql += "     and estabelecimento  = " + Estabelecimento
            StrSql += "     and cod_pedido_venda = " + CodPedidoVenda
            If Not String.IsNullOrEmpty(SeqItem) Then
                StrSql += "     and seq_item         = " + SeqItem
            End If
            If Not String.IsNullOrEmpty(seqProgramacao) Then
                StrSql += " and seq_programacao  = " + seqProgramacao
            End If

            ObjAcessoDados.ExecutarSql("call sp_sysvar();" + StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(seq_programacao),0) + 1 max from pedido_venda_item_programacao where empresa = " + empresa + " and estabelecimento = " + estabelecimento + " and cod_pedido_venda = " + codPedidoVenda + " and seq_item = " + seqItem
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
