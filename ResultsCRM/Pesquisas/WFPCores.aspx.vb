Public Partial Class WFPCores1
    Inherits System.Web.UI.Page

    Dim Controle As String
    Dim Comando As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Controle = Request.QueryString("controle").ToString

        SetaRetorno(Button1)
        SetaRetorno(Button2)
        SetaRetorno(Button3)
        SetaRetorno(Button4)
        SetaRetorno(Button5)
        SetaRetorno(Button6)
        SetaRetorno(Button7)
        SetaRetorno(Button8)
        SetaRetorno(Button9)
        SetaRetorno(Button10)
        SetaRetorno(Button11)
        SetaRetorno(Button12)
        SetaRetorno(Button13)
        SetaRetorno(Button14)
        SetaRetorno(Button15)
        SetaRetorno(Button16)
        SetaRetorno(Button17)
        SetaRetorno(Button18)
        SetaRetorno(Button19)
        SetaRetorno(Button20)
        SetaRetorno(Button21)
        SetaRetorno(Button22)
        SetaRetorno(Button23)
        SetaRetorno(Button24)
        SetaRetorno(Button25)
        SetaRetorno(Button26)
        SetaRetorno(Button27)
        SetaRetorno(Button28)
        SetaRetorno(Button29)
        SetaRetorno(Button30)

        MultiViewExpanse.ActiveViewIndex = 0

    End Sub

    Private Sub SetaRetorno(ByRef botao As Button)
        AddHandler botao.Click, AddressOf BotaoClick
        botao.ForeColor = botao.BackColor
        botao.BorderColor = botao.BackColor
    End Sub

    Private Sub BotaoClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim botao As Button = TryCast(sender, Button)
        Session("SCorPesquisada") = botao.BackColor.ToArgb
        Session("SAlterouCor") = CDbl(IIf(Not String.IsNullOrEmpty(Session("SAlterouCor")), 0, Session("SAlterouCor"))) + 1
        ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
    End Sub

    Protected Sub btnOkay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOkay.Click
        Try
            MultiViewExpanse.ActiveViewIndex = 0
            ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)

        Catch ex As Exception

            ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onError();", True)
            MultiViewExpanse.ActiveViewIndex = 0
        End Try
    End Sub

End Class