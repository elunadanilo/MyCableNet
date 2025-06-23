
# 📺 CableNet - Gestión de Clientes y Servicios

Este proyecto es una solución de backend construida con **.NET 8** y **SQL Server** que permite gestionar clientes, servicios contratados, facturación y pagos para una empresa de telecomunicaciones ficticia llamada *CableNet*.

---

## 🧱 Arquitectura

El proyecto sigue la arquitectura **Clean Architecture**, estructurada en los siguientes proyectos:

- `MyCableNet.Domain`: Entidades.
- `MyCableNet.Application`: Interfaces, DTOs y servicios.
- `MyCableNet.Infrastructure`: Repositorios e implementación de acceso a datos con EF Core.
- `MyCableNet.API`: Proyecto principal que expone una API RESTful consumible por Swagger o cualquier cliente HTTP.

---

## 🚀 Tecnologías utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- Swagger
- AutoMapper
- Clean Architecture

---

## 🧑‍💻 Requisitos previos

- .NET 8 SDK
- SQL Server (local o en contenedor)
- Visual Studio 2022+ o Visual Studio Code
- Git
- (Opcional) Postman o alguna herramienta para consumir APIs

---

## 📥 Instrucciones de instalación

### 1. Clonar el repositorio

```bash
git clone https://github.com/elunadanilo/MyCableNet.git
cd MyCableNet
```

### 2. Configurar la cadena de conexión

Edita el archivo `MyCableNet.API/appsettings.json` y modifica la cadena `"DefaultConnection"`:

#### 🔸 Ejemplo con autenticación Windows:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MyCableNetDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

#### 🔸 Ejemplo con usuario y contraseña:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MyCableNetDb;User Id=sa;Password=TuClaveSegura123;"
}
```

### 3. Crear la base de datos

**No necesitas crearla manualmente.** Puedes crearla ejecutando las migraciones con EF Core:

```bash
cd MyCableNet.API
dotnet ef database update
```

> Asegúrate de tener instalada la herramienta de EF Core:
> ```bash
> dotnet tool install --global dotnet-ef
> ```

### 4. Ejecutar el proyecto

```bash
cd MyCableNet.API
dotnet run
```
## 📊 Procedimientos almacenados útiles

La base de datos incluye SPs útiles para reportes o Power BI:

- `EXEC dbo.SP_ObtenerIngresosMensuales @Ano = 2025;`
- `EXEC dbo.SP_ObtenerClientesMorosos @DiasVencidos =`

## 🧾 Compilación y publicación

Para compilar:

```bash
dotnet build
```

Para publicar:

```bash
dotnet publish -c Release -o ./publish
```
## Otros Archivos

Dentro del repositorio encontrarás una carpeta adicional llamada **`otros_archivos`**, la cual contiene recursos complementarios utilizados durante el desarrollo y entrega de esta prueba técnica. Esta carpeta incluye:

- 🗃 **Procedimientos Almacenados**: 
  - `SP_ObtenerClientesMorosos`
  - `SP_ObtenerIngresosMensuales`
  
- 📊 **Reportes Power BI**:
  - `ClientesMorosos.pbix`
  - `ReporteIngresosMes.pbix`

- 🧾 **Consultas SQL**:
  - `Top10ClientesPesoBruto2014.sql`
  - `ConteoTransaccionesMensuales2015.sql`

- 📄 **Documento General**:
  - `ASSESSMENT.docx`: Documento que describe toda la solución, incluyendo arquitectura, diagramas UML, entidad-relación, pruebas realizadas, scripts y explicaciones técnicas.

Esta carpeta permite visualizar de forma rápida y organizada la información crítica del proyecto, útil tanto para evaluación como para futuras referencias técnicas.


## ❓ Preguntas frecuentes

**¿Debo crear la base de datos manualmente?**  
No. Al ejecutar `dotnet ef database update`, se crea automáticamente con las tablas y estructura necesarias.

**¿La API tiene seguridad?**  
Actualmente, los endpoints están abiertos para facilitar las pruebas. Se puede agregar autenticación JWT en fases futuras.

## 📌 Notas finales

Este proyecto fue desarrollado como parte de un assessment técnico. Su estructura es modular y puede escalar fácilmente para agregar más entidades, validaciones o capas de seguridad.

## 📬 Contacto

**Estuardo Luna**  

## 📝 Licencia

Este proyecto no tiene fines comerciales. Está enfocado únicamente en fines académicos y de evaluación técnica.
