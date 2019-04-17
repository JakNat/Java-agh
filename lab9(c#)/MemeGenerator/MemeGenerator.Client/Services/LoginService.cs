using MemeGenerator.Client.Requests;
using MemeGenerator.Model.Dto;
using MemeGenerator.Model.Responses;
using NetworkCommsDotNet;
using System;
using System.Threading.Tasks;

namespace MemeGenerator.Client.Services
{
    public class LoginService
    {
        private readonly IClientRequests clientRequests;

        public LoginService(IClientRequests clientRequests)
        {
            this.clientRequests = clientRequests;
        }

        public async Task<LoginResponseDto> LoginButtonAction(LoginDto loginDto)
        {
            LoginResponseDto response;
            try
            {
                response = await Task.Run(() => clientRequests.LoginRequest(loginDto));
            }
            catch (ExpectedReturnTimeoutException)
            {
                response = new LoginResponseDto() { Message = ResponseMessage.TimeOut };
            }
            catch (Exception)
            {
                response = new LoginResponseDto() { Message = "No Connection" };
            }
            return response;
        }
    }
}
