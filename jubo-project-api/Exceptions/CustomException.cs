using jubo_project_api.Models;

namespace jubo_project_api.Exceptions
{
    public class CustomException : Exception
    {
        protected readonly int _statusCode;
        private readonly string _message;
        public CustomException(CustomStatusCode customStatusCode, string message) 
        {
            _statusCode = (int)customStatusCode;
            _message = message;
        }

        public int StatusCode { get { return _statusCode; } }
        public string Message {  get { return _message; } }

        public ExceptionResponse GetExceptionResponse() 
            => new ExceptionResponse { StatusCode = _statusCode, Message = _message };
    }

    //--- 可持續新增自定義的 Exception，先以Order在做更新時找不到更新的檔案為例子
    public class NotFoundException : CustomException
    { 
        public NotFoundException(string message): base(CustomStatusCode.CustomNotFound, message) { }
    }

    public enum CustomStatusCode
    { 
        CustomNotFound = 701
    }
}
