<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAtendimentoPedidoSolicitacao.ascx.vb" Inherits="ResultsCRM.WUCAtendimentoPedidoSolicitacao" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table class="TextoCadastro_BGBranco" 
    style="width:100%; empty-cells: hide; border-collapse: collapse;">
    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="font-style: italic">
            Itens Solicitados</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr> 
    <tr>
        <td style="text-align: right">
            Seq. Solicitação:</td>
        <td>
            <asp:Label ID="LblSeqSolicitacao" runat="server" Font-Bold="True" Width="200px"></asp:Label>
            <asp:Label ID="LblAcao" runat="server" BackColor="#ECFFEC" Font-Bold="True" style="text-align:center"
                Width="138px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; text-align: right; " 
            class="CampoCadastro">
            <asp:Label ID="LblEquipamentoLabel" runat="server" Text="Equipamento:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DdlEquipamento" runat="server" CssClass="CampoCadastro" 
                Width="285px" AutoPostBack="True">
            </asp:DropDownList>
        &nbsp;<span><asp:ImageButton ID="BtnIncluirEquipamento" runat="server" 
                AlternateText="Novo Equipamento" Height="16px" ToolTip="Incluir Equipamento" 
                ImageUrl="~/Imagens/BtnIncluir.png" 
                
                
                
                onclientclick="ShowEditModal('../Forms/WFEquipamento.aspx?aid=I','EditModalPopupClientes','IframeEdit');" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender3" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirContato">
    </cc1:ModalPopupExtender>
            &nbsp;<asp:ImageButton ID="BtnAlterarEquipamento" runat="server" 
                AlternateText="Alterar equipamento" Height="16px" 
                ToolTip="Alterar informações do Equipamento" 
                ImageUrl="~/Imagens/BtnEditar.png" 
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFEquipamento.aspx?aid=A','EditModalPopupClientes','IframeEdit');" 
                style="width: 9px" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender4" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarContato">
    </cc1:ModalPopupExtender>
            &nbsp;<asp:ImageButton ID="BtnPesquisarEquipamento" runat="server" 
                AlternateText="Pesquisar equipamento" Height="16px" 
                ToolTip="Pesquisar Equipamento" 
                ImageUrl="~/Imagens/search.png" 
                onclientclick="ShowEditModal('../Pesquisas/WFPEquipamento.aspx','EditModalPopupClientes','IframeEdit');" />
     <cc1:ModalPopupExtender ID="BtnPesquisarEquipamento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnPesquisarEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupPesquisarEquipamento">
    </cc1:ModalPopupExtender>
            </span>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; text-align: right; " 
            class="CampoCadastro">
            <asp:Label ID="LblComponenteLabel" runat="server" Text="Componente:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DdlComponente" runat="server" CssClass="CampoCadastro" 
                Width="275px">
            </asp:DropDownList>
            <asp:Button ID="BtnIncluir" runat="server" CssClass="Botao" Text="Vincular" 
                ToolTip="Vincular componente" />
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" CssClass="TextoCadastro" DataKeyNames="cod_item" 
                DataSourceID="SqlDataSource1" 
                ForeColor="#333333" GridLines="None" Width="341px">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="seq_componente" HeaderText="Seq." 
                        SortExpression="seq_componente">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Componente" SortExpression="descricao">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                            (<asp:Label ID="Label4" runat="server" Text='<%# Eval("cod_item") %>'></asp:Label>
                            )
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("observacao") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                CommandArgument='<%# Eval("chave") %>' CommandName="EXCLUIR" 
                                ImageUrl="~/Imagens/BtnExcluir.png" 
                                onclientclick="return confirm('Deseja realmente excluir o registro selecionado?');" 
                                ToolTip="Excluir" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select eqc.cod_item, it.descricao, eqc.observacao, eqc.seq_componente, eqc.numero_serie || '§' || eqc.seq_componente chave
  from equipamento_componente eqc inner join item it on eqc.cod_item = it.cod_item
                                  inner join pedido_venda_solicitacao_equipamento_componente peqc on peqc.empresa = eqc.empresa
                                                                                          and peqc.numero_serie = eqc.numero_serie
                                                                                          and peqc.seq_componente = eqc.seq_componente
where peqc.empresa = :empresa
  and peqc.estabelecimento = :estabelecimento
  and peqc.cod_pedido_venda = :cod_pedido_venda
  and peqc.seq_solicitacao = :seq_solicitacao
order by it.descricao">
                <SelectParameters>
                    <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                    <asp:SessionParameter Name=":estabelecimento" 
                        SessionField="GlEstabelecimento" />
                    <asp:SessionParameter Name=":cod_pedido_venda" SessionField="SAtCodPedido" />
                    <asp:ControlParameter ControlID="LblSeqSolicitacao" Name=":seq_solicitacao" 
                        PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; text-align: right; vertical-align: top; ">
            Descrição:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtServicoSolicitado" runat="server" CssClass="CampoCadastro" 
                Height="42px" TextMode="MultiLine" Width="343px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top; padding-top: 5px">
            Tipos de Serviço:</td>
        <td>
            <asp:CheckBoxList ID="CbxServico" runat="server" RepeatColumns="2" 
                Width="343px">
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnSalvar" runat="server" CssClass="Botao" Text="Incluir" 
                ToolTip="Salva este registro e volta à tela anterior." />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" Visible="False" />
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
