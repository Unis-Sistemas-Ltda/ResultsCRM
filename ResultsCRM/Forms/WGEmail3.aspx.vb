Public Class WGEmail3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("SAcaoEmailAuxiliar") = ""
            Session("SSeqEmailAuxiliar") = "0"

            Call CarregaMarcador()

            Dim objUsuario As New UCLSysUsuario
            objUsuario.FillDropDown(DdlUsuarioGeral, True, "(Todos)", 0, True, 0, "")
            If Request.QueryString.Item("tc") = 1 Then
                objUsuario.FillDropDown(DdlUsuarioPessoal, True, "(Todos)", 0, False, "", "")
                DdlUsuarioPessoal.SelectedValue = "0"
            Else
                objUsuario.FillDropDown(DdlUsuarioPessoal, True, "(Todos)", 0, False, Session("GlCodUsuario"), Session("GlCodUsuario"))
                DdlUsuarioPessoal.SelectedValue = Session("GlCodUsuario")
            End If
            DdlUsuarioGeral.SelectedValue = "-9"
            Call AplicaFiltro(False)

            If Request.QueryString.Item("t") = 4 OrElse Request.QueryString.Item("t") = 9 Then
                GridView1.Columns.Item(9).Visible = True
                GridView1.Columns.Item(2).HeaderText = "Local"
                GridView1.Columns.Item(10).Visible = False
                If Request.QueryString.Item("t") <> 9 Then
                    GridView1.Columns.Item(2).Visible = False
                End If
            ElseIf Request.QueryString.Item("t") = 6 Then
                GridView1.Columns.Item(2).Visible = True
                GridView1.Columns.Item(2).HeaderText = "Origem"
                GridView1.Columns.Item(9).Visible = True
                GridView1.Columns.Item(10).Visible = False
            ElseIf Request.QueryString.Item("t") = 0 OrElse Request.QueryString.Item("t") = 1 OrElse Request.QueryString.Item("t") = 2 OrElse Request.QueryString.Item("t") = 5 Then
                GridView1.Columns.Item(2).Visible = False
                GridView1.Columns.Item(2).HeaderText = "Local"
                GridView1.Columns.Item(9).Visible = False
                GridView1.Columns.Item(10).Visible = False
            Else
                GridView1.Columns.Item(2).Visible = False
                GridView1.Columns.Item(2).HeaderText = "Local"
                GridView1.Columns.Item(9).Visible = False
                GridView1.Columns.Item(10).Visible = False
            End If

            If Request.QueryString.Item("tc") = 1 Then
                CbxContaPessoal.Visible = False
                Label1.Visible = False
                DdlUsuarioGeral.Visible = False
                CbxGeral.Visible = False
                Label5.Visible = False
                DdlUsuarioPessoal.Visible = False
            End If
        End If
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Dim objEmail2 As New UCLEmail2
            If objEmail2.Buscar(Session("GlEmpresa"), e.CommandArgument) Then
                Select Case objEmail2.GetConteudo("situacao")
                    Case 1, 2, 3, 4, 6
                        Response.Redirect("WFEmailDetalhes.aspx?p=WFEmailVisualizacao&e=" + e.CommandArgument + "&t=" + Request.QueryString.Item("t") + "&tc=" + Request.QueryString.Item("tc") + "&cc=" + Request.QueryString.Item("cc"))
                    Case 0, 5
                        Session("SAcaoEmail") = "ALTERAR"
                        Response.Redirect("WFEmailDetalhes.aspx?p=WFEmail&e=" + e.CommandArgument + "&t=" + Request.QueryString.Item("t") + "&tc=" + Request.QueryString.Item("tc") + "&cc=" + Request.QueryString.Item("cc"))
                End Select
            End If
        ElseIf e.CommandName = "ASSUMIR" Then
            Dim args() As String = e.CommandArgument.ToString.Split(";")
            Dim objEmail2 As New UCLEmail2
            If objEmail2.Buscar(Session("GlEmpresa"), args(0)) Then
                objEmail2.SetConteudo("cod_usuario", Session("GlCodUsuario"))
                objEmail2.Alterar()
                AplicaFiltro(True)
            End If
        ElseIf e.CommandName = "LIDO" Then
            Dim args() As String = e.CommandArgument.ToString.Split(";")
            Dim objEmail2 As New UCLEmail2
            objEmail2.SetSituacaoLeitura(Session("GlEmpresa"), args(0), IIf(args(1) = 0, 1, 0))
            AplicaFiltro(True)
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AplicaFiltro(True)
    End Sub

    Protected Sub AplicaFiltro(ByVal postback As Boolean)
        Try
            If postback Then
                For Each ctrl As Control In Me.Page.Form.Controls
                    If TypeOf ctrl Is TextBox Then
                        Session("S_PEM_" + ctrl.ID) = CType(ctrl, TextBox).Text
                    ElseIf TypeOf ctrl Is DropDownList Then
                        Session("S_PEM_" + ctrl.ID) = CType(ctrl, DropDownList).SelectedValue
                    ElseIf TypeOf ctrl Is CheckBox Then
                        Session("S_PEM_" + ctrl.ID) = CType(ctrl, CheckBox).Checked
                    End If
                Next
            Else
                For Each ctrl As Control In Me.Page.Form.Controls
                    If TypeOf ctrl Is TextBox Then
                        If Session("S_PEM_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_PEM_" + ctrl.ID).ToString) Then
                            CType(ctrl, TextBox).Text = Session("S_PEM_" + ctrl.ID)
                        End If
                    ElseIf TypeOf ctrl Is DropDownList Then
                        If Session("S_PEM_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_PEM_" + ctrl.ID).ToString) Then
                            CType(ctrl, DropDownList).SelectedValue = Session("S_PEM_" + ctrl.ID)
                        End If
                    ElseIf TypeOf ctrl Is CheckBox Then
                        If Session("S_PEM_" + ctrl.ID) IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("S_PEM_" + ctrl.ID).ToString) Then
                            CType(ctrl, CheckBox).Checked = Session("S_PEM_" + ctrl.ID)
                        End If
                    End If
                Next
            End If

            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaMarcador()
        Try
            Dim objMarcador As New UCLMarcador
            objMarcador.FillDropDown(DdlMarcador, Session("GlEmpresa"), True, "(Todos)", "0", "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SqlDataSource1_Init(sender As Object, e As System.EventArgs) Handles SqlDataSource1.Init
        SqlDataSource1.ConnectionString = StrConexaoEmail
    End Sub
End Class