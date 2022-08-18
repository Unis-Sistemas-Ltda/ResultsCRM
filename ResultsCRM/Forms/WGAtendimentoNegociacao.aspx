<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimentoNegociacao.aspx.vb" Inherits="ResultsCRM.WGAtendimentoNegociacao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.Erro
{
    font-size: 8pt;
    text-align: left;
    color: #CC0000;
    font-family: verdana;
}

input[type=button], input[type=submit], .Botao
{
    border: 1px solid #C0C0C0;
    color: #2A2A2A;
    background-color: #F0F0F0;
    background-position: 100% 100%;
    font-size: 8pt;
    text-align: center;
    font-family: verdana;
    line-height: 20px;
    font-weight: normal;
    height: 19px;
}

    </style>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <table style="border-style: none; width:100%; border-collapse: collapse;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
        <asp:Button ID="BtnIncluir" runat="server" Text="Incluir" />
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                        GridLines="None" Width="100%" AllowSorting="True" CssClass="CampoCadastro" 
                        AllowPaging="True" PageSize="50" 
                        EmptyDataText="&lt;br&gt;Nenhuma negociação foi adicionada a este chamado até o momento.&lt;br&gt;&lt;br&gt;Clique no botão Incluir acima para cadastrar uma nova negociação.">
                        <PagerSettings FirstPageText="1&nbsp;" Mode="NumericFirstLast" 
                            NextPageText="&gt;" LastPageText="Últ." PreviousPageText="&lt;" 
                            PageButtonCount="14" Visible="False" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nº Negociação" 
                                SortExpression="cod_negociacao_cliente">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("cod_negociacao") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblCodNegociacao" runat="server" 
                                        Text='<%# Eval("cod_negociacao_cliente") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Etapa" SortExpression="descricao_etapa">
                                <ItemTemplate>
                                    <asp:Label ID="LblFunil" runat="server" Text='<%# Eval("descricao_etapa") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("etapa") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="nome_usuario" 
                                HeaderText="Agente de Vendas" SortExpression="nome_usuario" />
                            <asp:BoundField DataField="data_cadastramento" 
                                DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data Cadastramento" 
                                SortExpression="data_cadastramento" />
                            <asp:BoundField DataField="total_mercadoria" DataFormatString="{0:F2}" 
                                HeaderText="Valor Total (R$)" SortExpression="total_mercadoria">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        CommandArgument='<%# Eval("cod_negociacao_cliente") %>' CommandName="ALTERAR" 
                                        ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do registro" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnImprimir" runat="server" 
                                        CommandArgument='<%# Eval("cod_negociacao_cliente") %>' CommandName="IMPRIMIR" 
                                        ImageUrl="~/Imagens/BtnImprimir.gif" Width="17px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton5" runat="server" 
                                    CommandArgument='<%# Eval("cod_negociacao_cliente") %>' CommandName="EXCLUIR" 
                                    ImageUrl="~/Imagens/BtnExcluir.png" 
                                    onclientclick="return confirm('ATENÇÃO: Procedimento irreversível! &nbsp;&nbsp;Deseja realmente excluir esta Negociação?');" 
                                    ToolTip="Excluir Negociação" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" ForeColor="White" 
                            HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
                        SelectCommand="select nc.cod_negociacao_cliente, nc.data_cadastramento, nc.cod_etapa, en.descricao descricao_etapa, nc.cod_agente_venda, ag.nome_usuario, nc.total_mercadoria
  from negociacao_cliente nc inner join etapa_negociacao en on en.empresa = nc.empresa and en.cod_etapa = nc.cod_etapa
                             left outer join sysusuario ag on ag.cod_usuario = nc.cod_agente_venda
 where nc.empresa     = :empresa
   and nc.cod_chamado = :cod_chamado
">
                        <SelectParameters>
                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                            Name=":empresa" SessionField="GlEmpresa" />
                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                            Name=":cod_chamado" SessionField="SCodAtendimento" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
