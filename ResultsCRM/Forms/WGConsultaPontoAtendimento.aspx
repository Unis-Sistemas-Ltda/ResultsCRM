<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGConsultaPontoAtendimento.aspx.vb" Inherits="ResultsCRM.WGConsultaPontoAtendimento" %>
<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 258px;
        }
    </style>
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div class="TituloConsulta">Histórico do Ponto de Atendimento</div>
    <div>
    
        <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td style="text-align: right; ">
                    Ponto Atend.:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtPontoAtendimento" runat="server" 
                        CssClass="CampoCadastro" Width="300px" AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="text-align: right">
                    Cód.
                    Cliente:</td>
                <td>
                    <asp:TextBox ID="TxtCodEmitente" runat="server" 
                        CssClass="CampoCadastro" Width="60px" AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="text-align: right">
                    Nome Cliente:</td>
                <td>
                    <asp:TextBox ID="TxtNomeEmitente" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o nome ou parte do nome do cliente." Width="160px" 
                        AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="text-align: right">
                    Equipamento/Patrimônio:</td>
                <td>
                    <asp:TextBox ID="TxtEquipamento" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o nome, parte do nome ou número de patrimônio do equipamento." Width="160px" 
                        AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #FFFFE6;" class="Erro" colspan="8">
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                        GridLines="None" Width="100%" AllowSorting="True" AllowPaging="True" 
                        PageSize="15">
                        <PagerSettings FirstPageText="·1·" LastPageText="·Últ·" 
                            Mode="NumericFirstLast" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="cod_emitente" HeaderText="Cód." 
                                SortExpression="cod_emitente">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nome" HeaderText="Nome Cliente" 
                                SortExpression="nome" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="numero_ponto_atendimento" 
                                HeaderText="Nº Ponto Atendimento" SortExpression="numero_ponto_atendimento">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descricao" HeaderText="Nome Ponto Atendimento" 
                                SortExpression="descricao" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="endereco" HeaderText="Endereço" 
                                SortExpression="endereco" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nome_cidade" HeaderText="Município" 
                                SortExpression="nome_cidade" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sigla" HeaderText="UF" SortExpression="sigla">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
                                        CommandName="DETALHAR" 
                                        ImageUrl="~/Imagens/BtnEditar.png" 
                                        ToolTip="Clique para consultar o registro" 
                                        CommandArgument='<%# Eval("cod_emitente") & ";" & Eval("numero_ponto_atendimento") %>' />
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
                <td colspan="8">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand="  SELECT e.cod_emitente,
         e.nome,
         ppa.numero_ponto_atendimento,
         ppa.descricao,
         ppa.endereco,
         ci.nome_cidade,
         puf.sigla,
         '§' || isnull(ppa.numero_ponto_atendimento,'') || '§' || isnull(ppa.descricao,'') || '§' || isnull(ppa.endereco,'') || '§' || isnull(ci.nome_cidade,'') || '§' || isnull(puf.sigla,'') || '§' ponto_atend
    FROM emitente e inner join  ponto_atendimento ppa on ppa.cod_emitente             = e.cod_emitente
                    left outer join cidade ci on ppa.cod_cidade = ci.cod_cidade and ppa.cod_estado = ci.cod_estado and ppa.cod_pais = ci.cod_pais
                    left outer join estado puf on puf.cod_pais = ppa.cod_pais and puf.cod_estado = ppa.cod_estado
   WHERE (:cod_emitente = '' or trim(:cod_emitente2) = trim(convert(varchar(12), e.cod_emitente)))
     AND isnull(e.nome,'') like '%' || trim(:nome_emitente) || '%'
     AND ponto_atend like '%' || :ponto_atend || '%'
     AND ( (select count(*) from equipamento eq where eq.cod_cliente = ppa.cod_emitente and eq.numero_ponto_atendimento = ppa.numero_ponto_atendimento and (isnull(eq.observacao,'') || isnull(eq.numero_registro,'')) like '%' || trim(:equipamento) || '%' ) > 0
           or trim(:equipamento2) = trim('') )

   ORDER BY e.nome, ppa.numero_ponto_atendimento, ppa.descricao">
                        <SelectParameters>
                            <asp:ControlParameter
                                ControlID="TxtCodEmitente"
                                ConvertEmptyStringToNull="False" 
                                Name=":cod_emitente" 
                                PropertyName="Text" 
                                DefaultValue=""                                
                                Type="String" />
                            <asp:ControlParameter 
                                ControlID="TxtCodEmitente" 
                                ConvertEmptyStringToNull="False" 
                                Name=":cod_emitente2" 
                                PropertyName="Text"
                                DefaultValue=""                                
                                Type="String"/>
                            <asp:ControlParameter
                                ControlID="TxtNomeEmitente" 
                                ConvertEmptyStringToNull="False"
                                Name=":nome_emitente"
                                PropertyName="Text" 
                                Type="String" DefaultValue="" />
                            <asp:ControlParameter
                                ControlID="TxtPontoAtendimento"
                                ConvertEmptyStringToNull="False" 
                                Name=":ponto_atend"
                                PropertyName="Text"
                                DefaultValue="" />
                            <asp:ControlParameter
                                ControlID="TxtEquipamento"
                                ConvertEmptyStringToNull="False" 
                                Name=":equipamento"
                                PropertyName="Text"
                                DefaultValue="" />
                            <asp:ControlParameter
                                ControlID="TxtEquipamento"
                                ConvertEmptyStringToNull="False" 
                                Name=":equipamento2"
                                PropertyName="Text"
                                DefaultValue="" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
