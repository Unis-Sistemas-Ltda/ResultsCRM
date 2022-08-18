select * from transferencia_tecnico_remessa tr
where cod_item = '269'
  and isnull(tr.status,1) not in (3,5,6)
  and ( isnull(tr.quantidade,0) - isnull(tr.qtd_retorno,0) - isnull(tr.qtd_baixa,0) ) > 0
  and cod_transferencia in 
(select cod_transferencia from transferencia_tecnico t
where cod_agente_tecnico = 96
and atualizado = 'S'
   and not exists( select 1 
                     from transferencia_tecnico_baixa bx
                    where bx.empresa            = tr.empresa
						    and bx.estabelecimento    = tr.estabelecimento
						    and bx.cod_transferencia  = tr.cod_transferencia
						    and bx.seq_transferencia  = tr.seq_transferencia
						    and bx.tipo_transacao     = 2
                      and isnull(bx.situacao,0) = 0 )
   and not exists( select 1
				    	   from pedido_venda_movimentacao_material rem
					     where rem.empresa           = t.empresa
						    and rem.estabelecimento   = t.estabelecimento
						    and rem.cod_transferencia = t.cod_transferencia)
)

select * from saldo_estoque_tecnico
where cod_agente_tecnico = 96
and cod_item = '269'

select *
  from movimento_estoque_tecnico
 where cod_agente_tecnico = 96
   and cod_item = '269'
   and quantidade= 6
   and tipo_movimento = 'S'
order by data_movimento desc

select *
  from transferencia_tecnico tt inner join transferencia_tecnico_remessa tr on tr.empresa = tt.empresa and tt.estabelecimento = tr.estabelecimento and tt.cod_transferencia = tr.cod_transferencia
 where tt.cod_agente_tecnico = 96
   and tt.atualizado = 'S'
   and tr.cod_item = '269'
   and tr.cod_transferencia = 20314

select * from transferencia_tecnico_baixa
where cod_transferencia = 7058
and cod_item = '269'

select * from transferencia_tecnico_remessa tr
where isnull(qtd_baixa,0) + isnull(qtd_retorno,0) > quantidade
and cod_item = '269'
and cod_transferencia in
(select cod_transferencia from transferencia_tecnico t
where cod_agente_tecnico = 96
and atualizado = 'S'
   and not exists( select 1 
                     from transferencia_tecnico_baixa bx
                    where bx.empresa            = tr.empresa
						    and bx.estabelecimento    = tr.estabelecimento
						    and bx.cod_transferencia  = tr.cod_transferencia
						    and bx.seq_transferencia  = tr.seq_transferencia
						    and bx.tipo_transacao     = 2
                      and isnull(bx.situacao,0) = 0 )
   and not exists( select 1
				    	   from pedido_venda_movimentacao_material rem
					     where rem.empresa           = t.empresa
						    and rem.estabelecimento   = t.estabelecimento
						    and rem.cod_transferencia = t.cod_transferencia)
)

select * from movimento_estoque_tecnico
where cod_item = '269'
and cod_agente_tecnico = 96
and quantidade = 8
and 20131015
