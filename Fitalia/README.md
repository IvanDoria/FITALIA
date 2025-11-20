# # Documentación Resumida de la API FITALIA

## 1. Arquitectura General
La API utiliza una arquitectura por capas:

**Controller → Service → Repository (DAO) → Base de Datos**

Responsabilidades:
- **Controllers:** Exponen endpoints HTTP.
- **Services:** Contienen lógica de negocio.
- **Repositories/DAO:** Acceso a la base de datos.
- **Entities:** Representan tablas.
- **Enumerations:** Tipos usados en el dominio.
- **Interfaces:** Contratos de servicios y repositorios.
- **Queries:** Consultas SQL centralizadas (si aplica).
- **Program/Config:** CORS, dependencias, conexión a la BD.

## 2. Estructura del Proyecto (Resumida)
```
FITALIA/
 ├── Controllers/
 ├── Services/
 │     └── Interfaces/
 ├── Data/ (Repositories)
 │     └── Interfaces/
 ├── Entities/
 ├── Enumerations/
 ├── Queries/
 ├── appsettings.json
 ├── Program.cs
 └── Startup.cs (si existe)
```

## 3. Componentes Principales

### 3.1 Controllers
Responsables de recibir solicitudes REST, manejar DTOs y devolver respuestas HTTP.

Ejemplos:
- Usuarios: GET, POST, PUT, DELETE
- Auth: login, registro
- Rutinas: gestión de rutinas y ejercicios
- Progreso: métricas físicas del usuario

Inyectan servicios mediante interfaces.

### 3.2 Services
Implementan la lógica del negocio:
- Validaciones
- Reglas del dominio
- Coordinación de repositorios
- Transformación entre entidades y DTOs

Registrados en *Program.cs* con **AddScoped**.

### 3.3 Repositories / DAO
Permiten acceso a la base de datos:
- CRUD
- Consultas SQL o uso de EF Core
- Transacciones

### 3.4 Interfaces
Contratos de servicios y repositorios.
Facilitan desacoplamiento y pruebas.

### 3.5 Entities
Modelos que representan las tablas.

### 3.6 Enumerations
Tipos para roles, estados o categorías.

### 3.7 Queries
Clases estáticas para centralizar SQL.

---

## 4. Conexión a Base de Datos (appsettings.json)
```json
{
  "ConnectionStrings": {
    "FitaliaDB": "Server=TU_SERVIDOR;Database=FITALIA;User Id=USUARIO;Password=CLAVE;"
  },
  "Jwt": {
    "Key": "clave_super_secreta",
    "Issuer": "FitaliaAPI",
    "Audience": "FitaliaFrontend"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.Hosting.Lifetime": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## 5. Configuración CORS (Program.cs)
```csharp
var MyCors = "_myCors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyCors, builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

app.UseCors(MyCors);
```

---

## 6. Ejecución del Proyecto

### Clonar el repositorio
```
git clone https://github.com/IvanDoria/FITALIA.git
```

### Configurar appsettings.json
- Conexión a SQL Server  
- JWT (si aplica)

### Restaurar dependencias
```
dotnet restore
```

### Crear base de datos (si usa EF Core)
```
dotnet ef database update
```

### Ejecutar la API
```
dotnet run
```

### Abrir Swagger
```
https://localhost:5001/swagger
```

---

## 7. Funcionalidades Principales
- CRUD de usuarios  
- Autenticación  
- Gestión de rutinas y ejercicios  
- Registro de progreso físico  
- Roles y permisos  
- CORS para integración con frontend  

---

## 8. Posibles Extensiones
- Refresh tokens  
- Estadísticas avanzadas  
- Recomendaciones automáticas  
- Notificaciones  
- Versionado de API  
