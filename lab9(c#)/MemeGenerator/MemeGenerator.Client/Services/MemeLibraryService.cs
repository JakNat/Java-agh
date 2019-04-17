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
    public class MemeLibraryService
    {
        private readonly IClientRequests clientRequests;

        public MemeLibraryService(IClientRequests clientRequests)
        {
            this.clientRequests = clientRequests;
        }

        public async Task<List<MemeDto>> LoadMemeByUserAction()
        {
            List<MemeDto> response;
            try
            {
                response = await Task.Run(() => clientRequests.LoadMemeByUser());
            }
            catch (ExpectedReturnTimeoutException)
            {
                response = null;
            }
            catch (Exception)
            {
                response = null;
            }
            return response;
        }

        public async Task<List<MemeDto>> LoadMemeByTitleAction(string searchByNameProperty)
        {
            List<MemeDto> response;
            try
            {
                response = await Task.Run(() => clientRequests.LoadMemeByTitle(searchByNameProperty));
            }
            catch (ExpectedReturnTimeoutException)
            {
                response = null;
            }
            catch (Exception)
            {
                response = null;
            }
            return response;
        }
    }
}
