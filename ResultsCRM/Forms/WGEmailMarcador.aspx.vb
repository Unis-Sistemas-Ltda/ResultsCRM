Public Class WGEmailMarcador
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("SMarcadorSelecionado") = ""
            Session("SRecarregaDDLMarcador") = "False"
        End If
        If Not IsPostBack OrElse Session("SRecarregaDDLMarcador") = "True" Then
            Call CarregaMarcador()
        End If
    End Sub

    Private Sub CarregaMarcador()
        Try
            Dim objMarcador As New UCLMarcador
            objMarcador.FillDropDown(DdlMarcador, Session("GlEmpresa"), True, "(selecione)", "0", "0")
            If Session("SMarcadorSelecionado") <> "" Then
                DdlMarcador.SelectedValue = Session("SMarcadorSelecionado")
                Call Vincular()
                Session("SMarcadorSelecionado") = ""
                Session("SRecarregaDDLMarcador") = "False"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim ObjEmailMarcador As New UCLEmailMarcador
                ObjEmailMarcador.Excluir(Session("GlEmpresa"), Request.QueryString.Item("e"), e.CommandArgument)
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Vincular()
        Try
            LblErro.Text = ""
            If DdlMarcador.SelectedValue = "0" Then
                LblErro.Text = "Selecione um marcador."
            Else
                Dim ObjEmailMarcador As New UCLEmailMarcador
                If ObjEmailMarcador.Buscar(Session("GlEmpresa"), Request.QueryString.Item("e"), DdlMarcador.SelectedValue) Then
                    LblErro.Text = "Marcador já vinculado."
                Else
                    ObjEmailMarcador.Incluir()
                    GridView1.DataBind()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Call Vincular()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub SqlDataSource1_Init(sender As Object, e As System.EventArgs) Handles SqlDataSource1.Init
        SqlDataSource1.ConnectionString = StrConexaoEmail
    End Sub
End Class