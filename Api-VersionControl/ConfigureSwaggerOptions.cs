using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api_VersionControl
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "My .NetApi RestFull",
                Version = description.ApiVersion.ToString(),
                Description = "This is my first Api Versioning control",
                Contact = new OpenApiContact()
                {
                    Email = "benaventmarc@gmail.com",
                    Name = "Marc",                    
                }
            };
            if (description.IsDeprecated)
            {
                info.Description += "This Api version has been deprecated";
            }
            return info;
        }
        public void Configure(SwaggerGenOptions options)
        {
            // Add Swagger Documentation for each versions
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }
    }
}
