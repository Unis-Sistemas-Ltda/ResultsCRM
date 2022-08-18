<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCEquipamento2.ascx.vb" Inherits="ResultsCRM.WUCEquipamento2" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />

<script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFEquipamento.aspx";
        }
        function onSuccess() {
            window.parent.document.getElementById('ButtonEditDone').click();
            window.parent.document.forms.item(0).submit();
        }
        function onError() {
            getbacktostepone();
        }
        function cancel() {
            window.parent.document.getElementById('ButtonEditCancel').click();
        }
    </script>

<body class="TextoCadastro_BGBranco">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="VwCadastro" runat="server">
            <table class="TextoCadastro_BGBranco" 
                style="width: 100%; border-collapse: collapse;">
                <tr>
                    <td class="TituloCadastro" colspan="3">
                        <asp:Label ID="LblTitulo" runat="server" 
                            Text="Detalhe do Cadastro de Equipamento"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Cód. Cliente:</td>
                    <td colspan="2">
                        <asp:Label ID="LblCodCliente" runat="server"></asp:Label>
                        &nbsp;
                        <asp:Label ID="LblCNPJLabel" runat="server" Text="CNPJ:"></asp:Label>
                        <asp:Label ID="LblCNPJ" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Ponto Atend.:</td>
                    <td colspan="2">
                        <asp:Label ID="LblDescricaoPontoAtendimento" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        Cód.
                        <asp:Label ID="LblCodEquipamentoLbl" runat="server" Text="Equipamento"></asp:Label>
                        :</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtNumeroSerie" runat="server" CssClass="CampoCadastro" 
                            Width="125px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="CBxAtivo" runat="server" Height="16px" Text="Ativo:" 
                            TextAlign="Left" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        Item:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtCodItem" runat="server" AutoPostBack="True" 
                            CssClass="CampoCadastro" Width="80px"></asp:TextBox>
                        <asp:ImageButton ID="BtnFiltrarItem0" runat="server" 
                            ImageUrl="~/Imagens/search.png" style="width: 16px" ToolTip="Pesquisar" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        Desc.Item:</td>
                    <td colspan="2">
                        <asp:Label ID="LblDescricaoItem" runat="server" Font-Bold="True" Height="17px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; vertical-align: top;">
                        Referência:</td>
                    <td colspan="2">
                        <asp:DropDownList ID="DdlReferencia" runat="server" CssClass="CampoCadastro" 
                            Width="235px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; vertical-align: top;">
                        Lote:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtLote" runat="server" CssClass="CampoCadastro" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Desc. Equipamento:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtObservacao" runat="server" CssClass="CampoCadastro" 
                            Width="230px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Estabelecimento:</td>
                    <td colspan="2">
                        <asp:DropDownList ID="DdlEstabelecimentoNFS" runat="server" 
                            CssClass="CampoCadastro" Width="235px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Nº NF:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtNF" runat="server" CssClass="CampoCadastro" Width="70px"></asp:TextBox>
                        <asp:Label ID="LblCNPJLabel0" runat="server" Height="17px" 
                            Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Série NF:" Width="80px"></asp:Label>
                        <asp:TextBox ID="TxtSerie" runat="server" CssClass="CampoCadastro" 
                            Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Nº OP:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtOP" runat="server" CssClass="CampoCadastro" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Ref. Garantia:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtReferenciaGarantia" runat="server" CssClass="CampoCadastro" 
                            Width="70px"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="TxtReferenciaGarantia_MaskedEditExtender" 
                            runat="server" BehaviorID="TxtReferenciaGarantia_MaskedEditExtender" 
                            Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureName="pt-BR" CultureThousandsPlaceholder="" CultureTimePlaceholder="" 
                            Mask="99/99/9999" MaskType="Date" TargetControlID="TxtReferenciaGarantia" 
                            UserDateFormat="DayMonthYear" />
                        <asp:Label ID="LblCNPJLabel1" runat="server" Height="17px" 
                            Text="&nbsp;Val.Garantia:" Width="80px"></asp:Label>
                        <asp:TextBox ID="TxtValidadeGarantia" runat="server" CssClass="CampoCadastro" 
                            Width="70px"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="TxtValidadeGarantia_MaskedEditExtender" 
                            runat="server" BehaviorID="TxtValidadeGarantia_MaskedEditExtender" 
                            Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureName="pt-BR" CultureThousandsPlaceholder="" CultureTimePlaceholder="" 
                            Mask="99/99/9999" MaskType="Date" TargetControlID="TxtValidadeGarantia" 
                            UserDateFormat="DayMonthYear" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Última Preventiva:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtUltimaPreventiva" runat="server" CssClass="CampoCadastro" 
                            Width="70px"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="TxtUltimaPreventiva_MaskedEditExtender" 
                            runat="server" BehaviorID="TxtUltimaPreventiva_MaskedEditExtender" 
                            Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureName="pt-BR" CultureThousandsPlaceholder="" CultureTimePlaceholder="" 
                            Mask="99/99/9999" MaskType="Date" TargetControlID="TxtUltimaPreventiva" 
                            UserDateFormat="DayMonthYear" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
                        &nbsp;
                        <asp:Button ID="BtnVoltarGeral" runat="server" CssClass="Botao" Text="Voltar" 
                            Visible="False" />
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="btnCancel" runat="server" BorderStyle="None" CssClass="Botao" OnClientClick="cancel();"
                            Font-Overline="False" Font-Underline="True" Text="Fechar" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="VwPesquisaItem" runat="server">
            <table class="TextoCadastro" style="width: 350px; height: 340px;">
                <tr>
                    <td class="TituloConsulta" colspan="3" style="height: 20px">
                        Pesquisa de Itens</td>
                </tr>
                <tr>
                    <td style="height: 25px">
                        <asp:Label ID="LblFornecedor" runat="server" 
                            Text="Informe o nome ou parte do nome do item:"></asp:Label>
                    </td>
                    <td class="CelulaCampoCadastro">
                        <asp:TextBox ID="TxtNome" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td class="CelulaCampoCadastro">
                        <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Filtrar" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="vertical-align: top">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                            CssClass="CampoCadastro" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                            GridLines="None" PageSize="8" Width="350px">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtnSelecionar" runat="server" 
                                            CommandArgument='<%# Eval("cod_item") %>' CommandName="SELECIONAR" 
                                            ForeColor="Black" Text='<%# Eval("descricao") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Código" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="LblCodigo" runat="server" Text='<%# Eval("cod_item") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings FirstPageText="1&nbsp;" LastPageText="Última" 
                                Mode="NumericFirstLast" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand=" select i.cod_item, i.descricao || ' (' || cod_item || ')' descricao
       from item i left outer join familia f on i.cod_plano_familia = f.cod_plano_familia and i.cod_familia = f.cod_familia
      where i.descricao like '%' || isnull(:nome,'') || '%'
        and trim(i.descricao) &lt;&gt; ''
        and trim(i.descricao) &lt;&gt; '-'
        and isnull(f.comercial,'N') = if :comercial = 'True' then 'S' else isnull(f.comercial,'N') endif
        and i.aplicacao = 1
      order by i.descricao">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtNome" ConvertEmptyStringToNull="False" 
                                    Name=":nome" PropertyName="Text" DbType="String" />
                                <asp:ControlParameter ControlID="ChkComercial" DbType="String" 
                                    Name=":comercial" PropertyName="Checked" 
                                    ConvertEmptyStringToNull="False" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 16px; text-align: left;">
                        <asp:CheckBox ID="ChkComercial" runat="server" Checked="True" 
                            Text="Mostrar somente itens de famílias comerciais" />
                        &nbsp;</td>
                    <td colspan="1" style="height: 16px">
                        <asp:Button ID="BtnVoltarParaEquipamento" runat="server" CssClass="Botao" 
                            Text="Voltar" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    </body>