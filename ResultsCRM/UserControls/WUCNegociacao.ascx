<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacao.ascx.vb" Inherits="ResultsCRM.WUCNegociacao" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxHora.ascx" tagname="TextBoxHora" tagprefix="uc2" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc3" %>

<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc4" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<style type="text/css">
    .auto-style1 {
        font-size: 8pt;
        text-align: left;
        color: #CC0000;
        font-family: verdana;
        height: 15px;
    }
    .auto-style2 {
        height: 21px;
        width: 195px;
    }
    .auto-style3 {
        text-align: left;
        height: 21px;
    }
    .auto-style4 {
        height: 28px;
        width: 195px;
    }
    .auto-style5 {
        text-align: left;
        height: 28px;
    }
    .auto-style6 {
        text-align: left;
        width: 155px;
        height: 28px;
    }
    .auto-style7 {
        width: 195px;
    }
</style>

<body class="TextoCadastro_BGBranco">

<asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True"></asp:ScriptManager>

<table style="width: 100%; border-collapse: collapse;" 
        class="TextoCadastro_BGBranco">
    <tr>
        <td class="auto-style1" colspan="4">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
              <asp:Label ID="LblInadimplente" runat="server" 
                Font-Bold="False" ForeColor="Red" Visible="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " class="auto-style7">
            Nº Negociação:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle" width="300px;">
            <asp:Label ID="LblNrNegociacao" runat="server" Font-Bold="False" 
                Font-Size="8pt" Width="75px"></asp:Label>
        &nbsp;<asp:Label ID="Label13" runat="server" Text="Nº Chamado:"></asp:Label>
            <asp:Label ID="LblCodChamado" runat="server"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right;">
            Funil:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle">
            <asp:DropDownList ID="DdlFunil" runat="server" CssClass="CampoCadastro" 
                Width="190px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7">
            Data Cadastramento:</td>
        <td class="CelulaCampoCadastro" 
            style="">
            <asp:Label ID="LblDataCadastramento" runat="server" Font-Bold="False" 
                Font-Size="8pt"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" 
            style="text-align: right;">
            Etapa:</td>
        <td class="CelulaCampoCadastro" 
            style="">
            <asp:DropDownList ID="DdlEtapa" runat="server" CssClass="CampoCadastro" 
                Width="190px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            <asp:Label ID="Label4" runat="server" Text="Estabelecimento:" ></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlEstabelecimento" runat="server" CssClass="CampoCadastro" Width="240px"  AutoPostBack="True"></asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
           
            Status:</td>
        <td class="CelulaCampoCadastro">
          
            <asp:DropDownList ID="DdlStatus" runat="server" CssClass="CampoCadastro" 
                Width="190px">
            </asp:DropDownList>
          
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " class="auto-style4">
            <asp:Label ID="Label5" runat="server" Text="Cliente:"></asp:Label>
            </td>
        <td class="auto-style5">
            <asp:TextBox ID="TxtCliente" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Width="43px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPClienteCNPJ.aspx?textbox=TxtCliente&amp;varmp=SCodClientePesquisado&amp;varmpc=SCNPJClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClientes','IframeEdit');"                 
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
                onclientclick="ShowEditModal('../Forms/WFClienteEmbeeded.aspx?a=A&amp;vcodemi=SCodEmitenteNegociacao&amp;vcodemp=SCodClientePesquisado&amp;valtecc=SAlterouCodCliente&amp;vrecdc=SRecarregaDdlContatos&amp;ccodcon=SCodContatoNegociacao&amp;cnpjemi=SCNPJEmitente&amp;vcodemin=SCodEmitenteNegociacaoAnterior','EditModalPopupAlterarCliente','IframeEdit');" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender5" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarCliente">
    </cc1:ModalPopupExtender>
                &nbsp;</span><asp:Label ID="Label3" runat="server" Text="CNPJ:" 
                Height="17px"></asp:Label>
            <asp:DropDownList ID="DdlCNPJ" runat="server" CssClass="CampoCadastro" 
                Width="140px" AutoPostBack="True"/>
        </td>
        <td class="auto-style6" style="text-align: right; ">
            Cliente PA:</td>
        <td class="auto-style5">
            <asp:TextBox ID="TxtClienteAtendimento" runat="server" CssClass="CampoCadastro" 
                Width="50px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarClienteAtendimento" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtCliente&amp;varmp=SCodClienteAtPesquisado&amp;varma=SAlterouCodClienteAt','EditModalPopupClienteAtendimento','IframeEdit');" 
                Height="15px" Width="16px" />
            <span class="TextoCadastro">
                <asp:ImageButton ID="BtnIncluirClienteAtendimento" runat="server" ImageUrl="~/Imagens/BtnIncluir.png" 
                    AlternateText="Novo Cliente" Height="16px" ToolTip="Novo cliente" 
                    
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFClienteEmbeeded.aspx?a=I1&amp;vcodemi=SCodEmitenteAtNegociacao&amp;vcodemp=SCodClienteAtPesquisado&amp;valtecc=SAlterouCodClienteAt&amp;vrecdc=SRecarregaDdlContatosAt&amp;ccodcon=SCodContatoNegociacaoAt&amp;cnpjemi=SCNPJEmitenteAtendimento&amp;vcodemin=SCodEmitenteAtNegociacao','EditModalPopupIncluirCliente','IframeEdit');" />
    <cc1:ModalPopupExtender ID="BtnIncluirClienteAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirClienteAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirClienteAtendimento">
    </cc1:ModalPopupExtender>
            </span>
    <cc1:ModalPopupExtender ID="BtnFiltrarClienteAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarClienteAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClienteAtendimento">
    </cc1:ModalPopupExtender>
            <span class="TextoCadastro">
                <asp:ImageButton ID="BtnAlterarClienteAtendimento" runat="server" ImageUrl="~/Imagens/BtnEditar.png" 
                    AlternateText="Alterar cliente" Height="16px" ToolTip="Alterar informações do cliente" 
                    
                
                
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFClienteEmbeeded.aspx?a=A1&amp;vcodemi=SCodEmitenteAtNegociacao&amp;vcodemp=SCodClienteAtPesquisado&amp;valtecc=SAlterouCodClienteAt&amp;vrecdc=SRecarregaDdlContatosAt&amp;ccodcon=SCodContatoNegociacaoAt&amp;cnpjemi=SCNPJEmitenteAtendimento&amp;vcodemin=SCodEmitenteAtNegociacao','EditModalPopupIncluirCliente','IframeEdit');" />
    <cc1:ModalPopupExtender ID="BtnAlterarClienteAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarClienteAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarClienteAtendimento">
    </cc1:ModalPopupExtender>
            <asp:Label ID="Label14" runat="server" Height="17px" Text="Nº Ponto Atend.:" 
                style="width: 105px"></asp:Label>
            <asp:TextBox ID="TxtNrPontoAtendimento" runat="server" CssClass="CampoCadastro" 
                Width="100px" MaxLength="25" AutoPostBack="True" Height="18px"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarPontoAtendimento" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPClienteFantasia.aspx?textbox=TxtCliente&amp;varmp=SCodClienteAtPesquisado&amp;varma=SAlterouNumeroPontoAtendimento&amp;varmpc=SPontoPesquisado','EditModalPopupClientes','IframeEdit');" 
                Height="15px" Width="16px" />
    <cc1:ModalPopupExtender ID="BtnFiltrarPontoAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarPontoAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupPontoAtendimento">
    </cc1:ModalPopupExtender>
            <asp:ImageButton ID="BtnIncluirPontoAtendimento" runat="server" ImageUrl="~/Imagens/BtnIncluir.png" 
                    AlternateText="Novo Cliente" Height="16px" ToolTip="Novo Ponto de Atendimento" 
                
                onclientclick="ShowEditModal('../Forms/WFPontoAtendimentoEmbeeded.aspx?a=I&amp;vcodemi=SCodEmitenteAtNegociacao&amp;vcodemp=SCodClienteAtPesquisado&amp;valtecc=SAlterouNumeroPontoAtendimento&amp;vrecdc=SRecarregaDdlContatosAt&amp;ccodcon=SCodContatoNegociacaoAt&amp;ptat=SPontoPesquisado&amp;vcodemin=SCodEmitenteAtNegociacao','EditModalPopupIncluirPontoAtendimento','IframeEdit');" />
    <cc1:ModalPopupExtender ID="BtnIncluirPontoAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirPontoAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirPontoAtendimento">
    </cc1:ModalPopupExtender>
                <asp:ImageButton ID="BtnAlterarPontoAtendimento" runat="server" ImageUrl="~/Imagens/BtnEditar.png" 
                    AlternateText="Alterar cliente" Height="16px" ToolTip="Alterar informações do ponto de atendimento" 
                
                onclientclick="ShowEditModal('../Forms/WFPontoAtendimentoEmbeeded.aspx?a=A&amp;vcodemi=SCodEmitenteAtNegociacao&amp;vcodemp=SCodClienteAtPesquisado&amp;valtecc=SAlterouNumeroPontoAtendimento&amp;vrecdc=SRecarregaDdlContatosAt&amp;ccodcon=SCodContatoNegociacaoAt&amp;ptat=SPontoPesquisado&amp;vcodemin=SCodEmitenteAtNegociacao','EditModalPopupIncluirPontoAtendimento','IframeEdit');" />
    <cc1:ModalPopupExtender ID="BtnAlterarPontoAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarPontoAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarPontoAtendimento">
    </cc1:ModalPopupExtender>
            </span>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " valign="top" class="auto-style7">
            Inscrição Estadual:</td>
        <td class="CelulaCampoCadastro" valign="top">
            <asp:Label ID="LblInscEstadual" runat="server" ForeColor="Red"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" 
            style="text-align: right;">
            Nome Cliente PA:</td>
        <td class="CelulaCampoCadastro" 
            style="">
        &nbsp;
            <asp:Label ID="LblRazaoSocialPontoAtendimento" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " valign="top" class="auto-style7" >
            Nome:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblNomeCliente" runat="server" Font-Bold="False"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" 
            style="text-align: right">
            Nome PA:</td>
        <td class="CelulaCampoCadastro" 
            style="">
            <asp:Label ID="LblNomePontoAtendimento" runat="server" Font-Bold="True"></asp:Label>
        &nbsp;/
            <asp:Label ID="LblObsPontoAtendimento" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style7" style="text-align: right; " >
            Endereço:</td>
        <td class="CelulaCampoCadastro" style="">
            <span>
            &nbsp;&nbsp;</span><asp:Label ID="LblEndereco" runat="server"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Endereço PA:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblEnderecoAtendimento" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style7" style="text-align: right; " >
            <span style="text-align: right">Contato:</span></td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlContato" runat="server" CssClass="CampoCadastro" 
                Width="240px" AutoPostBack="True">
            </asp:DropDownList>
            <span>
            <asp:ImageButton ID="BtnIncluirContato" runat="server" 
                AlternateText="Novo Contato" Height="16px" ToolTip="Novo contato" 
                ImageUrl="~/Imagens/BtnIncluir.png" 
                
                
                
                onclientclick="ShowEditModal('../Forms/WFContato.aspx?a=I&amp;vrecc=SRecarregaDdlContatos&amp;vcodc=SCodContatoNegociacao&amp;vcode=SCodEmitenteNegociacao&amp;ptat=','EditModalPopupIncluirContato','IframeEdit2');" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender3" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirContato" PopupControlID="DivEditWindow2" 
        OnCancelScript="EditCancelScript('IframeEdit2');" OnOkScript="EditOkayScript('IframeEdit2');"
        BehaviorID="EditModalPopupIncluirContato">
    </cc1:ModalPopupExtender>
            <asp:ImageButton ID="BtnAlterarContato" runat="server" 
                AlternateText="Alterar contato" Height="16px" 
                ToolTip="Alterar informações do contato" 
                ImageUrl="~/Imagens/BtnEditar.png" 
                
                
                
                onclientclick="ShowEditModal('../Forms/WFContato.aspx?a=A&amp;vrecc=SRecarregaDdlContatos&amp;vcodc=SCodContatoNegociacao&amp;vcode=SCodEmitenteNegociacao&amp;ptat=','EditModalPopupIncluirContato','IframeEdit2');" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender4" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarContato" PopupControlID="DivEditWindow2" 
        OnCancelScript="EditCancelScript('IframeEdit2');" OnOkScript="EditOkayScript('IframeEdit2');"
        BehaviorID="EditModalPopupAlterarContato">
    </cc1:ModalPopupExtender>
            </span>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Contato PA:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlContatoAtendimento" runat="server" CssClass="CampoCadastro" 
                Width="225px" AutoPostBack="True">
            </asp:DropDownList>
            <span class="TextoCadastro">
            <asp:ImageButton ID="BtnIncluirContato0" runat="server" 
                AlternateText="Novo Contato" Height="16px" ToolTip="Novo contato" 
                ImageUrl="~/Imagens/BtnIncluir.png" 
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFContato.aspx?a=I&amp;vrecc=SRecarregaDdlContatosAt&amp;vcodc=SCodContatoNegociacaoAt&amp;vcode=SCodEmitenteAtNegociacao&amp;ptat=SPontoAtendimento','EditModalPopupIncluirContatoAtendimento','IframeEdit');" />
     <cc1:ModalPopupExtender ID="BtnIncluirContato0_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirContato0" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirContatoAtendimento">
    </cc1:ModalPopupExtender>
            <asp:ImageButton ID="BtnAlterarContato0" runat="server" 
                AlternateText="Alterar contato" Height="16px" 
                ToolTip="Alterar informações do contato" 
                ImageUrl="~/Imagens/BtnEditar.png" 
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFContato.aspx?a=A&amp;vrecc=SRecarregaDdlContatosAt&amp;vcodc=SCodContatoNegociacaoAt&amp;vcode=SCodEmitenteAtNegociacao&amp;ptat=SPontoAtendimento','EditModalPopupAlterarContatoAtendimento','IframeEdit');" />
     <cc1:ModalPopupExtender ID="BtnAlterarContato0_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarContato0" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarContatoAtendimento">
    </cc1:ModalPopupExtender>
            </span>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " class="auto-style7">
            <asp:Label ID="Label12" runat="server" Text="Telefone(s):"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblTelefone" runat="server"></asp:Label> &nbsp;- 
            <asp:Label ID="LblCelular" runat="server"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" 
            style="text-align: right">
            Telefone PA:</td>
        <td class="CelulaCampoCadastro" 
            style="">
            <asp:Label ID="LblTelefoneAtendimento" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " class="auto-style7" >
            E-mail:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblEmail" runat="server"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            E-Mail PA:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblEmailAtendimento" runat="server" Height="16px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            Manter informado (e-mail):</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtManterInformado" runat="server" CssClass="CampoCadastro" 
                Width="240px" MaxLength="200"
                
                
                ToolTip="Informe aqui o(s) emails(s). Existindo mais de um endereço de email, utilize ponto-e-vírgula como separador."></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Label11" runat="server" Height="16px" 
                Text="Percentual Fechamento:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <uc4:TextBoxNumerico ID="TxtProbabilidadeSucesso" Width="45" runat="server" 
                QtdCasas="2" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style2" >
            <asp:Label ID="LblTipoCobranca" runat="server" Text="Tipo Cobrança:" Visible="False"></asp:Label>
            </td>
        <td class="auto-style3">
            <asp:DropDownList ID="DdlTipoCobranca" runat="server" CssClass="CampoCadastro" Width="240px" Visible="False" AutoPostBack="True"></asp:DropDownList>
        </td>
        <td class="auto-style3" style="text-align: right">
            Motivo Fechamento:
               <td class="auto-style3">
            <asp:DropDownList ID="DdlMotivoFechamento" runat="server" CssClass="CampoCadastro" Width="190px"  AutoPostBack="True"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            <asp:Label ID="Label9" runat="server" Text="&nbsp;Gestor:" style="text-align: right"
                Width="65px"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlGestor" runat="server" CssClass="CampoCadastro" 
                Width="240px">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Label8" runat="server" Height="16px" Text="Origem do Lead:" style="text-align: right; margin-left: 0px;"
                Width="100px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlFonteOrigem" runat="server" CssClass="CampoCadastro" 
                Width="190px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
             <asp:Label ID="LblRepresentante" runat="server" Height="16px" style="text-align: right"
                Text="Vendedor/Representante:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlRepresentante" runat="server" CssClass="CampoCadastro" 
                Width="240px">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Lbl1" runat="server" Height="16px" style="text-align: right"
                Text="Modelo de Proposta:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlModelo" runat="server" CssClass="CampoCadastro" 
                Width="190px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            Agente de Vendas:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlAgente" runat="server" CssClass="CampoCadastro" 
                Width="240px">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Validade da Proposta:</td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtDataValidadeProposta" runat="server" Width="90" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
             <asp:Label ID="LblCanalVenda" runat="server" Height="16px" style="text-align: right"
                Text="Canal de Venda:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlCanalVenda" runat="server" CssClass="CampoCadastro" 
                Width="240px">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Data/Hora Recontato:</td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtDataRecontato" runat="server" Width="90" />
            <uc2:TextBoxHora ID="TxtHoraRecontato" runat="server" Width="58"/>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            <asp:Label ID="LblCarteira" runat="server" Height="16px" style="text-align: right"
                Text="Carteira:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlCarteira" runat="server" CssClass="CampoCadastro" 
                Width="240px">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Previsão Fechamento:</td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtPrevisaoFechamento" runat="server" Width="90" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Label2" runat="server" Height="17px" Text=" Prioridade:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="ddlPrioridade" runat="server" CssClass="CampoCadastro" 
                Width="115px">
                <asp:ListItem Value="A">Alta</asp:ListItem>
                <asp:ListItem Selected="True" Value="M">Média</asp:ListItem>
                <asp:ListItem Value="B">Baixa</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            <asp:Label ID="LblMoeda" runat="server" Text="Moeda:" Height="16px" style="text-align:right"
                Width="65px"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlMoeda" runat="server" CssClass="CampoCadastro" 
                Width="240px">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Label1" runat="server" Height="17px" Text="Receptividade:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="ddlReceptividade" runat="server" CssClass="CampoCadastro" 
                Width="115px">
                <asp:ListItem Value="A">Muito receptivo</asp:ListItem>
                <asp:ListItem Selected="True" Value="M">Receptivo</asp:ListItem>
                <asp:ListItem Value="B">Pouco receptivo</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            <asp:Label ID="LblFormaPagto" runat="server" Text="Forma de Pagamento:" 
                style="text-align:right"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlFormaPagto" runat="server" CssClass="CampoCadastro" 
                Width="240px">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LblEquipamento" runat="server" Height="16px" Text="Equipamento:" 
                style="text-align: right"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlEquipamento" runat="server" CssClass="CampoCadastro" 
                Width="190px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style2" >
             <asp:Label ID="LblCondicaoPagto" runat="server" Text="Condição de Pagamento:" Height="16px" style="text-align:right"
                ></asp:Label>
            </td>
        <td class="auto-style3">
            <asp:DropDownList ID="DdlCondicaoPagto" runat="server" CssClass="CampoCadastro" 
                Width="240px">
            </asp:DropDownList>
        </td>
        <td class="auto-style3" style="text-align: right">
            <asp:Label ID="LabelObra01" runat="server" Text="Tipo da Obra:"></asp:Label>
        </td>
        <td class="auto-style3">
            <asp:DropDownList ID="DdlTipoObra" runat="server" CssClass="CampoCadastro" 
                Width="190px">
                <asp:ListItem Value="1">Casa</asp:ListItem>
                <asp:ListItem Value="2">Prédio</asp:ListItem>
                <asp:ListItem Value="3">Galpão</asp:ListItem>
                <asp:ListItem Value="4">Loja/Sala Comercial</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
              <asp:Label ID="LblNatureza" runat="server" Height="16px" Text="Natureza de Operação:" 
                style="text-align: right"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlNatureza" runat="server" CssClass="CampoCadastro" 
                Width="240px">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LabelObra02" runat="server"
                Text="Modalidade:" ></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlModalidadeObra" runat="server" CssClass="CampoCadastro" 
                Width="190px">
                <asp:ListItem Value="1">Nova</asp:ListItem>
                <asp:ListItem Value="2">Reforma</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            <asp:Label ID="LblFrete" runat="server" Height="16px" Text="Frete:" 
                style="text-align: right"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlFrete" runat="server" CssClass="CampoCadastro" 
                Width="80px">
                <asp:ListItem Value="1">CIF</asp:ListItem>
                <asp:ListItem Value="2">FOB</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LabelObra03" runat="server" Text="Estágio:" 
                style="text-align: right"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlEstagioObra" runat="server" CssClass="CampoCadastro" 
                Width="190px">
                <asp:ListItem Value="1">Fundação</asp:ListItem>
                <asp:ListItem Value="2">Andamento</asp:ListItem>
                <asp:ListItem Value="3">Telhado</asp:ListItem>
                <asp:ListItem Value="4">Acabamento</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LabelObra04" runat="server" Height="16px" Text="&nbsp;Tamanho:" style="text-align: right"
                Width="65px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTamanhoObra" runat="server" CssClass="CampoCadastro" 
                Width="40px"></asp:TextBox>
            <asp:Label ID="LabelObra05" runat="server" Height="16px" Text="&nbsp;m²&nbsp;"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            Gerar Chamado:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="ChkGerarChamado" runat="server" />
            <asp:Label ID="LblChamadoLbl" runat="server" Text="Chamado nº:" Visible="False"></asp:Label>
            <asp:Label ID="LblChamado" runat="server" Font-Bold="False"></asp:Label></td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Gerar Pedido:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="ChkGerarPedido" runat="server" />
            <asp:Label ID="LblNrPedidoLbl" runat="server" Text="Pedido nº:" Visible="False"></asp:Label>
            <asp:Label ID="LblNrPedido" runat="server" Font-Bold="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style7" >
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    </table>
    <%--este é o html para pesquisa de emitentes--%><%--este é o html para incluir emitente via negociação--%><%--este é o html para alterar cadastro de emitente via negociação--%><%--este é o html para funcionar o botão de incluir contatos--%><%--este é o html para funcionar o botão de incluir contatos--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation3">
        <iframe id="IframeEdit" frameborder="0" width="420" height="600" scrolling="yes">
        </iframe>
    </div>
     <div id="DivEditWindow2" style="display: none;" class="popupConfirmation3">
        <iframe id="IframeEdit2" frameborder="0" width="420" height="400" scrolling="yes">
        </iframe>
    </div>
</body>