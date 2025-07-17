<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GestionReservaciones.aspx.vb" Inherits="app_Web.GestionReservaciones" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Gestión de Reservaciones</title>
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet" />
</head>
<body class="bg-gray-100">
    <form id="form1" runat="server" class="container mx-auto py-8 px-4 sm:px-6 lg:px-8">
        <div class="max-w-4xl mx-auto bg-white rounded-lg shadow-md p-6">
            <h1 class="text-2xl font-bold text-gray-800 text-center mb-6">Gestión de Reservaciones</h1>

            <!-- Formulario de Reservación -->
            <div class="grid grid-cols-1 md:grid-cols-2 gap-4 mb-4">
                <div>
                    <label for="CITxt" class="block text-sm font-medium text-gray-700">CI del Cliente</label>
                    <asp:TextBox ID="CITxt" runat="server" CssClass="form-input mt-1 block w-full"></asp:TextBox>
                </div>
                <div>
                    <label for="NumeroHabitacionTxt" class="block text-sm font-medium text-gray-700">Número de Habitación</label>
                    <asp:TextBox ID="NumeroHabitacionTxt" runat="server" CssClass="form-input mt-1 block w-full"></asp:TextBox>
                </div>
                <div>
                    <label for="FechaInicioTxt" class="block text-sm font-medium text-gray-700">Fecha de Inicio</label>
                    <asp:TextBox ID="FechaInicioTxt" runat="server" CssClass="form-input mt-1 block w-full" TextMode="Date"></asp:TextBox>
                </div>
                <div>
                    <label for="FechaFinTxt" class="block text-sm font-medium text-gray-700">Fecha de Fin</label>
                    <asp:TextBox ID="FechaFinTxt" runat="server" CssClass="form-input mt-1 block w-full" TextMode="Date"></asp:TextBox>
                </div>
            </div>

            <!-- Botones -->
            <div class="flex justify-end space-x-4 mb-4">
                <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" CssClass="btn-primary" />
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn-secondary" />
                <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="btn-danger" />
            </div>

            <!-- Tabla de Reservaciones -->
            <asp:GridView ID="ReservacionesGridView" runat="server" AutoGenerateColumns="False" CssClass="min-w-full bg-white">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="CI" HeaderText="CI" />
                    <asp:BoundField DataField="NumeroHabitacion" HeaderText="Habitación" />
                    <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" />
                    <asp:BoundField DataField="FechaFin" HeaderText="Fecha de Fin" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
