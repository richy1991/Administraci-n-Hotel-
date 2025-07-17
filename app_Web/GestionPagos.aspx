<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GestionPagos.aspx.vb" Inherits="app_Web.GestionPagos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Gestión de Pagos</title>
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet" />
</head>
<body class="bg-gray-100">
    <form id="form1" runat="server" class="container mx-auto py-8 px-4 sm:px-6 lg:px-8">
        <div class="max-w-4xl mx-auto bg-white rounded-lg shadow-md p-6">
            <h1 class="text-2xl font-bold text-gray-800 text-center mb-6">Gestión de Pagos</h1>

            <!-- Formulario de Pago -->
            <div class="grid grid-cols-1 md:grid-cols-2 gap-4 mb-4">
                <div>
                    <label for="IDHospedajeTxt" class="block text-sm font-medium text-gray-700">ID de Hospedaje</label>
                    <asp:TextBox ID="IDHospedajeTxt" runat="server" CssClass="form-input mt-1 block w-full"></asp:TextBox>
                </div>
                <div>
                    <label for="MontoTxt" class="block text-sm font-medium text-gray-700">Monto</label>
                    <asp:TextBox ID="MontoTxt" runat="server" CssClass="form-input mt-1 block w-full"></asp:TextBox>
                </div>
                <div>
                    <label for="MetodoPagoDdl" class="block text-sm font-medium text-gray-700">Método de Pago</label>
                    <asp:DropDownList ID="MetodoPagoDdl" runat="server" CssClass="form-select mt-1 block w-full">
                        <asp:ListItem Text="Efectivo" Value="Efectivo" />
                        <asp:ListItem Text="Tarjeta de Crédito" Value="Tarjeta de Crédito" />
                        <asp:ListItem Text="Tarjeta de Débito" Value="Tarjeta de Débito" />
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Botones -->
            <div class="flex justify-end space-x-4 mb-4">
                <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" CssClass="btn-primary" />
            </div>

            <!-- Tabla de Pagos -->
            <asp:GridView ID="PagosGridView" runat="server" AutoGenerateColumns="False" CssClass="min-w-full bg-white">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="IDHospedaje" HeaderText="ID de Hospedaje" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Monto" HeaderText="Monto" />
                    <asp:BoundField DataField="MetodoPago" HeaderText="Método de Pago" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
