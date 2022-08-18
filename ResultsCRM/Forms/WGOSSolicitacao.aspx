<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGOSSolicitacao.aspx.vb" Inherits="ResultsCRM.WGOSSolicitacao" %>

<%@ Register src="../UserControls/WUCAtendimentoPedidoSolicitacao.ascx" tagname="WUCAtendimentoPedidoSolicitacao" tagprefix="uc2" %>

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
                    <uc2:WUCAtendimentoPedidoSolicitacao ID="WUCAtendimentoPedidoSolicitacao1" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" 
                        
                        EmptyDataText="Você ainda não incluiu nenhum item nesta OS. Clique no botão &lt;b&gt;Novo Registro&lt;/b&gt; acima para incluir um item.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" 
                VerticalAlign="Top" />
            <Columns>
                <asp:TemplateField HeaderText="Seq." SortExpression="seq_solicitacao">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("seq_solicitacao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblSeq" runat="server" 
                            Text='<%# Eval("seq_solicitacao", "{0:F0}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Equipamento / Solicitação" 
                    SortExpression="numero_serie">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("numero_serie") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblNumeroSerie" runat="server" 
                            Text='<%# Bind("numero_serie") %>' Font-Bold="True"></asp:Label>
                        &nbsp;-
                        <asp:Label ID="LblDescEquipamento" runat="server" Font-Bold="True" 
                            Text='<%# Eval("desc_equipamento") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LblServicoSolicitado" runat="server" 
                            Text='<%# Eval("servico_solicitado") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_solicitacao") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar Item da OS" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            CommandArgument='<%# Eval("seq_solicitacao") %>' CommandName="EXCLUIR" 
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
            SelectCommand="select convert(char,:tpfat) tpfat, pi.cod_pedido_venda, pi.seq_solicitacao, pi.numero_serie, if tpfat = 'G' then i.descricao || ' (' || i.cod_item || ') ' || eq.referencia else eq.observacao endif desc_equipamento, pi.servico_solicitado
  from pedido_venda p inner join pedido_venda_solicitacao pi on p.empresa          = pi.empresa
                                                     and p.estabelecimento  = pi.estabelecimento
                                                     and p.cod_pedido_venda = pi.cod_pedido_venda
                       left outer join equipamento eq on eq.numero_serie = pi.numero_serie
                                                    and eq.empresa      = pi.empresa
                       left outer join item i on eq.cod_item = i.cod_item
 where p.empresa           = :empresa
   and p.estabelecimento   = :estabelecimento
   and p.cod_pedido_venda  = convert(numeric(12),:cod_pedido)
order by pi.seq_solicitacao">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="N" Name=":tpfat" 
                    SessionField="GlTipoFaturamento" />
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" ConvertEmptyStringToNull="False" 
                    DbType="String" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" ConvertEmptyStringToNull="False" 
                    DbType="String" />
                <asp:SessionParameter Name=":cod_pedido" 
                    SessionField="SAtCodPedido" ConvertEmptyStringToNull="False" 
                    DbType="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
