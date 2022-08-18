Public Class UCLItem

    Private _CodItem As String
    Private _Descricao As String
    Private _TipoFaturamento As String
    Private objAcessoDados As UCLAcessoDados

    Public Property CodUd As String
    Public Property Aplicacao As String

    Public Property CodItem() As String
        Get
            Return _CodItem
        End Get
        Set(ByVal value As String)
            _CodItem = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return _Descricao
        End Get
        Set(ByVal value As String)
            _Descricao = value
        End Set
    End Property

    Public Property TipoFaturamento() As String
        Get
            Return _TipoFaturamento
        End Get
        Set(ByVal value As String)
            _TipoFaturamento = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Function GetFatorConversaoItemUnidade(ByVal codItem As String, ByVal codUnidade As String) As Double
        Dim StrSql As String = ""
        Dim dt As DataTable
        Dim ret As Double = 1

        Try
            StrSql += "select isnull(fator_conversao,1) fator "
            StrSql += "  from item_unidade "
            StrSql += " where cod_item = '" + codItem + "'"
            StrSql += "   and cod_unidade = '" + codUnidade + "'"
            dt = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("fator")
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return ret
    End Function

    Public Function GetFatorConversaoUD(ByVal codItem As String) As Double
        Dim StrSql As String = ""
        Dim dt As DataTable
        Dim ret As Double = 1

        Try
            StrSql += "select isnull(u.fator_conversao,1) fator "
            StrSql += "  from item i inner join unidade_despacho u on i.cod_ud = u.cod_ud "
            StrSql += " where cod_item = '" + codItem + "'"
            dt = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("fator")
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return ret
    End Function

    Public Function Buscar() As DataTable
        Dim strSql As String
        Dim dt As DataTable

        strSql = "select descricao, isnull(tipo_faturamento,'C') tipo_faturamento, cod_ud, aplicacao from item where cod_item = '" + CodItem + "'"

        dt = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            TipoFaturamento = dt.Rows.Item(0).Item("tipo_faturamento").ToString
            CodUd = dt.Rows.Item(0).Item("cod_ud").ToString
            Aplicacao = dt.Rows.Item(0).Item("aplicacao").ToString
        End If

        Return dt
    End Function

    Public Function PrecoItemContrato(ByVal empresa As String, ByVal codContrato As String, ByVal codItem As String) As Double
        Dim retorno As Double = 0
        Dim strSql As String = ""
        Dim dt As DataTable
        strSql += " select valor"
        strSql += "   from contrato_manutencao_item"
        strSql += "  where empresa  = " + empresa
        strSql += "    and contrato = '" + codContrato + "'"
        strSql += "    and cod_item = '" + codItem + "'"
        dt = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows.Item(0).Item("valor")) Then
                retorno = CDbl(dt.Rows.Item(0).Item("valor"))
            Else
                retorno = 0
            End If
        Else
            Return -0.01
        End If
        Return retorno
    End Function

    Public Function PrecoItemCliente(ByVal empresa As String, ByVal estabelecimento As String, ByVal emitente As String, ByVal cnpj As String, ByVal codItem As String, ByVal codContrato As String, ByVal codEmitenteAtendimento As String, ByVal numeroPontoAtendimento As String) As Double
        Dim retorno As Double = -0.01
        retorno = PrecoItemContrato(empresa, codContrato, codItem)
        If retorno = -0.01 Then
            retorno = PrecoItemCliente(empresa, estabelecimento, emitente, cnpj, codItem, codEmitenteAtendimento, numeroPontoAtendimento)
        End If
        Return retorno
    End Function

    Public Function PrecoItemCliente(ByVal empresa As String, ByVal estabelecimento As String, ByVal emitente As String, ByVal cnpj As String, ByVal codItem As String, ByVal codEmitenteAtendimento As String, ByVal numeroPontoAtendimento As String) As Double
        If String.IsNullOrWhiteSpace(codEmitenteAtendimento) Then
            codEmitenteAtendimento = "null"
        End If
        If String.IsNullOrWhiteSpace(numeroPontoAtendimento) Then
            numeroPontoAtendimento = "null"
        Else
            numeroPontoAtendimento = "'" + numeroPontoAtendimento + "'"
        End If
        Dim strSql As String = " select f_busca_preco_item_cliente_new2(" + empresa + "," + estabelecimento + "," + emitente + ",'" + cnpj + "','" + codItem + "',null,null,0,0, null, null, null," + codEmitenteAtendimento + "," + numeroPontoAtendimento + ") preco from dummy"
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        Dim retorno As Double = 0
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows.Item(0).Item("preco")) Then
                retorno = 0
            Else
                retorno = CDbl(dt.Rows.Item(0).Item("preco").ToString)
            End If

        End If
        Return retorno
    End Function

    Public Function PrecoItemCliente(ByVal empresa As String, ByVal estabelecimento As String, ByVal emitente As String, ByVal cnpj As String, ByVal codItem As String, ByVal PrecoRedefinido As Double, ByVal DescontoRedefinido As Double, ByVal Pedido As String, ByVal ValorDesconto As Double, ByVal codEmitenteAtendimento As String, ByVal numeroPontoAtendimento As String) As Double
        Dim strSql As String = " select f_busca_preco_item_cliente_new2(" + empresa + "," + estabelecimento + "," + emitente + ",'" + cnpj + "','" + codItem + "'," + PrecoRedefinido.ToString("F4").Replace(",", ".") + "," + DescontoRedefinido.ToString("F4").Replace(",", ".") + "," + Pedido + "," + ValorDesconto.ToString("F4").Replace(",", ".") + ", null, null, null," + codEmitenteAtendimento + "," + numeroPontoAtendimento + ") preco from dummy"
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        Dim retorno As Double = 0
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows.Item(0).Item("preco")) Then
                retorno = 0
            Else
                retorno = CDbl(dt.Rows.Item(0).Item("preco").ToString)
            End If

        End If
        Return retorno
    End Function

    Public Function F_BuscaTabelaPrecoVenda(ByVal empresa As String, ByVal emitente As String, ByVal cnpj As String) As Long
        Try
            Dim strSql As String = " select f_busca_tabela_preco_venda(" + empresa + "," + emitente + ",'" + cnpj + "') tabela from dummy"
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            Dim retorno As Long = 0
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("tabela")) Then
                    retorno = 0
                Else
                    retorno = CDbl(dt.Rows.Item(0).Item("tabela").ToString)
                End If
            End If
            Return retorno
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub BuscaDescontosComerciaisUnitarios(ByVal Empresa As String, ByVal Estabelecimento As String, ByVal CodTabelaPrecoVenda As String, ByVal CodItem As String, ByRef Desc1 As Double, ByRef Desc2 As Double, ByRef Desc3 As Double, ByRef Desc4 As Double, ByRef Desc5 As Double)
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable
            If String.IsNullOrWhiteSpace(Empresa) Then
                Empresa = "1"
            End If
            If String.IsNullOrWhiteSpace(Estabelecimento) Then
                Estabelecimento = "1"
            End If
            If String.IsNullOrWhiteSpace(CodTabelaPrecoVenda) Then
                CodTabelaPrecoVenda = "0"
            End If
            StrSql += " select isnull(perc_desconto_unitario1,0) desc1, isnull(perc_desconto_unitario2,0) desc2, isnull(perc_desconto_unitario3,0) desc3, isnull(perc_desconto_unitario4,0) desc4, isnull(perc_desconto_unitario5,0) desc5 "
            StrSql += "   from tabela_preco_venda_item "
            StrSql += "  where empresa                = " + empresa
            StrSql += "    and estabelecimento        = " + estabelecimento
            StrSql += "    and cod_tabela_preco_venda = " + codTabelaPrecoVenda
            StrSql += "    and cod_item               = '" + CodItem + "'"
            dt = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Desc1 = dt.Rows.Item(0).Item("desc1")
                Desc2 = dt.Rows.Item(0).Item("desc2")
                Desc3 = dt.Rows.Item(0).Item("desc3")
                Desc4 = dt.Rows.Item(0).Item("desc4")
                Desc5 = dt.Rows.Item(0).Item("desc5")
            Else
                Desc1 = 0
                Desc2 = 0
                Desc3 = 0
                Desc4 = 0
                Desc5 = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetNarrativa(ByVal codItem As String) As String
        Dim strSql As String = "select narrativa from item where cod_item = '" + codItem + "'"
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        Dim ret As String = ""
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("narrativa").ToString
        End If
        Return ret
    End Function

    Public Function GetTipoItem(ByVal codItem As String) As String
        Dim strSql As String = "select isnull(tipo_despesa_consultor,3) tipo_despesa_consultor from item where cod_item = '" + codItem + "'"
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        Dim ret As String = "3"
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("tipo_despesa_consultor").ToString
        End If
        Return ret
    End Function

    Public Sub FillDropDownUnidade(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal codItem As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select iu.cod_unidade, u.descricao "
        strSql += "   from item_unidade iu, "
        strSql += "        unidade u "
        strSql += "  where cod_item       = '" + codItem + "'"
        strSql += "    and iu.cod_unidade = u.cod_unidade "
        strSql += " union "
        strSql += " select i.cod_unidade, u.descricao "
        strSql += "   from item i, "
        strSql += "        unidade u       "
        strSql += "  where cod_item      = '" + codItem + "'"
        strSql += "    and i.cod_unidade = u.cod_unidade "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_unidade") = " "
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "descricao"
        DDL.DataValueField = "cod_unidade"
        DDL.DataBind()
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Try
            Dim strSql As String = ""
            Dim dt As DataTable

            strSql += " select cod_item, descricao "
            strSql += "   from item "
            strSql += "  order by descricao "
            dt = objAcessoDados.BuscarDados(strSql)

            If AdicionarRegistroEmBranco Then
                Dim NovaLinha As DataRow = dt.NewRow
                NovaLinha("cod_item") = " "
                If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                    DescricaoRegistroEmBranco = " "
                End If
                NovaLinha("descricao") = DescricaoRegistroEmBranco
                dt.Rows.InsertAt(NovaLinha, 0)
            End If

            DDL.DataSource = dt
            DDL.DataTextField = "descricao"
            DDL.DataValueField = "cod_item"
            DDL.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetComGrade(ByVal pCodItem As String) As String
        Try
            Dim strSql As String
            Dim dt As DataTable
            Dim retorno

            strSql = "select isnull(com_grade,'N') com_grade from item where cod_item = '" + pCodItem + "'"
            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                retorno = dt.Rows.Item(0).Item("com_grade")
            Else
                retorno = "N"
            End If

            Return retorno
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetImagem()
        Try
            Dim strSql As String
            Dim dt As DataTable
            Dim retorno

            strSql = "select imagem from item where cod_item = '" + CodItem + "'"
            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("imagem")) Then
                    retorno = Nothing
                Else
                    retorno = dt.Rows.Item(0).Item("imagem")
                End If
            Else
                retorno = Nothing
            End If

            Return retorno
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDescricaoUnidadeDespacho(codUd As String) As String
        Try
            If String.IsNullOrWhiteSpace(codUd) Then
                codUd = 0
            End If
            Dim StrSql As String = "select descricao from unidade_despacho where cod_ud = " + codUd
            Dim ret As String
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("descricao").ToString
            Else
                ret = ""
            End If
            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
