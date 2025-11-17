// ---- Archivo: SwaggerFilters/AuthorizationOperationFilter.cs ----

using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

// ¡¡ASEGURATE DE QUE EL NAMESPACE SEA EL CORRECTO!!
namespace TecnoUniShopApi.SwaggerFilters
{
    public class AuthorizationOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // 1. Revisa si el metodo o la clase tienen [AllowAnonymous]
            var hasAllowAnonymous = context.MethodInfo.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any() ||
                                    context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any();

            // 2. Si tiene [AllowAnonymous], no le pongas candado.
            if (hasAllowAnonymous)
            {
                operation.Security = new List<OpenApiSecurityRequirement>();
                return;
            }

            // 3. Revisa si el metodo o la clase tienen [Authorize]
            var hasAuthorize = context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                               context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            // 4. Si NO tiene [Authorize], no le pongas candado.
            if (!hasAuthorize)
            {
                operation.Security = new List<OpenApiSecurityRequirement>();
                return;
            }

            // 5. SI LLEGAMOS AQUI, es que SI tiene [Authorize] y NO tiene [AllowAnonymous]
            // ¡PONER EL CANDADO!
            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" // Debe coincidir con el Id en AddSecurityDefinition
                            }
                        },
                        new List<string>()
                    }
                }
            };
        }
    }
}