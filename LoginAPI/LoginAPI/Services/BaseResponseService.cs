using LoginAPI.EnumTypes;
using LoginAPI.Models;

namespace LoginAPI.Services
{
    public class BaseResponseService
    {
        public BaseResponse GetSuccessResponse(object data) => new BaseResponse() { Status = (byte)Status.Success, Data = data, Message = "Process Succeded"};
        public BaseResponse GetSuccessResponse(object data, string message) => new BaseResponse() { Status = (byte)Status.Success, Data = data, Message = message };
        public BaseResponse GetErrorResponse(Exception ex) => new BaseResponse() { Status = (byte)Status.Fail, Data = ex, Message = ex.Message};
    }
}
