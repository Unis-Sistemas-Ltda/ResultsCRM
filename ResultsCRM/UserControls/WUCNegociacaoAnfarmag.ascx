<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoAnfarmag.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoAnfarmag" %>
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
        <td style="text-align: right; width: 195px;">
            Nº Negociação:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle" width="300px;">
            <asp:Label ID="LblNrNegociacao" runat="server" Font-Bold="False" 
                Font-Size="8pt" Width="75px"></asp:Label>
        &nbsp;<asp:Label ID="Label13" runat="server" Text="Nº Chamado:"></asp:Label>
            <asp:Label ID="LblCodChamado" runat="server"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right;">
            <asp:Label ID="LabelObra01" runat="server" Text="Tipo da Obra:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle">
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
        <td style="text-align: right">
            Data Cadastramento:</td>
        <td class="CelulaCampoCadastro" 
            style="">
            <asp:Label ID="LblDataCadastramento" runat="server" Font-Bold="False" 
                Font-Size="8pt"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" 
            style="text-align: right;">
            <asp:Label ID="LabelObra02" runat="server"
                Text="Modalidade:" ></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" 
            style="">
            <asp:DropDownList ID="DdlModalidadeObra" runat="server" CssClass="CampoCadastro" 
                Width="190px">
                <asp:ListItem Value="1">Nova</asp:ListItem>
                <asp:ListItem Value="2">Reforma</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; background-color: #FBFBF9;">
            <asp:Label ID="Label5" runat="server" Text="Cliente:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="background-color: #FBFBF9;">
            <asp:TextBox ID="TxtCliente" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Width="43px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtCliente&amp;varmp=SCodClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClientes','IframeEdit');" 
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
                &nbsp;</span><asp:Label ID="Label3" runat="server" Text="CNPJ:" 
                Height="17px"></asp:Label>
            <asp:DropDownList ID="DdlCNPJ" runat="server" CssClass="CampoCadastro" 
                Width="140px" AutoPostBack="True"/>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right; width: 155px">
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
        <td style="text-align: right; background-color: #FBFBF9;" valign="top">
            Nome:</td>
        <td class="CelulaCampoCadastro" 
            style="background-color: #FBFBF9;" valign="top">
            <asp:Label ID="LblNomeCliente" runat="server" Font-Bold="False"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" 
            style="text-align: right;">
            <asp:Label ID="LabelObra04" runat="server" Height="16px" Text="&nbsp;Tamanho:" style="text-align: right"
                Width="65px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" 
            style="">
            <asp:TextBox ID="TxtTamanhoObra" runat="server" CssClass="CampoCadastro" 
                Width="40px"></asp:TextBox>
            <asp:Label ID="LabelObra05" runat="server" Height="16px" Text="&nbsp;m²&nbsp;"></asp:Label>
        &nbsp;
        </td>
    </tr>
    <tr>
        <td style="text-align: right; background-color: #FBFBF9;" valign="top" >
            Endereço:</td>
        <td class="CelulaCampoCadastro" 
            style="background-color: #FBFBF9;">
            <asp:Label ID="LblEndereco" runat="server"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" 
            style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" 
            style="">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1" style="text-align: right; background-color: #FBFBF9;" >
            <span style="text-align: right">Contato:</span></td>
        <td class="CelulaCampoCadastro" style="background-color: #FBFBF9;">
            <asp:DropDownList ID="DdlContato" runat="server" CssClass="CampoCadastro" 
                Width="240px" AutoPostBack="True">
            </asp:DropDownList>
            <span>
            &nbsp;<asp:ImageButton ID="BtnIncluirContato" runat="server" 
                AlternateText="Novo Contato" Height="16px" ToolTip="Novo contato" 
                ImageUrl="~/Imagens/BtnIncluir.png" 
                
                
                
                onclientclick="ShowEditModal('../Forms/WFContato.aspx?a=I&amp;vrecc=SRecarregaDdlContatos&amp;vcodc=SCodContatoNegociacao&amp;vcode=SCodEmitenteNegociacao&amp;ptat=','EditModalPopupIncluirContato','IframeEdit');" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender3" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirContato" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirContato">
    </cc1:ModalPopupExtender>
            &nbsp;<asp:ImageButton ID="BtnAlterarContato" runat="server" 
                AlternateText="Alterar contato" Height="16px" 
                ToolTip="Alterar informações do contato" 
                ImageUrl="~/Imagens/BtnEditar.png" 
                
                
                
                onclientclick="ShowEditModal('../Forms/WFContato.aspx?a=A&amp;vrecc=SRecarregaDdlContatos&amp;vcodc=SCodContatoNegociacao&amp;vcode=SCodEmitenteNegociacao&amp;ptat=','EditModalPopupIncluirContato','IframeEdit');" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender4" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarContato" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarContato">
    </cc1:ModalPopupExtender>
            </span>
        </td>
       
    </tr>
    <tr>
        <td class="style1" style="text-align: right; background-color: #FBFBF9;" >
            <asp:Label ID="Label12" runat="server" Text="Telefone(s):"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="background-color: #FBFBF9;">
            <asp:Label ID="LblTelefone" runat="server"></asp:Label> - 
            <asp:Label ID="LblCelular" runat="server"></asp:Label>
        </td>
       
    </tr>
    <tr>
        <td style="text-align: right; background-color: #FBFBF9;">
            E-mail:</td>
        <td class="CelulaCampoCadastro" 
            style="background-color: #FBFBF9;">
            <asp:Label ID="LblEmail" runat="server"></asp:Label>
        </td>
       
    </tr>
    <tr>
         <td style="text-align: right" >
            <asp:Label ID="Label9" runat="server" Text="&nbsp;Gestor:" style="text-align: right"
                Width="65px"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlGestor" runat="server" CssClass="CampoCadastro" 
                Width="240px">
            </asp:DropDownList>
        </td>
       
    </tr>
    <tr>
        <td style="text-align: right" >
            Agente de Vendas:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlAgente" runat="server" CssClass="CampoCadastro" 
                Width="240px">
            </asp:DropDownList>
        </td>
        
    </tr>
    <tr>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Funil:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlFunil" runat="server" CssClass="CampoCadastro" 
                Width="190px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
     
    </tr>
    <tr>
         <td class="CelulaCampoCadastro" style="text-align: right">
            Etapa:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlEtapa" runat="server" CssClass="CampoCadastro" 
                Width="190px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
      
    </tr>
    <tr>
       <td class="CelulaCampoCadastro" 
            style="text-align: right">
            Status:</td>
        <td class="CelulaCampoCadastro" 
            style="">
            <asp:DropDownList ID="DdlStatus" runat="server" CssClass="CampoCadastro" 
                Width="190px">
            </asp:DropDownList>
        </td>
        
    </tr>
    <tr>
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
        <td class="CelulaCampoCadastro" style="text-align: right">
            Motivo Fechamento:
        </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlMotivoFechamento" runat="server" CssClass="CampoCadastro" Width="190px"  AutoPostBack="True"></asp:DropDownList>
        </td>
       
    </tr>
    <tr>
           <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Label8" runat="server" Height="16px" Text="Origem:" style="text-align: right"
                Width="65px"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlFonteOrigem" runat="server" CssClass="CampoCadastro" 
                Width="190px">
            </asp:DropDownList>
        </td>
       
    </tr>
    <tr>
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
       <td class="CelulaCampoCadastro" style="text-align: right">
            Validade da Proposta:</td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtDataValidadeProposta" runat="server" Width="90" />
        </td>
       
    </tr>
    <tr>
           <td class="CelulaCampoCadastro" style="text-align: right">
            Data/Hora Recontato:</td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtDataRecontato" runat="server" Width="90" />
            <uc2:TextBoxHora ID="TxtHoraRecontato" runat="server" Width="58"/>
        </td>
        
    </tr>
    <tr>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Previsão Fechamento:</td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtPrevisaoFechamento" runat="server" Width="90" />
        </td>
      
    </tr>
    <tr>
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
       
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
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
        <iframe id="IframeEdit" frameborder="0" width="420" height="550" scrolling="no">
        </iframe>
    </div>
</body>