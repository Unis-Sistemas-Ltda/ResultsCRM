<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCFollowUP.ascx.vb" Inherits="ResultsCRM.WUCFollowUP" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc2" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<table class="TextoCadastro_BGBranco" 
    style="border-style: 0; border-color: 0; width:100%; border-collapse: collapse;">
    <tr>
        <td colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
            <asp:ScriptManager ID="ScriptManager1" runat="server" 
                EnableScriptGlobalization="True">
            </asp:ScriptManager>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="font-weight: bold">
            FOLLOW-UP</td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro">
            Seq.:</td>
        <td>
            <asp:Label ID="LblSeqFollowUp" runat="server" Font-Bold="True" Text="0" 
                Width="145px"></asp:Label>
            <asp:Label ID="LblAcao" runat="server" BackColor="#ECFFEC" Font-Bold="True" style="text-align:center"
                Width="138px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro">
            <asp:Label ID="Lbl_1" runat="server" Text="Data:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtData" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="70px"></asp:TextBox><cc1:CalendarExtender ID="TxtDataRecontatoI_CalendarExtender" runat="server" 
                        TargetControlID="TxtData" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="TxtData_MaskedEditExtender" 
                runat="server" BehaviorID="TxtDataEntrega_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtData" 
                UserDateFormat="DayMonthYear" />
            <asp:Label ID="Label1" runat="server" Text=" " Width="104px"></asp:Label>
            <asp:CheckBox ID="CbxOcultarPortal" runat="server" Height="19px" 
                Text="Ocultar no Portal:" TextAlign="Left" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;" 
            class="CampoCadastro">
            <asp:Label ID="Lbl_2" runat="server" Text="Descrição:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Width="285px" Height="70px" MaxLength="1500" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" 
                Text="Incluir" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" Visible="False" />
        </td>
    </tr>
</table>
<%--este é o html para pesquisa de itens--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
<%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="350" scrolling="no">
        </iframe>
    </div>
