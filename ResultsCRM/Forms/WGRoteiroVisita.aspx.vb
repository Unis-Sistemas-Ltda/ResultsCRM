Public Class WGRoteiroVisita
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TxtDataI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            If Not IsPostBack Then
                Session.Remove("SCodNegociacao")
                Call CarregaRepresentante()
                Call AplicaFiltro(False)
            End If
        Catch ex As Exception
            LblErro.Text = ex.ToString
        End Try
    End Sub

    Private Sub CarregaRepresentante()
        Dim objEmitente As New UCLEmitente(StrConexao)
        objEmitente.FillDropDown(DdlRepresentante, True, "(selecione)", UCLEmitente.TipoEmitenteDDL.Representante, "0", True, UCLEmitente.TipoExibicaoDDL.Nome, Session("GlCodGestor"))
        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
            DdlRepresentante.SelectedValue = Session("GlCodEmitenteExterno")
            DdlRepresentante.Enabled = False
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            LblErro.Text = ""
            If e.CommandName = "ALTERAR" Then
                Session("SCodRoteiroVisita") = e.CommandArgument
                Session("SAcaoRoteiroVisita") = "ALTERAR"
                Response.Redirect("WFRoteiroVisitaDetalhes.aspx")
            ElseIf e.CommandName = "EXCLUIR" Then
                Dim objRoteiroVisita As New UCLRoteiroVisita
                objRoteiroVisita.Excluir(Session("GlEmpresa"), Session("GlEstabelecimento"), e.CommandArgument)
                GridView1.DataBind()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try

    End Sub

    Protected Sub AplicaFiltro(ByVal postback As Boolean)
        Try
            If postback Then
                For Each ctrl As Control In CType(Me.Page.Form.Controls.Item(3), UpdatePanel).Controls.Item(0).Controls
                    If TypeOf ctrl Is TextBox Then
                        Session("S_ROTV_" + ctrl.ID) = CType(ctrl, TextBox).Text
                    ElseIf TypeOf ctrl Is DropDownList Then
                        Session("S_ROTV_" + ctrl.ID) = CType(ctrl, DropDownList).SelectedValue
                    End If
                Next
            Else
                For Each ctrl As Control In CType(Me.Page.Form.Controls.Item(3), UpdatePanel).Controls.Item(0).Controls
                    If TypeOf ctrl Is TextBox Then
                        If Session("S_ROTV_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_ROTV_" + ctrl.ID).ToString) Then
                            CType(ctrl, TextBox).Text = Session("S_ROTV_" + ctrl.ID)
                        End If
                    ElseIf TypeOf ctrl Is DropDownList Then
                        If Session("S_ROTV_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_ROTV_" + ctrl.ID).ToString) Then
                            CType(ctrl, DropDownList).SelectedValue = Session("S_ROTV_" + ctrl.ID)
                        End If
                    End If
                Next
            End If

            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            LblErro.Text = ex.ToString
        End Try
    End Sub

    Protected Sub BtnAplicarFiltro_Click(sender As Object, e As EventArgs) Handles BtnAplicarFiltro.Click
        AplicaFiltro(True)
    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Session("SCodRoteiroVisita") = -1
        Session("SAcaoRoteiroVisita") = "INCLUIR"
        Response.Redirect("WFRoteiroVisitaDetalhes.aspx")
    End Sub

End Class