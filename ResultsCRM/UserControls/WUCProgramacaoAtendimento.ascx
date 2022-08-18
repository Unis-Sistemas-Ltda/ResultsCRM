<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCProgramacaoAtendimento.ascx.vb" Inherits="ResultsCRM.WUCProgramacaoAtendimento" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="TituloMovimento">
    Programação de Atendimento</div>
<div class="Erro">
    <asp:Label ID="LblErro" runat="server"></asp:Label>
</div>
<div>
    <asp:Label ID="Label1" runat="server" Text="Cód. Programação:" Width="175px" 
        style="text-align:right" Height="17px"></asp:Label>
    &nbsp;<asp:Label ID="LblCodProgramacao" runat="server" Font-Bold="True" Height="17px" 
        Text="0"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Código do Cliente:" Width="175px" 
        style="text-align:right" Height="17px"></asp:Label>
    <asp:TextBox ID="TxtCodEmitente" runat="server" CssClass="CampoCadastro" 
        Width="60px" AutoPostBack="True"></asp:TextBox>
    &nbsp;<asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPClienteCNPJ.aspx?textbox=TxtCodEmitente&amp;varmp=SCodClientePesquisado&amp;varmpc=SCNPJClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClientes','IframeEdit');" 
                Height="15px" Width="16px" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </cc1:ModalPopupExtender>
    <br />
    <asp:Label ID="Label13" runat="server" Text="Nome do Cliente:" Width="175px" 
        style="text-align:right" Height="19px"></asp:Label>
    &nbsp;<asp:Label ID="LblNomeCliente" runat="server" Height="19px"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="CNPJ:" Width="175px" 
        style="text-align:right" Height="17px"></asp:Label>
    <asp:DropDownList ID="DdlCNPJ" runat="server" CssClass="CampoCadastro" 
        Width="315px" AutoPostBack="True">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Contato:" Width="175px" 
        style="text-align:right" Height="17px"></asp:Label>
    <asp:DropDownList ID="DdlContato" runat="server" CssClass="CampoCadastro" 
        Width="315px">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Contrato:" Width="175px" 
        style="text-align:right" Height="17px"></asp:Label>
    <asp:DropDownList ID="DdlContrato" runat="server" CssClass="CampoCadastro" 
        Width="315px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Analista:" Width="175px" 
        style="text-align:right" Height="17px"></asp:Label>
    <asp:DropDownList ID="DdlAnalista" runat="server" CssClass="CampoCadastro" 
        Width="315px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Tipo de Chamado:" Width="175px" 
        style="text-align:right" Height="17px"></asp:Label>
    <asp:DropDownList ID="DdlTipoChamado" runat="server" CssClass="CampoCadastro" 
        Width="315px">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Assunto:" Width="175px" 
        style="text-align:right" Height="17px"></asp:Label>
    <asp:TextBox ID="TxtAssunto" runat="server" CssClass="CampoCadastro" 
        MaxLength="50" Width="309px"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Observação:" Width="175px" 
        style="text-align:right" Height="17px"></asp:Label>
    <asp:TextBox ID="TxtObservacao" runat="server" CssClass="CampoCadastro" 
        MaxLength="100" Width="308px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label14" runat="server" Text="Follow-Up Inicial:" Width="175px" 
        style="text-align:right" Height="73px"></asp:Label>
    <asp:TextBox ID="TxtFollowUp" runat="server" CssClass="CampoCadastro" 
        Width="308px" Height="70px" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label10" runat="server" Text="Agendamento:" Width="175px" 
        style="text-align:right" Height="17px"></asp:Label>
    <asp:DropDownList ID="DdlTipoAgendamento" runat="server" 
        CssClass="CampoCadastro" Width="315px">
        <asp:ListItem Value="1">Dia 01 de cada mês</asp:ListItem>
        <asp:ListItem Value="2">Dia 02 de cada mês</asp:ListItem>
        <asp:ListItem Value="2">Dia 03 de cada mês</asp:ListItem>
        <asp:ListItem Value="4">Dia 04 de cada mês</asp:ListItem>
        <asp:ListItem Value="5">Dia 05 de cada mês</asp:ListItem>
        <asp:ListItem Value="6">Dia 06 de cada mês</asp:ListItem>
        <asp:ListItem Value="7">Dia 07 de cada mês</asp:ListItem>
        <asp:ListItem Value="8">Dia 08 de cada mês</asp:ListItem>
        <asp:ListItem Value="9">Dia 09 de cada mês</asp:ListItem>
        <asp:ListItem Value="10">Dia 10 de cada mês</asp:ListItem>
        <asp:ListItem Value="11">Dia 11 de cada mês</asp:ListItem>
        <asp:ListItem Value="12">Dia 12 de cada mês</asp:ListItem>
        <asp:ListItem Value="13">Dia 13 de cada mês</asp:ListItem>
        <asp:ListItem Value="14">Dia 14 de cada mês</asp:ListItem>
        <asp:ListItem Value="15">Dia 15 de cada mês</asp:ListItem>
        <asp:ListItem Value="16">Dia 16 de cada mês</asp:ListItem>
        <asp:ListItem Value="17">Dia 17 de cada mês</asp:ListItem>
        <asp:ListItem Value="18">Dia 18 de cada mês</asp:ListItem>
        <asp:ListItem Value="19">Dia 19 de cada mês</asp:ListItem>
        <asp:ListItem Value="20">Dia 20 de cada mês</asp:ListItem>
        <asp:ListItem Value="21">Dia 21 de cada mês</asp:ListItem>
        <asp:ListItem Value="22">Dia 22 de cada mês</asp:ListItem>
        <asp:ListItem Value="23">Dia 23 de cada mês</asp:ListItem>
        <asp:ListItem Value="24">Dia 24 de cada mês</asp:ListItem>
        <asp:ListItem Value="25">Dia 25 de cada mês</asp:ListItem>
        <asp:ListItem Value="26">Dia 26 de cada mês</asp:ListItem>
        <asp:ListItem Value="27">Dia 27 de cada mês</asp:ListItem>
        <asp:ListItem Value="28">Dia 28 de cada mês</asp:ListItem>
        <asp:ListItem Value="29">Dia 29 de cada mês</asp:ListItem>
        <asp:ListItem Value="30">Dia 30 de cada mês</asp:ListItem>
        <asp:ListItem Value="31">Dia 31 de cada mês</asp:ListItem>
        <asp:ListItem Value="52">Último dia de cada mês</asp:ListItem>
        <asp:ListItem Value="41">Todo domingo</asp:ListItem>
        <asp:ListItem Value="42">Toda segunda-feira</asp:ListItem>
        <asp:ListItem Value="43">Toda terça-feira</asp:ListItem>
        <asp:ListItem Value="44">Toda quarta-feira</asp:ListItem>
        <asp:ListItem Value="45">Toda quinta-feira</asp:ListItem>
        <asp:ListItem Value="46">Toda sexta-feira</asp:ListItem>
        <asp:ListItem Value="47">Todo sábado</asp:ListItem>
        <asp:ListItem Value="50">Todos os dias</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label11" runat="server" Text="Situação do Agendamento:" Width="175px" 
        style="text-align:right" Height="17px"></asp:Label>
    <asp:DropDownList ID="DdlSituacao" runat="server" CssClass="CampoCadastro" 
        Width="315px">
        <asp:ListItem Value="1">Ativo</asp:ListItem>
        <asp:ListItem Value="2">Pausado</asp:ListItem>
        <asp:ListItem Value="3">Cancelado</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label12" runat="server" Width="150px" 
        style="text-align:right" Height="17px"></asp:Label>
    <asp:Button ID="BtnGravar" runat="server" Text="Gravar" />
&nbsp;
    <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" />
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
</div>
