<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGPosVendaContatos.aspx.vb" Inherits="ResultsCRM.WGPosVendaContatos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TextoCadastro_BGBranco" style="font-weight: bold">
    
        <asp:Label ID="Label1" runat="server" Text="CONTATOS DO CLIENTE" Width="80%"></asp:Label>
        <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="~/Imagens/BtnNovoRegistro.png" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" DataSourceID="SqlDataSource1" 
            EmptyDataText="Nenhum pedido de venda encontrado." 
            EnableModelValidation="True" Font-Bold="False" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="cod_contato" HeaderText="Cód." 
                    SortExpression="cod_contato" >
                </asp:BoundField>
                <asp:BoundField DataField="nome" 
                    HeaderText="Nome" SortExpression="nome">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="titulo" 
                    HeaderText="Título" SortExpression="titulo">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="email" HeaderText="E-mail" 
                    SortExpression="email" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ativo" 
                    HeaderText="Ativo" SortExpression="ativo">
                </asp:BoundField>
                <asp:TemplateField SortExpression="cod_contato">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cod_contato") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("cod_contato") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select cod_contato, upper(nome) nome, upper(titulo) titulo, email, isnull(ativo,'S') ativo
  from contatos
 where cod_emitente = :cod_farmacia
 order by ativo desc, nome asc">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_farmacia" SessionField="SCodEmitente" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
