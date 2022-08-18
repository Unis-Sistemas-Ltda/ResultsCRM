Public Class WGCausaAcoes
    Inherits System.Web.UI.Page

    Private Const NAO_SELECIONADO As String = "0"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim objAcao As New UCLAcao
                objAcao.FillDropDown(DdlAcao, Session("GlEmpresa"), True, "(selecione)", NAO_SELECIONADO)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Try
            Dim objCausaAcao As New UClCausaAcao

            If DdlAcao.Items.Count = 0 OrElse DdlAcao.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione uma ação."
                Return
            End If

            If Not objCausaAcao.Buscar(Session("GlEmpresa"), Session("SCodCausa"), DdlAcao.SelectedValue) Then
                objCausaAcao.SetConteudo("empresa", Session("GlEmpresa"))
                objCausaAcao.SetConteudo("cod_causa", Session("SCodCausa"))
                objCausaAcao.SetConteudo("cod_acao", DdlAcao.SelectedValue)
                objCausaAcao.Incluir()
                LblErro.Text = "Ação incluída com sucesso."
                GridView1.DataBind()
            Else
                LblErro.Text = "Ação selecionado já incluída."
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim objCausaAcao As New UClCausaAcao
            objCausaAcao.Excluir(Session("GlEmpresa"), Session("SCodCausa"), e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub


End Class