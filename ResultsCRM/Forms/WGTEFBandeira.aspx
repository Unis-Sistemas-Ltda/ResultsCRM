<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGTEFBandeira.aspx.vb" Inherits="ResultsCRM.WGTEFBandeira" %>

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
                <td style="text-align: right">
                    Bandeira:</td>
                <td>
                    <asp:DropDownList ID="DdlBandeira" runat="server" CssClass="CampoCadastro" 
                        Width="300px" AutoPostBack="True">
                    </asp:DropDownList>
                    &nbsp;<asp:Label ID="Label1" runat="server" Height="17px" Text="Adquirente:"></asp:Label>
                    <asp:DropDownList ID="DdlAdquirente" runat="server" CssClass="CampoCadastro" 
                        Width="300px">
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="BtnAdicionar" runat="server" CssClass="Botao" 
                        Text="Adicionar" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" datasourceid="SqlDataSource2" 
                        EmptyDataText="Nenhuma bandeira adicionada ao cliente até o momento." 
                        ForeColor="#333333" GridLines="None" Width="100%" CssClass="TextoCadastro">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="cod_bandeira" HeaderText="Cód." 
                                SortExpression="cod_bandeira">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descricao" HeaderText="Bandeira" 
                                SortExpression="descricao">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nome_autorizadora" HeaderText="Adquirente" 
                                SortExpression="nome_autorizadora">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Excluir">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
                                        CommandArgument='<%# Eval("chave") %>' CommandName="EXCLUIR" 
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
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select a.cod_bandeira, b.descricao, t.nome_autorizadora, a.cod_bandeira || ';' || a.cod_adquirente chave
   from adesao_tef_bandeira a inner join tef_bandeira b on a.cod_bandeira = b.cod_bandeira
                              inner join tef_adquirente t on t.cod_adquirente = a.cod_adquirente
 where empresa = :empresa
     and cod_emitente = :cod_emitente">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" 
                                ConvertEmptyStringToNull="False" DbType="String" />
                            <asp:SessionParameter Name=":codEmitente" 
                                SessionField="SCodLoja" ConvertEmptyStringToNull="False" DbType="String" />
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                Name=":cnpj" SessionField="SCNPJLoja" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
