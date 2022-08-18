<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGTEFContrato.aspx.vb" Inherits="ResultsCRM.WGTEFContrato" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        </div>
    <div style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
        <table class="TextoCadastro_BGBranco" style="width:100%;">
            <tr>
                <td style="text-align: right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" datasourceid="SqlDataSource2" 
                        EmptyDataText="&lt;br&gt;Não há dados referentes à adesão a exibir." 
                        ForeColor="#333333" GridLines="None" Width="100%" CssClass="TextoCadastro">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="nome_responsavel" HeaderText="Nome Responsável" 
                                SortExpression="nome_responsavel">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cpf_responsavel" HeaderText="CPF" 
                                SortExpression="cpf_responsavel"><HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="rg_responsavel" HeaderText="RG" 
                                SortExpression="rg_responsavel">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_nascimento_responsavel" HeaderText="Nascimento" 
                                SortExpression="data_nascimento_responsavel">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="aceito" HeaderText="Aceito" 
                                SortExpression="aceito">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_aceite" HeaderText="Data Aceite" 
                                SortExpression="data_aceite">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ip_aceite" HeaderText="IP Aceite" 
                                SortExpression="ip_aceite">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="validado" HeaderText="Validado" 
                                SortExpression="validado">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_validacao" HeaderText="Data Validação" 
                                SortExpression="data_validacao">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ip_validacao" HeaderText="IP Validação" 
                                SortExpression="ip_validacao">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
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
                <td colspan="2">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand="select nome_responsavel, cpf_responsavel, rg_responsavel, data_nascimento_responsavel, aceito, data_aceite, ip_aceite, validado, data_validacao, ip_validacao
  from adesao_tef_emitente
 where cod_emitente = :cod_emitente
   and exists(select 1 from acesso_campanha_tef where empresa = 1 and cod_emitente = adesao_tef_emitente.cod_emitente and tipo_conteudo = 2)">
                        <SelectParameters>
                            <asp:SessionParameter Name=":codEmitente" 
                                SessionField="SCodLoja" ConvertEmptyStringToNull="False" DbType="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
