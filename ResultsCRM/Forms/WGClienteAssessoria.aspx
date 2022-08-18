<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGClienteAssessoria.aspx.vb"
    Inherits="ResultsCRM.WGClienteAssessoria" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%; border-collapse: collapse;" class="TextoCadastro_BGBranco">
        <tr>
            <td class="Erro" colspan="2">
                <asp:Label ID="LblErro" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BtnIncluir" runat="server" CssClass="Botao" Text="Incluir" />
            </td>
            <td style="text-align: right">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="TextoCadastro" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
                    Width="100%" AllowSorting="True" 
                    EmptyDataText="Nenhum registro incluído até o momento.">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                    <Columns>
                        <asp:TemplateField HeaderText="Fornecedor" SortExpression="nome_fornecedor">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("nome_fornecedor") %>'></asp:Label>
                                (<asp:Label ID="Label3" runat="server" Text='<%# Eval("cod_fornecedor") %>'></asp:Label>
                                )
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("nome_fornecedor") %>'></asp:Label>
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Assessoria" SortExpression="descricao_assessoria">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("descricao_assessoria") %>'></asp:Label>
                                (<asp:Label ID="Label4" runat="server" Text='<%# Eval("cod_assessoria") %>'></asp:Label>
                                )
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao_assessoria") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Etapa" SortExpression="descricao_etapa">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("descricao_etapa") %>'></asp:Label>
                                (<asp:Label ID="Label6" runat="server" Text='<%# Eval("cod_etapa") %>'></asp:Label>
                                )
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton3" runat="server" CommandArgument='<%# Eval("chave") %>'
                                    CommandName="ALTERAR" ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Alterar o registro"
                                    Visible='<%# Iif( Session("GlBloquearCadastroEmitenteRepresentante") = "S", "False", "True" ) %>' />
                                &nbsp;
                                <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("chave") %>'
                                    CommandName="EXCLUIR" ImageUrl="~/Imagens/BtnExcluir.png" OnClientClick="return confirm('Deseja realmente excluir o registro selecionado?');"
                                    ToolTip="Excluir" Visible='<%# Iif( Session("GlBloquearCadastroEmitenteRepresentante") = "S", "False", "True" ) %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="text-align: right">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select ea.cod_fornecedor, f.nome nome_fornecedor, ea.cod_assessoria, a.descricao descricao_assessoria, ea.cod_etapa, ae.descricao descricao_etapa,
       ea.empresa || ';' || ea.cod_emitente || ';' || ea.cod_assessoria || ';' || ea.cod_fornecedor chave
  from emitente_assessoria ea inner join assessoria a on a.cod_assessoria = ea.cod_assessoria
                              inner join emitente f on f.cod_emitente = ea.cod_fornecedor
                              inner join assessoria_etapa ae on ae.cod_assessoria = ea.cod_assessoria and ae.cod_etapa = ea.cod_etapa
 where ea.empresa = :empresa
   and ea.cod_emitente = :cod_emitente
 order by f.nome, a.descricao">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" Name=":cod_emitente"
                                SessionField="SCodEmitente" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
