<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPCores.aspx.vb" Inherits="ResultsCRM.WFPCores1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pesquisa de Cores</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFPCores.aspx";
        }
        function onSuccess() {
            window.parent.document.forms.item(0).submit();
            window.parent.document.getElementById('ButtonEditDone').click();
        }
        function onError() {
            getbacktostepone();
        }
        function cancel() {
            window.parent.document.getElementById('ButtonEditCancel').click();
        }
    </script>
    <style type="text/css">


.TextoCadastro
{
    font-size: 7pt;
    text-align: right;
    font-family: verdana;
    color: #666666;
    background-color: #EFEFEF;
}
.TextoCadastro
{
    font-size: 7pt;
    text-align: right;
    font-family: verdana;
    color: #666666;
    background-color: #EFEFEF;
}
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:MultiView ID="MultiViewExpanse" runat="server">
        <asp:View ID="ViewInput" runat="server">
            <div>
            
        <table class="TextoCadastro" style="width: 230px;">
            <tr>
                <td colspan="6" style="text-align: left" class="TituloConsulta">
                    Cores Disponíveis</td>
            </tr>
            <tr>
                <td colspan="6" style="text-align: left; font-size: 7pt;">
                    Selecione a cor</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" BackColor="#003366" Width="30px" 
                        Text="003366" />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" BackColor="#003300" Width="30px" 
                        Text="003300" />
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" BackColor="#CCCC00" Width="30px" 
                        Text="CCCC00" />
                </td>
                <td>
                    <asp:Button ID="Button16" runat="server" BackColor="Maroon" Width="30px" 
                        Text="800000" />
                </td>
                <td>
                    <asp:Button ID="Button17" runat="server" BackColor="#990099" Width="30px" 
                        Text="990099" />
                </td>
                <td class="TextoCadastro">
                    <asp:Button ID="Button26" runat="server" BackColor="#CCCCCC" Width="30px" 
                        Text="CCCCCC" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button8" runat="server" BackColor="#0066FF" Width="30px" 
                        Text="0066FF" />
                </td>
                <td>
                    <asp:Button ID="Button7" runat="server" BackColor="Lime" Width="30px" 
                        Text="00FF00" />
                </td>
                <td>
                    <asp:Button ID="Button4" runat="server" BackColor="Yellow" Width="30px" 
                        Text="FFFF00" />
                </td>
                <td>
                    <asp:Button ID="Button25" runat="server" BackColor="#CC0000" Width="30px" 
                        Text="CC0000" />
                </td>
                <td>
                    <asp:Button ID="Button18" runat="server" BackColor="#FF3399" Width="30px" 
                        Text="FF3399" />
                </td>
                <td class="TextoCadastro">
                    <asp:Button ID="Button27" runat="server" BackColor="#999999" Width="30px" 
                        Text="999999" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button9" runat="server" BackColor="#006699" Width="30px" 
                        Text="006699" />
                </td>
                <td>
                    <asp:Button ID="Button6" runat="server" BackColor="#009933" Width="30px" 
                        Text="009933" />
                </td>
                <td>
                    <asp:Button ID="Button5" runat="server" BackColor="#FFCC00" Width="30px" 
                        Text="FFCC00" />
                </td>
                <td>
                    <asp:Button ID="Button24" runat="server" BackColor="Red" Width="30px" 
                        Text="FF0000" />
                </td>
                <td>
                    <asp:Button ID="Button19" runat="server" BackColor="#FF33CC" Width="30px" 
                        Text="FF33CC" />
                </td>
                <td class="TextoCadastro">
                    <asp:Button ID="Button28" runat="server" BackColor="#666666" Width="30px" 
                        Text="666666" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button10" runat="server" BackColor="#00CCFF" Width="30px" 
                        Text="00CCFF" />
                </td>
                <td>
                    <asp:Button ID="Button11" runat="server" BackColor="#006600" Width="30px" 
                        Text="006600" />
                </td>
                <td>
                    <asp:Button ID="Button12" runat="server" BackColor="#FF9933" Width="30px" 
                        Text="FF9933" />
                </td>
                <td>
                    <asp:Button ID="Button23" runat="server" BackColor="#CC3300" Width="30px" 
                        Text="CC3300" />
                </td>
                <td>
                    <asp:Button ID="Button20" runat="server" BackColor="#FF66FF" Width="30px" 
                        Text="FF66FF" />
                </td>
                <td class="TextoCadastro">
                    <asp:Button ID="Button29" runat="server" BackColor="#CCFFFF" Width="30px" 
                        Text="CCFFFF" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button13" runat="server" BackColor="Blue" Width="30px" 
                        Text="0000FF" />
                </td>
                <td>
                    <asp:Button ID="Button14" runat="server" BackColor="#009900" Width="30px" 
                        Text="009900" />
                </td>
                <td>
                    <asp:Button ID="Button15" runat="server" BackColor="#FF6600" Width="30px" 
                        Text="FF6600" />
                </td>
                <td>
                    <asp:Button ID="Button22" runat="server" BackColor="#993300" Width="30px" 
                        Text="993300" />
                </td>
                <td>
                    <asp:Button ID="Button21" runat="server" BackColor="#CC99FF" Width="30px" 
                        Text="CC99FF" />
                </td>
                <td class="TextoCadastro">
                    <asp:Button ID="Button30" runat="server" BackColor="White" Width="30px" 
                        Text="FFFFFF" />
                </td>
            </tr>
            <tr>
                        <td colspan="6" style="height: 16px">
                            <asp:Button id="btnOkay" runat="server" CssClass="Botao" 
                                OnClick="btnOkay_Click" Text="Done" Visible="False" />
                            &nbsp;<input id="btnCancel" class="Botao" onclick="cancel();" 
                                style="border-style: none; font-family: verdana; text-decoration: underline; text-align: center;" 
                                type="button" value="Fechar" /></td>
                    </tr>
            </table>
            
            </div>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
