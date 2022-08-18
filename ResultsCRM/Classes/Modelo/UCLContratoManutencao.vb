Public Class UCLContratoManutencao
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("contrato_manutencao")
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodEmitente As String, ByVal Cnpj As String, ByVal Empresa As String, ByVal pCodContrato As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        If String.IsNullOrWhiteSpace(CodEmitente) OrElse String.IsNullOrWhiteSpace(Empresa) Then
            Return
        End If

        If pCodContrato Is Nothing Then
            pCodContrato = "0"
        End If

        If String.IsNullOrWhiteSpace(pCodContrato) Then
            pCodContrato = "0"
        End If

        strSql += " select contrato, contrato + ' - ' + descricao nome"
        strSql += "   from contrato_manutencao"
        strSql += "  where cod_emitente = " + CodEmitente
        If Not String.IsNullOrEmpty(Cnpj) Then
            strSql += "    and cnpj         = '" + Cnpj + "'"
        End If
        strSql += "    and empresa      = " + Empresa
        strSql += "    and ( contrato = '" + pCodContrato + "' or ( isnull(data_vencimento,'2999-12-31') >= today() and isnull(inativo,'N') = 'N' ) ) "
        strSql += "  order by nome "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("contrato") = "-1"
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "contrato"
        DDL.DataBind()
    End Sub

    Public Function GetQuantidadeContratada(ByVal pEmpresa As String, ByVal pCodContrato As String, ByVal pCodItem As String) As Double
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable
            StrSql += " select isnull(cmi.quantidade,0) qtd"
            StrSql += "   from contrato_manutencao_item cmi inner join contrato_manutencao cm on cmi.empresa = cm.empresa and cmi.contrato = cm.contrato"
            StrSql += "                                     inner join item i on i.cod_item = cmi.cod_item"
            StrSql += "  where cm.empresa   = " + pEmpresa
            StrSql += "    and cm.contrato  = '" + pCodContrato + "'"
            StrSql += "    and cmi.cod_item = '" + pCodItem + "'"
            StrSql += "    and i.tipo_despesa_consultor = 1"
            StrSql += "    and isnull(cmi.tipo_horas,0) = 0"
            dt = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count = 0 Then
                Return 0
            Else
                Return dt.Rows.Item(0).Item("qtd")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetQuantidadeHorasContratada(ByVal pEmpresa As String, ByVal pCodContrato As String) As Double
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable
            StrSql += " select isnull(cmi.quantidade,0) qtd "
            StrSql += "   from contrato_manutencao_item cmi inner join contrato_manutencao cm on cmi.empresa = cm.empresa and cmi.contrato = cm.contrato"
            StrSql += "                                     inner join item i on i.cod_item = cmi.cod_item"
            StrSql += "  where cm.empresa  = " + pEmpresa
            StrSql += "    and cm.contrato = '" + pCodContrato + "'"
            StrSql += "    and i.tipo_despesa_consultor = 1"
            StrSql += "    and isnull(cmi.tipo_horas,0) = 0"

            dt = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count = 0 Then
                Return 0
            Else
                Return dt.Rows.Item(0).Item("qtd")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetQuantidadeHorasConsumidaNoPeriodo(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodContrato As String, ByVal pDataInicial As Date, ByVal pDataFinal As Date) As Double
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable
            StrSql += " select sum(pvi.qtd_pedida) qtd"
            StrSql += "  from pedido_venda_item pvi inner join pedido_venda pv on pvi.empresa          = pv.empresa"
            StrSql += "                                                       and pvi.estabelecimento  = pv.estabelecimento"
            StrSql += "                                                       and pvi.cod_pedido_venda = pv.cod_pedido_venda"
            StrSql += "                             inner join chamado ch on ch.empresa     = pv.empresa"
            StrSql += "                                                  and ch.cod_chamado = pv.cod_chamado"
            StrSql += "                             inner join item i on i.cod_item = pvi.cod_item"
            StrSql += "                             left outer join tipo_cobranca_os tco on tco.cod_tipo_cobranca_os = pvi.cod_tipo_cobranca_os "
            StrSql += "                             left outer join contrato_manutencao_item cmi on cmi.empresa = ch.empresa and cmi.contrato = ch.contrato and cmi.cod_item = i.cod_item "
            StrSql += " where pvi.empresa         = " + pEmpresa
            StrSql += "   and pvi.estabelecimento = " + pEstabelecimento
            StrSql += "   and ch.contrato         = '" + pCodContrato + "'"
            StrSql += "   and i.tipo_despesa_consultor = 1"
            StrSql += "   and pvi.situacao_faturamento <> 5"
            StrSql += "   and (pvi.cod_tipo_cobranca_os is null or isnull(tco.faturado,'N') = 'S')"
            StrSql += "   and date(isnull(pvi.data_entrega,pv.data_emissao)) between '" + pDataInicial.ToString("yyyy-MM-dd") + "' and '" + pDataFinal.ToString("yyyy-MM-dd") + "'"
            StrSql += "   and isnull(cmi.tipo_horas,0) = 0"
            dt = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count = 0 Then
                Return 0
            Else
                If IsDBNull(dt.Rows.Item(0).Item("qtd")) Then
                    Return 0
                Else
                    Return dt.Rows.Item(0).Item("qtd")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetQuantidadeConsumidaNoPeriodo(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodContrato As String, ByVal pCodItem As String, ByVal pDataInicial As Date, ByVal pDataFinal As Date) As Double
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable
            StrSql += " select sum(pvi.qtd_pedida) qtd"
            StrSql += "  from pedido_venda_item pvi inner join pedido_venda pv on pvi.empresa          = pv.empresa"
            StrSql += "                                                       and pvi.estabelecimento  = pv.estabelecimento"
            StrSql += "                                                       and pvi.cod_pedido_venda = pv.cod_pedido_venda"
            StrSql += "                             inner join chamado ch on ch.empresa     = pv.empresa"
            StrSql += "                                                  and ch.cod_chamado = pv.cod_chamado"
            StrSql += "                             inner join item i on i.cod_item = pvi.cod_item"
            StrSql += "                             left outer join tipo_cobranca_os tco on tco.cod_tipo_cobranca_os = pvi.cod_tipo_cobranca_os "
            StrSql += " where pvi.empresa         = " + pEmpresa
            StrSql += "   and pvi.estabelecimento = " + pEstabelecimento
            StrSql += "   and pvi.cod_item        = '" + pCodItem + "'"
            StrSql += "   and ch.contrato         = '" + pCodContrato + "'"
            StrSql += "   and (pvi.cod_tipo_cobranca_os is null or isnull(tco.faturado,'N') = 'S')"
            StrSql += "   and i.tipo_despesa_consultor = 1"
            StrSql += "   and pvi.situacao_faturamento <> 5"
            StrSql += "   and date(isnull(pvi.data_entrega,pv.data_emissao)) between '" + pDataInicial.ToString("yyyy-MM-dd") + "' and '" + pDataFinal.ToString("yyyy-MM-dd") + "'"
            dt = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count = 0 Then
                Return 0
            Else
                If IsDBNull(dt.Rows.Item(0).Item("qtd")) Then
                    Return 0
                Else
                    Return dt.Rows.Item(0).Item("qtd")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    
End Class