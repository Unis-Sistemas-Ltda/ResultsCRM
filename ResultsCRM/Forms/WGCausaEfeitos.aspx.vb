Public Class WGCausaEfeitos
    Inherits System.Web.UI.Page

    Private Const NAO_SELECIONADO As String = "0"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim objEfeito As New UCLEfeito
                objEfeito.FillDropDown(DdlEfeito, Session("GlEmpresa"), True, "(selecione)", NAO_SELECIONADO)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Try
            Dim objCausaEfeito As New UCLCausaEfeito

            If DdlEfeito.Items.Count = 0 OrElse DdlEfeito.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione um efeito."
                Return
            End If

            If Not objCausaEfeito.Buscar(Session("GlEmpresa"), Session("SCodCausa"), DdlEfeito.SelectedValue) Then
                objCausaEfeito.SetConteudo("empresa", Session("GlEmpresa"))
                objCausaEfeito.SetConteudo("cod_causa", Session("SCodCausa"))
                objCausaEfeito.SetConteudo("cod_efeito", DdlEfeito.SelectedValue)
                objCausaEfeito.Incluir()
                LblErro.Text = "Efeito incluído com sucesso."
                GridView1.DataBind()
            Else
                LblErro.Text = "Efeito selecionado já incluído."
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim objCausaEfeito As New UCLCausaEfeito
            objCausaEfeito.Excluir(Session("GlEmpresa"), Session("SCodCausa"), e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub

End Class