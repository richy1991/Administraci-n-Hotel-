<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistrarHospedajeWF.aspx.vb" Inherits="app_Web.RegistrarHospedajeWF" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hotel Beni - Registrar Hospedaje</title>
    <!-- Estilos de Tailwind CSS -->
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@3.3.3/dist/tailwind.min.css" rel="stylesheet" />
    <!-- Estilos personalizados -->
    <style>
        body {
            background-image: url('https://virtualbackgrounds.site/wp-content/uploads/2020/07/reception-desk-at-a-luxury-hotel.jpg');
            background-size: cover;
            background-position: center;
            background-attachment: fixed;
        }
        .btn-primary {
            background-color: #3b82f6;
            color: white;
            font-weight: bold;
            padding: 0.75rem 1.5rem;
            border-radius: 0.5rem;
            transition: background-color 0.3s;
            display: inline-flex;
            align-items: center;
        }
        .btn-primary:hover {
            background-color: #2563eb;
        }
        .btn-secondary {
            background-color: #6b7280;
            color: white;
            font-weight: bold;
            padding: 0.75rem 1.5rem;
            border-radius: 0.5rem;
            transition: background-color 0.3s;
            display: inline-flex;
            align-items: center;
        }
        .btn-secondary:hover {
            background-color: #4b5563;
        }
        .form-input {
            border-radius: 0.5rem;
            border-color: #d1d5db;
        }
        .icon {
            width: 1.25rem;
            height: 1.25rem;
            margin-right: 0.5rem;
        }
    </style>
</head>
<body class="bg-blue-50">
    <form id="form1" runat="server" class="min-h-screen flex flex-col bg-black bg-opacity-20">
        <!-- Encabezado -->
        <header class="bg-white shadow-md">
            <div class="container mx-auto px-4 sm:px-6 lg:px-8 py-4 flex justify-between items-center">
                <div class="flex items-center">
                    <img src="https://img.freepik.com/vector-premium/logotipo-hotel-diseno-plano_23-2148161127.jpg" alt="Hotel Beni Logo" class="h-12 mr-4" />
                    <h1 class="text-3xl font-bold text-gray-800">Hotel Beni</h1>
                </div>
                <nav>
                    <a href="#" class="text-gray-600 hover:text-blue-500 px-3 py-2">Inicio</a>
                    <a href="#" class="text-gray-600 hover:text-blue-500 px-3 py-2">Habitaciones</a>
                    <a href="#" class="text-gray-600 hover:text-blue-500 px-3 py-2">Contacto</a>
                </nav>
            </div>
        </header>

        <!-- Contenido Principal -->
        <main class="flex-grow container mx-auto py-8 px-4 sm:px-6 lg:px-8">
            <div class="max-w-4xl mx-auto bg-white rounded-2xl shadow-xl p-8 bg-opacity-95">
                <h2 class="text-4xl font-extrabold text-gray-900 text-center mb-8">Registrar un Nuevo Hospedaje</h2>

                <!-- Sección de Búsqueda de Cliente -->
                <div class="bg-gray-50 p-6 rounded-lg mb-8">
                    <h3 class="text-xl font-semibold text-gray-800 mb-4">Paso 1: Buscar Cliente</h3>
                    <div class="grid grid-cols-1 md:grid-cols-3 gap-6">
                        <div class="md:col-span-2">
                            <label for="CITxt" class="block text-lg font-medium text-gray-700">Carnet de Identidad (CI)</label>
                            <asp:TextBox ID="CITxt" runat="server" CssClass="form-input mt-2 block w-full text-lg" placeholder="Ej: 12345678"></asp:TextBox>
                        </div>
                        <div class="md:self-end">
                            <asp:Button ID="BtnBuscar" runat="server" Text="Buscar Cliente" CssClass="btn-primary w-full">
                                <ContentTemplate>
                                    <svg class="icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                                        <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd" />
                                    </svg>
                                    Buscar Cliente
                                </ContentTemplate>
                            </asp:Button>
                        </div>
                    </div>
                </div>

                <!-- Sección de Información y Registro -->
                <div class="grid grid-cols-1 md:grid-cols-2 gap-8">
                    <!-- Columna Izquierda: Información del Cliente y Habitación -->
                    <div>
                        <h3 class="text-xl font-semibold text-gray-800 mb-4">Paso 2: Completar Información</h3>
                        <div class="space-y-6">
                            <div>
                                <label for="ClienteTxt" class="block text-lg font-medium text-gray-700">Nombre del Cliente</label>
                                <asp:TextBox ID="ClienteTxt" runat="server" ReadOnly="true" CssClass="form-input mt-2 block w-full bg-gray-200 text-lg"></asp:TextBox>
                            </div>
                            <div>
                                <label for="HabitacionDropdown" class="block text-lg font-medium text-gray-700">Asignar Habitación</label>
                                <asp:DropDownList ID="HabitacionDropdown" runat="server" CssClass="form-select mt-2 block w-full text-lg">
                                    <asp:ListItem Text="Seleccione una habitación disponible" Value="" />
                                </asp:DropDownList>
                            </div>
                            <div>
                                <label for="NochesTxt" class="block text-lg font-medium text-gray-700">Tiempo de Estadía (días)</label>
                                <asp:TextBox ID="NochesTxt" runat="server" CssClass="form-input mt-2 block w-full text-lg" placeholder="Ej: 3"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- Columna Derecha: Comentarios y Acciones -->
                    <div>
                        <h3 class="text-xl font-semibold text-gray-800 mb-4">Paso 3: Finalizar</h3>
                        <div class="space-y-6">
                            <div>
                                <label for="ComentariosTxt" class="block text-lg font-medium text-gray-700">Comentarios Adicionales</label>
                                <asp:TextBox ID="ComentariosTxt" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-input mt-2 block w-full text-lg" placeholder="Añadir notas o peticiones especiales..."></asp:TextBox>
                            </div>
                            <div class="flex justify-end space-x-4 mt-8">
                                <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" CssClass="btn-secondary" OnClientClick="return confirm('¿Estás seguro de limpiar el formulario?');" >
                                    <ContentTemplate>
                                        <svg class="icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                                            <path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd" />
                                        </svg>
                                        Limpiar
                                    </ContentTemplate>
                                </asp:Button>
                                <asp:Button ID="BtnRegistrarHospedaje" runat="server" Text="Guardar Registro" CssClass="btn-primary" >
                                    <ContentTemplate>
                                        <svg class="icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                                            <path d="M7.5 3.75A1.75 1.75 0 005.75 5.5v1.5h-1.5a.75.75 0 000 1.5h1.5v4.5h-1.5a.75.75 0 000 1.5h1.5v1.5A1.75 1.75 0 007.5 18h5a1.75 1.75 0 001.75-1.75v-1.5h1.5a.75.75 0 000-1.5h-1.5v-4.5h1.5a.75.75 0 000-1.5h-1.5v-1.5A1.75 1.75 0 0012.5 3.75h-5zM9 5.5a.25.25 0 01.25-.25h1.5a.25.25 0 01.25.25v1.5h-2v-1.5zm-1.5 4.5v-1.5h5v1.5h-5z" />
                                        </svg>
                                        Guardar Registro
                                    </ContentTemplate>
                                </asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>

        <!-- Pie de Página -->
        <footer class="bg-white mt-auto">
            <div class="container mx-auto py-6 px-4 sm:px-6 lg:px-8 text-center text-gray-600">
                &copy; <%# DateTime.Now.Year %> Hotel Beni. Todos los derechos reservados.
            </div>
        </footer>
    </form>
</body>
</html>


