Public Class WGClienteEquipamento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("SNumeroPontoAtendimento") Is Nothing OrElse String.IsNullOrEmpty(Session("SNumeroPontoAtendimento")) Then
            BtnNovoRegistro.Visible = False
        Else
            BtnNovoRegistro.Visible = True
        End If
        Session("SModoCadEquipamento") = WUCEquipamento.ModoJanela.AberturaPeloCadastroDelaMesma
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "ALTERAR" Then
                Session("SCodEmitenteAtNegociacao") = Session("SCodEmitente")
                Session("SPontoAtendimento") = Session("SNumeroPontoAtendimento")
                Session("SNumeroSerieItemPedido") = e.CommandArgument
                Response.Redirect("WFEquipamento.aspx?aid=A")
            ElseIf e.CommandName = "EXCLUIR" Then
                Dim objEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
                objEquipamento.Empresa = Session("GlEmpresa")
                objEquipamento.NumeroSerie = e.CommandArgument
                objEquipamento.Excluir()
                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
        
    End Sub

    Protected Sub BtnNovoRegistro_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SCodEmitenteAtNegociacao") = Session("SCodEmitente")
        Session("SPontoAtendimento") = Session("SNumeroPontoAtendimento")
        Session("SNumeroSerieItemPedido") = ""
        Response.Redirect("WFEquipamento.aspx?aid=I")
    End Sub
End Class