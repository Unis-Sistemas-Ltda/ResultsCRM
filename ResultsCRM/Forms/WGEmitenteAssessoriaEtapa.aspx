<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGEmitenteAssessoriaEtapa.aspx.vb" Inherits="ResultsCRM.WGEmitenteAssessoriaEtapa" %>

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
                    EmptyDataText="Nenhum registro foi incluído até o momento.">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                    <Columns>
                        <asp:BoundField DataField="seq_etapa" HeaderText="Seq." 
                            SortExpression="seq_etapa">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="data_inclusao" 
                            DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Inclusão" 
                            SortExpression="data_inclusao">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Etapa" SortExpression="descricao_etapa">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("descricao_etapa") %>'></asp:Label>
                                (<asp:Label ID="Label6" runat="server" Text='<%# Eval("cod_etapa") %>'></asp:Label>
                                )
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="data_inicio" DataFormatString="{0:dd/MM/yyyy}" 
                            HeaderText="Início" SortExpression="data_inicio">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="data_fim" DataFormatString="{0:dd/MM/yyyy}" 
                            HeaderText="Fim" SortExpression="data_fim">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="observacao" HeaderText="Observação" 
                            SortExpression="observacao">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton3" runat="server" CommandArgument='<%# Eval("seq_etapa") %>'
                                    CommandName="ALTERAR" ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Alterar o registro"
                                    
                                    Visible='<%# Iif( Session("GlBloquearCadastroEmitenteRepresentante") = "S", "False", "True" ) %>' />
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
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select eae.seq_etapa, eae.cod_etapa, eae.data_inicio, eae.data_fim, eae.observacao, ae.descricao descricao_etapa, eae.data_inclusao
  from emitente_assessoria_etapa eae inner join assessoria_etapa ae on ae.cod_etapa = eae.cod_etapa and ae.cod_assessoria = eae.cod_assessoria
 where eae.empresa = :empresa
   and eae.cod_emitente = :cod_emitente
   and eae.cod_assessoria = :cod_assessoria
   and eae.cod_fornecedor = :cod_fornecedor">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" Name=":cod_emitente"
                                SessionField="SCodEmitente" />
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                Name=":cod_assessoria" SessionField="SCodAssessoria" />
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                Name=":cod_fornecedor" SessionField="SCodFornecedorAssessoria" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
