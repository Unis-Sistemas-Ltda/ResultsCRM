Public Class UCLSolicitacaoTecnico

    Private ObjAcessoDados As UCLAcessoDados

    Public Property empresa As String
    Public Property estabelecimento As String
    Public Property cod_solicitacao As String
    Public Property cod_solicitante As String
    Public Property cod_agente_tecnico As String
    Public Property cod_item As String
    Public Property quantidade As String
    Public Property prioridade As String
    Public Property forma_entrega As String
    Public Property situacao As String
    Public Property cod_pedido_venda As String
    Public Property ddata_solicitacao As Date
    Public Property ddata_entrega As Date
    Public Property HoraSolicitacao As String
    Public Property HoraEntrega As String

    Private _data_solicitacao As String
    Private _data_entrega As String

    Public Property data_entrega As String
        Get
            Return _data_entrega
        End Get
        Set(value As String)
            If isValidDate(value) Then
                ddata_entrega = CDate(value)
            End If
            _data_entrega = value
        End Set
    End Property

    Public Property data_solicitacao As String
        Get
            Return _data_solicitacao
        End Get
        Set(value As String)
            If isValidDate(value) Then
                ddata_solicitacao = CDate(value)
            End If
            _data_solicitacao = value
        End Set
    End Property

    Public Sub New(ByVal StrConn As String)
        ObjAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodSolicitacao As String) As Boolean
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable

            StrSql += " select cod_solicitante, cod_agente_tecnico, cod_item, quantidade, data_solicitacao, data_entrega, prioridade, forma_entrega, situacao, cod_pedido_venda"
            StrSql += "   from solicitacao_tecnico"
            StrSql += "  where empresa         = " + pEmpresa
            StrSql += "    and estabelecimento = " + pEstabelecimento
            StrSql += "    and cod_solicitacao = " + pCodSolicitacao

            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                cod_solicitante = dt.Rows.Item(0).Item("cod_solicitante").ToString
                cod_agente_tecnico = dt.Rows.Item(0).Item("cod_agente_tecnico").ToString
                cod_item = dt.Rows.Item(0).Item("cod_item").ToString
                quantidade = dt.Rows.Item(0).Item("quantidade").ToString
                If IsDBNull(data_solicitacao) Then
                    data_solicitacao = ""
                    HoraSolicitacao = ""
                Else
                    data_solicitacao = CDate(dt.Rows.Item(0).Item("data_solicitacao")).ToString("dd/MM/yyyy")
                    HoraSolicitacao = CDate(dt.Rows.Item(0).Item("data_solicitacao")).ToString("HH:mm").Substring(0, 5)
                End If
                If IsDBNull(data_entrega) Then
                    data_entrega = ""
                    HoraEntrega = ""
                Else
                    data_entrega = CDate(dt.Rows.Item(0).Item("data_entrega")).ToString("dd/MM/yyyy")
                    HoraEntrega = CDate(dt.Rows.Item(0).Item("data_entrega")).ToString("HH:mm").Substring(0, 5)
                End If
                prioridade = dt.Rows.Item(0).Item("prioridade").ToString
                forma_entrega = dt.Rows.Item(0).Item("forma_entrega").ToString
                situacao = dt.Rows.Item(0).Item("situacao").ToString
                cod_pedido_venda = dt.Rows.Item(0).Item("cod_pedido_venda").ToString
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

            StrSql += " insert into solicitacao_tecnico ( "
            StrSql += "    empresa, estabelecimento, cod_solicitacao, cod_solicitante, cod_agente_tecnico, "
            StrSql += "    cod_item, quantidade, data_solicitacao, data_entrega, prioridade, forma_entrega, "
            StrSql += "    situacao, cod_pedido_venda ) "
            StrSql += " values ( " + empresa + ", " + estabelecimento + ", " + cod_solicitacao + ", " + cod_solicitante + ", " + cod_agente_tecnico + ", "
            StrSql += "    '" + cod_item + "', " + quantidade.Replace(",", ".") + ", '" + ddata_solicitacao.ToString("yyyy-MM-dd") + " " + HoraSolicitacao + "', '" + ddata_entrega.ToString("yyyy-MM-dd") + " " + HoraEntrega + "', '" + prioridade + "', '" + forma_entrega + "', "
            StrSql += "    " + IIf(String.IsNullOrWhiteSpace(situacao), "null", "'" + situacao + "'") + ", " + IIf(String.IsNullOrWhiteSpace(cod_pedido_venda), "null", cod_pedido_venda) + ") "

            ObjAcessoDados.ExecutarSql(StrSql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim StrSql As String = ""

            StrSql += " update solicitacao_tecnico "
            StrSql += "    set cod_solicitante    = " + cod_solicitante + ", "
            StrSql += "        cod_agente_tecnico = " + cod_agente_tecnico + ", "
            StrSql += "        cod_item           = '" + cod_item + "', "
            StrSql += "        quantidade         = " + quantidade.Replace(",", ".") + ", "
            StrSql += "        data_solicitacao   = '" + ddata_solicitacao.ToString("yyyy-MM-dd") + " " + HoraSolicitacao + "', "
            StrSql += "        data_entrega       = '" + ddata_entrega.ToString("yyyy-MM-dd") + " " + HoraEntrega + "',  "
            StrSql += "        prioridade         = '" + prioridade + "', "
            StrSql += "        forma_entrega      = '" + forma_entrega + "', "
            StrSql += "        situacao           = " + IIf(String.IsNullOrWhiteSpace(situacao), "null", "'" + situacao + "'") + ", "
            StrSql += "        cod_pedido_venda   = " + IIf(String.IsNullOrWhiteSpace(cod_pedido_venda), "null", cod_pedido_venda)
            StrSql += "  where empresa         = " + empresa
            StrSql += "    and estabelecimento = " + estabelecimento
            StrSql += "    and cod_solicitacao = " + cod_solicitacao

            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodSolicitacao As String)
        Try
            Dim StrSql As String = ""

            StrSql += " delete from solicitacao_tecnico "
            StrSql += "  where empresa         = " + pEmpresa
            StrSql += "    and estabelecimento = " + pEstabelecimento
            StrSql += "    and cod_solicitacao = " + pCodSolicitacao

            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_solicitacao),0) + 1 max from solicitacao_tecnico where empresa = " + empresa
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
