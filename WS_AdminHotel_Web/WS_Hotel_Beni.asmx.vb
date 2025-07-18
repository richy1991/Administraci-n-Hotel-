Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_Hotel_Beni
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hola a todos"
    End Function

    <WebMethod()>
    Public Function Consultar_Cliente(CI As String) As DB.VClienteDataTable
        Dim adap As New DBTableAdapters.VClienteTableAdapter
        Return adap.Devolver_CI(CI)

    End Function

    <WebMethod()>
    Public Function Habitaciones_Disponibles() As DB.vHabitacionesDataTable
        Dim adah As New DBTableAdapters.vHabitacionesTableAdapter
        Return adah.DevHabDisponible

    End Function

    <WebMethod()>
    Public Function Registrar_Hospedaje(CI As String, NumeroHabitacion As String, FechaInicio As DateTime, Noches As Integer, Comentarios As String) As String
        Try
            ' Validar los parámetros de entrada
            If String.IsNullOrWhiteSpace(CI) Then
                Throw New ArgumentException("El CI no puede estar vacío.")
            End If
            If String.IsNullOrWhiteSpace(NumeroHabitacion) Then
                Throw New ArgumentException("El número de habitación no puede estar vacío.")
            End If
            If Noches <= 0 Then
                Throw New ArgumentException("El número de noches debe ser mayor a 0.")
            End If

            ' Crear un nuevo registro de hospedaje
            Dim adaptadorReservaciones As New DBTableAdapters.ReservacionesTableAdapter
            Dim fechaFin As DateTime = FechaInicio.AddDays(Noches)

            ' Supongamos que el método "InsertarHospedaje" ya está definido en tu adaptador
            adaptadorReservaciones.InsertarHospedaje(
                CI, NumeroHabitacion, FechaInicio, fechaFin, 0, "Pendiente", Comentarios, DateTime.Now)

            ' Cambiar el estado de la habitación a "Ocupado"
            Dim adaptadorHabitaciones As New DBTableAdapters.HabitacionesTableAdapter
            adaptadorHabitaciones.ActualizarEstado("Ocupado", NumeroHabitacion)

            Return "Hospedaje registrado correctamente."
        Catch sqlEx As SqlClient.SqlException
            ' Manejo específico para errores SQL
            Return $"Error SQL: {sqlEx.Message}"
        Catch ex As Exception
            ' Manejo general de errores
            Return $"Error general: {ex.Message}"
        End Try
    End Function


End Class