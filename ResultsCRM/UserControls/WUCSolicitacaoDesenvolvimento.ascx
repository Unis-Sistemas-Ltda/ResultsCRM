<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCSolicitacaoDesenvolvimento.ascx.vb" Inherits="ResultsCRM.WUCSolicitacaoDesenvolvimento" %><%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register src="WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<body  class="TextoCadastro_BGBranco">

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>>

<table class="TextoCadastro_BGBranco" 
        style="width:100%; border-collapse: collapse;">
    <tr>
        <td class="TituloMovimento" colspan="3">
            Cadastro de Solicitações</td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
        <td height="400" rowspan="12" style="border: 1px solid #CCCCCC" width="35%">
            <uc2:WUCFrame ID="WUCFrame1" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodSolicitacao" runat="server" Font-Bold="True" Height="16px" 
                Width="150px"></asp:Label>
        &nbsp;
            <asp:Label ID="Label10" runat="server" Height="17px" Text="Tipo:&nbsp;" 
                style="text-align:right" Width="49px"></asp:Label>
            <asp:DropDownList ID="DdlTipo" runat="server" CssClass="CampoCadastro" 
                Width="175px">
                <asp:ListItem Selected="True" Value="1">Novo Desenvolvimento</asp:ListItem>
                <asp:ListItem Value="2">Correção de Erro</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Origem:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlOrigem" runat="server" CssClass="CampoCadastro" 
                Width="150px">
                <asp:ListItem Value="1">Analista</asp:ListItem>
                <asp:ListItem Value="2">Cliente</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label7" runat="server" Height="17px" style="text-align: right"
                Text="Analista:&nbsp;" Width="57px"></asp:Label>
            <asp:DropDownList ID="ddlAnalista" runat="server" CssClass="CampoCadastro" 
                Width="175px">
            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Height="17px" style="text-align: right"
                Text="&nbsp;&nbsp;&nbsp;Data:"></asp:Label>
            <uc1:TextBoxData ID="txtDataSolicitacao" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Desenvolvedor:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="ddlDesenvolvedor" runat="server" CssClass="CampoCadastro" 
                Width="250px">
            </asp:DropDownList>
            <asp:Label ID="Label6" runat="server" Height="17px" style="text-align: right"
                Text="Sistema:" Width="60px"></asp:Label>
            <asp:DropDownList ID="DdlSistema" runat="server" CssClass="CampoCadastro" 
                Width="185px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Cliente:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCliente" runat="server" CssClass="CampoCadastro" 
                Width="50px" AutoPostBack="True"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtCliente&amp;varmp=SCodClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClientes','IframeEdit');" 
                Height="16px" Width="16px" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </ajaxToolkit:ModalPopupExtender>
&nbsp;<asp:Label ID="LblNomeCliente" runat="server" Font-Bold="True" Height="17px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Assunto:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="txtAssunto" runat="server" CssClass="CampoCadastro" 
                Width="500px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            Descrição:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="txtDescricao" runat="server" CssClass="CampoCadastro" 
                Height="140px" TextMode="MultiLine" Width="500px" Font-Names="Courier new" 
                Font-Size="8pt" ForeColor="Black"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            Regra de Negócio:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="txtRegraNegocio" runat="server" CssClass="CampoCadastro" 
                Height="50px" TextMode="MultiLine" Width="500px" Font-Names="Couriew New" 
                Font-Size="8pt" ForeColor="Black"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Urgência:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="ddlUrgencia" runat="server" CssClass="CampoCadastro" 
                Width="85px">
                <asp:ListItem Selected="True" Value="0">Baixa</asp:ListItem>
                <asp:ListItem Value="1">Média</asp:ListItem>
                <asp:ListItem Value="2">Alta</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label2" runat="server" Height="17px" style="text-align: right"
                Text="Próx. visita:" Width="80px"></asp:Label>
            <uc1:TextBoxData ID="txtProximaVisita" 
                runat="server" />
            <asp:Label ID="Label4" runat="server" Height="17px" style="text-align: right"
                Text="Prazo Obrigatório:" Width="110px"></asp:Label>
            <asp:CheckBox ID="ChkPrazoObrigatorio" runat="server" Text=" " Height="20px" />
            &nbsp;<asp:Label ID="Label3" runat="server" Height="17px" Text="Data:" 
                style="text-align: right"></asp:Label>
            <uc1:TextBoxData ID="txtPrazoObrigatorio" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Obrigatório Cliente Aprovar:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="ChkClienteAprovar" runat="server" Text=" " Height="19px" />
            <asp:Label ID="Label8" runat="server" Height="16px" style="text-align: right"
                Text="&nbsp;&nbsp;&nbsp;Entrega Prevista:"></asp:Label>
            <uc1:TextBoxData ID="txtDataEntregaPrevista" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label5" runat="server" Height="16px" style="text-align: right"
                Text="Situação:&nbsp;" Width="65px"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlStatus" runat="server" CssClass="CampoCadastro" 
                Width="265px">
                <asp:ListItem Value="0">Solicitado</asp:ListItem>
                <asp:ListItem Value="4">Analisado - aguardando agendamento</asp:ListItem>
                <asp:ListItem Value="5">Aguardando aprovação cliente (Desenv. com custo)</asp:ListItem>
                <asp:ListItem Value="6">Desenvolvimento agendado</asp:ListItem>
                <asp:ListItem Value="1">Em desenvolvimento</asp:ListItem>
                <asp:ListItem Value="2">Desenvolvimento finalizado</asp:ListItem>
                <asp:ListItem Value="3">Entregue/atualizado</asp:ListItem>
                <asp:ListItem Value="7">Desenvolvimento cancelado</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label9" runat="server" Height="16px" style="text-align: right"
                Text="Versão:&nbsp;" Width="65px"></asp:Label>
            <asp:DropDownList ID="DdlReleaseVersaoBanco" runat="server" CssClass="CampoCadastro" 
                Width="170px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="text-align: left">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" />
        </td>
    </tr>
    </table>
    <%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="410" scrolling="no">
        </iframe>
    </div>
</body>