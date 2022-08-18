<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGOSNF.aspx.vb" Inherits="ResultsCRM.WGOSNF" %>

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
        style="border-style: none">
    
        <table style="width:100%;">
            <tr>
                <td>
    
        <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource7" ForeColor="#333333" GridLines="None" 
            Width="100%" 
                        
                        
                        EmptyDataText="Nenhuma nota fiscal a exibir." 
                        
                        DataKeyNames="empresa,estabelecimento,serie,cod_nfs,cod_item,cod_cond_pagto">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" 
                VerticalAlign="Top" />
            <Columns>
                <asp:BoundField DataField="data_faturamento" HeaderText="Data Faturamento" 
                    SortExpression="data_faturamento" DataFormatString="{0:dd/MM/yy}">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="serie" HeaderText="Série" 
                    SortExpression="serie" ReadOnly="True">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_nfs" HeaderText="NF" ReadOnly="True" 
                    SortExpression="cod_nfs" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="seq_item_nfs" HeaderText="Seq. Item NF" 
                    SortExpression="seq_item_nfs" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="qtd_pedida" HeaderText="Qtd. Pedida" 
                    SortExpression="qtd_pedida" DataFormatString="{0:F2}" >
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="qtd_entregue" HeaderText="Qtd. Faturada" 
                    SortExpression="qtd_entregue" DataFormatString="{0:F2}" >
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="qtd_pendente" HeaderText="Qtd. Pendente" 
                    SortExpression="qtd_pendente" DataFormatString="{0:F2}" >
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="seq_item" HeaderText="Seq. Item OS" 
                    SortExpression="seq_item" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Item" SortExpression="descricao">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                        (<asp:Label ID="Label8" runat="server" Text='<%# Eval("cod_item") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transportador" 
                    SortExpression="nome_transportador">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" 
                            Text='<%# Bind("nome_transportador") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("nome_transportador") %>'></asp:Label>
                        (<asp:Label ID="Label9" runat="server" Text='<%# Eval("cod_transportador") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Condição de Pagamento" 
                    SortExpression="descricao_cond_pagto">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" 
                            Text='<%# Bind("descricao_cond_pagto") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Bind("descricao_cond_pagto") %>'></asp:Label>
                        (<asp:Label ID="Label10" runat="server" Text='<%# Eval("cod_cond_pagto") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
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
        <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT nfs_faturamento.empresa,
		 nfs_faturamento.estabelecimento,
		 nfs_faturamento.serie,
		 nfs_faturamento.cod_nfs,
		 nfs_faturamento.seq_item_nfs,
		 nfs_faturamento.cod_pedido_venda,
		 nfs_faturamento.seq_item,
		 nfs_faturamento.seq_programacao,
		 nfs_faturamento.qtd_pedida,
		 nfs_faturamento.qtd_pendente,
		 nfs_faturamento.qtd_entregue,
		 nfs_faturamento.data_faturamento,
		 nfs_faturamento.tipo,
		 item.descricao,
		 item.cod_item,
		 item.cod_familia,
		 item.descricao_cupom_fisc,
		 nfs.atualizado,
		 nfs.atualizado_estoque,
		 nfs.cod_transportador,
		 nfs_faturamento.cod_cond_pagto,
       c.descricao descricao_cond_pagto, 
       (select nome from emitente where cod_emitente = nfs.cod_transportador) nome_transportador
  FROM nfs_faturamento left outer join cond_pagto_venda c on c.cod_cond_pagto = nfs_faturamento.cod_cond_pagto,
       item,
       pedido_venda_item,
		 nfs
 WHERE item.cod_item								= pedido_venda_item.cod_item
	AND nfs.situacao								= 1
   and isnull(nfs.situacao_nf_eletronica,1) &lt;&gt; 11
	AND nfs.cod_nfs								= nfs_faturamento.cod_nfs
	AND nfs.serie									= nfs_faturamento.serie
	AND nfs.estabelecimento						= nfs_faturamento.estabelecimento
	AND nfs.empresa								= nfs_faturamento.empresa
   AND pedido_venda_item.seq_item 			= nfs_faturamento.seq_item
   AND pedido_venda_item.cod_pedido_venda = nfs_faturamento.cod_pedido_venda
   AND pedido_venda_item.estabelecimento 	= nfs_faturamento.estabelecimento
   AND pedido_venda_item.empresa			 	= nfs_faturamento.empresa
   AND nfs_faturamento.cod_pedido_venda	= :cod_pedido
   AND nfs_faturamento.estabelecimento 	= :estabelecimento
   AND nfs_faturamento.empresa 				= :empresa">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_pedido" 
                    SessionField="SAtCodPedido" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
