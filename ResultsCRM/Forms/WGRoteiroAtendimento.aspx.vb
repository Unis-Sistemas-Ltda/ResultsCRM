Partial Public Class WGRoteiroAtendimento
    Inherits System.Web.UI.Page
    Dim objParametrosManutencao As New UCLParametrosManutencao
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TxtDataI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")

            If Not IsPostBack Then
                Call CarregaTecnico()
                Call AplicaFiltro(False)
            End If

        Catch ex As Exception
            LblErro.Text = ex.ToString
        End Try
    End Sub

    Private Sub CarregaTecnico()
        Dim objAgTecnico As New UCLAgenteTecnico
        objAgTecnico.FillDropDown(DdlAgenteTecnico, True, "(Todos)", 0)
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            LblErro.Text = ""
            If e.CommandName = "ALTERAR" Then
                Session("SCodRoteiroAtendimento") = e.CommandArgument
                Session("SAcao") = "ALTERAR"
                Try
                    Response.Redirect("WFRoteiroAtendimento.aspx")
                Catch ex As Exception
                End Try
            ElseIf e.CommandName = "EMAIL" Then
                Dim ObjRoteiroAtendimento As New UCLRoteiroAtendimento
                Dim retorno As String = ObjRoteiroAtendimento.EnviaEmailRoteiro(StrConexaoUsuario(Session("GlUsuario")), Session("GlEmpresa"), Session("GlEstabelecimento"), e.CommandArgument)
                If Not String.IsNullOrWhiteSpace(retorno) Then
                    LblErro.Text = retorno
                Else
                    LblErro.Text = "O e-mail será enviado dentro de até 5 minutos."
                End If
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
                        Session("S_ROT_" + ctrl.ID) = CType(ctrl, TextBox).Text
                    ElseIf TypeOf ctrl Is DropDownList Then
                        Session("S_ROT_" + ctrl.ID) = CType(ctrl, DropDownList).SelectedValue
                    End If
                Next
            Else
                For Each ctrl As Control In CType(Me.Page.Form.Controls.Item(3), UpdatePanel).Controls.Item(0).Controls
                    If TypeOf ctrl Is TextBox Then
                        If Session("S_ROT_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_ROT_" + ctrl.ID).ToString) Then
                            CType(ctrl, TextBox).Text = Session("S_ROT_" + ctrl.ID)
                        End If
                    ElseIf TypeOf ctrl Is DropDownList Then
                        If Session("S_ROT_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_ROT_" + ctrl.ID).ToString) Then
                            CType(ctrl, DropDownList).SelectedValue = Session("S_ROT_" + ctrl.ID)
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
        Session("SAcao") = "INCLUIR"
        Session("SCodRoteiroAtendimento") = -1
        Response.Redirect("WFRoteiroAtendimento.aspx")
    End Sub
End Class