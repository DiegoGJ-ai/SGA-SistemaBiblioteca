namespace SGA.Model.Responses
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public static ApiResponse Ok(string message = "")
            => new ApiResponse { Success = true, Message = message };

        public static ApiResponse Fail(string message)
            => new ApiResponse { Success = false, Message = message };
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T? Data { get; set; }

        public static ApiResponse<T> Ok(T data, string message = "")
            => new ApiResponse<T> { Success = true, Data = data, Message = message };

        public new static ApiResponse<T> Fail(string message)
            => new ApiResponse<T> { Success = false, Message = message };
    }
}
