<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGClienteSLA.aspx.vb" Inherits="ResultsCRM.WGClienteSLA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.TextoCadastro_BGBranco
{
    font-size: 7pt;
    text-align: left;
    font-family: verdana;
    color: #666666;
    background-color: #FFFFFF;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <div style="text-align: right">
        <asp:ImageButton ID="BtnIncluir" runat="server" AlternateText="Novo Registro" 
            ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    </div>
    <div class="TextoCadastro_BGBranco">
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" 
            EmptyDataText="Nenhuma SLA vinculada até o momento.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
<asp:TemplateField HeaderText="SLA" SortExpression="descricao">
<ItemTemplate>
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Bind("descricao") %>'></asp:Label>
                        (<asp:Label ID="Label4" runat="server" Text='<%# Eval("cod_sla") %>'></asp:Label>
                        )
                    
</ItemTemplate>

    <EditItemTemplate>
        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
    </EditItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" 
                            CommandArgument='<%# Eval("cod_sla") %>' ToolTip="Editar o registro" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            CommandArgument='<%# Eval("cod_sla") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente excluir esta SLA?');" 
                            ToolTip="Excluir o registro." />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton4" runat="server" 
                            CommandArgument='<%# Eval("cod_sla") %>' CommandName="DETALHE" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="SLA por UF / Município" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="ALTERAR" />
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="System.Data.Odbc" 
            SelectCommand="SELECT s.cod_sla, s.descricao, se.prazo_chegada, se.prazo_encerramento
  FROM sla_emitente se inner join sla s
WHERE se.cod_emitente = :cod_emitente
ORDER BY descricao">
            <SelectParameters>
                <asp:SessionParameter Name="cod_emitente" SessionField="SCodEmitente" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    
    </div>
    </form>
</body>
</html>
