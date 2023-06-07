namespace Core.Models
{
    public class BaseResponseModel
    {
        public abstract class BaseResponse
        {
            public BaseResponse(bool isCustomException = true, bool isValidationError = false, List<ErrorResponseContent>? errorContents = null)
            {
                IsCustomException = isCustomException;
                ErrorContents = errorContents;
            }
            public bool IsCustomException { get; set; }
            public bool IsValidationError { get; set; }
            public List<ErrorResponseContent>? ErrorContents { get; set; }
        }

        public class ErrorResponseContent
        {
            public ErrorResponseContent(string? title, string? content)
            {
                Title = title;
                Content = content;
            }

            public string? Title { get; set; }
            public string? Content { get; set; }

        }

        public class ServiceResponse<T> : BaseResponse
        {
            public T? Value { get; set; }

            public ServiceResponse(bool isCustomException = false, bool isValidationError = false, List<ErrorResponseContent>? errorContents = null) : base(isCustomException, isValidationError, errorContents)
            {
            }
            public ServiceResponse(T? value, bool isCustomException = false, bool isValidationError = false, List<ErrorResponseContent>? errorContents = null) : base(isCustomException, isValidationError, errorContents)
            {
                Value = value;
            }
        }

        public class ServiceResponse : BaseResponse
        {

            public ServiceResponse(bool isCustomException = true, bool isValidationError = false, List<ErrorResponseContent>? errorContents = null) : base(isCustomException, isValidationError, errorContents)
            {
            }
        }

    }
}