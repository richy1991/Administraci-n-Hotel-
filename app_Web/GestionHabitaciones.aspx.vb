Imports app_Web.WSHotelBeni

Public Class GestionHabitaciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarHabitaciones()
        End If
    End Sub

    Private Sub CargarHabitaciones()
        Dim WS As New WS_Hotel_BeniSoapClient
        HabitacionesGridView.DataSource = WS.ObtenerTodasLasHabitaciones()
        HabitacionesGridView.DataBind()
    End Sub

    Protected Sub BtnRegistrar_Click(sender As Object, e As EventArgs) Handles BtnRegistrar.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        Dim resultado As String = WS.Registrar_Habitacion(NumeroTxt.Text, TipoTxt.Text, Convert.ToDecimal(PrecioTxt.Text), EstadoDdl.SelectedValue)
        ' Mostrar resultado
        CargarHabitaciones()
    End Sub

    Protected Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        Dim resultado As String = WS.Actualizar_Habitacion(NumeroTxt.Text, TipoTxt.Text, Convert.ToDecimal(PrecioTxt.Text), EstadoDdl.SelectedValue)
        ' Mostrar resultado
        CargarHabitaciones()
    End Sub

    Protected Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        Dim resultado As String = WS.Eliminar_Habitacion(NumeroTxt.Text)
        ' Mostrar resultado
        CargarHabitaciones()
    End Sub

End Class
