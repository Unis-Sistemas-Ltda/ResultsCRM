Public Class UCLPedidoVendaSolicitacao

    Private ObjAcessoDados As UCLAcessoDados

    Private _empresa As String
    Private _estabelecimento As String
    Private _codPedidoVenda As String
    Private _seqSolicitacao As String
    Private _numeroSerie As String
    Private _servicoSolicitado As String
    Private _codCausa As String

    Public Sub New(ByVal StrConn As String)
        ObjAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

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
    Public Property SeqSolicitacao() As String
        Get
            Return _seqSolicitacao
        End Get
        Set(ByVal value As String)
            _seqSolicitacao = value
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
    Public Property ServicoSolicitado() As String
        Get
            Return _servicoSolicitado
        End Get
        Set(ByVal value As String)
            _servicoSolicitado = value
        End Set
    End Property
    Public Property CodCausa As String
        Get
            Return _codCausa
        End Get
        Set(value As String)
            _codCausa = value
        End Set
    End Property

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable

            StrSql += " select * "
            StrSql += "   from pedido_venda_solicitacao "
            StrSql += "  where empresa          = " + empresa
            StrSql += "    and estabelecimento  = " + estabelecimento
            StrSql += "    and cod_pedido_venda = " + CodPedidoVenda
            StrSql += "    and seq_solicitacao  = " + SeqSolicitacao

            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                NumeroSerie = dt.Rows.Item(0).Item("numero_serie").ToString
                ServicoSolicitado = dt.Rows.Item(0).Item("servico_solicitado").ToString
                CodCausa = dt.Rows.Item(0).Item("cod_causa").ToString
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
            Dim strSql As String = ""

            strSql += "call sp_sysvar(); "
            strSql += "insert into pedido_venda_solicitacao ("
            strSql += " empresa, "
            strSql += " estabelecimento, "
            strSql += " cod_pedido_venda, "
            strSql += " seq_solicitacao, "
            strSql += " numero_serie, "
            strSql += " cod_causa, "
            strSql += " servico_solicitado) "
            strSql += "values ("
            strSql += empresa + ", "
            strSql += estabelecimento + ", "
            strSql += codPedidoVenda + ", "
            strSql += SeqSolicitacao + ", "
            strSql += IIf(String.IsNullOrWhiteSpace(NumeroSerie), "null,", "'" + NumeroSerie + "', ")
            strSql += IIf(String.IsNullOrWhiteSpace(CodCausa), "null", CodCausa) + ", "
            strSql += "'" + ServicoSolicitado + "') "
            ObjAcessoDados.ExecutarSql(strSql)

            Call VincularEquipamentoAoContratoDoChamado()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim strSql As String = ""
            strSql += "call sp_sysvar(); "
            strSql += "update pedido_venda_solicitacao "
            strSql += "   set numero_serie                     = " + IIf(String.IsNullOrWhiteSpace(NumeroSerie), "null,", "'" + NumeroSerie + "', ")
            strSql += "       cod_causa                        = " + IIf(String.IsNullOrWhiteSpace(CodCausa), "null", CodCausa) + ", "
            strSql += "       servico_solicitado               = '" + ServicoSolicitado + "' "
            strSql += " where empresa           = " + Empresa
            strSql += "   and estabelecimento   = " + Estabelecimento
            strSql += "   and cod_pedido_venda  = " + CodPedidoVenda
            strSql += "   and seq_solicitacao   = " + SeqSolicitacao
            ObjAcessoDados.ExecutarSql(strSql)

            Call VincularEquipamentoAoContratoDoChamado()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim strSql As String = ""
            strSql += "  call sp_sysvar(); "
            strSql += "  delete from pedido_venda_solicitacao "
            strSql += "   where empresa           = " + Empresa
            strSql += "     and estabelecimento   = " + Estabelecimento
            strSql += "     and cod_pedido_venda  = " + CodPedidoVenda
            If Not String.IsNullOrEmpty(SeqSolicitacao) Then
                strSql += " and seq_solicitacao   = " + SeqSolicitacao
            End If

            ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(seq_solicitacao),0) + 1 max from pedido_venda_solicitacao where empresa = " + Empresa + " and estabelecimento = " + Estabelecimento + " and cod_pedido_venda = " + CodPedidoVenda
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += "select ps.seq_solicitacao seq, right('00' || ps.seq_solicitacao,2) || ' | ' || ec.cod_item  || ' - ' || left(trim(ps.servico_solicitado),42) descricao"
        strSql += "  from pedido_venda_solicitacao ps inner join equipamento ec on ec.empresa = ps.empresa and ec.numero_serie = ps.numero_serie"
        strSql += " where ps.empresa          = " + Empresa
        strSql += "   and ps.estabelecimento  = " + Estabelecimento
        strSql += "   and ps.cod_pedido_venda = " + CodPedidoVenda
        strSql += " order by ps.seq_solicitacao"
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim nr As DataRow = dt.NewRow
            nr.Item("seq") = 0
            nr.Item("descricao") = " "
            dt.Rows.InsertAt(nr, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "seq"
        DDL.DataBind()
    End Sub

    Public Sub VincularEquipamentoAoContratoDoChamado()
        Try
            Dim StrSql As String = ""

            StrSql += " insert into contrato_manutencao_equipamento( empresa, contrato, numero_serie, dia_manutencao, tipo_frequencia_manutencao )"
            StrSql += "  select c.empresa, c.contrato, pvs.numero_serie, cm.dia_manutencao, cm.tipo_frequencia_manutencao "
            StrSql += "    from chamado c inner join pedido_venda pv on c.empresa = pv.empresa and c.cod_chamado = pv.cod_chamado "
            StrSql += "                   inner join pedido_venda_solicitacao pvs on pvs.empresa = pv.empresa and pvs.estabelecimento = pv.estabelecimento and pvs.cod_pedido_venda = pv.cod_pedido_venda "
            StrSql += "                   inner join contrato_manutencao cm on cm.empresa = c.empresa and cm.contrato = c.contrato "
            StrSql += "   where pvs.empresa          = " + Empresa
            StrSql += "     and pvs.estabelecimento  = " + Estabelecimento
            StrSql += "     and pvs.cod_pedido_venda = " + CodPedidoVenda
            StrSql += "     and pvs.seq_solicitacao  = " + SeqSolicitacao
            StrSql += "     and cm.contrato is not null "
            StrSql += "     and pvs.numero_serie is not null"
            StrSql += "     and not exists(select 1 from contrato_manutencao_equipamento where empresa = c.empresa and contrato = c.contrato and numero_serie = pvs.numero_serie) "

            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class