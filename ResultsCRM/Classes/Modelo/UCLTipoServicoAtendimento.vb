Public Class UCLTipoServicoAtendimento
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("tipo_servico_atendimento")
    End Sub

    Public Function Buscar(ByVal pCodTipoServico As String) As Boolean
        Try
            Me.SetConteudo("cod_tipo_servico", pCodTipoServico)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodTipoServico As String)
        Try
            Me.SetConteudo("cod_tipo_servico", pCodTipoServico)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Try
            Dim StrSql As String = " select isnull(max(cod_tipo_servico),0) + 1 seq from tipo_servico_atendimento "
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("seq")
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLista() As List(Of UCLTipoServicoAtendimento)
        Try
            Dim servicos As New List(Of UCLTipoServicoAtendimento)
            Dim servico As UCLTipoServicoAtendimento
            Dim StrSql As String = "select cod_tipo_servico, descricao from tipo_servico_atendimento order by descricao "
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            For Each row As DataRow In dt.Rows
                servico = New UCLTipoServicoAtendimento
                servico.SetConteudo("cod_tipo_servico", row.Item("cod_tipo_servico"))
                servico.SetConteudo("descricao", row.Item("descricao"))
                servicos.Add(servico)
            Next
            Return servicos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
