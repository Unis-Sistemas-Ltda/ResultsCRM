Partial Public Class WGSistemaRelease
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaSistema()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim ObjSistemaRelease As New UCLSistemaRelease
            ObjSistemaRelease.CodSistema = DdlSistema.SelectedValue
            ObjSistemaRelease.Release = e.CommandArgument
            ObjSistemaRelease.Excluir()
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        End If
    End Sub

    Private Sub CarregaSistema()
        Dim objSistema As New UCLSistema
        objSistema.FillDropDown(DdlSistema)
    End Sub

    Protected Sub BtnNovoRegistro_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Try
            Dim ObjSistemaRelease As New UCLSistemaRelease

            If Not IsNumeric(TxtRelease.Text) OrElse TxtRelease.Text.Contains(".") OrElse TxtRelease.Text.Contains(",") Then
                LblErro.Text = "Release deve conter apenas números."
                Return
            End If

            ObjSistemaRelease.CodSistema = DdlSistema.SelectedValue
            ObjSistemaRelease.Release = TxtRelease.Text

            If ObjSistemaRelease.Existe() Then
                LblErro.Text = "Release já cadastrado."
                Return
            End If

            ObjSistemaRelease.Incluir()

            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlSistema_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlSistema.SelectedIndexChanged
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub
End Class