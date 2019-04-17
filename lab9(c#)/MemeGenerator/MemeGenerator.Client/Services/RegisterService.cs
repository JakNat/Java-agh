using MemeGenerator.Client.Requests;
using MemeGenerator.Model.Dto;
using MemeGenerator.Model.Responses;
using NetworkCommsDotNet;
using System;
using System.Threading.Tasks;

namespace MemeGenerator.Client.Services
{
    public class RegisterService
    {
        private readonly IClientRequests clientRequests;

        public RegisterService(IClientRequests clientRequests)
        {
            this.clientRequests = clientRequests;
        }

        public async Task<BaseResponseDto> RegisterButtonAction(RegisterDto registerDto)
        {
            BaseResponseDto response;
            try
            {
                response = await Task.Run(() => clientRequests.RegisterRequest(registerDto));
            }
            catch (ExpectedReturnTimeoutException)
            {
                response = new BaseResponseDto() { Message = ResponseMessage.TimeOut };
            }
            catch (Exception)
            {
                response = new BaseResponseDto() { Message = ResponseMessage.NoConnection };
            }
            return response;
        }
    }
}
