Partial Public Class WFClienteCabecalho
    Inherits System.Web.UI.Page

    Public ReadOnly Property Embeeded() As String
        Get
            Return Request.QueryString.Item("embeeded")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        WUCClienteCabecalho1.CodEmitente = Session(VarCodEmitente)
        WUCClienteCabecalho1.CNPJEmitente = Session("SCNPJEmitentePrincipal")
        WUCClienteCabecalho1.Acao = Session("SAcao")
        WUCClienteCabecalho1.Embeeded = Embeeded
        WUCClienteCabecalho1.VarAlterouCodCliente = VarAlterouCodCliente
        WUCClienteCabecalho1.VarCodContatoNegociacao = VarCodContatoNegociacao
        WUCClienteCabecalho1.VarCodEmitente = VarCodEmitente
        WUCClienteCabecalho1.VarCodEmitentePesquisado = VarCodEmitentePesquisado
        WUCClienteCabecalho1.VarRecarregaDdlContatos = VarRecarregaDdlContatos
        WUCClienteCabecalho1.VarCNPJEmitente = VarCNPJEmitente
        WUCClienteCabecalho1.VarCodEmitenteNegociacao = VarCodEmitenteNegociacao


    End Sub

    Public ReadOnly Property VarCodEmitente() As String
        Get
            Return Request.QueryString.Item("vcodemi")
        End Get
    End Property

    Public ReadOnly Property VarCodEmitentePesquisado() As String
        Get
            Return Request.QueryString.Item("vcodemp")
        End Get
    End Property

    Public ReadOnly Property VarAlterouCodCliente() As String
        Get
            Return Request.QueryString.Item("valtecc")
        End Get
    End Property

    Public ReadOnly Property VarRecarregaDdlContatos() As String
        Get
            Return Request.QueryString.Item("vrecdc")
        End Get
    End Property

    Public ReadOnly Property VarCodContatoNegociacao() As String
        Get
            Return Request.QueryString.Item("ccodcon")
        End Get
    End Property

    Public ReadOnly Property VarCNPJEmitente() As String
        Get
            Return Request.QueryString.Item("cnpjemi")
        End Get
    End Property

    Public ReadOnly Property VarCodEmitenteNegociacao() As String
        Get
            Return Request.QueryString.Item("vcodemin")
        End Get
    End Property

End Class