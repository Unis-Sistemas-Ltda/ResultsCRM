Imports System.Drawing

Public Class WGAssessoriaPainel
    Inherits System.Web.UI.Page
    Dim objAcessoDados As New UCLAcessoDados

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaTipoAssessoria()
                Call CarregaAssessoria()
                Call CarregaEtapaAssessoria("")
                Call AplicaFiltro(False)
            End If
        Catch ex As Exception
            LblErro.Text = ex.ToString
        End Try
    End Sub

    Private Sub CarregaTipoAssessoria()
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += "select * from tipo_assessoria order by descricao"
        dt = objAcessoDados.BuscarDados(strSql)

        Dim NovaLinha As DataRow = dt.NewRow
        NovaLinha("cod_tipo_assessoria") = 0
        NovaLinha("descricao") = "Todos"
        dt.Rows.InsertAt(NovaLinha, 0)

        DdlTipoAssessoria.DataSource = dt

        DdlTipoAssessoria.DataTextField = "descricao"
        DdlTipoAssessoria.DataValueField = "cod_tipo_assessoria"
        DdlTipoAssessoria.DataBind()
    End Sub

    Private Sub CarregaAssessoria()
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += "select * from assessoria order by descricao"
        dt = objAcessoDados.BuscarDados(strSql)

        Dim NovaLinha As DataRow = dt.NewRow
        NovaLinha("cod_assessoria") = 0
        NovaLinha("descricao") = "Todos"
        dt.Rows.InsertAt(NovaLinha, 0)

        DdlAssessoria.DataSource = dt

        DdlAssessoria.DataTextField = "descricao"
        DdlAssessoria.DataValueField = "cod_assessoria"
        DdlAssessoria.DataBind()
    End Sub

    Private Sub CarregaEtapaAssessoria(ByVal assesoria As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += "select * from assessoria_etapa "
        If assesoria <> "" Then
            strSql += "where cod_assessoria = " + assesoria + ""
        End If
        strSql += " order by descricao"

        dt = objAcessoDados.BuscarDados(strSql)

        Dim NovaLinha As DataRow = dt.NewRow
        NovaLinha("cod_etapa") = 0
        NovaLinha("descricao") = "Todos"
        dt.Rows.InsertAt(NovaLinha, 0)

        DdlEtapaAssessoria.DataSource = dt

        DdlEtapaAssessoria.DataTextField = "descricao"
        DdlEtapaAssessoria.DataValueField = "cod_etapa"
        DdlEtapaAssessoria.DataBind()
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            Dim LblColorida As Label
            Dim data As DataRowView = e.Row.DataItem
            If data Is Nothing Then Exit Sub

            If e.Row.RowType = DataControlRowType.DataRow Then
                LblColorida = CType(e.Row.FindControl("LblColorida"), Label)
                If data.Item("status_credenciamento") = "Ativo" Then LblColorida.BackColor = Color.Green
                If data.Item("status_credenciamento") = "Inativo" Then LblColorida.BackColor = Color.Orange
                If data.Item("status_credenciamento") = "Não Credenciado" Then LblColorida.BackColor = Color.Red
                If data.Item("status_credenciamento") = "Em Credenciamento" Then LblColorida.BackColor = Color.Yellow
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try

    End Sub

    Protected Sub AplicaFiltro(ByVal postback As Boolean)
        Try
            Session("emitente") = TxtCliente.Text
            Session("tipoAssessoria") = DdlTipoAssessoria.SelectedValue.ToString()
            Session("assessoria") = DdlAssessoria.SelectedValue.ToString()
            Session("etapa") = DdlEtapaAssessoria.SelectedValue.ToString()
            Session("status") = DdlStatus.SelectedValue.ToString()
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            LblErro.Text = ex.ToString
        End Try
    End Sub

    Protected Sub BtnAplicarFiltro_Click(sender As Object, e As EventArgs) Handles BtnAplicarFiltro.Click
        AplicaFiltro(True)
    End Sub

    Protected Sub DdlAssessoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlAssessoria.SelectedIndexChanged
        Try
            Dim cod As String
            cod = DdlAssessoria.SelectedValue.ToString()
            If cod <> "" Then
                If cod = 0 Then
                    cod = ""
                End If
            End If

            Call CarregaEtapaAssessoria(cod)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class