<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelOS.aspx.vb" Inherits="ResultsCRM.WFRelOS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>    
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />    
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloRelatorio">
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </asp:ScriptManager>
        Acompanhamento de Demanda</div>
    <div style="width:100%">
    
    </div>
    <table class="TextoCadastro_BGBranco" style="border-collapse: collapse">
        <tr>
            <td>
        <table 
            class="TextoCadastro_BGBranco" width="1049" 
                    style="border-collapse: collapse; font-size: 7pt;">
            <tr>
                <td style="text-align: right; " class="style9">
                    Nº Chamado:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtNrAtendimento" runat="server" 
                        CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                        Width="70px"></asp:TextBox>
                </td>
                <td style="text-align: right; " class="style8">
                    Cód.
                    Cliente:</td>
                <td style="vertical-align: top; " class="style1">
                    <asp:TextBox ID="TxtCodEmitente" runat="server" 
                        CssClass="CampoCadastro" Width="60px"></asp:TextBox>
&nbsp;</td>
                <td style="text-align: right;" class="style5">
                    Tipo Chamado:</td>
                <td style="vertical-align: top; " class="style2">
                    <asp:DropDownList ID="ddlTipoChamado" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; ">
                    Abertura:</td>
                <td>
                    <asp:TextBox ID="txtDataI" runat="server" 
                        CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender3" runat="server" 
                        TargetControlID="TxtDataI" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                    <asp:TextBox ID="TxtDataF" runat="server" 
                        CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender4" runat="server" 
                        TargetControlID="TxtDataF" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; " class="style9">
                    Chamado Cliente:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtOSCliente" runat="server" 
                        CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                        Width="70px"></asp:TextBox>
                </td>
                <td style="text-align: right;" class="style8">
                    Nome Cliente:</td>
                <td style="vertical-align: top" class="style1">
                    <asp:TextBox ID="TxtNomeEmitente" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o nome ou parte do nome do cliente." Width="195px"></asp:TextBox>
                </td>
                <td style="text-align: right;" class="style5">
                    <asp:Label ID="Label9" runat="server" Text="Tipo Status:"></asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddlTipoStatus" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                        <asp:ListItem Value="1234" Selected="True">(Todos)</asp:ListItem>
                        <asp:ListItem Value="1">Inicial</asp:ListItem>
                        <asp:ListItem Value="2">Intermediário</asp:ListItem>
                        <asp:ListItem Value="3">Final</asp:ListItem>
                        <asp:ListItem Value="12">Inicial / Intermediário</asp:ListItem>
                        <asp:ListItem Value="23">Intermediário / Final</asp:ListItem>
                        <asp:ListItem Value="13">Inicial / Final</asp:ListItem>
                        <asp:ListItem Value="4">Cancelado</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; ">
                    Início Execução OS:</td>
                <td>
                    <asp:TextBox ID="txtDataInicioExecucaoOSI" runat="server" 
                        CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender0" runat="server" 
                        TargetControlID="txtDataInicioExecucaoOSI" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                    <asp:TextBox ID="txtDataInicioExecucaoOSF" runat="server" 
                        CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender5" runat="server" 
                        TargetControlID="txtDataInicioExecucaoOSF" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; " class="style9">
                    OS Interna:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtOSInterna" runat="server" 
                        CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                        Width="70px"></asp:TextBox>
                </td>
                <td style="text-align: right;" class="style8">
                    Contato:</td>
                <td class="style1">
                    <asp:DropDownList ID="DdlContato" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right;" class="style5">
                    Status:</td>
                <td class="style2">
                    <asp:DropDownList ID="DdlStatus" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; vertical-align: bottom">
                    Término Execução OS:</td>
                <td style="vertical-align: bottom">
                    <asp:TextBox ID="txtDataTerminoExecucaoOSI" runat="server" 
                        CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender6" runat="server" 
                        TargetControlID="txtDataTerminoExecucaoOSI" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                    <asp:TextBox ID="txtDataTerminoExecucaoOSF" runat="server" 
                        CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender7" runat="server" 
                        TargetControlID="txtDataTerminoExecucaoOSF" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; " class="style9">
                    &nbsp;</td>
                <td style="text-align: left; ">
                    &nbsp;</td>
                <td style="text-align: right;" class="style8">
                    <asp:Label ID="LblPontoAtend" runat="server" Text="Ponto Atend.:"></asp:Label>
                </td>
                <td class="style1">
                    <asp:TextBox ID="TxtPontoDeAtendimento" runat="server" CssClass="CampoCadastro" 
                        
                        ToolTip="Informe o número, o nome ou parte do nome do ponto de atendimento" 
                        Width="195px"></asp:TextBox>
                </td>
                <td style="text-align: right;" class="style5">
                    <asp:Label ID="Label11" runat="server" Height="16px" Text="Analista:"></asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddlAnalista" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; vertical-align: bottom">
                    Inclusão da OS:</td>
                <td style="vertical-align: bottom">
                    <asp:TextBox ID="txtDataInclusaoOSI" runat="server" 
                        CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender8" runat="server" 
                        TargetControlID="txtDataInclusaoOSI" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                    <asp:TextBox ID="txtDataInclusaoOSF" runat="server" 
                        CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender9" runat="server" 
                        TargetControlID="txtDataInclusaoOSF" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; " class="style9">
                    &nbsp;</td>
                <td style="text-align: left; ">
                    &nbsp;</td>
                <td style="text-align: right;" class="style8">
                    <asp:Label ID="Label1" runat="server" Height="17px" Text="Assunto:"></asp:Label>
                </td>
                <td class="style1">
                    <asp:TextBox ID="TxtAssunto" runat="server" Width="190px" 
                        CssClass="CampoCadastro"></asp:TextBox>
                </td>
                <td style="text-align: right;" class="style5">
                    <asp:Label ID="LblTecnico" runat="server" Height="16px" Text="Técnico:"></asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddlAgenteTecnico" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; vertical-align: bottom">
                    Finalização da OS:</td>
                <td style="vertical-align: bottom">
                    <asp:TextBox ID="txtDataFinalizacaoOSI" runat="server" 
                        CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender10" runat="server" 
                        TargetControlID="txtDataFinalizacaoOSI" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                    <asp:TextBox ID="txtDataFinalizacaoOSF" runat="server" 
                        CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender11" runat="server" 
                        TargetControlID="txtDataFinalizacaoOSF" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; " class="style9" rowspan="2">
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/Imagens/BtnExcel.png" />
                    </td>
                <td style="text-align: left; ">
                    &nbsp;</td>
                <td style="text-align: right;" class="style8">
                    Serv. Solicitado:</td>
                <td class="style1">
                    <asp:TextBox ID="TxtServicoSolicitado" runat="server" 
                        CssClass="CampoCadastro" MaxLength="200"
                        Width="190px"></asp:TextBox>
                </td>
                <td style="text-align: right; vertical-align: top;" class="style5">
                    Tipo Cobrança:</td>
                <td class="style2" style="text-align: left; vertical-align: top">
                    <asp:DropDownList ID="ddlTipoCobrancaOS" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; vertical-align: bottom">
                    &nbsp;</td>
                <td style="text-align: right; vertical-align: bottom">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left; ">
                    &nbsp;</td>
                <td style="text-align: right;" class="style8">
                    Serv. Realizado:</td>
                <td class="style1">
                    <asp:TextBox ID="TxtServicoRealizado" runat="server" 
                        CssClass="CampoCadastro" MaxLength="200"
                        Width="190px"></asp:TextBox>
                </td>
                <td style="text-align: right; vertical-align: top;">
                        <asp:Label ID="LblRegiaoAtend" runat="server" Height="16px" 
                            Text="Região Atend.:"></asp:Label>
                    </td>
                <td style="text-align: left; vertical-align: top">
                        <asp:DropDownList ID="ddlRegiao" runat="server" CssClass="CampoCadastro" 
                            Width="200px">
                        </asp:DropDownList>
                    </td>
                <td style="text-align: right; vertical-align: bottom">
                    &nbsp;</td>
                <td style="text-align: right; vertical-align: bottom">
                    <asp:Button ID="Button1" runat="server" CssClass="Botao" Text="Recuperar" />
                </td>
            </tr>
            <tr>
                <td style="background-color: #FFFFE6;" class="Erro" colspan="8">
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="8">
                    &nbsp;</td>
            </tr>
            </table>
    
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                    <asp:GridView ID="GVRelOS" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                        Width="2000px" AllowSorting="True">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="seq" HeaderText="seq" ReadOnly="True" 
                                SortExpression="seq" Visible="False" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cod_pedido_venda" HeaderText="OS" ReadOnly="True" 
                                SortExpression="cod_pedido_venda" >
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cod_chamado" HeaderText="Chamado" 
                                SortExpression="cod_chamado">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="status_chamado" HeaderText="Status" 
                                SortExpression="status_chamado">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="motivo_cancelamento" HeaderText="Motivo" 
                                SortExpression="motivo_cancelamento" />
                            <asp:BoundField DataField="nome_emitente" HeaderText="Tomador" 
                                SortExpression="nome_emitente" />
                            <asp:BoundField DataField="data_chamado" DataFormatString="{0:dd/MM/yy HH:mm}" 
                                HeaderText="Data Abertura" SortExpression="data_chamado">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_encerramento" 
                                DataFormatString="{0:dd/MM/yy HH:mm}" HeaderText="Data Encerramento" 
                                SortExpression="data_encerramento">
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nome_emitente_atendimento" 
                                HeaderText="Banco/Empresa" SortExpression="nome_emitente_atendimento" />
                            <asp:BoundField DataField="ponto_atendimento" HeaderText="Ponto Atendimento" 
                                SortExpression="ponto_atendimento">
                            </asp:BoundField>
                            <asp:BoundField DataField="cidade" HeaderText="Município" 
                                SortExpression="cidade" />
                            <asp:BoundField DataField="uf" HeaderText="UF" SortExpression="uf" />
                            <asp:BoundField DataField="numero_uniorg" HeaderText="UNIORG" 
                                SortExpression="numero_uniorg" >
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="agentes_tecnicos" HeaderText="Técnicos" 
                                SortExpression="agentes_tecnicos" />
                            <asp:BoundField DataField="servicos_solicitados" 
                                HeaderText="Serviços Solicitados" SortExpression="servicos_solicitados" >
                                <ItemStyle Width="500px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="servicos_realizados" 
                                HeaderText="Serviços Realizados" SortExpression="servicos_realizados" >
                                <ItemStyle Width="500px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="observacao" HeaderText="Obs." 
                                SortExpression="observacao" />
                            <asp:BoundField DataField="data_inicio_execucao_os" 
                                DataFormatString="{0:dd/MM/yy HH:mm}" HeaderText="Início Execução OS" 
                                SortExpression="data_inicio_execucao_os" />
                            <asp:BoundField DataField="data_termino_execucao_os" 
                                DataFormatString="{0:dd/MM/yy HH:mm}" HeaderText="Término Execução OS" 
                                SortExpression="data_termino_execucao_os" />
                            <asp:BoundField DataField="tipo_cobranca" HeaderText="Tipo Cobrança" 
                                SortExpression="tipo_cobranca" />
                            <asp:BoundField DataField="analista" HeaderText="Analista" 
                                SortExpression="analista" />
                            <asp:BoundField DataField="data_inclusao_os" 
                                DataFormatString="{0:dd/MM/yy HH:mm}" HeaderText="Inclusão OS" 
                                SortExpression="data_inclusao_os" />
                            <asp:BoundField DataField="data_encerramento_os" 
                                DataFormatString="{0:dd/MM/yy HH:mm}" HeaderText="Finalização OS" 
                                SortExpression="data_encerramento_os" />
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
            <td>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:ControlParameter ControlID="TxtNrAtendimento" Name=":codchamado" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                            <asp:ControlParameter ControlID="TxtAssunto" Name=":assunto" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                            <asp:ControlParameter ControlID="DdlStatus" Name=":cod_status" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="ddlAnalista" Name=":cod_analista" 
                                PropertyName="SelectedValue" />
                            <asp:Parameter DefaultValue="-1" Name=":cod_usuario" />
                            <asp:ControlParameter ControlID="TxtCodEmitente" Name=":cod_emitente" 
                                PropertyName="Text" DefaultValue="" ConvertEmptyStringToNull="False" 
                                Type="String" />
                            <asp:ControlParameter ControlID="DdlContato" 
                                Name=":cod_contato" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="ddlTipoChamado" 
                                Name=":tipo_chamado" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="ddlTipoStatus" DefaultValue="" 
                                Name=":tipo_status" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtNomeEmitente" 
                                ConvertEmptyStringToNull="False" Name=":nome_emitente" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="TxtOSCliente" ConvertEmptyStringToNull="False" 
                                Name=":os_cliente" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="TxtOSInterna" ConvertEmptyStringToNull="False" 
                                Name=":os_interna" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="TxtPontoDeAtendimento" 
                                ConvertEmptyStringToNull="False" Name=":ponto_atendimento" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="ddlAgenteTecnico" Name=":agente_tecnico" 
                                PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="txtDataI" ConvertEmptyStringToNull="False" 
                                Name=":abertura_i" PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtDataF" ConvertEmptyStringToNull="False" 
                                Name=":abertura_f" PropertyName="Text" />
                            <asp:ControlParameter ControlID="txtDataInicioExecucaoOSI" 
                                ConvertEmptyStringToNull="False" DbType="String" Name=":data_inicio_execucao_i" 
                                PropertyName="Text" />
                            <asp:ControlParameter ControlID="txtDataInicioExecucaoOSF" 
                                ConvertEmptyStringToNull="False" DbType="String" Name=":data_inicio_execucao_f" 
                                PropertyName="Text" />
                            <asp:ControlParameter ControlID="txtDataTerminoExecucaoOSI" 
                                ConvertEmptyStringToNull="False" DbType="String" 
                                Name=":data_termino_execucao_i" PropertyName="Text" />
                            <asp:ControlParameter ControlID="txtDataTerminoExecucaoOSF" 
                                ConvertEmptyStringToNull="False" DbType="String" 
                                Name=":data_termino_execucao_f" PropertyName="Text" />
                            <asp:ControlParameter ControlID="txtDataInclusaoOSI" 
                                ConvertEmptyStringToNull="False" DbType="String" Name=":data_inclusao_os_i" 
                                PropertyName="Text" />
                            <asp:ControlParameter ControlID="txtDataInclusaoOSF" 
                                ConvertEmptyStringToNull="False" DbType="String" Name=":data_inclusao_os_f" 
                                PropertyName="Text" />
                            <asp:ControlParameter ControlID="txtDataFinalizacaoOSI" 
                                ConvertEmptyStringToNull="False" DbType="String" Name=":data_finalizacao_os_i" 
                                PropertyName="Text" />
                            <asp:ControlParameter ControlID="txtDataFinalizacaoOSF" 
                                ConvertEmptyStringToNull="False" DbType="String" Name=":data_finalizacao_os_f" 
                                PropertyName="Text" />
                            <asp:ControlParameter ControlID="ddlTipoCobrancaOS" 
                                ConvertEmptyStringToNull="False" DbType="String" Name=":cod_tipo_cobranca_os" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtServicoSolicitado" 
                                ConvertEmptyStringToNull="False" DbType="String" Name=":servico_solicitado" 
                                PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtServicoRealizado" 
                                ConvertEmptyStringToNull="False" DbType="String" Name=":servico_realizado" 
                                PropertyName="Text" />
                            <asp:ControlParameter ControlID="ddlRegiao" ConvertEmptyStringToNull="False" 
                                DbType="String" Name=":cod_regiao" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
