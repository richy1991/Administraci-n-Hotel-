<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GestionHabitaciones.aspx.vb" Inherits="app_Web.GestionHabitaciones" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Gestión de Habitaciones</title>
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet" />
</head>
<body class="bg-gray-100">
    <form id="form1" runat="server" class="container mx-auto py-8 px-4 sm:px-6 lg:px-8">
        <div class="max-w-4xl mx-auto bg-white rounded-lg shadow-md p-6">
            <h1 class="text-2xl font-bold text-gray-800 text-center mb-6">Gestión de Habitaciones</h1>

            <!-- Formulario de Habitación -->
            <div class="grid grid-cols-1 md:grid-cols-2 gap-4 mb-4">
                <div>
                    <label for="NumeroTxt" class="block text-sm font-medium text-gray-700">Número</label>
                    <asp:TextBox ID="NumeroTxt" runat="server" CssClass="form-input mt-1 block w-full"></asp:TextBox>
                </div>
                <div>
                    <label for="TipoTxt" class="block text-sm font-medium text-gray-700">Tipo</label>
                    <asp:TextBox ID="TipoTxt" runat="server" CssClass="form-input mt-1 block w-full"></asp:TextBox>
                </div>
                <div>
                    <label for="PrecioTxt" class="block text-sm font-medium text-gray-700">Precio</label>
                    <asp:TextBox ID="PrecioTxt" runat="server" CssClass="form-input mt-1 block w-full"></asp:TextBox>
                </div>
                <div>
                    <label for="EstadoDdl" class="block text-sm font-medium text-gray-700">Estado</label>
                    <asp:DropDownList ID="EstadoDdl" runat="server" CssClass="form-select mt-1 block w-full">
                        <asp:ListItem Text="Disponible" Value="Disponible" />
                        <asp:ListItem Text="Ocupado" Value="Ocupado" />
                        <asp:ListItem Text="Mantenimiento" Value="Mantenimiento" />
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Botones -->
            <div class="flex justify-end space-x-4 mb-4">
                <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" CssClass="btn-primary" />
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn-secondary" />
                <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="btn-danger" />
            </div>

            <!-- Tabla de Habitaciones -->
            <asp:GridView ID="HabitacionesGridView" runat="server" AutoGenerateColumns="False" CssClass="min-w-full bg-white">
                <Columns>
                    <asp:BoundField DataField="Numero" HeaderText="Número" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
