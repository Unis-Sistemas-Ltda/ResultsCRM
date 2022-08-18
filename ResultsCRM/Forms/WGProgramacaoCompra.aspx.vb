Public Class WGProgramacaoCompra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim StrSql As String = ""
        StrSql += " select op.empresa empresa, "
        StrSql += "       op.cod_item cod_item, "
        StrSql += "       i.descricao descricao_item, "
        StrSql += "       r.descricao descricao_referencia,"
        StrSql += "       'OP' tipo,"
        StrSql += "       op.cod_op numero_documento,"
        StrSql += "       op.qtd_solicitada,"
        StrSql += "       (if (isnull(op.qtd_solicitada,0) - isnull(op.qtd_produzida,0)) > 0 then isnull(op.qtd_solicitada,0) - isnull(op.qtd_produzida,0) else 0 endif) as qtd_saldo,"
        StrSql += "       op.data_fim data_prevista"
        StrSql += "  from ordem_producao op inner join item i            on op.cod_item   = i.cod_item"
        StrSql += "                         left outer join referencia r on op.referencia = r.cod_referencia"
        StrSql += " where trim(isnull(:cod_item,'')) in ('', op.cod_item)"
        StrSql += "   and i.descricao like '%' || replace(trim(isnull(:descricao,'')),'+','%') || '%'"
        StrSql += "   and op.situacao in (1,2)"
        StrSql += "   and qtd_saldo         <> 0"
        StrSql += "   and op.empresa         = :empresa"
        StrSql += "   and op.estabelecimento = :estabelecimento"
        StrSql += "   and trim(isnull(:referencia,'')) in ('', op.referencia)"
        StrSql += "   and data_prevista <= convert(date, f_isnull_or_empty(:periodo,'31/12/2999'),103)"
        StrSql += " union all "
        StrSql += " select oc.empresa empresa,"
        StrSql += "       oc.cod_item cod_item,"
        StrSql += "       i.descricao descricao_item,"
        StrSql += "       r.descricao descricao_referencia,"
        StrSql += "       'OC' tipo,"
        StrSql += "       oc.cod_ordem_compra numero_documento,"
        StrSql += "       oc.qtd_pedida,"
        StrSql += "       ( if (isnull(ocp.qtd_pedida,0) - isnull(ocp.qtd_entregue,0)) > 0 then isnull(ocp.qtd_pedida,0) - isnull(ocp.qtd_entregue,0) else 0 endif)   qtd_saldo,"
        StrSql += "       date(isnull(ocp.dt_entrega,oc.data_entrega)) data_prevista"
        StrSql += "  from ordem_compra oc   inner join ordem_compra_programacao ocp on ocp.empresa = oc.empresa"
        StrSql += "                                                                and ocp.estabelecimento = oc.estabelecimento"
        StrSql += "                                                                and ocp.cod_ordem_compra = oc.cod_ordem_compra"
        StrSql += "                         inner join item i            on oc.cod_item   = i.cod_item"
        StrSql += "                         left outer join referencia r on oc.referencia = r.cod_referencia"
        StrSql += " where trim(isnull(:cod_item,'')) in ('', oc.cod_item)"
        StrSql += "   and i.descricao like '%' || replace(trim(isnull(:descricao,'')),'+','%') || '%'"
        StrSql += "   and oc.situacao not in (5,6)"
        StrSql += "   and qtd_saldo         <> 0"
        StrSql += "   and oc.empresa         = :empresa"
        StrSql += "   and oc.estabelecimento = :estabelecimento"
        StrSql += "   and trim(isnull(:referencia,'')) in ('', isnull(oc.referencia,''))"
        StrSql += "   and data_prevista <= convert(date, f_isnull_or_empty(:periodo,'31/12/2999'),103)"
        StrSql += " order by descricao_item, cod_item, descricao_referencia, data_prevista"
        SqlDataSource1.SelectCommand = StrSql
        GridView1.DataBind()
    End Sub
End Class