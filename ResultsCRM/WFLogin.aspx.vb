Public Partial Class WFLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim usuario, senha As String
            Call SetaDsnAplicacao()
            Call SetaDsnEmailAplicacao()

            usuario = Session("SUsuarioConexao")
            senha = Session("SSenhaConexao")

            If Not String.IsNullOrEmpty(usuario) And Not String.IsNullOrEmpty(senha) Then
                TxtUsuario.Text = usuario
                TxtSenha.Text = senha
                Call Conectar()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub Conectar()
        Try
            Dim Usuario As String
            Dim Senha As String
            Dim Erro As Boolean = False
            Dim objUsuario As New UCLUsuario()
            Dim objAgenteVenda As New UCLAgenteVendas

            Usuario = TxtUsuario.Text
            Senha = TxtSenha.Text

            LblErro.Text = ""

            If Usuario = "" Then
                LblErro.Text += "Preencha o campo Usuário.<br/>"
                Erro = True
            End If

            If Senha = "" Then
                LblErro.Text += "Preencha o campo Senha.<br/>"
                Erro = True
            End If

            Call objUsuario.AutorizarUsuariosAcessarBD()

            If Not Erro Then
                objUsuario.Usuario = Usuario
                If Not objUsuario.Buscar() Then 'Não encontrou
                    LblErro.Text += "Usuário não cadastrado.<br/>"
                    Erro = True
                Else
                    If Senha <> objUsuario.Senha Then
                        LblErro.Text += "Senha não confere.<br/>"
                        Erro = True
                    Else
                        Select Case objUsuario.Situacao
                            Case UCLUsuario.SituacaoUsuario.Bloqueado
                                LblErro.Text += "Usuário bloqueado. Solicite ao responsável que verifique o cadastro do usuário no Results.<br/>"
                                Erro = True
                            Case UCLUsuario.SituacaoUsuario.Cancelado
                                LblErro.Text += "Usuário cancelado. Solicite ao responsável que verifique o cadastro do usuário no Results.<br/>"
                                Erro = True
                        End Select
                        Session("GlTipoAcesso") = CInt(objUsuario.GetTipoAcesso(objUsuario.CodUsuario))
                        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.SemAcesso Then
                            LblErro.Text += "Usuário sem permissão de acesso. É necessário cadastrar agente de vendas ou analista no Results.<br/>"
                            Erro = True
                        End If
                    End If
                End If

                If Not Erro Then
                    Call CarregaVariaveisGlobais(objUsuario.CodUsuario, Usuario, objUsuario.NomeUsuario, objUsuario.EmpresaPadrao, objUsuario.EstabelecimentoPadrao, Senha, objUsuario.CodGrupoExterno, objUsuario.Situacao, objUsuario.CodEmitenteExterno)
                    Session("GlAgenteVendaMaster") = objAgenteVenda.GetMaster(objUsuario.CodUsuario)
                    FormsAuthentication.RedirectFromLoginPage(TxtUsuario.Text, False)

                    'Altera usuário corrente para conexão no banco de dados
                    'SetUidBD(Usuario)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnConectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConectar.Click
        Try
            Call Conectar()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaVariaveisGlobais(ByVal Codusuario As String, ByVal Usuario As String, ByVal NomeUsuario As String, ByVal Empresa As String, ByVal Estabelecimento As String, ByVal senha As String, ByVal codGrupoExterno As String, ByVal idSituacao As String, ByVal CodEmitenteExterno As String)
        Try
            Dim objEmpresa As New UCLEmpresa()
            Dim objParametrosFaturamento As New UCLParametrosFaturamento
            Dim objParametrosVenda As New UCLParametrosVenda
            Dim ObjParametrosCRM As New UCLParametrosCRM

            objEmpresa.CodEmpresa = Empresa
            objEmpresa.Buscar()

            objParametrosFaturamento.Empresa = Empresa
            objParametrosFaturamento.Estabelecimento = Estabelecimento
            objParametrosFaturamento.Buscar()

            If String.IsNullOrWhiteSpace(CodEmitenteExterno) Then
                CodEmitenteExterno = -1
            End If

            ObjParametrosCRM.Empresa = Empresa
            ObjParametrosCRM.Buscar()

            objParametrosVenda.Buscar(Empresa)

            Dim objGestorConta As New UCLGestorConta
            objGestorConta.CodUsuario = Codusuario
            If objGestorConta.BuscarPorCodUsuario() Then
                Session("GlCodGestor") = Codusuario
                Session("GlIsGestor") = "S"
            Else
                Session("GlCodGestor") = 0
                Session("GlIsGestor") = "N"
            End If

            Session("GlCodUsuario") = Codusuario
            Session("GlUsuario") = Usuario
            Session("GlCodEmitenteExterno") = CodEmitenteExterno
            Session("GlCodGrupoExterno") = codGrupoExterno
            Session("GlIdSituacao") = idSituacao
            Session("GlEmpresa") = Empresa
            Session("GlRazaoSocial") = objEmpresa.RazaoSocial
            Session("GlEstabelecimento") = Estabelecimento
            Session("GlNomeUsuario") = NomeUsuario
            Session("GlSenhaUsuario") = senha
            Session("GlClienteUnis") = objEmpresa.CodClienteUnis
            Session("GlTipoFaturamento") = objParametrosFaturamento.Segmento
            If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
                Session("GlBloquearCadastroEmitenteRepresentante") = ObjParametrosCRM.BloquearCadastroEmitenteRepresentante
            Else
                Session("GlBloquearCadastroEmitenteRepresentante") = "N"
            End If
            Session("GlRestricaoAcessoAgenteVenda") = objParametrosVenda.GetConteudo("restricao_acesso_agente_venda")
            Call CarregaInfoEnvioEmail(objEmpresa.CodEmpresa)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaInfoEnvioEmail(ByVal empresa As String)
        Try
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)
            Dim strSql As String = "select smtp, utiliza_ssl ssl, porta_envio from parametros_email where empresa = " + empresa
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows.Item(0).Item("ssl")) Then
                    Session("GlUtilizaSSL") = dt.Rows.Item(0).Item("ssl").ToString
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("porta_envio")) Then
                    Session("GlPortaEnvioEmail") = dt.Rows.Item(0).Item("porta_envio").ToString
                End If
                If Not IsDBNull(dt.Rows.Item(0).Item("smtp")) Then
                    Session("GlSTMP") = dt.Rows.Item(0).Item("smtp").ToString
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class