Public Class WGClienteMercado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("GlBloquearCadastroEmitenteRepresentante") = "S" Then
            BtnAdicionar.Visible = False
        End If

        If Not IsPostBack Then
            Dim objMercado As New UCLMercado
            objMercado.FillDropDown(DdlMercado, True, " (selecione) ")
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Try
                Dim objClienteMercado As New UCLClienteMercado()
                objClienteMercado.Excluir(Session("SCodEmitente"), e.CommandArgument)
                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "onload", "alert('Registro excluído com sucesso!')", True)
            Catch ex As Exception
                If ex.Message.Contains("FK_") Then
                    LblErro.Text = "Não é possível excluir o registro pois o mesmo já possui vínculos no sistema."
                Else
                    LblErro.Text = ex.Message
                End If
            End Try
        End If
    End Sub

    Protected Sub BtnAdicionar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAdicionar.Click
        Try
            Call IncluirMercado()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub IncluirMercado()
        Try
            Dim objClienteMercado As New UCLClienteMercado()

            If DdlMercado.Items.Count = 0 Then
                Throw New Exception("Selecione o grupo.")
            End If

            If DdlMercado.SelectedValue = "0" Then
                Throw New Exception("Selecione o grupo.")
            End If

            If objClienteMercado.Buscar(Session("SCodEmitente"), DdlMercado.SelectedValue) Then
                Throw New Exception("Grupo já vinculado ao cliente.")
            End If

            objClienteMercado.SetConteudo("cod_emitente", Session("SCodEmitente"))
            objClienteMercado.SetConteudo("cod_mercado", DdlMercado.SelectedValue)
            objClienteMercado.SetConteudo("preferencial", "N")
            objClienteMercado.Incluir()

            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub ChkPreferencial_CheckedChanged(sender As Object, e As EventArgs)
        Try
            Dim chk As CheckBox = CType(sender, CheckBox)
            Dim preferencial As String
            Dim objClienteMercado As New UCLClienteMercado

            LblErro.Text = ""

            If chk.Checked Then
                preferencial = "S"
            Else
                preferencial = "N"
            End If

            If preferencial = "S" AndAlso objClienteMercado.BuscarPreferencial(Session("SCodEmitente")) <> "" Then
                LblErro.Text = "Somente um grupo pode ser marcado como preferencial."
            Else
                objClienteMercado.Buscar(Session("SCodEmitente"), chk.AccessKey)
                objClienteMercado.SetConteudo("preferencial", preferencial)
                objClienteMercado.Alterar()
            End If

            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class