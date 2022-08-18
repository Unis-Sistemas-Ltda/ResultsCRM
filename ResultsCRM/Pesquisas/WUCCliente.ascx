<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCCliente.ascx.vb" Inherits="ResultsCRM.WUCCliente" %>
<style type="text/css">
body
{
    height: 100%
}
</style>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <form id="form1" runat="server">
    <div class="TituloConsulta">Consulta de Emitentes</div>
        <table class="TextoCadastro" 
        style="width: 400px; background-color: #FFFFFF;">
            <tr>
                <td>
                    <asp:Label ID="LblFornecedor" runat="server" 
                        Text="Informe o nome ou parte do nome do cliente:"></asp:Label>
                    </td>
                <td class="CelulaCampoCadastro">
                    <asp:TextBox ID="TxtNome" runat="server" Width="200px"></asp:TextBox></td>
                <td class="CelulaCampoCadastro">
                    <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Filtrar" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                        CssClass="CampoCadastro" Width="100%">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnSelecionar" runat="server" 
                                        CommandArgument='<%# Eval("cod_emitente") %>' Height="16px" 
                                        ImageUrl="~/Imagens/BtnSelecionar.ico" Width="16px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Código">
                                <ItemTemplate>
                                    <asp:Label ID="LblCodigo" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="nome" HeaderText="Nome" />
                            <asp:BoundField DataField="nome_abreviado" HeaderText="Fantasia" 
                                SortExpression="nome_abreviado" />
                        </Columns>
                        <PagerSettings FirstPageText="1&nbsp;" LastPageText="Última" 
                            Mode="NumericFirstLast" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Left" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="3">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand=" select cod_emitente, nome, nome_abreviado
   from emitente
  where tipo in (2,3)
    and nome like '%' || isnull(:nome,'') || '%'
    and trim(nome) &lt;&gt; ''
    and trim(nome) &lt;&gt; '-'
  order by nome">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtNome" Name=":nome" PropertyName="Text" 
                    ConvertEmptyStringToNull="False" />
            </SelectParameters>
        </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </form>
