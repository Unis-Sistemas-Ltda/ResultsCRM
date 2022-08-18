<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelVisitacaoFiltro.aspx.vb" Inherits="ResultsCRM.WFRelVisitacaoFiltro" ClientIDMode="Static" %>
<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../ResultsCRM.js" type="text/javascript"> </script>
    <style type="text/css"> </style>
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="TituloRelatorio">Relatório de Visitações</div>
        <div>
    
            <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;" 
                class="TextoCadastro_BGBranco">
                <tr>
                    <td class="Erro" colspan="3">
                        <asp:Label ID="LblErro" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        Seq. Visita:</td>
                    <td colspan="2" style="text-align: left; ">
                        <asp:TextBox ID="TxtSeqVisita" runat="server" CssClass="CampoCadastro" 
                            MaxLength="10" style="text-align: center" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        Período:
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtDataI" runat="server" 
                            CssClass="TextoCadastro" Width="70px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TxtDataI" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                        <asp:Label ID="Label18" runat="server" Height="16px" Text="&nbsp;a:&nbsp;"></asp:Label>
                        <asp:TextBox ID="TxtDataF" runat="server" 
                            CssClass="TextoCadastro" Width="70px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender3" runat="server" 
                        TargetControlID="TxtDataF" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
                        </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        Cód. Cliente:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtCodEmitente" runat="server" CssClass="CampoCadastro" 
                            Width="60px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        Nome Cliente:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtNomeEmitente" runat="server" CssClass="CampoCadastro" 
                            ToolTip="Informe o nome ou parte do nome do cliente." Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        <asp:Label ID="Label11" runat="server" Height="16px" 
                            Text="Vendedor/Representante:"></asp:Label>
                        &nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlRepresentante" runat="server" CssClass="CampoCadastro" 
                            Width="300px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        <asp:Label ID="Label20" runat="server" Height="16px" Text="Situação:"></asp:Label>
                        </td>
                    <td colspan="2">
                        <asp:DropDownList ID="DdlSituacao" runat="server" CssClass="CampoCadastro" 
                            Width="300px">
                            <asp:ListItem Value="-1">Todas</asp:ListItem>
                            <asp:ListItem Selected="True" Value="1">Somente agendadas</asp:ListItem>
                            <asp:ListItem Value="2">Somente concluídas</asp:ListItem>
                            <asp:ListItem Value="3">Somente canceladas</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        Modelo:</td>
                    <td colspan="2">
                        <asp:RadioButtonList ID="RblModelo" runat="server" CellPadding="5" 
                            CellSpacing="3" CssClass="TextoCadastro" RepeatColumns="2">
                            <asp:ListItem Selected="True" Value="1">Sem Follow-Up</asp:ListItem>
                            <asp:ListItem Value="2">Com Follow-Up</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;" colspan="2">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="BtnOk" runat="server" CssClass="Botao" TabIndex="1" 
                            Text="Visualizar" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
            </table>
    
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
