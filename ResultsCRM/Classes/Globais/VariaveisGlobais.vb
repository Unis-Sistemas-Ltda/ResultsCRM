Imports System.IO
Imports System.Net

Module VariaveisGlobais
    Public __DsnEmail As String = "results"
    Public __Dsn As String = "results"
    'Public __Uid As String = "results"
    Public ReadOnly __Pwd As String = "results#01"

    'Para alterar o DirVirtual deve-se alterar no arquivo web.config, sessão appsettings, variável "caminho".
    'na variável acima, não se deve colocar barra (nem "/"  nem "\"), apenas o nome da pasta
    Public ReadOnly Property DirVirtual() As String
        Get
            Dim caminho As String = System.Configuration.ConfigurationManager.AppSettings("caminho")
            caminho = caminho.Trim
            If String.IsNullOrEmpty(caminho) Then
                Return ""
            Else
                Return caminho + "\"
            End If
        End Get
    End Property

    Public Sub CarregaFrame(ByRef frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.DataBind()
    End Sub

    Public ReadOnly Property DominioAnexoEmailRecebido As String
        Get
            Dim dominio As String = System.Configuration.ConfigurationManager.AppSettings("dominio_anexo_email_recebido")
            If dominio Is Nothing Then
                Return ""
            Else
                If String.IsNullOrEmpty(dominio) Then
                    Return ""
                Else
                    Return dominio
                End If
            End If
        End Get
    End Property

    Public ReadOnly Property DominioAnexoEmailEnviado As String
        Get
            Dim dominio As String = System.Configuration.ConfigurationManager.AppSettings("dominio_anexo_email_enviado")
            If dominio Is Nothing Then
                Return ""
            Else
                If String.IsNullOrEmpty(dominio) Then
                    Return ""
                Else
                    Return dominio
                End If
            End If
        End Get
    End Property

    Public ReadOnly Property DominioAnexoEmailNegociacao As String
        Get
            Dim dominio As String = System.Configuration.ConfigurationManager.AppSettings("dominio_anexo_email_negociacao")
            If dominio Is Nothing Then
                Return ""
            Else
                If String.IsNullOrEmpty(dominio) Then
                    Return ""
                Else
                    Return dominio
                End If
            End If
        End Get
    End Property

    Public ReadOnly Property DominioAnexoEmail As String
        Get
            Dim dominio As String = System.Configuration.ConfigurationManager.AppSettings("dominio_anexo_email")
            If dominio Is Nothing Then
                Return ""
            Else
                If String.IsNullOrEmpty(dominio) Then
                    Return ""
                Else
                    Return dominio
                End If
            End If
        End Get
    End Property

    Public Function DominioAnexoFollowUpChamado() As String
        Dim dominio As String = System.Configuration.ConfigurationManager.AppSettings("dominio_anexo_chamado")
        If dominio Is Nothing Then
            Return ""
        Else
            If String.IsNullOrEmpty(dominio) Then
                Return ""
            Else
                Return dominio
            End If
        End If
    End Function

    Public ReadOnly Property CaminhoFisicoAnexoChamado As String
        Get
            Dim dominio As String = System.Configuration.ConfigurationManager.AppSettings("caminho_fisico_anexo_chamado")
            If dominio Is Nothing Then
                Return ""
            Else
                If String.IsNullOrEmpty(dominio) Then
                    Return ""
                Else
                    Return dominio
                End If
            End If
        End Get
    End Property

    Public Function ValorNumericoBanco(ByVal StrNumero As String, ByVal Decimais As Integer) As String
        Dim retorno As String
        Dim numero As Double

        If StrNumero = "" Then
            'Se valor não estiver preenchido, retorne null
            retorno = "null"
        Else
            'Retira separadores de milhar
            StrNumero = StrNumero.Replace(".", "")
            If IsNumeric(StrNumero) Then
                numero = CDbl(StrNumero)
                'Dá o número de casas decimais necessário e converte para o formato do banco de dados
                retorno = numero.ToString("F" + Decimais.ToString)
                retorno = retorno.Replace(",", ".")
            Else
                retorno = "null"
            End If

        End If

        Return retorno
    End Function

    Public Function IsNull(ByVal valor1, ByVal valor2, Optional ByVal PadraoBancoDeDados = True)
        If TypeOf valor1 Is String Then
            If String.IsNullOrEmpty(valor1) Then
                If PadraoBancoDeDados Then
                    Return "'" + valor2.ToString + "'"
                Else
                    Return valor2.ToString
                End If
            Else
                If PadraoBancoDeDados Then
                    Return "'" + valor1.ToString + "'"
                Else
                    Return valor1.ToString
                End If
            End If
        Else
            If valor1 Is Nothing Then
                If TypeOf valor2 Is Double Or TypeOf valor2 Is Long Then
                    If PadraoBancoDeDados Then
                        Return valor2.ToString.Replace(",", ".")
                    Else
                        Return valor2
                    End If
                Else
                    Return valor2
                End If
            Else
                If TypeOf valor1 Is Double Or TypeOf valor1 Is Long Then
                    If PadraoBancoDeDados Then
                        Return valor1.ToString.Replace(",", ".")
                    Else
                        Return valor1
                    End If
                Else
                    Return valor1
                End If
            End If
        End If
    End Function

    'Public Sub SetUidBD(ByVal uid As String)
    '   __Uid = uid
    'End Sub

    Public Sub SetDsn(ByVal dsn As String)
        __Dsn = dsn
    End Sub

    Public Sub SetDsnEmail(ByVal dsn As String)
        __DsnEmail = dsn
    End Sub

    Public ReadOnly Property StrConexao() As String
        Get
            Return "Dsn=" & __Dsn & ";uid=resultscrm;pwd=results#01"
        End Get
    End Property

    Public ReadOnly Property StrConexaoEmail() As String
        Get
            Return "Dsn=" & __DsnEmail & ";uid=resultscrm;pwd=results#01"
        End Get
    End Property

    Public Function GetNomeIdentificacaoUsuario(ByVal CodUsuario As String) As String
        Try
            If String.IsNullOrWhiteSpace(CodUsuario) Then CodUsuario = 0
            Dim StrSql As String = "select nome_identificacao from sysusuario where cod_usuario = " + CodUsuario
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("nome_identificacao").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function StrConexaoUsuario(ByVal idUsuario As String) As String
        Return "Dsn=" & __Dsn & ";uid=" & idUsuario & ";pwd=results#01"
    End Function

    Public Sub SetaDsnAplicacao()
        Dim LDsn As String = System.Configuration.ConfigurationManager.AppSettings("dsn")
        LDsn = LDsn.Trim
        SetDsn(LDsn)
    End Sub

    Public Sub SetaDsnEmailAplicacao()
        Try
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)
            Dim dt As DataTable = objAcessoDados.BuscarDados("select first dsn_email from parametros_email where dsn_email is not null")
            Dim LDsn As String
            If dt.Rows.Count = 0 Then
                LDsn = __Dsn
            Else
                LDsn = dt.Rows.Item(0).Item("dsn_email").ToString
            End If
            LDsn = LDsn.Trim
            SetDsnEmail(LDsn)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetHtmlFromAspx(ByVal url As String) As String
        Dim contents As String = ""

        If url.Length > 6 Then
            'open 'http://' file
            If (url.Chars(0) = "h"c OrElse url.Chars(0) = "H"c) AndAlso _
               (url.Chars(1) = "t"c OrElse url.Chars(1) = "T"c) AndAlso _
               (url.Chars(2) = "t"c OrElse url.Chars(2) = "T"c) AndAlso _
               (url.Chars(3) = "p"c OrElse url.Chars(3) = "P"c) AndAlso _
               url.Chars(4) = ":"c AndAlso _
               url.Chars(5) = "/"c AndAlso _
               url.Chars(6) = "/"c Then

                Dim StreamHttp As Stream = Nothing
                Dim resp As WebResponse = Nothing
                Dim webrequest As HttpWebRequest = Nothing
                Try
                    webrequest = CType(HttpWebRequest.Create(url), HttpWebRequest)
                    resp = webrequest.GetResponse()
                    StreamHttp = resp.GetResponseStream()
                    Dim sr As New StreamReader(StreamHttp)
                    contents = sr.ReadToEnd()
                    Return contents
                Catch
                End Try
                'or open local file
            Else
                Try
                    Dim sr As New StreamReader(url)
                    contents = sr.ReadToEnd()
                    sr.Close()

                Catch
                End Try

            End If
        End If
        Return contents
    End Function

    Public Function ImprimeTexto(ByVal entrada As String) As String
        Dim saida As String

        saida = entrada.Replace(Chr(10), "<br>")
        saida = saida.Replace("[", "<")
        saida = saida.Replace("]", ">")

        Return saida
    End Function

    Public Enum TipoQuantidadeCalcular As Long
        QtdUD = 1
        QtdPedida = 2
    End Enum

    Public Function CalculaQuantidade_Unidade_UD(ByVal qtd_pedida As Double, ByVal qtd_ud As Double, ByVal tipo As TipoQuantidadeCalcular, ByVal item As String, ByVal referencia As String) As Double
        Dim ld_ud As Double
        Dim strSql As String
        Dim dt As DataTable
        Dim objAcessoDados As New UCLAcessoDados(StrConexao)
        Dim ld_conversao As Double
        Dim ld_qtd As Double
        Dim ld_consumo As Double

        If tipo = TipoQuantidadeCalcular.QtdPedida Then

            ld_conversao = 0
            ld_ud = qtd_ud

            strSql = "  Select u.fator_conversao from referencia r, unidade_despacho u where r.cod_referencia = '" + referencia + "' and u.cod_ud = r.cod_ud"
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("fator_conversao")) Then
                    ld_conversao = 0
                Else
                    ld_conversao = dt.Rows.Item(0).Item("fator_conversao")
                End If
            End If

            If ld_conversao = 0 Then
                strSql = " Select u.fator_conversao from item i, unidade_despacho u where i.cod_item = '" + item + "' and u.cod_ud = i.cod_ud"
                dt = objAcessoDados.BuscarDados(strSql)
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows.Item(0).Item("fator_conversao")) Then
                        ld_conversao = 0
                    Else
                        ld_conversao = dt.Rows.Item(0).Item("fator_conversao")
                    End If
                End If
            End If

            If ld_conversao = Nothing OrElse ld_conversao = 0 Then
                ld_conversao = 1
            End If

            ld_qtd = ld_ud * ld_conversao
            qtd_pedida = ld_qtd

        ElseIf tipo = TipoQuantidadeCalcular.QtdUD Then

            ld_conversao = 0
            ld_consumo = qtd_pedida

            strSql = "  Select u.fator_conversao from referencia r, unidade_despacho u where r.cod_referencia = '" + referencia + "' and u.cod_ud 	= r.cod_ud"
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("fator_conversao")) Then
                    ld_conversao = 0
                Else
                    ld_conversao = dt.Rows.Item(0).Item("fator_conversao")
                End If
            End If

            If ld_conversao = 0 Then
                strSql = " Select u.fator_conversao from item i, unidade_despacho u where i.cod_item = '" + item + "' and u.cod_ud 	= i.cod_ud"
                dt = objAcessoDados.BuscarDados(strSql)
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows.Item(0).Item("fator_conversao")) Then
                        ld_conversao = 0
                    Else
                        ld_conversao = dt.Rows.Item(0).Item("fator_conversao")
                    End If
                End If
            End If

            If ld_conversao = Nothing Or ld_conversao = 0 Then
                ld_conversao = 1
            End If

            ld_qtd = ld_consumo / ld_conversao
            qtd_ud = ld_qtd
        End If

        If tipo = TipoQuantidadeCalcular.QtdPedida Then
            Return qtd_pedida
        ElseIf tipo = TipoQuantidadeCalcular.QtdUD Then
            Return qtd_ud
        End If

    End Function

    Function F_DateAdd(ByVal data As Date, ByVal tipo As String, ByVal quantidade As Long, ByVal dutil As String) As Date
        Try
            Dim retorno As Date
            Dim idata As Date
            Dim inc As Long = 1
            Dim acrescentar As Long = 0
            Dim strSql As String
            Dim dt As DataTable
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)

            If quantidade < 0 Then
                inc = -1
            End If

            strSql = "select f_dateadd(" + data.ToString("yyyyMMdd") + ", 'd'," + quantidade.ToString + ") dt from dummy;"
            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                retorno = dt.Rows.Item(0).Item("dt")
            End If

            If dutil.ToUpper = "U" Then 'Último dia do prazo deve ser um dia últil
                While retorno.DayOfWeek = DayOfWeek.Sunday Or retorno.DayOfWeek = DayOfWeek.Saturday
                    strSql = "select f_dateadd(" + retorno.ToString("yyyyMMdd") + ", 'd'," + inc.ToString + ") dt from dummy;"
                    dt = objAcessoDados.BuscarDados(strSql)
                    If dt.Rows.Count > 0 Then
                        retorno = dt.Rows.Item(0).Item("dt")
                    Else
                        Exit While
                    End If
                End While
            ElseIf dutil.ToUpper = "S" Then 'Para cada dia não útil dentro do prazo, adicionar mais um dia útil
                idata = data
                While idata.DayOfWeek = DayOfWeek.Sunday Or idata.DayOfWeek = DayOfWeek.Saturday
                    idata = idata.AddDays(1)
                End While
                While True
                    If quantidade > 0 Then
                        If idata > retorno Then
                            Exit While
                        End If
                    Else
                        If idata < retorno Then
                            Exit While
                        End If
                    End If
                    If idata.DayOfWeek = DayOfWeek.Sunday Or idata.DayOfWeek = DayOfWeek.Saturday Then
                        acrescentar += (1 * inc)
                    End If
                    idata = idata.AddDays(inc)
                End While
                retorno = retorno.AddDays(acrescentar)
                retorno = F_DateAdd(retorno, tipo, 0, "u") 'Caso o término do prazo ocorra em um final de semana acrescentar dias até o mesmo coincidir com um dia útil
            End If

            Return retorno
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function PortaEnvioEmail(ByVal pEmpresa As String) As String
        Try
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim StrSql As String = "select porta_envio from parametros_email where empresa = " + pEmpresa
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("porta_envio").ToString()
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function UtilizaSSL(ByVal pEmpresa As String) As String
        Try
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim StrSql As String = "select utiliza_ssl from parametros_email where empresa = " + pEmpresa
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("utiliza_ssl").ToString()
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Enum ModoFormulario As Integer
        Inclusao = 1
        Consulta = 2
        ConsultaAlteracao = 3
        ConsultaAlteracaoExclusao = 4
        ConfirmaDados = 5
    End Enum

    Public Function ConverteDataDoBancoParaTela(ByVal strData As String) As String
        If strData Is Nothing Then
            Return ""
        ElseIf String.IsNullOrWhiteSpace(strData) Then
            Return ""
        ElseIf strData.Length < 10 Then
            Return ""
        Else
            strData = Left(strData, 10)
            strData = strData.Substring(8, 2) + "/" + strData.Substring(5, 2) + "/" + strData.Substring(0, 4)
        End If
        Return strData
    End Function

    Public Sub GravaLog(ByVal mensagem As String)
        Try
            Dim fwriter As IO.StreamWriter
            Dim fname As String
            Dim datahora As DateTime
            Dim x86 As Boolean = False
            Dim emIngles As Boolean = False

            If Directory.Exists("C:\Program Files (x86)") Then
                x86 = True
                emIngles = True
            Else
                If Directory.Exists("C:\Arquivos de Programas (x86)") Then
                    x86 = True
                    emIngles = False
                Else
                    If Directory.Exists("C:\Program Files") Then
                        x86 = False
                        emIngles = True
                    Else
                        x86 = False
                        emIngles = False
                    End If
                End If
            End If

            If emIngles Then
                fname = "C:\Program Files"
            Else
                fname = "C:\Arquivos de Programas"
            End If
            If x86 Then
                fname += " (x86)"
            End If
            fname += "\Unis"
            If Not Directory.Exists(fname) Then
                Directory.CreateDirectory(fname)
            End If

            fname += "\log_resultscrm"
            If Not Directory.Exists(fname) Then
                Directory.CreateDirectory(fname)
            End If
            fname += "\" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt"
            fname += ".txt"

            datahora = System.DateTime.Now

            fwriter = New IO.StreamWriter(fname, True)
            fwriter.WriteLine(datahora.ToString("dd/MM/yyyy HH:mm:ss") + mensagem + Chr(13) + Chr(10))
            fwriter.Flush()
            fwriter.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Function ClienteDoMesmoEstado(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodEmitente As String, ByVal pCNPJ As String) As Boolean
        Try
            Dim ret As Boolean = False
            Dim objEstabelecimento As New UCLEstabelecimento
            Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexao)

            objEstabelecimento.CodEmpresa = pEmpresa
            objEstabelecimento.Estabelecimento = pEstabelecimento
            If objEstabelecimento.Buscar() Then
                objEnderecoEmitente.CodEmitente = pCodEmitente
                objEnderecoEmitente.CNPJ = pCNPJ
                If objEnderecoEmitente.Buscar() Then
                    If objEnderecoEmitente.CodPais = objEstabelecimento.CodPais AndAlso objEnderecoEmitente.CodEstado = objEstabelecimento.CodEstado Then
                        ret = True
                    End If
                Else
                    Throw New Exception("Cliente/CNPJ não cadastrado. Cliente: " + pCodEmitente + " / CNPJ: " + pCNPJ)
                End If
            Else
                Throw New Exception("Estabelecimento não cadastrado. Empresa: " + pEmpresa + " / Estabelecimento: " + pEstabelecimento)
            End If

            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDistanciaPontoAtendimento(ByVal pCodEmitente As String, ByVal pNumeroPontoAtendimento As String) As Double
        Try
            Dim Ret As Double
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim StrSql As String = " select isnull(f_busca_distancia_ponto_atendimento(" + pCodEmitente + ",'" + pNumeroPontoAtendimento + "'),0) distancia from dummy"
            Dim Dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If Dt.Rows.Count > 0 Then
                Ret = Dt.Rows.Item(0).Item("distancia")
            Else
                Return 0
            End If
            Return Ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTabelaIcmsCfop(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pItem As String, ByVal pCNPJ As String, ByVal pCFOPAnterior As String) As String
        Try
            Dim Ret As String = ""
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim StrSql As String = " select isnull(f_tabela_icms_cfop(" + pEmpresa + ", " + pEstabelecimento + ", '" + pItem + "', '" + pCNPJ + "','" + pCFOPAnterior + "'),'') ret from dummy"
            Dim Dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If Dt.Rows.Count > 0 Then
                Ret = Dt.Rows.Item(0).Item("ret").ToString()
            Else
                Return ""
            End If
            Return Ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function UseDefaultCredentials(pEmpresa As String) As String
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable
            Dim objAcessoDados As New UCLAcessoDados

            StrSql += " select isnull(use_default_credentials,'N') as use_default_credentials "
            StrSql += "   from parametros_email "
            StrSql += "  where empresa = " + pEmpresa

            dt = objAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                If dt.Rows.Item(0).Item("use_default_credentials") = "S" Then
                    Return "True"
                Else
                    Return "False"
                End If
            Else
                Return "False"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'ls_cfop = u

End Module
