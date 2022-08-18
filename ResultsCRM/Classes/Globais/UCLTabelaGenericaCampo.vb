Public Class UCLTabelaGenericaCampo

    Public Property NomeCampo As String
    Public Property Tipo As ENTipoCampo
    Public Property IsNull As Boolean

    Private _ConteudoData As New DateTime
    Public Property ConteudoData As DateTime
        Get
            Return _ConteudoData
        End Get
        Set(value As DateTime)
            _ConteudoData = value
            _Conteudo = _ConteudoData.ToString("yyyy-MM-dd HH:mm:ss.fff")
        End Set
    End Property

    Private _Conteudo As String
    Public Property Conteudo As String
        Get
            Return _Conteudo
        End Get
        Set(value As String)
            If Tipo = ENTipoCampo.Data Then
                If Not String.IsNullOrWhiteSpace(value) Then
                    If value.Contains("-") Then
                        If value.Length >= 10 Then
                            Dim dia, mes, ano As Integer
                            dia = value.Substring(0, 10).Split("-")(2)
                            mes = value.Substring(0, 10).Split("-")(1)
                            ano = value.Substring(0, 10).Split("-")(0)
                            If value.Length >= 19 Then
                                Dim hora, minuto, segundo As Integer
                                hora = value.Substring(11, 8).Split(":")(0)
                                minuto = value.Substring(11, 8).Split(":")(1)
                                segundo = value.Substring(11, 8).Split(":")(2)
                                _ConteudoData = New DateTime(ano, mes, dia, hora, minuto, segundo)
                            Else
                                _ConteudoData = New DateTime(ano, mes, dia)
                            End If
                        End If
                    End If
                End If
            End If
            _Conteudo = value
        End Set
    End Property

    Public Enum ENTipoCampo As Integer
        Data = 1
        Texto = 2
        NumeroInteiro = 3
        NumeroDecimal = 4
    End Enum

    Public Sub New(ByVal pNomeCampo As String, ByVal pTipo As ENTipoCampo)
        Tipo = pTipo
        NomeCampo = pNomeCampo
        IsNull = True
    End Sub

    Public Sub New(ByVal pNomeCampo As String, ByVal pTipo As ENTipoCampo, ByVal pConteudo As String)
        Tipo = pTipo
        NomeCampo = pNomeCampo
        Conteudo = pConteudo
        IsNull = False
    End Sub

End Class