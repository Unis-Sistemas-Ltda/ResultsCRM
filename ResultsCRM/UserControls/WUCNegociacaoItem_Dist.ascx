<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoItem_Dist.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoItem_Dist" %>
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
        <td colspan="4" align="left" class="SubTituloMovimento">
            Item</td>
        <td align="left" class="SubTituloMovimento" style="padding: 2px 9px 2px 9px">
            &nbsp;</td>
        <td align="left" class="SubTituloMovimento" 
            
            style="border-left-style: solid; border-width: 1px; border-color: #DBDBDB; padding-left: 8px;">
            Acessórios &amp; Opcionais</td>
    </tr>
    <tr>
        <td class="Erro" colspan="4">
            <asp:Label ID="LblErro" runat="server"></asp:Label>

        </td>
        <td class="Erro">
            &nbsp;</td>
        <td align="left" valign="top" 
            
            style="border-left-style: solid; border-width: 1px; border-color: #DBDBDB; padding-left: 8px; text-align: right;" 
            width="100%">
            <asp:Button ID="BtnIncluirOpcional" runat="server" Text="Incluir/Alterar" onclientclick="ShowEditModal('../Pesquisas/WFPOpcionais.aspx','EditModalPopupOpcionais','IframeEditOpc');"
                Enabled="False" />

    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirOpcional" PopupControlID="DivEditWindowOpc" 
        OnCancelScript="EditCancelScript('IframeEditOpc');" OnOkScript="EditOkayScript('IframeEditOpc');"
        BehaviorID="EditModalPopupOpcionais">
    </cc1:ModalPopupExtender>

        </td>
    </tr>
    <tr>
        <td style="width: 95px; text-align: right;">
            Seq. Item:</td>
        <td class="CelulaCampoCadastro" colspan="3">
            <asp:Label ID="LblSeqItem" runat="server" Font-Bold="False"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
        <td align="left" rowspan="11" valign="top" 
            
            style="border-left-style: solid; border-width: 1px; border-color: #DBDBDB; padding-left: 8px;" 
            width="100%">
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
        <td style="text-align: right">
            Item:</td>
        <td class="CelulaCampoCadastro" colspan="3">
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
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label20" runat="server" Text="Narrativa:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" colspan="3">
            <asp:TextBox ID="TxtNarrativa" runat="server" CssClass="CampoCadastro" 
                Height="40px" TextMode="MultiLine" Width="383px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Referência:</td>
        <td class="CelulaCampoCadastro" colspan="3">
            <asp:DropDownList ID="DdlReferencia" runat="server" 
                CssClass="CampoCadastro" Width="383px">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            Natur. Oper:</td>
        <td class="CelulaCampoCadastro" colspan="3">
            <asp:DropDownList ID="DdlNaturOper" runat="server" CssClass="CampoCadastro" 
                Width="385px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right;">
            <asp:Label ID="Label15" runat="server" 
                Text="&nbsp;&nbsp;Quantidade:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" colspan="3">
            <asp:TextBox ID="TxtQuantidade" runat="server" AutoPostBack="True" 
                style="text-align:right" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
            <asp:Label ID="Label21" runat="server" Height="17px" 
                Text="&nbsp;&nbsp;&nbsp;Prazo de Entrega:"></asp:Label>
            <asp:TextBox ID="TxtPrazoEntrega" runat="server" CssClass="CampoCadastro" 
                MaxLength="4" Width="40px"></asp:TextBox>
            <asp:DropDownList ID="DdlTpPrazoEntrega" runat="server" 
                CssClass="CampoCadastro" Width="85px">
                <asp:ListItem Value="1">Dia(s)</asp:ListItem>
                <asp:ListItem Value="2">Mes(es)</asp:ListItem>
                <asp:ListItem Value="3">Ano(s)</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="LblAux1" runat="server"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux1" runat="server" CssClass="CampoCadastro" Width="145px" 
                Height="35px" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right; vertical-align: top">
            <asp:Label ID="LblAux2" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux2" runat="server" CssClass="CampoCadastro" Width="145px" 
                Height="35px" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="LblAux3" runat="server"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux3" runat="server" CssClass="CampoCadastro" Width="145px" 
                Height="35px" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right; vertical-align: top">
            <asp:Label ID="LblAux4" runat="server" Height="16px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAux4" runat="server" CssClass="CampoCadastro" Width="145px" 
                Height="35px" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="border: 1px solid #C0C0C0; vertical-align: top; text-align: right; width: 485px;" 
            colspan="4">
            <table style="width: 485px; border-collapse: collapse;">
                <tr>
                    <td colspan="6" style="text-align: left">
                        Preço Unitário</td>
                </tr>
                <tr>
                    <td style="width: 95px">
                        R$ Bruto:</td>
                    <td style="text-align: left">

            <asp:Label ID="LblPrecoUnitarioSemComponentes" runat="server" Text="0,0000" Width="60px" 
                            style="text-align:right"></asp:Label>
                    </td>
                    <td style="text-align: right">
                        R$ Opcionais:</td>
                    <td style="text-align: left">
                        <asp:Label ID="LblPrecoOpcionais" runat="server" Text="0,0000" 
                            Width="60px" style="text-align:right"></asp:Label>
                    </td>
                    <td>
                        R$ Unit. Orig.:</td>
                    <td width="62px">
                        <asp:Label ID="LblPrecoUnitarioTabela" runat="server" Text="0,0000" 
                            Width="60px" style="text-align:right"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        % Desc.:</td>
                    <td style="text-align: left">
            <asp:TextBox ID="TxtPercDescontoUnitario" runat="server" 
                style="text-align:right" CssClass="CampoCadastro" Width="60px" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td style="text-align: right">
                        % Acrésc.:</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TxtPercAcrescimoUnitario" runat="server" AutoPostBack="True" style="text-align:right"
                            CssClass="CampoCadastro" Width="60px"></asp:TextBox>
                    </td>
                    <td style="text-align: right">
                        R$ Unit. Líquido:</td>
                    <td style="text-align: left">
            <asp:TextBox ID="TxtPrecoUnitario" runat="server" AutoPostBack="True" 
                style="text-align:right" CssClass="CampoCadastro" Width="60px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right; border: 1px solid #C0C0C0; width: 485px" 
            colspan="4">
            <table style="width:485px; border-collapse: collapse;">
                <tr>
                    <td colspan="5" style="text-align: left">
                        Totais</td>
                </tr>
                <tr>
                    <td style="width: 95px">
                        % Desc.:</td>
                    <td style="text-align: left">
            <asp:TextBox ID="TxtPercDesconto" runat="server" AutoPostBack="True" 
                style="text-align:right" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
                    </td>
                    <td>
            ICMS: </td>
                    <td>
            <asp:Label ID="Label16" runat="server" Text="R$"></asp:Label>
&nbsp;<asp:Label ID="LblICMS" runat="server" Font-Bold="False">0,0000</asp:Label>
                    </td>
                    <td>
                        (<asp:Label ID="LblAliquotaICMS" runat="server" BackColor="#F0F0F0" 
                style="background-color: #FFFFFF">0</asp:Label>
            <asp:Label ID="Label8" runat="server" BackColor="#F0F0F0" Text="%" 
                style="background-color: #FFFFFF"></asp:Label>
                        )</td>
                </tr>
                <tr>
                    <td>
                        R$ Desc.:</td>
                    <td style="text-align: left">
            <asp:TextBox ID="TxtValorDesconto" runat="server" AutoPostBack="True" 
                style="text-align:right; height: 19px;" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
                    </td>
                    <td>
            <asp:Label ID="Label3" runat="server" Text="ICMS ST:"></asp:Label>
                    </td>
                    <td>
            <asp:Label ID="Label7" runat="server" Text="R$"></asp:Label>
&nbsp;<asp:Label ID="LblICMSST" runat="server" Font-Bold="False">0,0000</asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
            Vlr.&nbsp;Mercadoria:</td>
                    <td style="text-align: left">
            <asp:Label ID="Label12" runat="server" Text="R$" BorderStyle="None" 
                BorderWidth="1px"></asp:Label>
            &nbsp;<asp:Label ID="LblValorMercadoria" runat="server" Font-Bold="False" style="text-align:right"
                BorderStyle="None" BorderWidth="1px" Width="60px">0,00</asp:Label>
                    </td>
                    <td>
            <asp:Label ID="Label5" runat="server" Text="IPI:"></asp:Label>
                    </td>
                    <td>
            <asp:Label ID="Label17" runat="server" Text="R$"></asp:Label>
&nbsp;<asp:Label ID="LblIPI" runat="server" Font-Bold="False">0,0000</asp:Label>
                    </td>
                    <td>
                        (<asp:Label ID="LblAliquotaIPI" runat="server" BackColor="#F0F0F0" 
                style="background-color: #FFFFFF">0</asp:Label>
            <asp:Label ID="Label9" runat="server" BackColor="#F0F0F0" Text="%" 
                style="background-color: #FFFFFF"></asp:Label>
                        )</td>
                </tr>
                <tr>
                    <td>
                        Vlr. Total:</td>
                    <td style="text-align: left">
            <asp:Label ID="Label14" runat="server" BackColor="#ECFFEC" 
                BorderColor="#CCFFFF" Text="R$" BorderStyle="Solid" BorderWidth="1px" 
                Font-Bold="True" Height="16px"></asp:Label>
            <asp:Label ID="LblValorTotal" runat="server" Font-Bold="True" Font-Size="8pt" 
                style="text-align:right; background-color: #ECFFEC;" Width="60px" 
                BorderColor="#CCFFFF" BorderStyle="Solid" BorderWidth="1px" 
                ForeColor="#535353" Height="16px">0,00</asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:Button ID="Button1" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
        <td class="CelulaCampoCadastro" colspan="3">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" 
                Width="60px" />

            <asp:Label ID="LblQtdUD" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblBaseIcmsSubstituicao" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodEmitente" runat="server" Visible="False"></asp:Label>
            <asp:DropDownList ID="DdlUD" runat="server" CssClass="CampoCadastro" 
                Width="75px" AutoPostBack="True" Visible="False">
            </asp:DropDownList>
            <asp:Label ID="LblCNPJ" runat="server" Visible="False"></asp:Label>

            <asp:Label ID="LblValorUD" runat="server" Font-Bold="False" Text="0,0000" style="text-align:right"
                Width="60px" Visible="False"></asp:Label>

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

<%--este é o html para pesquisa de itens--%><%--frame onde é mostrado o popup--%>
    <div id="DivEditWindowOpc" style="display: none;" class="popupConfirmation714x390">
        <iframe id="IframeEditOpc" frameborder="0" width="714" height="390" scrolling="auto">
        </iframe>
    </div>