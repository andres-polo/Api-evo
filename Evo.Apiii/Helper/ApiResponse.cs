using System.Net;

namespace Evo.Apiii.Helper
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object? Result { get; set; }
        public ApiErrorResponse? Error { get; set; }
    }

    public class ApiErrorResponse
    {
        public string Message { get; set; } = String.Empty;
        public object? Info { get; set; }

    }
}
