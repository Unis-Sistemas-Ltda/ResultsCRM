<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoItem_Farmacos2FD.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoItem_Farmacos2FD" %>
<%@ Register Src="../OutrosControles/TextBoxNumerico.ascx" TagName="TextBoxNumerico" TagPrefix="uc1" %>
<%@ Register Src="../OutrosControles/TextBoxInteiro.ascx" TagName="TextBoxInteiro" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../OutrosControles/TextBoxData.ascx" TagName="TextBoxData" TagPrefix="uc3" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<style type="text/css">
    .auto-style1 {
        height: 25px;
    }
    .auto-style2 {
        text-align: left;
        height: 25px;
    }
</style>
<body>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table>
    <tr>
        <td>
            <table class="TextoCadastro_BGBranco" style="border: thin groove #CCCCCC; width: 800px;">               
                <tr>
                    <td colspan="6" align="left">
                        <img alt="Detalhes da Ficha de desenvolvimento do Produto"
                            src="../Imagens/DetalheItemNegociacao2.png" style="width: 420px; height: 18px" /></td>
                </tr>
                <tr>
                    <td style="width: 95px; text-align: right;">Seq. Item:</td>
                    <td class="CelulaCampoCadastro" colspan="1">
                        <asp:Label ID="LblSeqItem" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="Erro" colspan="4">
                        <asp:Label ID="LblErro" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style1">Item:</td>
                    <td class="auto-style2" colspan="5">
                        <asp:TextBox ID="TxtCodItem" runat="server" CssClass="CampoCadastro"
                            Width="90px" AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="BtnFiltrarItem" runat="server"
                            ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar"
                            OnClientClick="ShowEditModal('../Pesquisas/WFPItem.aspx?textbox=TxtCodItem','EditModalPopupClientes','IframeEdit');" />

                        <asp:Label ID="LblDescricaoItem" runat="server" Font-Bold="True"
                            Height="17px"></asp:Label>
                    </td>
                </tr>
  
                <tr>
                    <td style="vertical-align: top; text-align: right;">
                        <asp:Label ID="Label19" runat="server" Text="Nome do Produto:"></asp:Label>
                    </td>

                    <td colspan="5">
                        <asp:TextBox ID="TxtFdNomeProduto" runat="server" CssClass="CampoCadastro"
                            Width="600px"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td style="vertical-align: top; text-align: right;">
                        <asp:Label ID="Label18" runat="server" Text="Ação Desejada/Finalidade:"></asp:Label>
                    </td>

                    <td colspan="5">
                        <asp:TextBox ID="TxtFdAcaoDesejadaProduto" runat="server" CssClass="CampoCadastro"
                            Height="25px" TextMode="MultiLine" Width="600px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="CelulaCampoCadastro" style="text-align: right">
                        <asp:Label ID="Label4" runat="server" Text="Coloração do Produto:"></asp:Label></td>
                    <td colspan="5">
                        <asp:DropDownList ID="DdlFdColoracao" runat="server"
                            CssClass="CampoCadastro" Width="606px" Height="16px">
                            <asp:ListItem Value="-1">-- Selecione --</asp:ListItem>
                            <asp:ListItem Value="1">Incolor</asp:ListItem>
                            <asp:ListItem Value="2">Com Pigmento</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                 <tr>
                    <td style="vertical-align: top; text-align: right;">
                        <asp:Label ID="Label20" runat="server" Text="Cor de referência:"></asp:Label>
                    </td>

                    <td colspan="5">
                        <asp:TextBox ID="TxtFdCorReferencia" runat="server" CssClass="CampoCadastro"
                            Width="600px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="CelulaCampoCadastro" style="text-align: right">
                        <asp:Label ID="Label6" runat="server" Text="Definição de Fragrância:"></asp:Label></td>
                    <td colspan="5">
                        <asp:DropDownList ID="DdlFdOdor" runat="server"
                            CssClass="CampoCadastro" Width="383px">
                            <asp:ListItem Value="-1">-- Selecione --</asp:ListItem>
                            <asp:ListItem Value="1">Inodoro</asp:ListItem>
                            <asp:ListItem Value="2">Sem adição de Fragrância</asp:ListItem>
                            <asp:ListItem Value="3">Com adição de Fragrância</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="CelulaCampoCadastro" style="text-align: right">
                        <asp:Label ID="Label10" runat="server" Text="Direcionamento Olfativo da Fragrância:"></asp:Label></td>
                    <td colspan="5">
                        <asp:DropDownList ID="DdlFdOdorDirecionamento" runat="server"
                            CssClass="CampoCadastro" Width="383px">
                            <asp:ListItem Value="-1">-- Selecione --</asp:ListItem>
                            <asp:ListItem Value="1">Doce</asp:ListItem>
                            <asp:ListItem Value="2">Floral</asp:ListItem>
                            <asp:ListItem Value="3">Frutal</asp:ListItem>
                            <asp:ListItem Value="4">Amadeirado</asp:ListItem>
                            <asp:ListItem Value="5">Suave</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: right;">
                        <asp:Label ID="Label21" runat="server" Text="Fragrância de referência:"></asp:Label>
                    </td>

                    <td colspan="5">
                        <asp:TextBox ID="TxtFdOdorReferencia" runat="server" CssClass="CampoCadastro"
                            Width="600px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: right;">
                        <asp:Label ID="Label22" runat="server" Text="Descrição do Produto:"></asp:Label>
                    </td>

                    <td colspan="5">
                        <asp:TextBox ID="TxtFdDescricaoProduto" runat="server" CssClass="CampoCadastro"
                            Height="25px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: right;">
                        <asp:Label ID="Label11" runat="server" Text="Produto de Referência:"></asp:Label>
                    </td>

                    <td colspan="5">
                        <asp:TextBox ID="TxtFdProdutoReferencia" runat="server" CssClass="CampoCadastro"  Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: right;">
                        <asp:Label ID="Label12" runat="server" Text="Volume da Embalagem:"></asp:Label>
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="TxtFdVolumeEmbalagem" runat="server" Height="25px" TextMode="MultiLine" CssClass="CampoCadastro"  Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="CelulaCampoCadastro" style="text-align: right">
                        <asp:Label ID="Label14" runat="server" Text="Coloração da Embalagem:"></asp:Label>

                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="DdlFdCorEmbalagem" runat="server"
                            CssClass="CampoCadastro" Width="200px">
                            <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                            <asp:ListItem Value="1">Transparente</asp:ListItem>
                            <asp:ListItem Value="2">Branca</asp:ListItem>
                            <asp:ListItem Value="3">Preta</asp:ListItem>
                            <asp:ListItem Value="4">Ambar</asp:ListItem>
                            <asp:ListItem Value="5">Colorida</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label16" runat="server" Text="Em embalagens pretas, não é possível codificar data e validade, sendo necessário um espaço retangulo no rótulo"></asp:Label>
                        
                    </td>
                </tr>
                <tr>
                    <td class="CelulaCampoCadastro" style="text-align: right">
                        <asp:Label ID="Label23" runat="server" Text="Tipo de Material da Embalagem:"></asp:Label>

                    </td>
                    <td colspan="5">
                        <asp:DropDownList ID="DdlFdMpEmbalagem" runat="server"
                            CssClass="CampoCadastro" Width="600px">
                            <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                            <asp:ListItem Value="1">Vidro</asp:ListItem>
                            <asp:ListItem Value="2">Plástico</asp:ListItem>                          
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                     <td class="CelulaCampoCadastro" style="text-align: right">
                        <asp:Label ID="Label24" runat="server" Text="Tipo de Embalagem:"></asp:Label>

                    </td>
                    <td colspan="5">
                        <asp:DropDownList ID="DdlFdTipoEmbalagem" runat="server"
                            CssClass="CampoCadastro" Width="600px">
                            <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                            <asp:ListItem Value="1">Bisnaga</asp:ListItem>
                            <asp:ListItem Value="2">Pote</asp:ListItem>                          
                            <asp:ListItem Value="3">Frasco</asp:ListItem>  
                            <asp:ListItem Value="99">Outros</asp:ListItem>  
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                     <td class="CelulaCampoCadastro" style="text-align: right">
                        <asp:Label ID="Label25" runat="server" Text="Quantidade a Produzir:"></asp:Label>

                    </td>
                    <td colspan="5">
                        <asp:DropDownList ID="DdlFdQtdProduzir" runat="server"
                            CssClass="CampoCadastro" Width="600px">
                            <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                            <asp:ListItem Value="1">100 Un</asp:ListItem>
                            <asp:ListItem Value="2">500 Un</asp:ListItem>                          
                            <asp:ListItem Value="3">1000 Un</asp:ListItem>  
                            <asp:ListItem Value="4">1500 Un</asp:ListItem>  
                            <asp:ListItem Value="5">2000 Un</asp:ListItem>  
                            <asp:ListItem Value="6">2500 Un</asp:ListItem>  
                            <asp:ListItem Value="7">3000 Un</asp:ListItem>  
                            <asp:ListItem Value="8">3500 Un</asp:ListItem>  
                            <asp:ListItem Value="9">4000 Un</asp:ListItem>  
                            <asp:ListItem Value="10">4500 Un</asp:ListItem>  
                            <asp:ListItem Value="11">5000 Un</asp:ListItem>  
                            <asp:ListItem Value="12">Acima 5000 Un</asp:ListItem>  
                        </asp:DropDownList>
                    </td>
                </tr>



                
                <tr>                    
                    <td colspan="6" style="text-align: right">
                        <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar"
                            Width="60px" />
                        <asp:Button ID="Button1" runat="server" CssClass="Botao" Text="Voltar" />
                    </td>
                </tr>
            </table>
        </td>
        
    </tr>
</table>

<%--este é o html para pesquisa de itens--%>
<cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
    runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone"
    TargetControlID="BtnFiltrarItem" PopupControlID="DivEditWindow"
    OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
    BehaviorID="EditModalPopupClientes">
</cc1:ModalPopupExtender>
<%--botões padrão que ficam ocultos, são necessários, não remover--%>
<div class="popup_Buttons" style="display: none">
    <input id="ButtonEditDone" value="Done" type="button" />
    <input id="ButtonEditCancel" value="Cancel" type="button" />
</div>
<%--frame onde é mostrado o popup--%>
<div id="DivEditWindow" style="display: none;" class="popupConfirmation">
    <iframe id="IframeEdit" frameborder="0" width="480" height="350" scrolling="no"></iframe>
</div>
</body>

