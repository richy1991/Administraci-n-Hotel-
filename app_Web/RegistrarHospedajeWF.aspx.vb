Imports app_Web.WSHotelBeni

Public Class RegistrarHospedajeWF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarHabitacionesDisponibles()
        End If
    End Sub

    Protected Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If String.IsNullOrWhiteSpace(CITxt.Text) Then
            MostrarMensaje("Por favor, ingrese un CI para buscar.", "error")
            Return
        End If

        Try
            Dim WS As New WS_Hotel_BeniSoapClient()
            Dim ds As DB.VClienteDataTable = WS.Consultar_Cliente(CITxt.Text)
            If ds IsNot Nothing AndAlso ds.Rows.Count > 0 Then
                ClienteTxt.Text = ds(0).Cliente
                MostrarMensaje("Cliente encontrado exitosamente.", "success")
            Else
                ClienteTxt.Text = "Cliente no encontrado"
                MostrarMensaje("No se encontró ningún cliente con el CI proporcionado.", "error")
            End If
        Catch ex As Exception
            MostrarMensaje("Error al buscar el cliente: " & ex.Message, "error")
        End Try
    End Sub

    Protected Sub BtnRegistrarHospedaje_Click(sender As Object, e As EventArgs) Handles BtnRegistrarHospedaje.Click
        ' Validaciones
        If String.IsNullOrWhiteSpace(CITxt.Text) OrElse String.IsNullOrWhiteSpace(ClienteTxt.Text) OrElse ClienteTxt.Text = "Cliente no encontrado" Then
            MostrarMensaje("Por favor, busque y seleccione un cliente válido.", "error")
            Return
        End If

        If HabitacionDropdown.SelectedValue = "" Then
            MostrarMensaje("Por favor, seleccione una habitación.", "error")
            Return
        End If

        If String.IsNullOrWhiteSpace(NochesTxt.Text) OrElse Not IsNumeric(NochesTxt.Text) OrElse CInt(NochesTxt.Text) <= 0 Then
            MostrarMensaje("Por favor, ingrese un número de noches válido.", "error")
            Return
        End If

        Try
            ' Obtener los datos del formulario
            Dim CI As String = CITxt.Text
            Dim NumeroHabitacion As String = HabitacionDropdown.SelectedValue
            Dim FechaInicio As DateTime = DateTime.Today
            Dim Noches As Integer = Convert.ToInt32(NochesTxt.Text)
            Dim Comentarios As String = ComentariosTxt.Text

            ' Llamar al Web Service para registrar el hospedaje
            Dim WS As New WS_Hotel_BeniSoapClient()
            Dim resultado As String = WS.Registrar_Hospedaje(CI, NumeroHabitacion, FechaInicio, Noches, Comentarios)

            ' Mostrar el resultado
            MostrarMensaje(resultado, "success")
            LimpiarFormulario()
        Catch ex As Exception
            MostrarMensaje("Error al registrar el hospedaje: " & ex.Message, "error")
        End Try
    End Sub

    Protected Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        LimpiarFormulario()
    End Sub

    Private Sub CargarHabitacionesDisponibles()
        Try
            Dim WS As New WS_Hotel_BeniSoapClient()
            Dim habitaciones As DB.vHabitacionesDataTable = WS.Habitaciones_Disponibles()
            HabitacionDropdown.DataSource = habitaciones
            HabitacionDropdown.DataTextField = "NumeroHabitacion"
            HabitacionDropdown.DataValueField = "NumeroHabitacion"
            HabitacionDropdown.DataBind()
            HabitacionDropdown.Items.Insert(0, New ListItem("Seleccione una habitación disponible", ""))
        Catch ex As Exception
            MostrarMensaje("Error al cargar las habitaciones: " & ex.Message, "error")
        End Try
    End Sub

    Private Sub LimpiarFormulario()
        CITxt.Text = ""
        ClienteTxt.Text = ""
        HabitacionDropdown.SelectedIndex = 0
        NochesTxt.Text = ""
        ComentariosTxt.Text = ""
    End Sub

    Private Sub MostrarMensaje(mensaje As String, tipo As String)
        Dim script As String = $"setTimeout(function() {{ alert('{mensaje.Replace("'", "\'")}'); }}, 100);"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", script, True)
    End Sub
End Class
