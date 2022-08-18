Partial Public Class WGNegociacaoPipe
    Inherits System.Web.UI.Page

    Private Sub Mensagem(ByVal texto As String)
        Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "window.open('" + texto + "');", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim ObjParam As New UCLParametrosCRM
                ObjParam.Empresa = Session("GlEmpresa")
                ObjParam.Buscar()
                ListView1.GroupItemCount = ObjParam.NrEtapasPipeline
            End If
        Catch ex As Exception
            Mensagem(ex.Message)
        End Try
    End Sub

    Private Sub ListView1_DataBound(sender As Object, e As System.EventArgs) Handles ListView1.DataBound
        Dim l As ListViewItem
        Dim w As WUCFunilEtapaPainel
        Dim CodEtapa As String
        Dim NomeEtapa As String

        For Each i As ListViewItem In ListView1.Items
            If i.ItemType = ListViewItemType.DataItem Then
                w = i.FindControl("WUCFunilEtapaPainel1")
                If w Is Nothing Then
                    w = i.FindControl("WUCFunilEtapaPainel2")
                End If
                CodEtapa = CType(i.FindControl("LblCodEtapa"), Label).Text
                NomeEtapa = CType(i.FindControl("LblNomeEtapa"), Label).Text
                w.CodEtapa = CodEtapa
                w.NomeEtapa = NomeEtapa
                w.DataBind()
            End If
        Next

    End Sub

End Class