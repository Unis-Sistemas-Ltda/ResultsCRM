<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPOpcionais.aspx.vb" Inherits="ResultsCRM.WFPOpcionais" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pesquisa de Itens</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
     <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFPOpcionais.aspx";
        }
        function onSuccess() {
            window.parent.document.forms.item(0).submit();
            window.parent.document.getElementById('ButtonEditDone').click();
        }
        function onError() {
            getbacktostepone();
        }
        function cancel() {
            window.parent.document.getElementById('ButtonEditCancel').click();
        }
    </script>
    <style type="text/css">
        
    </style>
</head>
<body class="TextoCadastro" style="padding: 3px; margin:0;">
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:MultiView ID="MultiViewExpanse" runat="server">
        <asp:View ID="ViewInput" runat="server">
            <table class="TextoCadastro" 
                
                style="width: 690px; height: 380px; font-size: 7pt; border-collapse: collapse; background-color: #FFFFFF;">
                <tr>
                    <td class="TituloConsulta" colspan="3">
                        Acessórios &amp; Opcionais</td>
                </tr>
                <tr>
                    <td style="text-align: left; " colspan="2">
                        <asp:Label ID="Label1" runat="server" Text="Item:"></asp:Label>
                        <asp:Label ID="LblCodItem" runat="server" Font-Bold="True"></asp:Label>
                        -&nbsp;<asp:Label ID="LblDescricaoItem" runat="server" Font-Bold="True"></asp:Label>
                        <asp:Label ID="LblSeqEstrutura" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="LblReferencia" runat="server" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Height="17px" Text="Componente:&nbsp;"></asp:Label>
                        <asp:TextBox ID="TxtFiltroComponente" runat="server" CssClass="CampoCadastro" 
                            Width="130px"></asp:TextBox>
                        <asp:Button ID="BtnFiltrar" runat="server" Text="Filtrar" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: left; font-size: 7pt;" class="Erro">
                        <asp:Label ID="LblErro" runat="server"></asp:Label>
                        <asp:Label ID="LblCodItemGrupo" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="LblDescricaoItemGrupo" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 3px; border: 1px solid #CCCCCC; vertical-align: top; width: 255px; height: 100%;">
                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" CellPadding="3" CssClass="CampoCadastro" 
                            DataSourceID="SqlDataSource1" Font-Size="7pt" ForeColor="#333333" 
                            GridLines="None" Width="235px" 
                            
                            EmptyDataText="&lt;br&gt;&lt;br&gt;Não há grupo(s) de configuração cadastrado(s) para este item.">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Selecione o Grupo">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtnSelecionar" runat="server" 
                                            CommandArgument='<%# Eval("codigo") & ";" & Eval("seq_estrutura")%>' CommandName="SELECIONAR" 
                                            ForeColor="Black" 
                                            Text='<%# Eval("descricao_item") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Código" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="LblCodigo" runat="server" Text='<%# Eval("codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings FirstPageText="1&nbsp;" LastPageText="Última" 
                                Mode="NumericFirstLast" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                                VerticalAlign="Top" Height="26px" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select i.cod_item codigo, e.seq_estrutura,
       i.descricao || ' (' || i.cod_item || ')' descricao_item
  from estrutura e inner join item i on e.cod_componente = i.cod_item
 where e.cod_item = :cod_item
   and trim(e.referencia) = trim(:referencia)
   and e.tp_componente = 2
 order by e.seq_estrutura, i.descricao">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="LblCodItem" ConvertEmptyStringToNull="False" 
                                    Name=":cod_item" PropertyName="Text" DbType="String" />
                                <asp:ControlParameter ControlID="LblReferencia" 
                                    ConvertEmptyStringToNull="False" DbType="String" Name=":referencia" 
                                    PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td style="padding: 3px; border: 1px solid #CCCCCC; vertical-align: top" 
                        colspan="2">
                        <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" CellPadding="3" CssClass="CampoCadastro" 
                            DataSourceID="SqlDataSource2" Font-Size="7pt" ForeColor="#333333" 
                            GridLines="None" Width="440px" 
                            EmptyDataText="&lt;br&gt;&lt;br&gt;Nenhum grupo foi selecionado ou o grupo selecionado não possui itens.&lt;br&gt;&lt;br&gt;Selecione um grupo no menu ao lado.">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="LblHeader" runat="server" Text="Itens"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CbxSelecao" runat="server" AutoPostBack="True" 
                                            Checked='<%# Bind("marcado") %>' oncheckedchanged="CheckBox1_CheckedChanged" 
                                            Text='<%# Eval("descricao_item") %>'/>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Código" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="LblCodigo" runat="server" Text='<%# Eval("codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qtd." SortExpression="quantidade">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("quantidade") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtQuantidade" runat="server" CssClass="TextoCadastro"
                                            Text='<%# Bind("quantidade", "{0:F2}") %>' OnFocus="selecionaCampo(this)"
                                            Width="40px" AutoPostBack="True" ontextchanged="TxtQuantidade_TextChanged"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preço Unit." SortExpression="preco_unitario">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtPrecoUnitario" runat="server" CssClass="TextoCadastro" OnFocus="selecionaCampo(this)"
                                            style="text-align:right" Text='<%# Bind("preco_unitario", "{0:F2}") %>' 
                                            Visible='<%# Eval("enabled_valor") %>' Width="50px" AutoPostBack="True" 
                                            ontextchanged="TxtPrecoUnitario_TextChanged"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acrés/Desc" SortExpression="cf_acre_desc_3">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("cf_acre_desc_3") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preço Total" SortExpression="preco_total">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("preco_total") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" 
                                            Text='<%# Bind("preco_total", "{0:F2}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings FirstPageText="1&nbsp;" LastPageText="Última" 
                                Mode="NumericFirstLast" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                                VerticalAlign="Top" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                            
                            SelectCommand="select :cod_item codite,
       :referencia refe,
       :cod_componente codcomp,
       :empresa emp,
       :estabelecimento estab,
       convert(text, :cod_negociacao_cliente) neg,
       :seq_item sqitem,
       convert(text, :filtro_componente) filtro_componente,
       ec.valor_fixo,
       ec.tipo_valor,
       ec.tipo_soma,
       i.cod_item codigo,
       i.descricao || ' (' || i.cod_item || ')' descricao_item,
       if ec.valor_fixo &lt;&gt; 0 then '' else if ec.tipo_valor = 0 then '+' else '-' endif || ' ' || if ec.tipo_soma = 1 then 'R$' else ''endif endif cf_acrescimo_desconto,
       if ec.tipo_soma = 0 then '%' else '' endif cf_desconto,
       if ec.valor_fixo = 0 and ec.tipo_soma = 0 then cf_acrescimo_desconto || ' ' || convert(numeric(14,2), ec.valor) || cf_desconto else '0,00' endif cf_acre_desc_3,
       if exists(select 1
                   from negociacao_cliente_item_estrutura
                  where empresa = emp
                    and estabelecimento = estab
                    and cod_negociacao_cliente = neg
                    and seq_item = sqitem
                    and cod_item = codite
                    and seq_estrutura = e.seq_estrutura
                    and cod_componente_alternativo = ec.cod_componente_alternativo ) then 'True' else 'False' endif marcado,
       (select cod_emitente from negociacao_cliente where empresa = emp and estabelecimento = estab and cod_negociacao_cliente = neg) cod_cli,
       (select cnpj from negociacao_cliente where empresa = emp and estabelecimento = estab and cod_negociacao_cliente = neg) cnpj_cli,
       if ec.valor_fixo = 1 or ec.tipo_soma = 1 then f_busca_preco_item_cliente(emp, estab, cod_cli, cnpj_cli, ec.cod_componente_alternativo, null, null, null, null, null) else 0.0 endif preco_unitario,
       if ec.valor_fixo = 1 or ec.tipo_soma = 1 then 'True' else 'False' endif enabled_valor,
       isnull((  select quantidade
                   from negociacao_cliente_item_estrutura
                  where empresa = emp
                    and estabelecimento = estab
                    and cod_negociacao_cliente = neg
                    and seq_item = sqitem
                    and cod_item = codite
                    and seq_estrutura = e.seq_estrutura
                    and cod_componente_alternativo = ec.cod_componente_alternativo ), 1) quantidade,
        isnull((  select preco_total
                   from negociacao_cliente_item_estrutura
                  where empresa = emp
                    and estabelecimento = estab
                    and cod_negociacao_cliente = neg
                    and seq_item = sqitem
                    and cod_item = codite
                    and seq_estrutura = e.seq_estrutura
                    and cod_componente_alternativo = ec.cod_componente_alternativo ), 0) preco_total
  from estrutura e inner join estrutura_comp_alternativos ec on ec.cod_item      = e.cod_item
                                                            and ec.referencia    = e.referencia
                                                            and ec.seq_estrutura = e.seq_estrutura
                   inner join item i on ec.cod_componente_alternativo = i.cod_item
 where e.cod_item         = codite
   and trim(e.referencia) = trim(refe)
   and e.cod_componente   = codcomp
   and e.tp_componente    = 2
   and ( trim(isnull(filtro_componente,'')) = '' or i.cod_item || '|' || i.descricao like '%' || replace(trim(isnull(filtro_componente,'')),'+','%') || '%' )">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="LblCodItem" ConvertEmptyStringToNull="False" 
                                    Name=":cod_item" PropertyName="Text" DbType="String" />
                                <asp:ControlParameter ControlID="LblReferencia" Name=":referencia" 
                                    PropertyName="Text" ConvertEmptyStringToNull="False" DbType="String" />
                                <asp:ControlParameter ControlID="LblCodItemGrupo" DbType="String" 
                                    Name=":cod_componente" PropertyName="Text" 
                                    ConvertEmptyStringToNull="False" />
                                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" 
                                    ConvertEmptyStringToNull="False" DbType="String" />
                                <asp:SessionParameter Name=":estabelecimento" 
                                    SessionField="GlEstabelecimento" ConvertEmptyStringToNull="False" 
                                    DbType="String" />
                                <asp:SessionParameter Name=":cod_negociacao_cliente" 
                                    SessionField="SCodNegociacao" ConvertEmptyStringToNull="False" 
                                    DbType="String" />
                                <asp:SessionParameter Name=":seq_item" SessionField="SSeqItemNegociacao" 
                                    ConvertEmptyStringToNull="False" DbType="String" />
                                <asp:ControlParameter ControlID="TxtFiltroComponente" 
                                    ConvertEmptyStringToNull="False" Name=":filtro_componente" PropertyName="Text" 
                                    Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td width="150">
                        &nbsp;</td>
                    <td style="height: 16px">
                        <asp:Button ID="btnOkay" runat="server" CssClass="Botao" 
                            OnClick="btnOkay_Click" Text="Done" Visible="False" />
                        <input id="btnCancel" class="Botao" onclick="onSuccess();" 
                                style="border-style: none; font-family: verdana; text-decoration: underline; text-align: center;" 
                                type="button" value="Fechar" />
                    </td>
                </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>