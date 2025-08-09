School API (ASP.NET Core 8 + EF Core + SQL Server)

Descripción
API REST para una institución educativa con tablas de Students, Professors, Courses y Grades. Incluye autenticación JWT, Swagger, validación con FluentValidation, paginación y filtros, campos de auditoría y seeding.

Requisitos
- .NET 8 SDK
- SQL Server (local o remoto)

Configuración
1) Variables de entorno (recomendado):
   - ASPNETCORE_ENVIRONMENT=Development
   - ConnectionStrings__Default=Server=.;Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True
   - Jwt__Issuer=SchoolApi
   - Jwt__Audience=SchoolApiClients
   - Jwt__Key=<clave-secreta-larga>

   Alternativa: usar User Secrets en el proyecto `Api`.

2) Migraciones y base de datos:
   - Desde el directorio `School/Api` o raíz de la solución:
     dotnet tool restore
     dotnet build
     dotnet ef database update --project ../Infrastructure --startup-project ./

   Esto creará el esquema e insertará datos de ejemplo (25 estudiantes, 3 profesores, 5 cursos).

Ejecución
dotnet run --project Api

La API arrancará en `http://localhost:5008` y `https://localhost:7179` (ver `launchSettings.json`).

Swagger/OpenAPI
- Navega a `http://localhost:5008/swagger`.
- Autenticación: pulsa Authorize e ingresa `Bearer {token}`.

Autenticación
- Endpoint de token de prueba: `POST /auth/token?username=admin&password=admin`.
- Respuesta:
  { "access_token": "<jwt>" }
- Copia el token y úsalo como `Authorization: Bearer <jwt>` en las llamadas.

Endpoints principales
- Students
  - GET `/api/students?identification=&firstName=&lastName=&birthDateFrom=&birthDateTo=&page=1&pageSize=10`
  - GET `/api/students/identification/{idNumber}`
  - GET `/api/students/{id}`
  - POST `/api/students`
    { "identificationNumber": "STU999999", "firstName": "John", "lastName": "Doe", "birthDate": "2000-01-01" }
  - PUT `/api/students/{id}`
    { "firstName": "John", "lastName": "Smith", "birthDate": "2001-02-02" }
  - DELETE `/api/students/{id}`

- Professors
  - GET `/api/professors?document=&name=&email=&page=1&pageSize=10`
  - CRUD completo

- Courses
  - GET `/api/courses?code=&name=&professorId=&page=1&pageSize=10`
  - CRUD completo

- Grades
  - GET `/api/grades?studentId=&courseId=&type=&min=&max=&page=1&pageSize=10`
  - CRUD completo

Validación
- FluentValidation valida DTOs en requests. Respuestas inválidas retornan 400 con `ValidationProblemDetails`.

Auditoría y borrado lógico
- Entidades heredan de `BaseEntity` con `CreatedAt/By`, `UpdatedAt/By`, `IsActive`.
- Filtro global excluye `IsActive=false`.
- El contexto transforma `Delete` en soft‑delete.

Colección de Postman
- Archivo: `docs/School.postman_collection.json`.
- Variables: `baseUrl` (default `http://localhost:5008`) y `token`.
1) Ejecuta `Auth - Get Token` y guarda `access_token` en `token`.
2) Ejecuta requests de Students/Professors/Courses/Grades.

