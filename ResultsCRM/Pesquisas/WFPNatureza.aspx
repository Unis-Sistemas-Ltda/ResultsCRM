<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPNatureza.aspx.vb" Inherits="ResultsCRM.WFPNatureza" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pesquisa de Itens</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="TituloConsulta">Consulta de Natureza de Operação</div>
        <table class="TextoCadastro" 
         style="width: 500px; font-size: 7pt; background-color: #FFFFFF;">
            <tr>
                <td>
                    <asp:Label ID="LblFornecedor" runat="server" 
                        Text="Informe a descrição ou parte da descrição da natureza de operação:"></asp:Label>
                    </td>
                <td class="CelulaCampoCadastro" style="vertical-align: bottom">
                    <asp:TextBox ID="TxtNome" runat="server" Width="300px"></asp:TextBox></td>
                <td class="CelulaCampoCadastro" style="vertical-align: bottom">
                    <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Filtrar" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                        CssClass="CampoCadastro" Width="100%" Font-Size="7pt">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnSelecionar" runat="server" Height="16px" 
                                        ImageUrl="~/Imagens/BtnSelecionar.ico" Width="16px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Código">
                                <ItemTemplate>
                                    <asp:Label ID="LblCodigo" runat="server" Text='<%# Eval("cod_natur_oper") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="descricao" HeaderText="Descrição" />
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
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select cod_natur_oper, descricao
  from natureza_operacao
 where descricao like '%' || :nome || '%'
 order by cod_natur_oper">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtNome" Name=":nome" PropertyName="Text" 
                    ConvertEmptyStringToNull="False" />
            </SelectParameters>
        </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </form>
</body>
</html>