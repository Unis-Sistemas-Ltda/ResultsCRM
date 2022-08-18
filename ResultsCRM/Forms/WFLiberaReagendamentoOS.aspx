<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFLiberaReagendamentoOS.aspx.vb" Inherits="ResultsCRM.WFLiberaReagendamentoOS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="TextoCadastro_BGBranco" style="width:100%;">
            <tr>
                <td class="TituloMovimento" colspan="2">
                    Liberação de Reagendamento da Ordem de Serviço</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="Erro" colspan="2">
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Informe o número da Ordem de Serviço:</td>
                <td>
                    <asp:TextBox ID="TxtNumeroOS" runat="server" CssClass="CampoCadastro" 
                        MaxLength="10" Width="70px"></asp:TextBox>
&nbsp;
                    <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" 
                        onclientclick="return confirm('Deseja liberar o reagendamento da OS?');" 
                        Text="Liberar Reagendamento" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
