Public Class UCLNegociacaoItemFormula

    Private _Empresa As String
    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Private _Estabelecimento As String
    Public Property Estabelecimento() As String
        Get
            Return _Estabelecimento
        End Get
        Set(ByVal value As String)
            _Estabelecimento = value
        End Set
    End Property

    Private _CodNegociacao As String
    Public Property CodNegociacao() As String
        Get
            Return _CodNegociacao
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property

    Private _SeqItem As String
    Public Property SeqItem() As String
        Get
            Return _SeqItem
        End Get
        Set(ByVal value As String)
            _SeqItem = value
        End Set
    End Property

    Private _SeqFormula As String
    Public Property SeqFormula() As String
        Get
            Return _SeqFormula
        End Get
        Set(ByVal value As String)
            _SeqFormula = value
        End Set
    End Property

    Private _DescricaoComponente As String
    Public Property DescricaoComponente() As String
        Get
            Return _DescricaoComponente
        End Get
        Set(ByVal value As String)
            _DescricaoComponente = value
        End Set
    End Property

    Private _Percentual As String
    Public Property Percentual() As String
        Get
            Return _Percentual
        End Get
        Set(ByVal value As String)
            _Percentual = value
        End Set
    End Property

    Private _Qsp As String
    Public Property Qsp() As String
        Get
            Return _Qsp
        End Get
        Set(ByVal value As String)
            _Qsp = value
        End Set
    End Property

    Private objAcessoDados As UCLAcessoDados

    Public Sub New(ByVal StrConn As String)
        objAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Function Buscar() As DataTable
        Dim strSql As String = ""
        Dim dt As DataTable

        Try

            strSql += " select empresa,estabelecimento,cod_negociacao_cliente,seq_item,seq_formula,descricao_componente,percentual,qsp "
            strSql += "   from negociacao_cliente_item_formula "
            strSql += "  where empresa = " + Empresa
            strSql += "    and estabelecimento = " + Estabelecimento
            strSql += "    and cod_negociacao_cliente = " + CodNegociacao
            strSql += "    and seq_item = " + SeqItem
            strSql += "    and seq_formula = " + SeqFormula
            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                'descricao_componente, Percentual, Qsp
                DescricaoComponente = dt.Rows.Item(0).Item("descricao_componente").ToString
                Percentual = dt.Rows.Item(0).Item("percentual").ToString
                Qsp = dt.Rows.Item(0).Item("qsp").ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return dt
    End Function

    Public Sub Excluir()
        Dim strSql As String = ""

        Try
            strSql += " delete from negociacao_cliente_item_formula "
            strSql += "  where empresa = " + Empresa
            strSql += "    and estabelecimento = " + Estabelecimento
            strSql += "    and cod_negociacao_cliente = " + CodNegociacao
            strSql += "    and seq_item = " + SeqItem
            strSql += "    and seq_formula = " + SeqFormula
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            If String.IsNullOrEmpty(DescricaoComponente) Then
                DescricaoComponente = ""
            End If
            If String.IsNullOrWhiteSpace(Percentual) Then
                DescricaoComponente = "null"
            End If
            If String.IsNullOrWhiteSpace(Qsp) Then
                Qsp = "N"
            End If

            '-----------------


            strSql += " update negociacao_cliente_item_formula "
            strSql += "    set descricao_componente = '" + DescricaoComponente + "', "
            strSql += "        percentual = " + Percentual.Replace(",", ".") + ", "
            strSql += "        qsp = '" + Qsp + "'"
            strSql += "  where empresa = " + Empresa
            strSql += "    and estabelecimento = " + Estabelecimento
            strSql += "    and cod_negociacao_cliente = " + CodNegociacao
            strSql += "    and seq_item = " + SeqItem
            strSql += "    and seq_formula = " + SeqFormula
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            If String.IsNullOrEmpty(DescricaoComponente) Then
                DescricaoComponente = ""
            End If
            If String.IsNullOrWhiteSpace(Percentual) Then
                DescricaoComponente = "null"
            End If
            If String.IsNullOrWhiteSpace(Qsp) Then
                Qsp = "N"
            End If

            '----------

            strSql += " insert into negociacao_cliente_item_formula(empresa,estabelecimento,cod_negociacao_cliente,seq_item,seq_formula,descricao_componente,percentual,qsp) "
            strSql += " values (" + Empresa + ", " + Estabelecimento + ", " + CodNegociacao + ", " + SeqItem + ", " + SeqFormula + ", '" + DescricaoComponente + "', " + Percentual + ", '" + Qsp + "')"

            objAcessoDados.ExecutarSql(strSql)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(seq_formula),0) + 1 max from negociacao_cliente_item_formula where empresa = " + Empresa + " and estabelecimento = " + Estabelecimento + " and cod_negociacao_cliente = " + CodNegociacao + " and seq_item = " + SeqItem
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Function GetPercentualQsp() As Double
        Dim ret As Double = 100
        Dim strSql = " select isnull(sum(percentual),0) sum from negociacao_cliente_item_formula where empresa = " + Empresa + " and estabelecimento = " + Estabelecimento + " and cod_negociacao_cliente = " + CodNegociacao + " and seq_item = " + SeqItem
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = 100 - dt.Rows.Item(0).Item("sum")
        End If
        Return ret
    End Function

    Public Sub Gravar()
        Try
            If SeqItem = 0 Then
                SeqFormula = GetProximoCodigo()
                Incluir()
            Else
                Alterar()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
