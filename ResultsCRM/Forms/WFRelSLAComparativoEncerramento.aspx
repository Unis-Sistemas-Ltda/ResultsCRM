<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelSLAComparativoEncerramento.aspx.vb" Inherits="ResultsCRM.WFRelSLAComparativoEncerramento" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td class="TituloRelatorio" colspan="6">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" 
                        EnableScriptGlobalization="True">
                    </asp:ScriptManager>
                    Acompanhamento de SLA - Encerramento do Atendimento</td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    Nº Chamado:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtNrAtendimento" runat="server" 
                        CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                        Width="70px"></asp:TextBox>
                </td>
                <td style="text-align: right; ">
                    Cód.
                    Cliente:</td>
                <td style="vertical-align: top; ">
                    <asp:TextBox ID="TxtCodEmitente" runat="server" 
                        CssClass="CampoCadastro" Width="60px"></asp:TextBox>
                </td>
                <td style="text-align: right; " colspan="2">
                    <asp:Label ID="Label11" runat="server" Height="16px" Text="Analista:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlAnalista" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    Tipo Chamado:</td>
                <td style="text-align: left; ">
                    <asp:DropDownList ID="ddlTipoChamado" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    Nome Cliente:</td>
                <td style="vertical-align: top" >
                    <asp:TextBox ID="TxtNomeEmitente" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o nome ou parte do nome do cliente." Width="195px"></asp:TextBox>
                </td>
                <td style="text-align: right; ">
&nbsp;</td>
                <td style="text-align: right; ">
                    <asp:Label ID="LblTecnico" runat="server" Height="16px" Text="Técnico:"></asp:Label>
                    <asp:DropDownList ID="ddlAgenteTecnico" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    SLA:</td>
                <td style="text-align: left; ">
                    <asp:DropDownList ID="ddlsla" runat="server" CssClass="CampoCadastro" 
                        Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="LblPontoAtend" runat="server" Text="Ponto Atend.:"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="TxtPontoDeAtendimento" runat="server" CssClass="CampoCadastro" 
                        
                        ToolTip="Informe o número, o nome ou parte do nome do ponto de atendimento" 
                        Width="195px"></asp:TextBox>
                </td>
                <td style="text-align: right; vertical-align: bottom" rowspan="2">
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/Imagens/BtnExcel.png" ToolTip="Download no formato Excel" />
                </td>
                <td style="text-align: right; vertical-align: bottom">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    Encerramento:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtDataEncerramentoI" runat="server" CssClass="CampoCadastro" 
                        Width="80px"></asp:TextBox><cc1:CalendarExtender id="CalendarExtender11" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataEncerramentoI" todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
                    &nbsp;<asp:Label ID="Label17" runat="server" Height="16px" Text="a"></asp:Label>
&nbsp;<asp:TextBox ID="TxtDataEncerramentoF" runat="server" CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender id="CalendarExtender10" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataEncerramentoF" todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
                </td>
                <td style="text-align: right;">
                    Região Atend.:</td>
                <td >
                        <asp:DropDownList ID="ddlRegiao" runat="server" CssClass="CampoCadastro" 
                            Width="200px">
                        </asp:DropDownList>
                </td>
                <td style="text-align: right; vertical-align: bottom">
                    <asp:Button ID="BtnAplicarFiltro" runat="server" CssClass="Botao" 
                        Text="Aplicar Filtro" />
                </td>
            </tr>
        </table>
        <table style="border: thin groove #CCCCCC; width: 100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;">
        <tr><td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                        GridLines="None" Width="100%" AllowSorting="True">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="seq" HeaderText="seq" ReadOnly="True" 
                                SortExpression="seq" Visible="False" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cod_chamado" HeaderText="Nº Chamado" ReadOnly="True" 
                                SortExpression="cod_chamado" >
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="os_cliente" HeaderText="Chamado Cliente" 
                                SortExpression="os_cliente">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Tomador" SortExpression="nome_emitente">
                                <EditItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("nome_emitente") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("nome_emitente") %>'></asp:Label>
                                    &nbsp;(<asp:Label ID="Label6" runat="server" Text='<%# Eval("cod_emitente") %>'></asp:Label>
                                    )
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ponto de Atendimento" 
                                SortExpression="cod_emitente_atendimento">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" 
                                        Text='<%# Bind("cod_emitente_atendimento") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" 
                                        Text='<%# Eval("nome_emitente_atendimento") %>'></asp:Label>
                                    (<asp:Label ID="Label5" runat="server" 
                                        Text='<%# Bind("cod_emitente_atendimento") %>'></asp:Label>
                                    )
                                    <br />
                                    <asp:Label ID="Label8" runat="server" 
                                        Text='<%# Eval("nome_ponto_atendimento") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Analista" SortExpression="nome_analista">
                                <EditItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("nome_analista") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label16" runat="server" Text='<%# Bind("nome_analista") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="nome_analista_encerramento" 
                                HeaderText="Encerrado Por" SortExpression="nome_analista_encerramento" />
                            <asp:BoundField DataField="tecnicos" HeaderText="Técnicos" 
                                SortExpression="tecnicos" >
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_encerramento_sla" HeaderText="Previsto" 
                                SortExpression="data_encerramento_sla" 
                                DataFormatString="{0:dd/MM/yyyy HH:mm}">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_encerramento" HeaderText="Realizado" 
                                SortExpression="data_encerramento" DataFormatString="{0:dd/MM/yyyy HH:mm}">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="diferenca_horas" DataFormatString="{0:F2}" 
                                HeaderText="Dif. (h)" SortExpression="diferenca_horas">
                                <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Situação" SortExpression="cf_situacao">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cf_situacao") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblSituacao" runat="server" Text='<%# Bind("cf_situacao") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="desobrigado_sla" HeaderText="SLA">
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Left" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
                        SelectCommand="call sp_rel_sla_encerramento(:empresa, :cod_chamado, :cod_analista, :cod_emitente, :tipo_chamado, :nome_emitente, :ponto_atendimento, :agente_tecnico, :data_i, :data_f, :cod_regiao, :cod_sla)">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:ControlParameter ControlID="TxtNrAtendimento" Name=":cod_chamado" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                            <asp:ControlParameter ControlID="ddlAnalista" Name=":cod_analista" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtCodEmitente" Name=":cod_emitente" 
                                PropertyName="Text" DefaultValue="" ConvertEmptyStringToNull="False" 
                                Type="String" />
                            <asp:ControlParameter ControlID="ddlTipoChamado" 
                                Name=":tipo_chamado" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtNomeEmitente" 
                                ConvertEmptyStringToNull="False" Name=":nome_emitente" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="TxtPontoDeAtendimento" 
                                ConvertEmptyStringToNull="False" Name=":ponto_atendimento" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="ddlAgenteTecnico" Name=":agente_tecnico" 
                                PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter Name=":data_i" DefaultValue="" 
                                ControlID="TxtDataEncerramentoI" ConvertEmptyStringToNull="False" 
                                PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtDataEncerramentoF" 
                                ConvertEmptyStringToNull="False" Name=":data_f" PropertyName="Text" />
                            <asp:ControlParameter ControlID="ddlRegiao" ConvertEmptyStringToNull="False" 
                                DbType="String" Name=":cod_regiao" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="ddlsla" Name=":cod_sla" 
                                PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
        </tr>
        <tr>
        <td>&nbsp;</td>
        <td style="text-align: center; font-weight: bold">&nbsp;</td>
        <td colspan="2" 
                style="text-align: center; font-weight: bold; border-collapse: collapse;">&nbsp;</td>
        </tr>
        <tr>
        <td></td>
        <td style="text-align: center; font-weight: bold">Absoluto</td>
        <td style="text-align: center; font-weight: bold">Percentual</td>
        <td style="width: 60%">&nbsp;</td>
        </tr>
        <tr>
        <td style="text-align: right; font-weight: bold">Total</td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblTotalAbsoluto" runat="server" Text="0"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblTotalPercentual" runat="server" Text="0"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">&nbsp;</td>
        </tr>
        <tr>
        <td style="text-align: right; font-weight: bold">No Prazo</td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblTotalConforme" runat="server" Text="0"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblPercentualConforme" runat="server" Text="0"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">&nbsp;</td>
        </tr>
        <tr>
        <td style="text-align: right; font-weight: bold">Fora do Prazo</td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblTotalNaoConforme" runat="server" Text="0"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblPercentualNaoConforme" runat="server" Text="0"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">&nbsp;</td>
        </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
