<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCManual.ascx.vb" Inherits="ResultsCRM.WUCManual" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">Detalhe do Manual</div>
<table class="TextoCadastro" style="width:100%;">
    <tr>
        <td class="Erro" colspan="4" style="text-align: center">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select m.cod_modulo, m.ds_modulo, s.cod_sistema, s.descricao ds_sistema, r.cod_rotina, r.nome ds_rotina,
       'cod_modulo=[' || mr.cod_modulo ||']cod_sistema=[' || mr.cod_sistema || ']cod_rotina=[' || mr.cod_rotina || ']' chave
  from manual_rotina mr inner join sysmodulo m on m.cod_modulo = mr.cod_modulo
                        inner join sistema s on s.cod_sistema = mr.cod_sistema
                        inner join rotina r on r.cod_rotina = mr.cod_rotina
 where mr.cod_manual = :cod_manual">
                <SelectParameters>
                    <asp:ControlParameter ControlID="LblCodigo" Name=":cod_manual" 
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
        <td class="CelulaCampoCadastro" style="text-align: right" width="70">
            Módulo:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlModulo" runat="server" CssClass="CampoCadastro" 
                Width="250px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td rowspan="2" valign="top">
            Arquivo:</td>
        <td class="CelulaCampoCadastro" rowspan="2" valign="top">
            <asp:FileUpload ID="FU_Arquivo" runat="server" CssClass="CampoCadastro" 
                Width="400px" />
            <br />
            <br />
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" 
                Text="Gravar alterações" />
        &nbsp;<asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Rotina:</td>
        <td class="CelulaCampoCadastro" width="530">
            <asp:DropDownList ID="DdlRotina" runat="server" CssClass="CampoCadastro" 
                Width="250px" AutoPostBack="True">
            </asp:DropDownList>
&nbsp;<asp:Button ID="BtnVincular" runat="server" Text="Vincular" />
        </td>
    </tr>
    <tr>
        <td class="CelulaCampoCadastro" colspan="2" valign="top">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                GridLines="None" style="margin-right: 0px" Width="600px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ds_sistema" HeaderText="Sistema" 
                        SortExpression="ds_sistema">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ds_modulo" HeaderText="Módulo" 
                        SortExpression="ds_modulo">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ds_rotina" HeaderText="Rotina" 
                        SortExpression="ds_rotina">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                CommandArgument='<%# Eval("chave") %>' CommandName="EXCLUIR" 
                                ImageUrl="~/Imagens/BtnExcluir.png" 
                                OnClientClick="return confirm('Deseja realmente excluir o registro?');" 
                                ToolTip="Excluir" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
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
