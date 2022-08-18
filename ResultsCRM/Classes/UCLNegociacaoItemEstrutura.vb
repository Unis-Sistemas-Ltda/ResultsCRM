Public Class UCLNegociacaoItemEstrutura

    Private ObjAcessoDados As UCLAcessoDados
    Public Property Empresa As String
    Public Property Estabelecimento As String
    Public Property CodNegociacaoCliente As String
    Public Property SeqItem As String
    Public Property SeqItemEstrutura As String
    Public Property CodItem As String
    Public Property SeqEstrutura As String
    Public Property CodComponenteAlternativo As String
    Public Property ReferenciaComponenteAlternativo As String
    Public Property Quantidade As String
    Public Property Largura As String
    Public Property AbaEsquerda As String
    Public Property AbaDireita As String
    Public Property QuantidadeTotal As String
    Public Property PrecoUnitario As String
    Public Property PrecoTotal As String
    Public Property ValorFixo As String
    Public Property TipoValor As String
    Public Property TipoSoma As String

    Public Function CarregaCamposEstruturaCompAlternativos(ByVal pCodItem As String, ByVal pSeqEstrutura As String, ByVal pCodComponenteAlternativo As String, ByRef rValorFixo As Long, ByRef rTipoValor As Long, ByRef rTipoSoma As Long) As Boolean
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable
            StrSql += " select isnull(valor_fixo,0) valor_fixo, isnull(tipo_valor,0) tipo_valor, isnull(tipo_soma,0) tipo_soma"
            StrSql += "   from estrutura_comp_alternativos"
            StrSql += "  where cod_item = '" + pCodItem + "'"
            StrSql += "    and seq_estrutura = " + pSeqEstrutura
            StrSql += "    and cod_componente_alternativo = '" + pCodComponenteAlternativo + "'"

            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                rValorFixo = CInt(dt.Rows.Item(0).Item("valor_fixo")).ToString("F0")
                rTipoSoma = CInt(dt.Rows.Item(0).Item("tipo_valor")).ToString("F0")
                rTipoValor = CInt(dt.Rows.Item(0).Item("tipo_soma")).ToString("F0")
                Return True
            Else
                rValorFixo = 0
                rTipoSoma = 0
                rTipoValor = 0
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetPrecoUnitario(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacao As String, ByVal pCodComponenteAlternativo As String) As Double
        Try
            Dim StrSql As String
            Dim dt As DataTable
            Dim ObjNegociacaoCliente As New UCLNegociacao(StrConexao)

            ObjNegociacaoCliente.Empresa = pEmpresa
            ObjNegociacaoCliente.Estabelecimento = pEstabelecimento
            ObjNegociacaoCliente.CodNegociacao = pCodNegociacao
            ObjNegociacaoCliente.Buscar()

            If String.IsNullOrWhiteSpace(ObjNegociacaoCliente.CodCliente) Then
                ObjNegociacaoCliente.CodCliente = 0
            End If

            StrSql = "select f_busca_preco_item_cliente(" + pEmpresa + ", " + pEstabelecimento + ", " + ObjNegociacaoCliente.CodCliente + ", '" + ObjNegociacaoCliente.CNPJ + "', '" + pCodComponenteAlternativo + "', null, null, null, null, null) valor from dummy"
            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows.Item(0).Item("valor")) Then
                    Return CDbl(dt.Rows.Item(0).Item("valor"))
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub New(ByVal strConn As String)
        ObjAcessoDados = New UCLAcessoDados(strConn)
    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""
        Try
            strSql += " insert into negociacao_cliente_item_estrutura (empresa, estabelecimento, cod_negociacao_cliente, seq_item, seq_item_estrutura, cod_item, seq_estrutura, cod_componente_alternativo, referencia_componente_alternativo, quantidade, quantidade_total, preco_unitario, preco_total, valor_fixo, tipo_valor, tipo_soma, largura, aba_direita, aba_esquerda) "
            strSql += " values (" + Empresa.EmptyStringIsNull + ", " + Estabelecimento.EmptyStringIsNull + ", " + CodNegociacaoCliente.EmptyStringIsNull + ", " + SeqItem.EmptyStringIsNull + ", " + SeqItemEstrutura.EmptyStringIsNull + ", '" + CodItem + "', " + SeqEstrutura.EmptyStringIsNull + ", '" + CodComponenteAlternativo + "', '" + ReferenciaComponenteAlternativo + "', " + Quantidade.Replace(".", "").Replace(",", ".").EmptyStringIsNull + ", " + QuantidadeTotal.Replace(".", "").Replace(",", ".").EmptyStringIsNull + ", " + PrecoUnitario.Replace(".", "").Replace(",", ".").EmptyStringIsNull + ", " + PrecoTotal.Replace(".", "").Replace(",", ".").EmptyStringIsNull + ", " + ValorFixo.EmptyStringIsNull + ", " + TipoValor.EmptyStringIsNull + ", " + TipoSoma.EmptyStringIsNull + ", " + Largura.EmptyStringIsNull + ", " + AbaDireita.EmptyStringIsNull + ", " + AbaEsquerda.EmptyStringIsNull + ")"
            ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try
            strSql += " update negociacao_cliente_item_estrutura "
            strSql += "    set cod_item                          = '" + CodItem + "', "
            strSql += "        seq_estrutura                     = " + SeqEstrutura.EmptyStringIsNull + ", "
            strSql += "        cod_componente_alternativo        = '" + CodComponenteAlternativo + "', "
            strSql += "        referencia_componente_alternativo = '" + ReferenciaComponenteAlternativo + "', "
            strSql += "        quantidade                        = " + Quantidade.Replace(".", "").Replace(",", ".").EmptyStringIsNull + ", "
            strSql += "        quantidade_total                  = " + QuantidadeTotal.Replace(".", "").Replace(",", ".").EmptyStringIsNull + ", "
            strSql += "        preco_unitario                    = " + PrecoUnitario.Replace(".", "").Replace(",", ".").EmptyStringIsNull + ", "
            strSql += "        preco_total                       = " + PrecoTotal.Replace(".", "").Replace(",", ".").EmptyStringIsNull + ", "
            strSql += "        valor_fixo                        = " + ValorFixo.EmptyStringIsNull + ", " + TipoValor.EmptyStringIsNull + ", "
            strSql += "        tipo_valor                        = " + TipoValor.EmptyStringIsNull + ", "
            strSql += "        tipo_soma                         = " + TipoSoma.EmptyStringIsNull + ", "
            strSql += "        largura                           = " + Largura.EmptyStringIsNull + ", "
            strSql += "        aba_direita                       = " + AbaDireita.EmptyStringIsNull + ", "
            strSql += "        aba_esquerda                      = " + AbaEsquerda.EmptyStringIsNull
            strSql += "  where empresa                = " + Empresa.EmptyStringIsNull
            strSql += "    and estabelecimento        = " + Estabelecimento.EmptyStringIsNull
            strSql += "    and cod_negociacao_cliente = " + CodNegociacaoCliente.EmptyStringIsNull
            strSql += "    and seq_item               = " + SeqItem.EmptyStringIsNull
            strSql += "    and seq_item_estrutura     = " + SeqItemEstrutura.EmptyStringIsNull
            ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Dim strSql As String = ""
        Try
            strSql += " delete from negociacao_cliente_item_estrutura "
            strSql += "  where empresa                = " + Empresa.EmptyStringIsNull
            strSql += "    and estabelecimento        = " + Estabelecimento.EmptyStringIsNull
            strSql += "    and cod_negociacao_cliente = " + CodNegociacaoCliente.EmptyStringIsNull
            strSql += "    and seq_item               = " + SeqItem.EmptyStringIsNull
            strSql += "    and seq_item_estrutura     = " + SeqItemEstrutura.EmptyStringIsNull
            ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select * "
        StrSql += "   from negociacao_cliente_item_estrutura "
        StrSql += "  where empresa                = " + Empresa.EmptyStringIsNull
        StrSql += "    and estabelecimento        = " + Estabelecimento.EmptyStringIsNull
        StrSql += "    and cod_negociacao_cliente = " + CodNegociacaoCliente.EmptyStringIsNull
        StrSql += "    and seq_item               = " + SeqItem.EmptyStringIsNull
        StrSql += "    and seq_item_estrutura     = " + SeqItemEstrutura.EmptyStringIsNull
        dt = ObjAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            CodItem = dt.Rows.Item(0).Item("cod_item").ToString
            SeqEstrutura = dt.Rows.Item(0).Item("seq_estrutura").ToString
            CodComponenteAlternativo = dt.Rows.Item(0).Item("cod_componente_alternativo").ToString
            ReferenciaComponenteAlternativo = dt.Rows.Item(0).Item("referencia_componente_alternativo").ToString
            Quantidade = dt.Rows.Item(0).Item("quantidade").ToString
            QuantidadeTotal = dt.Rows.Item(0).Item("quantidade_total").ToString
            PrecoUnitario = dt.Rows.Item(0).Item("preco_unitario").ToString
            PrecoTotal = dt.Rows.Item(0).Item("preco_total").ToString
            ValorFixo = dt.Rows.Item(0).Item("valor_fixo").ToString
            TipoValor = dt.Rows.Item(0).Item("tipo_valor").ToString
            TipoSoma = dt.Rows.Item(0).Item("tipo_soma").ToString
            Largura = dt.Rows.Item(0).Item("largura").ToString
            AbaDireita = dt.Rows.Item(0).Item("aba_direita").ToString
            AbaEsquerda = dt.Rows.Item(0).Item("aba_esquerda").ToString

            Return True
        Else
            Return False
        End If

    End Function

    Public Function PermiteMultiplo(ByVal CodItem As String, ByVal SeqEstrutura As String) As Boolean
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable

            StrSql += "select isnull(permite_multiplo,'N') mult"
            StrSql += "  from estrutura"
            StrSql += " where cod_item      = '" + CodItem + "'"
            StrSql += "  and seq_estrutura  = " + SeqEstrutura
            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count = 0 Then
                Return False
            Else
                If dt.Rows.Item(0).Item("mult").ToString = "S" Then
                    Return True
                Else
                    Return False
                End If
            End If

            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetSeqItemEstrutura(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacao As String, ByVal pSeqItem As String, ByVal pSeqEstrutura As String, ByVal pCodComponenteAlternativo As String, ByVal pReferenciaComponenteAlternativo As String) As Long
        Try
            Dim ret As Long = 0
            Dim strSql = ""
            Dim dt As DataTable
            strSql += " select isnull(seq_item_estrutura,0) seq "
            strSql += "   from negociacao_cliente_item_estrutura "
            strSql += "  where empresa                           = " + pEmpresa.EmptyStringIsNull
            strSql += "    and estabelecimento                   = " + pEstabelecimento.EmptyStringIsNull
            strSql += "    and cod_negociacao_cliente            = " + pCodNegociacao.EmptyStringIsNull
            strSql += "    and seq_item                          = " + pSeqItem.EmptyStringIsNull
            strSql += "    and seq_estrutura                     = " + pSeqEstrutura.EmptyStringIsNull
            strSql += "    and cod_componente_alternativo        = " + pCodComponenteAlternativo.EmptyStringIsNull
            strSql += "    and referencia_componente_alternativo = '" + pReferenciaComponenteAlternativo + "'"
            dt = ObjAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count = 0 Then
                Return 0
            Else
                If Not IsDBNull(dt.Rows.Item(0).Item("seq")) Then
                    Return CLng(dt.Rows.Item(0).Item("seq"))
                Else
                    Return 0
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function QuantidadeItensGrupoConfiguracao() As Long
        Dim ret As Long = 0
        Dim strSql = ""

        strSql += " select count(1) qtd "
        strSql += "   from negociacao_cliente_item_estrutura "
        strSql += "  where empresa                = " + Empresa.EmptyStringIsNull
        strSql += "    and estabelecimento        = " + Estabelecimento.EmptyStringIsNull
        strSql += "    and cod_negociacao_cliente = " + CodNegociacaoCliente.EmptyStringIsNull
        strSql += "    and seq_item               = " + SeqItem.EmptyStringIsNull
        strSql += "    and seq_estrutura          = " + SeqEstrutura.EmptyStringIsNull

        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("qtd").ToString
        End If
        Return ret
    End Function

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = ""

        strSql += " select isnull(max(seq_item_estrutura),0) + 1 max "
        strSql += "   from negociacao_cliente_item_estrutura "
        strSql += "  where empresa                = " + Empresa.EmptyStringIsNull
        strSql += "    and estabelecimento        = " + Estabelecimento.EmptyStringIsNull
        strSql += "    and cod_negociacao_cliente = " + CodNegociacaoCliente.EmptyStringIsNull
        strSql += "    and seq_item               = " + SeqItem.EmptyStringIsNull

        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
