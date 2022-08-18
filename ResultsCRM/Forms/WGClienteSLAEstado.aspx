<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGClienteSLAEstado.aspx.vb" Inherits="ResultsCRM.WGClienteSLAEstado" %>

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
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin:0px">
    <form id="form1" runat="server">
    <div class="TextoCadastro_BGBranco">
    
        <table style="width:100%;">
            <tr>
                <td style="font-weight: bold">
        &nbsp;SLA:
        <asp:Label ID="LblDescricaoSLA" runat="server"></asp:Label>
        (<asp:Label ID="LblCodigoSLA" runat="server" Text="Label"></asp:Label>
        )</td>
                <td style="text-align: right">
        <asp:ImageButton ID="BtnIncluir" runat="server" AlternateText="Novo Registro" 
            ImageUrl="~/Imagens/BtnNovoRegistro.png" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" EnableModelValidation="True" 
            EmptyDataText="Nenhuma SLA vinculada até o momento.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="sigla_estado" HeaderText="UF" 
                    SortExpression="sigla_estado">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Prazo Chegada" SortExpression="prazo_chegada">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" 
                            Text='<%# Eval("prazo_chegada", "{0:F1}") %>'></asp:Label>
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
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Bind("prazo_chegada", "{0:F1}") %>'></asp:Label>
                        h.
                    </ItemTemplate>
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
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton4" runat="server" 
                            CommandArgument='<%# Bind("chave") %>' CommandName="EDITAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar o Registro" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            CommandArgument='<%# Eval("chave") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente excluir este registro?');" 
                            ToolTip="Excluir o registro." />
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
                </td>
            </tr>
            <tr>
                <td colspan="2">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="System.Data.Odbc" 
            SelectCommand="SELECT se.cod_pais cod_pais, se.cod_estado cod_estado, uf.sigla sigla_estado, se.prazo_chegada, se.prazo_encerramento, cod_pais || ';' || cod_estado || ';' || '' chave
  FROM sla_emitente_estado se inner join estado uf on se.cod_pais = uf.cod_pais and se.cod_estado = uf.cod_estado
 WHERE se.cod_emitente = :cod_emitente
      AND se.cod_sla = :cod_sla
ORDER BY sigla_estado">
            <SelectParameters>
                <asp:SessionParameter Name="cod_emitente" SessionField="SCodEmitente" />
                <asp:SessionParameter Name="cod_sla" SessionField="SCodSLA" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                </td>
            </tr>
        </table>
    
    </div>
    
    </form>
</body>
</html>
