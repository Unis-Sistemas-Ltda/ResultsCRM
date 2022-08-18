﻿Public Class UCLParametrosVenda
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("parametros_venda")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
