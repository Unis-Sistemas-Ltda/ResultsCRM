Public Class UCLBancoDadosVersao
    Private objAcessoDados As UCLAcessoDados

    Public Property Versao As String
    Public Property Descricao As String
    Public Property InicioVigencia As String
    Public Property TerminoVigencia As String
    Public Property Liberado As String
    Public Property CodBancoDados As String

    Public Sub Incluir()
        Dim strSql As String = ""
        Dim inivig As String
        Dim fimvig As String
        Try
            If IsDate(InicioVigencia) Then
                inivig = CDate(InicioVigencia).ToString("yyyyMMdd")
            Else
                inivig = "null"
            End If
            If IsDate(TerminoVigencia) Then
                fimvig = CDate(TerminoVigencia).ToString("yyyyMMdd")
            Else
                fimvig = "null"
            End If

            'strSql += " insert into banco_dados_versao (versao, descricao, inicio_vigencia, termino_vigencia, liberado, cod_banco_dados) "
            'strSql += " values ( " + Versao + ", '" + Descricao + "', " + inivig + ", " + fimvig + ", '" + Liberado + "', " + IIf(String.IsNullOrWhiteSpace(CodBancoDados), "null", CodBancoDados) + ")"
            strSql += " insert into versao_sistema (versao, descricao, inicio_vigencia, termino_vigencia, liberado) "
            strSql += " values ( " + Versao + ", '" + Descricao + "', " + inivig + ", " + fimvig + ", '" + Liberado + "' )"
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Dim inivig As String
        Dim fimvig As String
        Try
            If IsDate(InicioVigencia) Then
                inivig = CDate(InicioVigencia).ToString("yyyyMMdd")
            Else
                inivig = "null"
            End If
            If IsDate(TerminoVigencia) Then
                fimvig = CDate(TerminoVigencia).ToString("yyyyMMdd")
            Else
                fimvig = "null"
            End If

            'strSql += " update banco_dados_versao "
            strSql += " update versao_sistema "
            strSql += "    set descricao        = '" + Descricao + "', "
            strSql += "        inicio_vigencia  = " + inivig + ", "
            strSql += "        termino_vigencia = " + fimvig + ", "
            strSql += "        liberado         = '" + Liberado + "'"
            strSql += "  where versao = " + Versao
            'strSql += "    and cod_banco_dados  = " + CodBancoDados
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Dim strSql As String = ""
        Try
            'strSql += " delete from banco_dados_versao "
            strSql += " delete from versao_sistema "
            strSql += "  where versao  = " + Versao
            'strSql += "    and cod_banco_dados  = " + CodBancoDados
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Dim StrSql As String = ""
        Dim dt As DataTable

        StrSql += " select descricao, inicio_vigencia, termino_vigencia, liberado "
        'StrSql += "   from banco_dados_versao "
        StrSql += "   from versao_sistema "
        StrSql += "  where versao  = " + Versao
        'StrSql += "    and cod_banco_dados  = " + CodBancoDados
        dt = objAcessoDados.BuscarDados(StrSql)

        If dt.Rows.Count > 0 Then
            Descricao = dt.Rows.Item(0).Item("descricao").ToString
            Liberado = dt.Rows.Item(0).Item("liberado").ToString
            If IsDBNull(dt.Rows.Item(0).Item("inicio_vigencia")) Then
                InicioVigencia = ""
            Else
                InicioVigencia = CDate(dt.Rows.Item(0).Item("inicio_vigencia")).ToString("dd/MM/yyyy")
            End If
            If IsDBNull(dt.Rows.Item(0).Item("termino_vigencia")) Then
                TerminoVigencia = ""
            Else
                TerminoVigencia = CDate(dt.Rows.Item(0).Item("termino_vigencia")).ToString("dd/MM/yyyy")
            End If
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select versao, descricao, versao || ' ' || descricao cf_descricao "
        strSql += "   from versao_sistema "
        'strSql += "   from banco_dados_versao "
        'strSql += "  where cod_banco_dados = " + CodBancoDados
        strSql += "  order by versao desc "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("versao") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("descricao") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "cf_descricao"
        DDL.DataValueField = "versao"
        DDL.DataBind()
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        'Dim strSql = " select isnull(max(versao),0) + 1 max from banco_dados_versao where cod_banco_dados = " + CodBancoDados
        Dim strSql = " select isnull(max(versao),0) + 1 max from versao_sistema "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

End Class
