Imports app_Web.WSHotelBeni

Public Class GestionPagos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPagos()
        End If
    End Sub

    Private Sub CargarPagos()
        Dim WS As New WS_Hotel_BeniSoapClient
        PagosGridView.DataSource = WS.ObtenerTodosLosPagos()
        PagosGridView.DataBind()
    End Sub

    Protected Sub BtnRegistrar_Click(sender As Object, e As EventArgs) Handles BtnRegistrar.Click
        Dim WS As New WS_Hotel_BeniSoapClient
        Dim resultado As String = WS.Registrar_Pago(Convert.ToInt32(IDHospedajeTxt.Text), Convert.ToDecimal(MontoTxt.Text), MetodoPagoDdl.SelectedValue)
        ' Mostrar resultado
        CargarPagos()
    End Sub

End Class
