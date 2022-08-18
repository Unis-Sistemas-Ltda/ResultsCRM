Public Class WFRelAtividade
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                TxtData1.Text = "01/" + Today().ToString("MM/yyyy")
                TxtData2.Text = Date.DaysInMonth(Today().Year, Today().Month).ToString.PadLeft(2, "0") + "/" + Today().ToString("MM/yyyy")
                Call CarregaCanalVenda()
                Call CarregaUsuario()
                Call CarregaCarteira()
            End If
        Catch ex As Exception
            lblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaCanalVenda()
        Dim objCanalVenda As New UCLCanalVenda
        objCanalVenda.Empresa = Session("GlEmpresa")
        objCanalVenda.FillControl(LbxCanalVenda, True, "(Todos)")
        LbxCanalVenda.SelectedValue = "0"
    End Sub

    Private Sub CarregaUsuario()
        Dim objUsuario As New UCLUsuario
        objUsuario.FillControl(LbxUsuario, True, "(Todos)")
        LbxUsuario.SelectedValue = "0"
    End Sub

    Private Sub CarregaCarteira()
        Dim objCarteira As New UCLCarteiraCRM
        objCarteira.FillControl(LbxCarteira, True, "(Todos)")
        LbxCarteira.SelectedValue = "0"
    End Sub

    Protected Sub BtnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(TxtData1.Text) Or String.IsNullOrEmpty(TxtData2.Text) Then
            lblErro.Text = "Preencha o período."
            Return
        End If
        Response.Redirect("WFRelAtividadeReport.aspx?" & _
                      "datai=" & ValidaCampo("TxtData1", TxtData1.Text) & _
                      "&dataf=" & ValidaCampo("TxtData2", TxtData2.Text) & _
                      "&tipos=" & ValidaCampo("LbxTipo", LbxTipo.SelectedValue) & _
                      "&canais=" & ValidaCampo("LbxCanalVenda", LbxCanalVenda.SelectedValue) & _
                      "&usuarios=" & ValidaCampo("LbxUsuario", LbxUsuario.SelectedValue) & _
                      "&carteiras=" & ValidaCampo("LbxCarteira", LbxCarteira.SelectedValue))

    End Sub

    Private Function ValidaCampo(ByVal nomeCampo As String, conteudo As String) As String
        Try
            Dim retorno As String = ""
            Dim controle As New ListBox
            Select Case nomeCampo
                Case "TxtData1"
                    If String.IsNullOrWhiteSpace(conteudo) Then
                        Return "1900-01-01"
                    Else
                        Return CDate(conteudo).ToString("yyyy-MM-dd")
                    End If
                Case "TxtData2"
                    If String.IsNullOrWhiteSpace(conteudo) Then
                        Return "2999-12-31"
                    Else
                        Return CDate(conteudo).ToString("yyyy-MM-dd")
                    End If
                Case "LbxTipo", "LbxCanalVenda", "LbxUsuario", "LbxCarteira"
                    If nomeCampo = "LbxTipo" Then
                        controle = LbxTipo
                    ElseIf nomeCampo = "LbxCanalVenda" Then
                        controle = LbxCanalVenda
                    ElseIf nomeCampo = "LbxUsuario" Then
                        controle = LbxUsuario
                    ElseIf nomeCampo = "LbxCarteira" Then
                        controle = LbxCarteira
                    End If
                    For Each item As ListItem In controle.Items
                        If item.Selected Then
                            retorno += item.Value + ","
                        End If
                    Next
                    If retorno.EndsWith(",") Then
                        retorno = Left(retorno, retorno.Length - 1)
                    End If
                    If retorno = "" Then
                        retorno = "0"
                    End If
                    Return retorno
            End Select
            Return conteudo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class