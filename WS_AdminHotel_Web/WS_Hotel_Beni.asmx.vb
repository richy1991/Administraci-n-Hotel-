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
    Public Function Havitaciones_Disponibles() As DB.vHabitacionesDataTable
        Dim adah As New DBTableAdapters.vHabitacionesTableAdapter
        Return adah.DevHabDisponible

    End Function

    <WebMethod()>
    Public Function Registrar_Cliente(CI As String, Nombre As String, Apellido As String, Telefono As String, Email As String) As String
        Try
            Dim adap As New DBTableAdapters.ClienteTableAdapter
            adap.Insert(CI, Nombre, Apellido, Telefono, Email)
            Return "Cliente registrado correctamente."
        Catch ex As Exception
            Return "Error al registrar el cliente: " & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function Actualizar_Cliente(CI As String, Nombre As String, Apellido As String, Telefono As String, Email As String) As String
        Try
            Dim adap As New DBTableAdapters.ClienteTableAdapter
            adap.ActualizarCliente(Nombre, Apellido, Telefono, Email, CI)
            Return "Cliente actualizado correctamente."
        Catch ex As Exception
            Return "Error al actualizar el cliente: " & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function Registrar_Habitacion(Numero As String, Tipo As String, Precio As Decimal, Estado As String) As String
        Try
            Dim adap As New DBTableAdapters.HabitacionesTableAdapter
            adap.Insert(Numero, Tipo, Precio, Estado)
            Return "Habitación registrada correctamente."
        Catch ex As Exception
            Return "Error al registrar la habitación: " & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function Actualizar_Habitacion(Numero As String, Tipo As String, Precio As Decimal, Estado As String) As String
        Try
            Dim adap As New DBTableAdapters.HabitacionesTableAdapter
            adap.ActualizarHabitacion(Tipo, Precio, Estado, Numero)
            Return "Habitación actualizada correctamente."
        Catch ex As Exception
            Return "Error al actualizar la habitación: " & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function Eliminar_Habitacion(Numero As String) As String
        Try
            Dim adap As New DBTableAdapters.HabitacionesTableAdapter
            adap.EliminarHabitacion(Numero)
            Return "Habitación eliminada correctamente."
        Catch ex As Exception
            Return "Error al eliminar la habitación: " & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function Habitaciones_Ocupadas() As DB.vHabitacionesDataTable
        Dim adah As New DBTableAdapters.vHabitacionesTableAdapter
        Return adah.DevHabOcupada()
    End Function

    <WebMethod()>
    Public Function Registrar_Reservacion(CI As String, NumeroHabitacion As String, FechaInicio As DateTime, FechaFin As DateTime) As String
        Try
            Dim adap As New DBTableAdapters.ReservacionesTableAdapter
            adap.Insert(CI, NumeroHabitacion, FechaInicio, FechaFin, 0, "Pendiente", "Ninguna", DateTime.Now)
            Return "Reservación registrada correctamente."
        Catch ex As Exception
            Return "Error al registrar la reservación: " & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function Actualizar_Reservacion(ID As Integer, CI As String, NumeroHabitacion As String, FechaInicio As DateTime, FechaFin As DateTime, Estado As String) As String
        Try
            Dim adap As New DBTableAdapters.ReservacionesTableAdapter
            adap.ActualizarReservacion(CI, NumeroHabitacion, FechaInicio, FechaFin, 0, Estado, "Ninguna", DateTime.Now, ID)
            Return "Reservación actualizada correctamente."
        Catch ex As Exception
            Return "Error al actualizar la reservación: " & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function Eliminar_Reservacion(ID As Integer) As String
        Try
            Dim adap As New DBTableAdapters.ReservacionesTableAdapter
            adap.EliminarReservacion(ID)
            Return "Reservación eliminada correctamente."
        Catch ex As Exception
            Return "Error al eliminar la reservación: " & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function Registrar_Hospedaje(CI As String, NumeroHabitacion As String, FechaInicio As DateTime, Noches As Integer) As String
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
                CI, NumeroHabitacion, FechaInicio, fechaFin, 0, "Pendiente", "Ninguna", DateTime.Now)

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

    <WebMethod()>
    Public Function Registrar_Salida(IDHospedaje As Integer, NumeroHabitacion As String) As String
        Try
            Dim adaptadorHospedaje As New DBTableAdapters.HospedajeTableAdapter
            adaptadorHospedaje.RegistrarSalida(DateTime.Now, IDHospedaje)

            Dim adaptadorHabitaciones As New DBTableAdapters.HabitacionesTableAdapter
            adaptadorHabitaciones.ActualizarEstado("Disponible", NumeroHabitacion)

            Return "Salida registrada correctamente."
        Catch ex As Exception
            Return "Error al registrar la salida: " & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function Registrar_Pago(IDHospedaje As Integer, Monto As Decimal, MetodoPago As String) As String
        Try
            Dim adap As New DBTableAdapters.PagosTableAdapter
            adap.Insert(IDHospedaje, DateTime.Now, Monto, MetodoPago)
            Return "Pago registrado correctamente."
        Catch ex As Exception
            Return "Error al registrar el pago: " & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function Consultar_Pagos(IDHospedaje As Integer) As DB.PagosDataTable
        Dim adap As New DBTableAdapters.PagosTableAdapter
        Return adap.GetDataByIDHospedaje(IDHospedaje)
    End Function

    <WebMethod()>
    Public Function ObtenerTodosLosClientes() As DB.VClienteDataTable
        Dim adap As New DBTableAdapters.VClienteTableAdapter
        Return adap.GetData()
    End Function

    <WebMethod()>
    Public Function ObtenerTodasLasHabitaciones() As DB.vHabitacionesDataTable
        Dim adap As New DBTableAdapters.vHabitacionesTableAdapter
        Return adap.GetData()
    End Function

    <WebMethod()>
    Public Function ObtenerTodasLasReservaciones() As DB.ReservacionesDataTable
        Dim adap As New DBTableAdapters.ReservacionesTableAdapter
        Return adap.GetData()
    End Function

    <WebMethod()>
    Public Function ObtenerTodosLosHospedajes() As DB.HospedajeDataTable
        Dim adap As New DBTableAdapters.HospedajeTableAdapter
        Return adap.GetData()
    End Function

    <WebMethod()>
    Public Function ObtenerTodosLosPagos() As DB.PagosDataTable
        Dim adap As New DBTableAdapters.PagosTableAdapter
        Return adap.GetData()
    End Function


End Class