Partial Public Class WFEquipamento2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexao)
        Dim cnpj As String = ""

        objEmitente.CodEmitente = Session("SCodEmitenteAtNegociacao")

        If String.IsNullOrWhiteSpace(objEmitente.CodEmitente) Then
            objEmitente.CodEmitente = Session("SCodEmitenteNegociacao")
        End If

        If Not String.IsNullOrEmpty(objEmitente.CodEmitente) Then
            objEmitente.Buscar()
            If Not String.IsNullOrEmpty(Session("SCNPJEmitente")) Then
                objEnderecoEmitente.CodEmitente = objEmitente.CodEmitente
                objEnderecoEmitente.CNPJ = Session("SCNPJEmitente")
                If objEnderecoEmitente.Buscar() Then
                    cnpj = objEnderecoEmitente.CNPJ
                Else
                    cnpj = objEmitente.CNPJPreferencial
                End If
            Else
                cnpj = objEmitente.CNPJPreferencial
            End If
        End If

        WUCEquipamento21.Acao = Acao
        WUCEquipamento21.NumeroSerie = Session("SNumeroSerieItemPedido")
        WUCEquipamento21.CodCliente = objEmitente.CodEmitente
        WUCEquipamento21.CNPJ = cnpj
        WUCEquipamento21.NumeroPontoAtendimento = Session("SPontoAtendimento")
    End Sub

    Private ReadOnly Property Acao()
        Get
            Dim aid As String
            aid = Request.QueryString.Item("aid")
            Select Case aid.ToLower
                Case "a"
                    Return "ALTERAR"
                Case "i"
                    Return "INCLUIR"
                Case Else
                    Return "ALTERAR"
            End Select
        End Get
    End Property

End Class