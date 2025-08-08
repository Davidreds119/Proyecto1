# Sistema de Gestión de Clientes

## 📋 Descripción

Sistema web desarrollado en ASP.NET Core 8.0 para la gestión de clientes. Esta aplicación permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre la información de clientes, incluyendo funcionalidades de exportación de datos en formatos XML y JSON.

## 🚀 Características

- **Gestión completa de clientes**: CRUD operations
- **Interfaz web moderna**: Desarrollada con ASP.NET Core MVC
- **Base de datos SQL Server**: Utilizando Entity Framework Core
- **Exportación de datos**: Soporte para exportar en XML y JSON
- **Validación de datos**: Implementada con Data Annotations
- **Compilación en tiempo de ejecución**: Para desarrollo más ágil

## 🛠️ Tecnologías Utilizadas

- **.NET 8.0**: Framework de desarrollo
- **ASP.NET Core MVC**: Patrón de arquitectura web
- **Entity Framework Core 9.0.6**: ORM para acceso a datos
- **SQL Server**: Base de datos
- **NPOI 2.7.3**: Para manejo de archivos Excel
- **Razor Runtime Compilation**: Para desarrollo más rápido

## 📁 Estructura del Proyecto

```
Proyecto1/
├── Controllers/
│   ├── HomeController.cs
│   └── ClientesController.cs
├── Models/
│   ├── Clientes.cs
│   ├── Cliente2025Context.cs
│   └── ErrorViewModel.cs
├── Views/
├── wwwroot/
├── Program.cs
├── appsettings.json
└── Prueba 1.csproj
```

## 🗄️ Modelo de Datos

### Clientes
- `pkclientes` (int, PK): Identificador único del cliente
- `nombre` (string, 50): Nombre del cliente
- `apellido` (string, 50): Primer apellido
- `apellido2` (string, 50): Segundo apellido
- `cedula` (string, 20): Número de cédula

## 🔧 Configuración

### Prerrequisitos
- .NET 8.0 SDK
- SQL Server
- Visual Studio 2022 o VS Code

### Instalación

1. **Clonar el repositorio**
   ```bash
   git clone [URL_DEL_REPOSITORIO]
   cd Proyecto1
   ```

2. **Configurar la base de datos**
   - Asegúrate de tener SQL Server instalado y ejecutándose
   - Configura la cadena de conexión en `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=Cliente2025;Trusted_Connection=true;TrustServerCertificate=true;"
     }
   }
   ```

3. **Ejecutar las migraciones**
   ```bash
   dotnet ef database update
   ```

4. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```

5. **Acceder a la aplicación**
   - Abre tu navegador y ve a `https://localhost:5001` o `http://localhost:5000`

## 📖 Uso

### Funcionalidades Principales

1. **Listar Clientes**: Visualizar todos los clientes registrados
2. **Crear Cliente**: Agregar nuevos clientes al sistema
3. **Editar Cliente**: Modificar información de clientes existentes
4. **Eliminar Cliente**: Remover clientes del sistema
5. **Ver Detalles**: Consultar información detallada de un cliente
6. **Exportar Datos**: Exportar la lista de clientes en formato XML o JSON

### Endpoints API

- `GET /Clientes` - Listar todos los clientes
- `GET /Clientes/Details/{id}` - Ver detalles de un cliente
- `GET /Clientes/Create` - Formulario para crear cliente
- `POST /Clientes/Create` - Crear nuevo cliente
- `GET /Clientes/Edit/{id}` - Formulario para editar cliente
- `POST /Clientes/Edit/{id}` - Actualizar cliente
- `GET /Clientes/Delete/{id}` - Confirmar eliminación
- `POST /Clientes/Delete/{id}` - Eliminar cliente
- `GET /Clientes/ExportarXml` - Exportar datos en XML
- `GET /Clientes/ExportarJson` - Exportar datos en JSON

## 🔒 Seguridad

- Validación de tokens anti-falsificación (CSRF protection)
- Validación de modelos con Data Annotations
- Manejo de errores centralizado

## 🚀 Despliegue

### Desarrollo
```bash
dotnet run --environment Development
```

### Producción
```bash
dotnet publish -c Release
dotnet run --environment Production
```

## 📝 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Por favor, abre un issue o un pull request para sugerir cambios o mejoras.

## 📞 Soporte

Para soporte técnico o preguntas sobre el proyecto, por favor contacta al equipo de desarrollo.

---

**Desarrollado con ❤️ usando ASP.NET Core** 