Public Class UCLFAQ
    Private objAcessoDados As UCLAcessoDados

    Public Property CodFAQ() As String
    Public Property Pergunta() As String
    Public Property Resposta() As String
    Public Property Anexo() As String
    Public Property CodArea() As String
    Public Property Ativo() As String

    Public Sub New(ByVal strConexao As String)
        ObjAcessoDados = New UCLAcessoDados(strConexao)
    End Sub

    Public Sub Incluir()
        Dim strSql As String = ""
        Try
            If String.IsNullOrWhiteSpace(CodArea) Then
                CodArea = "null"
            End If
            strSql += "insert into faq (cod_faq, pergunta, resposta, anexo, cod_area, ativo) "
            strSql += " values( "
            strSql += CodFAQ + ", "
            strSql += "'" + Pergunta.Replace("'", "\'").Replace(Chr(34), "\" + Chr(34)) + "', "
            strSql += "'" + Resposta.Replace("'", "\'").Replace(Chr(34), "\" + Chr(34)) + "', "
            strSql += "'" + Anexo.Replace("'", "\'").Replace(Chr(34), "\" + Chr(34)) + "', "
            strSql += CodArea + ","
            strSql += "'" + Ativo + "')"

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar(ByVal pCodFAQ As String)
        CodFAQ = pCodFAQ
        Call Alterar()
    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""
        Try
            If String.IsNullOrWhiteSpace(CodArea) Then
                CodArea = "null"
            End If

            strSql += " update faq "
            strSql += "    set pergunta   = '" + Pergunta.Replace("'", "\'").Replace(Chr(34), "\" + Chr(34)) + "', "
            strSql += "        resposta   = '" + Resposta.Replace("'", "\'").Replace(Chr(34), "\" + Chr(34)) + "', "
            If Not String.IsNullOrWhiteSpace(Anexo) Then
                strSql += "    anexo      = '" + Anexo.Replace("'", "\'").Replace(Chr(34), "\" + Chr(34)) + "', "
            End If
            strSql += "        cod_area   = " + CodArea + ", "
            strSql += "        ativo      = '" + Ativo + "'"
            strSql += "  where cod_faq    = " + CodFAQ

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir(ByVal pCodFAQ As String)
        CodFAQ = pCodFAQ
        Call Excluir()
    End Sub

    Public Sub Excluir()
        Dim strSql As String = ""
        Try
            strSql += " delete from faq "
            strSql += "  where cod_faq    = " + CodFAQ
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Buscar()
        Dim strSql As String = ""
        Dim dt As DataTable
        Try
            strSql += " select * from faq "
            strSql += "  where cod_Faq          = " + CodFAQ

            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Pergunta = dt.Rows.Item(0).Item("pergunta").ToString.Replace("\'", "'").Replace("\" + Chr(34), Chr(34))
                Resposta = dt.Rows.Item(0).Item("resposta").ToString.Replace("\'", "'").Replace("\" + Chr(34), Chr(34))
                Anexo = dt.Rows.Item(0).Item("anexo").ToString
                CodArea = dt.Rows.Item(0).Item("cod_area").ToString
                Ativo = dt.Rows.Item(0).Item("ativo").ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim strSql As String = ""
        Dim dt As DataTable
        Dim Codigo As Long

        strSql += " select isnull(max(cod_faq), 0) + 1 as codigo "
        strSql += "   from faq "
        dt = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            Codigo = dt.Rows.Item(0).Item("codigo").ToString
        Else
            Codigo = 1
        End If

        Return Codigo
    End Function

    Public Sub SetFAQRotina(ByVal rotinas As List(Of UCLFAQRotina))
        Try
            For Each rotina As UCLFAQRotina In rotinas
                rotina.Incluir()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetFAQModulo(ByVal modulos As List(Of UCLFAQModulo))
        Try
            For Each modulo As UCLFAQModulo In modulos
                modulo.Incluir()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub LimpaFAQRotina()
        Try
            Dim StrSql As String = "delete from faq_rotina where cod_faq = " + CodFAQ
            objAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub LimpaFAQModulo()
        Try
            Dim StrSql As String = "delete from faq_modulo where cod_faq = " + CodFAQ
            objAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetFAQRotina() As List(Of UCLFAQRotina)
        Try
            Dim rotinas As New List(Of UCLFAQRotina)
            Dim ObjFAQRotina As UCLFAQRotina
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = " select cod_rotina "
            StrSql += "  from faq_rotina "
            StrSql += " where cod_faq = " + CodFAQ
            dt = ObjAcessoDados.BuscarDados(StrSql)

            For Each row As DataRow In dt.Rows
                ObjFAQRotina = New UCLFAQRotina
                ObjFAQRotina.SetConteudo("cod_faq", CodFAQ)
                ObjFAQRotina.SetConteudo("cod_rotina", row.Item("cod_rotina").ToString)
                rotinas.Add(ObjFAQRotina)
            Next

            Return rotinas
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetFAQModulo() As List(Of UCLFAQModulo)
        Try
            Dim modulos As New List(Of UCLFAQModulo)
            Dim ObjFAQModulo As UCLFAQModulo
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = " select cod_sistema, cod_modulo "
            StrSql += "  from faq_modulo "
            StrSql += " where cod_faq = " + CodFAQ
            dt = ObjAcessoDados.BuscarDados(StrSql)

            For Each row As DataRow In dt.Rows
                ObjFAQModulo = New UCLFAQModulo
                ObjFAQModulo.SetConteudo("cod_faq", CodFAQ)
                ObjFAQModulo.SetConteudo("cod_sistema", row.Item("cod_sistema").ToString)
                ObjFAQModulo.SetConteudo("cod_modulo", row.Item("cod_modulo").ToString)
                modulos.Add(ObjFAQModulo)
            Next

            Return modulos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class