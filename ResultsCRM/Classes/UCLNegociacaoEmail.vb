Public Class UCLNegociacaoEmail

    Private objAcessoDados As UCLAcessoDados

    Private _seq As String
    Private _dataEmail As String
    Private _DDataEmail As Date
    Private _HHoraEmail As String
    Private _de As String
    Private _remetente As String
    Private _para As String
    Private _destinatario As String
    Private _assunto As String
    Private _mensagem As String
    Private _anexo As String
    Private _enviado As String
    Private _DEnviado As Date
    Private _HEnviado As String
    Private _empresa As String
    Private _estabelecimento As String
    Private _codNegociacaoCliente As String
    Private _enviarAutomatico As String
    Private _enviadoAutomatico As String
    Private _dataEnvioAutomatico As String
    Private _DDataEnvioAutomatico As Date
    Private _HHoraEnvioAutomatico As String
    Private _destinatarioCC As String

    Public Property Seq() As String
        Get
            Return _seq
        End Get
        Set(ByVal value As String)
            _seq = value
        End Set
    End Property

    Public Property DataEmail() As String
        Get
            Return _dataEmail
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataEmail = value
            End If
            _dataEmail = value
        End Set
    End Property

    Public Property DDataEmail() As Date
        Get
            Return _DDataEmail
        End Get
        Set(ByVal value As Date)
            _DDataEmail = value
        End Set
    End Property

    Public Property HHoraEmail() As String
        Get
            Return _HHoraEmail
        End Get
        Set(ByVal value As String)
            _HHoraEmail = value
        End Set
    End Property

    Public Property De() As String
        Get
            Return _de
        End Get
        Set(ByVal value As String)
            _de = value
        End Set
    End Property

    Public Property Remetente() As String
        Get
            Return _remetente
        End Get
        Set(ByVal value As String)
            _remetente = value
        End Set
    End Property

    Public Property Para() As String
        Get
            Return _para
        End Get
        Set(ByVal value As String)
            _para = value
        End Set
    End Property

    Public Property Destinatario() As String
        Get
            Return _destinatario
        End Get
        Set(ByVal value As String)
            _destinatario = value
        End Set
    End Property

    Public Property Assunto() As String
        Get
            Return _assunto
        End Get
        Set(ByVal value As String)
            _assunto = value
        End Set
    End Property

    Public Property Mensagem() As String
        Get
            Return _mensagem
        End Get
        Set(ByVal value As String)
            _mensagem = value
        End Set
    End Property

    Public Property Anexo() As String
        Get
            Return _anexo
        End Get
        Set(ByVal value As String)
            _anexo = value
        End Set
    End Property

    Public Property Enviado() As String
        Get
            Return _enviado
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DEnviado = value
            End If
            _enviado = value
        End Set
    End Property

    Public Property DEnviado() As Date
        Get
            Return _DEnviado
        End Get
        Set(ByVal value As Date)
            _DEnviado = value
        End Set
    End Property

    Public Property HEnviado() As String
        Get
            Return _HEnviado
        End Get
        Set(ByVal value As String)
            _HEnviado = value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return _empresa
        End Get
        Set(ByVal value As String)
            _empresa = value
        End Set
    End Property

    Public Property Estabelecimento() As String
        Get
            Return _estabelecimento
        End Get
        Set(ByVal value As String)
            _estabelecimento = value
        End Set
    End Property

    Public Property CodNegociacaoCliente() As String
        Get
            Return _codNegociacaoCliente
        End Get
        Set(ByVal value As String)
            _codNegociacaoCliente = value
        End Set
    End Property

    Public Property EnviarAutomatico() As String
        Get
            Return _enviarAutomatico
        End Get
        Set(ByVal value As String)
            _enviarAutomatico = value
        End Set
    End Property

    Public Property EnviadoAutomatico() As String
        Get
            Return _enviadoAutomatico
        End Get
        Set(ByVal value As String)
            _enviadoAutomatico = value
        End Set
    End Property

    Public Property DestinatarioCC() As String
        Get
            Return _destinatarioCC
        End Get
        Set(ByVal value As String)
            _destinatarioCC = value
        End Set
    End Property

    Public Property DataEnvioAutomatico() As String
        Get
            Return _dataEnvioAutomatico
        End Get
        Set(ByVal value As String)
            If isValidDate(value) Then
                DDataEnvioAutomatico = value
            End If
            _dataEnvioAutomatico = value
        End Set
    End Property

    Public Property DDataEnvioAutomatico() As Date
        Get
            Return _DDataEnvioAutomatico
        End Get
        Set(ByVal value As Date)
            _DDataEnvioAutomatico = value
        End Set
    End Property

    Public Property HHoraEnvioAutomatico() As String
        Get
            Return _HHoraEnvioAutomatico
        End Get
        Set(ByVal value As String)
            _HHoraEnvioAutomatico = value
        End Set
    End Property

    Public Sub New(ByVal StrConn As String)
        objAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Sub Incluir()
        Try
            Dim strSql As String = ""
            strSql += "insert into negociacao_cliente_email(seq, data_email, de, remetente, para, destinatario, assunto, mensagem, anexo, enviado, empresa, estabelecimento, cod_negociacao_cliente, enviar_automatico, enviado_automatico, data_envio_automatico, destinatario_cc) "
            strSql += " values(" + Seq + ", "
            strSql += IIf(DDataEmail = Nothing, "null", "'" + DDataEmail.ToString("yyyy-MM-dd") + IIf(String.IsNullOrEmpty(HHoraEmail), "", " " + HHoraEmail + ":00") + "'") + ", "
            strSql += "'" + De + "', "
            strSql += "'" + Remetente + "', "
            strSql += "'" + Para + "', "
            strSql += "'" + Destinatario + "', "
            strSql += "'" + Assunto + "', "
            strSql += "'" + Mensagem + "', "
            strSql += IIf(String.IsNullOrEmpty(Anexo), "null", "'" + Anexo + "'") + ", "
            strSql += IIf(DEnviado = Nothing, "null", "'" + DEnviado.ToString("yyyy-MM-dd") + IIf(String.IsNullOrEmpty(HEnviado), "", " " + HEnviado + ":00") + "'") + ", "
            strSql += Empresa + ", "
            strSql += Estabelecimento + ", "
            strSql += IIf(String.IsNullOrEmpty(CodNegociacaoCliente), "null", CodNegociacaoCliente) + ", "
            strSql += IIf(String.IsNullOrEmpty(EnviarAutomatico), "null", "'" + EnviarAutomatico + "'") + ", "
            strSql += IIf(String.IsNullOrEmpty(EnviadoAutomatico), "null", "'" + EnviadoAutomatico + "'") + ", "
            strSql += IIf(DDataEnvioAutomatico = Nothing, "null", "'" + DDataEnvioAutomatico.ToString("yyyy-MM-dd") + IIf(String.IsNullOrEmpty(HHoraEnvioAutomatico), "", " " + HHoraEnvioAutomatico + ":00") + "'") + ", "
            strSql += "'" + DestinatarioCC + "')"
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim strSql As String = ""
            strSql += "update negociacao_cliente_email "
            strSql += "   set data_email             = " + IIf(DDataEmail = Nothing, "null", "'" + DDataEmail.ToString("yyyy-MM-dd") + IIf(String.IsNullOrEmpty(HHoraEmail), "", " " + HHoraEmail + ":00") + "'") + ", "
            strSql += "       de                     = '" + De + "', "
            strSql += "       remetente              = '" + Remetente + "', "
            strSql += "       para                   = '" + Para + "', "
            strSql += "       destinatario           = '" + Destinatario + "', "
            strSql += "       assunto                = '" + Assunto + "', "
            strSql += "       mensagem               = '" + Mensagem + "', "
            strSql += "       anexo                  = " + IIf(String.IsNullOrEmpty(Anexo), "null", "'" + Anexo + "'") + ", "
            strSql += "       enviado                = " + IIf(DEnviado = Nothing, "null", "'" + DEnviado.ToString("yyyy-MM-dd") + IIf(String.IsNullOrEmpty(HEnviado), "", " " + HEnviado + ":00") + "'") + ", "
            strSql += "       empresa                = " + Empresa + ", "
            strSql += "       estabelecimento        = " + Estabelecimento + ", "
            strSql += "       cod_negociacao_cliente = " + IIf(String.IsNullOrEmpty(CodNegociacaoCliente), "null", CodNegociacaoCliente) + ", "
            strSql += "       enviar_automatico      = " + IIf(String.IsNullOrEmpty(EnviarAutomatico), "null", "'" + EnviarAutomatico + "'") + ", "
            strSql += "       enviado_automatico     = " + IIf(String.IsNullOrEmpty(EnviadoAutomatico), "null", "'" + EnviadoAutomatico + "'") + ", "
            strSql += "       data_envio_automatico  = " + IIf(DDataEnvioAutomatico = Nothing, "null", "'" + DDataEnvioAutomatico.ToString("yyyy-MM-dd") + IIf(String.IsNullOrEmpty(HHoraEnvioAutomatico), "", " " + HHoraEnvioAutomatico + ":00") + "'") + ", "
            strSql += "       destinatario_cc        = '" + DestinatarioCC + "'"
            strSql += " where seq = " + Seq
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim strSql As String
            strSql = "delete from negociacao_cliente_email where seq = " + Seq
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim strSql As String
            Dim dt As DataTable

            strSql = " select * from negociacao_cliente_email where seq = " + Seq
            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                De = dt.Rows.Item(0).Item("de").ToString
                Remetente = dt.Rows.Item(0).Item("remetente").ToString
                Para = dt.Rows.Item(0).Item("para").ToString
                Destinatario = dt.Rows.Item(0).Item("destinatario").ToString
                DestinatarioCC = dt.Rows.Item(0).Item("destinatario_cc").ToString
                Assunto = dt.Rows.Item(0).Item("assunto").ToString
                Mensagem = dt.Rows.Item(0).Item("mensagem").ToString
                Anexo = dt.Rows.Item(0).Item("anexo").ToString
                Empresa = dt.Rows.Item(0).Item("empresa").ToString
                Estabelecimento = dt.Rows.Item(0).Item("estabelecimento").ToString
                CodNegociacaoCliente = dt.Rows.Item(0).Item("cod_negociacao_cliente").ToString
                EnviarAutomatico = dt.Rows.Item(0).Item("enviar_automatico").ToString
                EnviadoAutomatico = dt.Rows.Item(0).Item("enviado_automatico").ToString

                If Not IsDBNull(dt.Rows.Item(0).Item("data_email")) Then
                    DataEmail = CDate(dt.Rows.Item(0).Item("data_email")).ToString("dd/MM/yyyy")
                    DDataEmail = CDate(dt.Rows.Item(0).Item("data_email"))
                    HHoraEmail = CType(dt.Rows.Item(0).Item("data_email"), DateTime).ToString("HH:mm")
                Else
                    DataEmail = ""
                    DDataEmail = Nothing
                    HHoraEmail = ""
                End If

                If Not IsDBNull(dt.Rows.Item(0).Item("enviado")) Then
                    Enviado = CDate(dt.Rows.Item(0).Item("enviado")).ToString("dd/MM/yyyy")
                    DEnviado = CDate(dt.Rows.Item(0).Item("enviado"))
                    HEnviado = CType(dt.Rows.Item(0).Item("enviado"), DateTime).ToString("HH:mm")
                Else
                    Enviado = ""
                    DEnviado = Nothing
                    HEnviado = ""
                End If

                If Not IsDBNull(dt.Rows.Item(0).Item("data_envio_automatico")) Then
                    DataEnvioAutomatico = CDate(dt.Rows.Item(0).Item("data_envio_automatico")).ToString("dd/MM/yyyy")
                    DDataEnvioAutomatico = CDate(dt.Rows.Item(0).Item("data_envio_automatico"))
                    HHoraEnvioAutomatico = CType(dt.Rows.Item(0).Item("data_envio_automatico"), DateTime).ToString("HH:mm")
                Else
                    DataEnvioAutomatico = ""
                    DDataEnvioAutomatico = Nothing
                    HHoraEnvioAutomatico = ""
                End If

                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EnviaEmailsPendentes(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodNegociacaoCliente As String)
        Try
            Dim strSql As String
            strSql = " update negociacao_cliente_email "
            strSql += "   set enviado = getdate() "
            strSql += " where empresa                = " + pEmpresa
            strSql += "   and estabelecimento        = " + pEstabelecimento
            strSql += "   and cod_negociacao_cliente = " + pCodNegociacaoCliente
            strSql += "   and enviado           is null "
            strSql += "   and enviar_automatico = 'S'"
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(seq),0) + 1 max from negociacao_cliente_email "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
