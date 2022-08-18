Partial Public Class WFClienteCNPJ
    Inherits System.Web.UI.Page

    Private ReadOnly Property Embeeded() As String
        Get
            Return Request.QueryString.Item("embeeded")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCClienteCNPJ1.CodEmitente = Session(VarCodEmitente)
        WUCClienteCNPJ1.CNPJ = Session(VarCNPJEmitente)
        WUCClienteCNPJ1.Acao = Session("SAcaoCNPJ")
        WUCClienteCNPJ1.Embeeded = Embeeded
        WUCClienteCNPJ1.VarAlterouCodCliente = VarAlterouCodCliente
        WUCClienteCNPJ1.VarCodContatoNegociacao = VarCodContatoNegociacao
        WUCClienteCNPJ1.VarCodEmitente = VarCodEmitente
        WUCClienteCNPJ1.VarCodEmitentePesquisado = VarCodEmitentePesquisado
        WUCClienteCNPJ1.VarRecarregaDdlContatos = VarRecarregaDdlContatos
        WUCClienteCNPJ1.VarCNPJEmitentePesquisado = VarCNPJEmitente
        WUCClienteCNPJ1.VarCodEmitenteNegociacao = VarCodEmitenteNegociacao
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