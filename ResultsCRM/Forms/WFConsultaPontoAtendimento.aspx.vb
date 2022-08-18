Partial Public Class WFConsultaPontoAtendimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))

            objEmitente.CodEmitente = CodEmitente
            objEmitente.Buscar()
            LblCodCliente.Text = objEmitente.CodEmitente
            LblNomeCliente.Text = objEmitente.Nome

            objPontoAtendimento.CodEmitente = CodEmitente
            objPontoAtendimento.NumeroPontoAtendimento = NumeroPontoAtendimento
            objPontoAtendimento.Buscar()
            LblNumeroPontoAtendimento.Text = objPontoAtendimento.NumeroPontoAtendimento
            LblNomePontoAtendimento.Text = objPontoAtendimento.Descricao

            If Visualizacao = 2 Then
                BtnVoltar.Visible = False
                Label4.Font.Size = New System.Web.UI.WebControls.FontUnit(8, UnitType.Point)
                Label5.Font.Size = New System.Web.UI.WebControls.FontUnit(8, UnitType.Point)
                LblCodCliente.Font.Size = New System.Web.UI.WebControls.FontUnit(8, UnitType.Point)
                LblNomeCliente.Font.Size = New System.Web.UI.WebControls.FontUnit(8, UnitType.Point)
                LblNumeroPontoAtendimento.Font.Size = New System.Web.UI.WebControls.FontUnit(8, UnitType.Point)
                LblNomePontoAtendimento.Font.Size = New System.Web.UI.WebControls.FontUnit(8, UnitType.Point)
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub Mensagem(ByVal texto As String)
        If Not String.IsNullOrEmpty(texto) Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('" + texto + "');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "", True)
        End If
    End Sub

    Private ReadOnly Property CodEmitente() As String
        Get
            Return Request.QueryString.Item("ceid").ToString
        End Get
    End Property

    Private ReadOnly Property NumeroPontoAtendimento() As String
        Get
            Return Request.QueryString.Item("paid").ToString
        End Get
    End Property

    Private ReadOnly Property Visualizacao() As String
        Get
            Return Request.QueryString.Item("v").ToString
        End Get
    End Property

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGConsultaPontoAtendimento.aspx")
    End Sub

    Protected Sub TxtEquipamento_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtEquipamento.TextChanged
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub

    Protected Sub TxtPatrimonio_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtPatrimonio.TextChanged
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub
End Class