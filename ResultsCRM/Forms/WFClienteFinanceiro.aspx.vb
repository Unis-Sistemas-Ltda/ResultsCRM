Public Partial Class WFClienteFinanceiro
    Inherits System.Web.UI.Page

    Private ReadOnly Property Embeeded() As String
        Get
            Return Request.QueryString.Item("embeeded")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCClienteFinanceiro1.CodEmitente = Session(Request.QueryString.Item("vcodemi").ToString)
        WUCClienteFinanceiro1.Embeeded = Embeeded
        WUCClienteFinanceiro1.VarCodEmitente = VarCodEmitente
        WUCClienteFinanceiro1.VarCodEmitentePesquisado = VarCodEmitentePesquisado
        WUCClienteFinanceiro1.VarAlterouCodCliente = VarAlterouCodCliente
        WUCClienteFinanceiro1.VarCodContatoNegociacao = VarCodContatoNegociacao
        WUCClienteFinanceiro1.VarRecarregaDdlContatos = VarRecarregaDdlContatos
        WUCClienteFinanceiro1.VarCNPJEmitente = VarCNPJEmitente
        WUCClienteFinanceiro1.VarCodEmitenteNegociacao = VarCodEmitenteNegociacao
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
            Return Request.QueryString.Item("vcodemin")
        End Get
    End Property

End Class