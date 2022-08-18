<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGVisitacaoHistorico.aspx.vb" Inherits="ResultsCRM.WGVisitacaoHistorico" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
            <table style="border-style: none; width:100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;" 
                class="TextoCadastro_BGBranco">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                            GridLines="None" Width="100%" AllowSorting="True" PageSize="14" 
                            EmptyDataText="&lt;br&gt;&lt;br&gt;Nenhum registro a exibir.">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="seq_visita" HeaderText="Seq. Visita" ReadOnly="True" 
                                    SortExpression="seq_visita" >
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="data_visita" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Data" SortExpression="data_visita">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="hora_visita" HeaderText="Hora" 
                                    SortExpression="hora_visita">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Vendedor/Representante" 
                                    SortExpression="nome_representante">
                                    <ItemTemplate>
                                        <asp:Label ID="Label21" runat="server" 
                                            Text='<%# Bind("nome_representante") %>'></asp:Label>
                                        (<asp:Label ID="Label20" runat="server" Text='<%# Eval("cod_representante") %>'></asp:Label>
                                        )
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="situacao_nome" HeaderText="Situação" 
                                    SortExpression="situacao_nome">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="titulo" HeaderText="Assunto" SortExpression="titulo">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." 
                                Mode="NumericFirstLast" PageButtonCount="15" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                            
                            
                            
                            SelectCommand="call sp_visitacao(:empresa, :estabelecimento, '', :cod_cliente, '','','', -1, '')">
                            <SelectParameters>
                                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" 
                                    ConvertEmptyStringToNull="False" DbType="String" />
                                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                    Name=":estabelecimento" SessionField="GlEstabelecimento" />
                                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                    Name=":cod_cliente" SessionField="SCodEmitente" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
    
    <div>
    
    </div>
    </form>
</body>
</html>
