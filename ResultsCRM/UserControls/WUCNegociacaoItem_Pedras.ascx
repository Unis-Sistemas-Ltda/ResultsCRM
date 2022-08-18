<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoItem_Pedras.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoItem_Pedras" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
<table class="TextoCadastro_BGBranco" style="border-collapse: collapse" 
    width="100%">
    <tr>
        <td colspan="6" align="left" class="SubTituloMovimento">
            Item 
            Pedras</td>
        <td align="left" class="SubTituloMovimento" style="padding: 5px">
            &nbsp;</td>
        <td align="left" class="SubTituloMovimento" 
            style="border-left-style: solid; border-width: 1px; border-color: #DBDBDB">
            Acessórios &amp; Opcionais</td>
    </tr>
    <tr>
        <td class="Erro" colspan="6">
            <asp:Label ID="LblBaseIcmsSubstituicao" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodEmitente" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCNPJ" runat="server" Visible="False"></asp:Label>

        </td>
        <td class="Erro">
            &nbsp;</td>
        <td style="border-width: 1px; border-color: #DBDBDB; text-align: right; border-left-style: solid;">
            <asp:Button ID="BtnIncluirOpcional" runat="server" Text="Incluir/Alterar" onclientclick="ShowEditModal('../Pesquisas/WFPOpcionais.aspx','EditModalPopupOpcionais','IframeEditOpc');"
                Enabled="False" />

        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="6">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
        <td class="Erro">
            &nbsp;</td>
        <td align="left" rowspan="15" valign="top" 
            style="border-left-style: solid; border-width: 1px; border-color: #DBDBDB">
            <asp:GridView ID="GridView1" runat="server" CellPadding="3" 
                DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                AutoGenerateColumns="False" 
                EmptyDataText="&lt;br&gt;&lt;br&gt;Nenhum acessório/opcional foi incluído.&lt;br&gt;&lt;br&gt;Clique no botão acima para selecionar os acessórios e opcionais." 
                Font-Size="7pt" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="seq_item_estrutura" HeaderText="Seq." 
                        SortExpression="seq_item_estrutura">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Grupo" 
                        SortExpression="cod_componente">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cod_componente") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label18" runat="server" 
                                Text='<%# Eval("nome_grupo_configuracao") %>'></asp:Label>
                            (<asp:Label ID="Label1" runat="server" Text='<%# Bind("cod_componente") %>'></asp:Label>
                            )
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acessório/Opcional" 
                        SortExpression="cod_componente_alternativo">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" 
                                Text='<%# Bind("cod_componente_alternativo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label19" runat="server" Text='<%# Eval("nome_item_opcional") %>'></asp:Label>
                            (<asp:Label ID="Label2" runat="server" 
                                Text='<%# Bind("cod_componente_alternativo") %>'></asp:Label>
                            )
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="quantidade" DataFormatString="{0:F2}" 
                        HeaderText="Quantidade" SortExpression="quantidade">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="preco_unitario" DataFormatString="{0:F2}" 
                        HeaderText="Preço Unitário" SortExpression="preco_unitario">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="preco_total" DataFormatString="{0:F2}" 
                        HeaderText="Preço Total" SortExpression="preco_total">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                CommandArgument='<%# Eval("seq_item_estrutura") %>' CommandName="EXCLUIR" OnClientClick="return confirm('Deseja realmente excluir o acessório/opcional selecionado?');"
                                ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select n.seq_estrutura,
       n.cod_componente_alternativo,
       n.seq_item_estrutura,
       n.quantidade,
       e.cod_componente,
       n.largura,
       n.aba_esquerda,
       n.aba_direita,
       n.quantidade_total,
       n.preco_unitario,
       n.preco_total,
       e.exige_medidas,
       n.valor_fixo,
       n.tipo_valor,
       n.tipo_soma,
       n.preco_unitario as valor,
       ig.descricao nome_grupo_configuracao,
       io.descricao nome_item_opcional
  from negociacao_cliente_item_estrutura n inner join negociacao_cliente_item ni on ni.empresa                = n.empresa
                                                                                and ni.estabelecimento        = n.estabelecimento
                                                                                and ni.cod_negociacao_cliente = n.cod_negociacao_cliente
                                                                                and ni.seq_item               = n.seq_item
                                           inner join estrutura e on e.cod_item          = n.cod_item
                                                                 and trim(e.referencia)  = ni.referencia
                                                                 and e.seq_estrutura     = n.seq_estrutura
                                           inner join item ig on ig.cod_item = e.cod_componente
                                           inner join item io on io.cod_item = n.cod_componente_alternativo
 where n.empresa                = :empresa
   and n.estabelecimento        = :estabelecimento
   and n.cod_negociacao_cliente = :cod_negociacao
   and n.seq_item               = :seq_item
order by n.seq_estrutura">
                <SelectParameters>
                    <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                    <asp:SessionParameter Name=":estabelecimento" SessionField="GlEstabelecimento" />
                    <asp:SessionParameter Name=":cod_negociacao" SessionField="SCodNegociacao"/>
                    <asp:SessionParameter Name=":seq_item" SessionField="SSeqItemNegociacao" />
                </SelectParameters>
            </asp:SqlDataSource>

            <br />

            <asp:ImageButton ID="BtnAtualizarGrid" runat="server" Height="22px" 
                ImageUrl="~/Imagens/BtnIconeAtualizar.gif" ClientIDMode="Static"
                ToolTip="Atualizar lista de acessórios &amp; opcionais incluidos na negociação." />

        </td>
    </tr>
    <tr>
        <td style="width: 95px; text-align: right;">
            Seq. Item:</td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:Label ID="LblSeqItem" runat="server" Font-Bold="False"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Item:</td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:TextBox ID="TxtCodItem" runat="server" CssClass="CampoCadastro" 
                Width="90px" AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="BtnFiltrarItem" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPItemReferencia.aspx?textbox=TxtCodItem','EditModalPopupClientes','IframeEdit');" />

            <asp:Label ID="LblDescricaoItem" runat="server" Font-Bold="False" 
                Height="17px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Lote:</td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:DropDownList ID="DdlLote" runat="server" 
                CssClass="CampoCadastro" Width="383px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro">
          <asp:ImageButton ID="BtnFiltrarLotes" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar Lotes"
                
                
                onclientclick="ShowEditModal('../Pesquisas/WFPItemReferenciaLote.aspx?textbox=TxtCodItem','EditModalPopupLotes','IframeEdit');" />
            &nbsp;</td>
    </tr>   
    <tr>
        <td style="text-align: right">
            Natur. Oper:</td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:DropDownList ID="DdlNaturOper" runat="server" CssClass="CampoCadastro" 
                Width="385px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" colspan="5">
            <span>&nbsp;<asp:ImageButton ID="BtnIncluirEquipamento" runat="server" 
                AlternateText="Novo Equipamento" Height="16px" ToolTip="Incluir Equipamento" 
                ImageUrl="~/Imagens/BtnIncluir.png" 
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFEquipamento.aspx?aid=I','EditModalPopupClientes','IframeEdit');" 
                Enabled="False" />
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
                Enabled="False" />
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
                
                onclientclick="ShowEditModal('../Pesquisas/WFPEquipamento.aspx','EditModalPopupClientes','IframeEdit');" 
                Enabled="False" />
     <cc1:ModalPopupExtender ID="BtnPesquisarEquipamento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnPesquisarEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupPesquisarEquipamento">
    </cc1:ModalPopupExtender>
            </span>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: bottom">
            <asp:Label ID="Label15" runat="server" Height="16px" Text="Quantidade:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="vertical-align: bottom" width="77px">
            <asp:TextBox ID="TxtQuantidade" runat="server" AutoPostBack="True" 
                style="text-align:right" CssClass="CampoCadastro" Width="75px" 
                Enabled="False"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" 
            style="vertical-align: bottom; text-align: right" width="70">
            <asp:Label ID="Label2" runat="server" Height="16px" 
                Text="Preço Unit.:" ToolTip="Preço unitário"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="vertical-align: bottom" width="70">
            <uc1:TextBoxNumerico ID="TxtPrecoUnitario" runat="server" Width="75" 
                QtdCasas="4" AutoPostBack="True" />
        </td>
        <td class="CelulaCampoCadastro" 
            style="text-align: right; vertical-align: bottom" width="55">
            <asp:Label ID="Label11" runat="server" Height="16px" Text="UD:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="vertical-align: bottom">
            <asp:DropDownList ID="DdlUD" runat="server" CssClass="CampoCadastro" 
                Width="75px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="vertical-align: bottom">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Qtde. UD:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtQuantidadeUD" runat="server" AutoPostBack="True" 
                style="text-align:right" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Preço UD:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblValorUD" runat="server" Font-Bold="False" Text="0,0000" style="text-align:right"
                Width="77px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Desc.(R$):</td>
        <td class="CelulaCampoCadastro" width="77">
            <uc1:TextBoxNumerico ID="TxtValorDesconto" runat="server" Width="75" 
                QtdCasas="2" AutoPostBack="True" />
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Prazo Entrega:</td>
        <td class="CelulaCampoCadastro" colspan="2">
            <asp:TextBox ID="TxtPrazoEntrega" runat="server" CssClass="CampoCadastro" 
                style="margin-bottom: 0px" Width="30px"></asp:TextBox>
            <asp:DropDownList ID="DdlTpPrazoEntrega" runat="server" 
                CssClass="CampoCadastro">
                <asp:ListItem Value="1">Dia(s)</asp:ListItem>
                <asp:ListItem Value="2">Mês(es)</asp:ListItem>
                <asp:ListItem Value="3">Ano(s)</asp:ListItem>
            </asp:DropDownList>
            </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold;">
            Vlr.&nbsp;Merc.:</td>
        <td class="CelulaCampoCadastro" colspan="2">
            <asp:Label ID="Label12" runat="server" Text="R$" BorderStyle="None" 
                BorderWidth="1px"></asp:Label>
            &nbsp;<asp:Label ID="LblValorMercadoria" runat="server" Font-Bold="False" style="text-align:right"
                BorderStyle="None" BorderWidth="1px" Width="90px">0,00</asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold; font-size: 7pt;">
            ICMS: 
            </td>
        <td class="CelulaCampoCadastro" colspan="5" style="font-size: 7pt">
            <asp:Label ID="Label16" runat="server" Text="R$"></asp:Label>
&nbsp;<asp:Label ID="LblICMS" runat="server" Font-Bold="False">0,0000</asp:Label>
            &nbsp;(<asp:Label ID="LblAliquotaICMS" runat="server" BackColor="#F0F0F0" 
                style="background-color: #FFFFFF">0</asp:Label>
            <asp:Label ID="Label8" runat="server" BackColor="#F0F0F0" Text="%" 
                style="background-color: #FFFFFF"></asp:Label>
            )<asp:Label ID="Label3" runat="server" Text="&nbsp;&nbsp;&nbsp;ST:" 
                Font-Bold="True"></asp:Label>
            <asp:Label ID="Label7" runat="server" Text="&nbsp;R$"></asp:Label>
&nbsp;<asp:Label ID="LblICMSST" runat="server" Font-Bold="False">0,0000</asp:Label>
            <asp:Label ID="Label5" runat="server" Text="&nbsp;&nbsp;&nbsp;IPI:" 
                Font-Bold="True"></asp:Label>
            <asp:Label ID="Label17" runat="server" Text="&nbsp;R$"></asp:Label>
&nbsp;<asp:Label ID="LblIPI" runat="server" Font-Bold="False">0,0000</asp:Label>
            &nbsp;(<asp:Label ID="LblAliquotaIPI" runat="server" BackColor="#F0F0F0" 
                style="background-color: #FFFFFF">0</asp:Label>
            <asp:Label ID="Label9" runat="server" BackColor="#F0F0F0" Text="%" 
                style="background-color: #FFFFFF"></asp:Label>
            )</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label13" runat="server" Text="Vlr. Total:" Font-Bold="True"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:Label ID="Label14" runat="server" BackColor="#ECFFEC" 
                BorderColor="#CCFFFF" Text="R$" BorderStyle="Solid" BorderWidth="1px" 
                Font-Bold="True" Height="16px"></asp:Label>
            <asp:Label ID="LblValorTotal" runat="server" Font-Bold="True" Font-Size="8pt" 
                style="text-align:right; background-color: #ECFFEC;" Width="90px" 
                BorderColor="#CCFFFF" BorderStyle="Solid" BorderWidth="1px" 
                ForeColor="#535353" Height="16px">0,00</asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" colspan="5">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:Button ID="Button1" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" 
                Width="60px" />
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    </table>
<%--este é o html para pesquisa de itens--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarItem" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </cc1:ModalPopupExtender>

    <%--este é o html para pesquisa de lotes--%>
      <cc1:ModalPopupExtender ID="ModalPopupExtender5" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarLotes" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupLotes">
    </cc1:ModalPopupExtender>

  
<%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" onclick="document.getElementById('BtnAtualizarGrid').click()" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
<%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="480" height="350" scrolling="no">
        </iframe>
    </div>

<%--este é o html para pesquisa de itens--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirOpcional" PopupControlID="DivEditWindowOpc" 
        OnCancelScript="EditCancelScript('IframeEditOpc');" OnOkScript="EditOkayScript('IframeEditOpc');"
        BehaviorID="EditModalPopupOpcionais">
    </cc1:ModalPopupExtender>

<%--frame onde é mostrado o popup--%>
    <div id="DivEditWindowOpc" style="display: none;" class="popupConfirmation714x390">
        <iframe id="IframeEditOpc" frameborder="0" width="714" height="390" scrolling="auto">
        </iframe>
    </div>

