using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Planner.Services.Filters
{
    [ExcludeFromCodeCoverage]
    public class ExtendedApiDescriptionProvider : IApiDescriptionProvider
    {
        private DefaultApiDescriptionProvider _base;

        public ExtendedApiDescriptionProvider(IOptions<MvcOptions> optionsAccessor, IInlineConstraintResolver constraintResolver, IModelMetadataProvider modelMetadataProvider)
        {
            _base = new DefaultApiDescriptionProvider(optionsAccessor, constraintResolver, modelMetadataProvider);
        }

        public int Order => -1000;

        public void OnProvidersExecuted(ApiDescriptionProviderContext context)
        {
        }

        public void OnProvidersExecuting(ApiDescriptionProviderContext context)
        {
            foreach (var r in context.Results)
            {
                foreach (var detailResponse in r.ActionAttributes().OfType<DetailResponseAttribute>())
                {
                    var descriptor = r.ActionDescriptor as ControllerActionDescriptor;
                    if (descriptor == null)
                        return;

                    var baseType = descriptor.ControllerTypeInfo.BaseType;

                    var detailType = baseType.GenericTypeArguments.FirstOrDefault(t => t.Name.EndsWith("Details"));

                    r.SupportedResponseTypes.Add(new ApiResponseType() { StatusCode = detailResponse.StatusCode, Type = detailType });
                }
            }
        }
    }
}