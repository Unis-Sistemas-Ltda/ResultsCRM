<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCFalta.ascx.vb" Inherits="ResultsCRM.WUCFalta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloMovimento">Faltas de Agente Técnico<asp:ScriptManager 
        ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
</div>
<table style="width:100%; border-collapse: collapse;" class="TextoCadastro">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodigo" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Estabelecimento:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlEstabelecimento" runat="server" 
                CssClass="CampoCadastro" Width="300px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Agente técnico:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlAgenteTecnico" runat="server" CssClass="CampoCadastro" 
                Width="300px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Data:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDataFalta" runat="server" CssClass="CampoCadastro" 
                Width="75px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="TxtDataFalta" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="TxtDataFalta_MaskedEditExtender" 
                runat="server" BehaviorID="TxtDataFalta_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataFalta" UserDateFormat="DayMonthYear" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Hora início:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtHoraInicio" runat="server" CssClass="CampoCadastro" 
                MaxLength="5" Width="50px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Hora término:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtHoraTermino" runat="server" CssClass="CampoCadastro" 
                MaxLength="5" Width="50px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top">
            Motivo:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtMotivo" runat="server" CssClass="CampoCadastro" 
                Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Falta justificada:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxFaltaJustificada" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
