Imports System.IO

Public Class WFRelChamadoHorasDetalhado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TxtDataAberturaI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataAberturaF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataEncerramentoI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataEncerramentoF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")

            If Not IsPostBack Then
                Call CarregaTipoCobrancaOS()
                Dim objContrato As New UCLContratoManutencao
                objContrato.FillDropDown(DdlContrato, True, "(não selecionado)", 0, "", Session("GlEmpresa"), "")
            Else
                Call ChecaPesquisaCliente()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Public Sub CarregaTipoCobrancaOS()
        Try
            Dim ObjTipoCobrancaOS As New UCLTipoCobrancaOS
            ObjTipoCobrancaOS.FillDropDown(DdlTipoCobrancaOS, True, "(Todos)", "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnAplicarFiltro_Click(sender As Object, e As EventArgs) Handles BtnAplicarFiltro.Click
        SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        SqlDataSource2.DataBind()
        GridView2.DataBind()
    End Sub

    Protected Sub TxtCodEmitente_TextChanged(sender As Object, e As EventArgs) Handles TxtCodEmitente.TextChanged
        Dim objContrato As New UCLContratoManutencao
        objContrato.FillDropDown(DdlContrato, True, "(não selecionado)", TxtCodEmitente.Text, "", Session("GlEmpresa"), "")
    End Sub

    Private Sub ChecaPesquisaCliente()
        Try
            Dim CodClientePesquisado As String
            Dim CnpjClientePesquisado As String
            Dim alterouCodCliente As Long

            If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
                alterouCodCliente = Session("SAlterouCodCliente")
            Else
                alterouCodCliente = 0
            End If

            CodClientePesquisado = Session("SCodClientePesquisado")
            CnpjClientePesquisado = Session("SCNPJClientePesquisado")

            If Not String.IsNullOrEmpty(CodClientePesquisado) Then
                If alterouCodCliente > 0 Then
                    If TxtCodEmitente.Text <> CodClientePesquisado Then
                        TxtCodEmitente.Text = CodClientePesquisado
                        Dim objContrato As New UCLContratoManutencao
                        objContrato.FillDropDown(DdlContrato, True, "(não selecionado)", TxtCodEmitente.Text, "", Session("GlEmpresa"), "")
                    End If
                    Session("SAlterouCodCliente") = alterouCodCliente - 2
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class