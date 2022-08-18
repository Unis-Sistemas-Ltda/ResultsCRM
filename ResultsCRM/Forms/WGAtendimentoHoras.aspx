<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimentoHoras.aspx.vb" Inherits="ResultsCRM.WGAtendimentoHoras" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        </div>
    <div class="TextoCadastro_BGBranco" 
        style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
        <table style="width:100%;">
            <tr>
                <td style="text-align: right">
                    <asp:ImageButton ID="BtnIncluirOS" runat="server" 
            ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource3" 
                        EmptyDataText="Nenhum registro de horas incluído até o momento." 
                        ForeColor="#333333" GridLines="None" Width="100%" ShowFooter="True">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="seq_hora" 
                                HeaderText="Seq." SortExpression="seq_hora" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nome_usuario" HeaderText="Analista" 
                                SortExpression="nome_usuario" >
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_inicial" HeaderText="Data Inicial" 
                                SortExpression="data_inicial">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Data Final" SortExpression="data_final">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("data_final") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("data_final") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    Total:
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Horas" SortExpression="total_horas">
                                <ItemTemplate>
                                    <asp:Label ID="LblTotalHoras" runat="server" Text='<%# Bind("total_horas") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("total_horas") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="LblTotalGeralHoras" runat="server" Text="0,0000"></asp:Label>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton3" runat="server" 
                                        CommandArgument='<%# Eval("seq_hora") %>' CommandName="ALTERAR" 
                                        ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar Registro" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Excluir">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton5" runat="server" 
                                        CommandArgument='<%# Eval("seq_hora") %>' CommandName="EXCLUIR" 
                                        ImageUrl="~/Imagens/BtnExcluir.png" 
                                        onclientclick="return confirm('ATENÇÃO: PROCEDIMENTO IRREVERSÍVEL! Deseja realmente excluir o registro?');" 
                                        ToolTip="Excluir Registro" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand=" select c.empresa, c.cod_chamado, c.seq_hora, c.descricao, c.data_inicial, c.data_final, c.cod_analista, a.nome_usuario, c.total_horas
   from chamado_hora_trabalhada c left outer join sysusuario a on a.cod_usuario = c.cod_analista
  where c.empresa     = :empresa
    and c.cod_chamado = :cod_chamado
  order by seq_hora">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:SessionParameter Name=":cod_chamado" SessionField="SCodAtendimento" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>