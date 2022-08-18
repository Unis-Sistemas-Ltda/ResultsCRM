<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimentoCausa.aspx.vb" Inherits="ResultsCRM.WGAtendimentoCausa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
    
        <asp:Label ID="Label1" runat="server" Height="17px" Text="Problema:&nbsp;" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:DropDownList ID="DdlProblema" runat="server" CssClass="CampoCadastro" 
            Width="275px" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;<br />
    
        <asp:Label ID="Label2" runat="server" Height="17px" Text="Causa:&nbsp;" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:DropDownList ID="DdlCausa" runat="server" CssClass="CampoCadastro" 
            Width="275px">
        </asp:DropDownList>
&nbsp;<asp:Button ID="BtnIncluir" runat="server" Text="Incluir" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" 
            EmptyDataText="&lt;br&gt;Nenhuma causa foi incluída até o momento." 
            ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Problema" SortExpression="assunto">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("assunto") %>'></asp:Label>
                        (<asp:Label ID="Label3" runat="server" Text='<%# Eval("cod_problema") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("assunto") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Causa" SortExpression="descricao">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                        (<asp:Label ID="Label4" runat="server" Text='<%# Eval("cod_causa") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_problema") & ";" & Eval("cod_causa") %>' CommandName="EXCLUIR" 
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
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select cp.seq_problema, e.cod_problema, e.assunto, ca.cod_causa, ca.descricao
  from chamado_problema_causa cc inner join causa ca on ca.empresa = cc.empresa and ca.cod_causa = cc.cod_causa
                                 inner join chamado_problema cp on cc.empresa = cp.empresa and cc.cod_chamado = cp.cod_chamado and cc.seq_problema = cp.seq_problema
                                 inner join problema_padrao e on e.empresa = cp.empresa and e.cod_problema = cp.cod_problema
 where cc.empresa     = :empresa
   and cc.cod_chamado = :cod_chamado
 order by e.assunto, e.cod_problema, ca.descricao, ca.cod_causa">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cod_chamado" SessionField="SCodAtendimento" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>