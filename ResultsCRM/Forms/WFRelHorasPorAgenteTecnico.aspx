<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelHorasPorAgenteTecnico.aspx.vb" Inherits="ResultsCRM.WFRelHorasPorAgenteTecnico" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloRelatorio">
        Registro de Horas por Data / Agente Técnico
    </div>
    <div class="Erro">
        <asp:Label ID="LblErro" runat="server"></asp:Label>
    </div>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <br />
        <asp:Label ID="Label1" runat="server" Height="17px" Text="Período:&nbsp;"></asp:Label>
        <asp:TextBox ID="txtDataI" runat="server" CssClass="CampoCadastro" Width="80px"></asp:TextBox>
        <ajaxToolkit:MaskedEditExtender ID="txtDataI_MaskedEditExtender" runat="server" 
            BehaviorID="txtDataI_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
            MaskType="Date" TargetControlID="txtDataI" UserDateFormat="DayMonthYear" /><ajaxToolKit:CalendarExtender id="CalendarExtender11" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="txtDataI" todaysdateformat="d MMMM yyyy"></ajaxToolKit:CalendarExtender>
        <asp:Label ID="Label3" runat="server" Height="17px" Text="&nbsp;a&nbsp;"></asp:Label>
        <asp:TextBox ID="TxtDataF" runat="server" CssClass="CampoCadastro" Width="80px"></asp:TextBox><ajaxToolKit:CalendarExtender id="CalendarExtender1" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataF" todaysdateformat="d MMMM yyyy"></ajaxToolKit:CalendarExtender>
        <ajaxToolkit:MaskedEditExtender ID="TxtDataF_MaskedEditExtender" runat="server" 
            BehaviorID="TxtDataF_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
            MaskType="Date" TargetControlID="TxtDataF" UserDateFormat="DayMonthYear" />
        <asp:Label ID="Label2" runat="server" Height="17px" 
            Text="&nbsp;&nbsp;&nbsp;&nbsp;Agente Técnico:&nbsp;"></asp:Label>
        <asp:DropDownList ID="DdlAgente" runat="server" CssClass="CampoCadastro" 
            Width="200px">
        </asp:DropDownList>
        <asp:Label ID="Label6" runat="server" Height="17px" 
            Text="&nbsp;&nbsp;&nbsp;&nbsp;Modelo:&nbsp;"></asp:Label>
        <asp:DropDownList ID="DdlModelo" runat="server" CssClass="CampoCadastro" 
            Width="90px">
            <asp:ListItem Selected="True" Value="R">Resumido</asp:ListItem>
            <asp:ListItem Value="D">Detalhado</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label4" runat="server" Height="17px" 
            Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"></asp:Label>
                    <asp:Button ID="BtnAplicarFiltro" runat="server" CssClass="Botao" 
                        Text="Aplicar Filtro" />
        <asp:Label ID="Label5" runat="server" Height="17px" 
            Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"></asp:Label>
        <asp:Button ID="BtnImprimir" runat="server" CssClass="Botao" 
                        Text="Imprimir" onclientclick="self.print(); return false;" />
                <br />
                <br />
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
            Width="100%" AllowSorting="True" ShowFooter="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Data" SortExpression="entrega">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("entrega") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    TOTAL
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" 
                        Text='<%# Bind("entrega", "{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:BoundField DataField="cod_agente_tecnico" HeaderText="Código" 
                SortExpression="cod_agente_tecnico">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="nome" HeaderText="Nome do Agente Técnico" 
                SortExpression="nome">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Qtd. Horas" SortExpression="horas">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("horas") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="LblQtdTotalHoras" runat="server" Text="0,00"></asp:Label>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="LblQtdHoras" runat="server" 
                        Text='<%# Bind("horas", "{0:F2}") %>'></asp:Label>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo Cobrança" SortExpression="tipo_cobranca">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("tipo_cobranca") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LblDescricaoTipoCobrancaOS" runat="server" 
                        Text='<%# Bind("tipo_cobranca") %>'></asp:Label>
                    <asp:Label ID="LblCodTipoCobrancaOS" runat="server" 
                        Text='<%# Eval("cod_tipo_cobranca") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
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
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="call sp_rel_horas_agente_tecnico_resumido(:data_i, :data_f, :agente)">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtDataI" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":data_i" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDataF" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":data_f" PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlAgente" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":agente" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="call sp_rel_horas_agente_tecnico_detalhado(:data_i, :data_f, :agente)">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtDataI" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":data_i" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDataF" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":data_f" PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlAgente" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":agente" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="cod_emitente" 
            DataSourceID="SqlDataSource2" Font-Size="7pt" ForeColor="#333333" 
            GridLines="None" ShowFooter="True" Visible="False" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Data" SortExpression="entrega">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("entrega", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        TOTAL
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" 
                            Text='<%# Bind("entrega", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Agente Técnico" SortExpression="nome_tecnico">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("nome_tecnico") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("nome_tecnico") %>'></asp:Label>
                        (<asp:Label ID="Label7" runat="server" Text='<%# Eval("cod_agente_tecnico") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="cod_chamado" HeaderText="Chamado" 
                    SortExpression="cod_chamado">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_pedido_venda" HeaderText="OS" 
                    SortExpression="cod_pedido_venda">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Cliente" SortExpression="nome_cliente">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("nome_cliente") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("nome_cliente") %>'></asp:Label>
                        (<asp:Label ID="Label8" runat="server" Text='<%# Eval("cod_emitente") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Assunto Chamado" SortExpression="assunto">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("assunto") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("assunto") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Serviço Realizado" SortExpression="narrativa">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("narrativa") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("narrativa") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="hora_inicial" HeaderText="Hora Inicial" 
                    SortExpression="hora_inicial">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_final" HeaderText="Hora Final" 
                    SortExpression="hora_final">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Qtd. Horas" SortExpression="qtd_pedida">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("qtd_pedida") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="LblQtdTotalHoras" runat="server" Text="0,00"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblQtdHoras" runat="server" 
                            Text='<%# Bind("qtd_pedida", "{0:F2}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" />
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tipo Cobrança" SortExpression="tipo_cobranca">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("tipo_cobranca") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblDescricaoTipoCobrancaOS" runat="server" 
                            Text='<%# Bind("tipo_cobranca") %>'></asp:Label>
                        <asp:Label ID="LblCodTipoCobrancaOS" runat="server" 
                            Text='<%# Eval("cod_tipo_cobranca") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
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
        <br />
        <br />
        <asp:Label ID="LblTotalizacao" runat="server"></asp:Label>
    </div>
    
    </form>
</body>
</html>
