Imports app_Web.WSHotelBeni

Public Class GestionHospedajes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarHospedajes()
        End If
    End Sub

    Private Sub CargarHospedajes()
        Dim WS As New WS_Hotel_BeniSoapClient
        HospedajesGridView.DataSource = WS.ObtenerTodosLosHospedajes()
        HospedajesGridView.DataBind()
    End Sub

    Protected Sub BtnRegistrar_Click(sender As Object, e As EventArgs) Handles BtnRegistrar.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        Dim resultado As String = WS.Registrar_Hospedaje(CITxt.Text, NumeroHabitacionTxt.Text, Convert.ToDateTime(FechaInicioTxt.Text), Convert.ToInt32(NochesTxt.Text))
        ' Mostrar resultado
        CargarHospedajes()
    End Sub

    Protected Sub BtnRegistrarSalida_Click(sender As Object, e As EventArgs) Handles BtnRegistrarSalida.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        ' Aquí necesitaríamos un ID para registrar la salida.
        ' Dim resultado As String = WS.Registrar_Salida(ID, NumeroHabitacionTxt.Text)
        ' Mostrar resultado
        CargarHospedajes()
    End Sub

End Class
