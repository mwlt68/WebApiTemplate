using static Core.Models.BaseResponseModel;

namespace Core.Exceptions
{
    public abstract class CustomBaseException : Exception
    {
        public List<ErrorResponseContent>? ErrorContents { get; set; }
        public CustomBaseException(params ErrorResponseContent[] errorResponseContent) : base(errorResponseContent.FirstOrDefault()?.Content)
        {
            ErrorContents = errorResponseContent.ToList();
        }
        public CustomBaseException(string? title, string? content) : base(content)
        {
            ErrorContents = new List<ErrorResponseContent>
            {
                new ErrorResponseContent(title ?? "Undefined",content)
            };
        }
    }
}
