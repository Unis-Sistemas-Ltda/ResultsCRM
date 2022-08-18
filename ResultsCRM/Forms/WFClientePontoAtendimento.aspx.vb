Partial Public Class WFClientePontoAtendimento
    Inherits System.Web.UI.Page

    Private ReadOnly Property Embeeded() As String
        Get
            Return Request.QueryString.Item("embeeded")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCClientePontoAtendimento1.CodEmitente = Session(VarCodEmitente)
        WUCClientePontoAtendimento1.NumeroPontoAtendimento = Session(VarNrPtoAtendimentoPesquisado)
        WUCClientePontoAtendimento1.Acao = Session("SAcaoCNPJ")
        WUCClientePontoAtendimento1.Embeeded = Embeeded
        WUCClientePontoAtendimento1.VarAlterouPontoAtendimento = VarAlterouCodCliente
        WUCClientePontoAtendimento1.VarCodContatoNegociacao = VarCodContatoNegociacao
        WUCClientePontoAtendimento1.VarCodEmitente = VarCodEmitente
        WUCClientePontoAtendimento1.VarCodEmitentePesquisado = VarCodEmitentePesquisado
        WUCClientePontoAtendimento1.VarRecarregaDdlContatos = VarRecarregaDdlContatos
        WUCClientePontoAtendimento1.VarPtoAtEmitentePesquisado = VarNrPtoAtendimentoPesquisado
        WUCClientePontoAtendimento1.VarCodEmitenteNegociacao = VarCodEmitenteNegociacao
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

    Public ReadOnly Property VarNrPtoAtendimentoPesquisado() As String
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