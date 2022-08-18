Partial Public Class WUCVisitacao
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _Codigo As String

    Public ReadOnly Property BackTo As String
        Get
            Return Request.QueryString.Item("b")
        End Get
    End Property

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TxtData.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtHora.Attributes.Add("OnKeyPress", "formatacampo(this,'##:##');")

            Dim CodClientePesquisado As String
            Dim alterouCodCliente As Long

            If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
                alterouCodCliente = Session("SAlterouCodCliente")
            Else
                alterouCodCliente = 0
            End If

            CodClientePesquisado = Session("SCodClientePesquisado")

            If Not String.IsNullOrEmpty(CodClientePesquisado) Then
                If alterouCodCliente > 0 Then
                    If TxtCodEmitente.Text <> CodClientePesquisado Then
                        TxtCodEmitente.Text = CodClientePesquisado
                        Call CodigoClienteMudou()
                    End If
                    Session("SAlterouCodCliente") = alterouCodCliente - 1
                End If
            End If

            If Not IsPostBack Then
                Dim neg = False
                Dim vis = False
                If Session("SCodNegociacao") IsNot Nothing AndAlso Session("SCodNegociacao") > 0 Then
                    neg = True
                End If
                If Session("SCodRoteiroVisita") IsNot Nothing AndAlso Session("SCodRoteiroVisita") > 0 Then
                    vis = True
                End If
                If neg OrElse vis Then
                    TagTitulo.Visible = False
                End If
                If vis Then
                    BtnVoltar.Visible = False
                End If
                Call CarregaVendedores()
                If Acao = "ALTERAR" Then
                    BtnGravar.Text = "Gravar alterações"
                    Call CarregaFormulario(neg, vis)
                ElseIf Acao = "INCLUIR" Then
                    BtnGravar.Text = "Incluir"
                    Call CarregaNovaPK()
                    Call CarregaDadosComplementares(neg, vis)
                    Session("SCodEmitente") = 0
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaDadosComplementares(ByVal neg As Boolean, ByVal vis As Boolean)
        Try
            If neg Then
                Dim ObjNegociacao As New UCLNegociacao(StrConexao)
                ObjNegociacao.Empresa = Session("GlEmpresa")
                ObjNegociacao.Estabelecimento = Session("GlEstabelecimento")
                ObjNegociacao.CodNegociacao = Session("SCodNegociacao")
                TxtData.Text = Now.ToString("dd/MM/yyyy")
                If ObjNegociacao.Buscar().Rows.Count > 0 Then
                    ddlRepresentante.SelectedValue = ObjNegociacao.CodRepresentante
                    TxtCodEmitente.Text = ObjNegociacao.CodCliente
                    Call CodigoClienteMudou()
                    DdlCNPJ.SelectedValue = ObjNegociacao.CNPJ
                    Call AlteraDisponibilidadeCamposCliente(TipoDisponibilidadeCliente.ClienteOriundoNegociacao)
                End If
            End If
            If vis Then
                Dim objRoteiroVisita As New UCLRoteiroVisita
                objRoteiroVisita.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"), Session("SCodRoteiroVisita"))
                ddlRepresentante.SelectedValue = objRoteiroVisita.GetConteudo("cod_representante")
                ddlRepresentante.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario(ByVal neg As Boolean, ByVal vis As Boolean)
        Try
            Dim ObjVisitacao As New UCLVisitacao
            LblSeqVisitacao.Text = Codigo

            If ObjVisitacao.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"), Codigo) Then
                ddlRepresentante.SelectedValue = ObjVisitacao.GetConteudo("cod_representante")
                TxtData.Text = ConverteDataDoBancoParaTela(ObjVisitacao.GetConteudo("data_visita"))
                TxtHora.Text = ObjVisitacao.GetConteudo("hora_visita")
                DdlSituacao.SelectedValue = ObjVisitacao.GetConteudo("situacao")
                TxtCodEmitente.Text = ObjVisitacao.GetConteudo("cod_emitente")
                Session("SCodEmitenteNegociacao") = TxtCodEmitente.Text
                Session("SCodEmitente") = TxtCodEmitente.Text
                Call CarregaCNPJ()
                DdlCNPJ.SelectedValue = ObjVisitacao.GetConteudo("cnpj")
                Session("SCNPJEmitente") = ObjVisitacao.GetConteudo("cnpj")
                TxtTitulo.Text = ObjVisitacao.GetConteudo("titulo")
                TxtNarrativa.Text = ObjVisitacao.GetConteudo("narrativa")
                TxtClienteGenerico.Text = ObjVisitacao.GetConteudo("cliente_generico")
                CbxIdClienteGenerico.Checked = (ObjVisitacao.GetConteudo("id_cliente_generico").ToString = "S")
                If ObjVisitacao.IsNull("cod_negociacao_cliente") Then
                    Call AlteraDisponibilidadeCamposCliente(IIf(CbxIdClienteGenerico.Checked, TipoDisponibilidadeCliente.ClienteGenerico, TipoDisponibilidadeCliente.ClienteNaoGenerico))
                Else
                    Call AlteraDisponibilidadeCamposCliente(TipoDisponibilidadeCliente.ClienteOriundoNegociacao)
                End If

                If Not String.IsNullOrWhiteSpace(TxtCodEmitente.Text) Then
                    Dim ObjEmitente As New UCLEmitente(StrConexao)
                    ObjEmitente.CodEmitente = TxtCodEmitente.Text
                    ObjEmitente.Buscar()
                    LblNomeCliente.Text = ObjEmitente.Nome
                End If

                If vis Then
                    ddlRepresentante.Enabled = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjVisitacao As New UCLVisitacao
        LblSeqVisitacao.Text = ObjVisitacao.GetProximoCodigo(Session("GlEmpresa"), Session("GlEstabelecimento"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjVisitacao As New UCLVisitacao
        Try
            If IsDigitacaoOk() Then
                ObjVisitacao.SetConteudo("empresa", Session("GlEmpresa"))
                ObjVisitacao.SetConteudo("estabelecimento", Session("GlEstabelecimento"))
                If Acao = "ALTERAR" Then
                    ObjVisitacao.SetConteudo("seq_visita", LblSeqVisitacao.Text)
                    ObjVisitacao = CarregaObjeto(ObjVisitacao)
                    ObjVisitacao.Alterar()
                    If Session("SCodRoteiroVisita") IsNot Nothing AndAlso Session("SCodRoteiroVisita") > 0 Then
                        LblErro.Text = "Dados alterados com sucesso."
                    Else
                        Response.Redirect(BackTo + "?d=" + Now.ToString("yyyyMMddHHmmssfff"))
                    End If
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjVisitacao.SetConteudo("seq_visita", LblSeqVisitacao.Text)
                    ObjVisitacao = CarregaObjeto(ObjVisitacao)
                    ObjVisitacao.Incluir()
                    If Session("SCodRoteiroVisita") IsNot Nothing AndAlso Session("SCodRoteiroVisita") > 0 Then
                        Session("SAcaoVisitacao") = "ALTERAR"
                        Session("SSeqVisita") = LblSeqVisitacao.Text
                        LblErro.Text = "Dados incluidos com sucesso."
                    Else
                        Response.Redirect(BackTo + "?d=" + Now.ToString("yyyyMMddHHmmssfff"))
                    End If

                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If ddlRepresentante.SelectedItem Is Nothing Then
            LblErro.Text += "Escolha o Representante.<br/>"
        ElseIf ddlRepresentante.SelectedValue = "0" Then
            LblErro.Text += "Escolha o Representante.<br/>"
        End If

        If String.IsNullOrEmpty(TxtData.Text) Then
            LblErro.Text += "Preencha o campo Data.<br/>"
        ElseIf Not isValidDate(TxtData.Text) Then
            LblErro.Text += "Preencha corretamente o campo Data.<br/>"
        End If

        If CbxIdClienteGenerico.Checked Then
            If String.IsNullOrEmpty(TxtClienteGenerico.Text) Then
                LblErro.Text += "Informe o nome do cliente não cadastrado.<br/>"
            End If
        Else
            If String.IsNullOrEmpty(TxtCodEmitente.Text) Then
                LblErro.Text += "Preencha o campo Cliente.<br/>"
            End If

            If DdlCNPJ.SelectedItem Is Nothing Then
                LblErro.Text += "Preencha o campo CNPJ.<br/>"
            End If
        End If


        If String.IsNullOrEmpty(TxtTitulo.Text) Then
            LblErro.Text += "Preencha o campo Assunto.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjVisitacao As UCLVisitacao) As UCLVisitacao
        ObjVisitacao.SetConteudo("cod_representante", ddlRepresentante.SelectedValue)
        ObjVisitacao.SetConteudo("data_visita", TxtData.Text)
        ObjVisitacao.SetConteudo("hora_visita", TxtHora.Text)
        ObjVisitacao.SetConteudo("situacao", DdlSituacao.SelectedValue)
        ObjVisitacao.SetConteudo("cod_emitente", TxtCodEmitente.Text)
        ObjVisitacao.SetConteudo("cnpj", DdlCNPJ.SelectedValue.ToString)
        ObjVisitacao.SetConteudo("titulo", TxtTitulo.Text)
        ObjVisitacao.SetConteudo("narrativa", TxtNarrativa.Text)
        ObjVisitacao.SetConteudo("cliente_generico", TxtClienteGenerico.Text)
        ObjVisitacao.SetConteudo("id_cliente_generico", CbxIdClienteGenerico.Checked.ToString.Replace("True", "S").Replace("False", "N"))
        If Session("SCodNegociacao") IsNot Nothing AndAlso Session("SCodNegociacao") > 0 Then
            ObjVisitacao.SetConteudo("cod_negociacao_cliente", Session("SCodNegociacao"))
        End If
        If Session("SCodRoteiroVisita") IsNot Nothing AndAlso Session("SCodRoteiroVisita") > 0 Then
            ObjVisitacao.SetConteudo("cod_roteiro_visita", Session("SCodRoteiroVisita"))
        End If
        Return ObjVisitacao
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect(BackTo + "?d=" + Now.ToString("yyyyMMddHHmmssfff"))
    End Sub

    Private Sub CarregaVendedores()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        objEmitente.FillDropDown(ddlRepresentante, True, "", UCLEmitente.TipoEmitenteDDL.Representante, 0, True, UCLEmitente.TipoExibicaoDDL.Nome, Session("GlCodGestor"))
        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
            ddlRepresentante.SelectedValue = Session("GlCodEmitenteExterno")
            ddlRepresentante.Enabled = False
        End If
    End Sub

    Protected Sub CodigoClienteMudou()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

        Call CarregaCNPJ()

        If Not String.IsNullOrWhiteSpace(TxtCodEmitente.Text) Then
            objEmitente.CodEmitente = TxtCodEmitente.Text
            objEmitente.Buscar()
            LblNomeCliente.Text = objEmitente.Nome
        Else
            LblNomeCliente.Text = ""
        End If

        Session("SCodEmitenteNegociacao") = TxtCodEmitente.Text
        Session("SCodClientePesquisado") = TxtCodEmitente.Text
        Session("SCodEmitente") = TxtCodEmitente.Text
    End Sub

    Private Sub CarregaCNPJ()
        Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
        If Not String.IsNullOrEmpty(TxtCodEmitente.Text) Then
            objEnderecoEmitente.CodEmitente = TxtCodEmitente.Text
            objEnderecoEmitente.FillDropDownCNPJ(DdlCNPJ)
        Else
            DdlCNPJ.Items.Clear()
        End If
    End Sub

    Protected Sub TxtCodEmitente_TextChanged(sender As Object, e As EventArgs) Handles TxtCodEmitente.TextChanged
        Call CodigoClienteMudou()
    End Sub

    Private Enum TipoDisponibilidadeCliente
        ClienteNaoGenerico = 0
        ClienteGenerico = 1
        ClienteOriundoNegociacao = 2
    End Enum

    Private Sub AlteraDisponibilidadeCamposCliente(ByVal tipo As TipoDisponibilidadeCliente)
        Try
            If tipo = TipoDisponibilidadeCliente.ClienteGenerico Then
                TxtClienteGenerico.Enabled = True
                TxtCodEmitente.Enabled = False
                BtnFiltrarCliente.Enabled = False
                BtnIncluirCliente.Enabled = False
                BtnAlterarCliente.Enabled = False
                DdlCNPJ.Enabled = False
            ElseIf tipo = TipoDisponibilidadeCliente.ClienteNaoGenerico Then
                TxtClienteGenerico.Enabled = False
                TxtCodEmitente.Enabled = True
                BtnFiltrarCliente.Enabled = True
                BtnIncluirCliente.Enabled = True
                BtnAlterarCliente.Enabled = True
                DdlCNPJ.Enabled = True
            ElseIf tipo = TipoDisponibilidadeCliente.ClienteOriundoNegociacao Then
                TxtCodEmitente.Enabled = False
                BtnFiltrarCliente.Enabled = False
                BtnIncluirCliente.Enabled = False
                BtnAlterarCliente.Enabled = False
                DdlCNPJ.Enabled = False
                LblLabelNome2.Visible = False
                CbxIdClienteGenerico.Visible = False
                LblLabelNome1.Visible = False
                TxtClienteGenerico.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CbxIdClienteGenerico_CheckedChanged(sender As Object, e As EventArgs) Handles CbxIdClienteGenerico.CheckedChanged
        Try
            If CType(sender, CheckBox).Checked Then
                Call AlteraDisponibilidadeCamposCliente(TipoDisponibilidadeCliente.ClienteGenerico)
                TxtCodEmitente.Text = ""
                DdlCNPJ.Items.Clear()
            Else
                Call AlteraDisponibilidadeCamposCliente(TipoDisponibilidadeCliente.ClienteNaoGenerico)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class