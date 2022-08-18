Public Partial Class WFClienteEmbeeded
    Inherits System.Web.UI.Page

    Private ReadOnly Property Acao() As String
        Get
            Select Case Request.QueryString.Item("a")
                Case "A"
                    Session("SPulaCNPJCadastro") = "N"
                    Return "ALTERAR"
                Case "I"
                    Session("SPulaCNPJCadastro") = "N"
                    Return "INCLUIR"
                Case "A1"
                    Session("SPulaCNPJCadastro") = "S"
                    Return "ALTERAR"
                Case "I1"
                    Session("SPulaCNPJCadastro") = "S"
                    Return "INCLUIR"
                Case Else
                    Return "ALTERAR"
            End Select
        End Get
    End Property

    Private ReadOnly Property CodCliente() As String
        Get
            Select Case Acao
                Case "INCLUIR"
                    Return -1
                Case Else
                    Return Session(VarCodEmitenteNegociacao)
            End Select
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SAcao") = Acao
        Session(VarCodEmitente) = CodCliente
        Response.Redirect("WFClienteCabecalho.aspx?embeeded=True&vcodemi=" + VarCodEmitente + "&vcodemp=" + VarCodEmitentePesquisado + "&valtecc=" + VarAlterouCodCliente + "&vrecdc=" + VarRecarregaDdlContatos + "&ccodcon=" + VarCodContatoNegociacao + "&cnpjemi=" + VarCNPJEmitente + "&vcodemin=" + VarCodEmitenteNegociacao)
    End Sub

    Public ReadOnly Property VarCodEmitente() As String
        Get
            Return Request.QueryString.Item("vcodemi").ToString
        End Get
    End Property

    Public ReadOnly Property VarCodEmitentePesquisado() As String
        Get
            Return Request.QueryString.Item("vcodemp").ToString
        End Get
    End Property

    Public ReadOnly Property VarAlterouCodCliente() As String
        Get
            Return Request.QueryString.Item("valtecc").ToString
        End Get
    End Property

    Public ReadOnly Property VarRecarregaDdlContatos() As String
        Get
            Return Request.QueryString.Item("vrecdc")
        End Get
    End Property

    Public ReadOnly Property VarCodContatoNegociacao() As String
        Get
            Return Request.QueryString.Item("ccodcon").ToString
        End Get
    End Property

    Public ReadOnly Property VarCNPJEmitente() As String
        Get
            Return Request.QueryString.Item("cnpjemi").ToString
        End Get
    End Property

    Public ReadOnly Property VarCodEmitenteNegociacao() As String
        Get
            Return Request.QueryString.Item("vcodemin").ToString
        End Get
    End Property

End Class