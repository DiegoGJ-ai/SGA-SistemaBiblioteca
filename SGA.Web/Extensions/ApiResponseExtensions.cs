using SGA.Model.Responses;

namespace SGA.Web.Extensions
{
    public static class ApiResponseExtensions
    {
        public static bool IsSuccess(this ApiResponse response)
            => response != null && response.Success;
    }
}
