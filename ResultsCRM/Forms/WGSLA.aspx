<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGSLA.aspx.vb" Inherits="ResultsCRM.WGSLA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloCadastro"> 
        Cadastro de SLA</div>
    <div style="text-align: right">
        <asp:ImageButton ID="BtnIncluir" runat="server" AlternateText="Novo Registro" 
            ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    </div>
    <div class="TextoCadastro_BGBranco">
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" EnableModelValidation="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="cod_sla" HeaderText="Código" ReadOnly="True" 
                    SortExpression="cod_sla">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Prazo Chegada" SortExpression="prazo_chegada">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Bind("prazo_chegada", "{0:F1}") %>'></asp:Label>
                        h.
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("prazo_chegada") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prazo Encerramento" 
                    SortExpression="prazo_encerramento">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# Bind("prazo_encerramento", "{0:F1}") %>'></asp:Label>
                        h.
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" 
                            Text='<%# Bind("prazo_encerramento") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" 
                            CommandArgument='<%# Eval("cod_sla") %>' />
                    </ItemTemplate>
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
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT cod_sla, descricao, prazo_chegada, prazo_encerramento
  FROM results.sla
ORDER BY descricao">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
