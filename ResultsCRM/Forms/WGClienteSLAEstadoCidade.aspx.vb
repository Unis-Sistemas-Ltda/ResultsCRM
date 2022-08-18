Public Class WGClienteSLAEstadoCidade
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSLA As New UCLSLA
        Dim objEstado As New UCLEstado

        objSLA.CodSLA = Session("SCodSLA")
        If objSLA.Buscar() Then
            LblCodigoSLA.Text = objSLA.CodSLA
            LblDescricaoSLA.Text = objSLA.Descricao
        End If

        objEstado.CodPais = Session("SCodPaisSLA")
        objEstado.CodEstado = Session("SCodEstadoSLA")
        objEstado.Buscar() 
        LblUF.Text = objEstado.Sigla

    End Sub

    Protected Sub BtnIncluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIncluir.Click
        Session("SAcaoSLAMun") = "INCLUIR"
        Session("SCodCidadeSLA") = -1
        Response.Redirect("WFClienteSLAEstadoCidade.aspx")
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "EDITAR" Then
            Session("SAcaoSLAMun") = e.CommandName
            Session("SCodCidadeSLA") = GetCidade(e.CommandArgument)
            Response.Redirect("WFClienteSLAEstadoCidade.aspx")
        ElseIf e.CommandName = "EXCLUIR" Then
            Dim objSLAEmitenteSLACidade As New UCLSLAEmitenteCidade
            objSLAEmitenteSLACidade.CodSLA = Session("SCodSLA")
            objSLAEmitenteSLACidade.CodEmitente = Session("SCodEmitente")
            objSLAEmitenteSLACidade.CodPais = GetPais(e.CommandArgument)
            objSLAEmitenteSLACidade.CodEstado = GetEstado(e.CommandArgument)
            objSLAEmitenteSLACidade.CodCidade = GetCidade(e.CommandArgument)
            objSLAEmitenteSLACidade.Excluir()

            'Recarrega Grid em Tela
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        End If
    End Sub

    Private Function GetPais(ByVal chave As String) As String
        Try
            Dim pos As Long
            Dim ret As String

            pos = chave.IndexOf(";")
            ret = Left(chave, pos)

            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetEstado(ByVal chave As String) As String
        Try
            Dim pos1 As Long
            Dim pos2 As Long
            Dim ret As String

            pos1 = chave.IndexOf(";")
            pos2 = chave.LastIndexOf(";")
            ret = chave.Substring(pos1 + 1, pos2 - pos1 - 1)

            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetCidade(ByVal chave As String) As String
        Try
            Dim pos As Long
            Dim ret As String

            pos = chave.LastIndexOf(";")
            If (pos + 1) <= chave.Length Then
                ret = chave.Substring(pos + 1)
            Else
                ret = ""
            End If

            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class