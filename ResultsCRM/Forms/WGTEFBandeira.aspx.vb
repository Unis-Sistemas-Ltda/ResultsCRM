Public Class WGTEFBandeira
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("SCodLoja") = -1 Then
                BtnAdicionar.Enabled = False
                BtnAdicionar.ToolTip = "Você deve os dados da loja antes de adicionar uma bandeira."
            End If

            If Not IsPostBack Then
                Dim objBandeiraTEF As New UCLTEFBandeira
                objBandeiraTEF.FillDropDown(DdlBandeira, False, "", "")

                Dim objAdquirenteTEF As New UCLTefAdquirente
                objAdquirenteTEF.FillDropDown(DdlAdquirente, False, "", "", DdlBandeira.SelectedValue)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub Mensagem(ByVal texto As String)
        If Not String.IsNullOrEmpty(texto) Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('" + texto + "');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "", True)
        End If
    End Sub

    Protected Sub BtnAdicionar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAdicionar.Click
        Try
            Call IncluirBandeira()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub IncluirBandeira()
        Try
            Dim objAdesaoTEFBandeira As New UCLAdesaoTEFBandeira
            Dim objAdesaoTEFLoja As New UCLAdesaoTEFLoja

            objAdesaoTEFLoja.Buscar(Session("GlEmpresa"), Session("SCodLoja"), Session("SCNPJLoja"))

            If objAdesaoTEFBandeira.Buscar(Session("GlEmpresa"), Session("SCodLoja"), objAdesaoTEFLoja.GetConteudo("cnpj"), DdlBandeira.SelectedValue, DdlAdquirente.SelectedValue) Then
                LblErro.Text = "Esta bandeira já foi adicionada."
            Else
                LblErro.Text = ""
                objAdesaoTEFBandeira.SetConteudo("empresa", Session("GlEmpresa"))
                objAdesaoTEFBandeira.SetConteudo("cod_emitente", Session("SCodLoja"))
                objAdesaoTEFBandeira.SetConteudo("cnpj", objAdesaoTEFLoja.GetConteudo("cnpj"))
                objAdesaoTEFBandeira.SetConteudo("cod_bandeira", DdlBandeira.SelectedValue)
                objAdesaoTEFBandeira.SetConteudo("cod_adquirente", DdlAdquirente.SelectedValue)
                objAdesaoTEFBandeira.Incluir()

                SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                SqlDataSource2.DataBind()
                GridView2.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim args As String() = e.CommandArgument.ToString.Split(";")
                Call ExcluirBandeira(args(0), args(1))
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Public Sub ExcluirBandeira(ByVal codBandeira As String, ByVal codAdquirente As String)
        Try
            Dim objAdesaoTEFBandeira As New UCLAdesaoTEFBandeira

            objAdesaoTEFBandeira.Excluir(Session("GlEmpresa"), Session("SCodLoja"), codBandeira, codAdquirente)

            SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            SqlDataSource2.DataBind()
            GridView2.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlBandeira_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlBandeira.SelectedIndexChanged
        Dim objAdquirenteTEF As New UCLTefAdquirente
        objAdquirenteTEF.FillDropDown(DdlAdquirente, False, "", "", DdlBandeira.SelectedValue)
    End Sub
End Class