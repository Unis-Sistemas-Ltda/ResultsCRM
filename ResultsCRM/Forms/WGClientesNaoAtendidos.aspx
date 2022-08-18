<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGClientesNaoAtendidos.aspx.vb" Inherits="ResultsCRM.WGClientesNaoAtendidos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .TituloMovimento {
            font-family: Verdana;
            font-size: 12pt;
            font-weight: bold;
            color: #FFFFFF;
            background-color: #666666;
            text-align: center;
        }

        .TextoCadastro_BGBranco {
            font-size: 7pt;
            text-align: left;
            font-family: verdana;
            color: #666666;
            background-color: #FFFFFF;
        }

        .CampoCadastro {
            font-size: 7pt;
            font-family: verdana;
            color: #666666;
            text-align: left;
            margin-bottom: 0px;
        }

        .style1 {
            width: 258px;
        }

        .Erro {
            font-size: 7pt;
            text-align: left;
            color: #CC0000;
            font-family: verdana;
        }
        .auto-style1 {
            width: 146px;
        }
    </style>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="TituloMovimento">
                <asp:ScriptManager ID="ScriptManager1" runat="server"
                    EnableScriptGlobalization="True">
                </asp:ScriptManager>
                Clientes Não Atendidos
            </div>
            <div>

                <table style="border: thin groove #CCCCCC; width: 100%; font-family: verdana; font-size: 7pt;"
                    class="TextoCadastro_BGBranco">
                    <tr>
                        <td style="text-align: right;">Estabelecimento:</td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="DdlEstabelecimento_i" runat="server" CssClass="CampoCadastro"
                                Width="160px" ClientIDMode="Static">
                            </asp:DropDownList>
                            <asp:Label ID="Label3" runat="server" Height="16px" Text="&nbsp;a&nbsp;"></asp:Label>
                            <asp:DropDownList ID="DdlEstabelecimento_f" runat="server" CssClass="CampoCadastro"
                                Width="160px" ClientIDMode="Static">
                            </asp:DropDownList>
                        </td>
                      <td style="text-align: right;">UF:</td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="TxtUF" runat="server" 
                        CssClass="CampoCadastro" MaxLength="2" Width="30px" ClientIDMode="Static"></asp:TextBox>

                        </td>
                        <td style="text-align: right;">Modelo:</td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="DDlModelo" runat="server" CssClass="CampoCadastro"
                                Width="160px" ClientIDMode="Static">
                                <asp:ListItem Value="1" Selected="True">(Todos)</asp:ListItem>
                                <asp:ListItem Value="2">Roteiro de Entrega</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                       
                       <td style="text-align: right;" class="auto-style1">Unidade de Negócio:</td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="TxtUnidadeNegocio" runat="server" 
                        CssClass="CampoCadastro" Width="110px" ClientIDMode="Static"></asp:TextBox>

                        </td>
                        <td style="text-align: right;">
                            <asp:Button ID="Button1" runat="server" CssClass="Botao" Text="Pesquisar" />
                        </td>


                    </tr>
                    <tr>
                          <td style="text-align: right;">Representante:</td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="DDlRepresentante_i" runat="server" CssClass="CampoCadastro"
                                Width="160px" ClientIDMode="Static">
                            </asp:DropDownList>
                            <asp:Label ID="Label4" runat="server" Height="16px" Text="&nbsp;a&nbsp;"></asp:Label>
                            <asp:DropDownList ID="DDlRepresentante_f" runat="server" CssClass="CampoCadastro"
                                Width="160px" ClientIDMode="Static">
                            </asp:DropDownList>
                        </td>
                          <td style="text-align: right;">Município:</td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="TxtMunicipio" runat="server" 
                        CssClass="CampoCadastro" Width="110px" ClientIDMode="Static"></asp:TextBox>

                        </td>

                       
                       <td style="text-align: right;">Período:<br />
                        </td>
                        <td class="CelulaCampoCadastro">
                            <%--<uc1:TextBoxData ID="TxtData1" runat="server" />
                    <asp:Label ID="Label6" runat="server" Text="&nbsp;a" Height="17px"></asp:Label>&nbsp;
                    <uc1:TextBoxData ID="TxtData2" runat="server" />--%>
                            <asp:TextBox ID="TxtDataPeriodoI" runat="server" CssClass="CampoCadastro"
                                MaxLength="10" Style="text-align: center" Width="70px" ClientIDMode="Static"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtDataPeriodoI_CalendarExtender" runat="server"
                                TargetControlID="TxtDataPeriodoI" FirstDayOfWeek="Sunday" Format="dd/MM/yyyy"
                                TodaysDateFormat="d MMMM yyyy" />
                            <asp:Label ID="Label6" runat="server" Height="16px" Text="&nbsp;a&nbsp;"></asp:Label>
                            <asp:TextBox ID="TxtDataPeriodoF" runat="server" CssClass="CampoCadastro"
                                MaxLength="10" Style="text-align: center" Width="70px" CausesValidation="True"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtDataPeriodoF_CalendarExtender" runat="server"
                                TargetControlID="TxtDataPeriodoF" FirstDayOfWeek="Sunday" Format="dd/MM/yyyy"
                                TodaysDateFormat="d MMMM yyyy" />
                        </td>
                        <td style="text-align: left; vertical-align: top;" colspan="2">
                            <asp:CheckBox ID="CBxJaComprou" runat="server"
                                Text="Somente clientes que já tenham comprado ao menos uma vez" Height="17px" ClientIDMode="Static" />

                        </td>
                          <td style="text-align: right;">
                            <asp:Button ID="Button2" runat="server" CssClass="Botao" Text="Gerar Negociação" />
                        </td>

                    </tr>
                    <tr>
                          <td style="text-align: right;"></td>
                        <td style="text-align: left;">
                          
                        </td>
                          <td style="text-align: right;">Situação:</td>
                        <td style="text-align: left;">
                           <asp:DropDownList ID="DdlSituacao" runat="server" CssClass="CampoCadastro"
                                Width="160px" ClientIDMode="Static">
                                <asp:ListItem Value="0" Selected="True">(Todos)</asp:ListItem>
                                <asp:ListItem Value="1">Potencial</asp:ListItem>
                                <asp:ListItem Value="2">Ativo</asp:ListItem>
                                <asp:ListItem Value="3">Inativo</asp:ListItem>
                                <asp:ListItem Value="4">Em Ativação</asp:ListItem>
                                <asp:ListItem Value="6">Ativo Pend. Doc.</asp:ListItem>
                            </asp:DropDownList>
                        </td>

                       
                      
                        <td style="text-align: left; vertical-align: top;" colspan="2">
                            <asp:CheckBox ID="CheckBox1" runat="server"
                                Text="Informar outro Agente de Vendas" Height="17px" ClientIDMode="Static" AutoPostBack="True" />

                        </td>
                         <td style="text-align: right;"><asp:Label ID="lblAgenteVendas" runat="server" Height="16px" Text="Ag. Vendas:" Visible="False"></asp:Label> 
                        </td>
                        <td class="CelulaCampoCadastro">
                          <asp:DropDownList ID="DdlAgenteVendas" runat="server" CssClass="CampoCadastro"
                                Width="160px" ClientIDMode="Static" Visible="False">
                            </asp:DropDownList>
                        </td>
                        
                          <td style="text-align: right;">
                              &nbsp;</td>

                    </tr>
                    <tr>
                        <td style="background-color: #FFFFE6;" class="Erro" colspan="8">
                            <asp:Label ID="LblErro" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333"
                                GridLines="None" Width="100%" AllowSorting="True" AllowPaging="True"
                                PageSize="16" EmptyDataText="Nenhum cadastro foi encontrado." ShowHeaderWhenEmpty="false">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ."
                                    Mode="NumericFirstLast" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                    HorizontalAlign="Left" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Cód." SortExpression="cod_emitente">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("cod_emitente") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nome" SortExpression="nome">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nome_emitente") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("nome_emitente") %>'></asp:Label>                                           
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Font-Bold="True" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="cnpj" HeaderText="CNPJ/CPF" SortExpression="cnpj" />
                                    <asp:BoundField DataField="status_emitente" HeaderText="Situação Emitente" SortExpression="status_emitente" />
                                    <asp:BoundField DataField="nome_cidade" HeaderText="Município" SortExpression="nome_cidade" />
                                    <asp:BoundField DataField="sigla_uf" HeaderText="UF" SortExpression="sigla_uf" />
                                    <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                                    <asp:BoundField DataField="telefone" HeaderText="Contatos" SortExpression="telefone" />
                                    <asp:BoundField DataField="rep_nome" HeaderText="Representante" SortExpression="rep_nome" />
                                    <asp:BoundField DataField="canal_nome" HeaderText="Canal" SortExpression="canal_nome" />
                                    <asp:BoundField DataField="dias_atraso" HeaderText="Dias em Atraso" SortExpression="dias_atraso" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    
                                      <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:checkbox ID="chkRow" runat="server"                                               
                                                ToolTip="Clique para gerar negociação."  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
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
                                SelectCommand="call sp_rel_clientes_nao_atendidos_crm (@empresa = :empresa,  @estabelecimento_i = :estabelecimento_i, @estabelecimento_f = :estabelecimento_f,  @periodo_i = :periodo_i, @periodo_f = :periodo_f, @rep_i = :rep_i, @rep_f = :rep_f, @modelo = :modelo, @ja_comprou = :ja_comprou, @uf= :uf, @cidade= :municipio, @unidade_negocio = :unidade_negocio, @situacao = :situacao)" DeleteCommand="delete emitente where cod_emitente is null">

                                <SelectParameters>
                                    <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                                    <asp:SessionParameter Name=":estabelecimento_i" SessionField="SEstab_i" />
                                    <asp:SessionParameter Name=":estabelecimento_f" SessionField="SEstab_f" />
                                    <asp:SessionParameter Name=":periodo_i" SessionField="SPeriodo_i" />
                                    <asp:SessionParameter Name=":periodo_f" SessionField="SPeriodo_f" />
                                    <asp:SessionParameter Name=":rep_i" SessionField="SRep_i" />
                                    <asp:SessionParameter Name=":rep_f" SessionField="SRep_f" />
                                    <asp:ControlParameter Name=":modelo"  ControlID="DdlModelo"  PropertyName="Text" ConvertEmptyStringToNull="False" />
                                    <asp:SessionParameter Name=":ja_comprou" SessionField="SJaComprou" />
                                    <asp:ControlParameter Name=":uf" ControlID="TxtUF" ConvertEmptyStringToNull="False"   PropertyName="Text" />
                                    <asp:ControlParameter Name=":municipio" ControlID="TxtMunicipio" ConvertEmptyStringToNull="False"    PropertyName="Text" />
                                    <asp:ControlParameter Name=":unidade_negocio" ControlID="TxtUnidadeNegocio" ConvertEmptyStringToNull="False"    PropertyName="Text" />      
                                    <asp:ControlParameter Name=":situacao"  ControlID="DdlSituacao"  PropertyName="Text" ConvertEmptyStringToNull="False" />                               
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>

            </div>

        </div>
    </form>
</body>
</html>
