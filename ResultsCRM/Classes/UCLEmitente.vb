Public Class UCLEmitente

    Private _CodEmitente As String
    Private _Nome As String
    Private _TpPessoa As String
    Private _NomeAbreviado As String
    Private _Situacao As String
    Private _Tipo As String
    Private _Procedencia As String
    Private _Natureza As String
    Private _Funcionario As String
    Private _Transportador As String
    Private _Representante As String
    Private _Licenciador As String
    Private _OptantePeloSimples As String
    Private _DataCadastramento As String
    Private _DDataCadastramento As Date
    Private _UsuarioCadastramento As String
    Private _DataAlteracao As String
    Private _DDataAlteracao As Date
    Private _DataRecadastramento As String
    Private _DDataRecadastramento As Date
    Private _DataReativacao As String
    Private _DDataReativacao As Date
    Private _DataPendDoc As String
    Private _DDataPendDoc As Date
    Private _UsuarioAlteracao As String
    Private _TitulosEmAberto As Long
    Private _DiasInadimplente As Long
    Private _CnpjPreferencial As String
    Private _CnpjCobranca As String
    Private _CodEmitentePF As String
    Private _Associado As String
    Private objAcessoDados As UCLAcessoDados
    Private _ConfirmacaoEncerramentoOS As String
    Private _Cliente As String
    Private _Fornecedor As String
    Private _Distribuidor As String
    Private _CodRedeAssociativa As String
    Private _CodProprietario As String
    Private _CodFranquia As String
    Private _CodPessoaFisica As String


    Public Property ExigeFotoOS As String

    Public Enum TipoEmitenteDDL
        Cliente = 1
        Fornecedor = 2
        Representante = 3
        ProvedorTEF = 4
        AdquirenteTEF = 5
        Parceiro = 6
        Distribuidor = 7
    End Enum

    Public Enum TipoExibicaoDDL
        Nome = 1
        NomeAbreviado = 2
    End Enum

    Public Property ConfirmacaoEncerramentoOS As String
        Get
            If String.IsNullOrEmpty(_ConfirmacaoEncerramentoOS) Then
                _ConfirmacaoEncerramentoOS = "N"
            End If
            Return _ConfirmacaoEncerramentoOS
        End Get
        Set(value As String)
            _ConfirmacaoEncerramentoOS = value
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

    Public Property CodEmitentePF() As String
        Get
            Return _CodEmitentePF
        End Get
        Set(ByVal value As String)
            _CodEmitentePF = value
        End Set
    End Property

    Public Property Associado As String
        Get
            Return _Associado
        End Get
        Set(ByVal value As String)
            _Associado = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return _Nome
        End Get
        Set(ByVal value As String)
            _Nome = value
        End Set
    End Property

    Public Property TpPessoa() As String
        Get
            Return _TpPessoa
        End Get
        Set(ByVal value As String)
            _TpPessoa = value
        End Set
    End Property

    Public Property NomeAbreviado() As String
        Get
            Return _NomeAbreviado
        End Get
        Set(ByVal value As String)
            _NomeAbreviado = value
        End Set
    End Property

    Public Property Situacao() As String
        Get

            Return _Situacao
        End Get
        Set(ByVal value As String)
            _Situacao = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Public Property Procedencia() As String
        Get
            Return _Procedencia
        End Get
        Set(ByVal value As String)
            _Procedencia = value
        End Set
    End Property

    Public Property Natureza() As String
        Get
            Return _Natureza
        End Get
        Set(ByVal value As String)
            _Natureza = value
        End Set
    End Property

    Public Property Funcionario() As String
        Get
            If String.IsNullOrEmpty(_Funcionario) Then
                _Funcionario = "N"
            End If
            Return _Funcionario
        End Get
        Set(ByVal value As String)
            _Funcionario = value
        End Set
    End Property

    Public Property Transportador() As String
        Get
            If String.IsNullOrEmpty(_Transportador) Then
                _Transportador = "N"
            End If
            Return _Transportador
        End Get
        Set(ByVal value As String)
            _Transportador = value
        End Set
    End Property

    Public Property Representante() As String
        Get
            If String.IsNullOrEmpty(_Representante) Then
                _Representante = "N"
            End If
            Return _Representante
        End Get
        Set(ByVal value As String)
            _Representante = value
        End Set
    End Property

    Public Property Licenciador() As String
        Get
            If String.IsNullOrEmpty(_Licenciador) Then
                _Licenciador = "N"
            End If
            Return _Licenciador
        End Get
        Set(ByVal value As String)
            _Licenciador = value
        End Set
    End Property

    Public Property OptantePeloSimples() As String
        Get
            If String.IsNullOrEmpty(_OptantePeloSimples) Then
                _OptantePeloSimples = "N"
            End If
            Return _OptantePeloSimples
        End Get
        Set(ByVal value As String)
            _OptantePeloSimples = value
        End Set
    End Property

    Public Property DataCadastramento() As String
        Get
            If DDataCadastramento <> Nothing Then
                Return DDataCadastramento.ToString("dd/MM/yyyy")
            End If
            Return _DataCadastramento
        End Get
        Set(ByVal value As String)
            If IsDate(_DataCadastramento) Then
                DDataCadastramento = CDate(_DataCadastramento)
            End If
            _DataCadastramento = value
        End Set
    End Property

    Public Property DDataCadastramento() As Date
        Get
            Return _DDataCadastramento
        End Get
        Set(ByVal value As Date)
            _DDataCadastramento = value
        End Set
    End Property

    Public Property UsuarioCadastramento() As String
        Get
            Return _UsuarioCadastramento
        End Get
        Set(ByVal value As String)
            _UsuarioCadastramento = value
        End Set
    End Property

    Public Property DataAlteracao() As String
        Get
            If DDataAlteracao <> Nothing Then
                Return DDataAlteracao.ToString("dd/MM/yyyy")
            End If
            Return _DataAlteracao
        End Get
        Set(ByVal value As String)
            If IsDate(_DataAlteracao) Then
                DDataAlteracao = CDate(_DataAlteracao)
            End If
            _DataAlteracao = value
        End Set
    End Property

    Public Property DDataAlteracao() As Date
        Get
            Return _DDataAlteracao
        End Get
        Set(ByVal value As Date)
            _DDataAlteracao = value
        End Set
    End Property

    Public Property DataReativacao() As String
        Get
            If DDataReativacao <> Nothing Then
                Return DDataReativacao.ToString("dd/MM/yyyy")
            End If
            Return _DataReativacao
        End Get
        Set(ByVal value As String)
            If IsDate(_DataReativacao) Then
                DDataReativacao = CDate(_DataReativacao)
            End If
            _DataReativacao = value
        End Set
    End Property

    Public Property DDataReativacao() As Date
        Get
            Return _DDataReativacao
        End Get
        Set(ByVal value As Date)
            _DDataReativacao = value
        End Set
    End Property

    Public Property DataPendDoc() As String
        Get
            If DDataPendDoc <> Nothing Then
                Return DDataPendDoc.ToString("dd/MM/yyyy")
            End If
            Return _DataPendDoc
        End Get
        Set(ByVal value As String)
            If IsDate(_DataPendDoc) Then
                DDataPendDoc = CDate(_DataPendDoc)
            End If
            _DataPendDoc = value
        End Set
    End Property

    Public Property DDataPendDoc() As Date
        Get
            Return _DDataPendDoc
        End Get
        Set(ByVal value As Date)
            _DDataPendDoc = value
        End Set
    End Property

    Public Property DataRecadastramento() As String
        Get
            If DDataRecadastramento <> Nothing Then
                Return DDataRecadastramento.ToString("dd/MM/yyyy")
            End If
            Return _DataRecadastramento
        End Get
        Set(ByVal value As String)
            If IsDate(_DataRecadastramento) Then
                DDataRecadastramento = CDate(_DataRecadastramento)
            End If
            _DataRecadastramento = value
        End Set
    End Property

    Public Property DDataRecadastramento() As Date
        Get
            Return _DataRecadastramento
        End Get
        Set(ByVal value As Date)
            _DDataRecadastramento = value
        End Set
    End Property

    Public Property UsuarioAlteracao() As String
        Get
            Return _UsuarioAlteracao
        End Get
        Set(ByVal value As String)
            _UsuarioAlteracao = value
        End Set
    End Property

    Public Property CNPJPreferencial() As String
        Get
            Return _CnpjPreferencial
        End Get
        Set(ByVal value As String)
            _CnpjPreferencial = value
        End Set
    End Property

    Public Property CNPJCobranca() As String
        Get
            Return _CnpjCobranca
        End Get
        Set(ByVal value As String)
            _CnpjCobranca = value
        End Set
    End Property

    Public Property Cliente() As String
        Get
            If String.IsNullOrEmpty(_Funcionario) Then
                _Cliente = "N"
            End If
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property

    Public Property Fornecedor() As String
        Get
            If String.IsNullOrEmpty(_Funcionario) Then
                _Fornecedor = "N"
            End If
            Return _Fornecedor
        End Get
        Set(ByVal value As String)
            _Fornecedor = value
        End Set
    End Property

    Public Property Distribuidor() As String
        Get
            If String.IsNullOrEmpty(_Funcionario) Then
                _Distribuidor = "N"
            End If
            Return _Distribuidor
        End Get
        Set(ByVal value As String)
            _Distribuidor = value
        End Set
    End Property

    Public Property CodRedeAssociativa() As String
        Get
            Return _CodRedeAssociativa
        End Get
        Set(ByVal value As String)
            _CodRedeAssociativa = value
        End Set
    End Property

    Public Property CodProprietario() As String
        Get
            Return _CodProprietario
        End Get
        Set(ByVal value As String)
            _CodProprietario = value
        End Set
    End Property

    Public Property CodFranquia() As String
        Get
            Return _CodFranquia
        End Get
        Set(ByVal value As String)
            _CodFranquia = value
        End Set
    End Property

    Public Property CodPessoaFisica() As String
        Get
            Return _CodPessoaFisica
        End Get
        Set(ByVal value As String)
            _CodPessoaFisica = value
        End Set
    End Property

    Public Sub New(ByVal StrConn As String)
        objAcessoDados = New UCLAcessoDados(StrConn)
    End Sub

    Public Function Buscar() As DataTable
        Dim strSql As String
        Dim dt As DataTable

        strSql = " select isnull(nome,'') nome, isnull(associado,'N') associado, cod_emitente_pf, "
        strSql += "       isnull(nome_abreviado,'') nome_abreviado, "
        strSql += "       isnull(tp_pessoa,'') tp_pessoa, "
        strSql += "       isnull(tipo,'') tipo, "
        strSql += "       isnull(situacao,1) situacao, "
        strSql += "       isnull(procedencia,'') procedencia, "
        strSql += "       cod_usuario_cadastramento cod_usuario_cadastramento, "
        strSql += "       cod_usuario_alteracao cod_usuario_alteracao, "
        strSql += "       isnull(data_cadastramento,'1900-01-01') data_cadastramento, "
        strSql += "       isnull(data_alteracao,'1900-01-01') data_alteracao, "
        strSql += "       isnull(data_recadastramento,'1900-01-01') data_recadastramento, "
        strSql += "       isnull(data_reativacao,'1900-01-01') data_reativacao, "
        strSql += "       isnull(data_pendencia_documental,'1900-01-01') data_pendencia_documental, "
        strSql += "       isnull(representante,'N') representante,  "
        strSql += "       isnull(natureza_emitente,'') natureza_emitente, "
        strSql += "       isnull(licenciador,'N') licenciador, "
        strSql += "       isnull(funcionario,'N') funcionario, "
        strSql += "       isnull(transportador,'N') transportador, "
        strSql += "       isnull(optante_pelo_simples,'N') optante_pelo_simples, "
        strSql += "       isnull(exige_foto_os,'N') exige_foto_os, "
        strSql += "       isnull(confirmacao_encerramento_os,'N') confirmacao_encerramento_os, "
        strSql += "       isnull(cliente,'N') cliente, "
        strSql += "       isnull(fornecedor,'N') fornecedor, "
        strSql += "       isnull(distribuidor,'N') distribuidor, "
        strSql += "       cod_rede_associativa cod_rede_associativa,"
        strSql += "       cod_emitente_proprietario cod_emitente_proprietario,"
        strSql += "       cod_emitente_franquia cod_emitente_franquia,"
        strSql += "       cod_emitente_pf cod_emitente_pf"
        strSql += "  from emitente "
        strSql += " where cod_emitente = " + CodEmitente

        dt = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            Nome = dt.Rows.Item(0).Item("nome").ToString
            NomeAbreviado = dt.Rows.Item(0).Item("nome_abreviado").ToString
            CodEmitentePF = dt.Rows.Item(0).Item("cod_emitente_pf").ToString
            TpPessoa = dt.Rows.Item(0).Item("tp_pessoa").ToString
            Situacao = dt.Rows.Item(0).Item("situacao").ToString
            Tipo = dt.Rows.Item(0).Item("tipo").ToString
            Procedencia = dt.Rows.Item(0).Item("procedencia").ToString
            ExigeFotoOS = dt.Rows.Item(0).Item("exige_foto_os").ToString
            ConfirmacaoEncerramentoOS = dt.Rows.Item(0).Item("confirmacao_encerramento_os").ToString
            If Not IsDBNull(dt.Rows.Item(0).Item("cod_usuario_cadastramento")) Then
                UsuarioCadastramento = dt.Rows.Item(0).Item("cod_usuario_cadastramento").ToString
            Else
                UsuarioCadastramento = 1
            End If
            If Not IsDBNull(dt.Rows.Item(0).Item("cod_usuario_alteracao")) Then
                UsuarioAlteracao = dt.Rows.Item(0).Item("cod_usuario_alteracao").ToString
            Else
                UsuarioAlteracao = 1
            End If
            DataCadastramento = dt.Rows.Item(0).Item("data_cadastramento")
            DataAlteracao = dt.Rows.Item(0).Item("data_alteracao")
            DataRecadastramento = dt.Rows.Item(0).Item("data_recadastramento")
            DataReativacao = dt.Rows.Item(0).Item("data_reativacao")
            DataPendDoc = dt.Rows.Item(0).Item("data_pendencia_documental")
            Representante = dt.Rows.Item(0).Item("representante").ToString
            Natureza = dt.Rows.Item(0).Item("natureza_emitente").ToString
            Licenciador = dt.Rows.Item(0).Item("licenciador").ToString
            Funcionario = dt.Rows.Item(0).Item("funcionario").ToString
            Transportador = dt.Rows.Item(0).Item("transportador").ToString
            Cliente = dt.Rows.Item(0).Item("cliente").ToString
            Fornecedor = dt.Rows.Item(0).Item("fornecedor").ToString
            Distribuidor = dt.Rows.Item(0).Item("distribuidor").ToString
            CodRedeAssociativa = dt.Rows.Item(0).Item("cod_rede_associativa").ToString
            CodProprietario = dt.Rows.Item(0).Item("cod_emitente_proprietario").ToString
            CodFranquia = dt.Rows.Item(0).Item("cod_emitente_franquia").ToString
            CodPessoaFisica = dt.Rows.Item(0).Item("cod_emitente_pf").ToString
            OptantePeloSimples = dt.Rows.Item(0).Item("optante_pelo_simples").ToString
            Associado = dt.Rows.Item(0).Item("associado").ToString

            CNPJPreferencial = GetCNPJ(Me.CodEmitente, TipoCNPJ.Preferencial)
            If String.IsNullOrEmpty(CNPJPreferencial) Then
                CNPJPreferencial = GetCNPJ(Me.CodEmitente, TipoCNPJ.PrimeiroCadastrado)
            End If

            CNPJCobranca = GetCNPJ(Me.CodEmitente, TipoCNPJ.Cobranca)
            If String.IsNullOrEmpty(CNPJCobranca) Then
                CNPJCobranca = CNPJPreferencial
            End If

        End If

        Return dt
    End Function

    Public Enum TipoCNPJ As Integer
        Preferencial = 1
        Cobranca = 2
        PrimeiroCadastrado = 3
    End Enum

    Public Function GetCNPJ(ByVal emitente As String, ByVal tipo As TipoCNPJ) As String
        Try
            Dim cnpj As String
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = "  select first cnpj "
            StrSql += "   from endereco_emitente "
            StrSql += " where cod_emitente = " + emitente

            If tipo = TipoCNPJ.Cobranca Then
                StrSql += "  and isnull(cobranca,'N') = 'S' "
            ElseIf tipo = TipoCNPJ.Preferencial Then
                StrSql += "  and isnull(preferencial,'N') = 'S' "
            End If

            StrSql += "  order by cnpj"
            dt = objAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count = 0 Then
                cnpj = ""
            Else
                cnpj = dt.Rows.Item(0).Item("cnpj").ToString
            End If

            Return cnpj
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTipoPessoa(ByVal emitente As String) As String
        Try
            Dim tipoPessoa As String
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = "  select first tp_pessoa "
            StrSql += "   from emitente "
            StrSql += " where cod_emitente = " + emitente

            dt = objAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count = 0 Then
                tipoPessoa = ""
            Else
                tipoPessoa = dt.Rows.Item(0).Item("tp_pessoa").ToString
            End If

            Return tipoPessoa
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into emitente( cod_emitente, "
            strSql += "       nome, "
            strSql += "       nome_abreviado, "
            strSql += "       tp_pessoa, "
            strSql += "       tipo, "
            strSql += "       situacao, "
            strSql += "       procedencia, "
            strSql += "       cod_usuario_cadastramento, "
            strSql += "       cod_usuario_alteracao, "
            strSql += "       data_cadastramento, "
            strSql += "       data_alteracao, "
            strSql += "       auxiliar1, "
            strSql += "       representante, "
            strSql += "       natureza_emitente, "
            strSql += "       licenciador, "
            strSql += "       funcionario, "
            strSql += "       transportador, "
            strSql += "       exige_foto_os, "
            strSql += "       confirmacao_encerramento_os, "
            strSql += "       cod_rede_associativa, "
            strSql += "       cod_emitente_proprietario, "
            strSql += "       cod_emitente_franquia, "
            strSql += "       cod_emitente_pf, "
            strSql += "       optante_pelo_simples) "
            strSql += " values("
            strSql += CodEmitente + ", "
            strSql += "'" + Nome + "', "
            strSql += "'" + NomeAbreviado + "', "
            strSql += "'" + TpPessoa + "', "
            strSql += "'" + Tipo + "', "
            strSql += "'" + Situacao + "', "
            strSql += "'" + Procedencia + "', "
            strSql += "f_busca_cod_usuario(current user), "
            strSql += "f_busca_cod_usuario(current user), "
            strSql += "getDate(), "
            strSql += "getDate(), "
            strSql += "0, "
            strSql += "'" + Representante + "', "
            strSql += "'" + Natureza + "', "
            strSql += "'" + Licenciador + "', "
            strSql += "'" + Funcionario + "', "
            strSql += "'" + Transportador + "', "
            strSql += "'" + ExigeFotoOS + "', "
            strSql += "'" + ConfirmacaoEncerramentoOS + "', "
            strSql += "" + CodRedeAssociativa + ", "
            strSql += "" + CodProprietario + ", "
            strSql += "" + CodFranquia + ", "
            strSql += "" + CodPessoaFisica + ", "
            strSql += "'" + OptantePeloSimples + "')"
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update emitente"
            strSql += "    set nome                 = '" + Nome + "', "
            strSql += "        nome_abreviado       = '" + NomeAbreviado + "', "
            strSql += "        tp_pessoa            = '" + TpPessoa + "', "
            strSql += "        tipo                 = '" + Tipo + "', "
            strSql += "        situacao             = '" + Situacao + "', "
            strSql += "        procedencia          = '" + Procedencia + "', "
            strSql += "        confirmacao_encerramento_os = '" + ConfirmacaoEncerramentoOS + "', "
            'strSql += "        cod_usuario_cadastramento = " + UsuarioCadastramento + ", "
            'strSql += "        cod_usuario_alteracao = " + UsuarioAlteracao + ", "
            'If DDataCadastramento <> Nothing Then
            'strSql += "    data_cadastramento   = '" + DDataCadastramento.ToString("yyyy-MM-dd") + "', "
            'Else
            'strSql += "    data_cadastramento   = null, "
            'End If
            'If DDataAlteracao <> Nothing Then
            'strSql += "    data_alteracao       = '" + DDataAlteracao.ToString("yyyy-MM-dd") + "', "
            'Else
            'strSql += "    data_alteracao       = null, "
            'End If
            strSql += "        representante            = '" + Representante + "', "
            strSql += "        exige_foto_os            = '" + ExigeFotoOS + "', "
            strSql += "        natureza_emitente        = '" + Natureza + "', "
            strSql += "        licenciador              = '" + Licenciador + "', "
            strSql += "        funcionario              = '" + Funcionario + "', "
            strSql += "        transportador            = '" + Transportador + "', "
            strSql += "        cliente                  = '" + Cliente + "', "
            strSql += "        fornecedor               = '" + Fornecedor + "', "
            strSql += "        distribuidor             = '" + Distribuidor + "', "
            strSql += "        cod_rede_associativa     = " + CodRedeAssociativa + ", "
            strSql += "        cod_emitente_proprietario = " + CodProprietario + ", "
            strSql += "        cod_emitente_franquia    = " + CodFranquia + ", "
            strSql += "        cod_emitente_pf          = " + CodPessoaFisica + ", "
            strSql += "        optante_pelo_simples     = '" + OptantePeloSimples + "'"
            strSql += "  where cod_emitente         = " + CodEmitente
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String
            StrSql = " delete from emitente where cod_emitente = " + CodEmitente
            objAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetPessoaJuridica() As Long
        Try
            Dim strSql As String = " select isnull(cod_emitente,0) cod_emitente from emitente where cod_emitente_pf = " + IIf(String.IsNullOrEmpty(CodEmitente), "0", CodEmitente)
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("cod_emitente")
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_emitente),0) + 1 max from emitente "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal TipoEmitenteAFiltrar As TipoEmitenteDDL, ByVal CodEmitente As String, ByVal MostrarInativos As Boolean, ByVal TipoExibicao As TipoExibicaoDDL, ByVal CodUsuarioDoGestor As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_emitente, nome || ' (' || cod_emitente || ')' nome, nome_abreviado || ' (' || cod_emitente || ')' nome_abreviado "
        strSql += "   from emitente "
        Select Case TipoEmitenteAFiltrar
            Case TipoEmitenteDDL.Representante
                strSql += "  where representante = 'S' "
            Case TipoEmitenteDDL.Cliente
                strSql += "  where tipo in (2,3) "
            Case TipoEmitenteDDL.Fornecedor
                strSql += "  where tipo in (1,2) "
            Case TipoEmitenteDDL.AdquirenteTEF
                strSql += "  where isnull(adquirente_principal_tef,'N') = 'S' "
            Case TipoEmitenteDDL.ProvedorTEF
                strSql += "  where isnull(provedor_tef,'N') = 'S' "
            Case TipoEmitenteDDL.Parceiro
                strSql += "  where isnull(parceiro,'N') = 'S' "
            Case TipoEmitenteDDL.Distribuidor
                strSql += "  where isnull(distribuidor,'N') = 'S' "
        End Select
        If Not MostrarInativos Then
            strSql += " and ( situacao = 2 or cod_emitente = " + CodEmitente + " )"
        End If
        If TipoEmitenteAFiltrar = TipoEmitenteDDL.Representante AndAlso Not String.IsNullOrEmpty(CodUsuarioDoGestor) AndAlso IsNumeric(CodUsuarioDoGestor) AndAlso CodUsuarioDoGestor > 0 Then
            strSql += " and exists(select 1 from gestor_conta_representante gcr inner join gestor_conta gc on gc.cod_gestor = gcr.cod_gestor where gc.cod_usuario = " + CodUsuarioDoGestor + " and gcr.cod_representante = emitente.cod_emitente)"
        End If
        strSql += "  order by nome "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_emitente") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            NovaLinha("nome_abreviado") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        If TipoExibicao = TipoExibicaoDDL.Nome Then
            DDL.DataTextField = "nome"
        ElseIf TipoExibicao = TipoExibicaoDDL.NomeAbreviado Then
            DDL.DataTextField = "nome_abreviado"
        End If

        DDL.DataValueField = "cod_emitente"
        DDL.DataBind()

    End Sub

    Public Function TitulosEmAbertoVencidos(ByVal empresa As String)
        Try
            Dim StrSql As String = ""
            Dim qtd As Long
            Dim dt As DataTable

            StrSql += "	select count(*) qtd"
            StrSql += "	  from titulo_cr inner join especie_documento_cr es on  es.cod_especie = titulo_cr.cod_especie and es.empresa = titulo_cr.empresa "
            StrSql += "	 where titulo_cr.empresa         = " + empresa
            StrSql += "	   and titulo_cr.cod_emitente    = " + CodEmitente
            StrSql += "	   and titulo_cr.data_vencimento < today()"
            StrSql += "	   and titulo_cr.valor_saldo	 > 0"
            StrSql += "    and titulo_cr.sit_saldo 		 = 1"
            StrSql += "    and ((es.tipo = 3 and titulo_cr.situacao <> 4) or es.tipo <> 3 )"
            dt = objAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                qtd = dt.Rows.Item(0).Item("qtd")
            Else
                qtd = 0
            End If

            Return qtd

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetSolicitarNumeroSerialTerceiroOS(ByVal codEmitente As String) As String
        Try
            Dim StrSql As String = "select isnull(solicitar_numero_serial_terceiro_os,'N') solicitar_numero_serial_terceiro_os from emitente where cod_emitente = " + codEmitente
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("solicitar_numero_serial_terceiro_os").ToString()
            Else
                Return "N"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DiasInadimplente(ByVal empresa As String)
        Try
            Dim StrSql As String = ""
            Dim dias As Long
            Dim dt As DataTable

            StrSql += "	 select isnull(f_titulo_cr_consulta(0," + empresa + "," + CodEmitente + "),0) dias "
            StrSql += "	   from dummy;"
            dt = objAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                dias = dt.Rows.Item(0).Item("dias")
            Else
                dias = 0
            End If

            Return dias
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTelefone(ByVal CodEmitente As String) As String
        Try
            Dim strSql As String = "select telefone from endereco_emitente where preferencial = 'S' and cod_emitente = " + CodEmitente
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("telefone").ToString
            End If
            Return ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTelefone2(ByVal CodEmitente As String) As String
        Try
            Dim strSql As String = "select telefone2 from endereco_emitente where preferencial = 'S' and cod_emitente = " + CodEmitente
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("telefone2").ToString
            End If
            Return ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetEmail(ByVal CodEmitente As String) As String
        Try
            Dim strSql As String = "select contato_email from v_emitente_endereco where preferencial = 'S' and cod_emitente = " + CodEmitente
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("contato_email").ToString
            End If
            Return ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetRazaoSocial(ByVal CodEmitente As String) As String
        Dim razao As String = ""
        Dim strSql As String
        Dim dt As DataTable

        Try
            strSql = "select nome from emitente where cod_emitente = " + CodEmitente
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                razao = dt.Rows.Item(0).Item("nome").ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return razao

    End Function

    Public Sub IncluirEnderecoEmitente(ByVal cod_emitente As String, ByVal preferencial As String, ByVal cnpj As String, ByVal insc_estadual As String, ByVal insc_unicipal As String, ByVal endereco As String, ByVal numero As String, ByVal complemento As String, ByVal pais As String, ByVal estado As String, ByVal cidade As String, ByVal cep As String, ByVal telefone1 As String, ByVal telefone2 As String, ByVal fax As String, ByVal af As String, ByVal ae As String, ByVal NumFuncMatriz As String, ByVal RespTecnico As String, ByVal CpfRespTecnico As String, ByVal CrfRespTecnico As String, ByVal EstadoCrf As String, ByVal OrgaoExpeditor As String, ByVal Email As String, ByVal EmailXmlNfe As String, ByVal EmailBoleto As String)
        Dim nome As String = "(select first nome from emitente where cod_emitente = " + cod_emitente + ")"
        Dim nome_abreviado As String = "(select first nome_abreviado from emitente where cod_emitente = " + cod_emitente + ")"
        IncluirEnderecoEmitente(cod_emitente, nome, nome_abreviado, preferencial, cnpj, insc_estadual, insc_unicipal, endereco, numero, complemento, pais, estado, cidade, cep, telefone1, telefone2, fax, af, ae, NumFuncMatriz, RespTecnico, CpfRespTecnico, CrfRespTecnico, EstadoCrf, OrgaoExpeditor, Email, EmailXmlNfe, EmailBoleto)
    End Sub

    Public Sub IncluirEnderecoEmitente(ByVal cod_emitente As String, ByVal nome As String, ByVal nome_abreviado As String, ByVal preferencial As String, ByVal cnpj As String, ByVal insc_estadual As String, ByVal insc_unicipal As String, ByVal endereco As String, ByVal numero As String, ByVal complemento As String, ByVal pais As String, ByVal estado As String, ByVal cidade As String, ByVal cep As String, ByVal telefone1 As String, ByVal telefone2 As String, ByVal fax As String, ByVal af As String, ByVal ae As String, ByVal NumFuncMatriz As String, ByVal RespTecnico As String, ByVal CpfRespTecnico As String, ByVal CrfRespTecnico As String, ByVal EstadoCrf As String, ByVal OrgaoExpeditor As String, ByVal Email As String, ByVal EmailXmlNfe As String, ByVal EmailBoleto As String)
        cnpj = cnpj.Trim
        Dim strSql As String = "insert into endereco_emitente (cod_emitente,cnpj,nome,nome_abreviado,preferencial,endereco,numero,complemento,cod_pais,cod_estado,cod_cidade,cod_bairro,cep,email,email_xml_nfe,contato_boleto,insc_municipal,insc_estadual,telefone2,telefone,fax,cobranca,numero_funcionario,autorizacao_funcionamento,autorizacao_especial,nome_responsavel_tecnico,cpf_responsavel_tecnico,id_profissional,cod_estado_id_profissional,orgao_exp) values(" & cod_emitente & "," & cnpj & "," & nome & "," & nome_abreviado & "," & preferencial & "," & endereco & "," & numero & "," & complemento & "," & pais & "," & estado & "," & cidade & ", null, " & cep & ",'" & Email & "','" & EmailXmlNfe & "','" & EmailBoleto & "'," & insc_unicipal & "," & insc_estadual & "," & telefone2 & "," & telefone1 & "," & IIf(fax = "?", "null", fax) & "," & "'N' ," & NumFuncMatriz & "," & af & "," & ae & "," & RespTecnico & "," & CpfRespTecnico & "," & CrfRespTecnico & "," & EstadoCrf & "," & OrgaoExpeditor & ")"
        Try
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub IncluirEnderecoEmitente(ByVal cod_emitente As String, ByVal nome As String, ByVal preferencial As String, ByVal cnpj As String, ByVal endereco As String, ByVal pais As String, ByVal estado As String, ByVal cidade As String, ByVal cep As String, ByVal telefone1 As String, ByVal telefone2 As String, ByVal fax As String)
        Dim strSql As String
        cnpj = cnpj.Trim
        strSql = "if not exists(select 1 from endereco_emitente where cod_emitente = " + cod_emitente + " and cnpj = " + cnpj + ") then "
        strSql += "insert into endereco_emitente (cod_emitente,cnpj,nome,preferencial,endereco,cod_pais,cod_estado,cod_cidade,cod_bairro,cep,telefone2,telefone,fax,cobranca,ativo) values(" & cod_emitente & "," & cnpj & "," & nome & "," & preferencial & "," & endereco & "," & pais & "," & estado & "," & cidade & ",null," & cep & "," & telefone2 & "," & telefone1 & "," & fax & "," & "'N','S' ) end if"
        Try
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub atualiza_endereco_emitente(ByVal cod_emitente As String, ByVal preferencial As String, ByVal cnpj As String, ByVal insc_estadual As String, ByVal insc_unicipal As String, ByVal endereco As String, ByVal numero As String, ByVal complemento As String, ByVal pais As String, ByVal estado As String, ByVal cidade As String, ByVal cep As String, ByVal telefone1 As String, ByVal telefone2 As String, ByVal fax As String, ByVal af As String, ByVal ae As String, ByVal NumFuncMatriz As String, ByVal RespTecnico As String, ByVal CpfRespTecnico As String, ByVal CrfRespTecnico As String, ByVal EstadoCrf As String, ByVal OrgaoExpeditor As String, ByVal Email As String, ByVal EmailXmlNfe As String, ByVal EmailBoleto As String)
        Dim strSql As String = ""

        Try
            endereco = endereco.Replace("'", "")
            complemento = complemento.Replace("'", "")
            If preferencial.ToString.Replace("'", "").Trim = "" Then preferencial = "preferencial"

            strSql += "update endereco_emitente "
            strSql += "   set preferencial = " & preferencial & ","
            strSql += "       endereco =  '" & endereco & "',"
            strSql += "       numero =  " & numero & ","
            strSql += "       complemento =  '" & complemento & "',"
            strSql += "       cod_pais = " & pais & ","
            strSql += "       cod_estado = " & estado & ","
            strSql += "       cod_cidade = '" & cidade & "',"
            strSql += "       email = '" & Email.Replace("'", "") & "',"
            strSql += "       email_xml_nfe = '" & EmailXmlNfe.Replace("'", "") & "',"
            strSql += "       contato_boleto = '" & EmailBoleto.Replace("'", "") & "',"
            strSql += "       cod_bairro = null,"
            strSql += "       cep = '" & cep & "',"
            strSql += "       insc_municipal = '" & insc_unicipal & "',"
            strSql += "       insc_estadual = '" & insc_estadual & "',"
            strSql += "       telefone2 = " & telefone2 & ","
            strSql += "       telefone = " & telefone1 & ","
            strSql += "       fax = " & IIf(fax = "?", "fax", fax) & ","
            strSql += "       cobranca = 'N', "
            strSql += "       ativo = 'S', "
            strSql += "       numero_funcionario = " & NumFuncMatriz & ","
            strSql += "       autorizacao_funcionamento = " & af & ","
            strSql += "       autorizacao_especial = " & ae & ","
            strSql += "       nome_responsavel_tecnico = " & RespTecnico & ","
            strSql += "       cpf_responsavel_tecnico = " & CpfRespTecnico & ","
            strSql += "       id_profissional = " & CrfRespTecnico & ","
            strSql += "       cod_estado_id_profissional = " & EstadoCrf & ","
            strSql += "       orgao_exp = " & OrgaoExpeditor
            strSql += " where cod_emitente = " & cod_emitente
            strSql += "   and trim(cnpj) = " & cnpj

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function BuscaEnderecoEmitente(ByVal cod_emitente As String, ByVal cnpj As String) As DataTable
        Dim strSql As String = " SELECT * FROM endereco_emitente ee WHERE ee.cod_emitente = " + cod_emitente + " and trim(ee.cnpj) = " + cnpj
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        Return dt
    End Function

End Class