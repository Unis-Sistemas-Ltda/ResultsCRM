Public Class UCLManualRotina
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("manual_rotina")
    End Sub

    Public Function Buscar(ByVal pCodManual As String, ByVal pCodSistema As String, ByVal pCodModulo As String, ByVal pCodRotina As String) As Boolean
        Try
            Me.SetConteudo("cod_manual", pCodManual)
            Me.SetConteudo("cod_sistema", pCodSistema)
            Me.SetConteudo("cod_modulo", pCodModulo)
            Me.SetConteudo("cod_rotina", pCodRotina)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodManual As String, ByVal pCodSistema As String, ByVal pCodModulo As String, ByVal pCodRotina As String)
        Try
            Me.SetConteudo("cod_manual", pCodManual)
            Me.SetConteudo("cod_sistema", pCodSistema)
            Me.SetConteudo("cod_modulo", pCodModulo)
            Me.SetConteudo("cod_rotina", pCodRotina)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class