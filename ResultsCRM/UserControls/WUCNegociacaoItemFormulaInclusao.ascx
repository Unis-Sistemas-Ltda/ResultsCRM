<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoItemFormulaInclusao.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoItemFormulaInclusao1" %>
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
    .auto-style3 {
        text-align: left;
        width: 121px;
    }
    .auto-style4 {
        width: 121px;
    }
</style>
<Body>

    
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table>
    <tr>
        <td colspan="2">
            <table class="TextoCadastro_BGBranco" style="border: thin groove #CCCCCC; width: 800px;">               
                <tr>
                    <td colspan="6" align="left">
                        <img alt="Detalhes da Ficha de desenvolvimento do Produto"
                            src="../Imagens/DetalheItemNegociacaoFormula.png" style="width: 420px; height: 18px" /></td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style1">Seq. Item:</td>
                    <td class="auto-style3" colspan="1">
                        <asp:Label ID="LblSeqItem" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="Erro" colspan="4">
                        <asp:Label ID="LblErro" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style1">Seq. Item Fórmula:</td>
                    <td class="auto-style2" colspan="5">
                        <asp:Label ID="LblSeqItemFormaula" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
  
                <tr>
                    <td style="vertical-align: top; text-align: right;">
                        <asp:Label ID="Label19" runat="server" Text="Componente/Matéria Prima:"></asp:Label>
                    </td>

                    <td colspan="5">
                        <asp:TextBox ID="TxtDescricaoComponente" runat="server" CssClass="CampoCadastro"
                            Width="600px"></asp:TextBox></td>
                </tr>
                
                <tr>
                    <td class="CelulaCampoCadastro" style="text-align: right">
                        <asp:Label ID="Label14" runat="server" Text="Percentual(%):"></asp:Label>

                    </td>
                    <td colspan="1" style="text-align: left; vertical-align:central" class="auto-style4" >
                        <asp:TextBox ID="TxtPercentual" runat="server" CssClass="CampoCadastro"
                            Width="50px"></asp:TextBox>
                    </td>
                    </td>
                    <td colspan="3" class="CelulaCampoCadastro" style="text-align: left">                      
                        
                        <asp:CheckBox ID="ChkQsp" runat="server" Text="QSP" />
                        
                        
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
<%--botões padrão que ficam ocultos, são necessários, não remover--%>
<div class="popup_Buttons" style="display: none">
    <input id="ButtonEditDone" value="Done" type="button" />
    <input id="ButtonEditCancel" value="Cancel" type="button" />
</div>
<%--frame onde é mostrado o popup--%>
<div id="DivEditWindow" style="display: none;" class="popupConfirmation">
    <iframe id="IframeEdit" frameborder="0" width="480" height="350" scrolling="no"></iframe>
</div>

</Body>