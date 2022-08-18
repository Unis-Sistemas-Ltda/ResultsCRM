<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAcaoFollowUp.aspx.vb" Inherits="ResultsCRM.WGAcaoFollowUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div class="TituloCadastro">Cadastro de Ação</div>
    <div style="text-align: right">
    
        <asp:ImageButton ID="BtnIncluir" runat="server" AlternateText="INCLUIR" 
            ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
    </div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" CellPadding="4" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
            Width="100%" CssClass="TextoCadastro_BGBranco">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="cod_acao" HeaderText="Código" ReadOnly="True" 
                    SortExpression="cod_acao">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="envia_email" HeaderText="Envia E-mail" 
                    SortExpression="envia_email">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnAlterar" runat="server" AlternateText="ALTERAR" 
                            CommandArgument='<%# Eval("cod_acao") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                <asp:ImageButton ID="BtnAlterar" runat="server" AlternateText="ALTERAR" 
                    CommandArgument='<%# Eval("cod_acao") %>' />
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select * from acao_follow_up">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
