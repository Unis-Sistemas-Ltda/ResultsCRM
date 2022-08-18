<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFChamadoAcao.aspx.vb" Inherits="ResultsCRM.WFChamadoAcao" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
    
        <asp:Label ID="Label9" runat="server" Height="17px" Text="Seq. Ação:&nbsp;" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:Label ID="LblSeqAcao" runat="server" Text="0"></asp:Label>
        <br />
    
        <asp:Label ID="Label1" runat="server" Height="17px" Text="Problema:&nbsp;" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:DropDownList ID="DdlProblema" runat="server" CssClass="CampoCadastro" 
            Width="350px" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;<br />
    
        <asp:Label ID="Label2" runat="server" Height="17px" Text="Causa:&nbsp;" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:DropDownList ID="DdlCausa" runat="server" CssClass="CampoCadastro" 
            Width="350px" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;<br />
    
        <asp:Label ID="Label5" runat="server" Height="17px" Text="Efeito:&nbsp;" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:DropDownList ID="DdlEfeito" runat="server" CssClass="CampoCadastro" 
            Width="350px">
        </asp:DropDownList>
        <br />
    
        <asp:Label ID="Label7" runat="server" Height="17px" Text="Ação:&nbsp;" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:DropDownList ID="DdlAcao" runat="server" CssClass="CampoCadastro" 
            Width="350px">
        </asp:DropDownList>
        <br />
    
        <asp:Label ID="Label10" runat="server" Height="17px" Text="Responsável:&nbsp;" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:TextBox ID="TxtResponsavel" runat="server" CssClass="CampoCadastro" 
            Width="340px"></asp:TextBox>
        <br />
    
        <asp:Label ID="Label11" runat="server" Height="17px" 
            Text="Data Prevista:&nbsp;" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:TextBox ID="TxtDataPrevista" runat="server" CssClass="CampoCadastro" 
            Width="85px"></asp:TextBox> <ajaxToolkit:CalendarExtender ID="TxtDataPrevista_CalendarExtender" runat="server" 
                        TargetControlID="TxtDataPrevista" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
        <ajaxToolkit:MaskedEditExtender ID="TxtDataPrevista_MaskedEditExtender" 
            runat="server" BehaviorID="TxtDataPrevista_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
            MaskType="Date" TargetControlID="TxtDataPrevista" 
            UserDateFormat="DayMonthYear" />
        <br />
    
        <asp:Label ID="Label12" runat="server" Height="17px" 
            Text="Data Execução:&nbsp;" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:TextBox ID="TxtDataExecucao" runat="server" CssClass="CampoCadastro" 
            Width="85px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="TxtDataExecucao_CalendarExtender" runat="server" 
                        TargetControlID="TxtDataExecucao" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
        <ajaxToolkit:MaskedEditExtender ID="TxtDataExecucao_MaskedEditExtender" 
            runat="server" BehaviorID="TxtDataExecucao_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
            MaskType="Date" TargetControlID="TxtDataExecucao" 
            UserDateFormat="DayMonthYear" />
        <br />
    
        <asp:Label ID="Label13" runat="server" Height="17px" Text="Situação:&nbsp;" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:DropDownList ID="DdlSituacao" runat="server" CssClass="CampoCadastro" 
            Width="350px">
            <asp:ListItem Value="1">Não iniciada</asp:ListItem>
            <asp:ListItem Value="2">Iniciada</asp:ListItem>
            <asp:ListItem Value="3">Concluída</asp:ListItem>
            <asp:ListItem Value="4">Pausada</asp:ListItem>
            <asp:ListItem Value="5">Cancelada</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
    
        <asp:Label ID="Label8" runat="server" Height="17px" style="text-align:right"
            Width="100px"></asp:Label>
    
        <asp:Button ID="BtnGravar" runat="server" Text="Gravar" />
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Voltar" />
    
    </div>
    </form>
</body>
</html>
