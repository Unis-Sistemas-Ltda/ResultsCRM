<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCRotina.ascx.vb" Inherits="ResultsCRM.WUCRotina" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">Detalhe da Rotina</div>
<table class="TextoCadastro" style="width:100%;">
    <tr>
        <td class="Erro" colspan="4" style="text-align: center">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select m.cod_modulo, m.ds_modulo, s.descricao
  from sysmodulo m inner join rotina_modulo r on m.cod_modulo = r.cod_modulo
                   inner join sistema s on s.cod_sistema = m.cod_sistema
 where r.cod_rotina = :cod_rotina">
                <SelectParameters>
                    <asp:ControlParameter ControlID="LblCodigo" Name=":cod_rotina" 
                        PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td>
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodigo" runat="server" Font-Bold="True"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right" width="70">
            Sistema:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlSistema" runat="server" AutoPostBack="True" 
                CssClass="CampoCadastro" Width="250px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Nome:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtNome" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="400px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Módulo:</td>
        <td class="CelulaCampoCadastro" width="330">
            <asp:DropDownList ID="DdlModulo" runat="server" CssClass="CampoCadastro" 
                Width="250px">
            </asp:DropDownList>
&nbsp;<asp:Button ID="BtnVincular" runat="server" Text="Vincular" />
        </td>
    </tr>
    <tr>
        <td valign="top">
            Descrição:</td>
        <td class="CelulaCampoCadastro" valign="top">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="400px" Height="125px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" 
                Text="Gravar alterações" />
        &nbsp;<asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
        <td class="CelulaCampoCadastro" colspan="2" valign="top">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                GridLines="None" style="margin-right: 0px" Width="400px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Sistema" SortExpression="descricao">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Módulo" SortExpression="ds_modulo">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ds_modulo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ds_modulo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="return confirm('Deseja realmente excluir o registro?');"
                                CommandArgument='<%# Eval("cod_modulo") %>' CommandName="EXCLUIR" 
                                ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                    HorizontalAlign="Left" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </td>
    </tr>
    </table>
