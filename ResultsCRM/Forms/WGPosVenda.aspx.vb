Public Class WGPosVenda
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub AplicaFiltro()
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcaoPosVenda") = e.CommandName
            Session("SAcao") = e.CommandName
            Session("SCodEmitente") = GetCodEmitente(e.CommandArgument)
            Session("SCNPJEmitente") = GetCNPJEmitente(e.CommandArgument)
            Session("SCNPJEmitentePrincipal") = GetCNPJEmitente(e.CommandArgument)
            Response.Redirect("WFClienteDetalhes.aspx")
        End If
    End Sub

    Private Function GetCodEmitente(ByVal chave As String) As String
        Dim cod As String = ""
        Dim pos As Long
        Try
            If Not String.IsNullOrEmpty(chave) Then
                If chave.Contains(";") Then
                    pos = chave.IndexOf(";")
                    cod = Left(chave, pos)
                End If
            End If
            Return cod
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetCNPJEmitente(ByVal chave As String) As String
        Dim cnpj As String = ""
        Dim pos As Long
        Try
            If Not String.IsNullOrEmpty(chave) Then
                If chave.Contains(";") Then
                    pos = chave.IndexOf(";")
                    cnpj = chave.Substring(pos + 1)
                End If
            End If
            Return cnpj
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call AplicaFiltro()
    End Sub

    Protected Sub BtnNovoRegistro_Click(sender As Object, e As ImageClickEventArgs) Handles BtnNovoRegistro.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodEmitente") = -1
        Response.Redirect("WFClienteDetalhes.aspx")
    End Sub
End Class