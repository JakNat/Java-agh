using MemeGenerator.Client.Requests;
using MemeGenerator.Model.Dto;
using MemeGenerator.Model.Responses;
using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Client.Services
{
    public class MemeCreatorService
    {
        private readonly IClientRequests clientRequests;

        public MemeCreatorService(IClientRequests clientRequests)
        {
            this.clientRequests = clientRequests;
        }

        public async Task<BaseResponseDto> CreateByServerAction(MemeDto meme)
        {
            BaseResponseDto response;
            try
            {
                response = await Task.Run(() => clientRequests.CreateRequest(meme));
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
