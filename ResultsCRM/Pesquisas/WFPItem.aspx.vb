Partial Public Class WFPItem
    Inherits System.Web.UI.Page
    Dim Controle As String
    Dim Comando As String
    Dim VariavelArmazenamentoPesquisa As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Controle = Request.QueryString("textbox").ToString
        MultiViewExpanse.ActiveViewIndex = 0



        If Not String.IsNullOrEmpty(Request.QueryString.Item("varmp")) Then
            VariavelArmazenamentoPesquisa = Request.QueryString.Item("varmp").ToString()
        End If

    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        If String.IsNullOrEmpty(VariavelArmazenamentoPesquisa) Then
            If e.CommandName = "SELECIONAR" Then
                Session("SAlterouCodItem") = "S"
                Session("SCodItemPesquisado") = e.CommandArgument
                ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
            End If
        Else
            If e.CommandName = "SELECIONAR" Then
                Session("SAlterouCodItemReferencia") = "S"
                Session("SCodItemPesquisadoReferencia") = e.CommandArgument
                ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
            End If
        End If

    End Sub

    Protected Sub TxtFornecedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNome.TextChanged
        TxtNome.Text = TxtNome.Text
    End Sub

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnFiltrar.Click
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
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