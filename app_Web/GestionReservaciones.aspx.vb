Imports app_Web.WSHotelBeni

Public Class GestionReservaciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarReservaciones()
        End If
    End Sub

    Private Sub CargarReservaciones()
        Dim WS As New WS_Hotel_BeniSoapClient
        ReservacionesGridView.DataSource = WS.ObtenerTodasLasReservaciones()
        ReservacionesGridView.DataBind()
    End Sub

    Protected Sub BtnRegistrar_Click(sender As Object, e As EventArgs) Handles BtnRegistrar.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        Dim resultado As String = WS.Registrar_Reservacion(CITxt.Text, NumeroHabitacionTxt.Text, Convert.ToDateTime(FechaInicioTxt.Text), Convert.ToDateTime(FechaFinTxt.Text))
        ' Mostrar resultado
        CargarReservaciones()
    End Sub

    Protected Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        ' Aquí necesitaríamos un ID para actualizar la reservación.
        ' Dim resultado As String = WS.Actualizar_Reservacion(ID, CITxt.Text, NumeroHabitacionTxt.Text, Convert.ToDateTime(FechaInicioTxt.Text), Convert.ToDateTime(FechaFinTxt.Text), "Pendiente")
        ' Mostrar resultado
        CargarReservaciones()
    End Sub

    Protected Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        ' Aquí necesitaríamos un ID para eliminar la reservación.
        ' Dim resultado As String = WS.Eliminar_Reservacion(ID)
        ' Mostrar resultado
        CargarReservaciones()
    End Sub

End Class
