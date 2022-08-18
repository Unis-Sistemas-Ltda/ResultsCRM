<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCFAQ.ascx.vb" Inherits="ResultsCRM.WUCFAQ" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="HTMLEditor" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table class="Cadastro" style="width:100%;">
    <tr>
        <td class="TituloCadastro" colspan="3" style="text-align: center">
            FAQ</td>
    </tr>
    <tr>
        <td class="Titulo2" colspan="3" style="text-align: center">
            <asp:Label ID="LblAcao" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="3" style="text-align: center">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            C&oacute;digo:</td>
        <td>
            <asp:Label ID="LblCodFAQ" runat="server" style="font-weight: 700"></asp:Label>
        </td>
        <td rowspan="6" style="vertical-align: top; width: 30%">
            <b>Sistema:</b><br />
            <asp:DropDownList ID="DdlSistema" runat="server" CssClass="TextoCadastro" 
                Width="200px" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Button ID="BtnAddSistema" runat="server" Text="Adicionar" Width="72px" />
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                style="margin-bottom: 0px" Width="275px" AutoGenerateColumns="False" 
                EmptyDataText="&lt;br&gt;Nenhum sistema vinculado até o momento." 
                ShowHeader="False">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Sistema" SortExpression="descricao">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                            (<asp:Label ID="Label2" runat="server" Text='<%# Eval("cod_sistema") %>'></asp:Label>
                            )
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                CommandArgument='<%# Eval("cod_sistema") %>' CommandName="EXCLUIR" 
                                ImageUrl="~/Imagens/BtnExcluir.png" 
                                onclientclick="return confirm('Confirma exclusão?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
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
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select s.cod_sistema, s.descricao
  from faq_sistema fs inner join sistema s on fs.cod_sistema = s.cod_sistema
 where fs.cod_faq = :cod_faq
order by s.descricao">
                <SelectParameters>
                    <asp:ControlParameter ControlID="LblCodFAQ" Name=":cod_faq" 
                        PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <b>Módulo:</b><br />
            <asp:DropDownList ID="DdlModulo" runat="server" CssClass="TextoCadastro" 
                Width="200px">
            </asp:DropDownList>
            <asp:Button ID="BtnAddModulo" runat="server" Text="Adicionar" Width="72px" />
            <asp:GridView ID="GridView2" runat="server" CellPadding="4" 
                DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" 
                Width="275px" AutoGenerateColumns="False" DataKeyNames="cod_modulo" 
                EmptyDataText="&lt;br&gt;Nenhum módulo vinculado até o momento." 
                ShowHeader="False">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Módulo" SortExpression="descricao">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                            (<asp:Label ID="Label3" runat="server" Text='<%# Eval("cod_modulo") %>'></asp:Label>
                            )
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" 
                                CommandArgument='<%# Eval("cod_modulo") %>' CommandName="EXCLUIR" 
                                ImageUrl="~/Imagens/BtnExcluir.png"
                                onclientclick="return confirm('Confirma exclusão?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
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
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select s.cod_modulo, s.nome_modulo descricao
  from faq_modulo fs inner join sysmodulo s on fs.cod_modulo = s.cod_modulo
 where fs.cod_faq = :cod_faq
order by descricao">
                <SelectParameters>
                    <asp:ControlParameter ControlID="LblCodFAQ" Name=":cod_faq" 
                        PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <b>Rotina:</b><br />
            <asp:DropDownList ID="DdlRotina" runat="server" CssClass="TextoCadastro" 
                Width="200px">
            </asp:DropDownList>
            <asp:Button ID="BtnAddRotina" runat="server" Text="Adicionar" Width="72px" />
            <asp:GridView ID="GridView3" runat="server" CellPadding="4" 
                DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None" 
                Width="275px" AutoGenerateColumns="False" 
                EmptyDataText="&lt;br&gt;Nenhuma rotina vinculada até o momento." 
                ShowHeader="False">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Rotina" SortExpression="descricao">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                            (<asp:Label ID="Label4" runat="server" Text='<%# Eval("cod_rotina") %>'></asp:Label>
                            )
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton3" runat="server" 
                                CommandArgument='<%# Eval("cod_rotina") %>' CommandName="EXCLUIR" 
                                ImageUrl="~/Imagens/BtnExcluir.png"
                                onclientclick="return confirm('Confirma exclusão?');" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
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
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select s.cod_rotina, s.nome descricao
  from faq_rotina fs inner join rotina s on fs.cod_rotina = s.cod_rotina
 where fs.cod_faq = :cod_faq
order by descricao">
                <SelectParameters>
                    <asp:ControlParameter ControlID="LblCodFAQ" Name=":cod_faq" 
                        PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            Pergunta:</td>
        <td style="vertical-align: top">
            <HTMLEditor:Editor runat="server" ID="TxtPergunta" Width="550px" 
                Height="220px"> 
             </HTMLEditor:Editor>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            Resposta:</td>
        <td style="vertical-align: top">
            <HTMLEditor:Editor runat="server" ID="TxtResposta" Width="550px" Height="220px"> 
             </HTMLEditor:Editor>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Anexo:</td>
        <td>
            <asp:FileUpload ID="FUAnexo" runat="server" Width="550px" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Ativo:</td>
        <td>
            <asp:CheckBox ID="CbxAtivo" runat="server" Checked="True" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" Text="Salvar" Width="100px" 
                CssClass="Botao" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" Width="100px" 
                CssClass="Botao" />
        </td>
        <td style="text-align: center">
            &nbsp;</td>
    </tr>
</table>