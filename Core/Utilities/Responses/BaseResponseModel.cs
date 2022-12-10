using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Responses
{
    public class BaseResponseModel<T>
    {
        public BaseResponseModel(T result, bool hasException = false, string exceptionContent = null)
        {
            this.result = result;
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
        public T? result { get; set; }
        public bool hasException { get; set; }
        public string exceptionContent { get; set; }
    }

}
