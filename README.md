# API de Gestión de Escuelas de Música

Este proyecto es una **API RESTful** desarrollada con **ASP.NET Core Web API** y **Entity Framework Core**, diseñada para administrar escuelas de música, profesores y alumnos. Incluye funcionalidades completas de gestión (CRUD), relaciones entre entidades y ejecución de procedimientos almacenados para optimizar el acceso a datos.

---

## Tecnologías utilizadas

- **ASP.NET Core Web API** (.NET 8)
- **Entity Framework Core** (Todas en Verisón 8)
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.Relational`
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Tools`
- **SQL Server** (base de datos relacional)
- **Swagger** (documentación interactiva de la API)

---

##  Funcionalidades principales

- Gestión de Escuelas (crear, leer, actualizar, eliminar)
- Gestión de Alumnos y Profesores
- Asignación de profesores a escuelas
- Asignación de alumnos a profesores
- Inscripción de alumnos en escuelas
- Consultas relacionales:
  - Alumnos asignados por profesor (incluyendo la escuela)
---

##  Pasos para correr el proyecto

### 1. Clonar el repositorio

```bash
git clone https://github.com/erickha16/PruebaEscuelas_ErickAdiranHernandezAburto
cd PruebaEscuelas_ErickAdiranHernandezAburto
```

### 2. Condigurar cadena de conexión

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=NombreDeTuBD;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 3. Crear Base de datos

Ejecutar el script SQL_ESCUELA.sql dentro de SQL Server Managment Studio


### 4. Ejecutar la API

Puedes correr la Api desde Visual Studio o tilizando el comando:

```bash
dotnet run
```
