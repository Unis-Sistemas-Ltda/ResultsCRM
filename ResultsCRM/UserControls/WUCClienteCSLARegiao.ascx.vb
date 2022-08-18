Partial Public Class WUCClienteCSLARegiao
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodSLA As String
    Private _CodCliente As String
    Private _CodPais As String
    Private _CodEstado As String
    Private _CodRegiao As String
    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property CodSLA() As String
        Get
            Return _CodSLA
        End Get
        Set(ByVal value As String)
            _CodSLA = value
        End Set
    End Property
    Public Property CodCliente As String
        Get
            Return _CodCliente
        End Get
        Set(ByVal value As String)
            _CodCliente = value
        End Set
    End Property
    Public Property CodPais As String
        Get
            Return _CodPais
        End Get
        Set(ByVal value As String)
            _CodPais = value
        End Set
    End Property
    Public Property CodEstado As String
        Get
            Return _CodEstado
        End Get
        Set(ByVal value As String)
            _CodEstado = value
        End Set
    End Property
    Public Property CodRegiao As String
        Get
            Return _CodRegiao
        End Get
        Set(ByVal value As String)
            _CodRegiao = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSLAEmitenteEstado As New UCLSLAEmitenteEstado
        If Not IsPostBack Then
            If Acao = "EDITAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
                Try
                    objSLAEmitenteEstado.CodEmitente = CodCliente
                    objSLAEmitenteEstado.CodSLA = CodSLA
                    objSLAEmitenteEstado.CodPais = CodPais
                    objSLAEmitenteEstado.CodEstado = CodEstado
                    objSLAEmitenteEstado.Buscar()
                    TxtPrazoChegada.Text = objSLAEmitenteEstado.PrazoChegada
                    TxtPrazoEncerramento.Text = objSLAEmitenteEstado.PrazoEncerramento
                Catch ex As Exception
                    Throw ex
                End Try
            End If

            Dim objSLA As New UCLSLA
            objSLA.CodSLA = CodSLA
            objSLA.Buscar()
            LblDescricaoSLA.Text = objSLA.Descricao
            LblCodSLA.Text = objSLA.CodSLA

            Dim objEstado As New UCLEstado
            objEstado.CodPais = CodPais
            objEstado.CodEstado = CodEstado
            objEstado.Buscar()
            LblUF.Text = objEstado.Sigla
        End If
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim objSLARegiao As New UCLSLAEmitenteRegiao

            objSLARegiao.CodSLA = CodSLA
            objSLARegiao.CodEmitente = CodCliente
            objSLARegiao.CodPais = CodPais
            objSLARegiao.CodEstado = CodEstado
            objSLARegiao.CodRegiao = CodRegiao
            If objSLARegiao.Buscar() Then
                TxtPrazoEncerramento.Text = objSLARegiao.PrazoEncerramento
                TxtPrazoChegada.Text = objSLARegiao.PrazoChegada
                TxtNomeRegiao.Text = objSLARegiao.NomeRegiao
                LblCodRegiao.Text = CodRegiao
                Call CarregaCidades(objSLARegiao.Cidades)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CarregaCidades(ByVal cidades As List(Of UCLSLAEmitenteRegiaoCidade))
        Try
            Dim dt As New DataTable
            Dim novaLinha As DataRow
            Dim objCidade As New UCLCidade

            dt.Columns.Add("chave")
            dt.Columns.Add("nome_cidade")

            For Each cidade As UCLSLAEmitenteRegiaoCidade In cidades
                objCidade.CodPais = cidade.CodPais
                objCidade.CodEstado = cidade.CodEstado
                objCidade.CodCidade = cidade.CodCidade
                objCidade.Buscar()

                novaLinha = dt.NewRow
                novaLinha.Item("chave") = cidade.CodPais + ";" + cidade.CodEstado + ";" + cidade.CodCidade
                novaLinha.Item("nome_cidade") = objCidade.NomeCidade.ToUpper
                dt.Rows.Add(novaLinha)
            Next

            Session("DtCidade") = dt
            SetaComposicao(dt)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objSLAEmitenteRegiao As New UCLSLAEmitenteRegiao
            If IsDigitacaoOk() Then
                If Acao = "EDITAR" Then
                    objSLAEmitenteRegiao.CodSLA = CodSLA
                    objSLAEmitenteRegiao.CodEmitente = CodCliente
                    objSLAEmitenteRegiao.CodPais = CodPais
                    objSLAEmitenteRegiao.CodEstado = CodEstado
                    objSLAEmitenteRegiao.CodRegiao = CodRegiao
                    objSLAEmitenteRegiao.Buscar()
                    objSLAEmitenteRegiao = CarregaObjeto(objSLAEmitenteRegiao)
                    objSLAEmitenteRegiao.Alterar()
                    Response.Redirect("WGClienteSLAEstadoRegiao.aspx")
                ElseIf Acao = "INCLUIR" Then
                    objSLAEmitenteRegiao.CodSLA = CodSLA
                    objSLAEmitenteRegiao.CodEmitente = CodCliente
                    objSLAEmitenteRegiao.CodPais = CodPais
                    objSLAEmitenteRegiao.CodEstado = CodEstado
                    Call CarregaNovaPK()
                    objSLAEmitenteRegiao.CodRegiao = LblCodRegiao.Text
                    objSLAEmitenteRegiao = CarregaObjeto(objSLAEmitenteRegiao)
                    objSLAEmitenteRegiao.Incluir()
                    Response.Redirect("WGClienteSLAEstadoRegiao.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function CarregaObjeto(ByRef objSLAEmitenteRegiao As UCLSLAEmitenteRegiao) As UCLSLAEmitenteRegiao
        Dim cidades As New List(Of UCLSLAEmitenteRegiaoCidade)
        Dim objSLAEmitenteRegiaoCidade As UCLSLAEmitenteRegiaoCidade
        Dim dt As DataTable

        objSLAEmitenteRegiao.PrazoEncerramento = TxtPrazoEncerramento.Text.GetValidInputContent
        objSLAEmitenteRegiao.PrazoChegada = TxtPrazoChegada.Text.GetValidInputContent
        objSLAEmitenteRegiao.NomeRegiao = TxtNomeRegiao.Text.GetValidInputContent

        dt = Session("DtCidade")

        For Each row As DataRow In dt.Rows
            objSLAEmitenteRegiaoCidade = New UCLSLAEmitenteRegiaoCidade
            objSLAEmitenteRegiaoCidade.CodSLA = objSLAEmitenteRegiao.CodSLA
            objSLAEmitenteRegiaoCidade.CodEmitente = objSLAEmitenteRegiao.CodEmitente
            objSLAEmitenteRegiaoCidade.CodPais = objSLAEmitenteRegiao.CodPais
            objSLAEmitenteRegiaoCidade.CodEstado = objSLAEmitenteRegiao.CodEstado
            objSLAEmitenteRegiaoCidade.CodRegiao = objSLAEmitenteRegiao.CodRegiao
            objSLAEmitenteRegiaoCidade.CodCidade = GetCidade(row.Item("chave"))
            cidades.Add(objSLAEmitenteRegiaoCidade)
        Next

        objSLAEmitenteRegiao.Cidades = cidades

        Return objSLAEmitenteRegiao
    End Function

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""
        If String.IsNullOrEmpty(TxtPrazoEncerramento.Text) Then
            LblErro.Text += "Preencha o campo Prazo Encerramento.<br/>"
        End If
        If String.IsNullOrEmpty(TxtPrazoChegada.Text) Then
            LblErro.Text += "Preencha o campo Prazo Chegada.<br/>"
        End If
        If String.IsNullOrEmpty(TxtNomeRegiao.Text) Then
            LblErro.Text += "Preencha o campo Nome Região.<br/>"
        End If
        Return LblErro.Text.Trim = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Try
            Response.Redirect("WGClienteSLAEstadoRegiao.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub BtnPesquisa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnPesquisa.Click
        Try
            Dim objCidade As New UCLCidade
            Dim dt As DataTable

            dt = objCidade.DtCidadePorDescricao(TxtPesquisaCidade.Text, CodEstado)

            LbFiltro.DataSource = dt
            LbFiltro.DataTextField = "nome_cidade"
            LbFiltro.DataValueField = "chave"
            LbFiltro.DataBind()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnIncluir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnIncluir.Click
        Dim Chave As String
        Dim ChaveAux As String
        Dim descricao As String
        Dim dt As DataTable
        Dim novaLinha As DataRow

        If LbCidades.Items.Count = 0 Then
            Session("DtCidade") = Nothing
        End If

        If Session("DtCidade") Is Nothing Then
            dt = New DataTable
            dt.Columns.Add("chave")
            dt.Columns.Add("nome_cidade")
        Else
            dt = Session("DtCidade")
        End If

        If String.IsNullOrEmpty(LbFiltro.SelectedValue) Then
            If LbFiltro.Items.Count > 0 AndAlso LbFiltro.Items.Count = 1 Then
                LbFiltro.Items.Item(0).Selected = True
            Else
                Return
            End If
        End If

        novaLinha = dt.NewRow
        LblErro.Text = ""

        Chave = LbFiltro.SelectedValue
        descricao = LbFiltro.SelectedItem.Text

        For Each row As DataRow In dt.Rows
            ChaveAux = row.Item("chave")
            If ChaveAux = Chave Then
                Return
            End If
        Next

        novaLinha.Item("chave") = Chave
        novaLinha.Item("nome_cidade") = descricao

        dt.Rows.Add(novaLinha)

        Call SetaComposicao(dt)

        Session("DtCidade") = Nothing
        Session("DtCidade") = dt

    End Sub

    Protected Sub BtnExcluir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnExcluir.Click
        Dim Chave As String
        Dim ChaveAux As String
        Dim dt As DataTable
        Dim count As Integer = 0

        Chave = LbCidades.SelectedValue
        dt = Session("DtCidade")

        For Each row As DataRow In dt.Rows
            ChaveAux = row.Item("chave")
            If ChaveAux = Chave Then
                dt.Rows.RemoveAt(count)
                Exit For
            End If
            count += 1
        Next

        Session("DtCidade") = Nothing
        Session("DtCidade") = dt
        SetaComposicao(dt)

    End Sub

    Protected Sub SetaComposicao(ByVal dt)
        LbCidades.DataSource = dt
        LbCidades.DataTextField = "nome_cidade"
        LbCidades.DataValueField = "chave"
        LbCidades.DataBind()
    End Sub

    Private Sub CarregaNovaPK()
        Dim objSLAEmitenteRegiao As New UCLSLAEmitenteRegiao
        objSLAEmitenteRegiao.CodSLA = CodSLA
        objSLAEmitenteRegiao.CodEmitente = CodCliente
        objSLAEmitenteRegiao.CodPais = CodPais
        objSLAEmitenteRegiao.CodEstado = CodEstado
        LblCodRegiao.Text = objSLAEmitenteRegiao.GetProximoCodigo
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