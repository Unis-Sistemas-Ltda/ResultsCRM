Partial Public Class WFPontoAtendimentoEmbeeded
    Inherits System.Web.UI.Page

    Private ReadOnly Property Acao() As String
        Get
            Select Case Request.QueryString.Item("a")
                Case "A"
                    Return "ALTERAR"
                Case "I"
                    Return "INCLUIR"
                Case Else
                    Return "ALTERAR"
            End Select
        End Get
    End Property

    Private ReadOnly Property CodCliente() As String
        Get
            Return Session(VarCodEmitenteNegociacao)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SAcaoCNPJ") = Acao
        Session(VarCodEmitente) = CodCliente
        Response.Redirect("WFClientePontoAtendimento.aspx?embeeded=True&vcodemi=" + VarCodEmitente + "&vcodemp=" + VarCodEmitentePesquisado + "&valtecc=" + VarAlterouPontoAtendimento + "&vrecdc=" + VarRecarregaDdlContatos + "&ccodcon=" + VarCodContatoNegociacao + "&ptat=" + VarPontoAtendimento + "&vcodemin=" + VarCodEmitenteNegociacao)
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

    Public ReadOnly Property VarAlterouPontoAtendimento() As String
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

    Public ReadOnly Property VarPontoAtendimento() As String
        Get
            Return Request.QueryString.Item("ptat").ToString
        End Get
    End Property

    Public ReadOnly Property VarCodEmitenteNegociacao() As String
        Get
            Return Request.QueryString.Item("vcodemin").ToString
        End Get
    End Property

End Class