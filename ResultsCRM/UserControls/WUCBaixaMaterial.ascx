<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCBaixaMaterial.ascx.vb" Inherits="ResultsCRM.WUCBaixaMaterial" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>

<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc2" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table class="TextoCadastro_BGBranco" style="width:100%;">
    <tr>
        <td colspan="2" style="font-weight: bold">
            INSTALAÇÃO DE MATERIAL<asp:SqlDataSource 
                ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                
                SelectCommand="call sp_baixa_material_instalado(:tipo_material, :lotebaixa, :empresa, :estabelecimento, :cod_agente_tecico)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DdlTipoMaterial" Name=":tipo_material" 
                        DbType="String" PropertyName="SelectedValue" 
                        ConvertEmptyStringToNull="False" />
                    <asp:ControlParameter ControlID="TxtLoteBaixa" ConvertEmptyStringToNull="False" 
                        DbType="String" Name=":lotebaixa" PropertyName="Text" />
                    <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" DbType="String" 
                        ConvertEmptyStringToNull="False" DefaultValue="1" />
                    <asp:ControlParameter ControlID="DdlEstabelecimento" Name=":estabelecimento" DbType="String" 
                        PropertyName="SelectedValue" ConvertEmptyStringToNull="False" 
                        DefaultValue="1" />
                    <asp:ControlParameter ControlID="DdlAgenteTecnico" Name=":cod_agente_tecnico" DbType="String" 
                        PropertyName="SelectedValue" ConvertEmptyStringToNull="False" 
                        DefaultValue="" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Label ID="LblCodItem" runat="server"></asp:Label>
            <asp:Label ID="LblLote" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr> 
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro">
            Estabelecimento:</td>
        <td>
            <asp:DropDownList ID="DdlEstabelecimento" runat="server" CssClass="CampoCadastro" 
                Width="337px" Enabled="False">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro">
            Agente Técnico:</td>
        <td>
            <asp:DropDownList ID="DdlAgenteTecnico" runat="server" CssClass="CampoCadastro" 
                Width="337px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro">
            Tipo de Material:</td>
        <td>
            <asp:DropDownList ID="DdlTipoMaterial" runat="server" AutoPostBack="True" 
                CssClass="CampoCadastro" Width="140px">
                <asp:ListItem Value="R">Material de Retorno</asp:ListItem>
                <asp:ListItem Value="C">Material de Consumo</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="LblLabelLoteBaixa" runat="server" Height="16px" 
                Text="&nbsp;Lote para Baixa:"></asp:Label>
            <asp:TextBox ID="TxtLoteBaixa" runat="server" CssClass="CampoCadastro" 
                Width="70px" AutoPostBack="True"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarLote" runat="server" 
                ImageUrl="~/Imagens/search.png" 
                onclientclick="ShowEditModal('../Pesquisas/WFPLote.aspx','EditModalPopupClientes','IframeEdit');" 
                ToolTip="Pesquisar Lote" />
            <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
                runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
                TargetControlID="BtnFiltrarLote" PopupControlID="DivEditWindow" 
                OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
                BehaviorID="EditModalPopupLote">
            </cc1:ModalPopupExtender>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro">
            Material Solicitado:</td>
        <td>
            <asp:DropDownList ID="DdlTransferencia" runat="server" CssClass="CampoCadastro" 
                Width="337px" AutoPostBack="True" DataSourceID="SqlDataSource1" 
                DataTextField="cf_descricao" DataValueField="chave">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Transferência/Seq.:</td>
        <td>
            <asp:Label ID="LblCodTransferencia" runat="server" Font-Bold="True" Text="0"></asp:Label>
            /
            <asp:Label ID="LblSeqItemTransferencia" runat="server" Font-Bold="True" 
                Text="0" Width="235px"></asp:Label>
            <asp:CheckBox ID="ChkGerarRetorno" runat="server" AutoPostBack="True" 
                Text="Gerar Retorno" TextAlign="Left" />
            <asp:CheckBox ID="ChkGerarSolicitacaoMaterialTecnico" runat="server" AutoPostBack="True" 
                Text="&nbsp;&nbsp;Gerar Pendência de Remessa para Técnico" 
                TextAlign="Left" Visible="False" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Lbl_1" runat="server" Text="Item Retorno:" Visible="False"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtCodItemRetorno" runat="server" CssClass="CampoCadastro" 
                Width="70px" AutoPostBack="True" Visible="False"></asp:TextBox>
                        <asp:ImageButton ID="BtnFiltrarItem" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar Item" 
                
                onclientclick="ShowEditModal('../Pesquisas/WFPItem.aspx?textbox=TxtCodItem','EditModalPopupClientes','IframeEdit');" 
                Visible="False" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarItem" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </cc1:ModalPopupExtender>
            <asp:Label ID="LblDescricaoItem" runat="server" Font-Bold="True" 
                Height="17px" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Lbl_2" runat="server" Text="Lote Retorno:" Visible="False"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtLoteRetorno" runat="server" CssClass="CampoCadastro" 
                Visible="False" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Lbl_3" runat="server" Text="Qtde. Instalada:" Visible="False"></asp:Label>
        </td>
        <td>
            <asp:TextBox 
                ID="TxtQuantidadeBaixa" runat="server" 
                style="text-align:right" CssClass="CampoCadastro" Width="70px" 
                Visible="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" 
                Text="Registrar" />
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
