<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGNegociacao.aspx.vb"
    Inherits="ResultsCRM.WGNegociacao" %>

<%@ Register Assembly="WebDataWindow" Namespace="Sybase.DataWindow.Web" TagPrefix="dw" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%;
    min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div>
        <table style="border-style: none; width: 100%; border-collapse: collapse;" class="TextoCadastro_BGBranco">
            <tr>
                <td style="background-color:#5D7B9D; font-weight:bold; color:White;">
                    <asp:Label ID="lblRegistro" runat="server" style="text-align:center" Width="100px" Text="Nº Registros:"></asp:Label>
                    <asp:Label ID="lblQuantidadeRegistros" runat="server" style="text-align:left" Width="300px"></asp:Label>
                    <asp:Label ID="lblvalor" runat="server" style="text-align:left" Width="100px" Text="Valor Total:"></asp:Label>
                    <asp:Label ID="lblValorTotal" runat="server" style="text-align:left" Width="200px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="100%"
                        AllowSorting="True" CssClass="CampoCadastro" PageSize="50" EmptyDataText="Nenhuma negociação a exibir">
                        <PagerSettings FirstPageText="1&nbsp;" Mode="NumericFirstLast" NextPageText="&gt;"
                            LastPageText="Últ." PreviousPageText="&lt;" PageButtonCount="14" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nº Neg." SortExpression="cod_negociacao">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("cod_negociacao") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblCodNegociacao" runat="server" Text='<%# Bind("cod_negociacao") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="carteira" HeaderText="Carteira" SortExpression="carteira">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nome_emitente" HeaderText="Cliente/Conta" SortExpression="nome_emitente">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="uf" HeaderText="UF" SortExpression="uf" />
                            <asp:BoundField DataField="municipio" HeaderText="Município" SortExpression="municipio" />
                            <asp:BoundField DataField="telefone" HeaderText="Fone" SortExpression="telefone" />
                            <asp:BoundField DataField="contato_nome" HeaderText="Contato" SortExpression="contato_nome" />
                            <asp:TemplateField HeaderText="Data Recontato" SortExpression="data_recontato">
                                <ItemTemplate>
                                    <asp:Label ID="LblDataRecontato" runat="server" Text='<%# Bind("data_recontato", "{0:dd/MM/yy HH:mm}") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("data_recontato") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="data_previsao_fechamento" DataFormatString="{0:dd/MM/yyyy}"
                                HeaderText="Data Fechamento" SortExpression="data_previsao_fechamento" />
                            <asp:BoundField DataField="data_followup" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data follow-up"
                                SortExpression="data_followup" />
                            <asp:TemplateField HeaderText="Etapa" SortExpression="etapa">
                                <ItemTemplate>
                                    <asp:Label ID="LblColorida" runat="server" Text="__"></asp:Label>
                                    <asp:Label ID="LblFunil" runat="server" Text='<%# Bind("etapa") %>'></asp:Label>
                                    <asp:Label ID="LblCor" runat="server" Text='<%# Eval("cor") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("etapa") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="nome_usuario" HeaderText="Agente de Vendas" SortExpression="nome_usuario" />
                            <asp:BoundField DataField="total_pedido" DataFormatString="{0:F2}" HeaderText="Valor Total (R$)"
                                SortExpression="total_pedido">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("cod_negociacao") %>'
                                        CommandName="COPIAR" ImageUrl="~/Imagens/copiar.png" ToolTip="Copiar negociação" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument=' <%# Eval("chave") %> '
                                        CommandName="ALTERAR" ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do registro" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnImprimir" runat="server" CommandArgument='<%# Eval("cod_negociacao") %>'
                                        CommandName="IMPRIMIR" ImageUrl="~/Imagens/BtnImprimir.gif" Width="17px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
                        
                        
                        SelectCommand="call sp_negociacao(:empresa, :top, :inicial, :intermediario, :final, :nomecliente, :etapa, :uf, :municipio, :codnegociacao, :agente, :item, :funil, :carteira, :vendedor, :data_cadastro_i, :data_cadastro_f, :data_recontato_i, :data_recontato_f, :cod_fonte, :cod_marca, :cod_status, :cod_gestor, :fechamento_ini, :fechamento_fim, :pais)">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":top" SessionField="S_PNG_DdlTop" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":inicial" SessionField="S_PNG_CBxInicial" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":intermediario" SessionField="S_PNG_CBxIntermediario"
                                ConvertEmptyStringToNull="False" DbType="String" />
                            <asp:SessionParameter Name=":final" SessionField="S_PNG_CBxFinal" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":nomecliente" SessionField="S_PNG_TxtCliente" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":etapa" SessionField="S_PNG_DdlEtapa" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":uf" SessionField="S_PNG_TxtUF" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":municipio" SessionField="S_PNG_TxtMunicipio" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":codnegociacao" SessionField="S_PNG_TxtNrNegociacao"
                                ConvertEmptyStringToNull="False" DbType="String" />
                            <asp:SessionParameter Name=":agente" SessionField="S_PNG_ddlAgente" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":item" SessionField="S_PNG_ddlItem" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":funil" SessionField="S_PNG_ddlFunil" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":carteira" SessionField="S_PNG_DdlCarteira" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":vendedor" SessionField="S_PNG_DdlVendedor" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":data_cadastro_i" SessionField="S_PNG_TxtDataCadastramentoI"
                                ConvertEmptyStringToNull="False" DbType="String" />
                            <asp:SessionParameter Name=":data_cadastro_f" SessionField="S_PNG_TxtDataCadastramentoF"
                                ConvertEmptyStringToNull="False" DbType="String" />
                            <asp:SessionParameter Name=":data_recontato_i" SessionField="S_PNG_TxtDataRecontatoI"
                                ConvertEmptyStringToNull="False" DbType="String" />
                            <asp:SessionParameter Name=":data_recontato_f" SessionField="S_PNG_TxtDataRecontatoF"
                                ConvertEmptyStringToNull="False" DbType="String" />
                            <asp:SessionParameter Name=":cod_fonte" SessionField="S_PNG_DdlFonteOrigem" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":cod_marca" SessionField="S_PNG_DdlMarca" ConvertEmptyStringToNull="False"
                                DbType="String" />
                            <asp:SessionParameter Name=":cod_status" SessionField="S_PNG_DdlStatusNegociacao"
                                ConvertEmptyStringToNull="False" DbType="String" />
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" Name=":cod_gestor"
                                SessionField="GlCodGestor" />
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                Name=":fechamento_ini" SessionField="S_PNG_TxtDataPrevisaoI" />
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                Name=":fechamento_fim" SessionField="S_PNG_TxtDataPrevisaoF" />
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                Name=":pais" SessionField="S_PNG_TxtPais" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
