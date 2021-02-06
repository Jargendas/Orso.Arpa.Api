using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Orso.Arpa.Api.ModelBinding
{
    public class SwaggerAuthorizeOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            IEnumerable<AuthorizeAttribute> authAttributes = context.MethodInfo
                .GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>();

            IEnumerable<string> policyAttributes = authAttributes
                .Where(attr => attr.Policy != null)
                .Select(attr => attr.Policy)
                .Distinct();

            if (policyAttributes.Any())
            {
                operation.Responses.Add("403", new OpenApiResponse { Description = $"If current user does not meet policy '{policyAttributes.First()}'" });
                var oAuthScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                };
            }

            IEnumerable<string> roleAttributes = authAttributes
                .Where(attr => attr.Roles != null)
                .Select(attr => attr.Roles)
                .Distinct();

            if (roleAttributes.Any())
            {
                operation.Responses.Add("403", new OpenApiResponse { Description = $"If current user does not have the role of '{roleAttributes.First()}'" });
                var oAuthScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                };
            }
        }
    }
}