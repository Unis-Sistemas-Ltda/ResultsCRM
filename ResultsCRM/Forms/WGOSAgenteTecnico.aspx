<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGOSAgenteTecnico.aspx.vb" Inherits="ResultsCRM.WGOSAgenteTecnico" %>

<%@ Register src="../UserControls/WUCAtendimentoPedidoCabecalho.ascx" tagname="WUCAtendimentoPedidoCabecalho" tagprefix="uc1" %>

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
    <div style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
        <table class="TextoCadastro_BGBranco" style="width:100%;">
            <tr>
                <td colspan="2">
                    Agentes Técnicos da Ordem de Serviço</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Ag. Técnico:</td>
                <td>
                    <asp:DropDownList ID="DdlAgenteTecnico" runat="server" CssClass="CampoCadastro" 
                        Width="300px">
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="BtnVincularTecnico" runat="server" CssClass="Botao" 
                        Text="Vincular" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" datasourceid="SqlDataSource2" 
                        EmptyDataText="Não há agente(s) técnico(s) vinculado(s). Escolha um agente técnico acima e clique no botão &lt;b&gt;Vincular&lt;/b&gt; para vinculá-lo." 
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
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
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
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select p.cod_agente_tecnico , u.nome nome_usuario
  from pedido_venda_agente_tecnico p inner join agente_tecnico u on u.cod_agente_tecnico = p.cod_agente_tecnico
 where p.empresa = :empresa
   and p.estabelecimento = :estabelecimento
   and cod_pedido_venda = :codPedidoVenda
order by nome_usuario">
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
    </div>
    </form>
</body>
</html>
