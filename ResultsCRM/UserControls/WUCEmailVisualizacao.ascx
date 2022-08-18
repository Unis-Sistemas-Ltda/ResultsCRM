<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCEmailVisualizacao.ascx.vb" Inherits="ResultsCRM.WUCEmailVisualizacao" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
<style type="text/css">
    .style1
    {
        height: 15px;
    }
</style>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table class="TextoCadastro_BGBranco" 
    style="margin: 0px; width: 100%; border-collapse: collapse;">
    <tr>
        <td colspan="4" style="text-align: center">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro" style="padding: 10px;"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold;">
            Seq.
            E-mail:</td>
        <td colspan="3" style="width: 80%">
            <asp:Label ID="LblNrEmail" runat="server"  Text="0"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold;">
            <asp:Label ID="Label1" runat="server"  Text="Data da Mensagem:"></asp:Label>
        </td>
        <td colspan="3">
            <asp:Label ID="LblData" runat="server" Width="70px" 
                MaxLength="10"></asp:Label>
            <asp:Label ID="LblHora" runat="server" Width="45px" 
                MaxLength="5"></asp:Label>
&nbsp;
            </td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold;">
            Remetente:</td>
        <td colspan="3">
            <asp:Label ID="LblRemetenteNome" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold;">
            Destinatário:</td>
        <td colspan="3">
            <asp:Label ID="LblDestinatario" runat="server" CssClass="CampoCadastro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold;">
            Cópia para (CC):</td>
        <td colspan="3">
            <asp:Label ID="LblEmailCC" runat="server" CssClass="CampoCadastro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-weight: bold;">
            Cópia oculta (CCO):</td>
        <td>
            <asp:Label ID="LblCCO" runat="server" CssClass="CampoCadastro"></asp:Label>
        </td>
        <td style="text-align: right">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #CCCCCC; text-align: right; font-weight: bold; border-top-style: solid;" 
            class="style1">
            Assunto:</td>
        <td colspan="3" 
            
            
            style="border-width: 1px; border-color: #CCCCCC; border-top-style: solid; font-weight: bold;" 
            class="style1">
            <asp:Label ID="LblAssunto" runat="server" CssClass="CampoCadastro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top; font-weight: bold;">
            Anexo(s):</td>
        <td colspan="3">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1" GridLines="None" ShowHeader="False" 
                Width="100%" EmptyDataText="Nenhum anexo.">
                <Columns>
                    <asp:TemplateField HeaderText="arquivo" SortExpression="arquivo">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("arquivo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                NavigateUrl='<%# Eval("arquivo") %>' Target="_blank" 
                                Text='<%# Eval("arquivo") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select arquivo from email_anexo
 where seq_email = :seq_email
   and empresa   = :empresa
 order by seq_anexo">
                <SelectParameters>
                    <asp:ControlParameter ControlID="LblNrEmail" Name=":seq_email" 
                        PropertyName="Text" />
                    <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #CCCCCC; text-align: right; vertical-align: top; font-weight: bold; border-top-style: solid;">
            <br />
            Mensagem:</td>
        <td colspan="3" 
            style="border-width: 1px; border-color: #CCCCCC; border-top-style: solid;">
            <br />
            <asp:Label ID="LblMensagem" runat="server" CssClass="CampoCadastro" 
                TextMode="MultiLine"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top">
            &nbsp;</td>
        <td colspan="3">
            &nbsp;</td>
    </tr>
</table>