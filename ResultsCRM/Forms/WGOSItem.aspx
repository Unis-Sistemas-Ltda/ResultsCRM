<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGOSItem.aspx.vb" Inherits="ResultsCRM.WGOSItem" %>

<%@ Register src="../UserControls/WUCAtendimentoPedidoCabecalho.ascx" tagname="WUCAtendimentoPedidoCabecalho" tagprefix="uc1" %>

<%@ Register src="../UserControls/WUCAtendimentoPedidoItem.ascx" tagname="WUCAtendimentoPedidoItem" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        </div>
    <div class="TextoCadastro_BGBranco" 
        style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
    
        <table style="width:100%;">
            <tr>
                <td>
    
                    <uc2:WUCAtendimentoPedidoItem ID="WUCAtendimentoPedidoItem1" runat="server" />
    
                </td>
            </tr>
            <tr>
                <td>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" ShowFooter="True" 
                        
                        
                        EmptyDataText="Você ainda não incluiu nenhum item nesta OS. Clique no botão &lt;b&gt;Novo Registro&lt;/b&gt; acima para incluir um item.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" 
                VerticalAlign="Top" />
            <Columns>
                <asp:TemplateField HeaderText="Seq. Item" SortExpression="seq_item">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("seq_item") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblSeq" runat="server" Text='<%# Bind("seq_item", "{0:F0}") %>'></asp:Label>
                        <asp:Label ID="LblValorVisible" runat="server" 
                            Text='<%# Eval("valor_visible") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="seq_solicitacao" HeaderText="Seq. Solic." 
                    SortExpression="seq_solicitacao" Visible="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Item / Serv. Realizado" 
                    SortExpression="cod_item">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("cod_item") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblCodItem" runat="server" Text='<%# Bind("cod_item") %>' 
                            Font-Bold="True"></asp:Label>
                        &nbsp;-
                        <asp:Label ID="LblDescricaoItem" runat="server" Text='<%# Eval("descricao") %>' 
                            Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="LblNarrativa" runat="server" Text='<%# Eval("narrativa") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Equipamento / Componente" 
                    SortExpression="desc_equipamento">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" 
                            Text='<%# Bind("desc_equipamento") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" 
                            Text='<%# Bind("desc_equipamento") %>'></asp:Label>
                        (<asp:Label ID="Label2" runat="server" Font-Bold="True" 
                            Text='<%# Eval("numero_registro") %>'></asp:Label>
                        )<br />
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("ic_Descricao") %>'></asp:Label>
                        &nbsp;-
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("observacao") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="qtd_pedida" HeaderText="Qtd." 
                    SortExpression="qtd_pedida" DataFormatString="{0:F2}">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="preco_unitario" DataFormatString="R$ {0:F2}" 
                    HeaderText="Preço Unit." SortExpression="preco_unitario" >
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Total" SortExpression="valor_total_mercadoria">
                    <ItemTemplate>
                        R$
                        <asp:Label ID="LblValorTotal" runat="server" 
                            Text='<%# Bind("valor_total_mercadoria", "{0:F2}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" 
                            Text='<%# Bind("valor_total_mercadoria") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        R$
                        <asp:Label ID="LblTotalGeral" runat="server" Text="0,00"></asp:Label>
                    </FooterTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# eval("seq_item") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar Item da OS" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            CommandArgument='<%# Eval("seq_item") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('ATENÇÃO: Procedimento irreversível! &nbsp;&nbsp;Deseja realmente excluir o item selecionado?');" 
                            ToolTip="Excluir" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Right" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Right" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select convert(char,:tpfat) tpfat, pi.cod_pedido_venda, pi.seq_item, pi.numero_serie, if tpfat = 'G' then eq.cod_item else eq.numero_registro endif numero_registro, if tpfat = 'G' then (select descricao from item where cod_item = eq.cod_item) else eq.observacao endif desc_equipamento, pi.seq_componente, if tpfat = 'G' then eq.referencia else ic.descricao endif ic_Descricao, eqc.observacao, pi.servico_solicitado, pi.cod_item, i.descricao, pi.narrativa || ' ' || isnull(narrativa_complementar,'') narrativa, pi.qtd_pedida, pi.preco_unitario, pi.valor_total_mercadoria, pi.seq_solicitacao, if i.tipo_despesa_consultor in (1,2) then '&lt;br&gt; Data: ' || convert(varchar(10), pi.data_entrega, 103) || ' ' || if isnull(pi.km_inicial,0) &gt; 0 then ' KM Inicial: ' || isnull(pi.km_inicial,0) else '' endif || ' ' || if isnull(pi.km_final,0) &gt; 0 then ' KM Final: ' || isnull(pi.km_final,0) else '' endif || ' ' || if isnull(pi.hora_inicial,'') &lt;&gt; '' then ' - Horário: ' || isnull(pi.hora_inicial,'') || ' às ' || isnull(pi.hora_final,'') else '' endif else '' endif narrativa_complementar,
       if isnull(pm.mostrar_valor_os_crm,'N') = 'S' then 'True' else 'False' endif valor_visible
  from pedido_venda p inner join pedido_venda_item pi on p.empresa          = pi.empresa
                                                     and p.estabelecimento  = pi.estabelecimento
                                                     and p.cod_pedido_venda = pi.cod_pedido_venda
                      left outer join item i on pi.cod_item = i.cod_item
                      left outer join equipamento eq on eq.numero_serie = pi.numero_serie
                                                    and eq.empresa      = pi.empresa
                      left outer join equipamento_componente eqc on eqc.empresa = eq.empresa
                                                                and eqc.numero_serie = eq.numero_serie
                                                                and eqc.seq_componente = pi.seq_componente
                      left outer join item ic on ic.cod_item = eqc.cod_item
                      left outer join parametros_manutencao pm on pm.empresa = p.empresa and pm.estabelecimento = p.estabelecimento
 where p.empresa         = :empresa
   and p.estabelecimento = :estabelecimento
   and p.cod_pedido_venda    = :cod_pedido
order by pi.seq_item desc">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":tpfat" SessionField="GlTipoFaturamento" />
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
                <asp:SessionParameter Name=":cod_pedido" 
                    SessionField="SAtCodPedido" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
