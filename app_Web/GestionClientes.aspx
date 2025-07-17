<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GestionClientes.aspx.vb" Inherits="app_Web.GestionClientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Gestión de Clientes</title>
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet" />
</head>
<body class="bg-gray-100">
    <form id="form1" runat="server" class="container mx-auto py-8 px-4 sm:px-6 lg:px-8">
        <div class="max-w-4xl mx-auto bg-white rounded-lg shadow-md p-6">
            <h1 class="text-2xl font-bold text-gray-800 text-center mb-6">Gestión de Clientes</h1>

            <!-- Formulario de Cliente -->
            <div class="grid grid-cols-1 md:grid-cols-2 gap-4 mb-4">
                <div>
                    <label for="CITxt" class="block text-sm font-medium text-gray-700">CI</label>
                    <asp:TextBox ID="CITxt" runat="server" CssClass="form-input mt-1 block w-full"></asp:TextBox>
                </div>
                <div>
                    <label for="NombreTxt" class="block text-sm font-medium text-gray-700">Nombre</label>
                    <asp:TextBox ID="NombreTxt" runat="server" CssClass="form-input mt-1 block w-full"></asp:TextBox>
                </div>
                <div>
                    <label for="ApellidoTxt" class="block text-sm font-medium text-gray-700">Apellido</label>
                    <asp:TextBox ID="ApellidoTxt" runat="server" CssClass="form-input mt-1 block w-full"></asp:TextBox>
                </div>
                <div>
                    <label for="TelefonoTxt" class="block text-sm font-medium text-gray-700">Teléfono</label>
                    <asp:TextBox ID="TelefonoTxt" runat="server" CssClass="form-input mt-1 block w-full"></asp:TextBox>
                </div>
                <div class="md:col-span-2">
                    <label for="EmailTxt" class="block text-sm font-medium text-gray-700">Email</label>
                    <asp:TextBox ID="EmailTxt" runat="server" CssClass="form-input mt-1 block w-full"></asp:TextBox>
                </div>
            </div>

            <!-- Botones -->
            <div class="flex justify-end space-x-4 mb-4">
                <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" CssClass="btn-primary" />
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn-secondary" />
                <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="btn-danger" />
            </div>

            <!-- Tabla de Clientes -->
            <asp:GridView ID="ClientesGridView" runat="server" AutoGenerateColumns="False" CssClass="min-w-full bg-white" DataKeyNames="CI" OnSelectedIndexChanged="ClientesGridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="CI" HeaderText="CI" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
