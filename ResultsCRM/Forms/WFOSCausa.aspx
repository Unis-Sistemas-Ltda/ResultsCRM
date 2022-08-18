<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFOSCausa.aspx.vb" Inherits="ResultsCRM.WFOSCausa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="TextoCadastro_BGBranco" style="width:100%;">
            <tr>
                <td style="text-align: right" colspan="2">
    <div>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        </div>
    <div class="TextoCadastro_BGBranco">
    
        <table style="width:100%;">
            <tr>
                <td style="font-style: italic">
                    Registro de Causas</td>
                <td style="text-align: right;">
                    <asp:Button ID="Button1" runat="server" Text="Voltar" />
                </td>
            </tr>
            </table>
    
    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Selecione abaixo a(s) causa(s), clicando no botão &quot;Vincular&quot;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="LblEquipamentoLbl" runat="server" Text="Equipamento:"></asp:Label>
                </td>
                <td>
            <asp:DropDownList ID="DdlEquipamento" runat="server" CssClass="CampoCadastro" 
                Width="360px" AutoPostBack="True" Enabled="False">
            </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Solicitação:</td>
                <td>
                    <asp:Label ID="LblSolicitacao" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Causa:</td>
                <td>
                    <asp:DropDownList ID="DdlCausa" runat="server" CssClass="CampoCadastro" 
                        Width="300px">
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="BtnVincularCausa" runat="server" CssClass="Botao" 
                        Text="Vincular" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" datasourceid="SqlDataSource2" 
                        EmptyDataText="Não há causas vinculadas até o momento. Escolha acima e clique no botão &lt;b&gt;Vincular&lt;/b&gt;." 
                        ForeColor="#333333" GridLines="None" Width="100%">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="cod_causa" HeaderText="Cód." 
                                SortExpression="cod_causa">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descricao" HeaderText="Descrição da Causa" 
                                SortExpression="descricao">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Desvincular">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
                                        CommandArgument='<%# Eval("cod_causa") %>' CommandName="EXCLUIR" 
                                        ImageUrl="~/Imagens/BtnExcluir.png" 
                                        
                                        onclientclick="return confirm('Deseja realmente desvincular a causa selecionada?');" />
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
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select p.cod_causa, u.descricao
  from pedido_venda_solicitacao_causa p inner join causa u on u.cod_causa = p.cod_causa
 where empresa = :empresa
   and estabelecimento = :estabelecimento
   and cod_pedido_venda = :codPedidoVenda
   and seq_solicitacao = :codSolicitacao
order by u.descricao">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:SessionParameter Name=":estabelecimento" 
                                SessionField="GlEstabelecimento" />
                            <asp:SessionParameter Name=":codPedidoVenda" SessionField="SAtCodPedido" />
                            <asp:SessionParameter Name=":codSolicitacao" 
                                SessionField="SAtSeqItemPedidoCausa" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
