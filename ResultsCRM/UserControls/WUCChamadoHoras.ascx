<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCChamadoHoras.ascx.vb" Inherits="ResultsCRM.WUCChamadoHoras" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table class="TextoCadastro" style="width:100%;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Seq.:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblSeq" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Analista:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlAnalista" runat="server" CssClass="CampoCadastro" 
                Width="300px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td valign="top" style="text-align: right">
            Data/Hora Inicial:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDataInicio" runat="server" CssClass="CampoCadastro" 
                Width="75px"></asp:TextBox>
            <cc1:MaskedEditExtender ID="TxtDataInicio_MaskedEditExtender" runat="server" 
                BehaviorID="TxtDataInicio_MaskedEditExtender" Century="2000" 
                Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataInicio" UserDateFormat="DayMonthYear" />
            <asp:TextBox ID="TxtHoraInicial" runat="server" CssClass="CampoCadastro" 
                Width="60px"></asp:TextBox>
            <cc1:maskededitextender ID="MaskedEditExtender3" runat="server"
                TargetControlID="TxtHoraInicial" AcceptAMPM="false" MaskType="Time"
                Mask="99:99:99"/>
        </td>
    </tr>
    <tr>
        <td valign="top" style="text-align: right">
            Data/Hora Final:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDataTermino" runat="server" CssClass="CampoCadastro" 
                Width="75px"></asp:TextBox>
            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
                BehaviorID="TxtDataTermino_MaskedEditExtender" Century="2000" 
                Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataTermino" UserDateFormat="DayMonthYear" />
            <asp:TextBox ID="TxtHoraFinal" runat="server" CssClass="CampoCadastro" 
                Width="60px"></asp:TextBox>
            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                Mask="99:99:99" AcceptAMPM="false"
                MaskType="Time" TargetControlID="TxtHoraFinal"/>
            <asp:TextBox ID="TxtQtdHoras" runat="server" CssClass="CampoCadastro" 
                Width="75px" Enabled="False" Visible="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top" style="text-align: right">
            Descrição:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Height="100px" TextMode="MultiLine" Width="295px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <br />
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" />
        </td>
    </tr>
</table>
