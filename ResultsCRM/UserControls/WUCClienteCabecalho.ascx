<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCClienteCabecalho.ascx.vb" Inherits="ResultsCRM.WUCClienteCabecalho" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<style type="text/css">
    .style1
    {
        font-family: "Courier New";
    }
    .auto-style1 {
        width: 439px;
    }
</style>

<body  class="TextoCadastro">

<asp:DropDownList ID="DdlTipo" runat="server" CssClass="CampoCadastro" visible=false
                Width="100px">
                <asp:ListItem Value="1">Fornecedor</asp:ListItem>
                <asp:ListItem Selected="True" Value="2">Cliente</asp:ListItem>
                <asp:ListItem Value="3">Ambos</asp:ListItem>
            </asp:DropDownList>
<table class="TextoCadastro" 
        style="width:100%; background-color: #FFFFFF; font-size: 7pt;">
   <%-- <tr>
        <td class="TituloCadastro" colspan="2">
            Cadastro de Clientes</td>
    </tr>--%>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodEmitente" runat="server" Font-Bold="True" Height="16px"></asp:Label>
        &nbsp;           
            <asp:Label ID="LblCNPJLbl" runat="server" Text="CNPJ"></asp:Label>
            :<asp:Label ID="LblCNPJ" runat="server" Font-Bold="True" Text="0"></asp:Label>
        </td>
    </tr>
    <tr >
        <td style="text-align: right" class="auto-style1">
            Nome/Razão Social:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtNome" runat="server" CssClass="CampoCadastro" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            Fantasia/Apelido:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtFantasia" runat="server" CssClass="CampoCadastro" 
                Width="250px"></asp:TextBox>
        </td>
    </tr>
   
     <tr >
        <td style="text-align: right" class="auto-style1">
             <asp:Label ID="LblTxtEndereco" runat="server" Font-Bold="True">Endereço:</asp:Label>
            </td>
        <td style="text-align: left">
            <asp:Label ID="LblLogradouro" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
     <tr>
        <td style="text-align: right" class="auto-style1">
            <asp:Label ID="LblTxtBairro" runat="server" Font-Bold="True">Bairro:</asp:Label>
            </td>
        <td style="text-align: left">
            &nbsp;<asp:Label ID="LblBairro" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
             <asp:Label ID="LblTxtCEP" runat="server" Font-Bold="True">CEP:</asp:Label>
            </td>
        <td style="text-align: left">
            <asp:Label ID="LblCEP" runat="server" Font-Bold="True"></asp:Label>
            &nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            <asp:Label ID="LblTxtCidadeUF" runat="server" Font-Bold="True">Cidade/UF:</asp:Label>
            </td>
        <td style="text-align: left">
            <asp:Label ID="LblCidade" runat="server" Font-Bold="True"></asp:Label>
             <asp:Label ID="LblCidadeBarra" runat="server" Font-Bold="True">&nbsp;/</asp:Label>

            <asp:Label ID="LblUF" runat="server" Font-Bold="True"></asp:Label>
            <asp:Label ID="LblUFTraco" runat="server" Font-Bold="True">&nbsp;-</asp:Label>

            <asp:Label ID="LblPais" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
   
    <tr>
        <td style="text-align: right" class="auto-style1">
              <asp:Label ID="LblTxtTelefones" runat="server" Font-Bold="True">Telefone(s):</asp:Label>
            </td>
        <td style="text-align: left">
            <asp:Label ID="LblTelefones" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            <asp:Label ID="LblTxtFax" runat="server" Font-Bold="True">Fax:</asp:Label>
            </td>
        <td style="text-align: left">
            <asp:Label ID="LblFax" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
             <asp:Label ID="LblTxtEmail" runat="server" Font-Bold="True">E-mail:</asp:Label>
            </td>
        <td style="text-align: left">
            <asp:Label ID="LblEmail" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
     <tr>
        <td style="text-align: right" class="auto-style1">
            <asp:Label ID="LblTxtContatoPreferencial" runat="server" Font-Bold="True">Contato Preferencial:</asp:Label>
            </td>
        <td style="text-align: left">
            <asp:Label ID="LblContatoPreferencial" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
             <asp:Label ID="LblTxtSenha" runat="server" Font-Bold="True">Senha:</asp:Label>
            </td>
        <td style="text-align: left">
            <asp:Label ID="LblSenha" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
     <tr>
        <td class="auto-style1">
            &nbsp;</td>
        <td style="text-align: left">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            Situação do Emitente:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlSituacao" runat="server" CssClass="CampoCadastro" 
                Width="150px">
                <asp:ListItem Value="1">Potencial</asp:ListItem>
                <asp:ListItem Value="4">Em Ativação</asp:ListItem>
                <asp:ListItem Selected="True" Value="2">Ativo</asp:ListItem>
                <asp:ListItem Value="5">Ativo Pend. Documental</asp:ListItem>
                <asp:ListItem Value="3">Inativo</asp:ListItem>
                <asp:ListItem Value="6">Encerrou as Atividades</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            Procedência:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlProcedencia" runat="server" CssClass="CampoCadastro" 
                Width="150px">
                <asp:ListItem Selected="True" Value="N">Nacional</asp:ListItem>
                <asp:ListItem Value="I">Internacional</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            Natureza:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlNatureza" runat="server" CssClass="CampoCadastro" 
                Width="150px">
                <asp:ListItem Value="1">Indústria</asp:ListItem>
                <asp:ListItem Value="2">Revenda</asp:ListItem>
                <asp:ListItem Value="3">Serviço</asp:ListItem>
                <asp:ListItem Value="4">Consumo</asp:ListItem>
                <asp:ListItem Value="5">Produtor Rural</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td class="auto-style1" style="text-align: right">
            Preferencial:</td>
        <td style="text-align: left">
            <asp:Label ID="LblPreferencial" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style1" style="text-align: right">
            Associado:</td>
        <td style="text-align: left">
            <asp:Label ID="LblAssociado" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
      <tr>
        <td style="text-align: right;" >
            <asp:Label ID="Label1" runat="server" Text="Proprietário:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" >
            <asp:TextBox ID="TxtProprietario" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Width="43px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarProprietario" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtProprietario&amp;varmp=SCodProprietarioPesquisado&amp;varma=SAlterouCodProprietario','EditModalPopupProprietario','IframeEdit');" 
                Height="16px" Width="16px" />
                <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarProprietario" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupProprietario">
    </cc1:ModalPopupExtender>
           
        &nbsp;<asp:Label ID="LblProprietario" runat="server" Font-Bold="True"></asp:Label>
           
        </td>       
       
    </tr>
    <tr>
        <td style="text-align: right;" >
            <asp:Label ID="Label3" runat="server" Text="Pessoa Física:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" >
            <asp:TextBox ID="TxtPessoaFisica" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Width="43px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarPessoaFisica" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtPessoaFisica&amp;varmp=SCodPessoaFisicaPesquisado&amp;varma=SAlterouCodPessoaFisica','EditModalPopupPessoaFisica','IframeEdit');" 
                Height="16px" Width="16px" />
                <cc1:ModalPopupExtender ID="ModalPopupExtender3" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarPessoaFisica" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupPessoaFisica">
    </cc1:ModalPopupExtender>
           
        &nbsp;<asp:Label ID="LblPessoaFisica" runat="server" Font-Bold="True"></asp:Label>
           
        </td>       
       
    </tr>
     <tr>
        <td style="text-align: right;" >
            <asp:Label ID="Label2" runat="server" Text="Franquia/Bandeira:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" >
            <asp:TextBox ID="TxtFranquia" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Width="43px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarFranquia" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtFranquia&amp;varmp=SCodFranquiaPesquisada&amp;varma=SAlterouCodFranquia','EditModalPopupFranquia','IframeEdit');" 
                Height="16px" Width="16px" />
                <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarFranquia" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupFranquia">
    </cc1:ModalPopupExtender>
           
        &nbsp;<asp:Label ID="LblFranquia" runat="server" Font-Bold="True"></asp:Label>
           
        </td>       
       
    </tr>
    <tr>
        <td style="text-align: right;" >
            <asp:Label ID="Label6" runat="server" Text="Rede Associativa:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" >
            <asp:TextBox ID="TxtRedeAssociativa" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Width="43px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtRedeAssociativa&amp;varmp=SCodRedeAssocPesquisada&amp;varma=SAlterouCodRedeAssoc','EditModalPopupRedeAssociativa','IframeEdit');" 
                Height="16px" Width="16px" />
                <cc1:ModalPopupExtender ID="ModalPopupExtender4" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupRedeAssociativa">
    </cc1:ModalPopupExtender>
           
        &nbsp;<asp:Label ID="lblRedeAssociativa" runat="server" Font-Bold="True"></asp:Label>
           
        </td>       
       
    </tr>
     
    <tr>
        <td style="text-align: right" class="auto-style1">
            Confirmar Encerramento OS:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxConfirma" runat="server" Text="&nbsp;" />
            <span class="style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span>
            <asp:CheckBox ID="ChkExigeFotoOS" runat="server" Text="Exige Foto (OS):" 
                TextAlign="Left" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            Funcionário:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="ChkFuncionario" runat="server" Text=" " />
            <span class="style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span>
            <asp:CheckBox ID="ChkTransportador" runat="server" Text="Transportador:" 
                TextAlign="Left" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            Vendedor:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="ChkRepresentante" runat="server" Text=" " />
            <span class="style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span>&nbsp;<asp:CheckBox ID="ChkLicenciador" runat="server" Text="Licenciador:" 
                TextAlign="Left" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            Cliente:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="ChkCliente" runat="server" Text=" " />
            <span class="style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span>&nbsp;<asp:CheckBox ID="ChkFornecedor" runat="server" Text="Fornecedor:" 
                TextAlign="Left" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            Optante pelo Simples:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="ChkOptanteSimples" runat="server" />
               <span class="style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span>&nbsp;<asp:CheckBox ID="ChkDistribuidor" runat="server" Text="Distribuidor:" 
                TextAlign="Left" />
        </td>
    </tr>
    <tr style="">
        <td style="text-align: right" class="auto-style1">
            <asp:Label ID="LblGrupoEmitente" runat="server" Text="Grupo de Emitente:" 
                Visible="False"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            
            <asp:DropDownList ID="DdlMercado" runat="server" CssClass="CampoCadastro" 
                Width="150px">
            </asp:DropDownList>
            
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            <asp:Label ID="LblDataCadastramentoLBL" runat="server" 
                Text="Data Cadastramento:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblDataCadastro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            <asp:Label ID="LblUsuarioCadastramentoLBL" runat="server" 
                Text="Usuário Cadastramento:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblUsuarioCadastro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style1">
            <asp:Label ID="LblDataAlteracalLBL" runat="server" Text="Data Alteração:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblDataAlteracao" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style=" text-align: right;" class="auto-style1">
            <asp:Label ID="LblUsuarioAlteracaoLBL" runat="server" Text="Usuário Alteração:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblUsuarioAlteracao" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            &nbsp;</td>
        <td style="text-align: left">
            <asp:Label ID="LblInadimplente" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Button ID="btnOkay" runat="server" CssClass="Botao" 
                OnClick="btnOkay_Click" Text="Done" Visible="False" />
        </td>
        <td style="text-align: left">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" />
            <asp:Button ID="BtnCancelar" runat="server" CssClass="Botao" Text="Cancelar" />
&nbsp;&nbsp;
            <asp:Button ID="BtnProximo" runat="server" CssClass="Botao" Text="Continuar" 
                Visible="False" />
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
        <iframe id="IframeEdit" frameborder="0" width="420" height="600" scrolling="no">
        </iframe>
    </div>
     
   
</body>