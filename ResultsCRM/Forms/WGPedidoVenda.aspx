<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGPedidoVenda.aspx.vb" Inherits="ResultsCRM.WGPedidoVenda" %>
<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ordens de Serviço</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server" defaultbutton="BtnPesquisar">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
        </asp:ScriptManager>
    <div class="TituloMovimento">
        Painel de Pedidos de Venda</div>
    <div>
    
        <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td style="text-align: right; ">
                    Nº Pedido:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtCodPedidoVenda" runat="server" 
                        CssClass="CampoCadastro" MaxLength="15" style="text-align: center" 
                        Width="80px" 
                        
                        
                        ToolTip="Para informar mais de uma OS, informe os números separando por vírgula. Exemplo: 1282,1284, 1286"></asp:TextBox>
                </td>
                <td style="text-align: right; ">
                    Status Digitação:</td>
                <td style="vertical-align: top; ">
                    <asp:DropDownList ID="DdlStatus" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                        <asp:ListItem Value="0">(Todas)</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">Somente Abertas</asp:ListItem>
                        <asp:ListItem Value="2">Somente Encerradas</asp:ListItem>
                        <asp:ListItem Value="3">Somente Canceladas</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; ">
&nbsp;<asp:DropDownList ID="ddlAnalista" runat="server" 
                        CssClass="CampoCadastro" Width="200px" Visible="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    Cód.
                    Cliente:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtCodEmitente" runat="server" 
                        CssClass="CampoCadastro" Width="80px" AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    Contato:</td>
                <td style="vertical-align: top">
                    <asp:DropDownList ID="DdlContato" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; vertical-align: bottom">
&nbsp;<asp:TextBox ID="TxtTecnico" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o nome ou parte do nome do agente técnico" Width="190px" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    Nome Cliente:</td>
                <td style="text-align: left; width: 110px;">
                    <asp:TextBox ID="TxtNomeEmitente" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o nome ou parte do nome do cliente." Width="195px"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    &nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddlStatusRecebimento" runat="server" 
                        CssClass="CampoCadastro" Width="200px" Visible="False">
                        <asp:ListItem Value="0">(Todas)</asp:ListItem>
                        <asp:ListItem Value="1">Somente Pendentes</asp:ListItem>
                        <asp:ListItem Value="2">Somente Recebidas</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; vertical-align: bottom">
                    <asp:TextBox ID="TxtPontoAtendimento" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o nome ou parte do nome do cliente." Width="190px" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; " colspan="2">
            <asp:TextBox ID="TxtDataEncerramento" runat="server" CssClass="CampoCadastro" 
                Width="80px" Visible="False"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="TxtDataEncerramento" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="TxtDataEncerramento_MaskedEditExtender" 
                runat="server" BehaviorID="TxtDataPrevisaoFim_MaskedEditExtender" 
                Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataEncerramento" 
                UserDateFormat="DayMonthYear" />
                </td>
                <td style="text-align: right;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="text-align: right; vertical-align: bottom">
                    <asp:DropDownList ID="ddlRegiao" runat="server" 
                            CssClass="CampoCadastro" Width="195px" Visible="False">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; " colspan="2">
                    <asp:Button ID="BtnRegistrarRecebimento" runat="server" CssClass="Botao" 
                        Text="Registrar Recebimento" />
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="Label5" runat="server" Height="16px" Text="Exibir:"></asp:Label>
                    </td>
                <td>
                    <asp:DropDownList ID="DdlTop" runat="server" CssClass="CampoCadastro" 
                        Width="200px">
                        <asp:ListItem Value="50" Selected="True">50 registros</asp:ListItem>
                        <asp:ListItem Value="100">100 registros</asp:ListItem>
                        <asp:ListItem Value="150">150 registros</asp:ListItem>
                        <asp:ListItem Value="200">200 registros</asp:ListItem>
                        <asp:ListItem Value="300">300 registros</asp:ListItem>
                        <asp:ListItem Value="400">400 registros</asp:ListItem>
                        <asp:ListItem Value="500">500 registros</asp:ListItem>
                        <asp:ListItem Value="1000">1000 registros</asp:ListItem>
                        <asp:ListItem Value="9999999999">Todas</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; vertical-align: bottom">
                        <asp:Button ID="BtnLimparFiltro" runat="server" 
                            Text="Limpar Filtros" />
                        &nbsp;&nbsp;
                        <asp:Button ID="BtnPesquisar" runat="server" 
                            Text="Pesquisar" />
                </td>
            </tr>
            <tr>
                <td style="background-color: #FFFFE6;" class="Erro" colspan="5">
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                        GridLines="None" Width="100%" AllowSorting="True">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField SortExpression="alterado_tecnico">
                                <ItemTemplate>
                                    <asp:Label ID="LblCor" runat="server" BackColor="Blue" BorderColor="Blue" 
                                        BorderStyle="Solid" BorderWidth="1px" ForeColor="Blue" Height="10px" Text="." 
                                        ToolTip="Alterado pelo Técnico" 
                                        Visible='<%# Iif(Eval("alterado_tecnico") = "S", "True", "False") %>' 
                                        Width="10px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="seq" HeaderText="seq" ReadOnly="True" 
                                SortExpression="seq" Visible="False" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Nº OS" SortExpression="cod_pedido_venda">
                                <EditItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("cod_pedido_venda") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblCodPedidoVenda" runat="server" 
                                        Text='<%# Bind("cod_pedido_venda") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cliente" SortExpression="nome_emitente">
                                <EditItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("nome_emitente") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("nome_emitente") %>'></asp:Label>
                                    &nbsp;(<asp:Label ID="Label4" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:Label>
                                    )
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ponto_atendimento" HeaderText="Ponto Atend." 
                                SortExpression="ponto_atendimento">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Status Dig." SortExpression="status_digitacao">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" 
                                        Text='<%# Bind("status_digitacao") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblStatusDig" runat="server" 
                                        Text='<%# Bind("status_digitacao") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="BtnMarcar" runat="server" ForeColor="White" 
                                        onclick="BtnMarcar_Click">Marcar</asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CbxMarcado" runat="server" Visible="False" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status Rec." SortExpression="status_recebimento">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" 
                                        Text='<%# Bind("status_recebimento") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblStatusRec" runat="server" 
                                        Text='<%# Bind("status_recebimento") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="data_encerramento" DataFormatString="{0:dd/MM/yyyy}" 
                                HeaderText="Encerramento" SortExpression="data_encerramento">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Agente de Vendas" 
                                SortExpression="nome_agente_vendas">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" 
                                        Text='<%# Bind("nome_agente_vendas") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label04" runat="server" Text='<%# Bind("nome_agente_vendas") %>'></asp:Label>
                                    (<asp:Label ID="Label6" runat="server" Text='<%# Eval("cod_agente_vendas") %>'></asp:Label>
                                    )
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="agentes_tecnicos" HeaderText="Agente(s) Técnico(s)" 
                                SortExpression="agentes_tecnicos">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="status_tecnico" HeaderText="Status Técnico" 
                                SortExpression="status_tecnico">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="valor_total" DataFormatString="{0:F2}" 
                                HeaderText="Total (R$)" SortExpression="valor_total">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
                                        CommandArgument='<%# Eval("cod_pedido_venda") %>' CommandName="ALTERAR" 
                                        ImageUrl="~/Imagens/BtnEditar.png" 
                                        ToolTip="Clique para alterar ou consultar o registro" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
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
                <td colspan="5">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        SelectCommand="call sp_painel_pedido(:empresa, :ntop, :pedido, :status_digitacao, :status_recebimento, :cod_emitente, :cod_contato, :nome_emitente, :cod_analista, :ponto_atend, :data_encerramento, :tecnicos, :cod_regiao, :codemitenteexterno)">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:ControlParameter ControlID="DdlTop" Name=":top" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtCodPedidoVenda" Name=":pedido" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                            <asp:ControlParameter ControlID="DdlStatus" Name=":status_digitacao" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="ddlStatusRecebimento" Name=":status_recebimento" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtCodEmitente" Name=":cod_emitente" 
                                PropertyName="Text" DefaultValue="" ConvertEmptyStringToNull="False" 
                                Type="String" />
                            <asp:ControlParameter ControlID="DdlContato" 
                                Name=":cod_contato" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtNomeEmitente" 
                                ConvertEmptyStringToNull="False" Name=":nome_emitente" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="ddlAnalista" Name=":cod_analista" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtPontoAtendimento" 
                                ConvertEmptyStringToNull="False" Name=":ponto_atend" PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtDataEncerramento" 
                                ConvertEmptyStringToNull="False" DbType="String" Name=":data_encerramento" 
                                PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtTecnico" ConvertEmptyStringToNull="False" 
                                DbType="String" Name=":tecnicos" PropertyName="Text" />
                            <asp:ControlParameter ControlID="ddlRegiao" ConvertEmptyStringToNull="False" 
                                DbType="String" Name=":cod_regiao" PropertyName="SelectedValue" />
                            <asp:SessionParameter Name=":codemitenteexterno" SessionField="GlCodEmitenteExterno" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    OS&#39;S LISTADAS:
                    <asp:Label ID="LblNrOS" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
