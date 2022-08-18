Partial Public Class WGVisitacao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TxtDataI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")

            If Not IsPostBack Then
                Session.Remove("SCodNegociacao")
                Session.Remove("SCodRoteiroVisita")
                Call CarregaRepresentante()
                Call AplicaFiltro()
            End If

        Catch ex As Exception
            LblErro.Text = ex.ToString
        End Try
    End Sub

    Private Sub CarregaRepresentante()
        Dim ObjEmitente As New UCLEmitente(StrConexao)
        ObjEmitente.FillDropDown(ddlRepresentante, True, "(Todos)", UCLEmitente.TipoEmitenteDDL.Representante, 0, False, UCLEmitente.TipoExibicaoDDL.Nome, Session("GlCodGestor"))

        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
            ddlRepresentante.SelectedValue = Session("GlCodEmitenteExterno")
            ddlRepresentante.Enabled = False
            GridView1.Columns.Item(2).Visible = False
        Else
            GridView1.Columns.Item(2).Visible = True
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SSeqVisita") = e.CommandArgument
            Session("SAcaoVisitacao") = "ALTERAR"
            Response.Redirect("WFVisitacao.aspx?b=WGVisitacao.aspx")
        End If
    End Sub

    Protected Sub AplicaFiltro()
        Try
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            LblErro.Text = ex.ToString
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call AplicaFiltro()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Session("SAcaoVisitacao") = "INCLUIR"
        Session("SSeqVisita") = -1
        Response.Redirect("WFVisitacao.aspx?b=WGVisitacao.aspx")
    End Sub
End Class