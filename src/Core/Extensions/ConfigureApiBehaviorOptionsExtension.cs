using System.Text.Json;
using Core.Utilities.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ConfigureApiBehaviorOptionsExtension
    {
        public static IMvcBuilder AddConfigureApiBehaviorOptions(this IMvcBuilder builder)
        {
            return builder.ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var errors = context.ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => GetValidationErrorModels(e.ErrorMessage));
                        var validationErrors = errors.Where(x=> x != null).Select(x=> x!).ToList();
                        var validationErrorResponseModel = new ValidationErrorResponseModel(validationErrors); 
                        return new BadRequestObjectResult(validationErrorResponseModel);
                    };
                });
        }
        private static  ValidationErrorModel? GetValidationErrorModels(string message)
        {
            try
            {
                return JsonSerializer.Deserialize<ValidationErrorModel?>(message);
            }
            catch
            {
                return null;
            }
        }

    }
}