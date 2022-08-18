<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGCausaEfeitos.aspx.vb" Inherits="ResultsCRM.WGCausaEfeitos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
    
        <asp:Label ID="Label1" runat="server" Height="17px" Text="Efeito:&nbsp;" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:DropDownList ID="DdlEfeito" runat="server" CssClass="CampoCadastro" 
            Width="275px">
        </asp:DropDownList>
&nbsp;<asp:Button ID="BtnIncluir" runat="server" Text="Incluir" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" 
            EmptyDataText="&lt;br&gt;Nenhum efeito foi incluído até o momento." 
            ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="cod_efeito" HeaderText="Código" 
                    SortExpression="cod_efeito">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Efeito" 
                    SortExpression="descricao">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("cod_efeito") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja excluir o registro?')" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select e.cod_efeito, e.descricao
from efeito e inner join causa_efeito ce on e.empresa = ce.empresa and e.cod_efeito = ce.cod_efeito
where ce.empresa = :empresa
and ce.cod_causa = :cod_causa">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cod_causa" SessionField="SCodCausa" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
