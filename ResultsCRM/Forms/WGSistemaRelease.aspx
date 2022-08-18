<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGSistemaRelease.aspx.vb" Inherits="ResultsCRM.WGSistemaRelease" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloCadastro">
        Releases de Sistema</div>
    <div class="Erro" style="text-align: right">
        <br />
        <asp:Label ID="LblErro" runat="server" Height="20px"></asp:Label>
    </div>
    <div style="text-align: right">
    
        <asp:Label ID="Label1" runat="server" Height="17px" Text="Sistema:"></asp:Label>
        &nbsp;<asp:DropDownList ID="DdlSistema" runat="server" CssClass="CampoCadastro" 
            Width="200px" AutoPostBack="True">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Height="17px" Text="Release:"></asp:Label>
        &nbsp;<asp:TextBox ID="TxtRelease" runat="server" CssClass="CampoCadastro" 
            Width="50px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="BtnNovoRegistro" runat="server" 
            AlternateText="Novo Registro" ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
    </div>
    <div style="text-align: right">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" 
            AllowSorting="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="descricao" HeaderText="Sistema" 
                    SortExpression="descricao" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="release" HeaderText="Release" ReadOnly="True" 
                    SortExpression="release">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            CommandArgument='<%# Eval("release") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Confirma exclusão do registro selecionado?');" 
                            ToolTip="Excluir o registro" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="1º&nbsp;&nbsp;&nbsp;" Mode="NumericFirstLast" 
                NextPageText="Última" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select r.cod_sistema, s.descricao, r.&quot;release&quot;
   from sistema_release r inner join sistema s on r.cod_sistema = s.cod_sistema
 where r.cod_sistema = :sistema
 order by r.&quot;release&quot; desc">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlSistema" Name="sistema" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
