<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAprovFinancOS.aspx.vb" Inherits="ResultsCRM.WGAprovFinancOS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Aprovação Financeira OS</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div class="TituloMovimento">Aprovação Financeira da Ordem de Serviço</div>
    <div>
    
        <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td style="text-align: right; ">
                    Nº OS:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtCodPedidoVenda" runat="server" 
                        CssClass="CampoCadastro" MaxLength="150" style="text-align: center" 
                        Width="167px" 
                        
                        ToolTip="Para informar mais de uma OS, informe os números separando por vírgula. Exemplo: 1282,1284, 1286" 
                        AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="text-align: right; ">
                    Cód.
                    Cliente:</td>
                <td style="vertical-align: top; ">
                    <asp:TextBox ID="TxtCodEmitente" runat="server" 
                        CssClass="CampoCadastro" Width="60px" AutoPostBack="True"></asp:TextBox>
&nbsp;</td>
                <td style="text-align: right; ">
                    <asp:Label ID="Label11" runat="server" Height="16px" Text="Analista:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlAnalista" runat="server" 
                        CssClass="CampoCadastro" Width="200px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    Nº Chamado:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtChamado" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o numero do chamado." Width="195px" 
                        AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    Nome Cliente:</td>
                <td style="vertical-align: top">
                    <asp:TextBox ID="TxtNomeEmitente" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o nome ou parte do nome do cliente." Width="195px" 
                        AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="text-align: right; vertical-align: bottom">
                    <asp:Label ID="Label12" runat="server" Height="16px" Text="Encerramento:"></asp:Label>
&nbsp;<asp:TextBox ID="TxtEncerramento_I" runat="server" AutoPostBack="True" 
                        CssClass="CampoCadastro" MaxLength="10" Width="83px"></asp:TextBox>
&nbsp;<asp:Label ID="Label13" runat="server" Height="16px" Text=" a"></asp:Label>
&nbsp;
                    <asp:TextBox ID="TxtEncerramento_F" runat="server" AutoPostBack="True" 
                        CssClass="CampoCadastro" MaxLength="10" Width="82px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    Status Aprovação:</td>
                <td style="text-align: left; width: 110px;">
                    <asp:DropDownList ID="DdlStatusAprovacao" runat="server" 
                        CssClass="CampoCadastro" Width="170px" AutoPostBack="True">
                        <asp:ListItem Value="0">(Todas)</asp:ListItem>
                        <asp:ListItem Value="N" Selected="True">Pendentes</asp:ListItem>
                        <asp:ListItem Value="S">Aprovadas</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    Contato:</td>
                <td>
                    <asp:DropDownList ID="DdlContato" runat="server" 
                        CssClass="CampoCadastro" Width="200px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; vertical-align: bottom">
                    <asp:Button ID="BtnRegistrarRecebimento" runat="server" CssClass="Botao" 
                        Height="25px" Text="Registrar Recebimento" Enabled="False" 
                        Visible="False" />
                    <asp:Label ID="Label5" runat="server" Height="16px" Text="Exibir:"></asp:Label>
&nbsp;<asp:DropDownList ID="DdlTop" runat="server" CssClass="CampoCadastro" 
                        Width="200px" AutoPostBack="True">
                        <asp:ListItem Value="50">50 registros</asp:ListItem>
                        <asp:ListItem Selected="True" Value="75">75 registros</asp:ListItem>
                        <asp:ListItem Value="100">100 registros</asp:ListItem>
                        <asp:ListItem Value="125">125 registros</asp:ListItem>
                        <asp:ListItem Value="150">150 registros</asp:ListItem>
                        <asp:ListItem Value="200">200 registros</asp:ListItem>
                        <asp:ListItem Value="300">300 registros</asp:ListItem>
                        <asp:ListItem Value="400">400 registros</asp:ListItem>
                        <asp:ListItem Value="500">500 registros</asp:ListItem>
                        <asp:ListItem Value="1000">1000 registros</asp:ListItem>
                        <asp:ListItem Value="999999">Todas</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="background-color: #FFFFE6;" class="Erro" colspan="5">
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                        GridLines="None" Width="100%" AllowSorting="True">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="seq" HeaderText="seq" ReadOnly="True" 
                                SortExpression="seq" Visible="False" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Nº OS" SortExpression="cod_pedido_venda">
                                <EditItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("cod_pedido_venda") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblCodPedidoVenda" runat="server" 
                                        Text='<%# Bind("cod_pedido_venda") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="chamado_cliente" HeaderText="Chamado" />
                            <asp:BoundField DataField="nome_abreviado" HeaderText="Tomador" />
                            <asp:BoundField DataField="data_encerramento" HeaderText="Data Encerramento" 
                                DataFormatString="{0:dd/MM/yy HH:mm}" />
                            <asp:BoundField DataField="nome_ponto_atendimento" 
                                HeaderText="Ponto Atendimento" />
                            <asp:BoundField DataField="tecnicos" HeaderText="Técnico" />
                            <asp:TemplateField HeaderText="Status Dig." SortExpression="status_digitacao">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" 
                                        Text='<%# Bind("status_digitacao") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblStatusDig" runat="server" 
                                        Text='<%# Bind("status_digitacao") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="BtnMarcar" runat="server" ForeColor="White" 
                                        onclick="BtnMarcar_Click">Marcar</asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CbxMarcado" runat="server" Visible="False" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status Rec." SortExpression="status_recebimento">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" 
                                        Text='<%# Bind("status_recebimento") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblStatusRec" runat="server" 
                                        Text='<%# Bind("status_recebimento") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="status_aprovacao" HeaderText="Status Aprovação" 
                                SortExpression="status_aprovacao">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Agente de Vendas" 
                                SortExpression="nome_agente_vendas">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" 
                                        Text='<%# Bind("nome_agente_vendas") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label04" runat="server" Text='<%# Bind("nome_agente_vendas") %>'></asp:Label>
                                    (<asp:Label ID="Label6" runat="server" Text='<%# Eval("cod_agente_vendas") %>'></asp:Label>
                                    )
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="valor_total" DataFormatString="{0:F2}" 
                                HeaderText="Total (R$)" SortExpression="valor_total">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
                                        CommandArgument='<%# Eval("cod_pedido_venda") %>' CommandName="ALTERAR" 
                                        ImageUrl="~/Imagens/BtnEditar.png" 
                                        ToolTip="Clique para alterar ou consultar o registro" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Left" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        SelectCommand="call sp_aprov_financ_os(:empresa, :ntop, :pedido, :status_aprovacao, :cod_emitente, :cod_contato, :nome_emitente, :cod_analista, :chamado, :enc_i, :enc_f)">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:ControlParameter ControlID="DdlTop" Name=":top" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtCodPedidoVenda" Name=":pedido" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                            <asp:ControlParameter ControlID="DdlStatusAprovacao" Name=":status_aprovacao" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtCodEmitente" Name=":cod_emitente" 
                                PropertyName="Text" DefaultValue="" ConvertEmptyStringToNull="False" 
                                Type="String" />
                            <asp:ControlParameter ControlID="DdlContato" 
                                Name=":cod_contato" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtNomeEmitente" 
                                ConvertEmptyStringToNull="False" Name=":nome_emitente" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="ddlAnalista" Name=":cod_analista" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtChamado" ConvertEmptyStringToNull="False" 
                                Name=":chamado" PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtEncerramento_I" 
                                ConvertEmptyStringToNull="False" Name=":enc_i" PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtEncerramento_F" 
                                ConvertEmptyStringToNull="False" Name=":enc_f" PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="5" 
                    style="border-top-style: solid; border-width: 1px; border-color: #808080">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource2" Font-Bold="True" 
                        ForeColor="#333333" GridLines="None" ShowHeader="False" Width="450px">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="descricao" HeaderText="descricao" 
                                SortExpression="descricao">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="qtd" HeaderText="qtd" SortExpression="qtd">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="complemento" HeaderText="complemento" 
                                SortExpression="complemento">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
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
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        SelectCommand="call sp_aprov_financ_os_resumo(:empresa, :ntop, :pedido, :status_aprovacao, :cod_emitente, :cod_contato, :nome_emitente, :cod_analista, :chamado, :enc_i, :enc_f)">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:ControlParameter ControlID="DdlTop" Name=":top" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtCodPedidoVenda" Name=":pedido" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                            <asp:ControlParameter ControlID="DdlStatusAprovacao" Name=":status_aprovacao" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtCodEmitente" Name=":cod_emitente" 
                                PropertyName="Text" DefaultValue="" ConvertEmptyStringToNull="False" 
                                Type="String" />
                            <asp:ControlParameter ControlID="DdlContato" 
                                Name=":cod_contato" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtNomeEmitente" 
                                ConvertEmptyStringToNull="False" Name=":nome_emitente" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="ddlAnalista" Name=":cod_analista" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="TxtChamado" ConvertEmptyStringToNull="False" 
                                Name=":chamado" PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtEncerramento_I" 
                                ConvertEmptyStringToNull="False" Name=":enc_i" PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtEncerramento_F" 
                                ConvertEmptyStringToNull="False" Name=":enc_f" PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>

</html>
