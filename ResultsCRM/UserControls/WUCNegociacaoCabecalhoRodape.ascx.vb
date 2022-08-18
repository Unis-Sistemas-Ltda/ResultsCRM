Public Partial Class WUCNegociacaoCabecalhoRodape
    Inherits System.Web.UI.UserControl
    Private _CodNegociacao As String

    Public Property CodNegociacao() As String
        Get
            Return _CodNegociacao
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If CodNegociacao = -1 Then
            LblErro.Text = "Antes de preencher o cabeçalho e o rodapé da proposta, por favor salve a negociação."
            BtnGravar.Enabled = False
            TxtCabecalho.Enabled = False
            TxtRodape.Enabled = False
            BtnImprimir.Visible = False
        Else
            BtnGravar.Enabled = True
            TxtCabecalho.Enabled = True
            TxtRodape.Enabled = True
            BtnImprimir.Visible = True
        End If
        If Not IsPostBack Then
            Call CarregaFormulario()
        End If
        BtnImprimir.Attributes.Add("OnClick", "window.open('WFImpressaoPropostaPDF.aspx?eid=" + Session("GlEmpresa") + "&sid=" + Session("GlEstabelecimento") + "&nid=" + CodNegociacao + "&ucid=" + Session("GlClienteUnis") + "&li=../Imagens/logo_proposta.jpg');")
    End Sub

    Private Sub CarregaFormulario()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Dim anexos As String() = {"", "", "", "", ""}

        objNegociacao.Empresa = Session("GlEmpresa")
        objNegociacao.Estabelecimento = Session("GlEstabelecimento")
        objNegociacao.CodNegociacao = CodNegociacao
        objNegociacao.Buscar()

        TxtCabecalho.Text = objNegociacao.Cabecalho
        TxtRodape.Text = objNegociacao.Rodape

        If objNegociacao.AnexoProposta.ToString().Contains(",") Then
            anexos = objNegociacao.AnexoProposta.Split(",")
        Else
            anexos(0) = objNegociacao.AnexoProposta.ToString()
        End If

        LblAnexo1.Text = ""
        LblAnexo1.NavigateUrl = ""
        LblAnexo1.Visible = False
        BtnExcluirAnexo1.Visible = False
        FuAnexoProposta1.Visible = True

        LblAnexo2.Text = ""
        LblAnexo2.NavigateUrl = ""
        LblAnexo2.Visible = False
        BtnExcluirAnexo2.Visible = False
        FuAnexoProposta2.Visible = True

        LblAnexo3.Text = ""
        LblAnexo3.NavigateUrl = ""
        LblAnexo3.Visible = False
        BtnExcluirAnexo3.Visible = False
        FuAnexoProposta3.Visible = True

        LblAnexo4.Text = ""
        LblAnexo4.NavigateUrl = ""
        LblAnexo4.Visible = False
        BtnExcluirAnexo4.Visible = False
        FuAnexoProposta4.Visible = True

        LblAnexo5.Text = ""
        LblAnexo5.NavigateUrl = ""
        LblAnexo5.Visible = False
        BtnExcluirAnexo5.Visible = False
        FuAnexoProposta5.Visible = True

        For i As Integer = 0 To 4
            If i < anexos.Length Then
                Select Case i
                    Case 0
                        LblCaminhoAnexo1.Text = anexos(i)
                        If Not String.IsNullOrEmpty(LblCaminhoAnexo1.Text) Then
                            LblAnexo1.Text = GetFileName(LblCaminhoAnexo1.Text)
                            LblAnexo1.NavigateUrl = DominioAnexoEmailNegociacao + LblAnexo1.Text
                            LblAnexo1.Visible = True
                            BtnExcluirAnexo1.Visible = True
                            FuAnexoProposta1.Visible = False
                        End If
                    Case 1
                        LblCaminhoAnexo2.Text = anexos(i)
                        If Not String.IsNullOrEmpty(LblCaminhoAnexo2.Text) Then
                            LblAnexo2.Text = GetFileName(LblCaminhoAnexo2.Text)
                            LblAnexo2.NavigateUrl = DominioAnexoEmailNegociacao + LblAnexo2.Text
                            LblAnexo2.Visible = True
                            BtnExcluirAnexo2.Visible = True
                            FuAnexoProposta2.Visible = False
                        End If
                    Case 2
                        LblCaminhoAnexo3.Text = anexos(i)
                        If Not String.IsNullOrEmpty(LblCaminhoAnexo3.Text) Then
                            LblAnexo3.Text = GetFileName(LblCaminhoAnexo3.Text)
                            LblAnexo3.NavigateUrl = DominioAnexoEmailNegociacao + LblAnexo3.Text
                            LblAnexo3.Visible = True
                            BtnExcluirAnexo3.Visible = True
                            FuAnexoProposta3.Visible = False
                        End If
                    Case 3
                        LblCaminhoAnexo4.Text = anexos(i)
                        If Not String.IsNullOrEmpty(LblCaminhoAnexo4.Text) Then
                            LblAnexo4.Text = GetFileName(LblCaminhoAnexo4.Text)
                            LblAnexo4.NavigateUrl = DominioAnexoEmailNegociacao + LblAnexo4.Text
                            LblAnexo4.Visible = True
                            BtnExcluirAnexo4.Visible = True
                            FuAnexoProposta4.Visible = False
                        End If
                    Case 4
                        LblCaminhoAnexo5.Text = anexos(i)
                        If Not String.IsNullOrEmpty(LblCaminhoAnexo5.Text) Then
                            LblAnexo5.Text = GetFileName(LblCaminhoAnexo5.Text)
                            LblAnexo5.NavigateUrl = DominioAnexoEmailNegociacao + LblAnexo5.Text
                            LblAnexo5.Visible = True
                            BtnExcluirAnexo5.Visible = True
                            FuAnexoProposta5.Visible = False
                        End If
                End Select
            End If
        Next
        
    End Sub

    Private Sub GravarDados()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Try
            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("GlEstabelecimento")
            objNegociacao.CodNegociacao = CodNegociacao
            objNegociacao.Buscar()

            If objNegociacao.CodTipoCobrancaOs = 0 Then
                objNegociacao.CodTipoCobrancaOs = "null"
            End If

            If objNegociacao.CodMotivo = 0 Then
                objNegociacao.CodMotivo = "null"
            End If

            If objNegociacao.CodContato = 0 Then
                objNegociacao.CodContato = "null"
            End If

            If objNegociacao.CodCarteira = 0 Then
                objNegociacao.CodCarteira = "null"
            End If

            If objNegociacao.CodGestorConta = 0 Then
                objNegociacao.CodGestorConta = "null"
            End If

            If objNegociacao.CodAgenteVenda = 0 Then
                objNegociacao.CodAgenteVenda = "null"
            End If

            If objNegociacao.CodCanalVendas = 0 Then
                objNegociacao.CodCanalVendas = "null"
            End If

            If objNegociacao.CodNaturOper = 0 Then
                objNegociacao.CodNaturOper = "null"
            End If

            If String.IsNullOrEmpty(objNegociacao.ProbabilidadeSucesso) Then
                objNegociacao.ProbabilidadeSucesso = "null"
            End If

            If objNegociacao.CodFormaPagto = 0 Then
                objNegociacao.CodFormaPagto = "null"
            End If

            If objNegociacao.CodCondPagto = 0 Then
                objNegociacao.CodCondPagto = "null"
            End If

            objNegociacao.Cabecalho = TxtCabecalho.Text.GetValidInputContent
            objNegociacao.Rodape = TxtRodape.Text.GetValidInputContent

            Dim anexos() As String = {"", "", "", "", ""}

            If Not String.IsNullOrEmpty(FuAnexoProposta1.FileName) Then
                anexos(0) = GetFileName(CaminhoFisicoAnexo1)
            Else
                anexos(0) = GetFileName(LblCaminhoAnexo1.Text)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta2.FileName) Then
                anexos(1) = GetFileName(CaminhoFisicoAnexo2)
            Else
                anexos(1) = GetFileName(LblCaminhoAnexo2.Text)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta3.FileName) Then
                anexos(2) = GetFileName(CaminhoFisicoAnexo3)
            Else
                anexos(2) = GetFileName(LblCaminhoAnexo3.Text)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta4.FileName) Then
                anexos(3) = GetFileName(CaminhoFisicoAnexo4)
            Else
                anexos(3) = GetFileName(LblCaminhoAnexo4.Text)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta5.FileName) Then
                anexos(4) = GetFileName(CaminhoFisicoAnexo5)
            Else
                anexos(4) = GetFileName(LblCaminhoAnexo5.Text)
            End If

            objNegociacao.AnexoProposta = ""

            For i As Integer = 0 To 4
                If i > 0 AndAlso anexos(i).ToString().Trim() <> "" AndAlso objNegociacao.AnexoProposta <> "" Then
                    objNegociacao.AnexoProposta += ","
                End If
                If i = 0 Then
                    objNegociacao.AnexoProposta += GetFileName(CaminhoFisicoAnexo1.Trim)
                ElseIf i = 1 Then
                    objNegociacao.AnexoProposta += GetFileName(CaminhoFisicoAnexo2.Trim)
                ElseIf i = 2 Then
                    objNegociacao.AnexoProposta += GetFileName(CaminhoFisicoAnexo3.Trim)
                ElseIf i = 3 Then
                    objNegociacao.AnexoProposta += GetFileName(CaminhoFisicoAnexo4.Trim)
                ElseIf i = 4 Then
                    objNegociacao.AnexoProposta += GetFileName(CaminhoFisicoAnexo5.Trim)
                End If
            Next

            objNegociacao.Alterar()

            If Not String.IsNullOrEmpty(FuAnexoProposta1.FileName) Then
                FuAnexoProposta1.SaveAs(CaminhoFisicoAnexo1)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta2.FileName) Then
                FuAnexoProposta2.SaveAs(CaminhoFisicoAnexo2)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta3.FileName) Then
                FuAnexoProposta3.SaveAs(CaminhoFisicoAnexo3)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta4.FileName) Then
                FuAnexoProposta4.SaveAs(CaminhoFisicoAnexo4)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta5.FileName) Then
                FuAnexoProposta5.SaveAs(CaminhoFisicoAnexo5)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Call GravarDados()
            Call CarregaFormulario()
            LblErro.Text = "Dados gravados com sucesso."
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnEmail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEmail.Click
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))

        Try
            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("GlEstabelecimento")
            objNegociacao.CodNegociacao = CodNegociacao
            objNegociacao.Buscar()

            Dim anexos() As String = {"", "", "", "", ""}

            If Not String.IsNullOrEmpty(FuAnexoProposta1.FileName) Then
                anexos(0) = GetFileName(CaminhoFisicoAnexo1)
            Else
                anexos(0) = GetFileName(LblCaminhoAnexo1.Text)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta2.FileName) Then
                anexos(1) = GetFileName(CaminhoFisicoAnexo2)
            Else
                anexos(1) = GetFileName(LblCaminhoAnexo2.Text)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta3.FileName) Then
                anexos(2) = GetFileName(CaminhoFisicoAnexo3)
            Else
                anexos(2) = GetFileName(LblCaminhoAnexo3.Text)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta4.FileName) Then
                anexos(3) = GetFileName(CaminhoFisicoAnexo4)
            Else
                anexos(3) = GetFileName(LblCaminhoAnexo4.Text)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta5.FileName) Then
                anexos(4) = GetFileName(CaminhoFisicoAnexo5)
            Else
                anexos(4) = GetFileName(LblCaminhoAnexo5.Text)
            End If

            objNegociacao.AnexoProposta = ""

            For i As Integer = 0 To 4
                If i > 0 AndAlso anexos(i).ToString().Trim() <> "" AndAlso objNegociacao.AnexoProposta <> "" Then
                    objNegociacao.AnexoProposta += ","
                End If
                If i = 0 Then
                    objNegociacao.AnexoProposta += GetFileName(CaminhoFisicoAnexo1.Trim)
                ElseIf i = 1 Then
                    objNegociacao.AnexoProposta += GetFileName(CaminhoFisicoAnexo2.Trim)
                ElseIf i = 2 Then
                    objNegociacao.AnexoProposta += GetFileName(CaminhoFisicoAnexo3.Trim)
                ElseIf i = 3 Then
                    objNegociacao.AnexoProposta += GetFileName(CaminhoFisicoAnexo4.Trim)
                ElseIf i = 4 Then
                    objNegociacao.AnexoProposta += GetFileName(CaminhoFisicoAnexo5.Trim)
                End If

            Next

            If Not String.IsNullOrEmpty(FuAnexoProposta1.FileName) Then
                FuAnexoProposta1.SaveAs(CaminhoFisicoAnexo1)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta2.FileName) Then
                FuAnexoProposta2.SaveAs(CaminhoFisicoAnexo2)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta3.FileName) Then
                FuAnexoProposta3.SaveAs(CaminhoFisicoAnexo3)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta4.FileName) Then
                FuAnexoProposta4.SaveAs(CaminhoFisicoAnexo4)
            End If

            If Not String.IsNullOrEmpty(FuAnexoProposta5.FileName) Then
                FuAnexoProposta5.SaveAs(CaminhoFisicoAnexo5)
            End If

            objNegociacao.Alterar()
            objNegociacao.EnviaNegociacaoPorEmail(Session("GlClienteUnis"), Session("GlSTMP"), Session("GlPortaEnvioEmail"), Session("GlUtilizaSSL"), "")
            Call CarregaFormulario()
            LblErro.Text = "E-mail enviado com sucesso."

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Function GetFileName(ByVal arquivo As String) As String
        Try
            Dim pos As Long = arquivo.LastIndexOf("\")

            If pos = -1 Then
                pos = arquivo.LastIndexOf("/")
            End If

            If pos = -1 Then
                pos = 0
            End If

            arquivo = arquivo.Substring(pos)

            Return arquivo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private ReadOnly Property CaminhoFisicoAnexo1() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosEmail
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Session("GlEmpresa"))

            If Not String.IsNullOrEmpty(FuAnexoProposta1.FileName) Then
                caminhoanexo = FuAnexoProposta1.FileName
                arquivoanexo = GetFileName(caminhoanexo).Replace("\", "")
                arquivoanexo = objParametrosManutencao.GetConteudo("diretorio_anexo_proposta") + "\" + CodNegociacao.PadLeft(7, "0") + "_" + arquivoanexo
            Else
                arquivoanexo = LblCaminhoAnexo1.Text
            End If
            Return arquivoanexo
        End Get
    End Property
    Private ReadOnly Property CaminhoFisicoAnexo2() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosEmail
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Session("GlEmpresa"))

            If Not String.IsNullOrEmpty(FuAnexoProposta2.FileName) Then
                caminhoanexo = FuAnexoProposta2.FileName
                arquivoanexo = GetFileName(caminhoanexo).Replace("\", "")
                arquivoanexo = objParametrosManutencao.GetConteudo("diretorio_anexo_proposta") + "\" + CodNegociacao.PadLeft(7, "0") + "_" + arquivoanexo
            Else
                arquivoanexo = LblCaminhoAnexo2.Text
            End If
            Return arquivoanexo
        End Get
    End Property
    Private ReadOnly Property CaminhoFisicoAnexo3() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosEmail
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Session("GlEmpresa"))

            If Not String.IsNullOrEmpty(FuAnexoProposta3.FileName) Then
                caminhoanexo = FuAnexoProposta3.FileName
                arquivoanexo = GetFileName(caminhoanexo).Replace("\", "")
                arquivoanexo = objParametrosManutencao.GetConteudo("diretorio_anexo_proposta") + "\" + CodNegociacao.PadLeft(7, "0") + "_" + arquivoanexo
            Else
                arquivoanexo = LblCaminhoAnexo3.Text
            End If
            Return arquivoanexo
        End Get
    End Property
    Private ReadOnly Property CaminhoFisicoAnexo4() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosEmail
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Session("GlEmpresa"))

            If Not String.IsNullOrEmpty(FuAnexoProposta4.FileName) Then
                caminhoanexo = FuAnexoProposta4.FileName
                arquivoanexo = GetFileName(caminhoanexo).Replace("\", "")
                arquivoanexo = objParametrosManutencao.GetConteudo("diretorio_anexo_proposta") + "\" + CodNegociacao.PadLeft(7, "0") + "_" + arquivoanexo
            Else
                arquivoanexo = LblCaminhoAnexo4.Text
            End If
            Return arquivoanexo
        End Get
    End Property
    Private ReadOnly Property CaminhoFisicoAnexo5() As String
        Get
            Dim objParametrosManutencao As New UCLParametrosEmail
            Dim caminhoanexo As String
            Dim arquivoanexo As String = ""

            objParametrosManutencao.Buscar(Session("GlEmpresa"))

            If Not String.IsNullOrEmpty(FuAnexoProposta5.FileName) Then
                caminhoanexo = FuAnexoProposta5.FileName
                arquivoanexo = GetFileName(caminhoanexo).Replace("\", "")
                arquivoanexo = objParametrosManutencao.GetConteudo("diretorio_anexo_proposta") + "\" + CodNegociacao.PadLeft(7, "0") + "_" + arquivoanexo
            Else
                arquivoanexo = LblCaminhoAnexo5.Text
            End If
            Return arquivoanexo
        End Get
    End Property

    Protected Sub BtnExcluirAnexo1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExcluirAnexo1.Click
        Try
            System.IO.File.Delete(LblCaminhoAnexo1.Text)
            LblAnexo1.Text = ""
            LblAnexo1.NavigateUrl = ""
            LblCaminhoAnexo1.Text = ""
            LblAnexo1.Visible = False
            BtnExcluirAnexo1.Visible = False
            FuAnexoProposta1.Visible = True
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Sub BtnExcluirAnexo2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExcluirAnexo2.Click
        Try
            System.IO.File.Delete(LblCaminhoAnexo2.Text)
            LblAnexo2.Text = ""
            LblAnexo2.NavigateUrl = ""
            LblCaminhoAnexo2.Text = ""
            LblAnexo2.Visible = False
            BtnExcluirAnexo2.Visible = False
            FuAnexoProposta2.Visible = True
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Sub BtnExcluirAnexo3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExcluirAnexo3.Click
        Try
            System.IO.File.Delete(LblCaminhoAnexo3.Text)
            LblAnexo3.Text = ""
            LblAnexo3.NavigateUrl = ""
            LblCaminhoAnexo3.Text = ""
            LblAnexo3.Visible = False
            BtnExcluirAnexo3.Visible = False
            FuAnexoProposta3.Visible = True
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Sub BtnExcluirAnexo4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExcluirAnexo4.Click
        Try
            System.IO.File.Delete(LblCaminhoAnexo4.Text)
            LblAnexo4.Text = ""
            LblAnexo4.NavigateUrl = ""
            LblCaminhoAnexo4.Text = ""
            LblAnexo4.Visible = False
            BtnExcluirAnexo4.Visible = False
            FuAnexoProposta4.Visible = True
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Sub BtnExcluirAnexo5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExcluirAnexo5.Click
        Try
            System.IO.File.Delete(LblCaminhoAnexo5.Text)
            LblAnexo5.Text = ""
            LblAnexo5.NavigateUrl = ""
            LblCaminhoAnexo5.Text = ""
            LblAnexo5.Visible = False
            BtnExcluirAnexo5.Visible = False
            FuAnexoProposta5.Visible = True
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
End Class