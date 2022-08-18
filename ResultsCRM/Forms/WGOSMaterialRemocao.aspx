<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGOSMaterialRemocao.aspx.vb" Inherits="ResultsCRM.WGOSMaterialRemocao" %>

<%@ Register src="../UserControls/WUCRemocaoMaterial.ascx" tagname="WUCRemocaoMaterial" tagprefix="uc4" %>

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
    
                    <uc4:WUCRemocaoMaterial ID="WUCRemocaoMaterial1" runat="server" />
    
                </td>
            </tr>
            <tr>
                <td>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" ShowFooter="True" 
                        
                        
                        EmptyDataText="Você ainda não baixou nenhum material nesta Ordem de Serviço." 
                        AllowSorting="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" 
                VerticalAlign="Top" />
            <Columns>
                <asp:BoundField DataField="cod_item" HeaderText="Cód. Item" 
                    SortExpression="cod_item" ReadOnly="True" >
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="item_descricao" 
                    HeaderText="Descrição Item" SortExpression="item_descricao">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="quantidade" DataFormatString="{0:F1}" 
                    HeaderText="Qtde." SortExpression="quantidade" >
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="lote" 
                    HeaderText="Lote" SortExpression="lote" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_inclusao" DataFormatString="{0:dd/MM/yy HH:mm}" 
                    HeaderText="Data/Hora" SortExpression="data_inclusao">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="nome" HeaderText="Agente Técnico" 
                    SortExpression="nome">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_usuario" HeaderText="Usuário" 
                    SortExpression="nome_usuario">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            CommandArgument='<%# Eval("seq_movimentacao") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente estornar esta baixa?');" 
                            ToolTip="Estornar Baixa de Material" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Right" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select pm.empresa,
       pm.estabelecimento,
       pm.cod_pedido_venda,
       pm.seq_movimentacao,
       pm.tipo,
       pm.cod_item,
       pm.lote,
       pm.quantidade,
       pm.cod_agente_tecnico,
       pm.cod_transferencia,
       pm.cod_usuario_inclusao,
       pm.data_inclusao,
       s.nome_usuario,
       i.descricao item_descricao,
       ate.nome
  from pedido_venda_movimentacao_material pm inner join sysusuario s on pm.cod_usuario_inclusao      = s.cod_usuario
                                             inner join item i       on i.cod_item                   = pm.cod_item
                                             inner join agente_tecnico ate on ate.cod_agente_tecnico = pm.cod_agente_tecnico and isnull(ate.empresa,1) = pm.empresa and isnull(ate.estabelecimento,1) = pm.estabelecimento
 where pm.empresa               = :empresa
   and pm.estabelecimento     = :estabelecimento
   and pm.cod_pedido_venda = :cod_pedido_venda">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
                <asp:SessionParameter Name=":cod_pedido_venda" 
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
