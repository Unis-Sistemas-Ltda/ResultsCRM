Public Class WUCRoteiroAtendimento
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodRoteiro As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodRoteiro() As String
        Get
            Return _CodRoteiro
        End Get
        Set(ByVal value As String)
            _CodRoteiro = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtDataAtendimento.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")

        If Not IsPostBack Then
            Call CarregaTecnico()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaTecnico()
        Dim objAgTecnico As New UCLAgenteTecnico
        objAgTecnico.FillDropDown(DdlAgenteTecnico, False, "(Todos)", -1)
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjRoteiro As New UCLRoteiroAtendimento
        ObjRoteiro.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"), CodRoteiro)
        LblCodRoteiro.Text = CodRoteiro
        Call CarregaTecnico()
        DdlAgenteTecnico.SelectedValue = ObjRoteiro.GetConteudo("cod_agente_tecnico")
        TxtDataAtendimento.Text = ConverteDataDoBancoParaTela(ObjRoteiro.GetConteudo("data_atendimento"))
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjRoteiro As New UCLRoteiroAtendimento
        LblCodRoteiro.Text = ObjRoteiro.GetProximoCodigo(Session("GlEmpresa"), Session("GlEstabelecimento"))
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjRoteiro As New UCLRoteiroAtendimento
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjRoteiro.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjRoteiro.SetConteudo("estabelecimento", Session("GlEstabelecimento"))
                    ObjRoteiro.SetConteudo("cod_roteiro", LblCodRoteiro.Text)
                    ObjRoteiro = CarregaObjeto(ObjRoteiro)
                    ObjRoteiro.Alterar()
                    Call GravaMarcacoes(GetMarcacoes())
                    Response.Redirect("WGRoteiroAtendimento.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjRoteiro.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjRoteiro.SetConteudo("estabelecimento", Session("GlEstabelecimento"))
                    ObjRoteiro.SetConteudo("cod_roteiro", LblCodRoteiro.Text)
                    ObjRoteiro.SetConteudo("cod_usuario_inclusao", Session("GlCodUsuario"))
                    ObjRoteiro.SetConteudo("data_inclusao", Now.ToString("dd/MM/yyyy HH:mm:ss.fff"))
                    ObjRoteiro = CarregaObjeto(ObjRoteiro)
                    ObjRoteiro.Incluir()
                    Call GravaMarcacoes(GetMarcacoes())
                    Response.Redirect("WGRoteiroAtendimento.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtDataAtendimento.Text) Then
            LblErro.Text += "Preencha o campo Data.<br/>"
        ElseIf Not isValidDate(TxtDataAtendimento.Text) Then
            LblErro.Text += "Preencha corretamente o campo Data.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjRoteiro As UCLRoteiroAtendimento) As UCLRoteiroAtendimento
        ObjRoteiro.SetConteudo("data_atendimento", TxtDataAtendimento.Text)
        ObjRoteiro.SetConteudo("cod_agente_tecnico", DdlAgenteTecnico.SelectedValue)
        ObjRoteiro.SetConteudo("cod_usuario_alteracao", Session("GlCodUsuario"))
        ObjRoteiro.SetConteudo("data_alteracao", Now.ToString("dd/MM/yyyy HH:mm:ss.fff"))
        Return ObjRoteiro
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGRoteiroAtendimento.aspx")
    End Sub

    Protected Sub DdlAgenteTecnico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlAgenteTecnico.SelectedIndexChanged
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub

    Private Sub GravaMarcacoes(marcacoes As List(Of Marcacao))
        Try
            Dim objRoteiroAtendimentoPedidoVenda As UCLRoteiroAtendimentoPedidoVenda
            Dim objPedidoVendaAgenteTecnico As UCLPedidoVendaAgenteTecnico

            For Each m As Marcacao In marcacoes
                objRoteiroAtendimentoPedidoVenda = New UCLRoteiroAtendimentoPedidoVenda
                If objRoteiroAtendimentoPedidoVenda.Buscar(Session("GlEmpresa"), Session("GlEstabelecimento"), LblCodRoteiro.Text, m.CodPedidoVenda) Then
                    objRoteiroAtendimentoPedidoVenda.Excluir(Session("GlEmpresa"), Session("GlEstabelecimento"), LblCodRoteiro.Text, m.CodPedidoVenda)
                End If
                If m.Marcado Then
                    If CbxSemTecnico.Checked Then
                        objPedidoVendaAgenteTecnico = New UCLPedidoVendaAgenteTecnico(StrConexao)
                        objPedidoVendaAgenteTecnico.Empresa = Session("GlEmpresa")
                        objPedidoVendaAgenteTecnico.Estabelecimento = Session("GlEstabelecimento")
                        objPedidoVendaAgenteTecnico.CodPedidoVenda = m.CodPedidoVenda
                        objPedidoVendaAgenteTecnico.CodAgenteTecnico = DdlAgenteTecnico.SelectedValue
                        If Not objPedidoVendaAgenteTecnico.Existe() Then
                            objPedidoVendaAgenteTecnico.Incluir()
                        End If
                    End If
                    objRoteiroAtendimentoPedidoVenda = New UCLRoteiroAtendimentoPedidoVenda
                    objRoteiroAtendimentoPedidoVenda.SetConteudo("empresa", Session("GlEmpresa"))
                    objRoteiroAtendimentoPedidoVenda.SetConteudo("estabelecimento", Session("GlEstabelecimento"))
                    objRoteiroAtendimentoPedidoVenda.SetConteudo("cod_roteiro", LblCodRoteiro.Text)
                    objRoteiroAtendimentoPedidoVenda.SetConteudo("cod_pedido_venda", m.CodPedidoVenda)
                    objRoteiroAtendimentoPedidoVenda.SetConteudo("sequencia", m.Sequencia)
                    objRoteiroAtendimentoPedidoVenda.Incluir()
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetMarcacoes() As List(Of Marcacao)
        Try
            Dim m As Marcacao
            Dim marcacoes As New List(Of Marcacao)

            For Each row As GridViewRow In GridView1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    m = New Marcacao
                    m.Marcado = CType(row.FindControl("CbxMarcado"), CheckBox).Checked
                    m.Sequencia = CType(row.FindControl("TxtSequencia"), TextBox).Text.ToString.GetValidInputContent
                    m.CodPedidoVenda = CType(row.FindControl("LblCodPedidoVenda"), Label).Text
                    marcacoes.Add(m)
                End If
            Next

            Return marcacoes
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Structure Marcacao
        Dim Marcado As Boolean
        Dim Sequencia As String
        Dim CodPedidoVenda As String
    End Structure

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CbxSemTecnico.CheckedChanged
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub
End Class