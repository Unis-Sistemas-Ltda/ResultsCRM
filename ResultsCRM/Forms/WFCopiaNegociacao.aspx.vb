Public Partial Class WFCopiaNegociacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LblNegociacao.Text = Session("SCodNegociacao")

        If LblClicouNoSim.Text = "True" Then
            Session("SCodNegociacao") = LblNovaNeg.Text
            Session("SAcao") = "ALTERAR"
            Response.Redirect("WFNegociacao.aspx")
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("WGNegociacao.aspx")
    End Sub

    Protected Sub BtnSim_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSim.Click
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Dim novaneg As String

        novaneg = objNegociacao.CopiaNegociacao(Session("GlEmpresa"), Session("GlEstabelecimento"), Session("SCodNegociacao"))

        If IsNumeric(novaneg) Then
            LblNovaNeg.Text = novaneg
            LblClicouNoSim.Text = "True"
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('A negociação foi copiada com sucesso. O Nº da nova negociação é " + novaneg + ".'); document.forms[0].submit();", True)
        Else
            LblErro.Text = novaneg
        End If

    End Sub

End Class