<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelOSPendenteImpressao.aspx.vb" Inherits="ResultsCRM.WFRelOSPendenteImpressao" %>
<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ordens de Serviço</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div class="TituloConsulta">Ordens de Serviço Pendentes de Impressão</div>
    <div>
    
        <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td style="text-align: right; ">
                    Nº OS:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtCodPedidoVenda" runat="server" 
                        CssClass="CampoCadastro" MaxLength="15" style="text-align: center" 
                        Width="80px" 
                        
                        ToolTip="Para informar mais de uma OS, informe os números separando por vírgula. Exemplo: 1282,1284, 1286" 
                        AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="text-align: right; ">
                    &nbsp;</td>
                <td style="vertical-align: top; ">
                    &nbsp;</td>
                <td style="text-align: right; ">
                    &nbsp;</td>
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
                            <asp:TemplateField HeaderText="Cliente" SortExpression="nome_emitente">
                                <EditItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("nome_emitente") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("nome_emitente") %>'></asp:Label>
                                    &nbsp;(<asp:Label ID="Label4" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:Label>
                                    )
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ponto_atendimento" HeaderText="Ponto Atend." 
                                SortExpression="ponto_atendimento">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
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
                            <asp:BoundField DataField="agentes_tecnicos" HeaderText="Agente(s) Técnico(s)" 
                                SortExpression="agentes_tecnicos">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="valor_total" DataFormatString="{0:F2}" 
                                HeaderText="Total (R$)" SortExpression="valor_total">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
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
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        SelectCommand="  SELECT c.empresa empresa,   
         c.cod_pedido_venda cod_pedido_venda,   
         c.cod_emitente cod_emitente,
         e.nome nome_emitente,
         c.cnpj_faturamento cnpj,
         isnull( (select epa.nome || '  -  ' || isnull(ppa.numero_ponto_atendimento,'') || ' - ' || isnull(ppa.descricao,'') || ' - ' || ci.nome_cidade || '/' || puf.sigla
                    from ponto_atendimento ppa left outer join cidade ci on ppa.cod_cidade = ci.cod_cidade and ppa.cod_estado = ci.cod_estado and ppa.cod_pais = ci.cod_pais
                                               left outer join estado puf on puf.cod_pais = ppa.cod_pais and puf.cod_estado = ppa.cod_estado
                                               inner join emitente epa on epa.cod_emitente = ppa.cod_emitente
                   where ppa.cod_emitente             = ch.cod_emitente_atendimento 
                     and ppa.numero_ponto_atendimento = ch.numero_ponto_atendimento),'') ponto_atendimento,
         c.cod_contato cod_contato,   
         ct.nome nome_contato,
         c.cod_agente_venda cod_agente_vendas,
         usu.nome_usuario nome_agente_vendas, 
         if c.status_digitacao = 2 then 'Encerrada' else 'Aberta' endif status_digitacao,
         if c.status_recebimento = 2 then 'Recebida' else 'Pendente' endif status_recebimento,
         c.total_pedido valor_total,
         c.data_encerramento data_encerramento,
         isnull((select trim(list(' ' || a.nome || ' (' || a.cod_agente_tecnico || ')'))
                   from pedido_venda_agente_tecnico pt inner join agente_tecnico a on a.cod_agente_tecnico = pt.cod_agente_tecnico
                  where pt.cod_pedido_venda = c.cod_pedido_venda
                    and pt.estabelecimento  = c.estabelecimento
                    and pt.empresa          = c.empresa),'') agentes_tecnicos
    FROM pedido_venda c left outer join emitente e on c.cod_emitente   = e.cod_emitente
                        left outer join contatos ct on ct.cod_emitente = c.cod_emitente
                                                   and ct.cod_contato  = c.cod_contato
                        left outer join sysusuario usu on usu.cod_usuario  = c.cod_agente_venda
                        left outer join chamado ch on ch.empresa     = c.empresa
                                                  and ch.cod_chamado = c.cod_chamado
   WHERE c.empresa                 = :empresa
     AND ( ( trim(isnull(:pedido1,'')) &lt;&gt; '' and ' ' || replace(:pedido2,',',' , ') || ' ' like '% ' || c.cod_pedido_venda || ' %' ) or ( trim(isnull(:pedido3,'')) = '' ) )
     AND isnull(c.id_os,'N') = 'S'
     AND isnull(c.imprimir_matricial,'N') = 'S'
     AND isnull(c.impresso_os,'N') = 'N'
   ORDER BY c.cod_pedido_venda;
">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:ControlParameter ControlID="TxtCodPedidoVenda" Name=":pedido1" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                                <asp:ControlParameter ControlID="TxtCodPedidoVenda" Name=":pedido2" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                                <asp:ControlParameter ControlID="TxtCodPedidoVenda" Name=":pedido3" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    OS&#39;S LISTADAS:
                    <asp:Label ID="LblNrOS" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
