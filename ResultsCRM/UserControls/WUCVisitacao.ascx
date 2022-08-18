<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCVisitacao.ascx.vb" Inherits="ResultsCRM.WUCVisitacao" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server" 
    EnableScriptGlobalization="True"></asp:ScriptManager>

<div runat="server" id="TagTitulo" class="TituloMovimento">Registro de Visitação</div>

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
            <asp:Label ID="LblSeqVisitacao" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Vendedor/Representante:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="ddlRepresentante" runat="server" 
                            CssClass="CampoCadastro" Width="400px">
                        </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Data:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtData" runat="server" CssClass="TextoCadastro" 
                MaxLength="10" Width="75px"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtData_CalendarExtender" runat="server" 
                        TargetControlID="TxtData" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
            <span>
                <asp:Label ID="LblLabelCNPJ2" runat="server" Height="17px" Width="60px" 
                style="text-align: right">Hora:</asp:Label>
            <asp:TextBox ID="TxtHora" runat="server" CssClass="CampoCadastro" MaxLength="5" 
                Width="45px"></asp:TextBox>
                    </span>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <span>
                <asp:Label ID="LblLabelCNPJ0" runat="server" Height="17px" Width="105px" 
                style="text-align: right">Situação:</asp:Label>
                    </span>
        </td>
        <td class="CelulaCampoCadastro">
            <span>
            <asp:DropDownList ID="DdlSituacao" runat="server" AutoPostBack="True" 
                            CssClass="CampoCadastro" Width="200px">
                            <asp:ListItem Selected="True" Value="1">Agendada</asp:ListItem>
                            <asp:ListItem Value="2">Concluída</asp:ListItem>
                            <asp:ListItem Value="3">Cancelada</asp:ListItem>
                        </asp:DropDownList>
                    </span>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Cliente:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCodEmitente" runat="server" CssClass="TextoCadastro" 
                Width="75px" AutoPostBack="True"></asp:TextBox>
             &nbsp;<asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtCodEmitente&amp;varmp=SCodClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClientes','IframeEdit');" 
                Height="16px" Width="16px" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </cc1:ModalPopupExtender>
            <span>
                &nbsp;<asp:ImageButton ID="BtnIncluirCliente" runat="server" ImageUrl="~/Imagens/BtnIncluir.png" 
                    AlternateText="Novo Cliente" Height="16px" ToolTip="Novo cliente" 
                onclientclick="ShowEditModal('../Forms/WFClienteEmbeeded.aspx?a=I&amp;vcodemi=SCodEmitenteNegociacao&amp;vcodemp=SCodClientePesquisado&amp;valtecc=SAlterouCodCliente&amp;vrecdc=SRecarregaDdlContatos&amp;ccodcon=SCodContatoNegociacao&amp;cnpjemi=SCNPJEmitente&amp;vcodemin=SCodEmitenteNegociacao','EditModalPopupIncluirCliente','IframeEdit');" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirCliente">
    </cc1:ModalPopupExtender>
                &nbsp;<asp:ImageButton ID="BtnAlterarCliente" runat="server" ImageUrl="~/Imagens/BtnEditar.png" 
                    AlternateText="Alterar cliente" Height="16px" ToolTip="Alterar informações do cliente" 
                onclientclick="ShowEditModal('../Forms/WFClienteEmbeeded.aspx?a=A&amp;vcodemi=SCodEmitenteNegociacao&amp;vcodemp=SCodClientePesquisado&amp;valtecc=SAlterouCodCliente&amp;vrecdc=SRecarregaDdlContatos&amp;ccodcon=SCodContatoNegociacao&amp;cnpjemi=SCNPJEmitente&amp;vcodemin=SCodEmitenteNegociacao','EditModalPopupAlterarCliente','IframeEdit');" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender5" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarCliente">
    </cc1:ModalPopupExtender>
                &nbsp;</span>
    <asp:Label ID="LblLabelCNPJ" runat="server" Height="17px">&nbsp;&nbsp;CNPJ:&nbsp;</asp:Label>
            <asp:DropDownList ID="DdlCNPJ" runat="server" CssClass="CampoCadastro" 
                Width="200px" AutoPostBack="True"/>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nome:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblNomeCliente" runat="server" Height="17px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
    <asp:Label ID="LblLabelNome2" runat="server" Height="17px">&nbsp;&nbsp;Cliente não cadastrado:</asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxIdClienteGenerico" runat="server" AutoPostBack="True" />
    <asp:Label ID="LblLabelNome1" runat="server" Height="17px">&nbsp;&nbsp;Nome:&nbsp;</asp:Label>
            <asp:TextBox ID="TxtClienteGenerico" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="275px" Enabled="False" 
                ToolTip="Nome do cliente não cadastrado"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Assunto:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTitulo" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top" style="text-align: right">
            Follow-up:</td>
        <td class="CelulaCampoCadastro" valign="top">
            <asp:TextBox ID="TxtNarrativa" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="400px" Height="125px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" 
                Text="Gravar alterações" />
        &nbsp;&nbsp;&nbsp; <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
    </table>
<%--este é o html para pesquisa de emitentes--%><%--este é o html para incluir emitente via negociação--%><%--este é o html para alterar cadastro de emitente via negociação--%><%--este é o html para funcionar o botão de incluir contatos--%><%--este é o html para funcionar o botão de incluir contatos--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
<%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="410" scrolling="no">
        </iframe>
    </div>