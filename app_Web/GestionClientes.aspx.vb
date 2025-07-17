Imports app_Web.WSHotelBeni

Public Class GestionClientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarClientes()
        End If
    End Sub

    Private Sub CargarClientes()
        Dim WS As New WS_Hotel_BeniSoapClient
        ClientesGridView.DataSource = WS.ObtenerTodosLosClientes()
        ClientesGridView.DataBind()
    End Sub

    Protected Sub BtnRegistrar_Click(sender As Object, e As EventArgs) Handles BtnRegistrar.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        Dim resultado As String = WS.Registrar_Cliente(CITxt.Text, NombreTxt.Text, ApellidoTxt.Text, TelefonoTxt.Text, EmailTxt.Text)
        ' Mostrar resultado
        CargarClientes()
    End Sub

    Protected Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        Dim resultado As String = WS.Actualizar_Cliente(CITxt.Text, NombreTxt.Text, ApellidoTxt.Text, TelefonoTxt.Text, EmailTxt.Text)
        ' Mostrar resultado
        CargarClientes()
    End Sub

    Protected Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        Dim resultado As String = WS.Eliminar_Cliente(CITxt.Text)
        ' Mostrar resultado
        CargarClientes()
    End Sub

    Protected Sub ClientesGridView_SelectedIndexChanged(sender As Object, e As EventArgs)
        CITxt.Text = ClientesGridView.SelectedDataKey.Value.ToString()
        NombreTxt.Text = ClientesGridView.SelectedRow.Cells(1).Text
        ApellidoTxt.Text = ClientesGridView.SelectedRow.Cells(2).Text
        TelefonoTxt.Text = ClientesGridView.SelectedRow.Cells(3).Text
        EmailTxt.Text = ClientesGridView.SelectedRow.Cells(4).Text
    End Sub
End Class
