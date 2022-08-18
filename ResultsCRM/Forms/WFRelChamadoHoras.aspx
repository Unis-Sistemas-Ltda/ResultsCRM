<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelChamadoHoras.aspx.vb" Inherits="ResultsCRM.WFRelChamadoHoras" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloRelatorio">
        Relação de Chamados / Horas 
        por Cliente</div>
    <div class="Erro">
        <asp:Label ID="LblErro" runat="server"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </asp:ScriptManager>
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
                        CssClass="CampoCadastro" Width="60px" AutoPostBack="True"></asp:TextBox>
                    <asp:ImageButton ID="BtnFiltrarClienteAtendimento" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtCliente&amp;varmp=SCodClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClienteAtendimento','IframeEdit');" 
                Height="15px" Width="16px" />
    <cc1:ModalPopupExtender ID="BtnFiltrarClienteAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarClienteAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClienteAtendimento">
    </cc1:ModalPopupExtender>
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
                <td style="text-align: right">
                    Tipo Cobrança:</td>
                <td>
                    <asp:DropDownList ID="DdlTipoCobrancaOS" runat="server" 
                        CssClass="CampoCadastro" Width="195px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right">
                    Contrato:</td>
                <td>
            <asp:DropDownList ID="DdlContrato" runat="server" CssClass="CampoCadastro" 
                Width="200px">
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
                                    )<asp:Label ID="LblCodContrato" runat="server" Text='<%# Eval("contrato") %>' 
                                        Visible="False"></asp:Label>
                                    <br /> <br />
                                    <div style="padding-left: 30px">
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                        
                                            SelectCommand="call sp_rel_chamados_hora(:empresa, :cod_emitente, :nome_emitente, :abertura_i, :abertura_f, :encerramento_i, :encerramento_f, :cod_contrato, :cod_tipo_cobranca,2)">
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
                                            <asp:ControlParameter ControlID="LblCodContrato" ConvertEmptyStringToNull="False" 
                                                DbType="String" Name=":cod_contrato" PropertyName="Text" />
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
                                                HeaderText="Encerramento" ReadOnly="True" SortExpression="data_encerramento">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="pergunta" HeaderText="Pergunta / Problema" 
                                                ReadOnly="True" SortExpression="pergunta">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="300px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="narrativa" HeaderText="Resposta / Solução" 
                                                ReadOnly="True" SortExpression="narrativa">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="tempo" HeaderText="Tempo" ReadOnly="True" 
                                                SortExpression="tempo">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="70px" />
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
                                        Totais:<br />
                                        <asp:Label ID="Label19" style="text-align: right;" runat="server" 
                                            Text='<%# Eval("nome_tipo_1") %>' Width="125px"></asp:Label>
                                        <asp:Label ID="Label24" runat="server" style="text-align:right"
                                            Text='<%# Eval("qtd_total_tipo_1", "{0:F2}") %>' Width="75px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label20" runat="server" style="text-align: right;" 
                                            Text='<%# Eval("nome_tipo_2") %>' Width="125px"></asp:Label>
                                        <asp:Label ID="Label25" runat="server" style="text-align:right" 
                                            Text='<%# Eval("qtd_total_tipo_2", "{0:F2}") %>' Width="75px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label21" runat="server" style="text-align: right;" 
                                            Text='<%# Eval("nome_tipo_3") %>' Width="125px"></asp:Label>
                                        <asp:Label ID="Label26" runat="server" style="text-align:right" 
                                            Text='<%# Eval("qtd_total_tipo_3", "{0:F2}") %>' Width="75px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label22" runat="server" style="text-align: right;" 
                                            Text='<%# Eval("nome_tipo_4") %>' Width="125px"></asp:Label>
                                        <asp:Label ID="Label27" runat="server" style="text-align:right" 
                                            Text='<%# Eval("qtd_total_tipo_4", "{0:F2}") %>' Width="75px"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label23" runat="server" style="text-align: right;" 
                                            Text='<%# Eval("nome_tipo_5") %>' Width="125px"></asp:Label>
                                        <asp:Label ID="Label28" runat="server" style="text-align:right" 
                                            Text='<%# Eval("qtd_total_tipo_5", "{0:F2}") %>' Width="75px"></asp:Label></div>
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
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        SelectCommand="call sp_rel_chamados_hora(:empresa, :cod_emitente, :nome_emitente, :abertura_i, :abertura_f, :encerramento_i, :encerramento_f, :cod_contrato, :cod_tipo_cobranca,1)">
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
                            <asp:ControlParameter ControlID="DdlContrato" ConvertEmptyStringToNull="False" 
                                DbType="String" Name=":cod_contrato" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </div>
    <%--este é o html para funcionar o botão de incluir contatos--%><%--este é o html para funcionar o botão de incluir contatos--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="410" scrolling="no">
        </iframe>
    </div>
    </form>
</body>
</html>
