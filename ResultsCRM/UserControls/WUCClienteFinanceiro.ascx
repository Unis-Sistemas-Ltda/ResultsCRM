<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCClienteFinanceiro.ascx.vb" Inherits="ResultsCRM.WUCClienteFinanceiro" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
<asp:ScriptManager ID="ScriptManager1" 
                runat="server">
            </asp:ScriptManager>
<table class="TextoCadastro_BGBranco" 
    style="width:100%; border-collapse: collapse; font-size: 7pt;">
    <tr>
        <td class="TituloCadastro" colspan="2">
            Cliente Financeiro
        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Grupo:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlGrupo" runat="server" CssClass="CampoCadastro" 
                Width="260px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Vendedor:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlRepresentante" runat="server" CssClass="CampoCadastro" 
                Width="260px">
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td style="text-align: right">
            Distribuidor:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlDistribuidor" runat="server" CssClass="CampoCadastro" Width="260px">
            </asp:DropDownList>           
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Canal de Venda:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlCanalVenda" runat="server" CssClass="CampoCadastro" 
                Width="260px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Cond. Pagto:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlCondicaoPagamento" runat="server" 
                CssClass="CampoCadastro" Width="260px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Forma Pagto:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlFormaPagamento" runat="server" 
                CssClass="CampoCadastro" Width="260px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nat. Op. Produtos:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlNatureza" runat="server" CssClass="CampoCadastro" 
                Width="102px">
            </asp:DropDownList>
            <asp:Label ID="Label2" runat="server" Height="17px" Text="&nbsp; Serviços:"></asp:Label>
            <asp:DropDownList ID="DdlNaturezaServicos" runat="server" CssClass="CampoCadastro" 
                Width="102px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Tipo Frete:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlTipoFrete" runat="server" CssClass="CampoCadastro" 
                Width="260px">
                <asp:ListItem Value="1">CIF</asp:ListItem>
                <asp:ListItem Value="2">FOB</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Carteira bancária:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlCarteiraBancaria" runat="server" CssClass="CampoCadastro" 
                Width="260px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Portador:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlPortador" runat="server" CssClass="CampoCadastro" 
                Width="260px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Banco:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlBanco" runat="server" CssClass="CampoCadastro" 
                Width="260px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Cliente Padrão:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtClienteAtendimento" runat="server" CssClass="CampoCadastro" 
                Width="50px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            &nbsp;<asp:Label ID="LblRazaoSocialPontoAtendimento" runat="server" Font-Bold="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            PA Padrão:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtNrPontoAtendimento" runat="server" CssClass="CampoCadastro" 
                Width="100px" MaxLength="25" AutoPostBack="True" Height="18px"></asp:TextBox>
            <asp:Label ID="LblNomePontoAtendimento" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Parceiro:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlParceiro" runat="server" CssClass="CampoCadastro" 
                Width="145px">
            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Height="17px" Text="&nbsp;Repasse:"></asp:Label>
            <asp:TextBox ID="TxtRepasse" runat="server" CssClass="CampoCadastro" Width="45px"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td style="text-align: right">
            Adesão:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAdesao" runat="server" CssClass="CampoCadastro" Width="45px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Provedor TEF:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlProvedorTEF" runat="server" CssClass="CampoCadastro" 
                Width="260px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Adquirente Principal:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlAdquirentePrincipal" runat="server" CssClass="CampoCadastro" 
                Width="260px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
    <asp:Button ID="btnOkay" runat="server" CssClass="Botao" 
                                OnClick="btnOkay_Click" Text="Done" Visible="False" />
        </td>
        <td class="CelulaCampoCadastro">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" />
        &nbsp;&nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" 
                Visible="False" />
        &nbsp;&nbsp;
            <asp:Button ID="BtnConcluir" runat="server" CssClass="Botao" Text="Concluir" 
                Visible="False" />
        </td>
    </tr>
</table>
<%--este é o html para funcionar o botão de incluir contatos--%><%--este é o html para funcionar o botão de incluir contatos--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
<%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="410" scrolling="no">
        </iframe>
    </div>