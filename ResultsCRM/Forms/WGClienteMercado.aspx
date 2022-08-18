<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGClienteMercado.aspx.vb" Inherits="ResultsCRM.WGClienteMercado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <table style="width: 100%; border-collapse: collapse;" 
         class="TextoCadastro_BGBranco">
        <tr>
            <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Height="16px" 
                    Text="Selecione o Grupo:&nbsp;"></asp:Label>
                <asp:DropDownList ID="DdlMercado" runat="server" CssClass="CampoCadastro" 
                    Width="225px">
                </asp:DropDownList>
&nbsp;<asp:Button ID="BtnAdicionar" runat="server" CssClass="Botao" 
                    Text="Incluir" />
            </td>
            <td style="text-align: right">
    
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%" 
            AllowSorting="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="cod_mercado" HeaderText="Cód. Grupo" 
                    SortExpression="cod_mercado" ReadOnly="True">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Preferencial">
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkPreferencial" runat="server" 
                             AutoPostBack="True" 
                            Checked='<%# Bind("pref") %>' 
                            oncheckedchanged="ChkPreferencial_CheckedChanged" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            CommandArgument='<%# Eval("cod_mercado") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir" 
                            
                            onclientclick="return confirm('Deseja realmente excluir o registro selecionado?');" 
                            
                            Visible='<%# Iif( Session("GlBloquearCadastroEmitenteRepresentante") = "S", "False", "True" ) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
    <div style="text-align: right">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select cm.cod_emitente, cm.cod_mercado, m.descricao, if isnull(cm.preferencial,'N') = 'S' then 'True' else 'False' endif pref
  from cliente_mercado cm inner join mercado m on cm.cod_mercado = m.cod_mercado
 where cod_emitente = :codigo
 order by m.descricao">
            <SelectParameters>
                <asp:SessionParameter Name=":codigo" SessionField="SCodEmitente" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
