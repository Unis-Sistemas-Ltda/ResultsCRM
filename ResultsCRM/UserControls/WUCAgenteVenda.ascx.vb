Partial Public Class WUCAgenteVenda
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodAgente As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodAgente() As String
        Get
            Return _CodAgente
        End Get
        Set(ByVal value As String)
            _CodAgente = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim alterouCodUsuario As Long
        Dim CodUsuarioPesquisado As String = Session("SCodUsuarioPesquisado")

        If Not String.IsNullOrEmpty(Session("SAlterouCodUsuario")) Then
            alterouCodUsuario = Session("SAlterouCodUsuario")
        Else
            alterouCodUsuario = 0
        End If

        If Not String.IsNullOrEmpty(CodUsuarioPesquisado) Then
            If alterouCodUsuario > 0 Then
                If TxtCodUsuario.Text <> CodUsuarioPesquisado Then
                    TxtCodUsuario.Text = CodUsuarioPesquisado
                End If
                Session("SAlterouCodUsuario") = alterouCodUsuario - 1
            End If
        End If

        If Not IsPostBack Then
            Call CarregaTipos()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            End If
            Call CarregaFunis()
        End If

        Call MostraNomeUsuario()
    End Sub

    Private Sub CarregaFunis()
        Dim objFunil As New UCLFunilVenda
        Dim dt As DataTable = objFunil.GetFunis(Session("GlEmpresa"))
        Dim objAgenteVenda As New UCLAgenteVendas
        Dim funisSelecionados As List(Of String) = objAgenteVenda.GetFunis(Session("GlEmpresa"), TxtCodUsuario.Text)

        For Each row As DataRow In dt.Rows
            Dim li As New ListItem
            li.Value = row.Item("cod_funil")
            li.Text = row.Item("descricao")
            li.Selected = funisSelecionados.Contains(li.Value)
            CbxFunis.Items.Add(li)
        Next
    End Sub

    Private Sub CarregaFormulario()
        Dim objAgente As New UCLAgenteVendas
        TxtCodUsuario.Text = CodAgente

        objAgente.Codigo = CodAgente
        objAgente.Buscar()

        DdlTipoAgente.SelectedValue = objAgente.Tipo
    End Sub

    Private Sub MostraNomeUsuario()
        Dim objUsuario As New UCLUsuario
        If Not String.IsNullOrEmpty(TxtCodUsuario.Text) Then
            objUsuario.CodUsuario = TxtCodUsuario.Text
            objUsuario.BuscarPorCodigo()
            LblNomeUsuario.Text = objUsuario.NomeUsuario
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objAgente As New UCLAgenteVendas
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objAgente.Codigo = TxtCodUsuario.Text
                    objAgente = CarregaObjeto(objAgente)
                    objAgente.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    objAgente.Codigo = TxtCodUsuario.Text
                    objAgente = CarregaObjeto(objAgente)
                    objAgente.Incluir()
                End If

                For Each item As ListItem In CbxFunis.Items
                    If item.Selected Then
                        objAgente.ExcluirFunil(Session("GlEmpresa"), TxtCodUsuario.Text, item.Value)
                        objAgente.InserirFunil(Session("GlEmpresa"), TxtCodUsuario.Text, item.Value)
                    Else
                        objAgente.ExcluirFunil(Session("GlEmpresa"), TxtCodUsuario.Text, item.Value)
                    End If
                Next

                Response.Redirect("WGAgenteVenda.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtCodUsuario.Text) Then
            LblErro.Text += "Preencha o campo Usuário.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjAgente As UCLAgenteVendas) As UCLAgenteVendas

        ObjAgente.Tipo = DdlTipoAgente.SelectedValue

        Return ObjAgente
    End Function

    Private Sub CarregaTipos()
        Dim objTipoAgente As New UCLTipoAgenteVenda
        objTipoAgente.FillDropDown(DdlTipoAgente, False, "")
    End Sub

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGAgenteVenda.aspx")
    End Sub
End Class