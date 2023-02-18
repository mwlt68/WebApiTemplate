using System.Text.Json;
using Core.Utilities.Responses;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Template.API.Interceptors
{
    public class UseCustomErrorModelInterceptor : IValidatorInterceptor
    {
        private static string SerializeError(ValidationFailure failure)
        {
            var error = new ValidationErrorModel(failure.PropertyName, failure.ErrorMessage);
            return JsonSerializer.Serialize(error);
        }

        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return commonContext;
        }

        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
        {
            var failures = result.Errors
                .Select(error => new ValidationFailure(error.PropertyName, SerializeError(error)));

            return new ValidationResult(failures);
        }
    }
}