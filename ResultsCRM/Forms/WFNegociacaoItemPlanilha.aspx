<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFNegociacaoItemPlanilha.aspx.vb" Inherits="ResultsCRM.WFNegociacaoItemPlanilha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Negociação</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
</head>
<body style="margin: 0px; padding: 0px">
    <form id="form1" runat="server">
    <table class="TextoCadastro_BGBranco" style="width:100%;">
        <tr>
            <td class="Erro" colspan="3">
        <asp:Label ID="LblErro" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: 8pt; border: 1px solid #999999; text-align: left">
                <asp:Label ID="Label7" runat="server" Text="Negociação Nº:" Width="90px" 
                    Style="text-align: right"></asp:Label>
                &nbsp;<asp:Label ID="LblCodNegociacaoCliente" runat="server" Font-Bold="True"></asp:Label>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Cliente:" Width="90px" 
                    Style="text-align: right"></asp:Label>
                &nbsp;<asp:Label ID="LblNomeCliente" runat="server" Font-Bold="True"></asp:Label>
&nbsp; -&nbsp;
                <asp:Label ID="LblCNPJ" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td style="border: 1px solid #999999; text-align: center; font-size: 8pt;">
                Total: R$
                <asp:Label ID="LblTotal" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td style="border: 1px solid #999999; text-align: center">
        <asp:Button ID="BtnCalcular" runat="server" CssClass="Botao" Text="Calcular" />
            &nbsp;
        <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
&nbsp;
        <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" 
            
                    onclientclick="if ( confirm('Deseja voltar sem salvar as alterações?') ) self.close()" 
                    Text="Voltar" />
            </td>
        </tr>
        <tr>
            <td colspan="3" style="border: 1px solid #999999">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="cod_emitente" SortExpression="cod_emitente" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblCodEmitente" runat="server" 
                            Text='<%# Bind("cod_emitente") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="cnpj" SortExpression="cnpj" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cnpj") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblCNPJ" runat="server" Text='<%# Bind("cnpj") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="cod_unidade" SortExpression="cod_unidade" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("cod_unidade") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblCodUnidade" runat="server" Text='<%# Bind("cod_unidade") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="base_icms_substituicao" 
                    SortExpression="base_icms_substituicao" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" 
                            Text='<%# Bind("base_icms_substituicao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblBaseIcmsSubstituicao" runat="server" 
                            Text='<%# Bind("base_icms_substituicao") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="preco_unitario_ud" 
                    SortExpression="preco_unitario_ud" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" 
                            Text='<%# Bind("preco_unitario_ud") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblPrecoUnitarioUD" runat="server" 
                            Text='<%# Bind("preco_unitario_ud") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="seq_item" SortExpression="seq_item" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("seq_item") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblSeqItem" runat="server" Text='<%# Bind("seq_item") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Código" SortExpression="cod_item">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("cod_item") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblCodItem" runat="server" Text='<%# Bind("cod_item") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="descricao" HeaderText="Desc. Item" 
                    SortExpression="descricao" />
                <asp:TemplateField HeaderText="Quantidade" SortExpression="qtd_ud">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("qtd_ud") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Height="15px" Text="Log.:" Width="28px"></asp:Label>
                        <asp:TextBox ID="TxtQtdUD" runat="server" CssClass="CampoCadastro" style="text-align:right"
                            Text='<%# Bind("qtd_ud", "{0:F2}") %>' Width="50px"></asp:TextBox>
                        <asp:Label ID="Label6" runat="server" Height="15px" 
                            Text='<%# Eval("desc_ud") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label5" runat="server" Height="15px" Text="Unit.:" Width="28px"></asp:Label>
                        <asp:TextBox ID="TxtQtdPedida" runat="server" CssClass="CampoCadastro"  style="text-align:right"
                            Text='<%# Bind("qtd_pedida", "{0:F2}") %>' Width="50px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="R$ Fábrica" 
                    SortExpression="preco_unitario_tabela">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" 
                            Text='<%# Bind("preco_unitario_tabela") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="TxtPrecoUnitarioTabela" runat="server" style="text-align:right"
                            CssClass="CampoCadastro" Text='<%# Bind("preco_unitario_tabela", "{0:F2}") %>' 
                            Width="60px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="%D.Com.1" 
                    SortExpression="perc_desconto_unitario1">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox11" runat="server" 
                            Text='<%# Bind("perc_desconto_unitario1") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="TxtDescUnitario1" runat="server" CssClass="CampoCadastro" style="text-align:right"
                            Text='<%# Bind("perc_desconto_unitario1", "{0:F2}") %>' Width="50px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="%D.Com.2" 
                    SortExpression="perc_desconto_unitario2">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox12" runat="server" 
                            Text='<%# Bind("perc_desconto_unitario2") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="TxtDescUnitario2" runat="server" CssClass="CampoCadastro" style="text-align:right"
                            Text='<%# Bind("perc_desconto_unitario2", "{0:F2}") %>' Width="50px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="%D.Com.3" 
                    SortExpression="perc_desconto_unitario3">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox13" runat="server" 
                            Text='<%# Bind("perc_desconto_unitario3") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="TxtDescUnitario3" runat="server" CssClass="CampoCadastro" style="text-align:right"
                            Text='<%# Bind("perc_desconto_unitario3", "{0:F2}") %>' Width="50px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="%D.Com.4" 
                    SortExpression="perc_desconto_unitario4">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox14" runat="server" 
                            Text='<%# Bind("perc_desconto_unitario4") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="TxtDescUnitario4" runat="server" CssClass="CampoCadastro" style="text-align:right"
                            Text='<%# Bind("perc_desconto_unitario4", "{0:F2}") %>' Width="50px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="%D.Repasse" 
                    SortExpression="perc_desconto_unitario5">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox15" runat="server" 
                            Text='<%# Bind("perc_desconto_unitario5") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="TxtDescUnitario5" runat="server" CssClass="CampoCadastro" style="text-align:right"
                            Text='<%# Bind("perc_desconto_unitario5", "{0:F2}") %>' Width="50px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="R$ Líquido" SortExpression="preco_unitario">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("preco_unitario") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblPrecoUnitario" runat="server" 
                            Text='<%# Bind("preco_unitario", "{0:F2}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
<asp:TemplateField HeaderText="Recurso" SortExpression="recurso">
<ItemTemplate>
                        <asp:Label ID="LblRecurso" runat="server" 
                            Text='<%# Bind("recurso", "{0:F2}") %>'></asp:Label>
                    
</ItemTemplate>

    <EditItemTemplate>
        <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("recurso") %>'></asp:TextBox>
    </EditItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
                <asp:TemplateField HeaderText="Impostos" SortExpression="aliquota_icms">
                    <ItemTemplate>
                        ICMS:<asp:Label ID="LblValorICMS" runat="server" Font-Bold="True" 
                            Text='<%# Eval("valor_icms", "{0:F2}") %>'></asp:Label>
                        (<asp:Label ID="LblAliquotaICMS" runat="server" Font-Bold="True" 
                            Text='<%# Eval("aliquota_icms", "{0:F1}") %>'></asp:Label>
                        %)<br />ICMS-ST:<asp:Label ID="LblICMSSubstituicao" runat="server" 
                            Font-Bold="True" Text='<%# Eval("icms_substituicao", "{0:F2}") %>'></asp:Label>
                        <br />
                        IPI:<asp:Label ID="LblValorIPI" runat="server" Font-Bold="True" 
                            Text='<%# Eval("valor_ipi", "{0:F2}") %>'></asp:Label>
                        (<asp:Label ID="LblAliquotaIPI" runat="server" Font-Bold="True" 
                            Text='<%# Eval("aliquota_ipi", "{0:F1}") %>'></asp:Label>
                        %)
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("aliquota_icms") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Desc.Nota" SortExpression="perc_desconto">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Height="15px" Text="%" Width="15px"></asp:Label>
                        <asp:TextBox ID="TxtPercDesconto" runat="server" CssClass="CampoCadastro" 
                            style="text-align:right" Text='<%# Bind("perc_desconto", "{0:F2}") %>' 
                            Width="50px"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label3" runat="server" Height="15px" Text="R$" Width="15px"></asp:Label>
                        <asp:TextBox ID="TxtValorDesconto" runat="server" CssClass="CampoCadastro" 
                            style="text-align:right" Text='<%# Bind("valor_desconto", "{0:F2}") %>' 
                            Width="50px"></asp:TextBox>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("perc_desconto") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="R$ Merc." SortExpression="valor_mercadoria" 
                    Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="LblValorMercadoria" runat="server" 
                            Text='<%# Bind("valor_mercadoria", "{0:F2}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox19" runat="server" 
                            Text='<%# Bind("valor_mercadoria") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="R$ Total" 
                    SortExpression="valor_total_mercadoria">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox17" runat="server" 
                            Text='<%# Bind("valor_total_mercadoria") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblValorTotalMercadoria" runat="server" 
                            Text='<%# Bind("valor_total_mercadoria", "{0:F2}") %>' Font-Bold="True"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                VerticalAlign="Top" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    
            </td>
        </tr>
        <tr>
    <td colspan="3">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select nc.empresa,
       nc.estabelecimento,
       nc.cod_negociacao_cliente,
       nc.cod_emitente,
       nc.cnpj,
       nci.cod_unidade,
       nci.base_icms_substituicao,
       nci.preco_unitario_ud,
       nci.seq_item,
       i.cod_item,
       i.descricao,
      nci.cod_natur_oper cod_natur_oper,
       nci.qtd_pedida,
       nci.qtd_ud,
       ud.descricao desc_ud,
       nci.data_entrega,
       nci.narrativa,
       nci.preco_unitario_tabela,
       nci.perc_desconto_unitario1,
       nci.perc_desconto_unitario2,
       nci.perc_desconto_unitario3,
       nci.perc_desconto_unitario4,
       nci.perc_desconto_unitario5,
       nci.preco_unitario,
       nci.recurso,
       nci.aliquota_icms,
       nci.valor_icms,
       nci.icms_substituicao,
       nci.aliquota_ipi,
       nci.valor_ipi,
       nci.perc_desconto,
       nci.valor_desconto,
       nci.valor_mercadoria,
       nci.valor_total_mercadoria
  from item i left outer join unidade_despacho ud on i.cod_ud = ud.cod_ud,
       negociacao_cliente nc left outer join negociacao_cliente_item nci on nc.empresa                = nci.empresa
                                                                        and nc.estabelecimento        = nci.estabelecimento
                                                                        and nc.cod_negociacao_cliente = nci.cod_negociacao_cliente
                                                                        and nci.cod_item              = i.cod_item
 where isnull(i.planilha_crm_negociacao,'N') = 'S'
   and nc.empresa = :empresa
   and nc.estabelecimento = :estabelecimento
   and nc.cod_negociacao_cliente = :cod_negociacao
order by i.descricao, i.cod_item">
            <SelectParameters>
                <asp:SessionParameter Name="empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter Name="estabelecimento" SessionField="GlEstabelecimento" />
                <asp:ControlParameter ControlID="LblCodNegociacaoCliente" Name="cod_negociacao" 
                    PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        </td>
        </tr>
    </table>
    </form>
</body>
</html>
