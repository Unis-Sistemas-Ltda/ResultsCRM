<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFNegociacaoFiltro.aspx.vb" Inherits="ResultsCRM.WFNegociacaoFiltro" %>
<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>
<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../ResultsCRM.js" type="text/javascript"> </script>
</head>
<body style="border: 0px; padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server" defaultbutton="BtnAplicarFiltro">
    <div class="TituloMovimento">
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </asp:ScriptManager>
        Painel de Negociações</div>
    <div>
    
        <table style="padding: 0px; margin: 0px; border-style: none; border-width: 0px; width:100%; border-collapse: collapse;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td style="text-align: left; " class="Erro" colspan="10">
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                </td>
                <td style="text-align: right; " class="Erro" colspan="1">
                    <asp:Button ID="BtnRedirect" runat="server" BackColor="White" 
                        BorderColor="White" BorderStyle="None" BorderWidth="0px" ForeColor="White" 
                        Height="1px" Text="Redirect" Width="1px" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    Negociação:<br />
                </td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtNrNegociacao" runat="server" 
                        CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                        Width="60px" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td style="text-align: right; ">
                    Origem:</td>
                <td style="text-align: left; ">
            <asp:DropDownList ID="DdlFonteOrigem" runat="server" CssClass="CampoCadastro" 
                Width="170px" ClientIDMode="Static">
            </asp:DropDownList>
                </td>
                <td style="text-align: right; ">
                    <asp:Label ID="Label1" runat="server" Text="Cliente/Contato/CNPJ:"></asp:Label>
                </td>
                <td style="width: 170px;">
                    <asp:TextBox ID="TxtCliente" runat="server" Width="170px" 
                        CssClass="CampoCadastro" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td style="text-align: right; ">
                    Vendedor:</td>
                <td>
                    <asp:DropDownList ID="DdlVendedor" runat="server" 
                        CssClass="CampoCadastro" Width="195px" ClientIDMode="Static">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; " colspan="2">
                    Item:</td>
                <td style="text-align: left; width: 160px;">
                    <asp:DropDownList ID="ddlItem" runat="server" 
                        CssClass="CampoCadastro" Width="160px" ClientIDMode="Static">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; vertical-align: top;" rowspan="2">
                    Status:</td>
                <td style="text-align: left; vertical-align: top;" rowspan="2">
                    <asp:CheckBox ID="CBxInicial" runat="server" Checked="True" 
                        Text="Inicial" Height="17px" ClientIDMode="Static" />
                    <br />
                    <asp:CheckBox ID="CBxIntermediario" runat="server" Checked="True"  ClientIDMode="Static" 
                        Text="Intermediário" Height="17px" />
                    <br />
                    <asp:CheckBox ID="CBxFinal" runat="server" Text="Concluído" Height="17px"  
                        ClientIDMode="Static" />
                </td>
                <td style="text-align: right; ">
                    Funil:</td>
                <td style="text-align: left; " rowspan="2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlFunil" runat="server" AutoPostBack="True" 
                                ClientIDMode="Static" CssClass="CampoCadastro" Width="170px">
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="DdlEtapa" runat="server" ClientIDMode="Static" 
                                CssClass="CampoCadastro" Width="170px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="text-align: right;">
                    Pais:</td>
                <td style="vertical-align: top">
                    <asp:TextBox ID="TxtPais" runat="server" CssClass="CampoCadastro" Width="117px" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    Ag. Vendas:</td>
                <td>
                    <asp:DropDownList ID="ddlAgente" runat="server" 
                        CssClass="CampoCadastro" Width="195px" ClientIDMode="Static">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; " colspan="2">
                    Marca:</td>
                <td style="text-align: left; vertical-align: bottom">
                    <asp:DropDownList ID="DdlMarca" runat="server" CssClass="CampoCadastro" 
                        Width="160px" ClientIDMode="Static">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    <asp:Label ID="Label2" runat="server" Text="Etapa:"></asp:Label>
                </td>
                <td style="text-align: right;">
                    Município:</td>
                <td style="vertical-align: top">
                    <asp:TextBox ID="TxtMunicipio" runat="server" 
                        CssClass="CampoCadastro" Width="110px" ClientIDMode="Static"></asp:TextBox>
                &nbsp;
                    <asp:Label ID="Label3" runat="server" Height="16px" Text="UF:"></asp:Label>
                    <asp:TextBox ID="TxtUF" runat="server" 
                        CssClass="CampoCadastro" MaxLength="2" Width="30px" ClientIDMode="Static"></asp:TextBox>
                </td>
                <%--<td style="text-align: right;">
                    Ação:</td>
                <td>
                    <asp:DropDownList ID="ddlAcao" runat="server" 
                        CssClass="CampoCadastro" Width="195px" ClientIDMode="Static">
                    </asp:DropDownList>
                </td>--%>
                <td style="text-align: right;">
                    Carteira:</td>
                <td>
                    <asp:DropDownList ID="DdlCarteira" runat="server" 
                        CssClass="CampoCadastro" Width="195px" ClientIDMode="Static">
                    </asp:DropDownList>
                </td>
                <td colspan="2" style="text-align: right">
                    Exibir:</td>
                <td colspan="1" style="text-align: left">
                    <asp:DropDownList ID="DdlTop" runat="server" CssClass="CampoCadastro" 
                        Width="160px" ClientIDMode="Static">
                        <asp:ListItem Value="50">50 registros</asp:ListItem>
                        <asp:ListItem Value="100">100 registros</asp:ListItem>
                        <asp:ListItem Value="150">150 registros</asp:ListItem>
                        <asp:ListItem Value="200">200 registros</asp:ListItem>
                        <asp:ListItem Value="300">300 registros</asp:ListItem>
                        <asp:ListItem Value="400">400 registros</asp:ListItem>
                        <asp:ListItem Value="500">500 registros</asp:ListItem>
                        <asp:ListItem Value="1000">1000 registros</asp:ListItem>
                        <asp:ListItem Value="9999999" Selected="True">Todas</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
            <td style="text-align: right; ">
                    Status:</td>
                <td style="text-align: left; ">
                    <asp:DropDownList ID="DdlStatusNegociacao" runat="server" 
                        CssClass="CampoCadastro" Width="130px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    Fechamento:<br />
                </td>
                <td class="CelulaCampoCadastro">
                    <%--<uc1:TextBoxData ID="TxtData1" runat="server" />
                    <asp:Label ID="Label6" runat="server" Text="&nbsp;a" Height="17px"></asp:Label>&nbsp;
                    <uc1:TextBoxData ID="TxtData2" runat="server" />--%>
                    <asp:TextBox ID="TxtDataPrevisaoI" runat="server" CssClass="CampoCadastro" 
                        MaxLength="10" style="text-align: center" Width="70px" ClientIDMode="Static"></asp:TextBox>
                    <cc1:CalendarExtender ID="TxtDataPrevisaoI_CalendarExtender" runat="server" 
                        TargetControlID="TxtDataPrevisaoI" FirstDayOfWeek="Sunday" Format="dd/MM/yyyy" 
                        TodaysDateFormat="d MMMM yyyy" />
                    <asp:Label ID="Label6" runat="server" Height="16px" Text="&nbsp;a&nbsp;"></asp:Label>
                    <asp:TextBox ID="TxtDataPrevisaoF" runat="server" CssClass="CampoCadastro" 
                        MaxLength="10" style="text-align: center" Width="70px" CausesValidation="True"></asp:TextBox>
                    <cc1:CalendarExtender ID="TxtDataPrevisaoF_CalendarExtender" runat="server" 
                        TargetControlID="TxtDataPrevisaoF" FirstDayOfWeek="Sunday" Format="dd/MM/yyyy" 
                        TodaysDateFormat="d MMMM yyyy"/>
                </td>
                <td style="text-align: right; ">
                    Recontato:</td>
                <td>
                    <asp:TextBox ID="TxtDataRecontatoI" runat="server" 
                        CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                        Width="70px" ClientIDMode="Static"></asp:TextBox>
                         <cc1:CalendarExtender ID="TxtDataRecontatoI_CalendarExtender" runat="server" 
                        TargetControlID="TxtDataRecontatoI" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                    <asp:Label ID="Label5" runat="server" Height="16px" Text="&nbsp;a&nbsp;"></asp:Label>
                    <asp:TextBox ID="TxtDataRecontatoF" runat="server" 
                        CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                        Width="70px" CausesValidation="True"></asp:TextBox>
                        <cc1:CalendarExtender ID="TxtDataRecontatof_CalendarExtender" runat="server" 
                        TargetControlID="TxtDataRecontatoF" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                </td>
                <td style="text-align: right;">
                    Cadastramento:</td>
                <td>
                    <asp:TextBox ID="TxtDataCadastramentoI" runat="server" 
                        CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                        Width="70px" ClientIDMode="Static"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="TxtDataCadastramentoI" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                    <asp:Label ID="Label4" runat="server" Height="16px" Text="&nbsp;a&nbsp;"></asp:Label>
                    <asp:TextBox ID="TxtDataCadastramentoF" runat="server" 
                        CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                        Width="70px" CausesValidation="True"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TxtDataCadastramentoF" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                </td>
                <td>
                    <asp:Menu ID="MnuTipoVisualizacao" runat="server" Orientation="Horizontal"
                        RenderingMode="List">
                        <Items>
                            <asp:MenuItem ImageUrl="../Imagens/BtnListagem.png" Selected="True" Text=""
                                ToolTip="Exibição em lista" Value="WGNegociacao.aspx"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../Imagens/BtnLadoLado.png" Text=""
                                ToolTip="Exibição em pipeline" Value="WGNegociacaoPipe.aspx"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BorderColor="Blue" BorderStyle="Solid" BorderWidth="1px" />
                        <StaticMenuItemStyle BorderColor="White" BorderStyle="Solid" 
                            BorderWidth="1px" Height="16px" />
                        <StaticSelectedStyle BackColor="#E5E5E5" BorderColor="White" 
                            BorderStyle="Solid" BorderWidth="1px" />
                    </asp:Menu>
                </td>
                <td colspan="2" style="text-align: right; width: 160px;">
                    <asp:Button ID="BtnAplicarFiltro" runat="server" CssClass="Botao" Text="Aplicar Filtro" />
                    &nbsp;<asp:Button ID="BtnNovoRegistro" runat="server" CssClass="Botao" Text="Novo Registro" />
                </td>
            </tr>
            <tr>
                <td style="border-style: solid none none none; border-width: 1px; border-color: #C0C0C0; width: 100%; height: 565px;"  
                    colspan="11">
                    <uc1:WUCFrame ID="WUCFrameNegociacao" runat="server" Scrolling="auto"/>
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
