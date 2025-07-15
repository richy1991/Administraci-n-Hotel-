<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistrarHospedajeWF.aspx.vb" Inherits="app_Web.RegistrarHospedajeWF" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Registrar Hospedaje</title>
    <!-- Estilos de Tailwind CSS -->
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet" />
</head>
<body class="bg-gray-100">
    <form id="form1" runat="server" class="container mx-auto py-8 px-4 sm:px-6 lg:px-8">
        <div class="max-w-2xl mx-auto bg-white rounded-lg shadow-md p-6">
            <h1 class="text-2xl font-bold text-gray-800 text-center mb-6">Registrar Hospedaje</h1>
            
            <!-- Buscar Cliente -->
            <div class="mb-4">
                <label for="label" class="block text-sm font-medium text-gray-700">Ingrese el CI</label>
                <asp:TextBox ID="CITxt" runat="server" CssClass="form-input mt-1 block w-full" placeholder="Ej: 12345678"></asp:TextBox>
            </div>
            <div class="mb-4">
                <asp:Button ID="BtnBuscar" runat="server" Text="Buscar Cliente" CssClass="btn-primary w-full" />
            </div>
            
            <!-- Información del Cliente -->
            <div class="mb-4">
                <label for="ClienteTxt" class="block text-sm font-medium text-gray-700">Nombre del Cliente</label>
                <asp:TextBox ID="ClienteTxt" runat="server" ReadOnly="true" CssClass="form-input mt-1 block w-full bg-gray-100"></asp:TextBox>
            </div>
            
            <!-- Asignar Habitación -->
            <div class="mb-4">
                <label for="HabitacionDropdown" class="block text-sm font-medium text-gray-700">Asignar Habitación</label>
                <asp:DropDownList ID="HabitacionDropdown" runat="server" CssClass="form-select mt-1 block w-full">
                    <asp:ListItem Text="Seleccione una habitación" Value="" />
                </asp:DropDownList>
            </div>
            
            <!-- Tiempo de Estadía -->
            <div class="mb-4">
                <label for="EstadiaTxt" class="block text-sm font-medium text-gray-700">Tiempo de Estadía (en días)</label>
                <asp:TextBox ID="NochesTxt" runat="server" CssClass="form-input mt-1 block w-full" placeholder="Ej: 3"></asp:TextBox>
            </div>
            
            <!-- Comentarios -->
            <div class="mb-4">
                <label for="ComentariosTxt" class="block text-sm font-medium text-gray-700">Comentarios (opcional)</label>
                <asp:TextBox ID="ComentariosTxt" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-input mt-1 block w-full"></asp:TextBox>
            </div>
            
            <!-- Botones -->
            <div class="flex justify-end space-x-4">
                <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" CssClass="btn-secondary" OnClientClick="return confirm('¿Estás seguro de limpiar el formulario?');" />
                <asp:Button ID="BtnRegistrarHospedaje" runat="server" Text="Guardar Registro" CssClass="btn-primary" />
            </div>
        </div>
    </form>
</body>
</html>


