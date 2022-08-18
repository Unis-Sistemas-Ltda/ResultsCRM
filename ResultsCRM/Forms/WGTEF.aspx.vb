Public Class WGTEF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaDropdowns()
            DdlGrupoTEF.SelectedValue = -1
            GridView1.DataBind()
        End If
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Dim args As String() = e.CommandArgument.ToString.Split(";")
            Session("SAcao") = e.CommandName
            Session("SCodLoja") = args(0)
            Session("SCNPJLoja") = args(1)
            Response.Redirect("WFTEF.aspx?ori=P")
        ElseIf e.CommandName = "EXCLUIR" Then
            Try
                Dim args As String() = e.CommandArgument.ToString.Split(";")
                Dim objAdesaoLoja As New UCLAdesaoTEFLoja
                objAdesaoLoja.Excluir(Session("GlEmpresa"), args(0), args(1))
            Catch ex As Exception
                If ex.Message.Contains("FK_") Then
                    LblErro.Text = "Não é possível excluir o registro por o mesmo já possui vínculos."
                Else
                    LblErro.Text = ex.Message
                End If
            End Try
        End If
    End Sub

    

    Private Sub CarregaDropdowns()
        Try
            Dim objAdesaoTEF As New UCLAdesaoTEF
            objAdesaoTEF.FillDropDown(DdlGrupoTEF, True, "(Todos)", -1, Session("GlEmpresa"))

            Call CarregaEstado()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SqlDataSource1_Selected(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Selected
        LblQtd.Text = e.AffectedRows
    End Sub

    Public Sub CarregaEstado()
        Dim ObjEstado As New UCLEstado

        ObjEstado.CodPais = 1
        ObjEstado.FillDropDown(DdlUF, True, "(Todos)", UCLEstado.Tipo.Sigla)

    End Sub

    Protected Sub BtnFiltrar0_Click(sender As Object, e As EventArgs) Handles BtnFiltrar0.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodLoja") = -1
        Response.Redirect("WFTEF.aspx?ori=P")
    End Sub
End Class