<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGTEFHistoricoAcesso.aspx.vb" Inherits="ResultsCRM.WGTEFHistoricoAcesso" %>

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
                        EmptyDataText="&lt;br&gt;Nenhum acesso efetuado." 
                        ForeColor="#333333" GridLines="None" Width="100%" CssClass="TextoCadastro">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="seq_acesso" HeaderText="Seq." 
                                SortExpression="seq_acesso">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nome_rede" HeaderText="Grupo" 
                                SortExpression="nome_rede">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_acesso" HeaderText="Data" 
                                SortExpression="data_acesso" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="conteudo" HeaderText="Conteúdo Acessado" 
                                SortExpression="conteudo" ReadOnly="True">
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
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select a.seq_acesso, t.nome_rede, a.data_acesso, case a.tipo_conteudo when 1 then 'Simulador' when 2 then 'Adesão' when 3 then 'Portal de Campanhas' end conteudo
  from acesso_campanha_tef a left outer join adesao_tef t on a.cod_adesao = t.cod_adesao
 where cod_emitente = :cod_emitente
 order by a.seq_acesso">
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
