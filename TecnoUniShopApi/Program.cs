using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TecnoUniShopApi.SwaggerFilters; // Tu namespace

var builder = WebApplication.CreateBuilder(args);

// *** INICIO DE CONFIGURACION DE SERVICIOS ***

// 1. Agregar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 2. Configurar Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autenticacion JWT. Escribe 'Bearer' [espacio] y tu token.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.OperationFilter<AuthorizationOperationFilter>();
});


// 3. --- ¡¡AQUI ESTA EL CODIGO QUE VISUAL STUDIO ESTA IGNORANDO!! ---
// Configurar JWT (Tokens de seguridad)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// 4. Configurar Autorizacion
builder.Services.AddAuthorization();
// *** FIN DE CONFIGURACION DE SERVICIOS ***

var app = builder.Build();

// *** INICIO DE CONFIGURACION DE LA APP ***
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
// 5. ¡¡USAR AUTENTICACION!!
app.UseAuthentication(); // Primero autentica
app.UseAuthorization();  // Luego autoriza 

app.MapControllers();

app.Run();