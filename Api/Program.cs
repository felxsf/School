using Api.Services;
using Application;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Students;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using School.Api.Services;
using School.Application.Courses;
using School.Application.Grades;
using School.Application.Professors;
using School.Application.Students;
using School.Infrastructure.Courses;
using School.Infrastructure.Grades;
using School.Infrastructure.Professors;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using School.Application.Abstractions;
using School.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<SchoolDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Services
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IGradeService, GradeService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<School.Application.Abstractions.IUserContext, UserContext>();

builder.Services.AddControllers();


// Auto‑validación de FluentValidation -> 400 con ValidationProblemDetails
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<School.Application.Validation.StudentCreateDtoValidator>();

// ProblemDetails (RFC 7807) para excepciones no controladas y 400 de modelo
builder.Services.AddProblemDetails(options =>
{
    // Mostrar detalles de excepción solo en desarrollo
    //options.IncludeExceptionDetails = (ctx, ex) => builder.Environment.IsDevelopment();
    options.CustomizeProblemDetails = ctx =>
    {
        ctx.ProblemDetails.Extensions["traceId"] = ctx.HttpContext.TraceIdentifier;
    };
});

// JWT
var jwt = builder.Configuration.GetSection("Jwt");
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt["Issuer"],
            ValidAudience = jwt["Audience"],
            IssuerSigningKey = key
        };
    });

builder.Services.AddAuthorization();

// Swagger + JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "School API", Version = "v1" });
    var scheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bearer {token}"
    };
    c.AddSecurityDefinition("Bearer", scheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement { { scheme, Array.Empty<string>() } });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Emisor de token de prueba
app.MapPost("/auth/token", (string username, string password) =>
{
    if (username == "admin" && password == "admin")
    {
        var handler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new[] {
                new System.Security.Claims.Claim("sub", username)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            Issuer = jwt["Issuer"],
            Audience = jwt["Audience"],
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        };
        var token = handler.CreateToken(tokenDescriptor);
        return Results.Ok(new { access_token = handler.WriteToken(token) });
    }
    return Results.Unauthorized();
});

app.Run();
