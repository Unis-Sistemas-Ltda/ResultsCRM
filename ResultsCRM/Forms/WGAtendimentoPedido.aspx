<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimentoPedido.aspx.vb" Inherits="ResultsCRM.WGAtendimentoPedido" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        </div>
    <div class="TextoCadastro_BGBranco" 
        style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
        <table style="width:100%;">
            <tr>
                <td style="text-align: right">
                    <asp:ImageButton ID="BtnIncluirOS" runat="server" 
            ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource3" 
                        EmptyDataText="Ordem de Serviço ainda não incluída. Clique no botão &lt;b&gt;Novo Registro&lt;/b&gt; acima para incluí-la." 
                        ForeColor="#333333" GridLines="None" Width="100%">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="cod_pedido_venda" DataFormatString="{0:F0}" 
                                HeaderText="Nº OS" SortExpression="cod_pedido_venda" />
                            <asp:BoundField DataField="situacao" HeaderText="Situação" 
                                SortExpression="situacao" />
                            <asp:BoundField DataField="aceito_tecnico" HeaderText="Aceito Técnico" 
                                SortExpression="aceito_tecnico">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_entrega" DataFormatString="{0:dd/MM/yyyy}" 
                                HeaderText="Data Atendimento" SortExpression="data_entrega" />
                            <asp:BoundField DataField="total_pedido" HeaderText="Valor Total" 
                                SortExpression="total_pedido" DataFormatString="{0:F2}" >
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton3" runat="server" 
                                        CommandArgument='<%# Eval("cod_pedido_venda") %>' CommandName="ALTERAR" 
                                        ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar OS" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Excluir">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton5" runat="server" 
                                        CommandArgument='<%# Eval("cod_pedido_venda") %>' CommandName="EXCLUIR" 
                                        ImageUrl="~/Imagens/BtnExcluir.png" 
                                        onclientclick="return confirm('ATENÇÃO: PROCEDIMENTO IRREVERSÍVEL! Deseja realmente excluir a OS?');" 
                                        ToolTip="Excluir" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Imprimir">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton4" runat="server" 
                                        CommandArgument='<%# Eval("cod_pedido_venda") %>' CommandName="IMPRIMIR" 
                                        ImageUrl="~/Imagens/BtnImprimir.gif" Width="22px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select cod_pedido_venda, case isnull(aceito_tecnico,'N') when 'N' then 'Não' when 'S' then 'Sim' end aceito_tecnico, data_entrega, total_pedido, if status_digitacao = 2 then 'Encerrada' else if status_digitacao = 3 then 'Cancelada' else 'Aberta' endif endif situacao
  from pedido_venda
 where empresa = :empresa
   and estabelecimento = :estabelecimento
   and cod_chamado = :cod_chamado">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:SessionParameter Name=":estabelecimento" 
                                SessionField="GlEstabelecimento" />
                            <asp:SessionParameter Name=":cod_chamado" SessionField="SCodAtendimento" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
