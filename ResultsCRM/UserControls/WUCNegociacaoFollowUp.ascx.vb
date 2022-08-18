Public Partial Class WUCNegociacaoFollowUp
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _Empresa As String
    Private _Estabelecimento As String
    Private _CodNegociacao As String
    Private _SeqFollowUp As String
    Private _CodEmitente As String

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property Estabelecimento() As String
        Get
            Return _Estabelecimento
        End Get
        Set(ByVal value As String)
            _Estabelecimento = value
        End Set
    End Property

    Public Property CodNegociacao() As String
        Get
            Return _CodNegociacao
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property

    Public Property SeqFollowUp() As String
        Get
            Return _SeqFollowUp
        End Get
        Set(ByVal value As String)
            _SeqFollowUp = value
        End Set
    End Property

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
        End Set
    End Property

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CodContatoRetornado As String
        Dim recarregaContatos As Long
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))

        Call BuscaEmitente()

        If Not String.IsNullOrEmpty(Session("SRecarregaDdlContatos")) Then
            recarregaContatos = Session("SRecarregaDdlContatos")
        Else
            recarregaContatos = 0
        End If

        If Not IsPostBack Then
            Call CarregaDropDows()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            Else
                CarregaNovaPK()
            End If
        Else
            If recarregaContatos > 0 Then
                CodContatoRetornado = Session("SCodContatoNegociacao")
                Call CarregaContatos()
                If Not String.IsNullOrEmpty(CodContatoRetornado) Then
                    DdlContato.SelectedValue = CodContatoRetornado
                    Call ContatoSelecionadoMudou()
                End If
                Session("SRecarregaDdlContatos") = recarregaContatos - 1
            End If
        End If
    End Sub

    Private Sub CarregaDropDows()
        Call BuscaEmitente()
        Call CarregaContatos()
        Call CarregaAcao()
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjFollowUp As New UCLFollowUpEmitente(StrConexaoUsuario(Session("GlUsuario")))
        ObjFollowUp.Empresa = Empresa
        ObjFollowUp.Estabelecimento = Estabelecimento
        ObjFollowUp.CodNegociacaoCliente = CodNegociacao
        ObjFollowUp.SeqFollowUP = SeqFollowUp
        ObjFollowUp.BuscarPorNegociacao()

        DdlAcao.SelectedValue = ObjFollowUp.CodAcao
        TxtData.Text = CDate(ObjFollowUp.DataFollowUp).ToString("dd/MM/yyyy")
        TxtHora.Text = ObjFollowUp.HoraFollowUp
        DdlContato.SelectedValue = ObjFollowUp.CodContato
        Call ContatoSelecionadoMudou()
        TxtAssunto.Text = ObjFollowUp.Assunto
        TxtDescricao.Text = ObjFollowUp.Descricao
        LblSeq.Text = SeqFollowUp
        CbxEnviaEmail.Checked = (ObjFollowUp.EnviaEmail = "S")
        If Not String.IsNullOrEmpty(ObjFollowUp.DataRecontato) Then
            TxtDataRecontato.Text = ObjFollowUp.DDataRecontato.ToString("dd/MM/yyyy")
            TxtHoraRecontato.Text = ObjFollowUp.HoraRecontato
        End If
    End Sub

    Private Sub CarregaContatos()
        Dim objContato As New UCLContato
        If Not String.IsNullOrEmpty(CodEmitente) Then
            objContato.CodEmitente = CodEmitente
            objContato.FillDropDown(DdlContato, True, "", 0)
        End If
    End Sub

    Private Sub CarregaAcao()
        Dim objAcao As New UCLAcaoFollowUp
        objAcao.FillDropDown(DdlAcao, True, "")

    End Sub

    Private Sub BuscaEmitente()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))

        objNegociacao.Empresa = Empresa
        objNegociacao.Estabelecimento = Estabelecimento
        objNegociacao.CodNegociacao = CodNegociacao
        objNegociacao.Buscar()
        CodEmitente = objNegociacao.CodCliente

    End Sub

    Private Sub CarregaNovaPK()
        Dim objNegociacaoFollowUp As New UCLFollowUpEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim ObjNegociacao As New UCLNegociacao(StrConexao)

        ObjNegociacao.Empresa = Session("GlEmpresa")
        ObjNegociacao.Estabelecimento = Session("GlEstabelecimento")
        ObjNegociacao.CodNegociacao = CodNegociacao
        ObjNegociacao.Buscar()
        LblSeq.Text = objNegociacaoFollowUp.GetProximoCodigo(Session("GlEmpresa"), Session("GlEstabelecimento"), ObjNegociacao.CodCliente)

        TxtData.Text = Date.Now.ToString("dd/MM/yyyy")
        TxtHora.Text = DateTime.Now.ToString("HH:mm")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim objNegociacaoFollowUp As New UCLFollowUpEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Try
            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objNegociacaoFollowUp.CodNegociacaoCliente = CodNegociacao
                    objNegociacaoFollowUp.SeqFollowUP = SeqFollowUp
                    objNegociacaoFollowUp.Empresa = Session("GlEmpresa")
                    objNegociacaoFollowUp.Estabelecimento = Session("SEstabelecimentoNegociacao")
                    objNegociacaoFollowUp.BuscarPorNegociacao()
                    objNegociacaoFollowUp = CarregaObjetos(objNegociacaoFollowUp)
                    objNegociacaoFollowUp.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objNegociacaoFollowUp.CodNegociacaoCliente = CodNegociacao
                    objNegociacaoFollowUp.SeqFollowUP = LblSeq.Text
                    objNegociacaoFollowUp.Empresa = Session("GlEmpresa")
                    objNegociacaoFollowUp.Estabelecimento = Session("SEstabelecimentoNegociacao")
                    objNegociacaoFollowUp = CarregaObjetos(objNegociacaoFollowUp)
                    objNegociacaoFollowUp.Incluir()
                End If

                Call checaEnvioEmail()
                Response.Redirect("WGNegociacaoHistorico.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub ChecaEnvioEmail()
        Dim objAcao As New UCLAcaoFollowUp
        Dim objAgenteVenda As New UCLAgenteVendas
        Dim enviaEmail As String = objAcao.GetEnviaEmail(DdlAcao.SelectedValue)
        Dim objEmail As New UCLEmail
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Dim manterInformado As String

        If enviaEmail = "S" Then
            Try
                If Not String.IsNullOrEmpty(TxtDescricao.Text) Then
                    objNegociacao.Empresa = Session("GlEmpresa")
                    objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
                    objNegociacao.CodNegociacao = Session("SCodNegociacao")
                    objNegociacao.Buscar()

                    objAgenteVenda.Codigo = objNegociacao.CodAgenteVenda
                    objAgenteVenda.Buscar()
                    If objAgenteVenda.Email.IsValidEmail Then
                        manterInformado = objNegociacao.ManterInformado

                        If Not String.IsNullOrEmpty(manterInformado) Then
                            objEmail.envia_email(Session("GlEmpresa"), Session("GlSTMP"), objAgenteVenda.Email, manterInformado, TxtAssunto.Text, ImprimeTexto(TxtDescricao.Text), objAgenteVenda.Senha, Session("GlPortaEnvioEmail"), Session("GlUtilizaSSL"), "")
                        End If

                    Else
                        LblErro.Text = "Email não está parametrizado no cadastro do agente de vendas ou não é válido."
                    End If
                End If

            Catch ex As Exception
                LblErro.Text = ex.Message
            End Try
        End If

    End Sub

    Private Function CarregaObjetos(ByRef objNegociacaoFollowUp As UCLFollowUpEmitente)

        Call BuscaEmitente()

        objNegociacaoFollowUp.CodAcao = DdlAcao.SelectedValue
        objNegociacaoFollowUp.DataFollowUp = TxtData.Text
        objNegociacaoFollowUp.HoraFollowUp = TxtHora.Text

        If DdlContato.SelectedValue = "0" Then
            objNegociacaoFollowUp.CodContato = "null"
        Else
            objNegociacaoFollowUp.CodContato = DdlContato.SelectedValue
        End If

        objNegociacaoFollowUp.CodEmitente = CodEmitente
        objNegociacaoFollowUp.Assunto = TxtAssunto.Text
        objNegociacaoFollowUp.Descricao = TxtDescricao.Text.GetValidInputContent
        objNegociacaoFollowUp.Tipo = 2
        objNegociacaoFollowUp.CodUsuario = Session("GlCodUsuario")
        objNegociacaoFollowUp.EnviaEmail = IIf(CbxEnviaEmail.Checked, "S", "N")

        Dim dataHoraRecontato As String = ""

        If Not String.IsNullOrEmpty(TxtDataRecontato.Text) Then
            dataHoraRecontato = TxtDataRecontato.Text
            If Not String.IsNullOrEmpty(TxtHoraRecontato.Text) Then
                dataHoraRecontato += " " + TxtHoraRecontato.Text
            End If
        End If

        If Acao = "ALTERAR" Then
            If Not String.IsNullOrEmpty(dataHoraRecontato) Then
                If String.IsNullOrEmpty(objNegociacaoFollowUp.DataRecontato) Then
                    If CDate(TxtDataRecontato.Text) < Now.Date() Then
                        Throw New Exception("Data do recontato não pode ser retroativa.")
                    End If
                Else
                    If Convert.ToDateTime(dataHoraRecontato) <> Convert.ToDateTime(objNegociacaoFollowUp.DataRecontato) Then
                        If CDate(TxtDataRecontato.Text) < Now.Date() Then
                            Throw New Exception("Data do recontato não pode ser retroativa.")
                        End If
                    End If
                End If
            End If
        End If

        objNegociacaoFollowUp.DataRecontato = dataHoraRecontato

        Return objNegociacaoFollowUp
    End Function

    Private Function IsDigitacaoOK()
        Try
            Dim objParametrosVenda As New UCLParametrosVenda

            objParametrosVenda.Buscar(Session("GlEmpresa"))

            LblErro.Text = ""
            If objParametrosVenda.GetConteudo("exigir_acao_follow_up_negociacao_crm") = "S" Then
                If String.IsNullOrEmpty(DdlAcao.SelectedValue) OrElse DdlAcao.SelectedValue = "0" Then
                    LblErro.Text += "Preencha o campo Ação.<br/>"
                End If
            End If

            If Not IsDate(TxtData.Text) Then
                LblErro.Text += "Preencha o campo Data.<br/>"
            End If

            If String.IsNullOrEmpty(TxtHora.Text) Then
                LblErro.Text += "Preencha corretamente o campo Hora.<br/>"
            End If

            If String.IsNullOrEmpty(TxtAssunto.Text) Then
                LblErro.Text += "Preencha o campo Assunto.<br/>"
            End If

            If String.IsNullOrEmpty(TxtDescricao.Text) Then
                LblErro.Text += "Preencha corretamente campo Descrição.<br/>"
            End If

            Dim objNegociacao As New UCLNegociacao(StrConexao)

            Dim codEtapa As String
            codEtapa = objNegociacao.GetCodEtapa(Session("GlEmpresa"), Session("SEstabelecimentoNegociacao"), Session("SCodNegociacao"))
            codEtapa = IIf(String.IsNullOrEmpty(codEtapa), "0", codEtapa)

            Dim objEtapa As New UCLEtapaNegociacao
            objEtapa.Empresa = Session("GlEmpresa")
            objEtapa.Codigo = codEtapa
            If objEtapa.Buscar() Then
                If objEtapa.ExigirDataRecontato = "S" Then
                    If TxtDataRecontato.Text = "" Then
                        LblErro.Text += "Preencha o campo Data Recontato.<br/>"
                    ElseIf Not isValidDate(TxtDataRecontato.Text) Then
                        LblErro.Text += "Preencha corretamente o campo Data Recontato.<br/>"
                    Else
                        'If Acao = "INCLUIR" Then
                        If CDate(TxtDataRecontato.Text) < Now.Date() Then
                            LblErro.Text += "Data do recontato não pode ser retroativa.<br/>"
                        End If
                        'End If
                    End If
                End If
            End If

            Return LblErro.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub DdlContato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlContato.SelectedIndexChanged
        Call ContatoSelecionadoMudou()
    End Sub

    Private Sub ContatoSelecionadoMudou()
        Session("SCodContatoNegociacao") = DdlContato.SelectedValue
        Call CarregaInfoContato()
    End Sub

    Private Sub CarregaInfoContato()
        Dim objContato As New UCLContato
        If Not String.IsNullOrEmpty(CodEmitente) Then
            objContato.CodEmitente = CodEmitente
            objContato.Codigo = DdlContato.SelectedValue
            objContato.Buscar()
            LblEmail.Text = objContato.Email
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("WGNegociacaoHistorico.aspx")
    End Sub
End Class