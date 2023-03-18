namespace Core.Utilities.Responses
{
    public class BaseResponseModel
    {
        public BaseResponseModel(bool hasException = false, string? exceptionContent = null)
        {
            this.hasException = hasException;
            this.exceptionContent = exceptionContent;
        }
        public BaseResponseModel(string exceptionContent)
        {
            hasException = true;
            this.exceptionContent = exceptionContent;
        }
        public BaseResponseModel(Exception exception)
        {
            hasException = true;
            exceptionContent = exception.Message;
        }
        public bool hasException { get; set; }
        public string? exceptionContent { get; set; }
    }

    public class DataResponseModel<T> : BaseResponseModel
    {
        public T? result { get; set; }
        public DataResponseModel(T? result, bool hasException = false, string? exceptionContent = null) :base(hasException,exceptionContent)
        {
            this.result = result;
            this.hasException = hasException;
            this.exceptionContent = exceptionContent;
        }
    } 

}
