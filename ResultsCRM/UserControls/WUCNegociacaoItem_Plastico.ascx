<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoItem_Plastico.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoItem_Plastico" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
<%--este é o html para pesquisa de itens--%>
    <%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="350" scrolling="no">
        </iframe>
    </div>
<table class="TextoCadastro_BGBranco"
    style="width:495px;">
    <tr>
        <td colspan="6">
            <asp:Label ID="LblBaseIcmsSubstituicao" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodEmitente" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCNPJ" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblSeqItem" runat="server" Font-Bold="True" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="6" align="left">
            <img alt="Detalhe do Item da Negociação" 
                src="../Imagens/DetalheItemNegociacao.png" style="width: 420px; height: 18px" /></td>
    </tr>
    <tr>
        <td class="Erro" colspan="6" style="background-color: #FFFFEC">
            <asp:Label ID="LblErro" runat="server"></asp:Label>

        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Item:</td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:TextBox ID="TxtCodItem" runat="server" CssClass="CampoCadastro" 
                Width="90px" AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="BtnFiltrarItem" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPItem.aspx?textbox=TxtCodItem','EditModalPopupClientes','IframeEdit');" />

    <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarItem" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </cc1:ModalPopupExtender>

            <asp:Label ID="LblDescricaoItem" runat="server" Font-Bold="True" 
                Height="17px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            <asp:Label ID="Label1" runat="server" Text="Narrativa:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:TextBox ID="TxtNarrativa" runat="server" CssClass="CampoCadastro" 
                Width="385px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            Nat. Oper.:</td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:DropDownList ID="DdlNaturOper" runat="server" CssClass="CampoCadastro" 
                Width="386px" AutoPostBack="True" ToolTip="Informe a natureza da operação">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Quantidade:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtQuantidade" runat="server" AutoPostBack="True" 
                style="text-align:right" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Label2" runat="server" Height="16px" 
                Text="R$ Unitário:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxNumerico ID="TxtPrecoUnitario" runat="server" Width="75" 
                QtdCasas="4" AutoPostBack="True" />
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Label11" runat="server" Height="16px" Text="UD:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: left">
            <asp:DropDownList ID="DdlUD" runat="server" CssClass="CampoCadastro" 
                Width="75px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Qtde. UD:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtQuantidadeUD" runat="server" AutoPostBack="True" 
                style="text-align:right" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            R$ UD:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblValorUD" runat="server" Font-Bold="True" Text="0,0000" style="text-align:center"
                Width="60px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Label6" runat="server" Height="16px" Text="Desc.(R$):"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxNumerico ID="TxtValorDesconto" runat="server" Width="75" 
                QtdCasas="4" AutoPostBack="True" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            H:</td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxNumerico ID="TxtH" runat="server" QtdCasas="2" 
                Width="75" AutoPostBack="False" />
            </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            L/C:</td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxNumerico ID="TxtC" runat="server" QtdCasas="2" 
                Width="75" AutoPostBack="False" />
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            E:</td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxNumerico ID="TxtE" runat="server" QtdCasas="4" 
                Width="75" AutoPostBack="False" />
                        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="LblAux1" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux1" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
            </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LblAux2" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux2" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LblAux3" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux3" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="LblAux4" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux4" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
            </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LblAux5" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux5" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LblAux6" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux6" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="LblAux7" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux7" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
            </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LblAux8" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux8" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LblAux9" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux9" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="LblAux10" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux10" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LblAux11" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux11" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LblAux12" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux12" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            ICMS: R$</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblICMS" runat="server" Font-Bold="True">0,0000</asp:Label>
            <asp:Label ID="LblAliquotaICMS" runat="server" BackColor="#F0F0F0">0</asp:Label>
            <asp:Label ID="Label8" runat="server" BackColor="#F0F0F0" Text="%"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Label3" runat="server" Text="ICMS ST:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="Label7" runat="server" Text="R$"></asp:Label>
&nbsp;<asp:Label ID="LblICMSST" runat="server" Font-Bold="True">0,0000</asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Label5" runat="server" Text="IPI:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblIPI" runat="server" Font-Bold="True">0,0000</asp:Label>
            <asp:Label ID="LblAliquotaIPI" runat="server" BackColor="#F0F0F0">0</asp:Label>
            <asp:Label ID="Label9" runat="server" BackColor="#F0F0F0" Text="%"></asp:Label>
                        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Vlr.&nbsp;Merc,:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="Label12" runat="server" BackColor="#ECFFEC" 
                BorderColor="#CCFFFF" Text="R$" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
            <asp:Label ID="LblValorMercadoria" runat="server" Font-Bold="True" 
                style="text-align:right; background-color: #ECFFEC;" Width="60px" 
                BorderColor="#CCFFFF" BorderStyle="Solid" BorderWidth="1px">0,00</asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Label13" runat="server" Text="Vlr.Total:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: left">
            <asp:Label ID="Label14" runat="server" BackColor="#ECFFEC" 
                BorderColor="#CCFFFF" Text="R$" BorderStyle="Solid" BorderWidth="1px" 
                Font-Bold="True" Height="16px"></asp:Label>
            <asp:Label ID="LblValorTotal" runat="server" Font-Bold="True" Font-Size="8pt" 
                style="text-align:right; background-color: #ECFFEC;" Width="60px" 
                BorderColor="#CCFFFF" BorderStyle="Solid" BorderWidth="1px" 
                ForeColor="#535353" Height="16px">0,00</asp:Label>
        </td>
        <td class="CelulaCampoCadastro" colspan="2">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;<asp:Button ID="Button1" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
        </tr>
</table>