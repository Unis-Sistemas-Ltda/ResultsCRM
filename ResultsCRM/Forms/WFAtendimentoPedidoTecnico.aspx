<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFAtendimentoPedidoTecnico.aspx.vb" Inherits="ResultsCRM.WFAtendimentoPedidoTecnico" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="TextoCadastro_BGBranco" style="width:100%;">
        <tr>
            <td colspan="2">
                <img alt="Ordem de Serviço" src="../Imagens/OSAtendimento.png" 
                    style="width: 420px; height: 18px" /></td>
        </tr>
        <tr>
            <td class="Erro" colspan="2">
                <asp:Label ID="LblErro" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Ag.
                Técnico:</td>
            <td>
                <asp:DropDownList ID="DdlAgenteTecnico" runat="server" CssClass="CampoCadastro" 
                    Width="300px">
                </asp:DropDownList>
&nbsp;<asp:Button ID="BtnIncluir" runat="server" CssClass="Botao" Text="Vincular" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataSourceID="SqlDataSource1" 
                    EmptyDataText="Não há técnico(s) vinculado(s) à esta Ordem de serviço até o momento." 
                    ForeColor="#333333" GridLines="None" Width="100%">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="cod_agente_tecnico" HeaderText="Cód." 
                            SortExpression="cod_agente_tecnico">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nome_usuario" HeaderText="Nome Ag. Técnico" 
                            SortExpression="nome_usuario">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Desvincular">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" 
                                    CommandArgument='<%# Eval("cod_agente_tecnico") %>' CommandName="EXCLUIR" 
                                    ImageUrl="~/Imagens/BtnExcluir.png" 
                                    onclientclick="return confirm('Deseja realmente desvincular o técnico selecionado?');" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select p.cod_agente_tecnico , u.nome_usuario
  from pedido_venda_agente_tecnico p inner join sysusuario u on p.cod_agente_tecnico = u.cod_usuario
 where empresa = :empresa
   and estabelecimento = :estabelecimento
   and cod_pedido_venda = :codPedidoVenda
order by u.nome_usuario">
                    <SelectParameters>
                        <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                        <asp:SessionParameter Name=":estabelecimento" 
                            SessionField="GlEstabelecimento" />
                        <asp:SessionParameter Name=":codPedidoVenda" SessionField="SAtCodPedido" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
