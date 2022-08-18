<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCEquipamento.ascx.vb" Inherits="ResultsCRM.WUCEquipamento" %>
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
            <table class="TextoCadastro_BGBranco" style="width: 100%;">
                <tr>
                    <td class="TituloCadastro" colspan="3">
                        <asp:Label ID="LblTitulo" runat="server" 
                            Text="Detalhe do Cadastro de Equipamento"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="3">
                        &nbsp;</td>
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
                        Nº Série:</td>
                    <td colspan="2">
                        <asp:Label ID="LblNrSerie" runat="server" Font-Bold="True" Height="16px"></asp:Label>
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
                            CssClass="CampoCadastro" Width="50px"></asp:TextBox>
                        <asp:ImageButton ID="BtnFiltrarItem1" runat="server" 
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
                        Desc. Equipamento:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtObservacao" runat="server" CssClass="CampoCadastro" 
                            Width="230px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="LblNumeroControle" runat="server" Text="Nº Patrimônio"></asp:Label>
                        :</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtRegPatrimonial" runat="server" CssClass="CampoCadastro" 
                            Width="160px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Nº Série Terceiro:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtNumeroSerieTerceiro" runat="server" 
                            CssClass="CampoCadastro" Width="160px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Placa:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtPlaca" runat="server" CssClass="CampoCadastro" Width="160px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Quantidade:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtQuantidade" runat="server" CssClass="CampoCadastro" Width="160px"></asp:TextBox>
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
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Continuar" />
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
                    <td class="TituloConsulta" colspan="4" style="height: 20px">
                        Pesquisa de Itens</td>
                </tr>
                <tr>
                    <td style="height: 25px">
                        <asp:Label ID="LblFornecedor" runat="server" 
                            Text="Informe o nome ou parte do nome do item:"></asp:Label>
                    </td>
                    <td class="CelulaCampoCadastro" colspan="2">
                        <asp:TextBox ID="TxtNome" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td class="CelulaCampoCadastro">
                        <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Filtrar" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="vertical-align: top">
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
                    <td colspan="3" style="height: 16px; text-align: left;">
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
        <asp:View ID="VwComponentes" runat=server>
            <table class="TextoCadastro_BGBranco" style="width:100%;">
                <tr>
                    <td class="TituloCadastro" colspan="2">
                        Componentes do
                        <asp:Label ID="LblTituloPasso2" runat="server" Text="Equipamento"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Cód. Cliente:</td>
                    <td style="text-align: left">
                        <asp:Label ID="LblCodClienteComponente" runat="server"></asp:Label>
                        &nbsp;
                        <asp:Label ID="LblCNPJLabel0" runat="server" Text="CNPJ:"></asp:Label>
                        <asp:Label ID="LblCNPJComponente" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Ponto Atend.:</td>
                    <td style="text-align: left">
                        <asp:Label ID="LblDescricaoPontoAtendimentoComponente" runat="server" 
                            Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Cód.
                        <asp:Label ID="LblCodEquipamentoLbl0" runat="server" Text="Equipamento"></asp:Label>
                        :</td>
                    <td style="text-align: left">
                        <asp:Label ID="LblNrSerieComponente" runat="server" Font-Bold="True" 
                            Height="16px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Item:</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TxtCodItemComponente" runat="server" AutoPostBack="True" 
                            CssClass="CampoCadastro" Width="50px"></asp:TextBox>
                        <asp:ImageButton ID="BtnFiltrarItem0" runat="server" 
                            ImageUrl="~/Imagens/search.png" style="width: 16px" ToolTip="Pesquisar" />
                        &nbsp;<asp:Label ID="LblDescricaoItemComponente" runat="server" Font-Bold="True" 
                            Height="17px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Quantidade:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtQuantidadeComponente" runat="server" CssClass="CampoCadastro" Width="160px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Observação:</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TxtObservacaoComponente" runat="server" 
                            CssClass="CampoCadastro" Width="200px"></asp:TextBox>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        &nbsp;</td>
                    <td style="text-align: left">
                        <asp:Button ID="BtnIncluirComponente" runat="server" CssClass="Botao" 
                            Text="Incluir" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" CssClass="CampoCadastro" DataKeyNames="cod_item" 
                            DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" 
                            Width="350px" 
                            EmptyDataText="Nenhum componente foi inserido neste equipamento até o momento. Informe um item acima e clique no botão Incluir para adicionar um.">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="seq_componente" HeaderText="Seq." 
                                    SortExpression="seq_componente">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Item" SortExpression="cod_item">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("cod_item") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("descricao_item") %>'></asp:Label>
                                        &nbsp;(<asp:Label ID="Label2" runat="server" Text='<%# Bind("cod_item") %>'></asp:Label>
                                        )
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="observacao" HeaderText="Observação" 
                                    SortExpression="observacao">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="quantidade" HeaderText="Qtade." 
                                    SortExpression="quantidade" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" 
                                            CommandArgument='<%# Eval("seq_componente") %>' CommandName="EXCLUIR" 
                                            ImageUrl="~/Imagens/BtnExcluir.png" 
                                            onclientclick="return confirm('Deseja realmente excluir o registro?');" 
                                            ToolTip="Excluir" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select ec.seq_componente, ec.cod_item, ec.observacao, it.descricao descricao_item, ec.quantidade
  from equipamento_componente ec inner join item it on ec.cod_item = it.cod_item
 where empresa      = :empresa
   and numero_serie = :numero_serie">
                            <SelectParameters>
                                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                                <asp:ControlParameter ControlID="LblNrSerie" Name=":numero_serie" 
                                    PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td style="text-align: left">
                        <asp:Button ID="BtnConcluir" runat="server" CssClass="Botao" Text="Concluir" />
                        &nbsp;
                        <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    </body>