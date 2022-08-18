Imports System.IO

Public Class WFRelChamadoDeslocamentoDetalhado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TxtDataAberturaI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataAberturaF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataEncerramentoI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataEncerramentoF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")

            If Not IsPostBack Then
                Call CarregaTipoCobrancaOS()
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

End Class