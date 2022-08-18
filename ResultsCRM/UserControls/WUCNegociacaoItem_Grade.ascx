<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoItem_Grade.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoItem_Grade" %>
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
            Item</td>
        <td align="left" class="SubTituloMovimento" style="padding: 5px">&nbsp;</td>
        <td align="left" class="SubTituloMovimento" style="border-left-style: solid; border-width: 1px; border-color: #DBDBDB">
            <asp:Label ID="LblCoresTamanhos" runat="server" Text="Cores e Tamanhos"></asp:Label>
        </td>
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
            <asp:Button ID="BtnIncluirReferencia" runat="server" Text="Incluir/Alterar" onclientclick="ShowEditModal('../Pesquisas/WFPNegociacaoProgramacao.aspx','EditModalPopupOpcionais','IframeEditOpc');"
                Enabled="False" />

        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="6">
            <asp:Label ID="LblErro" runat="server"></asp:Label>

        </td>
        <td class="Erro">
            &nbsp;</td>
        <td align="left" rowspan="14" valign="top" 
            style="border-left-style: solid; border-width: 1px; border-color: #DBDBDB">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" 
                GridLines="None" 
                EmptyDataText="&lt;br&gt;&lt;br&gt;Clique no botão acima para informar as respectivas quantidads por cor e tamanho." 
                Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" 
                    BorderColor="#E4E4E4" BorderStyle="Solid" BorderWidth="1px" />
                <Columns>
                    <asp:BoundField DataField="cf_cor" HeaderText="Cor" ReadOnly="True" 
                        SortExpression="cf_cor">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_1" 
                        SortExpression="quantidade_tamanho_1">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam1" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_1") %>'></asp:Label>
                            <asp:Label ID="LblTam1" runat="server" Text='<%# Eval("cod_tamanho_1") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam1" runat="server" 
                                Text='<%# Eval("visible_tamanho_1") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam1" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_2" 
                        SortExpression="quantidade_tamanho_2">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam2" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_2") %>'></asp:Label>
                            <asp:Label ID="LblTam2" runat="server" Text='<%# Eval("cod_tamanho_2") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam2" runat="server" 
                                Text='<%# Eval("visible_tamanho_2") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam2" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_3" 
                        SortExpression="quantidade_tamanho_3">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam3" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_3") %>'></asp:Label>
                            <asp:Label ID="LblTam3" runat="server" Text='<%# Eval("cod_tamanho_3") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam3" runat="server" 
                                Text='<%# Eval("visible_tamanho_3") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam3" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_4" 
                        SortExpression="quantidade_tamanho_4">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam4" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_4") %>'></asp:Label>
                            <asp:Label ID="LblTam4" runat="server" Text='<%# Eval("cod_tamanho_4") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam4" runat="server" 
                                Text='<%# Eval("visible_tamanho_4") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam4" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_5" 
                        SortExpression="quantidade_tamanho_5">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam5" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_5") %>'></asp:Label>
                            <asp:Label ID="LblTam5" runat="server" Text='<%# Eval("cod_tamanho_5") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam5" runat="server" 
                                Text='<%# Eval("visible_tamanho_5") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam5" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_6" 
                        SortExpression="quantidade_tamanho_6">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam6" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_6") %>'></asp:Label>
                            <asp:Label ID="LblTam6" runat="server" Text='<%# Eval("cod_tamanho_6") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam6" runat="server" 
                                Text='<%# Eval("visible_tamanho_6") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam6" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_7" 
                        SortExpression="quantidade_tamanho_7">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam7" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_7") %>'></asp:Label>
                            <asp:Label ID="LblTam7" runat="server" Text='<%# Eval("cod_tamanho_7") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam7" runat="server" 
                                Text='<%# Eval("visible_tamanho_7") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam7" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_8" 
                        SortExpression="quantidade_tamanho_8">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam8" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_8") %>'></asp:Label>
                            <asp:Label ID="LblTam8" runat="server" Text='<%# Eval("cod_tamanho_8") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam8" runat="server" 
                                Text='<%# Eval("visible_tamanho_8") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam8" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_9" 
                        SortExpression="quantidade_tamanho_9">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam9" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_9") %>'></asp:Label>
                            <asp:Label ID="LblTam9" runat="server" Text='<%# Eval("cod_tamanho_9") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam9" runat="server" 
                                Text='<%# Eval("visible_tamanho_9") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam9" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_10" 
                        SortExpression="quantidade_tamanho_10">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam10" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_10") %>'></asp:Label>
                            <asp:Label ID="LblTam10" runat="server" Text='<%# Eval("cod_tamanho_10") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam10" runat="server" 
                                Text='<%# Eval("visible_tamanho_10") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam10" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_11" 
                        SortExpression="quantidade_tamanho_11">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam11" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_11") %>'></asp:Label>
                            <asp:Label ID="LblTam11" runat="server" Text='<%# Eval("cod_tamanho_11") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam11" runat="server" 
                                Text='<%# Eval("visible_tamanho_11") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam11" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_12" 
                        SortExpression="quantidade_tamanho_12">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam12" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_12") %>'></asp:Label>
                            <asp:Label ID="LblTam12" runat="server" Text='<%# Eval("cod_tamanho_12") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam12" runat="server" 
                                Text='<%# Eval("visible_tamanho_12") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam12" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_13" 
                        SortExpression="quantidade_tamanho_13">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam13" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_13") %>'></asp:Label>
                            <asp:Label ID="LblTam13" runat="server" Text='<%# Eval("cod_tamanho_13") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam13" runat="server" 
                                Text='<%# Eval("visible_tamanho_13") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam13" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_14" 
                        SortExpression="quantidade_tamanho_14">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam14" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_14") %>'></asp:Label>
                            <asp:Label ID="LblTam14" runat="server" Text='<%# Eval("cod_tamanho_14") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam14" runat="server" 
                                Text='<%# Eval("visible_tamanho_14") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam14" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_15" 
                        SortExpression="quantidade_tamanho_15">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam15" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_15") %>'></asp:Label>
                            <asp:Label ID="LblTam15" runat="server" Text='<%# Eval("cod_tamanho_15") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam15" runat="server" 
                                Text='<%# Eval("visible_tamanho_15") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam15" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_16" 
                        SortExpression="quantidade_tamanho_16">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam16" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_16") %>'></asp:Label>
                            <asp:Label ID="LblTam16" runat="server" Text='<%# Eval("cod_tamanho_16") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam16" runat="server" 
                                Text='<%# Eval("visible_tamanho_16") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam16" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_17" 
                        SortExpression="quantidade_tamanho_17">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam17" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_17") %>'></asp:Label>
                            <asp:Label ID="LblTam17" runat="server" Text='<%# Eval("cod_tamanho_17") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam17" runat="server" 
                                Text='<%# Eval("visible_tamanho_17") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam17" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_18" 
                        SortExpression="quantidade_tamanho_18">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam18" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_18") %>'></asp:Label>
                            <asp:Label ID="LblTam18" runat="server" Text='<%# Eval("cod_tamanho_18") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam18" runat="server" 
                                Text='<%# Eval("visible_tamanho_18") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam18" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_19" 
                        SortExpression="quantidade_tamanho_19">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam19" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_19") %>'></asp:Label>
                            <asp:Label ID="LblTam19" runat="server" Text='<%# Eval("cod_tamanho_19") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam19" runat="server" 
                                Text='<%# Eval("visible_tamanho_19") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam19" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_20" 
                        SortExpression="quantidade_tamanho_20">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam20" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_20") %>'></asp:Label>
                            <asp:Label ID="LblTam20" runat="server" Text='<%# Eval("cod_tamanho_20") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam20" runat="server" 
                                Text='<%# Eval("visible_tamanho_20") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam20" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_21" 
                        SortExpression="quantidade_tamanho_21">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam21" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_21") %>'></asp:Label>
                            <asp:Label ID="LblTam21" runat="server" Text='<%# Eval("cod_tamanho_21") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam21" runat="server" 
                                Text='<%# Eval("visible_tamanho_21") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam21" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_22" 
                        SortExpression="quantidade_tamanho_22">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam22" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_22") %>'></asp:Label>
                            <asp:Label ID="LblTam22" runat="server" Text='<%# Eval("cod_tamanho_22") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam22" runat="server" 
                                Text='<%# Eval("visible_tamanho_22") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam22" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_23" 
                        SortExpression="quantidade_tamanho_23">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam23" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_23") %>'></asp:Label>
                            <asp:Label ID="LblTam23" runat="server" Text='<%# Eval("cod_tamanho_23") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam23" runat="server" 
                                Text='<%# Eval("visible_tamanho_23") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam23" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_24" 
                        SortExpression="quantidade_tamanho_24">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam24" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_24") %>'></asp:Label>
                            <asp:Label ID="LblTam24" runat="server" Text='<%# Eval("cod_tamanho_24") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam24" runat="server" 
                                Text='<%# Eval("visible_tamanho_24") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam24" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_25" 
                        SortExpression="quantidade_tamanho_25">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam25" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_25") %>'></asp:Label>
                            <asp:Label ID="LblTam25" runat="server" Text='<%# Eval("cod_tamanho_25") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam25" runat="server" 
                                Text='<%# Eval("visible_tamanho_25") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam25" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_26" 
                        SortExpression="quantidade_tamanho_26">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam26" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_26") %>'></asp:Label>
                            <asp:Label ID="LblTam26" runat="server" Text='<%# Eval("cod_tamanho_26") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam26" runat="server" 
                                Text='<%# Eval("visible_tamanho_26") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam26" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_27" 
                        SortExpression="quantidade_tamanho_27">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam27" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_27") %>'></asp:Label>
                            <asp:Label ID="LblTam27" runat="server" Text='<%# Eval("cod_tamanho_27") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam27" runat="server" 
                                Text='<%# Eval("visible_tamanho_27") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam27" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_28" 
                        SortExpression="quantidade_tamanho_28">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam28" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_28") %>'></asp:Label>
                            <asp:Label ID="LblTam28" runat="server" Text='<%# Eval("cod_tamanho_28") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam28" runat="server" 
                                Text='<%# Eval("visible_tamanho_28") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam28" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_29" 
                        SortExpression="quantidade_tamanho_29">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam29" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_29") %>'></asp:Label>
                            <asp:Label ID="LblTam29" runat="server" Text='<%# Eval("cod_tamanho_29") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam29" runat="server" 
                                Text='<%# Eval("visible_tamanho_29") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam29" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_30" 
                        SortExpression="quantidade_tamanho_30">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam30" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_30") %>'></asp:Label>
                            <asp:Label ID="LblTam30" runat="server" Text='<%# Eval("cod_tamanho_30") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam30" runat="server" 
                                Text='<%# Eval("visible_tamanho_30") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam30" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_31" 
                        SortExpression="quantidade_tamanho_31">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam31" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_31") %>'></asp:Label>
                            <asp:Label ID="LblTam31" runat="server" Text='<%# Eval("cod_tamanho_31") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam31" runat="server" 
                                Text='<%# Eval("visible_tamanho_31") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam31" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_32" 
                        SortExpression="quantidade_tamanho_32">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam32" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_32") %>'></asp:Label>
                            <asp:Label ID="LblTam32" runat="server" Text='<%# Eval("cod_tamanho_32") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam32" runat="server" 
                                Text='<%# Eval("visible_tamanho_32") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam32" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_33" 
                        SortExpression="quantidade_tamanho_33">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam33" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_33") %>'></asp:Label>
                            <asp:Label ID="LblTam33" runat="server" Text='<%# Eval("cod_tamanho_33") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam33" runat="server" 
                                Text='<%# Eval("visible_tamanho_33") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam33" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_34" 
                        SortExpression="quantidade_tamanho_34">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam34" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_34") %>'></asp:Label>
                            <asp:Label ID="LblTam34" runat="server" Text='<%# Eval("cod_tamanho_34") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam34" runat="server" 
                                Text='<%# Eval("visible_tamanho_34") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam34" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="quantidade_tamanho_35" 
                        SortExpression="quantidade_tamanho_35">
                        <ItemTemplate>
                            <asp:Label ID="LblQtdTam35" runat="server" 
                                Text='<%# Bind("quantidade_tamanho_35") %>'></asp:Label>
                            <asp:Label ID="LblTam35" runat="server" Text='<%# Eval("cod_tamanho_35") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="LblVisibleTam35" runat="server" 
                                Text='<%# Eval("visible_tamanho_35") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LblTituloTam35" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="#E4E4E4" 
                    BorderStyle="Solid" BorderWidth="1px" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                SelectCommand="call sp_negociacao_item_grade(:empresa,:estabelecimento, :cod_negociacao, :seq_item, :cod_item)">
                <SelectParameters>
                    <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                    <asp:SessionParameter Name=":estabelecimento" SessionField="GlEstabelecimento" />
                    <asp:SessionParameter Name=":cod_negociacao" SessionField="SCodNegociacao"/>
                    <asp:SessionParameter Name=":seq_item" SessionField="SSeqItemNegociacao" />
                    <asp:ControlParameter ControlID="TxtCodItem" Name=":cod_item" 
                        PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>

            <br />

            <asp:ImageButton ID="BtnAtualizarGrid" runat="server" Height="22px" 
                ImageUrl="~/Imagens/BtnIconeAtualizar.gif" ClientIDMode="Static"
                ToolTip="Atualizar lista de cores/tamanhos incluídos na negociação." />

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
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar Item" 
                
                onclientclick="ShowEditModal('../Pesquisas/WFPItem.aspx?textbox=TxtCodItem','EditModalPopupClientes','IframeEdit');" />

            <asp:Label ID="LblDescricaoItem" runat="server" Font-Bold="False" 
                Height="17px"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="LblReferencia" runat="server" Text="Referência:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:DropDownList ID="DdlReferencia" runat="server" CssClass="CampoCadastro" 
                Width="366px">
            </asp:DropDownList>
                        <asp:ImageButton ID="BtnFiltrarReferencia" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar Referência" 
                
                onclientclick="ShowEditModal('../Pesquisas/WFPReferencia.aspx','EditModalPopupReferencia','IframeEdit');" 
                Width="16px" />

    <cc1:ModalPopupExtender ID="BtnFiltrarReferencia_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarReferencia" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupReferencia">
    </cc1:ModalPopupExtender>
        </td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            <asp:Label ID="Label1" runat="server" Text="Narrativa:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" colspan="5">
            <asp:TextBox ID="TxtNarrativa" runat="server" CssClass="CampoCadastro" 
                Height="40px" TextMode="MultiLine" Width="381px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro">
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
        <td style="text-align: right; vertical-align: bottom">
            <asp:Label ID="Label15" runat="server" Height="16px" Text="Quantidade:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="vertical-align: bottom" width="77px">
            <asp:TextBox ID="TxtQuantidade" runat="server" AutoPostBack="True" 
                style="text-align:right" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" 
            style="vertical-align: bottom; text-align: right" width="55">
            <asp:Label ID="Label2" runat="server" Height="16px" 
                Text="R$ Unit.:" ToolTip="Preço unitário em Reais."></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="vertical-align: bottom" width="77">
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
            R$ UD:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblValorUD" runat="server" Font-Bold="False" Text="0,0000" style="text-align:right"
                Width="60px"></asp:Label>
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
            ICMS: </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="Label16" runat="server" Text="R$"></asp:Label>
&nbsp;<asp:Label ID="LblICMS" runat="server" Font-Bold="False">0,0000</asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LblAliquotaICMS" runat="server" BackColor="#F0F0F0" 
                style="background-color: #FFFFFF">0</asp:Label>
            <asp:Label ID="Label8" runat="server" BackColor="#F0F0F0" Text="%" 
                style="background-color: #FFFFFF"></asp:Label>
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
        <td style="text-align: right">
            <asp:Label ID="Label3" runat="server" Text="ICMS ST:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="Label7" runat="server" Text="R$"></asp:Label>
&nbsp;<asp:Label ID="LblICMSST" runat="server" Font-Bold="False">0,0000</asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            &nbsp;</td>
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
        <td style="text-align: right">
            <asp:Label ID="Label5" runat="server" Text="IPI:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="Label17" runat="server" Text="R$"></asp:Label>
&nbsp;<asp:Label ID="LblIPI" runat="server" Font-Bold="False">0,0000</asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="LblAliquotaIPI" runat="server" BackColor="#F0F0F0" 
                style="background-color: #FFFFFF">0</asp:Label>
            <asp:Label ID="Label9" runat="server" BackColor="#F0F0F0" Text="%" 
                style="background-color: #FFFFFF"></asp:Label>
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
        <td style="text-align: right">
            Vlr.&nbsp;Merc.:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="Label12" runat="server" Text="R$" BorderStyle="None" 
                BorderWidth="1px"></asp:Label>
            &nbsp;<asp:Label ID="LblValorMercadoria" runat="server" Font-Bold="False" 
                BorderStyle="None" BorderWidth="1px">0,00</asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Label ID="Label13" runat="server" Text="Vlr.Total:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: left">
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
<%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" onclick="document.getElementById('BtnAtualizarGrid').click()" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
<%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="350" scrolling="no">
        </iframe>
    </div>

<%--este é o html para pesquisa de itens--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirReferencia" PopupControlID="DivEditWindowOpc" 
        OnCancelScript="EditCancelScript('IframeEditOpc');" OnOkScript="EditOkayScript('IframeEditOpc');"
        BehaviorID="EditModalPopupOpcionais">
    </cc1:ModalPopupExtender>

<%--frame onde é mostrado o popup--%>
    <div id="DivEditWindowOpc" style="display: none;" class="popupConfirmation714x390">
        <iframe id="IframeEditOpc" frameborder="0" width="714" height="390" scrolling="auto">
        </iframe>
    </div>