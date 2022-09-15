<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCFunilEtapaPainel.ascx.vb" Inherits="ResultsCRM.WUCFunilEtapaPainel" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<body style="padding:0; margin:0; border:0">
    <div style="padding-right: 4px; padding-left: 4px">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
            GridLines="None" Width="100%" ShowHeaderWhenEmpty="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="LblTitulo" runat="server"></asp:Label>
                    <br />
                    <table style="width: 100%; border-collapse: collapse">
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="Label3" runat="server" Font-Size="8pt" Text="R$&nbsp;"></asp:Label>
                                <asp:Label ID="LblValorTotal" runat="server" Font-Size="8pt" 
                                    style="text-align:left" Text="0,00"></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="LblQtdNegociacoes" runat="server" Font-Size="8pt" 
                                    style="text-align: right">0 negócios</asp:Label>
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                        CommandArgument='<%# Eval("chave") %>' CommandName="ALTERAR" 
                        CssClass="CampoCadastro" Font-Underline="False" 
                        Text='<%# Eval("nome_emitente") & " -<i>" & Eval("data_cadastramento", "{0:dd/MM/yy}") & "</i>" & Iif(not isdbnull(Eval("data_recontato")),"<br/><i>Recontato: " & Eval("data_recontato","{0:dd/MM/yy}") & "</i>","") & "<br/>" & Eval("total_pedido", "{0:N2}") & "<br/>Follow-up: " & Eval("data_followup","{0:dd/MM/yy}") %>' 
                        Width="100%"></asp:LinkButton>
                    <asp:Label ID="LblValor" runat="server" Font-Size="8pt"
                        Text='<%# Eval("total_pedido", "{0:N2}") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="False" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle CssClass="TituloPipeline" Height="67px" HorizontalAlign="Center" 
            VerticalAlign="Bottom" Font-Bold="False" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
            
            
            
            SelectCommand="call sp_negociacao(:empresa, :top, :inicial, :intermediario, :final, :nomecliente, :etapa, :uf, :municipio, :codnegociacao, :agente, :item, :funil, :carteira, :vendedor, :data_cadastro_i, :data_cadastro_f, :data_recontato_i, :data_recontato_f, :cod_fonte, :cod_marca, 0, :cod_gestor, :fechamento_ini, :fechamento_fim, :pais)">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa"       SessionField="GlEmpresa"              ConvertEmptyStringToNull="False"  DbType="String"  />
                            <asp:SessionParameter Name=":top"           SessionField="S_PNG_DdlTop"           ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":inicial"       SessionField="S_PNG_CBxInicial"       ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":intermediario" SessionField="S_PNG_CBxIntermediario" ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":final"         SessionField="S_PNG_CBxFinal"         ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":nomecliente"   SessionField="S_PNG_TxtCliente"       ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:ControlParameter ControlID="LblCodEtapa" ConvertEmptyStringToNull="False" 
                                DbType="String" Name=":etapa" PropertyName="Text" />
                            <asp:SessionParameter Name=":uf"            SessionField="S_PNG_TxtUF"            ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":municipio"     SessionField="S_PNG_TxtMunicipio"     ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":codnegociacao" SessionField="S_PNG_TxtNrNegociacao"  ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":agente"        SessionField="S_PNG_ddlAgente"        ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":item"          SessionField="S_PNG_ddlItem"          ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":funil"         SessionField="S_PNG_ddlFunil"         ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":carteira"      SessionField="S_PNG_DdlCarteira"      ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":vendedor"      SessionField="S_PNG_DdlVendedor"      ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":data_cadastro_i" SessionField="S_PNG_TxtDataCadastramentoI" ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":data_cadastro_f" SessionField="S_PNG_TxtDataCadastramentoF" ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":data_recontato_i" SessionField="S_PNG_TxtDataRecontatoI" ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":data_recontato_f" SessionField="S_PNG_TxtDataRecontatoF" ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":cod_fonte" SessionField="S_PNG_DdlFonteOrigem" ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter Name=":cod_marca" SessionField="S_PNG_DdlMarca" ConvertEmptyStringToNull="False"  DbType="String"/>
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                Name=":cod_gestor" SessionField="GlCodGestor" />
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                Name=":fechamento_ini" SessionField="S_PNG_TxtDataPrevisaoI" />
                            <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                Name=":fechamento_fim" SessionField="S_PNG_TxtDataPrevisaoF" />
                            <asp:SessionParameter Name=":pais"          
                                SessionField="S_PNG_TxtPais"          ConvertEmptyStringToNull="False"  
                                DbType="String"/>
                        </SelectParameters>
                    </asp:SqlDataSource>
    </div>
    <asp:Label ID="LblCodEtapa" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="LblNomeEtapa" runat="server" Visible="False"></asp:Label>
</body>