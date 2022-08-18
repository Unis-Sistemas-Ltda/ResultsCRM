<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGPosVendaCompras.aspx.vb" Inherits="ResultsCRM.WGPosVendaCompras" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TextoCadastro_BGBranco" style="font-weight: bold">
    
        HISTÓRICO DE COMPRAS<br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="False" Height="17px" 
            Text="Pesquise por item:&nbsp;"></asp:Label>
        <asp:TextBox ID="TxtItemPesquisado" runat="server" CssClass="CampoCadastro" 
            Width="180px"></asp:TextBox>
&nbsp;<asp:Button ID="BtnPesquisar" runat="server" CssClass="Botao" Text="Pesquisar" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" DataSourceID="SqlDataSource1" 
            EmptyDataText="Nenhum pedido de venda encontrado." 
            EnableModelValidation="True" Font-Bold="False" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="cod_pedido_venda" HeaderText="Ped. Nº" 
                    SortExpression="cod_pedido_venda" DataFormatString="{0:F0}" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="data_emissao" DataFormatString="{0:dd/MM/yy}" 
                    HeaderText="Emissão" SortExpression="data_emissao">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="data_entrega" DataFormatString="{0:dd/MM/yy}" 
                    HeaderText="Entrega" SortExpression="data_entrega">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="seq_item" 
                    DataFormatString="{0:F0}" HeaderText="Seq." 
                    SortExpression="seq_item" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Item" SortExpression="descricao">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                        (<asp:Label ID="Label2" runat="server" Text='<%# Eval("cod_item") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="qtd_pedida" DataFormatString="{0:F2}" 
                    HeaderText="Qtde." SortExpression="qtd_pedida">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="preco_unitario" DataFormatString="{0:F2}" 
                    HeaderText="R$ Unitário" SortExpression="preco_unitario">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="valor_mercadoria" DataFormatString="{0:F2}" 
                    HeaderText="R$ Total" SortExpression="valor_mercadoria">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select p.cod_pedido_venda,
       pi.seq_item,
       i.descricao,
       i.cod_item,
       p.data_emissao,
       p.data_entrega,
       pi.preco_unitario,
       pi.qtd_pedida,
       pi.valor_mercadoria
  from pedido_venda p inner join pedido_venda_item pi on p.cod_pedido_venda = pi.cod_pedido_venda
                                                     and p.empresa          = pi.empresa
                                                     and p.estabelecimento  = pi.estabelecimento
                      inner join item i on i.cod_item = pi.cod_item
 where p.cod_emitente = :cod_farmacia
     and i.cod_item || ';' || i.descricao like '%' || :item || '%'
order by p.data_entrega desc, p.data_emissao desc">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_farmacia" SessionField="SCodEmitente" />
                <asp:ControlParameter ControlID="TxtItemPesquisado" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":item" 
                    PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
