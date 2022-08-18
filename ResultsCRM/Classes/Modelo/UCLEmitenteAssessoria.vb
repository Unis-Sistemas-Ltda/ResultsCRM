Public Class UCLEmitenteAssessoria
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("emitente_assessoria")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pCodAssessoria As String, ByVal pCodFornecedor As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cod_assessoria", pCodAssessoria)
            Me.SetConteudo("cod_fornecedor", pCodFornecedor)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pCodAssessoria As String, ByVal pCodFornecedor As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cod_assessoria", pCodAssessoria)
            Me.SetConteudo("cod_fornecedor", pCodFornecedor)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overrides Sub Incluir()
        MyBase.Incluir()
        Call IncluirEtapa()
    End Sub

    Public Overrides Sub Alterar()
        Dim codEtapaAnterior As String = "0"
        Dim StrSql As String = "select cod_etapa from emitente_assessoria where empresa = " + Me.GetConteudo("empresa") + " and cod_emitente = " + Me.GetConteudo("cod_emitente") + " and cod_assessoria = " + Me.GetConteudo("cod_assessoria") + " and cod_fornecedor = " + Me.GetConteudo("cod_fornecedor")
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
        If dt.Rows.Count > 0 Then
            codEtapaAnterior = dt.Rows.Item(0).Item("cod_etapa").ToString
        End If

        MyBase.Alterar() 'Método ancestral

        If codEtapaAnterior <> Me.GetConteudo("cod_etapa") Then
            Call IncluirEtapa()
        End If
    End Sub

    Private Sub IncluirEtapa()
        Dim objEmitenteAssessoriaEtapa As New UCLEmitenteAssessoriaEtapa
        objEmitenteAssessoriaEtapa.SetConteudo("empresa", Me.GetConteudo("empresa"))
        objEmitenteAssessoriaEtapa.SetConteudo("cod_emitente", Me.GetConteudo("cod_emitente"))
        objEmitenteAssessoriaEtapa.SetConteudo("cod_assessoria", Me.GetConteudo("cod_assessoria"))
        objEmitenteAssessoriaEtapa.SetConteudo("cod_fornecedor", Me.GetConteudo("cod_fornecedor"))
        objEmitenteAssessoriaEtapa.SetConteudo("seq_etapa", objEmitenteAssessoriaEtapa.GetProximoCodigo(Me.GetConteudo("empresa"), Me.GetConteudo("cod_emitente"), Me.GetConteudo("cod_assessoria"), Me.GetConteudo("cod_fornecedor")))
        objEmitenteAssessoriaEtapa.SetConteudo("cod_etapa", Me.GetConteudo("cod_etapa"))
        objEmitenteAssessoriaEtapa.SetConteudo("cod_usuario_inclusao", Me.GetConteudo("cod_usuario_alteracao"))
        objEmitenteAssessoriaEtapa.SetConteudo("data_inclusao", Now().ToString("yyyy-MM-dd HH:mm:ss.fff"))
        objEmitenteAssessoriaEtapa.SetConteudo("cod_usuario_alteracao", Me.GetConteudo("cod_usuario_alteracao"))
        objEmitenteAssessoriaEtapa.SetConteudo("data_alteracao", Now().ToString("yyyy-MM-dd HH:mm:ss.fff"))
        objEmitenteAssessoriaEtapa.Incluir()
    End Sub

End Class
