Public Partial Class WUCFrame
    Inherits System.Web.UI.UserControl
    Dim _Pagina As String
    Dim _Width As String
    Dim _Height As String
    Dim _Scrolling As String
    Dim _FrameBorder As String

    Public Property FrameBorder As String
        Get
            If String.IsNullOrWhiteSpace(_FrameBorder) Then
                _FrameBorder = "0"
            End If
            Return _FrameBorder
        End Get
        Set(value As String)
            _FrameBorder = value
        End Set
    End Property

    Public Property Scrolling() As String
        Get
            If String.IsNullOrWhiteSpace(_Scrolling) Then
                _Scrolling = "auto"
            End If
            Return _Scrolling
        End Get
        Set(value As String)
            _Scrolling = value
        End Set
    End Property

    Public Property Width() As String
        Get
            Return _Width
        End Get
        Set(ByVal value As String)
            _Width = value
        End Set
    End Property

    Public Property Height() As String
        Get
            Return _Height
        End Get
        Set(ByVal value As String)
            _Height = value
        End Set
    End Property


    Public Property Pagina()
        Get
            Return _Pagina
        End Get
        Set(ByVal value)
            _Pagina = value
            IFPagina.Attributes.Item("SRC") = _Pagina
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Carregar()
    End Sub

    Public Sub Carregar()
        Try
            Dim estilo As String
            estilo = "border:none; width: " & Width & "; height: " & Height '& "frameborder=" & Chr(34) & FrameBorder & Chr(34) & " scrolling=" & Chr(34) & Scrolling & Chr(34) + ";"
            If Scrolling = "no" Or String.IsNullOrWhiteSpace(Scrolling) Then
                estilo += "overflow: hidden; clear: both"
            End If
            IFPagina.Attributes.Item("Style") = estilo
            IFPagina.Attributes.Item("frameborder") = Chr(34) & FrameBorder & Chr(34)
            IFPagina.Attributes.Item("scrolling") = Chr(34) & Scrolling & Chr(34)
            IFPagina.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class