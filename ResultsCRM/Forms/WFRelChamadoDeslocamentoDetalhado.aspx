<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelChamadoDeslocamentoDetalhado.aspx.vb" Inherits="ResultsCRM.WFRelChamadoDeslocamentoDetalhado" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloRelatorio">
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </asp:ScriptManager>
        Relação de Chamados / 
        Deslocamentos 
        por Cliente - Detalhado</div>
    <div class="Erro">
        <asp:Label ID="LblErro" runat="server"></asp:Label>
    </div>
    <div>
        <table style="width: 100%; border-collapse: collapse;">
            <tr>
                <td style="text-align: right">
                    Abertura:</td>
                <td>
                    <asp:TextBox ID="TxtDataAberturaI" runat="server" CssClass="CampoCadastro" 
                        Width="80px"></asp:TextBox><cc1:CalendarExtender id="CalendarExtender01" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataAberturaI" todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
                    <asp:Label ID="Label18" runat="server" Height="16px" Text="&nbsp;a&nbsp;" 
                        Width="16px"></asp:Label>
                    <asp:TextBox ID="TxtDataAberturaF" runat="server" CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender id="CalendarExtender2" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataAberturaF" todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
                </td>
                <td style="text-align: right">
                    Cód.
                    Cliente:</td>
                <td>
                    <asp:TextBox ID="TxtCodEmitente" runat="server" 
                        CssClass="CampoCadastro" Width="60px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Encerramento:</td>
                <td>
                    <asp:TextBox ID="TxtDataEncerramentoI" runat="server" CssClass="CampoCadastro" 
                        Width="80px"></asp:TextBox><cc1:CalendarExtender id="CalendarExtender3" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataEncerramentoI" todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
                    <asp:Label ID="Label17" runat="server" Height="16px" Text="&nbsp;a&nbsp;" 
                        Width="16px"></asp:Label>
                    <asp:TextBox ID="TxtDataEncerramentoF" runat="server" CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender id="CalendarExtender4" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataEncerramentoF" todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
                </td>
                <td style="text-align: right">
                    Nome Cliente:</td>
                <td>
                    <asp:TextBox ID="TxtNomeEmitente" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o nome ou parte do nome do cliente." Width="195px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="text-align: right">
                    Tipo Cobrança:</td>
                <td>
                    <asp:DropDownList ID="DdlTipoCobrancaOS" runat="server" 
                        CssClass="CampoCadastro" Width="195px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right">
                    <asp:Button ID="BtnAplicarFiltro" runat="server" CssClass="Botao" 
                        Text="Aplicar Filtro" />
                &nbsp;<asp:Button ID="BtnAplicarFiltro0" runat="server" CssClass="Botao" 
                        Text="Imprimir" onclientclick="self.print(); return false;" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="font-size: 8pt">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" 
                        GridLines="None" Width="100%" Font-Size="8pt">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Cliente" SortExpression="nome_emitente">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome_emitente") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                <div style="font-size:7pt">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("nome_emitente") %>' 
                                        Font-Bold="True"></asp:Label>
                                    (<asp:Label ID="LblCodEmitenteLinhaGrid" runat="server" 
                                        Text='<%# Eval("cod_emitente") %>' Font-Bold="True"></asp:Label>
                                    )<br /> <br />
                                    <div style="padding-left: 30px">
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                        
                                            SelectCommand="call sp_rel_chamados_deslocamento(:empresa, :cod_emitente, :nome_emitente, :abertura_i, :abertura_f, :encerramento_i, :encerramento_f, :cod_tipo_cobranca,2)">
                                        <SelectParameters>
                                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                                Name=":empresa" SessionField="GlEmpresa" />
                                            <asp:ControlParameter ControlID="LblCodEmitenteLinhaGrid" 
                                                ConvertEmptyStringToNull="False" DbType="String" Name=":cod_emitente" 
                                                PropertyName="Text" />
                                            <asp:ControlParameter ControlID="TxtNomeEmitente" 
                                                ConvertEmptyStringToNull="False" DbType="String" Name=":nome_emitente" 
                                                PropertyName="Text" />
                                            <asp:ControlParameter ControlID="TxtDataAberturaI" 
                                                ConvertEmptyStringToNull="False" DbType="String" Name=":abertura_i" 
                                                PropertyName="Text" />
                                            <asp:ControlParameter ControlID="TxtDataAberturaF" 
                                                ConvertEmptyStringToNull="False" DbType="String" Name=":abertura_f" 
                                                PropertyName="Text" />
                                            <asp:ControlParameter ControlID="TxtDataEncerramentoI" 
                                                ConvertEmptyStringToNull="False" DbType="String" Name=":encerramento_i" 
                                                PropertyName="Text" />
                                            <asp:ControlParameter ControlID="TxtDataEncerramentoF" 
                                                ConvertEmptyStringToNull="False" DbType="String" Name=":encerramento_f" 
                                                PropertyName="Text" />
                                            <asp:ControlParameter ControlID="DdlTipoCobrancaOS" 
                                                ConvertEmptyStringToNull="False" DbType="String" Name=":cod_tipo_cobranca" 
                                                PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        CellPadding="4" DataSourceID="SqlDataSource1" Font-Size="7pt" 
                                        ForeColor="#333333" GridLines="None" Width="950px">
                                        <AlternatingRowStyle ForeColor="#345C9A" />
                                        <Columns>
                                            <asp:BoundField DataField="cod_chamado" HeaderText="Nº Chamado" ReadOnly="True" 
                                                SortExpression="cod_chamado">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="cod_pedido_venda" HeaderText="Nº OS" ReadOnly="True" 
                                                SortExpression="cod_pedido_venda">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="data_encerramento" DataFormatString="{0:dd/MM/yyyy}" 
                                                HeaderText="Encerramento" ReadOnly="True" 
                                                SortExpression="data_encerramento" Visible="False">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="tecnico" HeaderText="Técnico" ReadOnly="True" 
                                                SortExpression="tecnico">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="pergunta" HeaderText="Pergunta / Problema" 
                                                ReadOnly="True" SortExpression="pergunta" Visible="False">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="300px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="narrativa" HeaderText="Descrição" 
                                                ReadOnly="True" SortExpression="narrativa" Visible="False">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom"/>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="local_origem" HeaderText="Local Origem" ReadOnly="True" 
                                                SortExpression="local_origem">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="local_destino" HeaderText="Local Destino" ReadOnly="True" 
                                                SortExpression="local_destino">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="data_entrega" DataFormatString="{0:dd/MM/yyyy}" 
                                                HeaderText="Data" ReadOnly="True" 
                                                SortExpression="data_entrega">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="qtd_pedida" HeaderText="Qtd. Km" ReadOnly="True" 
                                                SortExpression="qtd_pedida" DataFormatString="{0:F1}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="preco_unitario" HeaderText="R$/Km" ReadOnly="True" 
                                                SortExpression="preco_unitario" DataFormatString="{0:F2}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="valor_total_mercadoria" HeaderText="R$ Total" ReadOnly="True" 
                                                SortExpression="valor_total_mercadoria" DataFormatString="{0:F2}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="qtd_pedida" SortExpression="qtd_pedida" 
                                                Visible="False">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" 
                                                        Text='<%# Eval("qtd_pedida", "{0:F4}") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" 
                                                        Text='<%# Bind("qtd_pedida", "{0:F4}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipo Cobrança" 
                                                SortExpression="descricao_tipo_cobranca">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" 
                                                        Text='<%# Eval("descricao_tipo_cobranca") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" 
                                                        Text='<%# Bind("descricao_tipo_cobranca") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="70px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle Font-Bold="True" Font-Underline="True" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                        <br />
                                        <asp:Label ID="Label29" style="text-align: right;" runat="server" 
                                            Text='&lt;b&gt;Totais&lt;/b&gt;' Width="125px"></asp:Label>
                                        <asp:Label ID="Label30" runat="server" style="text-align:right"
                                            Text='&lt;b&gt;Km&lt;/b&gt;' Width="75px"></asp:Label>
                                        <asp:Label ID="Label31" runat="server" style="text-align:right" 
                                            Text="&lt;b&gt;R$&lt;/b&gt;" Width="75px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label19" style="text-align: right;" runat="server" 
                                            Text='<%# Eval("nome_tipo_1") %>' Width="125px"></asp:Label>
                                        <asp:Label ID="Label24" runat="server" style="text-align:right"
                                            Text='<%# Eval("qtd_total_tipo_1", "{0:F1}") %>' Width="75px"></asp:Label>
                                        <asp:Label ID="Label32" runat="server" style="text-align:right" 
                                            Text='<%# Eval("valor_total_tipo_1", "{0:F2}") %>' Width="75px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label20" runat="server" style="text-align: right;" 
                                            Text='<%# Eval("nome_tipo_2") %>' Width="125px"></asp:Label>
                                        <asp:Label ID="Label25" runat="server" style="text-align:right" 
                                            Text='<%# Eval("qtd_total_tipo_2", "{0:F1}") %>' Width="75px"></asp:Label>
                                        <asp:Label ID="Label33" runat="server" style="text-align:right" 
                                            Text='<%# Eval("valor_total_tipo_2", "{0:F2}") %>' Width="75px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label21" runat="server" style="text-align: right;" 
                                            Text='<%# Eval("nome_tipo_3") %>' Width="125px"></asp:Label>
                                        <asp:Label ID="Label26" runat="server" style="text-align:right" 
                                            Text='<%# Eval("qtd_total_tipo_3", "{0:F1}") %>' Width="75px"></asp:Label>
                                        <asp:Label ID="Label34" runat="server" style="text-align:right" 
                                            Text='<%# Eval("valor_total_tipo_3", "{0:F2}") %>' Width="75px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label22" runat="server" style="text-align: right;" 
                                            Text='<%# Eval("nome_tipo_4") %>' Width="125px"></asp:Label>
                                        <asp:Label ID="Label27" runat="server" style="text-align:right" 
                                            Text='<%# Eval("qtd_total_tipo_4", "{0:F1}") %>' Width="75px"></asp:Label>
                                        <asp:Label ID="Label35" runat="server" style="text-align:right" 
                                            Text='<%# Eval("valor_total_tipo_4", "{0:F2}") %>' Width="75px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label23" runat="server" style="text-align: right;" 
                                            Text='<%# Eval("nome_tipo_5") %>' Width="125px"></asp:Label>
                                        <asp:Label ID="Label28" runat="server" style="text-align:right" 
                                            Text='<%# Eval("qtd_total_tipo_5", "{0:F1}") %>' Width="75px"></asp:Label>
                                        <asp:Label ID="Label36" runat="server" style="text-align:right" 
                                            Text='<%# Eval("valor_total_tipo_5", "{0:F2}") %>' Width="75px"></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                            Font-Size="8pt" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="8pt" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        SelectCommand="call sp_rel_chamados_deslocamento(:empresa, :cod_emitente, :nome_emitente, :abertura_i, :abertura_f, :encerramento_i, :encerramento_f, :cod_tipo_cobranca,1)">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" 
                                ConvertEmptyStringToNull="False" DbType="String" />
                            <asp:ControlParameter ControlID="TxtCodEmitente" Name=":cod_emitente" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" DbType="String" />
                            <asp:ControlParameter ControlID="TxtNomeEmitente" 
                                ConvertEmptyStringToNull="False" Name=":nome_emitente" PropertyName="Text" 
                                DbType="String" />
                            <asp:ControlParameter ControlID="TxtDataAberturaI" 
                                Name=":abertura_i" PropertyName="Text" ConvertEmptyStringToNull="False" 
                                DbType="String" />
                            <asp:ControlParameter ControlID="TxtDataAberturaF" 
                                ConvertEmptyStringToNull="False" Name=":abertura_f" PropertyName="Text" 
                                DbType="String" />
                            <asp:ControlParameter ControlID="TxtDataEncerramentoI" 
                                ConvertEmptyStringToNull="False" Name=":encerramento_i" 
                                PropertyName="Text" DbType="String" />
                            <asp:ControlParameter Name=":encerramento_f" 
                                ControlID="TxtDataEncerramentoF" ConvertEmptyStringToNull="False" 
                                PropertyName="Text" DbType="String" />
                            <asp:ControlParameter ControlID="DdlTipoCobrancaOS" Name=":cod_tipo_cobranca" 
                                PropertyName="SelectedValue" ConvertEmptyStringToNull="False" 
                                DbType="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
