using Filters.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Filters.Filters
{
    public class MySampleExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public MySampleExceptionFilter(IWebHostEnvironment webHostEnvironment,
            IModelMetadataProvider modelMetadataProvider)
        {
            _webHostEnvironment = webHostEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is MyException)
                context.Result = new JsonResult($"Fallo en la aplicacion " +
                    $"{_webHostEnvironment.ApplicationName}. " +
                    $"Exception del tipo {context.Exception.GetType}");
        }
    }
}
