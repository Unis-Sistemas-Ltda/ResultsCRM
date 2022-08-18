Public Class UCLEmitenteTEFLojaBandeira
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("emitente_tef_loja_bandeira")
    End Sub

    Public Function Buscar(ByVal pCodEmitente As String, ByVal pCNPJ As String, ByVal pCodAdquirente As String, ByVal pCodBandeira As String) As Boolean
        Try
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cnpj", pCNPJ)
            Me.SetConteudo("cod_adquirente", pCodAdquirente)
            Me.SetConteudo("cod_bandeira", pCodBandeira)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodEmitente As String, ByVal pCNPJ As String, ByVal pCodAdquirente As String, ByVal pCodBandeira As String)
        Try
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Me.SetConteudo("cnpj", pCNPJ)
            Me.SetConteudo("cod_adquirente", pCodAdquirente)
            Me.SetConteudo("cod_bandeira", pCodBandeira)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
