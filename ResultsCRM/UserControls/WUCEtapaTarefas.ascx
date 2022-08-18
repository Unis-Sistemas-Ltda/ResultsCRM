<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCEtapaTarefas.ascx.vb" Inherits="ResultsCRM.WUCEtapaTarefas" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">Tarefas do Funil</div>
<table style="width:100%;" class="TextoCadastro">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Funil:</td>
        <td class="CelulaCampoCadastro" style="font-weight: bold">
            <asp:Label ID="LblDescricao" runat="server" Font-Bold="True"></asp:Label>
&nbsp;(<asp:Label ID="LblCodigo" runat="server" Font-Bold="True"></asp:Label>
            )</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="1" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" 
                ForeColor="#333333" GridLines="None" Width="100%">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Tarefa">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkSelecionado1" runat="server" 
                                Checked='<%# Bind("checked_1") %>' Text='<%# Eval("descricao_1") %>' 
                                ToolTip='<%# Eval("codigo_1") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sequência">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtSequencia1" runat="server" CssClass="CampoCadastro" style="text-align:center"
                                MaxLength="4" Text='<%# Bind("sequencia_1") %>' Width="45px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemStyle Width="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tarefa">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkSelecionado2" runat="server" 
                                Checked='<%# Bind("checked_2") %>' Text='<%# Eval("descricao_2") %>' 
                                ToolTip='<%# Eval("codigo_2") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sequência">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtSequencia2" runat="server" CssClass="CampoCadastro" 
                                MaxLength="4" style="text-align:center" Text='<%# Bind("sequencia_2") %>' 
                                Width="45px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                SelectCommand="exec sp_funil_etapa(:etapa)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="LblCodigo" Name=":etapa" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
