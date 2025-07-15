Imports app_Web.WSHotelBeni

Public Class RegistrarHospedajeWF
    Inherits System.Web.UI.Page


    Protected Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        Dim ds As New DB.VClienteDataTable
        ds = WS.Consultar_Cliente(CITxt.Text)
        ClienteTxt.Text = ds.Item(0).Cliente


    End Sub


    '  Protected Sub BtnRegistrarHospedaje_Click(sender As Object, e As EventArgs) Handles BtnRegistrarHospedaje.Click
    ' Obtener los datos del formulario
    '   Dim CI As String = CITxt.Text
    '    Dim NumeroHabitacion As String = HabitacionDropdown.SelectedValue ' Usa SelectedValue si es un DropDownList
    Dim FechaInicio As DateTime = DateTime.Today ' Captura la fecha de hoy
    '       Dim Noches As Integer = Convert.ToInt32(NochesTxt.Text) ' Asume que tienes un TextBox para las noches
    '   Dim FechaFin As DateTime = FechaInicio.AddDays(Noches) ' Calcula la fecha de fin

    ' Llamar al Web Service para registrar el hospedaje
    Dim WS As New WS_Hotel_BeniSoapClient


    'Dim resultado As String = WS.Registrar_Hospedaje(CI, NumeroHabitacion, FechaInicio, Noches)

    ' Mostrar el resultado en un Label
    'ResultadoLbl.Text = resultado ' Asume que tienes un Label llamado ResultadoLbl para mostrar el mensaje
    '    End Sub
End Class
